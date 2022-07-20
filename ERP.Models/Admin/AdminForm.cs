using ERP.Models.Cartables;
 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Admin;

public class AdminForm: BaseEntity<int>
{
    [Required]
    [StringLength(100)]
    public string FormName { get; set; }

    public virtual ICollection<CARTable> CARTable { get; set; }
}
