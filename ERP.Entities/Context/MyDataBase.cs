

using Microsoft.EntityFrameworkCore;

namespace ERP.Entities.Context;

public class MyDataBase : DbContext   
{

    public MyDataBase(DbContextOptions<MyDataBase> options) : base(options)
    {
       
    }
    //public DbSet<User> Users { get; set; }
    //public DbSet<Activity> Activities { get; set; }
    //public DbSet<Schedule> Schedules { get; set; }
    //public DbSet<Request> Requests { get; set; }
    //public DbSet<Visit> Visits { get; set; }
    //
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<User>().ToTable("User");
    //    modelBuilder.Entity<Activity>().ToTable("Activity");
    //    modelBuilder.Entity<Schedule>().ToTable("Schedule");
    //    modelBuilder.Entity<Request>().ToTable("Request");
    //    modelBuilder.Entity<Visit>().ToTable("Visit");

    //    //modelBuilder.Seed();

    //}

}