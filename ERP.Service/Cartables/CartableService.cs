
using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Dtos.Cartables;
using ERP.Dtos.Employees;
using ERP.Entities.UnitOfWork;
using ERP.Framework.Exceptions;
using ERP.Models.Admin;
using ERP.Models.Cartables;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Models.SP;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Cartables;

public class CartableService : ICartableService
{                                         
    private readonly IUnitOfWork _uw;                                                                    
    public CartableService(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<List<SPCARSignList>> GetAllByUserAsync(CartableDto model, int? userId)
    {
        var Params = new List<SqlParameter>();
        Params.Add(new SqlParameter("@UserId", userId));
        Params.Add(new SqlParameter("@Status", model.Status));

        return await _uw.GetRepository<SPCARSignList>().FromSqlRaw("EXEC dbo.CARSignList @UserId = @UserId, @Status = @Status", Params.ToArray()).ToListAsync();
    }

    public async Task<SPCARSignList> ConfirmRequestAsync(SPCARSignList model)
    {
                              
        var Params = new List<SqlParameter>();          
        Params.Add(new SqlParameter("@FieldCode", model.FieldCode));
        Params.Add(new SqlParameter("@RequestDate", model.RequestDate));
        Params.Add(new SqlParameter("@TableName", model.TableName.ToString()));        
        Params.Add(new SqlParameter("@EmployeeId", model.EMPEmployeeId));      
        Params.Add(new SqlParameter("@DeleteFlag", model.Status));
        Params.Add(new SqlParameter("@Description", ""));
        Params.Add(new SqlParameter("@OrderNoIN", model.Status== 1 ?model.OrderNo.ToString() : "0"));
        Params.Add(new SqlParameter("@SignDate", DateTime.Now.ToPersianDate()));            

        
        //var a =_uw.ExecuteSqlRaw("EXEC [dbo].[CARSignRecord] @TableId = 2, @FieldCode = @FieldCode, @RequestDate = @RequestDate, @EmployeeId = @EmployeeId, @DeleteFlag = 0, @Description = @Description, @OrderNoIN = 0, @SignDate = @SignDate, @ConfirmType = 0", Params.ToArray());
       var spResult = await _uw.GetRepository<SPIntResult>().FromSqlRaw("DECLARE	@SpReturnResult int; EXEC @SpReturnResult = dbo.CARSignRecord @TableName = @TableName, @FieldCode = @FieldCode, @RequestDate = @RequestDate, @EmployeeId = @EmployeeId, @DeleteFlag = @DeleteFlag, @Description = @Description, @OrderNoIN = @OrderNoIN, @SignDate = @SignDate, @ConfirmType = 0; SELECT	'SpReturnResult' = @SpReturnResult", Params.ToArray()).ToListAsync();

        if (spResult.FirstOrDefault().SpReturnResult == 0)
        {
            throw new ValidationException(ErrorList.NotAccess, "شما به این امضاء دسترسی ندارید.");
        }
        if (spResult.FirstOrDefault().SpReturnResult == 2)
        {
            throw new ValidationException(ErrorList.NotFound, "امضاء مورد نظر یافت نشد.");
        }
 
                  
        _uw.SaveChanges();

        return model;
    }

    public async Task<dynamic> GetByIdAsync(string FieldCode, string TableName)
    {

        var lst = await _uw.GetRepository<CARCartableTrace>()
       .GetAll(x => x.CARTable.TableName == TableName && x.Status == (short)BaseStatus.Active)
       .Select(x => new
       {
           CartableSigne = x,
           CartableSigned = _uw.GetRepository<CARCartable>().GetAll().Where(a => a.CARCartableTrace.Id == x.Id && a.Status == (short)BaseStatus.Active && a.FieldCode == FieldCode).Include(x => x.EMPEmployee).Select(b => new {  b.SignDate, SignTime= b.CreateDateTime.ToShortTimeString(), Employee= b.EMPEmployee.FirstName + " " + b.EMPEmployee.LastName, b.EMPEmployee.EmpoloyeeNo }).ToList(),           
       })
       .ToListAsync();
 
        return lst;

    }      
}

