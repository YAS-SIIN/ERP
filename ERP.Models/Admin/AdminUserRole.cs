﻿ 
namespace ERP.Models.Admin;

public class AdminUserRole : BaseEntity<int>
{
    public virtual AdminRole? AdminRole { get; set; }   
    public virtual AdminUser? AdminUser { get; set; }
}
