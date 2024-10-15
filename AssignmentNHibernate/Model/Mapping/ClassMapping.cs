using AssignmentNHibernate.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNHibernate.Model.Mapping
{
    class ClassMapping : ClassMapping<Class>
    {
        public ClassMapping() {
            Table("Class");

            Id(x => x.Id, map => map.Column("Id"));

            Property(x => x.Name);

            Property(x => x.SubjectName);
            ManyToOne(x => x.Teacher, m => m.Column("teacher"));
            Bag(x => x.Students, c =>
            {
                c.Key(k => k.Column("Class"));
                c.Cascade(Cascade.All
                          | Cascade.DeleteOrphans);
            }, r => r.OneToMany());
        }
    }
}
