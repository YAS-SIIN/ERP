
using ERP.Entities.GenericRepository;
using ERP.Models.Admin;
using ERP.Service.Admin;
using ERP.Service.Crud;

using Microsoft.Extensions.DependencyInjection;

namespace ERP.Service;

public class DependencyResolver
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<AdminUser>, GenericRepository<AdminUser>>();
        services.AddScoped<ICrudService<AdminUser>, CrudService<AdminUser>>();
        services.AddScoped<IAccountService, AccountService>();
    }
}
