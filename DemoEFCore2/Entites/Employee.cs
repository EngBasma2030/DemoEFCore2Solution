using DemoEFCore2.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    // Poco Class
    // Plain old CLR object

    // EF Core Supports 4 Ways for Mapping COde (DbContext, Models) to Database(Tabels, views)
    // 1. By Conventions (Default Behaviour)
    // 2. Data Annotation (set of attributes used for data validation)
    // 3. Fluent APIS => dbcontext --> OnModelCreating()
    // 4. Configuration class per entity --> organized way 3rd way 
    #region By Convention
    //internal class Employee
    //{
    //    public int Id { get; set; } // public Numeric Named as "Id" || EmployeeId
    //    public string Name { get; set; } // string : ref type => Allow Null [optional]
    //                                     // -- nvarchar(max)
    //    public double Salary { get; set; } // double : value type => not Null [required]
    //                                       // -- float
    //    public int? Age { get; set; } // Nullable<int> :: allow Null [optional]
    //}
    #endregion

    [Table("Employees",Schema ="dbo")]
    internal class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // (1,1) 
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int EmpId { get; set; }
        [Required]
        // [AllowNull]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50,MinimumLength = 10)]
        public string Name { get; set; } // [required] Attribute => required in database
                                         // required Keyword => required at application
        [Column(TypeName = "money")]
        public double Salary { get; set; }
        [Range(21,60)]
        public int? Age { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Column("EmpEmail", TypeName = "varchar")]
        public string Email { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [NotMapped]

        public string PhoneNumber { get; set; }
        [PasswordPropertyText]
        [NotMapped]
        public string Password { get; set; }
        public Address Address { get; set; }

        // navigation property [one]
        // EF core : Employee may manage department or not [partial participation]
        [InverseProperty("Manager")]
        public Department? ManagedDeprtment { get; set; }

        public int? DepartmentId { get; set; }
        // navigation property [one]
        [InverseProperty("Employees")]
        //[ForeignKey("Hamadaaa")]
        public Department Department { get; set; }
    }
}
