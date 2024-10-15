namespace Assignment
{
    public class Program
    {
        static List<Student> studentList = new List<Student>();

        static List<Teacher> teacherList = new List<Teacher>
        {
            new Teacher{id = 1, name="Nguyen Van A", dob="15/04/1983" },
            new Teacher{id = 2, name="Vu Van B", dob="07/02/1982" },
            new Teacher{id = 3, name="Tran Thi C", dob="13/04/1984" }
        };

        static List<Class> classList = new List<Class>
        {
            new Class{id = 1, name="SE1620", subject = "PRN221", teacher = teacherList[0] },
            new Class{id = 2, name="SE1625", subject = "PRU211", teacher = teacherList[1] },
            new Class{id = 3, name="SE1630", subject = "PRM392", teacher = teacherList[2] }
        };
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----- Quan Ly Sinh Vien -----");
                Console.WriteLine("1. Xem Danh Sach Sinh Vien");
                Console.WriteLine("2. Them Moi Sinh Vien");
                Console.WriteLine("3. Chinh Sua Thong Tin Sinh Vien");
                Console.WriteLine("4. Xoa Sinh Vien");
                Console.WriteLine("5. Sap xep du lieu sinh vien theo ten");
                Console.WriteLine("6. Tim kiem Sinh Vien theo ma Sinh vien");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowStudentList();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        SortListStudentByName();
                        break;
                    case "6":
                        FindStudentById();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                        break;
                }

                Console.WriteLine("\nNhan Enter đe tiep tuc...");
                Console.ReadLine();
            }
        }
        static void ShowStudentList()
        {
            Console.WriteLine("----- Danh Sach Sinh Vien -----");

            if (studentList.Count > 0)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", "Id", "Ten", "Ngay sinh", "Dia chi", "Lop Hoc");
                foreach (var s in studentList)
                {
                    Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", s.id, s.name, s.dob, s.address, s.classroom.name);
                }
            }
            else
            {
                Console.WriteLine("Khong co sinh vien nao trong danh sach.");
            }
        }
        static void AddStudent()
        {
            Console.WriteLine("----- Them Sinh Vien -----");

            Console.Write("Nhap ten sinh vien: ");
            string name = Console.ReadLine();

            Console.Write("Nhap ngay sinh: ");
            string dob = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            string address = Console.ReadLine();

            Console.WriteLine("Danh sach lop hoc:");
            foreach (var c in classList)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15}", c.id, c.name, c.subject, c.teacher.name);
            }

            Class classStudent = null;
            while (true)
            {

                Console.Write("Nhap lop hoc: ");
                string classId = Console.ReadLine();

                foreach (var c in classList)
                {
                    if (int.Parse(classId) == c.id)
                    {
                        classStudent = c; break;
                    }
                }
                if (classStudent != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Class khong ton tai");
                }
            }

            int idStudent = 1;
            if (studentList.Count > 0)
            {
                idStudent = studentList[studentList.Count - 1].id + 1;
            }
            Student newStudent = new Student { id = idStudent, name = name, dob = dob, address = address, classroom = classStudent };
            studentList.Add(newStudent);

            Console.WriteLine("Sinh vien da duoc them thanh cong!");
        }
        static void UpdateStudent()
        {
            ShowStudentList();

            if (studentList.Count > 0)
            {
                Console.Write("Nhap ma Sinh Vien muon sua: ");
                string stId = Console.ReadLine();
                Student student = new Student();
                foreach (var s in studentList)
                {
                    if (int.Parse(stId) == s.id)
                    {
                        student = s; break;
                    }
                }
                if (student == null)
                {
                    Console.WriteLine("----- Sinh Vien khong ton tai -----");
                }
                else
                {
                    Console.WriteLine("----- Chinh Sua Thong Tin Sinh Vien -----");

                    Console.Write("Nhap ten sinh vien: ");
                    string name = Console.ReadLine();
                    student.name = name;

                    Console.Write("Nhap ngay sinh: ");
                    string dob = Console.ReadLine();
                    student.dob = dob;

                    Console.Write("Nhap dia chi: ");
                    string address = Console.ReadLine();
                    student.address = address;

                    Console.WriteLine("Danh sach lop hoc:");
                    foreach (var c in classList)
                    {
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15}", c.id, c.name, c.subject, c.teacher.name);
                    }
                    Console.Write("Nhap lop hoc: ");
                    string className = Console.ReadLine();

                    foreach (var c in classList)
                    {
                        if (className.ToLower().Equals(c.name.ToLower()))
                        {
                            student.classroom = c; break;
                        }
                    }

                    Console.WriteLine("Sinh vien da duoc chinh sua thanh cong!");
                }
            }
        }
        static void DeleteStudent()
        {
            ShowStudentList();

            if (studentList.Count > 0)
            {
                Console.Write("Nhap ma Sinh Vien muon xoa: ");
                string stId = Console.ReadLine();
                foreach (var s in studentList)
                {
                    if (int.Parse(stId) == s.id)
                    {
                        studentList.Remove(s); break;
                    }
                }
                Console.WriteLine("Sinh vien da duoc xoa thanh cong!");
            }
        }
        static void SortListStudentByName()
        {
            List<Student> studentListSort = studentList.OrderBy(s => s.name).ToList();
            Console.WriteLine("----- Danh Sach Sinh Vien -----");

            if (studentList.Count > 0)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", "Id", "Ten", "Ngay sinh", "Dia chi", "Lop Hoc");
                foreach (var s in studentListSort)
                {
                    Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", s.id, s.name, s.dob, s.address, s.classroom.name);
                }
            }
            else
            {
                Console.WriteLine("Khong co sinh vien nao trong danh sach.");
            }
        }
        static void FindStudentById()
        {
            if (studentList.Count > 0)
            {
                Console.WriteLine("Nhap ma Sinh Vien muon tim kiem: ");
                string stId = Console.ReadLine();
                foreach (var s in studentList)
                {
                    if (int.Parse(stId) == s.id)
                    {
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", s.id, s.name, s.dob, s.address, s.classroom.name);
                        break;
                    }
                }
            }
        }
    }
}