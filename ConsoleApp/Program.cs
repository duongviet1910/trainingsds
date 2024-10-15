using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using ConsoleAppQLSV.Repository.IRepository;
using ConsoleAppQLSV.Repository;
using Microsoft.Extensions.DependencyInjection;
using ConsoleAppQLSV.Service.IStudent;
using ConsoleAppQLSV.Service;
using ConsoleAppQLSV;

namespace ConsoleAppQLSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .BuildSessionFactory()
            .AddSingleton<IStudentRepositoty, StudentRepository>()
            .AddSingleton<IClassRepository, ClassRepository>()
            .AddSingleton<IStudentService, StudentService>()
            .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var studentService = serviceProvider.GetService<IStudentService>();
                Menu();
                while (true)
                {
                    Console.Write("Chon chuc nang : ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            studentService.ListAllStudent();
                            break;
                        case 2:
                            studentService.AddNewStudent();
                            break;
                        case 3:
                            studentService.UpdateStudent();
                            break;
                        case 4:
                            studentService.DeleteStudent();
                            break;
                        case 5:
                            studentService.SortData();
                            break;
                        case 6:
                            studentService.FindStudentById();
                            break;
                        case 7:
                            return;

                    }
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n Quan li sinh vien ");
            Console.WriteLine("1. Xem danh sach sinh vien ");
            Console.WriteLine("2. Thêm moi sinh vien ");
            Console.WriteLine("3. Chinh sua thong tin sinh vien ");
            Console.WriteLine("4. Xoa sinh vien");
            Console.WriteLine("5. Sap xep sinh vien theo ten ");
            Console.WriteLine("6. Tim kiem sinh vien theo ma so sinh vien ");
            Console.WriteLine("7. Thoat");
        }
    }
}