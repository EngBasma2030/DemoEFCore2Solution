using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }

         //public int ManagerID { get; set; }
        // FK must named as [MangerId,ManagerEmpId,EmployeeId,EmployeeEmpId]
        // if you didn't repersent the FK in the model => EF core will create it automatically [ManagerEmpId]
        // In one to one relationship FK is required if you defined both navigation properties
        // [ForeignKey(nameof(Manager))]
        public int DepatmentManagerId {get; set;}

        // navigation property [one]
        // EF core : Department must has one employee [manager] => [total Perticaption]
        [InverseProperty("ManagedDeprtment")]
         public Employee Manager { get; set; }

        public Address Address { get; set; }
        // navigation property [many]
        // [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //public Department()
        //{
        //    Employees = new HashSet<Employee>();
        //}

    }
}
