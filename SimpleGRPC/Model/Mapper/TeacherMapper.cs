using Share;
using System.Drawing.Printing;

namespace SimpleGRPC.Model.Mapper
{
    public class TeacherMapper
    {
        public TeacherGrpc TeacherToTeacherGrpc(Teacher teacher)
        {
            TeacherGrpc teacherGrpc = new TeacherGrpc();
            teacherGrpc.Id = teacher.Id;
            teacherGrpc.Name = teacher.Name;
            teacherGrpc.Dob = teacher.Dob;
            return teacherGrpc;
        }

        
    }
}
