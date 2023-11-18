using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class AddPhoneViewModel
    {
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Primary_phone { get; set; }
        [Required]
        public string Secondary_phone { get; set; }
    }
}
