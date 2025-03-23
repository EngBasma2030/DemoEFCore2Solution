using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore2.Entites
{
    [PrimaryKey(nameof(StudentId) , nameof(CourseId))]

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual  Course Course { get; set; }
    }
}
