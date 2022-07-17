using ERP.Models.Employees;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Admin;

public class AdminUserRole : BaseEntity<int>
{
    public int AdminRoleId { get; set; }     

    public virtual AdminRole? AdminRole { get; set; }

}
