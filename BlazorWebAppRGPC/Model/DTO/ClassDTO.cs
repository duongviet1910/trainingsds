using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppRGPC.Model.DTO
{
    public class ClassDTO
    {
        public ClassDTO()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The field must not empty !!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must not empty !!!")]
        public string SubjectName { get; set; }
        [RegularExpression("^(?!0$)\\d+$", ErrorMessage = "Please choose class")]

        public int TeacherId { get; set; }
        public string TeacherName { get; set;}

    }
}
