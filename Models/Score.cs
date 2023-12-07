using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Score
    {
        public Guid Id { get; set; }
        public int Course_id { get; set; }
        public string Matric_number { get; set; }
        public Decimal CA_1 { get; set; }
        public Decimal CA_2 { get; set; }
        public Decimal CA_3 { get; set; }
        public Decimal Exam_score { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public int Level { get; set; }
    }
}
