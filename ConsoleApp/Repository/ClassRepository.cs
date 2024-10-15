using ConsoleAppQLSV.Model;
using ConsoleAppQLSV.Repository.IRepository;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Repository
{
    class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
            _session = session;
        }

        public List<Class> GetAllClass()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>()
                    .Fetch(s => s.Teacher)
                    .ToList();
            }
        }

        public Class GetClass(int id)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.Get<Class>(id);
                }
            }
        }
    }
}
