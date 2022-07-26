
using ERP.Models.Employees;

using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Services;

public class ServRequestService : BaseEntity<int>
{
    [Required]
    [StringLength(10)]
    public string RequestDate { get; set; }
                  
    [Required]
    public short RequestServiceType { get; set; }

    [StringLength(250)]
    public string ServicesOrGoods { get; set; }

    public virtual EMPEmployee? EMPEmployee { get; set; }
}
