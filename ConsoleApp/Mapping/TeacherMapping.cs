using ConsoleAppQLSV.Model;
using FluentNHibernate.Conventions.Inspections;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Mapping
{
     class TeacherMapping : ClassMapping<Teacher>
    {
        public TeacherMapping()
        {
            Table("teacher");

            Id(x => x.Id, map => map.Column("teacher_id"));

            Property(x => x.Name, map => map.Column("teacher_fullname"));

            Property(x => x.Dob, map => map.Column("teacher_birthday"));
            /*
            Bag(x => x.Class, c =>
            {
                c.Key(k => k.Column("Teacher"));
                c.Cascade(Cascade.All | Cascade.DeleteOrphans);
                c.Inverse(true);
            }, r => r.OneToMany());*/
        }
    }
}
