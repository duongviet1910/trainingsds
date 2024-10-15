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
    public partial class ListClass
    {
        [Inject] IClassService ClassService { get; set; }
        [Inject] ITeacherService TeacherService { get; set; }
        [Inject] IMessageService Message {  get; set; }


        public List<ClassViewDTO> ListClasss = new List<ClassViewDTO>();
        public List<ClassViewDTO> ListClassPage = new List<ClassViewDTO>();
        public List<Teacher> ListTeachers = new List<Teacher>();
        public List<TeacherViewDTO> ListTeacherss = new List<TeacherViewDTO>();

        public ClassDTO ClassDTO = new ClassDTO();
        public Class Classs = new Class();
        public ClassViewDTO ClassSearch = new ClassViewDTO();

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
            var result = ClassService.GetDataPage(pageNumber, pageSize, ClassSearch);
            ListClassPage = result.ClassViews;
            ListClassPage.ForEach(c =>
            {
                c.TeacherName = ListTeachers.FirstOrDefault(x => x.Id == c.TeacherId)?.Name;

            });
            totalCount = result.Total;
            StateHasChanged();
        }
        public async Task OnPaging()
        {
            await loadData();
        }
        private async void OnValidSubmit()
        {
            pageNumber = 1;
            await loadData();
        }
        private void OnInvalidSubmit()
        {
            ClassSearch = new ClassViewDTO();
        }
        private void ShowPopupClass(ClassViewDTO classViewDTO)
        {
            isPopupVisible = true;
            ClassDTO = new ClassDTO();
            if (classViewDTO != null)
            {
                isCreate = false;
                ClassDTO.Id = classViewDTO.Id;
                ClassDTO.Name = classViewDTO.Name;
                ClassDTO.SubjectName = classViewDTO.SubjectName;
                ClassDTO.TeacherId = classViewDTO.TeacherId;
                ClassDTO.TeacherName = classViewDTO.TeacherName;
            }
            else
            {
                isCreate = true;
            }
        }
        private void OnSubmitSuccess()
        {
            BooleanGrpc check;
            if (isCreate)
            {
                check = ClassService.AddNewClass(ClassDTO);
            }
            else
            {
                check = ClassService.UpdateClass(ClassDTO);
            }
            if (check.result)
            {
                Success(check.mess);
            }
            else
            {
                Error(check.mess);
            }
            close();
        }
        public void OnSubmitFail()
        {
            Error("Fail");
        }
        private void Error(string mes)
        {
            Message.Error(mes,5);
        }
        private void Success(string mes)
        {
            Message.Success(mes,3);
        }
        public void close()
        {
            Clear();
            isPopupVisible = false;
        }
        public void Clear()
        {
            ClassDTO = new ClassDTO();
            isCreate = true;
            ClassSearch = new ClassViewDTO();

            UpdateListClass();
        }
        private async void UpdateListClass()
        {
            pageNumber = 1;
            await loadData();
        }
        public void DeleteClass(ClassViewDTO classViewDTO)
        {
            var check = ClassService.DeleteClass(classViewDTO);
            if (check.result)
            {
                Success(check.mess);
            }
            else
            {
                Error(check.mess);
            }
            UpdateListClass();
        }
    }
}
