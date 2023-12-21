using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string First_name { get; set; }
        [Required(ErrorMessage = "Middle Name is Required")]
        public string Middle_name { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_name { get; set; }
        [Required(ErrorMessage = "Date of Birth Field is required")]
        public DateTime? Date_of_birth { get; set; }
        [Required(ErrorMessage = "Admission Number is Required")]
        public string Admission_number { get; set; }
        [Required(ErrorMessage = "Admission Date is Required")]
        public DateTime? Admission_date { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Home_address { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Faculty is Required")]
        public string Faculty { get; set; }
        [Required(ErrorMessage = "This Level is Required")]
        public int Level { get; set; }
        [Required(ErrorMessage = "This Course is Required")]
        public string Course_of_study { get; set; }
        [Required(ErrorMessage = "This Gender Field is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This Phone Number Field is Required")]
        [Phone(ErrorMessage = "Please Enter a valid Phone number")]
        public string Phone_number { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address")]
        [Required(ErrorMessage = "This Email is Required")]
        public string Email { get; set; }
    }
}
