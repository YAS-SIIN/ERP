
using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Entities.UnitOfWork;
using ERP.Framework.Exceptions;
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
        return await _uw.GetRepository<InOutRequestLeave>().GetAll(x => x.Status != (short)BaseStatus.Deleted && x.EMPEmployee.Id == employee.Id).ToListAsync();
    }

    public async Task<InOutRequestLeave> ConfirmRequestLeaveAsync(int Id)
    {

        InOutRequestLeave model = await _uw.GetRepository<InOutRequestLeave>().GetAsync(x => x.Id == Id && x.Status == (short)BaseStatus.Deactive);
        if (model == null)
        {
            throw new ValidationException(ErrorList.NotFound, "مرخصی مورد نظر یافت نشد.");
        }

        model.UpdateDateTime = DateTime.Now;
        model.Status = (short)BaseStatus.Active;
  
   
        var a = _uw.ExecuteSqlComman("EXEC [dbo].[CARSignRecord] @CARCartableTraceId = 3, @FieldCode = " + model.Id + ", @RequestDate = '" + model.RequestDate + "', @EmployeeId = 1, @DeleteFlag =0, @Description = N'test',  @SignDate = N'"+ DateTime.Now.ToPersianDate()+"'");

        _uw.GetRepository<InOutRequestLeave>().Update(model);
                  
        _uw.SaveChanges();

        return model;
    }

}

