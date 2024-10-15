using Share;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Model.Mapper
{
    public class StudentMapper
    {
        public StudentGrpc StudentToStudentGrpc(Student students)
        {
            ClassMapper classMapper = new ClassMapper();
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = students.Id;
            studentGrpc.Name = students.Name;
            studentGrpc.Dob = students.Dob;
            studentGrpc.Address = students.Address;
            studentGrpc.ClassId = students.ClassId;
            studentGrpc.ClassName = students.ClassName;
            return studentGrpc;
        }
        public Student StudenGrpcToStudent(StudentGrpc studentGrpc)
        {
            ClassMapper classMapper = new ClassMapper();

            Student _student = new Student();
            _student.Id = studentGrpc.Id;
            _student.Name = studentGrpc.Name;
            _student.Dob = studentGrpc.Dob;
            _student.Address = studentGrpc.Address;
            _student.ClassId = studentGrpc.ClassId; 
            _student.ClassName = studentGrpc.ClassName;
            return _student;
        }
    }
}
