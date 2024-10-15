using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppRGPC.Model.DTO
{
    public class TeacherDTO
    {
        public TeacherDTO()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The field must not empty !!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must not empty !!!")]

        public DateTime Dob { get; set; }
    }

}
