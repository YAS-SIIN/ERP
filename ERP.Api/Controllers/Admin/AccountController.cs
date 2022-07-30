using ERP.Api.Middlewares;
using ERP.Common.Enums;
using ERP.Dtos.Admin;
using ERP.Dtos.Exceptions;
using ERP.Framework.Exceptions;
using ERP.Models.Employees;
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
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }
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
    [Authorize]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAccountInfo(string token)
    {
        var Resualt = await _accountService.GetEmployeeByToken(token);
                                 
        EMPEmployee newModel = new EMPEmployee();
        newModel.FirstName = Resualt.FirstName;
        newModel.LastName = Resualt.LastName;
        newModel.EmpoloyeeNo = Resualt.EmpoloyeeNo;    

        return OkData(newModel);
    }


    [HttpPost, Route("[action]")]
    public async Task ResetPasswordVerificationCodeAsync([FromBody] ResetPasswordVerificationCodeInputModel model)
    {
        if (UserSession != null && UserSession?.UserId != null)
            throw new ValidationException(ErrorList.LoginedUser, "You're logged-in already.");           

        await _accountService.ResetPasswordVerificationCodeAsync(model.MobileNumber);
    }

    [HttpPost, Route("[action]")]
    [Authorize]
    public async Task ResetPassword([FromBody] ResetPasswordInputModel model)
    {
        if (UserSession != null && UserSession?.UserId != null)
            throw new ValidationException(ErrorList.LoginedUser, "You're logged-in already.");

        await _accountService.ResetPasswordAsync(model.MobileNumber, model.Password, model.VerificationCode);
    }

}
