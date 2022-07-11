using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Employees;

public class EMPEmployee
{

    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string? LastName { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? EmpoloyeeNo { get; set; }
             
    [Required]
    [StringLength(50)]
    public string? FatherName { get; set; }

    [Required]
    [StringLength(10)]
    public string? NationalCode { get; set; }

    [Required]
    [StringLength(10)]
    public string? IdentifyNo { get; set; }

}
