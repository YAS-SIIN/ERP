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
        public async Task<ActionResult<ApiResultViewModel<string>>> GetPersianDateAsync()
        {
 
            var result = DateTime.Now.ToPersianDate();

            return OkData(result);
        }
    }
}
