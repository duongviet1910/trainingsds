namespace BlazorWebAppRGPC.Model.DTO
{
    public class DataPageItem
    {
        public int Total { get; set; }
        public List<ClassViewDTO> ClassViews { get; set; } = new List<ClassViewDTO>();
        public List<StudentViewDTO> StudentViews { get; set; } = new List<StudentViewDTO>();
    }
}
