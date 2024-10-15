using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNHibernate.Model.Mapping
{
     class StudentMapping : ClassMapping<Student>
    {
        public StudentMapping() {
            Table("Student");
            Id(x => x.Id, map => map.Column("Id"));

            Property(x => x.Name);

            Property(x => x.Address);

            Property(x => x.Dob);

            ManyToOne(x => x.ClassStudent, m => m.Column("class"));
        }
    }
}
