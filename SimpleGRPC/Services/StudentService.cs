using NHibernate.Mapping.ByCode.Impl;
using ProtoBuf.Grpc;
using Share;
using SimpleGRPC.Model;
using SimpleGRPC.Model.Mapper;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Services
{
    public class StudentService : StudentProto
    {
        private readonly ILogger<StudentService> logger;
        private readonly IStudentRepository studentRepository;
        StudentMapper studentMapper = new StudentMapper();

        public StudentService(ILogger<StudentService> logger, IStudentRepository _studentRepository)
        {
            this.logger = logger;
            studentRepository = _studentRepository;
        }

        public BooleanGrpc AddStudent(StudentGrpc request, CallContext context = default)
        {
            Student student = studentMapper.StudenGrpcToStudent(request);
            return studentRepository.AddNewStudent(student);
        }

        public BooleanGrpc DeleteStudent(StudentGrpc request, CallContext context = default)
        {
            Student studentDelete = studentMapper.StudenGrpcToStudent(request);
            return studentRepository.DeleteStudent(studentDelete);
        }

        public ListStudents GetListStudent(Empty request, CallContext context = default)
        {
            ListStudents listStudents = new ListStudents();
            List<Student> students = studentRepository.GetAllStudents();
            foreach (var item in students)
            {
                StudentGrpc studentGrpc = studentMapper.StudentToStudentGrpc(item);
                listStudents.List.Add(studentGrpc);
            }
            return listStudents;
        }

        public BooleanGrpc UpdateStudent(StudentGrpc request, CallContext context = default)
        {
            Student studentUpdate = studentMapper.StudenGrpcToStudent(request);
            return studentRepository.UpdateStudent(studentUpdate);
        }

        public StudentGrpc GetStudentById(IntGrpc id, CallContext context = default)
        {
            Student t = studentRepository.GetStudentById(id.Id);
            return studentMapper.StudentToStudentGrpc(t);
        }

        

        public DataPageStudent GetDataPage(PageStudent pageStudent, CallContext context = default)
        {
            DataPageStudent listStudents = new DataPageStudent();
            Student studentSearch;

                studentSearch = studentMapper.StudenGrpcToStudent(pageStudent.StudentGrpc);

            var students = studentRepository.GetDataPage(pageStudent.PageNumber, pageStudent.PageSize, studentSearch);
            foreach (var item in students.StudentList)
            {
                StudentGrpc studentItem = studentMapper.StudentToStudentGrpc(item);
                listStudents.List.Add(studentItem);
            }
            listStudents.Total = students.Total;
            return listStudents;
        }

    }
}
