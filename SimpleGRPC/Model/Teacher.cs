using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model
{
    public class Teacher
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Dob { get; set; }


    }

}
