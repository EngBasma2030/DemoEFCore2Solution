//using Common;
using DemoEFCore2.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.ToTable("Departments", "dbo");

            D.HasKey(D => D.DepartmentId);

            D.Property(D => D.DepartmentId)
             .UseIdentityColumn(10, 10);

            //D.Property(D => D.DeptId)
            // .ValueGeneratedNever(); // disable identity constrains

            //D.Property(D => D.DeptId)
            // .HasDefaultValueSql(" NewGuid()");

            //D.Property(D => D.DeptId)
            // .HasDefaultValue("10");

            D.Property(D => D.Name)
             .HasColumnName("DepartmentNAme")
             .HasColumnType("varchar")
             .HasMaxLength(20)
             .IsRequired(false)
             .HasDefaultValue("HR")
             .HasAnnotation("MaxLenght", 20);

            D.Property(D => D.CreationDate)
             .HasAnnotation("DataType", "DateTime")
             // .HasDefaultValue(DateTime.Now) // Default value = new DateTime (2025,3,4)
             .HasDefaultValueSql("GetDate()"); // After insert [stay the same] -- can be manually set
                                               // .HasComputedColumnSql("GetDate()"); // Automatically recalculation -- can not be manually set

            D.OwnsOne(D => D.Address, Address => Address.WithOwner());

        }
    }
}
