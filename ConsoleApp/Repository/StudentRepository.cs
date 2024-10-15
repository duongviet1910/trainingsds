using ConsoleAppQLSV.Model;
using ConsoleAppQLSV.Repository.IRepository;
using NHibernate.Linq;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Repository
{
    class StudentRepository : IStudentRepositoty
    {
        private readonly IClassRepository _classRepository;
        private readonly ISessionFactory _session;
        public StudentRepository(IClassRepository classRepository, ISessionFactory session)
        {
            _classRepository = classRepository;
            _session = session;
        }

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenSession())
            {
                var result = session.Query<Student>()
                                    .Fetch(s => s.ClassStudent) // Sử dụng JoinQueryOver để ánh xạ các liên kết
                                    .ToList();

                return result;
            }
        }

/*
        public int geta()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>().OrderByDescending(c => c.Id).FirstOrDefault().Id;

            }

        }
*/

        public void AddNewStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {

                        session.Save(student);


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

        public void UpdateStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(student);
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

        public void DeleteStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
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

        public List<Student> SortData()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        public void FindStudentById()
        {
            throw new NotImplementedException();
        }   

        public Student GetStudentById(int id)
        {
            using (var session = _session.OpenSession())
            {
                var student = session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .Where(s => s.Id == id)
                    .ToList()
                    .FirstOrDefault();
                return student;
            }
        }
    }
}
