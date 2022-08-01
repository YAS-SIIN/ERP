
using ERP.Dtos.Cartables;
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Models.SP;

namespace ERP.Service.Cartables;

public interface ICartableService
{
    Task<List<SPCartableList>> GetAllByUserAsync(CartableDto model, AdminUser user);
    Task<InOutRequestLeave> ConfirmRequestAsync(int Id, int EmployeeId);
}
