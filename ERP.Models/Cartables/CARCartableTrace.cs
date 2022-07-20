 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARCartableTrace : BaseEntity<double>
{
 
    [Required]          
    public int? OrderNo { get; set; }
 
    [Required]
    [StringLength(10)]
    public string? SignTitle { get; set; }

    [Required]
    [StringLength(10)]
    public string? SignName { get; set; }
   
}
