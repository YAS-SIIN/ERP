using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dtos.Admin;

public class UserLoginDto
{
    [Required]          
    public string? UserName { get; set; }

    [Required]          
    public string? PassWord { get; set; }
}

 
public class LoginModel  
{
    public string Token { get; set; } 
    public bool IsSuccessful { get; set; }   
    public DateTime ExpirationDate { get; set; }
 
}

public class ResetPasswordVerificationCodeInputModel
{
    public string MobileNumber { get; set; }   
}

public class ResetPasswordInputModel
{
    public string MobileNumber { get; set; }      
    public string Password { get; set; }         
    public string VerificationCode { get; set; }            
}