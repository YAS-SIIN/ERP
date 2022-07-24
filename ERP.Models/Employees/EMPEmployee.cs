 
using ERP.Models.Cartables;
 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Employees;

public class EMPEmployee : BaseEntity<int>
{

    [Required]
    [MinLength(3)]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(3)]
    [StringLength(100)]
    public string LastName { get; set; }
    
    [Required]            
    public int EmpoloyeeNo { get; set; }
             
    [Required]      
    [MinLength(3)]
    [StringLength(50)]
    public string FatherName { get; set; }

    [Required]
    [MinLength(10)]
    [StringLength(10)]
    public string NationalCode { get; set; }

    [Required]
    [StringLength(10)]
    public string IdentifyNo { get; set; }
                              
    [Required]
    [MinLength(10)]
    [StringLength(10)]
    public string DateOfBirth { get; set; }

    [Required]       
    public short Gender { get; set; }

    [Required]
    [MinLength(10)]
    [StringLength(10)]
    public string HireDate { get; set; }

    [Required]
    [MinLength(10)]
    [StringLength(10)]
    public string LeaveDate { get; set; }

    [Required]
    [MinLength(11)]
    [StringLength(11)]
    public string MobileNo { get; set; }

    [Required]
    [StringLength(200)]
    public string ImaghePath { get; set; }
                                                             
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
    public virtual ICollection<InOutRequestLeave>? InOutRequestLeave { get; set; }
}
