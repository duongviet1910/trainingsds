using NHibernate;
using SimpleGRPC.Model;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ISessionFactory _session;
        public TeacherRepository(ISessionFactory session)
        {
            _session = session;
        }
        public List<Teacher> GetAllTeachers()
        {
            using(var session = _session.OpenSession())
            {
                return session.Query<Teacher>().ToList();
            }
        }

        public Teacher GetTeacherById(int id)
        {
            using(var session = _session.OpenSession())
            {
                return session.Query<Teacher>().Where(x=>x.Id == id).First();
            }
        }
    }
}
