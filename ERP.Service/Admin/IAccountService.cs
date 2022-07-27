using ERP.Dtos.Admin;
using ERP.Models.Admin;
using ERP.Models.Employees;

using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Admin;

public interface IAccountService
{
    Task<AdminUser> GetAccountByToken(string token);
    Task<EMPEmployee> GetEmployeeByAccount(AdminUser user);
    Task<EMPEmployee> GetEmployeeByToken(string token);
    Task<LoginModel> LoginAsync(UserLoginDto userLogin);
    Task LogoutAsync(string token);
    Task<bool> IsAuthenticated(string token);   
    Task<bool> IsAuthenticatedRole(string token, string role);                                                                      
    Task ResetPasswordVerificationCodeAsync(string mobileNumber);
    Task ResetPasswordAsync(string mobileNumber, string password, string verificationCode);
}
