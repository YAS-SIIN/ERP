﻿using ERP.Models.Cartables;
                  
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Admin;

public class AdminRole : BaseEntity<int>
{                                   

    [Required]
    [StringLength(100)]
    public string RoleName { get; set; }
    public virtual ICollection<AdminUserRole>? AdminUserRole { get; set; }
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
}
