
using ERP.Entities.GenericRepository;
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Service.Admin;
using ERP.Service.Crud;

using Microsoft.Extensions.DependencyInjection;

namespace ERP.Service;

public class DependencyResolver
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<AdminUser>, GenericRepository<AdminUser>>();
        services.AddScoped<IGenericRepository<EMPEmployee>, GenericRepository<EMPEmployee>>();
        services.AddScoped<ICrudService<EMPEmployee>, CrudService<EMPEmployee>>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IEmployeesService, EmployeesService>();
    }
}
