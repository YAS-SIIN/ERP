
using System.ComponentModel.DataAnnotations;

namespace ERP.Common.Enums;

public class TypeEnum
{
 
    public enum SessionStatus
    {

        [Display(Name = "Logout")]
        Logout = 0,

        [Display(Name = "Login")]
        Login = 1,

    }

    public enum BaseStatus
    {

        [Display(Name = "Deactive")]
        Deactive = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Deleted")]
        Deleted = 3
    }

}
