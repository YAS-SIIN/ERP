 
using ERP.Entities.UnitOfWork;
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.InOut;  
                       
using Microsoft.EntityFrameworkCore;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.InOut;

public class RequestLeaveService : IRequestLeaveService
{                                         
    private readonly IUnitOfWork _uw;                                                                    
    public RequestLeaveService(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<List<InOutRequestLeave>> GetUserAllAsync(EMPEmployee employee)
    {
        return await _uw.GetRepository<InOutRequestLeave>().GetAll(x => x.Status != (short)BaseStatus.Deleted).Include(x=>x.EMPEmployee == employee).ToListAsync();
    }  
}
