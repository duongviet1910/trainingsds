using ConsoleAppQLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Repository.IRepository
{
     interface IStudentRepositoty
    {
        public List<Student> GetAllStudents();

        public void AddNewStudent(Student student);

        public void UpdateStudent(Student studentUpdate);

        public void DeleteStudent(Student student);

        public List<Student> SortData();

        public void FindStudentById();

        public Student GetStudentById(int id);
    }
}
