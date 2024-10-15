using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using Share;

namespace BlazorWebAppRGPC.Service.IService
{
    public interface IClassService
    {
        public List<ClassViewDTO> GetAllClasss();

        public BooleanGrpc AddNewClass(ClassDTO classNew);

        public BooleanGrpc UpdateClass(ClassDTO classUpdate);

        public BooleanGrpc DeleteClass(ClassViewDTO classDelete);

        public List<Class> SortData();

        public Class GetClassById(int id);
        public int GetIDNewClass();
        public DataPageItem GetDataPage(int pageNumber, int pageSize, ClassViewDTO classSearch);
    }
}
