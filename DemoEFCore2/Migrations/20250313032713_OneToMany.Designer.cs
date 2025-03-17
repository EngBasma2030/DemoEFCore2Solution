﻿// <auto-generated />
using System;
using DemoEFCore2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoEFCore2.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20250313032713_OneToMany")]
    partial class OneToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoEFCore2.Entites.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 10L, 10);

                    b.Property<DateOnly>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GetDate()")
                        .HasAnnotation("DataType", "DateTime");

                    b.Property<int>("DepatmentManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasDefaultValue("HR")
                        .HasColumnName("DepartmentNAme")
                        .HasAnnotation("MaxLenght", 20);

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepatmentManagerId")
                        .IsUnique();

                    b.ToTable("Departments", "dbo");
                });

            modelBuilder.Entity("DemoEFCore2.Entites.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("EmpEmail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("EmpId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees", "dbo");
                });

            modelBuilder.Entity("DemoEFCore2.Entites.Department", b =>
                {
                    b.HasOne("DemoEFCore2.Entites.Employee", "Manager")
                        .WithOne("ManagedDeprtment")
                        .HasForeignKey("DemoEFCore2.Entites.Department", "DepatmentManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("DemoEFCore2.Entites.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DepartmentId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DepartmentId");

                            b1.ToTable("Departments", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("DepartmentId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("DemoEFCore2.Entites.Employee", b =>
                {
                    b.HasOne("DemoEFCore2.Entites.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.OwnsOne("DemoEFCore2.Entites.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeEmpId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeEmpId");

                            b1.ToTable("Employees", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeEmpId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DemoEFCore2.Entites.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DemoEFCore2.Entites.Employee", b =>
                {
                    b.Navigation("ManagedDeprtment");
                });
#pragma warning restore 612, 618
        }
    }
}
