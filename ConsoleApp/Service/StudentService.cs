using ConsoleAppQLSV.Model;
using ConsoleAppQLSV.Repository;
using ConsoleAppQLSV.Repository.IRepository;
using ConsoleAppQLSV.Service.IStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Service
{
    class StudentService : IStudentService
    {
        private readonly IStudentRepositoty _studentRepositoty;
        private readonly IClassRepository _classRepository;
        private List<Student> students;
        public StudentService(IStudentRepositoty studentRepositoty, IClassRepository classRepository)
        {
            _classRepository = classRepository;
            _studentRepositoty = studentRepositoty;

        }
        public void AddNewStudent()
        {
            Student student = new Student();
            // Console.Write("Nhap ma so sinh vien : ");
            //student.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap ten : ");
            student.Name = Console.ReadLine();
            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
            student.Dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap dia chi : ");
            student.Address = Console.ReadLine();
            Console.Write("Nhap ma lop: ");
            int maLop = Convert.ToInt32(Console.ReadLine());
            student.ClassStudent = _classRepository.GetClass(maLop);
            if (student.ClassStudent == null)
            {
                Console.WriteLine("Khong ton tai lop hoc");
            }
            else
            {
                _studentRepositoty.AddNewStudent(student);
                Console.WriteLine("Them sinh vien thanh cong !");
            }
            
        }

        public void DeleteStudent()
        {
            Console.Write("Nhap ma so sinh vien can xoa: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Student? student = _studentRepositoty.GetStudentById(studentID);
            

            if (student != null)
            {
                _studentRepositoty.DeleteStudent(student);
                Console.WriteLine("Xoa sinh vien thanh cong !");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
        }

        public void FindStudentById()
        {
            Console.Write("Nhap ma so sinh vien can tim: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Student? student = _studentRepositoty.GetStudentById(studentID);

            if (student != null)
            {
                Console.WriteLine("Thong tin sinh vien:");
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
        }

        public void ListAllStudent()
        {
            List<Student> listStudent = _studentRepositoty.GetAllStudents();
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
            var students = _studentRepositoty.SortData();
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Nhap ma so sinh vien can chinh sua: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Student student = _studentRepositoty.GetStudentById(studentID);




            if (student != null)
            {
                Console.WriteLine(student.ToString());
                Console.Write("Nhap ten moi: ");
                student.Name = Console.ReadLine();
                Console.Write("Nhap ngay sinh moi: (yyyy-MM-dd): ");
                student.Dob = DateTime.Parse(Console.ReadLine());
                Console.Write("Nhap dia chi moi: ");
                student.Address = Console.ReadLine();
                Console.Write("Nhap ma lop moi: ");
                int maLop = Convert.ToInt32(Console.ReadLine());
                student.ClassStudent = _classRepository.GetClass(maLop);
                _studentRepositoty.UpdateStudent(student);
                if (student.ClassStudent == null)
                {
                    Console.WriteLine("Khong ton tai lop hoc");
                }

                Console.WriteLine("Cap nhat thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }

        }


    }
}



