using ERP.Api.Middlewares;
using ERP.Common.Enums;
using ERP.Dtos.Exceptions;
using ERP.Dtos.Other;
using ERP.Framework.Exceptions;
using ERP.Common.Shared;

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
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> InsertAsync([FromBody] InOutRequestLeave model)
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Items["UserSession"];
            EMPEmployee employee = await _accountService.GetEmployeeByToken(session.Token);
            model.EMPEmployee = employee;
            model.RequestDate = DateTime.Now.ToPersianDate();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _crudService.InsertAsync(model);

            return OkData(result);
        }

        [HttpPut, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> UpdateAsync([FromBody] InOutRequestLeave model)
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
     
            InOutRequestLeave model = await _crudService.GetAsync(x=>x.Id == Id && x.Status == (short)BaseStatus.Deactive);
            if (model == null)
            {
                throw new ValidationException(ErrorList.NotFound, "مرخصی مورد نظر یافت نشد."); 
            }
            model.Status = (short)BaseStatus.Active;
            model.UpdateDateTime = DateTime.Now;
            var result = await _crudService.UpdateAsync(model);

            return OkData(result);
        }

        [HttpDelete, Route("[action]")]
        [Authorize(Role = "RequestLeave")]
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> DeleteAsync(int Id)
        {
            InOutRequestLeave model = await _crudService.GetAsync(x => x.Id == Id && x.Status != (short)BaseStatus.Deleted);
            if (model == null)
            {
                throw new ValidationException(ErrorList.NotFound, "مرخصی مورد نظر یافت نشد.");
            }
            model.Status = (short)BaseStatus.Deleted;
            model.UpdateDateTime = DateTime.Now;
            var result = await _crudService.UpdateAsync(model);

            return OkData(result);
        }
    }
}
