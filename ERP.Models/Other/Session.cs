
using ERP.Models.Admin;
       
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Other
{
    public class Session : BaseEntity<int>
    {                                          
        [StringLength(500)]
        public string Token { get; set; }     

        [StringLength(500)]
        public string SessionUser { get; set; }

        public DateTime ExpirationDate { get; set; }         

        public virtual AdminUser? AdminUser { get; set; }
    }
}

