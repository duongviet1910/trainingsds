using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppQLSV.Model;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ConsoleAppQLSV.Mapping
{
     class StudentMapping : ClassMapping<Student>
    {
        public StudentMapping()
        {
            Table("student");
            Id(x => x.Id, map => {
                map.Column("student_id");
                map.Generator(Generators.Native);
            });
            Property(x => x.Name, map => map.Column("student_fullname"));
            Property(x => x.Dob, map => map.Column("student_birthday"));
            Property(x => x.Address, map => map.Column("student_address"));
            ManyToOne(x => x.ClassStudent, map => map.Column("student_class_id"));

        }
    }
}
