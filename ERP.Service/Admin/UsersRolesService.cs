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
using ERP.Models.SP;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Admin;

public class UsersRolesService : IUsersRolesService
{                                             
    private readonly IUnitOfWork _uw;
 
    public UsersRolesService( IUnitOfWork uw)
    {                          
        _uw = uw;
    }
        
    public async Task<dynamic> GetRolesByUserAsync(int UserId)
    {                              
        return await _uw.GetRepository<AdminRole>().GetAll(x => x.Status == (short)BaseStatus.Active).Select(x => new { AdminRole = x, HasRole = _uw.GetRepository<AdminUserRole>().GetAll().Any(a => a.AdminRole.Id == x.Id && a.Status == (short)BaseStatus.Active && a.AdminUser.Id == UserId) }).ToListAsync();
    }

    public async Task<AdminUserRole> InsertUpdateUserRoleAsync(UserRoleDto model)
    {           
        AdminUserRole userRole = new AdminUserRole();
        if (model.HasRole == true)
        {
            userRole.AdminRole = _uw.GetRepository<AdminRole>().GetById(model.RoleId);
            userRole.AdminUser = _uw.GetRepository<AdminUser>().GetById(model.UserId);
            userRole.Status = (short)BaseStatus.Active;
            userRole.CreateDateTime = DateTime.Now;

            await _uw.GetRepository<AdminUserRole>().AddAsync(userRole);

        }  else
        {
            userRole = await _uw.GetRepository<AdminUserRole>().GetAll(x=>x.AdminRole.Id == model.RoleId && x.AdminUser.Id == model.UserId && x.Status == (short)BaseStatus.Active).FirstOrDefaultAsync();
            
            userRole.Status = (short)BaseStatus.Deleted;
            userRole.UpdateDateTime = DateTime.Now;

            _uw.GetRepository<AdminUserRole>().Update(userRole);
        }

        _uw.SaveChanges();
        return userRole;
    }


}
