using Share;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Model.Mapper
{
    public class ClassMapper
    {
        public ClassGrpc ClassToClassGrpc(Class classs)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classs.Id;
            classGrpc.Name = classs.Name;
            classGrpc.Subject = classs.SubjectName;
            classGrpc.TeacherId = classs.TeacherId;
            classGrpc.TeacherName = classs.TeacherName;
            return classGrpc;
        }
        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            _class.TeacherId= classGrpc.TeacherId;
            _class.TeacherName= classGrpc.TeacherName; 
            return _class;
        }
    }
}
