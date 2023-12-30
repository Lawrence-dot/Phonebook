using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Interfaces;

namespace Phonebook.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentDbContext students;

        private readonly IStudent _studentService;

        public StudentErrorViewModel studentdata = new StudentErrorViewModel();

        public StudentController(StudentDbContext Students, IStudent studentService)
        {
            students = Students;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
           // var stud = await students.Students.ToListAsync();
           var students = _studentService.Query();
            return View(students.ToList());
        }

        public async Task<IActionResult> Add(AddStudentViewModel student)
        {
           
            if (ModelState.IsValid)
            {
                var addNew = await _studentService.AddNew(student);
                if (addNew)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            return View("~/Views/Student/AddStudent.cshtml", student);
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
            await _studentService.Delete(id);
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
            if (ModelState.IsValid)
            {   
                await _studentService.Update(student);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View("~/Views/Student/Edit.cshtml", student);
            }
        }

    }
}
