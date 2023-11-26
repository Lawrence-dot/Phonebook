using System;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string Admission_number { get; set; }
        public DateTime Admission_date { get; set; }
        public string Home_address { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public int Level { get; set; }
        public string Course_of_study { get; set; }
        public string Gender { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }

    }
}
