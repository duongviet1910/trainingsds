using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using Share;

namespace BlazorWebAppRGPC.Service.IService
{
    public interface IStudentService
    {
        public List<StudentViewDTO> GetAllStudent();

        public BooleanGrpc AddStudent(StudentDTO studentnew);

        public BooleanGrpc UpdateStudent(StudentDTO studentUpdate);

        public BooleanGrpc DeleteStudent(StudentViewDTO studentDelete);

        public List<Student> SortData();

        public Student GetStudentById(int id);
        public int GetIDNewStudent();
        public DataPageItem GetDataPage(int pageNumber, int pageSize, StudentViewDTO studentSearch);
    }
}
