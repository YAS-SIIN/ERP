using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ERP.Models.Employees;

namespace ERP.Models.Admin;

public class AdminUser
{
    [Required]
    [StringLength(100)]
    public string? UserName { get; set; }

    [Required]
    [StringLength(100)]
    public string? PassWord { get; set; }

    public virtual EMPEmployee? Employee { get; set; }

    public virtual ICollection<AdminUserRole>? UserRole { get; set; }
}
