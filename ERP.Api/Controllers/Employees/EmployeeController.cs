using ERP.Api.Middlewares;
using ERP.Dtos.Employees;
using ERP.Dtos.Exceptions;
using ERP.Dtos.Other;
using ERP.Models.Employees;
using ERP.Service.Employees;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Api.Controllers.Employees;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ApiControllerBase
{
   
    private readonly ICrudService<EMPEmployee> _crudService;  
    private readonly IEmployeesService _employeesService;
    public EmployeeController(ICrudService<EMPEmployee> crudService, IEmployeesService employeesService)
    {
  
        _crudService = crudService;
        _employeesService = employeesService;
    }

    [HttpPost, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAsync()
    {
        var result = await _crudService.GetAllAsync(x=>x.Status != (short)BaseStatus.Deleted);

        return OkData(result);
    }

    [HttpPost, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> InsertAsync([FromForm] EmplopyeeInDto model)
    {
      //  model.
 
        EMPEmployee employeeModel = Newtonsoft.Json.JsonConvert.DeserializeObject<EMPEmployee>(model.EMPEmployee);

        ModelState.ClearValidationState(nameof(model));
        if (!TryValidateModel(employeeModel, nameof(employeeModel)))
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }
          
            var result = await _employeesService.InsertEmployeeAsync(employeeModel, model.File);

        return OkData(result);
    }

    [HttpPut, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> UpdateAsync([FromForm] EmplopyeeInDto model)
    {
        EMPEmployee employeeModel = Newtonsoft.Json.JsonConvert.DeserializeObject<EMPEmployee>(model.EMPEmployee);
        ModelState.ClearValidationState(nameof(model));
        if (!TryValidateModel(employeeModel, nameof(employeeModel)))
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }

        var result = await _employeesService.UpdateEmployeeAsync(employeeModel, model.File);

        return OkData(result);
    }

    [HttpPut, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> ConfirmAsync(int Id)
    {
     
        var result = await _employeesService.ConfirmEmployeeAsync(Id);

        return OkData(result);
    }

    [HttpDelete, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> DeleteAsync(int Id)
    {
        var result = await _employeesService.DeleteEmployeeAsync(Id);

        return OkData(result);
    }

}
