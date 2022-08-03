using ERP.Models.Admin;
using ERP.Models.Employees;

using System.ComponentModel.DataAnnotations;


namespace ERP.Models.SP;

public class SPCARSignList
{                   
    public string FieldCode { get; set; }         
    public string RequestDate { get; set; }
    public int CARTableId { get; set; }    
    public string SignTitle { get; set; } 
    public string SignTitleFa { get; set; }
    public string TableName { get; set; }
    public string FormName { get; set; }
    public string FormNameFa { get; set; }    
    public short Status { get; set; }

}
