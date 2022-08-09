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

public class ResetPasswordDto
{
    [Required]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Compare("Password")]
    [Required]
    [DataType(DataType.Password)]
    public string RePassword { get; set; }                  
}