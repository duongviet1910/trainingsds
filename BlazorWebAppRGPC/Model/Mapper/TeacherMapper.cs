using BlazorWebAppRGPC.Model.DTO;
using Share;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class TeacherMapper
    {
        public Teacher TeacherGrpcToTeacher(TeacherGrpc teacherGrpc)
        {
            Teacher teacher = new Teacher();
            teacher.Id = teacherGrpc.Id;
            teacher.Name = teacherGrpc.Name;
            teacher.Dob = teacherGrpc.Dob;
            return teacher;
        }
        public IntGrpc ToIntGrpc(int id)
        {
            IntGrpc intGrpc = new IntGrpc();
            intGrpc.Id = id;
            return intGrpc;
        }

        
    }
}
