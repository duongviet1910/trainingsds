using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAppRGPC.Model
{
    public class Teacher
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Dob { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual string Dobs { get; set; }

        public override string ToString()
        {
            return $" {Dob.ToString("dd/MM/yyyy")}";
        }

    }

}
