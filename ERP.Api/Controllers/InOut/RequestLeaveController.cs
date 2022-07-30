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
using ERP.Dtos.InOut;

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
        public async Task<ActionResult<ApiResultViewModel<InOutRequestLeave>>> GetAsync([FromBody] RequestLeaveFilterDto model)
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Items["UserSession"];
            EMPEmployee employee = await _accountService.GetEmployeeByToken(session.Token);     

            var result = await _requestLeaveService.GetUserAllAsync(employee);

            if (model.Year != 0 && model.Year != null)
            {
                result = result.Where(x => Convert.ToInt32(x.RequestDate.Substring(0, 4)) >= Convert.ToInt32(model.Year.ToString())).ToList();
            }                                                          
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
     
       
            var result = await _requestLeaveService.ConfirmRequestLeaveAsync(Id);

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
