using AssignmentNHibernate.Model;
using AssignmentNHibernate.Repository.IRepository;
using AssignmentNHibernate.Service.IService;
using AssignmentNHibernate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNHibernate.Service
{
    class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }
        public void AddNewStudent()
        {
            var student = new Student
            {
                Id = getNewId(),
                Name = InputHelper.StringNotBlank("Enter student name: "),
                Dob = InputHelper.DateCheck("Enter student dob: "),
                Address = InputHelper.StringNotBlank("Enter student address: "),
                ClassStudent = InputHelper.ClassId("Enter class id: ", _classRepository.GetAllClasses())
            };
            _studentRepository.AddNewStudent(student);
        }

        public void DeleteStudent()
        {
            List<Student> listStudent = _studentRepository.GetAllStudents();
            if (listStudent.Count == 0)
            {
                Console.WriteLine("No data can delete");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
                Student studentDelete = InputHelper.StudentId("Enter Student ID you want to delete: ", listStudent);
                _studentRepository.DeleteStudent(studentDelete);
            }
        }

        public void FindStudentById()
        {
            int id = InputHelper.NumberCheck("Enter the student id: ");
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine($"Not Found Student's Information with Id = {id}");
            }
            else
            {
                Console.WriteLine(student);
            }
        }

        public void ListAllStudent()
        {
            List<Student> listStudent = _studentRepository.GetAllStudents();
            if (listStudent.Count == 0)
            {
                Console.WriteLine("Has 0 student");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void SortData()
        {
            List<Student> listStudent = _studentRepository.SortData();
            if (listStudent.Count == 0)
            {
                Console.WriteLine("Has 0 student");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void UpdateStudent()
        {
            List<Student> listStudent = _studentRepository.GetAllStudents();
            if (listStudent.Count == 0)
            {
                Console.WriteLine("No data can update");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
                Student studentUpdate = InputHelper.StudentId("Enter Student ID you want to update: ", listStudent);

                studentUpdate.Name = InputHelper.StringNotBlank("Enter the new name: ");
                studentUpdate.Dob = InputHelper.DateCheck("Enter the new dob (dd/MM/yyyy): ");
                studentUpdate.Address = InputHelper.StringNotBlank("Enter the new address: ");
                studentUpdate.ClassStudent = InputHelper.ClassId("Enter the new id class: ", _classRepository.GetAllClasses());
                _studentRepository.UpdateStudent(studentUpdate);
            }
        }
        private int getNewId()
        {
            if (_studentRepository.GetAllStudents().Count == 0)
            {
                return 1;
            }
            var student = _studentRepository.GetAllStudents().Last();
            int result = student.Id + 1;
            return result;
        }
    }
}
