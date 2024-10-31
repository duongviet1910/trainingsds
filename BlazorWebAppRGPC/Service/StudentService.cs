using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Pages;
using BlazorWebAppRGPC.Service.IService;
using Grpc.Net.Client;
using OneOf.Types;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorWebAppRGPC.Service
{
    public class StudentService : IStudentService
    {
        StudentMapper studentMapper = new StudentMapper();
        ClasssMapper ClassMapper = new ClasssMapper();
        TeacherMapper TeacherMapper = new TeacherMapper();
        public StudentProto getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5141", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<StudentProto>();
        }
        public BooleanGrpc AddStudent(StudentDTO studentnew)
        {
            var client = getService();
            StudentGrpc studentGrpc = studentMapper.StudentDTOToStudentGrpc(studentnew);
            return client.AddStudent(studentGrpc);
        }
        public BooleanGrpc UpdateStudent(StudentDTO studentUpdate)
        {
            var client = getService();
            var c = studentMapper.StudentDTOToStudentGrpc(studentUpdate);
            return client.UpdateStudent(c);
        }

        public BooleanGrpc DeleteStudent(StudentViewDTO studentDelete)
        {
            var client = getService();
            var c = studentMapper.StudentViewDTOToStudentGrpc(studentDelete);
            return client.DeleteStudent(c);
        }


        public BooleanGrpc UpdateStudentClass(List<StudentViewDTO> studentUpdateclass)
        {
            var client = getService();
            List<StudentGrpc> studentGrpcs = new List<StudentGrpc>();
            DateTime today = DateTime.Today;
            DateTime juneFirst = new DateTime(today.Year, 6, 1);

            foreach (StudentViewDTO dto in studentUpdateclass)
            {
                
                if (DateTime.Now.Month > 6)
                {
                    
                    dto.ClassId++;
                }

                // Chuyển đổi đối tượng StudentDTO sang StudentGrpc
                var grpc = studentMapper.StudentViewDTOToStudentGrpc(dto);
                studentGrpcs.Add(grpc);
            }

            return client.UpdateStudentClass(studentGrpcs);
        }

        public List<StudentViewDTO> GetAllStudent()
        {
            List<StudentViewDTO> listStudents = new List<StudentViewDTO>();
            var client = getService();
            Empty empty = new Empty();
            var list = client.GetListStudent(empty);
            foreach (var c in list.List)
            {
                StudentViewDTO s = studentMapper.StudentGrpcToStudentViewDTO(c);
                listStudents.Add(s);
            }
            return listStudents;
        }


        public int GetIDNewStudent()
        {
            throw new NotImplementedException();
        }

        public List<Student> SortData()
        {
            throw new NotImplementedException();
        }

        public DataPageItem GetDataPage(int pageNumber, int pageSize, StudentViewDTO studentSearch)
        {

            try
            {
                DataPageItem listStudent = new DataPageItem();
                var client = getService();
                PageStudent p = new PageStudent();
                p.PageNumber = pageNumber;
                p.PageSize = pageSize;
                p.StudentGrpc = studentSearch != null ? studentMapper.StudentViewDTOToStudentGrpc(studentSearch) : new StudentGrpc();
                var list = client.GetDataPage(p);
                var stt = (pageNumber - 1) * pageSize + 1;
                foreach (var c in list.List)
                {
                    StudentViewDTO s = studentMapper.StudentGrpcToStudentViewDTO(c);
                    s.STT = stt++;
                    listStudent.StudentViews.Add(s);
                }
                listStudent.Total = list.Total;
                return listStudent;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return new DataPageItem();
        } 

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
