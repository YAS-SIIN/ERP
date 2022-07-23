 
using ERP.Dtos.Employees;     
using ERP.Models.Employees;

 

namespace ERP.Service.Admin;

public interface IEmployeesService
{
    Task<EMPEmployee> InsertEmployeeAsync(EmplopyeeInDto model);
    Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model);
    Task<EMPEmployee> DeleteEmployeeAsync(int Id);

}
