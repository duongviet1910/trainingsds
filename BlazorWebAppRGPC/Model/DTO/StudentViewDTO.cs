namespace BlazorWebAppRGPC.Model.DTO
{
    public class StudentViewDTO
    {
        public int STT { get; set; }
        public int Id { get; set; }

        public String Name { get; set; }

        public DateTime Dob { get; set; }

        public String Address { get; set; }

        public ClassViewDTO ClassStudent { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        
    }
}
