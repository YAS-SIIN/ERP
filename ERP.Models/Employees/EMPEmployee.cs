
using ERP.Models.Cartables;
using ERP.Models.InOut;
using ERP.Models.Services;

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
    public int EmpoloyeeNo { get; set; } = 0;
             
    [Required]
    [MinLength(3)]
    [StringLength(50)]
    public string FatherName { get; set; }

    [Required]
    [MinLength(10)]
    [StringLength(10)]
    [RegularExpression(@"^[0-9]{10}$")]
    public string NationalCode { get; set; }

    [Required]
    [StringLength(10)]
    public string IdentifyNo { get; set; }
                              
    [Required]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [StringLength(10)]
    public string DateOfBirth { get; set; }

    [Required]       
    public short Gender { get; set; }

    [Required]
    [MinLength(10)]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [StringLength(10)]
    public string HireDate { get; set; }

    [Required(AllowEmptyStrings = true)]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [StringLength(10)]
    public string LeaveDate { get; set; } = "";

    [Required]
    [MinLength(11)]
    [StringLength(11)]       
    [RegularExpression(@"^[0-9]{3}[0-9]{3}[0-9]{4}$")]        
    public string MobileNo { get; set; }

    [StringLength(200)]
    public string ImaghePath { get; set; } = "";
                                                             
    public virtual ICollection<CARCartable>? CARCartable { get; set; }
    public virtual ICollection<InOutRequestLeave>? InOutRequestLeave { get; set; }
    public virtual ICollection<ServRequestService>? ServRequestService { get; set; }
}
