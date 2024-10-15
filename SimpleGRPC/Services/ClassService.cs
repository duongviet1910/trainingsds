using ProtoBuf.Grpc;
using Share;
using SimpleGRPC.Model;
using SimpleGRPC.Model.Mapper;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Services
{
    public class ClassService : ClassProto
    {
        private readonly ILogger<ClassService> logger;
        private readonly IClassRepository classRepository;
        ClassMapper classMapper = new ClassMapper();

        public ClassService(ILogger<ClassService> logger, IClassRepository _classRepository)
        {
            this.logger = logger;
            classRepository = _classRepository;
        }

        public BooleanGrpc AddClass(ClassGrpc request, CallContext context = default)
        {
            Class classNew = classMapper.ClassGrpcToClass(request);
            return classRepository.AddNewClass(classNew);
        }

        public BooleanGrpc DeleteClass(ClassGrpc request, CallContext context = default)
        {
            Class classDelete = classMapper.ClassGrpcToClass(request);
            return classRepository.DeleteClass(classDelete);
        }

        public ListClasses GetListClass(Empty request, CallContext context = default)
        {
            ListClasses listClasses = new ListClasses();
            List<Class> classes = classRepository.GetAllClasses();
            foreach (var item in classes)
            {
                ClassGrpc classGrpc = classMapper.ClassToClassGrpc(item);
                listClasses.List.Add(classGrpc);
            }
            return listClasses;
        }

        public BooleanGrpc UpdateClass(ClassGrpc request, CallContext context = default)
        {
            Class classUpdate = classMapper.ClassGrpcToClass(request);
            return classRepository.UpdateClass(classUpdate);
        }

        public ClassGrpc GetClassById(IntGrpc id, CallContext context = default)
        {
            Class t = classRepository.GetClassById(id.Id);
            return classMapper.ClassToClassGrpc(t);
        }

        public DataPage GetDataPage(Page page, CallContext context = default)
        {
            DataPage listClasses = new DataPage();
            Class classSearch;
            if (page.ClassGrpc.TeacherId != 0 || !string.IsNullOrEmpty(page.ClassGrpc.Name) || !string.IsNullOrEmpty(page.ClassGrpc.Subject))
            {
                classSearch = classMapper.ClassGrpcToClass(page.ClassGrpc);
            }
            else
            {
                classSearch = new Class();
            } 
            var classes = classRepository.GetDataPage(page.PageNumber, page.PageSize, classSearch);
            foreach (var item in classes.ClassList)
            {
                ClassGrpc classItem = classMapper.ClassToClassGrpc(item);
                listClasses.List.Add(classItem);
            }
            listClasses.Total = classes.Total;
            return listClasses;
        }
    }
}
