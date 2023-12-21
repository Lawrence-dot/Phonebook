using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentDbContext students;

        public StudentErrorViewModel studentdata = new StudentErrorViewModel();

        public StudentController(StudentDbContext Students)
        {
            students = Students;
        }

        public async Task<IActionResult> Index()
        {
            var stud = await students.Students.ToListAsync();
            return View(stud);
        }

        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
            if (ModelState.IsValid)
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
                    Admission_date = (DateTime)student.Admission_date,
                    Admission_number = student.Admission_number,
                    Date_of_birth = (DateTime)student.Date_of_birth,
                    Department = student.Department,
                    Faculty = student.Faculty,
                    Home_address = student.Home_address,
                    Phone_number = student.Phone_number
                };
                await students.Students.AddAsync(data);
                await students.SaveChangesAsync();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View("~/Views/Student/AddStudent.cshtml", student);
            }

            
        }

        public IActionResult Error()
        {
            return View(studentdata);
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
            return RedirectToAction("Index", "Student");
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
            var defu = ModelState;
            if (ModelState.IsValid)
            {
                
                var data = await students.Students.FindAsync(student.Id);
                if (data != null)
                {
                    data.First_name = student.First_name;
                    data.Last_name = student.Last_name;
                    data.Middle_name = student.Middle_name;
                    data.Course_of_study = student.Course_of_study;
                    data.Email = student.Email;
                    data.Level = student.Level;
                    data.Gender = student.Gender;
                    data.Date_of_birth = (DateTime)student.Date_of_birth;
                    data.Admission_number = student.Admission_number;
                    data.Department = student.Department;
                    data.Faculty = student.Faculty;
                    data.Admission_date = (DateTime)student.Admission_date;
                    data.Home_address = student.Home_address;
                    data.Phone_number = student.Phone_number;
                    await students.SaveChangesAsync();   
                }
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View("~/Views/Student/Edit.cshtml", student);
            }
        }

    }
}
