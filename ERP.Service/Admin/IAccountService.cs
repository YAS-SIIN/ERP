using ERP.Dtos.Admin;
using ERP.Models.Admin;
using ERP.Models.Employees;

using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Admin;

public interface IAccountService
{
    Task<dynamic> GetUsersForModalAsync();
    Task<AdminUser> GetAccountByTokenAsync(string token);
    Task<EMPEmployee> GetEmployeeByUserIdAsync(int? userId);
    Task<EMPEmployee> GetEmployeeByTokenAsync(string token);
    Task<LoginModel> LoginAsync(UserLoginDto userLogin);
    Task LogoutAsync(string token);
    Task<bool> IsAuthenticatedAsync(string token);   
    Task<bool> IsAuthenticatedRoleAsync(string token, string role);                                                                      
    Task ResetPasswordVerificationCodeAsync(string mobileNumber);
    Task<ResetPasswordDto> ResetPasswordAsync(ResetPasswordDto model, int? userId);
}
