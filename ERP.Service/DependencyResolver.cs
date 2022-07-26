
using ERP.Entities.GenericRepository;
using ERP.Models.Admin;
using ERP.Models.Cartables;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Service.Admin;
using ERP.Service.Crud;
using ERP.Service.Employees;
using ERP.Service.InOut;

using Microsoft.Extensions.DependencyInjection;

namespace ERP.Service;

public class DependencyResolver
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<AdminUser>, GenericRepository<AdminUser>>();
        services.AddScoped<IGenericRepository<EMPEmployee>, GenericRepository<EMPEmployee>>();       
        services.AddScoped<ICrudService<EMPEmployee>, CrudService<EMPEmployee>>();     
        services.AddScoped<ICrudService<InOutRequestLeave>, CrudService<InOutRequestLeave>>();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IEmployeesService, EmployeesService>();
        services.AddScoped<IRequestLeaveService, RequestLeaveService>();
    }
}
