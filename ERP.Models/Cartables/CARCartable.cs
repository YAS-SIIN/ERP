using ERP.Models.Employees;
 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARCartable : BaseEntity<double>
{
    [Required]
    [StringLength(20)]
    public string FieldCode { get; set; }

    [Required]          
    public int OrderNo { get; set; } = 0;

    [Required]
    public bool DeleteFlag { get; set; }

    [Required]
    public short ConfirmType { get; set; } = 0;

    [Required]
    [StringLength(10)]
    public string SignDate { get; set; } = "";

}
