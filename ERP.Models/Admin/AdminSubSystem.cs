 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Admin;

public class AdminSubSystem : BaseEntity<int>
{
    [Required]
    [StringLength(100)]
    public string SubSystemName { get; set; }

    public virtual ICollection<AdminForm>? AdminForm { get; set; }
}
