using Phonebook.Models;

namespace Phonebook.Validations
{
    public static class StudentValidator
    {
        public static List<string> AddStudent(AddStudentViewModel Student) 
        { 
            List<string> errors = new List<string>();   
            if (Student == null) throw new ArgumentNullException($"Invalid Student Object {nameof(Student)}");
            if (!verifystring(Student.Department))
            {
                errors.Add("Invalid Student Department");
            }
            return errors;
        }

        public static bool verifystring(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
