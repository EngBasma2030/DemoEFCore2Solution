using DemoEFCore2.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEFCore2.Configurations;
using System.Reflection;
//using Common;

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


           // modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Employee>()
                .HasOne(E => E.ManagedDeprtment)
                .WithOne(D => D.Manager)
                .HasForeignKey<Department>(D => D.DepatmentManagerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(true);

            //modelBuilder.Entity<Employee>()
            //.HasOne<Department>()
            //.WithOne()
            //.HasForeignKey<Department>(D => D.DepatmentManagerId)
            //.OnDelete(DeleteBehavior.SetNull)
            //.IsRequired(true);

            modelBuilder.Entity<Department>()
                .HasMany(D => D.Employees)
                .WithOne(E => E.Department);

            modelBuilder.Entity<Employee>()
                .HasOne(E => E.Department)
                .WithMany(D => D.Employees)
                .IsRequired(false)
                .HasForeignKey(E => E.DepartmentId);

            //modelBuilder.Entity<Student>()
            //    .HasMany(S => S.Courses)
            //    .WithMany(C => C.Students);

            //modelBuilder.Entity<Course>()
            //    .HasMany(C => C.Students)
            //    .WithMany(S => S.Courses);

            modelBuilder.Entity<Student>()
                .HasMany(S => S.StudentCourses)
                .WithOne(SC => SC.Student);

            modelBuilder.Entity<Course>()
                .HasMany(C => C.CourseStudents)
                .WithOne(SC => SC.Course);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department>? Departments { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
