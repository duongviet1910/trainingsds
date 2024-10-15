using BlazorWebAppRGPC.Data;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Repository;
using BlazorWebAppRGPC.Repository.IRepository;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWebAppRGPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<NHibernate.ISessionFactory>(NHibernateConfig.BuildSessionFactory());
            builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
            builder.Services.AddSingleton<IClassRepository, ClassRepository>();
            builder.Services.AddSingleton<StudentMapper>();
            builder.Services.AddSingleton<ClasssMapper>();
            builder.Services.AddSingleton<TeacherMapper>();
            builder.Services.AddRazorPages(); 
            builder.Services.AddAntDesign();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IClassService, ClassService>();
            builder.Services.AddSingleton<ITeacherService, TeacherService>();
            builder.Services.AddSingleton<IStudentService, StudentService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}