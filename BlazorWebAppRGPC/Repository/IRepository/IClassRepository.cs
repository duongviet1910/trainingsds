using BlazorWebAppRGPC.Model;

namespace BlazorWebAppRGPC.Repository.IRepository
{
    public interface IClassRepository
    {
        public List<Class> GetAllClasses();

        public Class GetClassById(int id);
    }
}
