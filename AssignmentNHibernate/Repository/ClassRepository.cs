using AssignmentNHibernate.Model;
using AssignmentNHibernate.Repository.IRepository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;


namespace AssignmentNHibernate.Repository
{
    class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
            _session = session;
        }
        public List<Class> GetAllClasses()
        {
            using (var session = _session.OpenSession())
            {
                List<Class> classes = session.Query<Class>().Fetch(s=>s.Teacher).ToList();
                return classes;
            }
        }
    }
}
