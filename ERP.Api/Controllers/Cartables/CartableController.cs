using ERP.Api.Middlewares;
using ERP.Dtos.Cartables;
using ERP.Dtos.Exceptions;
using ERP.Models.Cartables;
using ERP.Service.Admin;
using ERP.Service.Crud;
using ERP.Dtos.Other;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERP.Models.Admin;
using ERP.Service.Cartables;
using ERP.Models.SP;

namespace ERP.Api.Controllers.Cartables
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartableController : ApiControllerBase
    {                                                            
        private readonly IAccountService _accountService;
        private readonly ICartableService _cartableService;
        public CartableController(ICartableService cartableService, IAccountService accountService)
        {
            _cartableService = cartableService;
            _accountService = accountService;
        }
        [HttpPost, Route("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResultViewModel<SPCARSignList>>> GetAsync([FromBody] CartableDto model)
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Items["UserSession"];
            AdminUser user = await _accountService.GetAccountByToken(session.Token);

            var result = await _cartableService.GetAllByUserAsync(model, user);

            //if (model.Year != 0 && model.Year != null)
            //{
            //    //result = result.Where(x => Convert.ToInt32(x.RequestDate.Substring(0, 4)) >= Convert.ToInt32(model.Year.ToString())).ToList();
            //}
            //if (model.Status != 2)
            //{
            //    // result = result.Where(x => x.Status == model.Status).ToList();
            //}
            return OkData(result);
        }

        [HttpGet, Route("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResultViewModel<dynamic>>> GetAsync(int id, string FormName)
        {
            var result = await _cartableService.GetByIdAsync(id.ToString(), FormName);

            return OkData(result);
        }
    }
}
