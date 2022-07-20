 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class CARTable : BaseEntity<int>
{
    [Required]
    [StringLength(20)]
    public string? TableName { get; set; }
                                                        
    public virtual ICollection<CARCartableTrace>? CARCartableTrace { get; set; }
}
