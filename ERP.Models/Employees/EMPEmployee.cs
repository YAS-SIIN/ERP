 
using ERP.Models.Cartables;
 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Employees;

public class EMPEmployee : BaseEntity<int>
{

    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }
    
    [Required]            
    public int EmpoloyeeNo { get; set; }
             
    [Required]
    [StringLength(50)]
    public string FatherName { get; set; }

    [Required]
    [StringLength(10)]
    public string NationalCode { get; set; }

    [Required]
    [StringLength(10)]
    public string IdentifyNo { get; set; }
                              
    [Required]
    [StringLength(10)]
    public string DateOfBirth { get; set; }

    [Required]       
    public short Gender { get; set; }

    [Required]
    [StringLength(10)]
    public string HireDate { get; set; }

    [Required]
    [StringLength(10)]
    public string LeaveDate { get; set; }

    [Required]
    [StringLength(11)]
    public string MobileNo { get; set; }

    [Required]
    [StringLength(200)]
    public string ImaghePath { get; set; }
                                                             
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
    public virtual ICollection<InOutRequestLeave>? InOutRequestLeave { get; set; }
}
