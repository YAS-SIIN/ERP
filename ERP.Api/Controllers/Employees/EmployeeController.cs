using ERP.Dtos.Exceptions;
using ERP.Models.Employees;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.Employees;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ApiControllerBase
{
 
    private readonly ICrudService<EMPEmployee> _crudService;
    public EmployeeController(ICrudService<EMPEmployee> crudService)
    {
        _crudService = crudService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.GetAllAsync();

        return OkData(result);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> GetAsync([FromBody] int Id)
    {
        var result = await _crudService.GetByIdAsync(Id);

        return OkData(result);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PostAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.InsertAsync(model);

        return OkData(result);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> PutAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.UpdateAsync(model);

        return OkData(result);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResultViewModel<EMPEmployee>>> DeleteAsync([FromBody] EMPEmployee model)
    {
        var result = await _crudService.DeleteAsync(model);

        return OkData(result);
    }

}
