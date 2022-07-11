using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Admin;

public class AdminRole : BaseEntity<int>
{
    [Required]
    [StringLength(100)]
    public string? RoleName { get; set; }
    public virtual ICollection<AdminUserRole>? AdminUserRole { get; set; }
}
