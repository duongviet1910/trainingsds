using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service.IService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorWebAppRGPC.Service
{
    public class TeacherService : ITeacherService
    {
        TeacherMapper teacherMapper = new TeacherMapper();
        public TeacherProto getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5141", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<TeacherProto>();
        }
        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            var client = getService();
            Empty e = new Empty();
            var list = client.GetListTeacher(e);
            foreach( var teacher in list.List)
            {
                Teacher t = teacherMapper.TeacherGrpcToTeacher(teacher);
                teachers.Add(t);
            }
            return teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            Empty e = new Empty();
            var client = getService();
            var t = client.GetTeacherById(teacherMapper.ToIntGrpc(id));
            return teacherMapper.TeacherGrpcToTeacher(t);
        }
    }
}
