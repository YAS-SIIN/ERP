using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dtos.Admin;

public class UserRoleDto
{
    [Required]          
    public int? UserId { get; set; }

    [Required]          
    public int? RoleId { get; set; }

    [Required]
    public bool? HasRole { get; set; }

}

