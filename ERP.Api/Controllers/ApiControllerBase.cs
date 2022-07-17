using ERP.Common;
using ERP.Dtos.Exceptions;
using ERP.Dtos.Other;

using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

public class ApiControllerBase : Controller
{
    public UserSessionModel UserSession => (UserSessionModel)HttpContext.Items["UserSession"];

    public OkObjectResult OkData<TData>(TData data, object meta = null)
    {
        return Ok(ApiResultViewModel<TData>.FromData(data, meta));
    }
}
