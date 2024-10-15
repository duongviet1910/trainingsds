using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Share;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class StudentMapper
    {
        public StudentViewDTO StudentGrpcToStudentViewDTO(StudentGrpc studentGrpc)
        {
            ClasssMapper classMapper = new ClasssMapper();

            StudentViewDTO _student = new StudentViewDTO();
            _student.Id = studentGrpc.Id;
            _student.Name = studentGrpc.Name;
            _student.Dob = studentGrpc.Dob;
            _student.Address = studentGrpc.Address;
            _student.ClassId = studentGrpc.ClassId;
            _student.ClassName = studentGrpc.ClassName;
            return _student;
        }
        public StudentGrpc StudentViewDTOToStudentGrpc(StudentViewDTO studentViewDTO)
        {
            ClasssMapper classMapper = new ClasssMapper();
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = studentViewDTO.Id;
            studentGrpc.Name = studentViewDTO.Name;
            studentGrpc.Dob = studentViewDTO.Dob;
            studentGrpc.Address = studentViewDTO.Address;
            studentGrpc.ClassId = studentViewDTO.ClassId;
            studentGrpc.ClassName = studentViewDTO.ClassName;
            return studentGrpc;
        }
        public StudentGrpc StudentDTOToStudentGrpc(StudentDTO studentDTO)
        {
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = studentDTO.Id;
            studentGrpc.Name = studentDTO.Name;
            studentGrpc.Dob = studentDTO.Dob;
            studentGrpc.Address = studentDTO.Address;
            studentGrpc.ClassId = studentDTO.ClassId;
            studentGrpc.ClassName = studentDTO.ClassName;
            return studentGrpc;
        }

        
    }
}
