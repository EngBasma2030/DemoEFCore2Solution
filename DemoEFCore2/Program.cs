using DemoEFCore2.Contexts;
using DemoEFCore2.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel.DataAnnotations;

namespace DemoEFCore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext(); // syntax suger

            // CRUD operations

            // deallocate || free || delete db connection

            //try
            //{
            //    // CRUD operations
            //}
            //finally
            //{
            //    // [close | free ] database connection
            //    dbContext.Dispose();
            //}


            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            //Employee emp01 = new Employee()
            //{
            //    Name = "Hamada",
            //    Age = 25,
            //    Salary = 5000,
            //    Email = "hamada@gmail.com"
            //};
            //Employee emp02 = new Employee()
            //{
            //    Name = "Omar",
            //    Age = 26,
            //    Salary = 5000,
            //    Email = "omar@gmail.com"
            //};

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

            //var employee = dbContext.Employees.SingleOrDefault(E => E.EmpId == 12);
            //var employee02 = dbContext.Employees.AsNoTracking().SingleOrDefault(E => E.EmpId == 4);

            #region Update
            ////if (employee != null)
            ////{
            ////    employee.Name = "Noha"; // Modified
            ////}

            ////if (employee02 != null)
            ////{
            ////    employee02.Name = "Mona"; // Modified
            ////}
            ////dbContext.SaveChanges();

            //////Console.WriteLine(employee?.Name ?? "NA");

            ////Console.WriteLine(dbContext.Entry(employee).State); 
            ////Console.WriteLine(dbContext.Entry(employee02).State); 
            #endregion

            #region Remove
            //if (employee != null)
            //{
            //    Console.WriteLine(dbContext.Entry(employee).State); // Unchanged

            //    dbContext.Employees.Remove(employee);
            //    dbContext.Set<Employee>().Remove(employee);
            //    dbContext.Remove(employee);
            //    dbContext.Entry(employee).State = EntityState.Deleted;

            //    Console.WriteLine("After delete");
            //    Console.WriteLine(dbContext.Entry(employee).State); // Deleted

            //    Console.WriteLine("After savechanges");
            //    dbContext.SaveChanges();
            //    Console.WriteLine(dbContext.Entry(employee).State); // Deleted
            //}
            #endregion

            #region Session 04

            #region 1. Explicit loading
            //var employee = (from E in dbContext.Employees
            //                where E.EmpId == 20
            //                select E).FirstOrDefault();

            //// Extra Trip
            //dbContext.Entry(employee).Reference(E => E.Department).Load();

            //Console.WriteLine($"EmpName : {employee?.Name} , DeptName : {employee?.Department.Name}");

            //var department = (from D in dbContext.Departments
            //                  where D.DepartmentId == 11
            //                  select D).FirstOrDefault();

            //// Extra Trip
            //dbContext.Entry(department).Collection(D => D.Employees).Load();
            //Console.WriteLine($"DeptName : {department?.Name}");

            //foreach (var emp in department?.Employees)
            //{
            //    Console.WriteLine($"EmpName : {emp.Name}");
            //}
            #endregion

            #region 2. Eager loadind
            //var employee = (from E in dbContext.Employees.Include(E => E.Department)                            
            //                where E.EmpId == 20
            //                select E).FirstOrDefault();


            //Console.WriteLine($"EmpName : {employee?.Name} , DeptName : {employee?.Department?.Name}");

            //var department = (from D in dbContext.Departments.Include(D => D.Employees)
            //                  where D.DepartmentId == 11
            //                  select D).FirstOrDefault();

            //Console.WriteLine($"DeptName : {department?.Name}");

            //foreach (var emp in department?.Employees)
            //{
            //    Console.WriteLine($"EmpName : {emp.Name}");
            //}
            #endregion

            #region 3. Lazy loading
            //var employee = (from E in dbContext.Employees
            //                where E.EmpId == 20
            //                select E).FirstOrDefault();


            //Console.WriteLine($"EmpName : {employee?.Name} , DeptName : {employee?.Department?.Name}");

            //var department = (from D in dbContext.Departments.Include(D => D.Employees)
            //                  where D.DepartmentId == 11
            //                  select D).FirstOrDefault();

            //Console.WriteLine($"DeptName : {department?.Name}");

            //foreach (var emp in department?.Employees)
            //{
            //    Console.WriteLine($"EmpName : {emp.Name}");
            //}
            #endregion

            #region Tracking
            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //var employee = (from E in dbContext.Employees
            //                where E.EmpId == 20
            //                select E).AsNoTracking().FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(employee).State); // Unchanged

            //employee.Name = "Noha";
            //Console.WriteLine(dbContext.Entry(employee).State); // Modified

            //dbContext.SaveChanges();
            #endregion

            #region Mapping view
            //var result = dbContext.EmployeeDepartments.FromSqlRaw("select * From EmployeeDepartmentView");

            //foreach (var item in dbContext.EmployeeDepartments)
            //{
            //    Console.WriteLine($"Employee : {item.EmpName} , Department : {item.DeptName}");
            //}
            #endregion

            #endregion

            #region Session 05

            #region Join [Inner Join]
            // 1. Query Syntax
            //var result = from E in dbContext.Employees
            //             join D in dbContext.Departments
            //             on E.DepartmentId equals D.DepartmentId
            //             where E.Salary >= 5000
            //             select new
            //             {
            //                 Employee = E.Name,
            //                 DeptName = D.Name
            //             };

            // 2. fluent syntax
            //var result = dbContext.Employees.Join(dbContext.Departments, E => E.DepartmentId, D => D.DepartmentId,
            //                                     (E, D) => new
            //                                     {
            //                                         EmpName = E.Name,
            //                                         DeptName = D.Name,
            //                                         Salary = E.Salary,
            //                                     }).Where(A => A.Salary >= 5000);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Group Join [Left Outer Join]

            #region example 01
            //var result = dbContext.Departments.GroupJoin(dbContext.Employees, D => D.DepartmentId, E => E.DepartmentId, (D, E) => new
            //{
            //    Department = D,
            //    Employee = E
            //});

            //var result = from D in dbContext.Departments
            //             join E in dbContext.Employees
            //             on D.DepartmentId equals E.DepartmentId into Groups
            //             select new
            //             {
            //                 Department = D,
            //                 Employee = Groups
            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department = {item.Department.Name}");
            //    Console.WriteLine("******************************");
            //    foreach (var item1 in item.Employee)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }
            //}
            #endregion

            #region example 02
            //var result = dbContext.Departments.GroupJoin(dbContext.Employees, D => D.DepartmentId, E => E.DepartmentId,
            //    (Department, Employee) => new
            //    {
            //        Department = Department,
            //        Employees = Employee
            //    }).Where(A => A.Employees.Count() > 1);

            //var result = from D in dbContext.Departments
            //             join E in dbContext.Employees
            //             on D.DepartmentId equals E.DepartmentId into Groups
            //             select new
            //             {
            //                 Department = D,
            //                 Employees = Groups
            //             } into Groups
            //             where Groups.Employees.Count() > 1
            //             select Groups;


            //foreach (var Item in result)
            //{
            //    Console.WriteLine(Item.Department.Name);
            //    Console.WriteLine("##########################");
            //    foreach (var EmpItem in Item.Employees)
            //    {
            //        Console.WriteLine(EmpItem.Name);
            //    }
            //}
            #endregion

            #region Left Join Not Working 
            //var result = dbContext.Departments.LeftJoin(dbContext.Employees, D => D.DepartmentId, E => E.DepartmentId,
            //    (D, E) => new
            //    {
            //        Department = D,
            //        Emp = E
            //    });

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Group Join [Right outer join ]
            //var result = dbContext.Employees.GroupJoin(dbContext.Departments, E => E.DepartmentId, D => D.DepartmentId,
            //    (E, D) => new
            //    {
            //        Employee = E,
            //        Department = D

            //    });

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Employee.Name);
            //    foreach (var item1 in item.Department)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }
            //}
            #endregion


            #endregion

            #region Creoss Join
            //var result = from E in dbContext.Employees
            //             from D in dbContext.Departments
            //             select new
            //             {
            //                 E.Name,
            //                 DeptName = D.Name
            //             };

            //var result = dbContext.Employees.SelectMany(E => dbContext.Departments.Select(D => new
            //{
            //    E.Name,
            //    DeptName = D.Name
            //}));

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion



            var emp01 = dbContext.Employees.FirstOrDefault();
            if(emp01 != null)
            {
                // Console.WriteLine(emp01.Age); // 22
                emp01.Age = null;
            }

            //var result = dbContext.Employees.Local.Any(E => E.Age == null);
            //Console.WriteLine($"result local => {result}");

            //result = dbContext.Employees.Any(E => E.Age == null);
            //Console.WriteLine($"result Remote => {result}");

            var result = dbContext.Employees.Find(1);
            result = dbContext.Find<Employee>(1);

            dbContext.Employees.Load();

            Console.WriteLine(result.Name);
            #endregion
        }
    }
}
