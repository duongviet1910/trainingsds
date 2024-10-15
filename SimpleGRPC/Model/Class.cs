using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model
{
    public class Class
    {
        public virtual int Id { get; set; }
        //public virtual int IsDeleted { get; set; }
        public virtual string Name { get; set; }
        public virtual string SubjectName { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual string TeacherName { get; set; }

        public override string? ToString()
        {
            return $"{Id} - {Name} - {SubjectName}";
        }
    }
}
