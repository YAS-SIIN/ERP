using ERP.Models.Cartables;
                  
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Admin;

public class AdminRole : BaseEntity<int>
{                                   

    [Required]
    [StringLength(100)]
    public string RoleName { get; set; }

    [Required]
    [StringLength(100)]
    public string RoleNameFa { get; set; }

    public virtual ICollection<AdminUserRole>? AdminUserRole { get; set; }
    public virtual ICollection<CARCartableTrace>? CARCartableTrace { get; set; }     

}
