
using ERP.Models.Admin;  

using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARCartableTrace : BaseEntity<double>
{
 
 
    [Required]
    [StringLength(10)]
    public string SignTitle { get; set; }

    [Required]
    [StringLength(10)]
    public string SignName { get; set; }

    public virtual CARTable? CARTable { get; set; }
    public virtual AdminRole? AdminRole { get; set; }
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
}
