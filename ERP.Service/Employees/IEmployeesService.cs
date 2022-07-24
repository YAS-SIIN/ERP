 
using ERP.Dtos.Employees;     
using ERP.Models.Employees;

using Microsoft.AspNetCore.Http;

namespace ERP.Service.Admin;

public interface IEmployeesService
{
    Task<EMPEmployee> InsertEmployeeAsync(EMPEmployee model, IFormFile File);
    Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model, IFormFile File);
    Task<EMPEmployee> ConfirmEmployeeAsync(int Id);
    Task<EMPEmployee> DeleteEmployeeAsync(int Id);

}
