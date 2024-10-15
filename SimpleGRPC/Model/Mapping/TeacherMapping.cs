using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model.Mapping
{
    class TeacherMapping : ClassMapping<Teacher>
    {
        public TeacherMapping()
        {
            Table("Teacher");

            //Id(x => x.Id, map => map.Column("teacher_id"));

            Id(x => x.Id, map => {
                map.Column("teacher_id");
                map.Generator(NHibernate.Mapping.ByCode.Generators.Identity); // Sử dụng Identity để auto-increment
            });

            Property(x => x.Name, map => map.Column("teacher_fullname"));

            Property(x => x.Dob, map => map.Column("teacher_birthday"));
        }
    }
}
