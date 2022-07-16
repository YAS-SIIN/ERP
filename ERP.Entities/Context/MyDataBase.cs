

using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.Other;

using Microsoft.EntityFrameworkCore;

namespace ERP.Entities.Context;

public class MyDataBase : DbContext
{

    public MyDataBase(DbContextOptions<MyDataBase> options) : base(options)
    {

    }
    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<AdminRole> AdminRoles { get; set; }
    public DbSet<AdminForm> AdminForms { get; set; }
    public DbSet<AdminUserRole> AdminUserRoles { get; set; }
    public DbSet<EMPEmployee> EMPEmployees { get; set; }
    public DbSet<Session> Sessions { get; set; }
    //
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<EMPEmployee>().HasIndex(b => b.EmpoloyeeNo).IsUnique();

        modelBuilder.Entity<EMPEmployee>().HasIndex(b => b.IdentifyNo).IsUnique();

        base.OnModelCreating(modelBuilder);
    }

}