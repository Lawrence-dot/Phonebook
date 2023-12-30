using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Implementation;
using Phonebook.Services.Interfaces;

namespace Phonebook.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext courses;

        private readonly ICourse _courseService;

        public CourseErrorModel coursedata = new CourseErrorModel();

        public CourseController(StudentDbContext Courses, ICourse courseService)
        {
            courses = Courses;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCourses()
        {
            return View();
        }

        public async Task<IActionResult> ViewCourses()
        {
            var courseview = _courseService.Query().ToList();
            foreach (var course in courseview)
            {
                course.Unit = course.Unit.ToString();
            }

            return View(courseview);

        }

        public async Task<IActionResult> ViewCourse(Guid Id)
        {

            var course = await courses.Courses.FindAsync(Id);
            return View(course);

        }

        public async Task<IActionResult> AddNewCourses(AddCourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddNew(course);
                return RedirectToAction("ViewCourses", "Course");
            } else
            {
                return View("~/Views/Course/AddCourses.cshtml", course);
            }


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _courseService.Delete(id);    
            return RedirectToAction( "ViewCourses", "Course");
        }

        public IActionResult Error()
        {
            return View(coursedata);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await courses.Courses.FindAsync(id);
            if (data != null)
            {
                var contact = new EditCourseViewModel()
                {
                    Id = id,
                    Title = data.Title,
                    Code = data.Code,   
                    Unit = data.Unit,
                };
                return View(contact);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> EditCourse(EditCourseViewModel editcourse)
        {
           
            if (ModelState.IsValid)
            {
                await _courseService.Update(editcourse);
                return RedirectToAction("ViewCourses", "Course");
            }
            else
            {
                return View("~/Views/Student/AddStudent.cshtml", editcourse);
            }
            
        }
    }
}
