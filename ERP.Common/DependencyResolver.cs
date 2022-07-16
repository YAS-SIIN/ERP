using ERP.Common;
using ERP.Framework.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace ERP.Common;

public class DependencyResolver
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<ISecurity, Security>();
        services.AddScoped<IJwtManager, JwtManager>();                           
    }
}
