using System.ComponentModel.DataAnnotations;

namespace ERP.Common
{
    public class TypeEnum
    {
        public enum UserStatus
        {

            [Display(Name = "Deactive")]
            Submit = 0,

            [Display(Name = "Active")]
            InProgress = 2,

            [Display(Name = "Deleted")]
            Deleted = 3
        }
                      
    }
}
