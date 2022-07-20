 
using System.ComponentModel.DataAnnotations;
 

namespace ERP.Models.Cartables;

public class InOutRequestLeave : BaseEntity<int>
{
    [Required]
    [StringLength(10)]
    public string RequestDate { get; set; }
                  
    [Required]
    public short RequestLeaveType { get; set; }

    [Required]         
    public short LeaveType { get; set; }

    [Required]
    [StringLength(10)]
    public string FromDate { get; set; } = "";

    [Required]
    [StringLength(10)]
    public string ToDate { get; set; } = "";

    [StringLength(10)]
    public TimeSpan FromTime { get; set; } = DateTime.Now.TimeOfDay;
              
    [StringLength(10)]
    public TimeSpan ToTime { get; set; } = DateTime.Now.TimeOfDay;

    [Required]
    public int LeaveDay { get; set; }
             
    [Required]
    public int LeaveTime { get; set; }

    [StringLength(250)]
    public string LeaveReason { get; set; }

}
