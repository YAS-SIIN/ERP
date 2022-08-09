
using ERP.Models.Admin;

using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARTable : BaseEntity<int>
{
    [Required]
    [StringLength(50)]
    public string TableName { get; set; }
                                                        
    public virtual ICollection<CARCartableTrace>? CARCartableTrace { get; set; }
    public virtual AdminForm? AdminForm { get; set; }
}
