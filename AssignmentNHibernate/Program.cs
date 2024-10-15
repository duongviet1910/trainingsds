using Microsoft.Extensions.DependencyInjection;
using AssignmentNHibernate.Model;
using AssignmentNHibernate.Utils;
using NHibernate.Cfg;
using Environment = System.Environment;
using NHibernate;
using AssignmentNHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using AssignmentNHibernate.Model.Mapping;
using AssignmentNHibernate.Repository;
using AssignmentNHibernate.Repository.IRepository;
using AssignmentNHibernate.Service.IService;
using AssignmentNHibernate.Service;

namespace AssignmentNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .BuildSessionFactory()
            .AddSingleton<IStudentRepository, StudentRepository>()
            .AddSingleton<IClassRepository, ClassRepository>()
            .AddSingleton<IStudentService, StudentService>()
            .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var studentService = serviceProvider.GetService<IStudentService>();
                while (true)
                {
                    menu();
                    int choose = InputHelper.NumberCheckInRange("Nhap lua chon : ", 0, 6);
                    switch (choose)
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
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }


        static void menu()
        {
            Console.WriteLine("----- Quan Ly Sinh Vien -----");
            Console.WriteLine("1. Xem Danh Sach Sinh Vien");
            Console.WriteLine("2. Them Moi Sinh Vien");
            Console.WriteLine("3. Chinh Sua Thong Tin Sinh Vien");
            Console.WriteLine("4. Xoa Sinh Vien");
            Console.WriteLine("5. Sap xep du lieu sinh vien theo ten");
            Console.WriteLine("6. Tim kiem Sinh Vien theo ma Sinh vien");
            Console.WriteLine("0. Thoat");
        }
    }

}