using DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using NorthwindContext dbContext = new NorthwindContext();

            #region Run Row SQL

            //1.Excute select statement : from SQL Row , from SQL Interpolated

            // fromSqlRow
            //int count = 3;
            //var categories = dbContext.Categories.FromSqlRaw("select * from categories");
            // categories = dbContext.Categories.FromSqlRaw("select top ({0}) * from categories", count);

            // fromSqlInterpolated
            //categories = dbContext.Categories.FromSqlInterpolated($"select * from categories");
            //categories = dbContext.Categories.FromSqlInterpolated($"select top ({count}) * from categories");

            // 2. Excute DML statement [Inset , UpDate , delete]
            // ExcuteSQLRow
            // var Result = dbContext.Database.ExecuteSqlRaw(" update Categories\r\n  set CategoryName = 'Hamada'\r\n  where CategoryID = 6");

            //var Result = dbContext.Database.ExecuteSqlInterpolated($" update Categories\r\n  set CategoryName = 'Hamada'\r\n  where CategoryID = 7");
            //Console.WriteLine(Result);

            //var Categories = context.Categories.ToList();

            //foreach (var item in categories)
            //{
            //    Console.WriteLine(item.CategoryName);
            //}
            #endregion

            #region stored procedures
            #endregion 

            // check locally first [local => cache app]
            if (dbContext.Products.Local.Any(p => p.UnitsInStock == 0))
            Console.WriteLine("There Is At least one product out Stock");

            else if (dbContext.Products.Any(p => p.UnitsInStock == 0))
                Console.WriteLine("There Is At least one product out Stock");

            // each Time will send request to [server] Database to check if at least one product out stock


        }
    }
}
