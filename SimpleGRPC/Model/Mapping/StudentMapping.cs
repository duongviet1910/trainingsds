using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model.Mapping
{
     class StudentMapping : ClassMapping<Student>
    {
        public StudentMapping() {
            Table("Student");
            Id(x => x.Id, map => {
                map.Column("student_id");
                map.Generator(NHibernate.Mapping.ByCode.Generators.Identity); // Sử dụng Identity để auto-increment
            });

            Property(x => x.Name, map => map.Column("student_fullname"));

            Property(x => x.Address, map => map.Column("student_address"));

            Property(x => x.Dob, map => map.Column("student_birthday"));

            Property(x => x.ClassId, m => m.Column("student_class_id"));
        }
    }
}
