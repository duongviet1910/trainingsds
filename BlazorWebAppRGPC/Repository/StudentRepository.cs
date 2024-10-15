using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Repository.IRepository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Data;

namespace BlazorWebAppRGPC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISessionFactory _session;
        public StudentRepository(ISessionFactory session)
        {
            _session = session;
        }

        public Boolean AddNewStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Insert(student);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public void DeleteStudent(Student student)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Delete(student);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenStatelessSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .ToList();
            }
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

        public Boolean UpdateStudent(Student studentUpdate)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        session.Update(studentUpdate);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        private IQueryable<Student> Filter(IQueryable<Student> query, StudentSearch studentSearch)
        {
            if (!string.IsNullOrWhiteSpace(studentSearch.Name))
            {
                query = query.Where(x => x.Name.Contains(studentSearch.Name));
            }
            if (!string.IsNullOrWhiteSpace(studentSearch.Address))
            {
                query = query.Where(x => x.Address.Contains(studentSearch.Address));
            }
            if (studentSearch.StartDate != null)
            {
                query = query.Where(x => x.Dob <= studentSearch.StartDate);
            }
            if (studentSearch.EndDate != null)
            {
                query = query.Where(x => x.Dob >= studentSearch.EndDate);
            }
            //if (studentSearch.ClassID != -1)
            //{
            //    query = query.Where(x => x.ClassStudent.Id == studentSearch.ClassID);
            //}
            if (!string.IsNullOrWhiteSpace(studentSearch.ClassName))
            {
                query = query.Where(x => x.ClassName.Contains(studentSearch.ClassName));
            }

            return query;
        }
        public async Task<PageView<Student>> GetDataPage(int pageNumber, int pageSize, StudentSearch studentSearch)
        {
            using (var session = _session.OpenSession())
            {
                var query = session.Query<Student>();
                query = Filter(query, studentSearch);
                var pageData = await query.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
                var total = query.Count();
                return new PageView<Student>
                {
                    Items = pageData,
                    PageCount = total
                };
            }
        }
    }
}
