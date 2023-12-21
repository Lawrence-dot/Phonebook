using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class AddScoreViewModel
    {
        [Required(ErrorMessage = "A Valid Course is Required")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Matric Number is Required")]
        public string Matric_number { get; set; }
        [Required(ErrorMessage = "CA 1 is Required")]
        public decimal CA_1 { get; set; }
        [Required(ErrorMessage = "CA 2 is Required")]
        public decimal CA_2 { get; set; }
        [Required(ErrorMessage = "CA 3 is Required")]
        public decimal CA_3 { get; set; }
        [Required(ErrorMessage = "Exam Score is Required")]
        public decimal Exam_score { get; set; }
        [Required(ErrorMessage = "Year is Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Semester is Required")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "Level is Required")]
        public int Level { get; set; }
    }
}
