using ERP.Dtos.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERP.Common.Shared;

namespace ERP.Api.Controllers.Other
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ApiControllerBase
    {

        [HttpPost, Route("[action]")]          
        public string GetPersianDate()
        {
 
            var result = DateTime.Now.ToPersianDate();

            return result;
        }
    }
}
