using ConsoleAppQLSV.Mapping;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Configuration = NHibernate.Cfg.Configuration;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace ConsoleAppQLSV
{
    static class NHibernateconfig
    {
        public static IServiceCollection BuildSessionFactory(this IServiceCollection services)
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

            var sessionFactory = cfg.BuildSessionFactory();
            services.AddSingleton<ISessionFactory>(sessionFactory);
            services.AddScoped<ISession>(provider => provider.GetRequiredService<ISessionFactory>().OpenSession());

            return services;
        }
    }
}
