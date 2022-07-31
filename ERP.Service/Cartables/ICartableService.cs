
using ERP.Models.Admin;
using ERP.Models.Cartables;
using ERP.Models.Employees;
using ERP.Models.InOut;     

namespace ERP.Service.Cartables;

public interface ICartableService
{
    Task<List<CARCartableList>> GetAllByUserAsync(AdminUser user);
    Task<InOutRequestLeave> ConfirmRequestAsync(int Id, int EmployeeId);
}
