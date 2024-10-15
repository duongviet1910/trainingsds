using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Repository.IRepository;
using NHibernate;
using NHibernate.Linq;
using Share;
using System.Data;

namespace BlazorWebAppRGPC.Repository
{
    public class ClassRepository : IClassRepository
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
                return session.Query<Class>()
                    .Fetch(x=>x.Teacher)
                    .ToList();
            }
        }

        public Class GetClassById(int id)
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public BooleanGrpc AddNewClass(Class classNew)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        //classNew.Id = GetIDNewClass();
                        //classNew.IsDeleted = 0;
                        session.Insert(classNew);
                        transaction.Commit();
                        r.result = true;
                        r.mess = "Successfull";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        r.result = false;
                        r.mess = ex.Message;
                        transaction.Rollback();
                    }
                    return r;
                }
            }
        }
        public BooleanGrpc UpdateClass(Class classUpdate)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        session.Update(classUpdate);
                        transaction.Commit();
                        r.result = true;
                        r.mess = "Successfull";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        r.result = false;
                        r.mess = ex.Message;
                        transaction.Rollback();
                    }
                    return r;
                }
            }
        }
    }
}
