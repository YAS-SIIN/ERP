using ERP.Common;
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

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.GetAllAsync();

        return OkData(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PostAsync([FromBody] EMPEmployee model)
    {
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }

        var result = await _employeesService.InsertEmployeeAsync(model);

        return OkData(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PutAsync([FromBody] EMPEmployee model)
    {
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("", "This record already exists."); // a cross field validation
            return BadRequest(ModelState);
        }

        var result = await _employeesService.UpdateEmployeeAsync(model);

        return OkData(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> DeleteAsync([FromBody] EMPEmployee model)
    {
        var result = await _employeesService.DeleteEmployeeAsync(model);

        return OkData(result);
    }

}
