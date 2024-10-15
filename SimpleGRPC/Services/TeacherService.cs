using ProtoBuf.Grpc;
using Share;
using SimpleGRPC.Model;
using SimpleGRPC.Model.Mapper;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Services
{
    public class TeacherService : TeacherProto
    {
        private readonly ILogger<TeacherService> logger;
        private readonly ITeacherRepository _teacherRepository;
        TeacherMapper teacherMapper = new TeacherMapper();

        public TeacherService(ILogger<TeacherService> logger, ITeacherRepository teacherRepository)
        {
            this.logger = logger;
            _teacherRepository = teacherRepository;
        }
        public ListTeachers GetListTeacher(Empty request, CallContext context = default)
        {
            ListTeachers listTeachers = new ListTeachers();
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            foreach (var item in teachers)
            {
                TeacherGrpc teacherGrpc = teacherMapper.TeacherToTeacherGrpc(item);
                listTeachers.List.Add(teacherGrpc);
            }
            return listTeachers;
        }

        public TeacherGrpc GetTeacherById(IntGrpc id, CallContext context = default)
        {
            Teacher t = _teacherRepository.GetTeacherById(id.Id);
            return teacherMapper.TeacherToTeacherGrpc(t);
        }
    }
}
