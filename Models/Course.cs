using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Unit is Required")]
        public string Unit { get; set; }
    }
}
