using ERP.Api.Middlewares;
using ERP.Dtos.Employees;
using ERP.Dtos.Exceptions;
using ERP.Models.Employees;
using ERP.Service.Admin;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.GetAllAsync();

        return OkData(result);
    }

    [HttpPost]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PostAsync()
    {
        var file = Request.Form.Files[0];
        EMPEmployee employeeModel = Newtonsoft.Json.JsonConvert.DeserializeObject<EMPEmployee>(Request.Form.ToList()[0].Value);
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }
        if (file.Length <= 0)
        {
            ModelState.AddModelError("", "The Employee Picture Not found."); // a cross field validation
            return BadRequest(ModelState);
        }

            var result = await _employeesService.InsertEmployeeAsync(employeeModel, file);

        return OkData(result);
    }

    [HttpPut]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PutAsync([FromBody] EmplopyeeInDto model)
    {
        EMPEmployee employeeModel = Newtonsoft.Json.JsonConvert.DeserializeObject<EMPEmployee>(model.EMPEmployee);
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }

        var result = await _employeesService.UpdateEmployeeAsync(employeeModel, model.File);

        return OkData(result);
    }

    [HttpPut, Route("[action]")]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> ConfirmAsync([FromBody] int Id)
    {
     
        var result = await _employeesService.ConfirmEmployeeAsync(Id);

        return OkData(result);
    }

    [HttpDelete]
    [Authorize(Role = "Employee")]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> DeleteAsync([FromBody] int Id)
    {
        var result = await _employeesService.DeleteEmployeeAsync(Id);

        return OkData(result);
    }

}
