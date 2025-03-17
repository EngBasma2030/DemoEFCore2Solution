using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    [PrimaryKey(nameof(StudentId) , nameof(CourseId))]

    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }
        public Student Student { get; set; }
        public  Course Course { get; set; }
    }
}
