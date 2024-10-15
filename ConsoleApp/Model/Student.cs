using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Model
{
     class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Dob { get; set; }
        public virtual String Address { get; set; }
        public virtual Class ClassStudent { get; set; }
        public override string? ToString()
        {
            return $"MSV: {Id}, Ten: {Name}, Ngay sinh: {Dob.ToShortDateString()}, Đia chi: {Address}, Lop: {ClassStudent}";
        }
    }
}
