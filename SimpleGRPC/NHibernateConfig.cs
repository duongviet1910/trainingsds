using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using SimpleGRPC.Model.Mapping;

namespace SimpleGRPC
{
    public static class NHibernateConfig
    {
        public static ISessionFactory BuildSessionFactory()
        {
            var cfg = new Configuration();
            string connectionString = "Data Source=DESKTOP-VQE3MQM;Initial Catalog=qlsv;Integrated Security = True";

            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(StudentMapping));
            mapper.AddMapping(typeof(TeacherMapping));
            mapper.AddMapping(typeof(ClassMapping));
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(domainMapping);

            return cfg.BuildSessionFactory();
        }
    }
}
