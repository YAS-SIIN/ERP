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
using ERP.Models.Employees;
using ERP.Models.Other;

using Microsoft.EntityFrameworkCore;
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
       var session =await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login && x.AdminUser.Status == (short)BaseStatus.Active).Include(e => e.AdminUser).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Token is invalid.");
   
        return session.AdminUser;
    }

    public async Task<EMPEmployee> GetEmployeeByAccount(AdminUser user)
    {
        var account = await _uw.GetRepository<AdminUser>().GetAll(x=> x.Status == (short)BaseStatus.Active && x.EMPEmployee.Status == (short)BaseStatus.Active && x.Id == user.Id).Include(e => e.EMPEmployee).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "Employee is not found.");
 
        return account.EMPEmployee;
    }

    public async Task<EMPEmployee> GetEmployeeByToken(string token)
    {
        var session = await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login && x.AdminUser.Status == (short)BaseStatus.Active).Include(e => e.AdminUser).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Token is invalid.");

        var account = await _uw.GetRepository<AdminUser>().GetAll(x => x.Status == (short)BaseStatus.Active && x.EMPEmployee.Status == (short)BaseStatus.Active && x.Id == session.AdminUser.Id).Include(e => e.EMPEmployee).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "Employee is not found.");

        return account.EMPEmployee;                       
    }

    public async Task<bool> IsAuthenticated(string token)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

        return await _uw.GetRepository<Session>().ExistDataAsync(x => x.Token == token && x.Status == (short)SessionStatus.Login);
    }

    public async Task<bool> IsAuthenticatedRole(string token, string role)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

     
var session =await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login).
            Include(a=>a.AdminUser).
            ThenInclude(b => b.AdminUserRole.Where(x => x.AdminRole.RoleName == role && x.AdminRole.Status == (short)BaseStatus.Active)).
            ThenInclude(c => c.AdminRole).ToListAsync();
                                                       

        if (session == null)
            return false;

        return true;

    }

    public async Task<LoginModel> LoginAsync(UserLoginDto userLogin)
    {

        var account =await _uw.GetRepository<AdminUser>().GetAsync(x => x.UserName.ToLower() == userLogin.UserName.Trim().ToLower() && x.Status == (short)BaseStatus.Active);
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "کاربر مورد نظر یافت نشد.");

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
            Token = token
        };

        await _uw.GetRepository<Session>().AddAsync(session);
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

        var session =await _uw.GetRepository<Session>().GetAsync(x => x.Token == token && x.Status == (short)SessionStatus.Login);
  
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Session not found.");
                                   
        session.Status = (short)SessionStatus.Logout;
        session.UpdateDateTime = DateTime.Now;

         _uw.GetRepository<Session>().Update(session);
        _uw.SaveChanges();
    }

    public async Task ResetPasswordVerificationCodeAsync(string mobileNumber)
    {
        var currentAccount = await _uw.GetRepository<AdminUser>().GetAsync(x => x.MobileNo == mobileNumber.Trim().ToLower() && x.Status == (short)BaseStatus.Active);
        if (currentAccount == null)
            throw new ValidationException(ErrorList.NotFound, "کاربر مورد نظر یافت نشد.");

        var verificationCode = new Random().Next(1000, 9999).ToString();
        currentAccount.VerificationCode = verificationCode;
        currentAccount.UpdateDateTime = DateTime.Now;
        currentAccount.Status = (short)BaseStatus.Active;

        //await _notificationHandler.SendVerificationCodeAsync(mobileNumber, verificationCode, cancellationToken);
        _uw.GetRepository<AdminUser>().Update(currentAccount);
        _uw.SaveChangesAsync();

    }

    public async Task ResetPasswordAsync(string UserName, string password, string verificationCode)
    {
        var currentAccount = await _uw.GetRepository<AdminUser>().GetAsync(x => x.UserName.ToLower() == UserName.Trim().ToLower() && x.Status == (short)BaseStatus.Active);
        if (currentAccount == null)
            throw new ValidationException(ErrorList.NotFound, "کاربر مورد نظر یافت نشد.");

        if (currentAccount.VerificationCode != verificationCode)
            throw new ValidationException(ErrorList.NotFound, "Verification code is not working.");
                                            
        currentAccount.PassWord = _security.HashPassword(password);
        currentAccount.UpdateDateTime = DateTime.Now;
        currentAccount.Status = (short)BaseStatus.Active;
        currentAccount.VerificationCode = string.Empty;

        _uw.GetRepository<AdminUser>().Update(currentAccount);
        _uw.SaveChangesAsync();
    }

}
