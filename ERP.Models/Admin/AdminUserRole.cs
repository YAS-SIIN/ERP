using ERP.Models.Employees;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Admin;

public class AdminUserRole
{
    public virtual AdminRole? Role { get; set; }
    public virtual EMPEmployee? Employee { get; set; }
}
