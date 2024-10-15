using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Model.Mapping
{
    class ClassMapping : ClassMapping<Class>
    {
        public ClassMapping() {
            Table("Class");

            //Id(x => x.Id, map => map.Column("class_id"));

            Id(x => x.Id, map => {
                map.Column("class_id");
                map.Generator(NHibernate.Mapping.ByCode.Generators.Identity); // Sử dụng Identity để auto-increment
            });

            Property(x => x.Name, map => map.Column("class_name"));

            Property(x => x.SubjectName, map => map.Column("class_subject"));
            Property(x => x.TeacherId,map => map.Column("teacher_id"));
            //Property(x => x.IsDeleted);
            //ManyToOne(x => x.Teacher, m => m.Column("teacher_id"));
        }
    }
}
