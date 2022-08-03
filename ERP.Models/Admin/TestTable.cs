 
using System.ComponentModel.DataAnnotations;
 
using ERP.Models.Employees;
 

namespace ERP.Models.Admin;

public class TestTable
{
  
    public double? Id { get; set; }


    [Required]
    [StringLength(100)]
    public string TestField { get; set; }
          
                    
                                                 
}
