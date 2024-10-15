using AntDesign;
using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Share;
using System.Drawing.Printing;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListTeacher
    {
        [Inject] IClassService ClassService { get; set; }
        [Inject] ITeacherService TeacherService { get; set; }
        [Inject] IMessageService Message { get; set; }


        public List<ClassViewDTO> ListClasss = new List<ClassViewDTO>();
        public List<ClassViewDTO> ListClassPage = new List<ClassViewDTO>();
        public List<Teacher> ListTeachers = new List<Teacher>();
        public ClassDTO ClassDTO = new ClassDTO();
        public Class Classs = new Class();
        public ClassViewDTO ClassSearch = new ClassViewDTO();
        public Teacher Teacher = new Teacher();
        ITable table;

        public int pageNumber = 1;
        public int pageSize = 5;
        public int totalCount = 0;

        public bool isCreate = true;
        public bool isPopupVisible = false;
        protected override async Task OnInitializedAsync()
        {
            ListTeachers = TeacherService.GetAllTeachers();
            await loadData();
        }
        private async Task loadData()
        {
            var result = TeacherService.GetAllTeachers().ToList();
            // ListClassPage = result.ClassViews;
            // totalCount = result.Total;
            //ListTeachers.ForEach(Teacher =>
            //{
            //    Teacher.Dobs = Teacher.Dob.ToString("dd/MM/yyyy");
            //});


            StateHasChanged();
        }

        public async Task OnPaging()
        {
            await loadData();
        }
        private void ShowPopupTeacher(Teacher teacher)
        {
            isPopupVisible = true;
            Teacher = new Teacher();
            if (teacher != null)
            {
                isCreate = false;
                Teacher.Id = teacher.Id;
                Teacher.Name = teacher.Name;
                Teacher.Dob = teacher.Dob;
            }
            else
            {
                isCreate = true;
            }
        }

    }
}