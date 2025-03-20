using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public ICollection<Student> Students { get; set; }
        public virtual ICollection<StudentCourse> CourseStudents { get; set; }
    }
}
