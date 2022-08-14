using ERP.Api.Middlewares;
using ERP.Dtos.Cartables;
using ERP.Dtos.Exceptions;     
using ERP.Service.Admin;            
using Microsoft.AspNetCore.Mvc;           
using ERP.Service.Cartables;
using ERP.Models.SP;
using ERP.Models.Employees;          

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
     

            var result = await _cartableService.GetAllByUserAsync(model, UserSession?.UserId);

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
        public async Task<ActionResult<ApiResultViewModel<dynamic>>> GetAsync(int Id, string TableName)
        {
            var result = await _cartableService.GetByIdAsync(Id.ToString(), TableName);

            return OkData(result);
        }

        [HttpPut, Route("[action]")]
        [Authorize]
        public async Task<ActionResult<ApiResultViewModel<SPCARSignList>>> ConfirmAsync(SPCARSignList model)
        {       
            EMPEmployee employee = await _accountService.GetEmployeeByUserIdAsync(UserSession?.UserId);
            model.EMPEmployeeId = employee.Id;
            
            var result = await _cartableService.ConfirmRequestAsync(model);

            return OkData(result);
        }
    }
}
