//using ConsoleAppQLSV.Service.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Model
{
     class Class
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SubjectName { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Student { get; set; } // tai danh sach svien khi can thiet 
        public override string? ToString()
        {
            return $"{Id} - {Name} - {SubjectName}";
        }
    }
}
