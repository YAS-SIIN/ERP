﻿// <auto-generated />
using System;
using ERP.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.Entities.Migrations
{
    [DbContext(typeof(MyDataBase))]
    [Migration("20220720144001_ChangeInTables")]
    partial class ChangeInTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ERP.Models.Admin.AdminForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminSubSystemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminSubSystemId");

                    b.ToTable("AdminForms");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminRoles");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminSubSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("SubSystemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminSubSystems");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("EMPEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EMPEmployeeId");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("AdminUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminRoleId");

                    b.HasIndex("AdminUserId");

                    b.ToTable("AdminUserRoles");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARCartable", b =>
                {
                    b.Property<double>("Id")
                        .HasColumnType("float");

                    b.Property<int?>("AdminRoleId")
                        .HasColumnType("int");

                    b.Property<short>("ConfirmType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("EMPEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FieldCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("SignDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminRoleId");

                    b.HasIndex("EMPEmployeeId");

                    b.ToTable("CARCartables");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARCartableTrace", b =>
                {
                    b.Property<double>("Id")
                        .HasColumnType("float");

                    b.Property<int?>("CARTableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("SignName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SignTitle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CARTableId");

                    b.ToTable("CARCartableTrace");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminFormId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminFormId");

                    b.ToTable("CARTable");
                });

            modelBuilder.Entity("ERP.Models.Cartables.InOutRequestLeave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("EMPEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FromDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<TimeSpan>("FromTime")
                        .HasMaxLength(10)
                        .HasColumnType("time");

                    b.Property<int>("LeaveDay")
                        .HasColumnType("int");

                    b.Property<string>("LeaveReason")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("LeaveTime")
                        .HasColumnType("int");

                    b.Property<short>("LeaveType")
                        .HasColumnType("smallint");

                    b.Property<string>("RequestDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<short>("RequestLeaveType")
                        .HasColumnType("smallint");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("ToDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<TimeSpan>("ToTime")
                        .HasMaxLength(10)
                        .HasColumnType("time");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EMPEmployeeId");

                    b.ToTable("InOutRequestLeaves");
                });

            modelBuilder.Entity("ERP.Models.Employees.EMPEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("EmpoloyeeNo")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("HireDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IdentifyNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ImaghePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LeaveDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpoloyeeNo")
                        .IsUnique();

                    b.HasIndex("IdentifyNo")
                        .IsUnique();

                    b.ToTable("EMPEmployees");
                });

            modelBuilder.Entity("ERP.Models.Other.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("SessionUser")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminUserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminForm", b =>
                {
                    b.HasOne("ERP.Models.Admin.AdminSubSystem", null)
                        .WithMany("AdminForm")
                        .HasForeignKey("AdminSubSystemId");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminUser", b =>
                {
                    b.HasOne("ERP.Models.Employees.EMPEmployee", "EMPEmployee")
                        .WithMany()
                        .HasForeignKey("EMPEmployeeId");

                    b.Navigation("EMPEmployee");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminUserRole", b =>
                {
                    b.HasOne("ERP.Models.Admin.AdminRole", null)
                        .WithMany("AdminUserRole")
                        .HasForeignKey("AdminRoleId");

                    b.HasOne("ERP.Models.Admin.AdminUser", null)
                        .WithMany("AdminUserRole")
                        .HasForeignKey("AdminUserId");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARCartable", b =>
                {
                    b.HasOne("ERP.Models.Admin.AdminRole", null)
                        .WithMany("CARCartable")
                        .HasForeignKey("AdminRoleId");

                    b.HasOne("ERP.Models.Employees.EMPEmployee", null)
                        .WithMany("CARCartable")
                        .HasForeignKey("EMPEmployeeId");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARCartableTrace", b =>
                {
                    b.HasOne("ERP.Models.Cartables.CARTable", null)
                        .WithMany("CARCartableTrace")
                        .HasForeignKey("CARTableId");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARTable", b =>
                {
                    b.HasOne("ERP.Models.Admin.AdminForm", null)
                        .WithMany("CARTable")
                        .HasForeignKey("AdminFormId");
                });

            modelBuilder.Entity("ERP.Models.Cartables.InOutRequestLeave", b =>
                {
                    b.HasOne("ERP.Models.Employees.EMPEmployee", null)
                        .WithMany("InOutRequestLeave")
                        .HasForeignKey("EMPEmployeeId");
                });

            modelBuilder.Entity("ERP.Models.Other.Session", b =>
                {
                    b.HasOne("ERP.Models.Admin.AdminUser", "AdminUser")
                        .WithMany()
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminUser");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminForm", b =>
                {
                    b.Navigation("CARTable");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminRole", b =>
                {
                    b.Navigation("AdminUserRole");

                    b.Navigation("CARCartable");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminSubSystem", b =>
                {
                    b.Navigation("AdminForm");
                });

            modelBuilder.Entity("ERP.Models.Admin.AdminUser", b =>
                {
                    b.Navigation("AdminUserRole");
                });

            modelBuilder.Entity("ERP.Models.Cartables.CARTable", b =>
                {
                    b.Navigation("CARCartableTrace");
                });

            modelBuilder.Entity("ERP.Models.Employees.EMPEmployee", b =>
                {
                    b.Navigation("CARCartable");

                    b.Navigation("InOutRequestLeave");
                });
#pragma warning restore 612, 618
        }
    }
}
