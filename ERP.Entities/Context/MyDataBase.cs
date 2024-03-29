﻿

using ERP.Models.Admin;
using ERP.Models.Cartables;
using ERP.Models.Employees;
using ERP.Models.InOut;
using ERP.Models.Other;
using ERP.Models.Services;
using ERP.Models.SP;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Entities.Context;

public class MyDataBase : DbContext
{

    public MyDataBase(DbContextOptions<MyDataBase> options) : base(options)
    {

    }

    #region Admin
    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<AdminRole> AdminRoles { get; set; }
    public DbSet<AdminForm> AdminForms { get; set; }  
    public DbSet<AdminSubSystem> AdminSubSystems { get; set; }
    public DbSet<AdminUserRole> AdminUserRoles { get; set; }       
   // public DbSet<TestTable> TestTables { get; set; }
    #endregion

    #region Cartable
    public DbSet<CARCartable> CARCartables { get; set; } 
    public DbSet<CARCartableTrace> CARCartableTraces { get; set; }
    public DbSet<CARTable> CARTables { get; set; }
    #endregion

    #region Employe  

    [UseSorting]
    public DbSet<EMPEmployee> EMPEmployees { get; set; }
    #endregion

    #region InOut
    public DbSet<InOutRequestLeave> InOutRequestLeaves { get; set; }
    #endregion

    #region Serv
    public DbSet<ServRequestService> ServRequestServices { get; set; }
    #endregion

    #region Other
    public DbSet<Session> Sessions { get; set; }
    #endregion

    #region SP

    public DbSet<SPIntResult> SPIntResults { get; set; }
    public DbSet<SPCARSignList> SPCartableLists { get; set; }
    #endregion

    //
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<EMPEmployee>().HasQueryFilter(a => a.Status != (short)BaseStatus.Deleted);
        modelBuilder.Entity<EMPEmployee>().HasIndex(b => b.EmpoloyeeNo).IsUnique();

        modelBuilder.Entity<EMPEmployee>().HasIndex(b => b.NationalCode).IsUnique();

        modelBuilder.Entity<AdminRole>().HasIndex(b => b.RoleName).IsUnique();
                                                              
        modelBuilder.Entity<Session>().HasOne(p => p.AdminUser).WithMany();     

        modelBuilder.Entity<SPIntResult>().ToTable(p=>p.ExcludeFromMigrations()).HasNoKey();    
        modelBuilder.Entity<SPCARSignList>().ToTable(p => p.ExcludeFromMigrations()).HasNoKey();

        //modelBuilder.Entity<TestTable>().Property(f => f.Id).ValueGeneratedOnAdd();

        //modelBuilder.Entity<Session>()
        //    .HasOne(e => e.AdminUser);
 
        base.OnModelCreating(modelBuilder);
    }

}