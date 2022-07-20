using ERP.Dtos.Admin;
using ERP.Models.Admin;
using ERP.Models.Employees;

using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Admin;

public interface IEmployeesService
{
    Task<EMPEmployee> InsertEmployeeAsync(EMPEmployee model);
    Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model);
    Task<EMPEmployee> DeleteEmployeeAsync(EMPEmployee model);

}
