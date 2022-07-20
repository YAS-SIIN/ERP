﻿using ERP.Common;
using ERP.Dtos.Admin;
using ERP.Dtos.Exceptions;
using ERP.Framework.Exceptions;

using ERP.Service.Admin;


using Microsoft.AspNetCore.Mvc;


namespace ERP.Api.Controllers.Admin;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiControllerBase
{                                         
    private readonly IAccountService _accountService;
    public AccountController( IAccountService accountService)
    {                             
        _accountService = accountService;
    }

    [HttpPost, Route("[action]")]
    public async Task<ActionResult<ApiResultViewModel<LoginModel>>> LoginAsync([FromBody] UserLoginDto model)
    {
        var result = await _accountService.LoginAsync(model);

        return OkData(new LoginModel()
        {
            Token = result.Token,
            IsSuccessful = result.IsSuccessful,
            ExpirationDate = result.ExpirationDate
        });
    }

    [Authorize]
    [HttpPost, Route("[action]")]
    public async Task LogoutAsync()
    {
        await _accountService.LogoutAsync(UserSession.Token);
    }

    [HttpPost, Route("[action]")]
    public async Task<ActionResult<ApiResultViewModel<bool>>> IsAuthenticatedAsync([FromRoute] string token)
    {
        var isAuthenticated = await _accountService.IsAuthenticated(token);

        return OkData(isAuthenticated);
    }


    [HttpPost, Route("[action]")]
    public async Task ResetPasswordVerificationCodeAsync([FromBody] ResetPasswordVerificationCodeInputModel model)
    {
        if (UserSession != null && UserSession?.UserId != null)
            throw new ValidationException("100", "You're logged-in already.");

        await _accountService.ResetPasswordVerificationCodeAsync(model.MobileNumber);
    }

    [HttpPost, Route("[action]")]
    public async Task ResetPassword([FromBody] ResetPasswordInputModel model)
    {
        if (UserSession != null && UserSession?.UserId != null)
            throw new ValidationException("100", "You're logged-in already.");

        await _accountService.ResetPasswordAsync(model.MobileNumber, model.Password, model.VerificationCode);
    }

}