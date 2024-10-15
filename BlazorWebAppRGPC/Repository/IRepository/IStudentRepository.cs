using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWebAppRGPC.Model;

namespace BlazorWebAppRGPC.Repository.IRepository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Boolean AddNewStudent(Student student);

        public Boolean UpdateStudent(Student studentUpdate);

        public void DeleteStudent(Student student);

        public List<Student> SortData();

        public Student GetStudentById(int id);
        public int GetIDNewStudent();
        Task<PageView<Student>> GetDataPage(int pageNumber, int pageSize, StudentSearch studentSearch);
    }
}
