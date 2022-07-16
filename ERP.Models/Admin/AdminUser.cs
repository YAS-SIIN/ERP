using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ERP.Models.Employees;

namespace ERP.Models.Admin;

public class AdminUser : BaseEntity<int>
{
    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string? LastName { get; set; }
               
    [Required]
    [StringLength(11)]
    public string? MobileNo { get; set; }   

    [Required]
    [StringLength(100)]
    public string? UserName { get; set; }

    [Required]
    [StringLength(100)]
    public string? PassWord { get; set; }

    [Required]
    [StringLength(100)]
    public string? VerificationCode { get; set; }

    public virtual EMPEmployee? EMPEmployee { get; set; }

    public virtual ICollection<AdminUserRole>? AdminUserRole { get; set; }
}
