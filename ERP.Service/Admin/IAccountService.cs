using ERP.Dtos.Admin;
using ERP.Models.Admin;

using System.Threading;
using System.Threading.Tasks;

namespace ERP.Service.Admin;

public interface IAccountService
{
    Task<AdminUser> GetAccountByToken(string token);
    Task<LoginModel> LoginAsync(UserLoginDto userLogin);
    Task LogoutAsync(string token);
    Task<bool> IsAuthenticated(string token);                                                                       
    Task ResetPasswordVerificationCodeAsync(string mobileNumber);
    Task ResetPasswordAsync(string mobileNumber, string password, string verificationCode);
}
