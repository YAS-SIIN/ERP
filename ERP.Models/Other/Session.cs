
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Other
{
    public class Session : BaseEntity<int>
    {
        public int AccountId
        {
            get;
            set;
        }

        [StringLength(500)]
        public string Token
        {
            get;
            set;
        }

        [StringLength(500)]
        public string SessionId
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public bool IsValid
        {
            get;
            set;
        }
    }
}
