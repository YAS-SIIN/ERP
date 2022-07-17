namespace ERP.Common.Shared;

public interface ISecurity
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}
