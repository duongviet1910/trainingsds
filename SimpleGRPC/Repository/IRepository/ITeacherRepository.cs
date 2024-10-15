using SimpleGRPC.Model;

namespace SimpleGRPC.Repository.IRepository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);
    }
}
