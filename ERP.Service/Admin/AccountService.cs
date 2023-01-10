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
using ERP.Models.SP;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Admin;

public class AccountService : IAccountService
{
     
    private readonly ISecurity _security;
    private readonly IJwtManager _jwtManager;
    private readonly IUnitOfWork _uw;
 
    public AccountService(ISecurity security, IJwtManager jwtManager, IUnitOfWork uw)
    {
        _security = security;
        _jwtManager = jwtManager;
        _uw = uw;
    }
        
    public async Task<dynamic> GetUsersForModalAsync()
    {                              
        return await _uw.GetRepository<AdminUser>().GetAll(x => x.Status == (short)BaseStatus.Active).Select(x => new { x.Id, x.UserName, x.FirstName, x.LastName }).ToListAsync(); 
    }

    public async Task<AdminUser> GetAccountByTokenAsync(string token)
    {
       var session =await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login && x.AdminUser.Status == (short)BaseStatus.Active).Include(e => e.AdminUser).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Token is invalid.");
   
        return session.AdminUser;
    }

    public async Task<EMPEmployee> GetEmployeeByUserIdAsync(int? userId)
    {
        var account = await _uw.GetRepository<AdminUser>().GetAll(x=> x.Status == (short)BaseStatus.Active && x.EMPEmployee.Status == (short)BaseStatus.Active && x.Id == userId).Include(e => e.EMPEmployee).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (account == null)
            throw new ValidationException(ErrorList.NotFound, "Employee is not found.");
 
        return account.EMPEmployee;
    }

    public async Task<EMPEmployee> GetEmployeeByTokenAsync(string token)
    {
        var session = await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login && x.AdminUser.Status == (short)BaseStatus.Active && x.AdminUser.EMPEmployee.Status == (short)BaseStatus.Active).Include(e => e.AdminUser).ThenInclude(x=>x.EMPEmployee).FirstOrDefaultAsync();
        //var session = sessionLst.Where(x => x.Token == token && x.IsValid).FirstOrDefault();
        if (session == null)
            throw new ValidationException(ErrorList.NotFound, "Token is invalid.");

        return session.AdminUser.EMPEmployee;                       
    }

    public async Task<bool> IsAuthenticatedAsync(string token)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

        return await _uw.GetRepository<Session>().ExistDataAsync(x => x.Token == token && x.Status == (short)SessionStatus.Login);
    }

    public async Task<bool> IsAuthenticatedRoleAsync(string token, string role)
    {
        if (string.IsNullOrEmpty(token.Trim()))
            throw new ValidationException(ErrorList.NotFound, "Token is required.");

        var user = await _uw.GetRepository<Session>().GetAll(x => x.Token == token && x.Status == (short)SessionStatus.Login && x.AdminUser.Status == (short)BaseStatus.Active).Include(e => e.AdminUser) .FirstOrDefaultAsync();

        var Params = new List<SqlParameter>();
        Params.Add(new SqlParameter("@UserId", user.AdminUser.Id));
        Params.Add(new SqlParameter("@RoleName", role));
        var spResult = await _uw.GetRepository<SPIntResult>().FromSqlRaw("EXEC dbo.PermissionCheck @UserId = @UserId, @RoleName = @RoleName", Params.ToArray()).ToListAsync();

        if (spResult.FirstOrDefault().SpReturnResult == 0)
        {
            return false;
        }    
                   
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
        _uw.SaveChanges();

    }

    public async Task<ResetPasswordDto> ResetPasswordAsync(ResetPasswordDto model, int? userId)
    {

        var currentAccount =await _uw.GetRepository<AdminUser>().GetByIdAsync(userId);

        if (currentAccount.PassWord != _security.HashPassword(model.OldPassword))
            throw new ValidationException(ErrorList.NotFound, "کلمه عبور قدیمی صحیح نمی باشد.");

        currentAccount.PassWord = _security.HashPassword(model.Password);
        currentAccount.UpdateDateTime = DateTime.Now;
        currentAccount.Status = (short)BaseStatus.Active;
        currentAccount.VerificationCode = string.Empty;

        _uw.GetRepository<AdminUser>().Update(currentAccount);
        _uw.SaveChanges();

        return model;
    }

}
