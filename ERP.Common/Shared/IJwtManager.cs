using System;

namespace ERP.Common.Shared;

public interface IJwtManager
{
    string GenerateToken(string sessionId, int accountId, string name, string family, DateTime expirationDate);
}
