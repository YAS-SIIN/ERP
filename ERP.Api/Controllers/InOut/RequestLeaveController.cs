using ERP.Api.Middlewares;
using ERP.Dtos.Exceptions;
using ERP.Dtos.Other;
using ERP.Models.Admin;
 
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Service.Admin;
using ERP.Service.Crud;
using ERP.Service.InOut;

using Microsoft.AspNetCore.Mvc;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Api.Controllers.InOut
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLeaveController : ApiControllerBase
    {
        private readonly ICrudService<InOutRequestLeave> _crudService;
        private readonly IAccountService _accountService;
        private readonly IRequestLeaveService _requestLeaveService;
        public RequestLeaveController(ICrudService<InOutRequestLeave> crudService, IAccountService accountService, IRequestLeaveService requestLeaveService)
        {          
            _crudService = crudService;
            _accountService = accountService;
            _requestLeaveService = requestLeaveService; 
        }
                            
        [HttpPost, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> GetAsync()
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Items["UserSession"];
            EMPEmployee employee = await _accountService.GetEmployeeByToken(session.Token);     

            var result = await _requestLeaveService.GetUserAllAsync(employee);

            return OkData(result);
        }

        [HttpPost, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> InsertAsync([FromForm] InOutRequestLeave model)
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Items["UserSession"];
            EMPEmployee employee = await _accountService.GetEmployeeByToken(session.Token);
            model.EMPEmployee = employee;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _crudService.InsertAsync(model);

            return OkData(result);
        }

        [HttpPut, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> UpdateAsync([FromForm] InOutRequestLeave model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _crudService.UpdateAsync(model);

            return OkData(result);
        }

        [HttpPut, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> ConfirmAsync(int Id)
        {
            InOutRequestLeave model = await _crudService.GetByIdAsync(Id);
            model.Status = (short)BaseStatus.Active;
            model.UpdateDateTime = DateTime.Now;
            var result = await _crudService.UpdateAsync(model);

            return OkData(result);
        }

        [HttpDelete, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> DeleteAsync(int Id)
        {
            InOutRequestLeave model = await _crudService.GetByIdAsync(Id);
            model.Status = (short)BaseStatus.Deleted;
            model.UpdateDateTime = DateTime.Now;
            var result = await _crudService.UpdateAsync(model);

            return OkData(result);
        }
    }
}
