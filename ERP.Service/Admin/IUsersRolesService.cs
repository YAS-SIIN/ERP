using ERP.Dtos.Admin;
using ERP.Models.Admin;
using ERP.Models.Employees;

using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Admin;

public interface IUsersRolesService
{
    Task<dynamic> GetRolesByUserAsync(int UserId);
    Task<AdminUserRole> InsertUpdateUserRoleAsync(UserRoleDto model);
}
