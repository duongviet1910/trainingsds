using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service.IService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorWebAppRGPC.Service
{
    public class ClassService : IClassService
    {
        ClasssMapper ClassMapper = new ClasssMapper();
        TeacherMapper TeacherMapper = new TeacherMapper();
        public ClassProto getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5141", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<ClassProto>();
        }   
        public BooleanGrpc AddNewClass(ClassDTO classNew)
        {
                var client = getService();
                ClassGrpc classGrpc = ClassMapper.ClassDTOToClassGrpc(classNew);
                return client.AddClass(classGrpc);
        }
        public BooleanGrpc UpdateClass(ClassDTO classUpdate)
        {
            var client = getService();
            var c = ClassMapper.ClassDTOToClassGrpc(classUpdate);
            return client.UpdateClass(c);
        }

        public BooleanGrpc DeleteClass(ClassViewDTO classDelete)
        {
            var client = getService();
            var c = ClassMapper.ClassViewDTOToClassGrpc(classDelete);
            return client.DeleteClass(c);
        }

        public List<ClassViewDTO> GetAllClasss()
        {
            List<ClassViewDTO> listClasses = new List<ClassViewDTO>();
            var client = getService();
            Empty empty = new Empty();
            var list = client.GetListClass(empty);
            foreach (var c in list.List)
            {
                ClassViewDTO s = ClassMapper.ClassGrpcToClassViewDTO(c);
                listClasses.Add(s);
            }
            return listClasses;
        }


        public int GetIDNewClass()
        {
            throw new NotImplementedException();
        }

        public List<Class> SortData()
        {
            throw new NotImplementedException();
        }

        public DataPageItem GetDataPage(int pageNumber, int pageSize, ClassViewDTO classSearch)
        {
            DataPageItem listClasses = new DataPageItem();
            var client = getService();
            ClassGrpc search = ClassMapper.ClassViewDTOToClassGrpc(classSearch);
            Page p = new Page();
            p.PageNumber = pageNumber; p.PageSize = pageSize; p.ClassGrpc = search;
            var list = client.GetDataPage(p);
            var stt = (pageNumber - 1) * pageSize + 1;
            foreach (var c in list.List)
            {
                ClassViewDTO s = ClassMapper.ClassGrpcToClassViewDTO(c);
                s.STT = stt++;
                listClasses.ClassViews.Add(s);
            }
            listClasses.Total = list.Total;
            return listClasses;
        }

        public Class GetClassById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
