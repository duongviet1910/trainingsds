using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using SimpleGRPC.Model;

namespace SimpleGRPC.Repository.IRepository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public BooleanGrpc AddNewStudent(Student student);

        public BooleanGrpc UpdateStudent(Student studentUpdate);

        public BooleanGrpc DeleteStudent(Student student);

        public List<Student> SortData();

        public Student GetStudentById(int id);
        public int GetIDNewStudent();
        public DataItems GetDataPage(int pageNumber, int pageSize, Student studentSearch);
    }
}
