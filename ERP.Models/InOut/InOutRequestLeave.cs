
using ERP.Models.Employees;

using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.InOut;

public class InOutRequestLeave : BaseEntity<int>
{
    [Required]
    [StringLength(10)]
    public string RequestDate { get; set; } = "";
                  
    [Required]
    public short RequestLeaveType { get; set; }

    [Required]         
    public short LeaveType { get; set; }

    [Required]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [MinLength(10)]
    [StringLength(10)]
    public string FromDate { get; set; } = "";

    [Required]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [MinLength(10)]
    [StringLength(10)]
    public string ToDate { get; set; } = "";

    [Required]
    [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$")]
    [MinLength(10)]
    [StringLength(10)]
    public string TimeLeaveDate { get; set; } = "";

    [Required]
    [StringLength(8)]
    public string FromTime { get; set; } = "";

    [Required]
    [StringLength(8)]
    public string ToTime { get; set; } = "";

    [Required]
    public int LeaveDay { get; set; }
             
    [Required]
    public int LeaveTime { get; set; }

    [StringLength(250)]
    public string LeaveReason { get; set; }

    public virtual EMPEmployee? EMPEmployee { get; set; }
}
