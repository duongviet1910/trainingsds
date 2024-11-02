using AntDesign;
using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Repository;
using BlazorWebAppRGPC.Repository.IRepository;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Share;
using System.ServiceModel.Channels;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListStudent
    {
        [Inject] IStudentService StudentService { get; set; }
        [Inject] IClassService ClassService { get; set; }
        [Inject] ITeacherService TeacherService { get; set; }
        [Inject] IMessageService Message { get; set; }

        private List<StudentViewDTO> listStudentViewDTO = new List<StudentViewDTO>();
        private List<StudentViewDTO> listStudentUpdate = new List<StudentViewDTO>();

        private List<Class> listClass = new List<Class>();
        public Student student = new Student();
        public StudentDTO StudentDTO = new StudentDTO();
        public List<Teacher> ListTeachers = new List<Teacher>();
        public List<ClassViewDTO> ListClasss = new List<ClassViewDTO>();
        public StudentViewDTO studentSearch = new StudentViewDTO();
        private List<Student> ListStudents = new List<Student>();
        public Student Student = new Student();




        [Inject] StudentMapper studentMapper { get; set; }

        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalCount = 0;
        private PageView<Student> pageItems = new PageView<Student>();
        public bool isCreate = true;
        public bool isPopupVisible = false;
        
        protected override async Task OnInitializedAsync()
        {
            ListClasss = ClassService.GetAllClasss();
            await loadData();
        }
        

        private async Task loadData()
        {
            var result = StudentService.GetDataPage(pageNumber, pageSize, studentSearch);
            listStudentViewDTO = result.StudentViews;
            listStudentViewDTO.ForEach(c =>
            {
                c.ClassName = ListClasss.FirstOrDefault(x => x.Id == c.ClassId)?.Name;
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
            studentSearch = new StudentViewDTO();
        }
        private void ShowPopupStudent(StudentViewDTO studentViewDTO)
        {
            isPopupVisible = true;
            StudentDTO = new StudentDTO();
            if (studentViewDTO != null)
            {
                isCreate = false;
                StudentDTO.Id = studentViewDTO.Id;
                StudentDTO.Name = studentViewDTO.Name;
                StudentDTO.Dob = studentViewDTO.Dob;
                StudentDTO.Address = studentViewDTO.Address;
                StudentDTO.ClassId = studentViewDTO.ClassId;
                StudentDTO.ClassName = studentViewDTO.ClassName;

            }
            else
            {
                isCreate = true;
                StudentDTO.Dob = DateTime.Today;
            }
        }

        async Task UpdateStudentClassesAsync()
        {
            BooleanGrpc check;
            listStudentUpdate = StudentService.GetAllStudent();
            check = StudentService.UpdateStudentClass(listStudentUpdate);
            if(check.result)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = check.mess,
                    NotificationType = NotificationType.Success
                });
                await loadData();
            }
            else
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = check.mess,
                    NotificationType = NotificationType.Error
                });
            }

        }

        private void OnSubmitSuccess()
        {
            BooleanGrpc check;
            if (isCreate)
            {
                check = StudentService.AddStudent(StudentDTO);
            }
            else
            {
                check = StudentService.UpdateStudent(StudentDTO);
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
            Message.Error(mes, 5);
        }
        private void Success(string mes)
        {
            Message.Success(mes, 3);
        }
        public void close()
        {
            Clear();
            isPopupVisible = false;
        }
        public void Clear()
        {
            StudentDTO = new StudentDTO();
            isCreate = true;
            studentSearch = new StudentViewDTO();

            UpdateListStudent();
        }
        
        public void DeleteStudent(StudentViewDTO studentViewDTO)
        {
            var check = StudentService.DeleteStudent(studentViewDTO);
            if (check.result)
            {
                Success(check.mess);

                UpdateListStudent();

            }
            else
            {
                Error(check.mess);
            }
        }

        private async void UpdateListStudent()
        {
            await loadData();
        }
    }
}
