
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Enums
{
    public static class ErrorList
    {

        [Display(Name = "اطلاعاتی یافت نشد.")]
        public const string NotFound = "100";

        [Display(Name = "عملیات با موفقیت انجام شد.")]
        public const string Done = "101";

        [Display(Name = "خطایی در انجتم عملیات رخ داده است.")]
        public const string Error = "102";
                
        [Display(Name = "فرمت فایل مجاز نمی باشد.")]
        public const string FileFormat = "103";

        [Display(Name = "فایل انتخاب نشده است.")]
        public const string NotFoundFile = "104";

        [Display(Name = "شما به این عملیات دسترسی ندارید.")]
        public const string NotAccess = "105";

        [Display(Name = "شما وارد سیستم شده اید.")]
        public const string LoginedUser = "106";

        [Display(Name = "اطلاعات مورد نظر قابل حذف نمی باشد.")]
        public const string NotDelete = "107";

    }
}
