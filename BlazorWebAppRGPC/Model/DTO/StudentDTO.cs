using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppRGPC.Model.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must not empty !!!")]
        [MinLength(8, ErrorMessage = "The field must have a minimum length of 8 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must not empty !!!")]
        public DateTime Dob { get; set; }

        //[MinLength(8, ErrorMessage = "The field must have a minimum length of 8 characters")]
        [Required(ErrorMessage = "The field must not empty !!!")]
        public string Address { get; set; }


        [RegularExpression("^(?!0$)\\d+$", ErrorMessage = "Please choose class")]
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        /*public StudentDTO()
        {
        }
        */
    }
}
