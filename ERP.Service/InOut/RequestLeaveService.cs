
using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Dtos.Cartables;
using ERP.Dtos.Employees;
using ERP.Entities.UnitOfWork;
using ERP.Framework.Exceptions;
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Models.Other;

using Microsoft.Data.SqlClient;
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

    public async Task<InOutRequestLeave> ConfirmRequestLeaveAsync(int Id, int EmployeeId)
    {

        InOutRequestLeave model = await _uw.GetRepository<InOutRequestLeave>().GetAsync(x => x.Id == Id && x.Status == (short)BaseStatus.Deactive);
        if (model == null)
        {
            throw new ValidationException(ErrorList.NotFound, "مرخصی مورد نظر یافت نشد.");
        }

        var Params = new List<SqlParameter>();       
        Params.Add(new SqlParameter("@FieldCode", model.Id.ToString()));
        Params.Add(new SqlParameter("@RequestDate", model.RequestDate));
        Params.Add(new SqlParameter("@EmployeeId", EmployeeId));   
        Params.Add(new SqlParameter("@Description", model.Description));
        Params.Add(new SqlParameter("@SignDate", DateTime.Now.ToPersianDate()));            

        model.UpdateDateTime = DateTime.Now;
        model.Status = (short)BaseStatus.Active;
        //var a =_uw.ExecuteSqlRaw("EXEC [dbo].[CARSignRecord] @TableId = 2, @FieldCode = @FieldCode, @RequestDate = @RequestDate, @EmployeeId = @EmployeeId, @DeleteFlag = 0, @Description = @Description, @OrderNoIN = 0, @SignDate = @SignDate, @ConfirmType = 0", Params.ToArray());
       var a = _uw.GetRepository<SPIntResult>().FromSqlRaw("DECLARE	@SpReturnResult int; EXEC	@SpReturnResult = dbo.CARSignRecord @TableId = 2, @FieldCode = @FieldCode, @RequestDate = @RequestDate, @EmployeeId = @EmployeeId, @DeleteFlag = 0, @Description = @Description, @OrderNoIN = 0, @SignDate = @SignDate, @ConfirmType = 0; SELECT	'SpReturnResult' = @SpReturnResult", Params.ToArray());

        if (a.ToList().FirstOrDefault().SpReturnResult == 0)
        {
            throw new ValidationException(ErrorList.NotAccess, "شما به این امضاء دسترسی ندارید.");
        }
        if (a.ToList().FirstOrDefault().SpReturnResult == 2)
        {
            throw new ValidationException(ErrorList.NotFound, "امضاء مورد نظر یافت نشد.");
        }
        _uw.GetRepository<InOutRequestLeave>().Update(model);
                  
        _uw.SaveChanges();

        return model;
    }

}

