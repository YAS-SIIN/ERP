using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Dtos.Other;
using ERP.Entities.UnitOfWork;
using ERP.Framework;
using ERP.Framework.Exceptions;

using ERP.Models;
using ERP.Models.Admin;
using ERP.Models.Other;

using Microsoft.Extensions.Options;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Admin;

public class AccountService : IAccountService
{
     
    private readonly ISecurity _security;
    private readonly IJwtManager _jwtManager;
    private readonly IUnitOfWork _uw;
 
    public AccountService(IOptionsMonitor<ApplicationOptions> options, ISecurity security, IJwtManager jwtManager, IUnitOfWork uw)
    {
        _security = security;
        _jwtManager = jwtManager;
        _uw = uw;
    }

    public async Task<AdminUser> GetAccountByToken(string token)
    {
        var session = await _uw.GetRepository<Session>().GetAsync(x => x.Token == token && x.IsValid);
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Token is invalid.");

        var account = await _uw.GetRepository<AdminUser>().GetAsync(x => x.Id == session.AdminUser.Id);
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "Account already exists.");

        return account;
    }
                  
    public async Task<bool> IsAuthenticated(string token)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

        return await _uw.GetRepository<Session>().ExistDataAsync(x => x.Token == token && x.IsValid);
    }

    public async Task<LoginModel> LoginAsync(UserLoginDto userLogin)
    {
        if (string.IsNullOrEmpty(userLogin.UserName.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Username is required.");

        if (string.IsNullOrEmpty(userLogin.PassWord))
            throw new ValidationException(ErrorList.NotFound, "Password is required.");

        var account =await _uw.GetRepository<AdminUser>().GetAsync(x => x.UserName.ToLower() == userLogin.UserName.Trim().ToLower());
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "Account not found.");

        //if (!_security.VerifyHashedPassword(account.PassWord, userLogin.PassWord))
        //    throw new ValidationException(ErrorList.NotFound, "Username or password is not valid.");

        var sessionUser = Guid.NewGuid().ToString();
        var expirationDate = DateTime.Today.AddDays(365);


        var token = _jwtManager.GenerateToken(sessionUser, account.Id, account.FirstName, account.LastName, expirationDate);

        var session = new Session()
        {
            CreateDateTime = DateTime.Now,    
            SessionUser = sessionUser,
            UpdateDateTime = DateTime.Now,
            Status = (short)SessionStatus.Login,
            AdminUser = account,
            ExpirationDate = expirationDate,
            IsValid = true,
            Token = token
        };

         _uw.GetRepository<Session>().Add(session);
        _uw.SaveChanges();
        return new LoginModel()
        {
            ExpirationDate = session.ExpirationDate,
            IsSuccessful = true,
            Token = session.Token
        };
    }

    public async Task LogoutAsync(string token)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

        var session =await _uw.GetRepository<Session>().GetAsync(x => x.Token == token && x.IsValid);
  
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Session not found.");

        session.IsValid = false;
        session.Status = (short)SessionStatus.Logout;
        session.UpdateDateTime = DateTime.Now;

         _uw.GetRepository<Session>().Update(session);
        _uw.SaveChangesAsync();
    }

    public async Task ResetPasswordVerificationCodeAsync(string mobileNumber)
    {
        var currentAccount = await _uw.GetRepository<AdminUser>().GetAsync(x => x.MobileNo == mobileNumber.Trim().ToLower());
        if (currentAccount == null)
            throw new ValidationException(ErrorList.NotFound, $"Account not found.");

        var verificationCode = new Random().Next(1000, 9999).ToString();
        currentAccount.VerificationCode = verificationCode;
        currentAccount.UpdateDateTime = DateTime.Now;
        currentAccount.Status = (short)UserStatus.Active;

        //await _notificationHandler.SendVerificationCodeAsync(mobileNumber, verificationCode, cancellationToken);
        _uw.GetRepository<AdminUser>().Update(currentAccount);
        _uw.SaveChangesAsync();

    }

    public async Task ResetPasswordAsync(string UserName, string password, string verificationCode)
    {
        var currentAccount = await _uw.GetRepository<AdminUser>().GetAsync(x => x.UserName.ToLower() == UserName.Trim().ToLower());
        if (currentAccount == null)
            throw new ValidationException(ErrorList.NotFound, "Account not found.");

        if (currentAccount.VerificationCode != verificationCode)
            throw new ValidationException(ErrorList.NotFound, "Verification code is not working.");
                                            
        currentAccount.PassWord = _security.HashPassword(password);
        currentAccount.UpdateDateTime = DateTime.Now;
        currentAccount.Status = (short)UserStatus.Active;
        currentAccount.VerificationCode = string.Empty;

        _uw.GetRepository<AdminUser>().Update(currentAccount);
        _uw.SaveChangesAsync();
    }

}
