using BlazorWebAppRGPC.Model;

namespace BlazorWebAppRGPC.Service.IService
{
    public interface ITeacherService
    {
        public List<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);

    }
}
