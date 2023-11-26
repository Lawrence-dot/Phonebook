using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class StudentController : Controller
    {
        public string errorMessage = "";

        private readonly StudentDbContext students;

        public StudentController(StudentDbContext Students)
        {
            students = Students;
        }

        public bool verifystring(string value)
        {
            if (value.Length > 0 && value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Verifymail(string mail)
        {
            if (mail.Length > 0 && mail != null && mail.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verifyDob (DateTime date) {
            if (date < new DateTime(2006, 12, 25) && date <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verifyadmdate(DateTime date)
        {
            if (date <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool verifyphone(string value)
        {
            if (value.StartsWith("0") && value.Length == 11)
            {
                return true;
            }
            else if (value.StartsWith("+234") && value.Length == 14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
            if (verifystring(student.First_name) && verifyDob(student.Date_of_birth) && verifyadmdate(student.Admission_date) && verifystring(student.Middle_name) && verifystring(student.Last_name) && verifyphone(student.Phone_number) && verifystring(student.Admission_number) && verifystring(student.Home_address) && verifystring(student.Department) && verifystring(student.Faculty) && verifystring(student.Level.ToString()) && verifystring(student.Gender) && Verifymail(student.Email) && verifystring(student.Course_of_study))
                {
                    var data = new Student()
                {
                    Id = new Guid(),
                    First_name = student.First_name,
                    Last_name = student.Last_name,
                    Middle_name = student.Middle_name,
                    Course_of_study = student.Course_of_study,
                    Email = student.Email,
                    Level = student.Level,
                    Gender = student.Gender,
                    Admission_date = student.Admission_date,
                    Admission_number = student.Admission_number,
                    Date_of_birth = student.Date_of_birth,
                    Department = student.Department,
                    Faculty = student.Faculty,
                    Home_address = student.Home_address,
                    Phone_number = student.Phone_number
                };
                await students.Students.AddAsync(data);
                await students.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return new EmptyResult();
            }
        }

        public async Task<IActionResult> ViewStudent(Guid id)
        {
            var data = await students.Students.FindAsync(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return new EmptyResult();
            }

        }

        public IActionResult AddStudent()
        {
                return View();

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await students.Students.FindAsync(id);
            if (data != null)
            {
                students.Students.Remove(data);
                await students.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await students.Students.FindAsync(id);
            if (data != null)
            {
                var contact = new EditStudentViewModel()
                {
                    Id = data.Id,
                    First_name = data.First_name,
                    Last_name = data.Last_name,
                    Middle_name = data.Middle_name,
                    Course_of_study = data.Course_of_study,
                    Email = data.Email,
                    Level = data.Level,
                    Gender = data.Gender,
                    Admission_date = data.Admission_date,
                    Admission_number = data.Admission_number,
                    Date_of_birth = data.Date_of_birth,
                    Department = data.Department,
                    Faculty = data.Faculty,
                    Home_address = data.Home_address,
                    Phone_number = data.Phone_number
                };
                return View(contact);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> EditStudent(EditStudentViewModel student)
        {
            Console.WriteLine(student.Date_of_birth);
            if (verifystring(student.First_name))
            {
                var data = await students.Students.FindAsync(student.Id);
                Console.WriteLine(student.Id);
                if (data != null)
                {
                    data.First_name = student.First_name;
                    data.Last_name = student.Last_name;
                    data.Middle_name = student.Middle_name;
                    data.Course_of_study = student.Course_of_study;
                    data.Email = student.Email;
                    data.Level = student.Level;
                    data.Gender = student.Gender;
                    data.Date_of_birth = student.Date_of_birth;
                    data.Admission_number = student.Admission_number;
                    data.Department = student.Department;
                    data.Faculty = student.Faculty;
                    data.Admission_date = student.Admission_date;
                    data.Home_address = student.Home_address;
                    data.Phone_number = student.Phone_number;
                    Console.WriteLine("db");
                    await students.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return new EmptyResult();
            }
        }

    }
}
