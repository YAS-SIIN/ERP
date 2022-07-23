using ERP.Service.Admin;
using ERP.Dtos.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
 
using System;


namespace ERP.Api.Middlewares;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{                                                     
    public string? Role { get; set; } = string.Empty;
 
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        UserSessionModel session = (ERP.Dtos.Other.UserSessionModel)context.HttpContext.Items["UserSession"];
        if (context.HttpContext.Request.Path.Value == "/api/session" & context.HttpContext.Request.Method == HttpMethods.Delete & session == null)
        {
            context.Result = new  OkResult();
            return;

        }
          
        if (session == null)
        {
            // not logged in
            //context.Result = new UnauthorizedResult();
            //return;
        }

        Role = "Test";
        if (!String.IsNullOrEmpty(Role))
        {
           
 var accountService = context.HttpContext.RequestServices.GetService(typeof(IAccountService));
            var roleResault = (accountService as IAccountService).IsAuthenticatedRole(session.Token,Role);
            
                //context.Result = new UnauthorizedResult();
                //return;
             

        }
    }
}
