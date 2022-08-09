
using ERP.Dtos.Cartables;
using ERP.Models.Admin;
using ERP.Models.Cartables;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Models.SP;

namespace ERP.Service.Cartables;

public interface ICartableService
{
    Task<List<SPCARSignList>> GetAllByUserAsync(CartableDto model, int? userId);
    Task<SPCARSignList> ConfirmRequestAsync(SPCARSignList model);
    Task<dynamic> GetByIdAsync(string FieldCode, string TableName);
}
