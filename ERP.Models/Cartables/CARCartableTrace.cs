
using ERP.Models.Admin;  

using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARCartableTrace : BaseEntity<int>
{
       
    [Required]
    public int OrderNo { get; set; } = 0;

    [Required]
    [StringLength(100)]
    public string SignTitle { get; set; }

    [Required]
    [StringLength(100)]
    public string SignTitleFa { get; set; }

    public virtual CARTable? CARTable { get; set; }
    public virtual AdminRole? AdminRole { get; set; }
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
}
