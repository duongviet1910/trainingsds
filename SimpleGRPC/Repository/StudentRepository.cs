using SimpleGRPC.Model;
using SimpleGRPC.Repository.IRepository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Data;
using Share;
using System.Collections;

namespace SimpleGRPC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISessionFactory _session;
        public StudentRepository(ISessionFactory session)
        {
            _session = session;
        }

        public BooleanGrpc AddNewStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {

                        session.Insert(student);
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
        public BooleanGrpc DeleteStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {

                        session.Delete(student);
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


        public BooleanGrpc UpdateStudentClass(List<Student> studentUpdateclass)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        foreach (var student in studentUpdateclass)
                        {
                            session.Update(student);
                        }
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

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenStatelessSession())
            {
                return session.Query<Student>()
                    //.Fetch(s => s.ClassStudent)
                    .ToList();
            }
        }

        public DataItems GetDataPage(int pageNumber, int pageSize, Student studentSearch)
        {
            using (var session = _session.OpenSession())
            {
                try
                {
                    DataItems result = new DataItems();
                    var query = session.Query<Student>()/*.Where(x=>x.IsDeleted != 1)*/;
                    query = Filter(query, studentSearch);
                    result.Total = query.Count();
                    result.StudentList = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
        private IQueryable<Student> Filter(IQueryable<Student> query, Student studentSearch)
        {
            
            if (!string.IsNullOrWhiteSpace(studentSearch.Name))
            {
                query = query.Where(x => x.Name.Contains(studentSearch.Name));
            }
            if (!string.IsNullOrWhiteSpace(studentSearch.Address))
            {
                query = query.Where(x => x.Address.Contains(studentSearch.Address));
            }
            //if (studentSearch.ClassId != null)
            //{
            //    query = query.Where(x => x.ClassId == studentSearch.ClassId);
            //}
            if (studentSearch.ClassId != 0)
            {
                query = query.Where(x => x.ClassId == studentSearch.ClassId);
            }
            return query;
        }

        public int GetIDNewStudent()
        {
            var student = GetAllStudents().OrderByDescending(x => x.Id).First();
            return student.Id + 1;
        }

        public Student GetStudentById(int id)
        {
            using (var session = _session.OpenStatelessSession())
            {
                var student = session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .Where(s => s.Id == id)
                    .ToList()
                    .FirstOrDefault();
                return student;
            }
        }

        public List<Student> SortData()
        {
            using (var session = _session.OpenStatelessSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .OrderBy(s => s.Name)
                    .ToList();
            }
        }

        public BooleanGrpc UpdateStudent(Student studentUpdate)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {

                        session.Update(studentUpdate);
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
