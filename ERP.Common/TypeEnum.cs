using System.ComponentModel.DataAnnotations;

namespace ERP.Common;

public class TypeEnum
{
    public enum UserStatus
    {

        [Display(Name = "Deactive")]
        Deactive = 0,

        [Display(Name = "Active")]
        Active = 2,

        [Display(Name = "Deleted")]
        Deleted = 3
    }

    public enum SessionStatus
    {

        [Display(Name = "Logout")]
        Logout = 0,

        [Display(Name = "Login")]
        Login = 1,
  
    }


}
