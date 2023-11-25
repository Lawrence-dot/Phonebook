using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Score
    {
        public Guid Id { get; set; }
        [Key]
        public int Course_id { get; set; }
        public string Matric_number { get; set; }
        public int CA_1 { get; set; }
        public int CA_2 { get; set; }
        public int CA_3 { get; set; }
        public int Exam_score { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public int Level { get; set; }
    }
}
