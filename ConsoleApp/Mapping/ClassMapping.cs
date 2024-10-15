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
    class ClassMapping : ClassMapping<Class>
    {
        public ClassMapping()
        {
            Table("class");
            Id(x => x.Id, map => map.Column("class_id"));
            Property(x => x.Name, map => map.Column("class_name"));
            Property(x => x.SubjectName, map =>map.Column("class_subject"));
            ManyToOne(x => x.Teacher, map => map.Column("teacher_id"));
            
        }
    }
}
