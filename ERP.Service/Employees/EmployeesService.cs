using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Dtos.Other;
using ERP.Entities.UnitOfWork;
using ERP.Framework;
using ERP.Framework.Exceptions;

using ERP.Models;
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.Other;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Admin;

public class EmployeesService : IEmployeesService
{
    private readonly ISecurity _security;
    private readonly IUnitOfWork _uw;  
    public EmployeesService(IUnitOfWork uw, ISecurity security)
    {
        _security = security;
        _uw = uw;
    }

    public async Task<EMPEmployee> InsertEmployeeAsync(EMPEmployee model)
    {
                                                 
        await _uw.GetRepository<EMPEmployee>().AddAsync(model);
        AdminUser user = new AdminUser();
        model.EmpoloyeeNo = await _uw.GetRepository<EMPEmployee>().GetAllAsync().Result.MaxAsync(x => x.EmpoloyeeNo) + 1;
        model.EmpoloyeeNo = model.EmpoloyeeNo == 0 || model.EmpoloyeeNo == 1 ? 10001 : model.EmpoloyeeNo;
        model.Status = (short)BaseStatus.Deactive;
        model.CreateDateTime = DateTime.Now;

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.PassWord = _security.HashPassword(model.NationalCode);
        user.Status = (short)BaseStatus.Deactive;
        user.CreateDateTime = DateTime.Now;

        await _uw.GetRepository<EMPEmployee>().AddAsync(model);
        await _uw.GetRepository<AdminUser>().AddAsync(user);

        _uw.SaveChanges();

        return model;
    }


    public async Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model)
    {
 
        AdminUser user = await _uw.GetRepository<AdminUser>().GetAllAsync().Result.Include(x => x.EMPEmployee).Where(x => x.EMPEmployee.Id == model.Id).FirstOrDefaultAsync();
 
        model.Status = (short)BaseStatus.Deactive;
        model.CreateDateTime = DateTime.Now;

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        model.Status = (short)BaseStatus.Deactive;
        user.CreateDateTime = DateTime.Now;

        _uw.GetRepository<EMPEmployee>().Update(model);
        _uw.GetRepository<AdminUser>().Update(user);

        _uw.SaveChanges();

        return model;
    }

    public async Task<EMPEmployee> DeleteEmployeeAsync(EMPEmployee model)
    {
        AdminUser user = await _uw.GetRepository<AdminUser>().GetAllAsync().Result.Include(x => x.EMPEmployee).Where(x => x.EMPEmployee.Id == model.Id).FirstOrDefaultAsync();
                                          
         _uw.GetRepository<EMPEmployee>().Delete(model);
         _uw.GetRepository<AdminUser>().Delete(user);

        _uw.SaveChanges();

        return model;
    }

}
