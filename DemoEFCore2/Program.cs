using DemoEFCore2.Contexts;
using DemoEFCore2.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace DemoEFCore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext(); // syntax suger

            // CRUD operations

            // deallocate || free || delte db connection

            //try
            //{
            //    // CRUD operations
            //}
            //finally
            //{
            //    // [close | free ] database connection
            //    dbContext.Dispose();
            //}


            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            Employee emp01 = new Employee()
            {
                Name = "Hamada", 
                Age = 25,
                Salary = 5000,
                Email = "hamada@gmail.com"
            };
            Employee emp02 = new Employee()
            {
                Name = "Omar",
                Age = 26,
                Salary = 5000,
                Email = "omar@gmail.com"
            };

            #region Insert
            //Console.WriteLine(dbContext.Entry(emp01).State); // Detached

            //dbContext.Employees.Add(emp01); // Added
            //dbContext.Set<Employee>().Add(emp01);
            //dbContext.Add(emp01); // 3.1 Feature
            //dbContext.Entry(emp01).State = EntityState.Added;

            //// change entry state to be Added

            //dbContext.Add(emp02); // Added
            //Console.WriteLine("After Adding");
            //Console.WriteLine(dbContext.Entry(emp01).State); // Added

            //dbContext.SaveChanges();
            //Console.WriteLine("After save Changes");
            //Console.WriteLine(dbContext.Entry(emp01).State); // Detached
            #endregion

            var employee = dbContext.Employees.SingleOrDefault(E => E.EmpId == 3);
            var employee02 = dbContext.Employees.AsNoTracking().SingleOrDefault(E => E.EmpId == 4);

            #region Update
            //if (employee != null)
            //{
            //    employee.Name = "Noha"; // Modified
            //}

            //if (employee02 != null)
            //{
            //    employee02.Name = "Mona"; // Modified
            //}
            //dbContext.SaveChanges();

            ////Console.WriteLine(employee?.Name ?? "NA");

            //Console.WriteLine(dbContext.Entry(employee).State); 
            //Console.WriteLine(dbContext.Entry(employee02).State); 
            #endregion

            if (employee != null)
            {
                Console.WriteLine(dbContext.Entry(employee).State); // Unchanged

                dbContext.Employees.Remove(employee);
                dbContext.Set<Employee>().Remove(employee);
                dbContext.Remove(employee);
                dbContext.Entry(employee).State = EntityState.Deleted;

                Console.WriteLine("After delete");
                Console.WriteLine(dbContext.Entry(employee).State); // Deleted

                Console.WriteLine("After savechanges");
                dbContext.SaveChanges();
                Console.WriteLine(dbContext.Entry(employee).State); // Deleted
            }
        }
    }
}
