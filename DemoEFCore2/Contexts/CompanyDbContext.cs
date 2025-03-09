using DemoEFCore2.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEFCore2.Configurations;
using System.Reflection;
using Common;

namespace DemoEFCore2.Contexts
{
    internal class CompanyDbContext : DbContext
    {
        public CompanyDbContext () : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-RKP4IOQ ; Database = Company ; Trusted_Connection = True ; Encrypt = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // employee has property (name) is required
            // empId is PK
            // Fluent APIs


            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

           // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department>? Departments { get; set; }



    }
}
