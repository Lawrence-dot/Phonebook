using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext courses;

        public CourseErrorModel coursedata = new CourseErrorModel();

        public CourseController(StudentDbContext Courses)
        {
            courses = Courses;
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
            var courseview = await courses.Courses.ToListAsync();
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
                var data = new Course()
                {
                    Id = new Guid(),
                    Title = course.Title,
                    Code = course.Code,
                    Unit = course.Unit,
                };
                await courses.Courses.AddAsync(data);
                await courses.SaveChangesAsync();
                return RedirectToAction("ViewCourses", "Course");
            } else
            {
                return View("~/Views/Course/AddCourses.cshtml", course);
            }


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await courses.Courses.FindAsync(id);
            if (data != null)
            {
                courses.Courses.Remove(data);
                await courses.SaveChangesAsync();
            }
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
                var data = await courses.Courses.FindAsync(editcourse.Id);
                if (data != null)
                {
                    data.Title = editcourse.Title;
                    data.Code = editcourse.Code;
                    data.Unit = editcourse.Unit;
                    await courses.SaveChangesAsync();
                }
                return RedirectToAction("ViewCourses", "Course");
            }
            else
            {
                return View("~/Views/Student/AddStudent.cshtml", editcourse);
            }
            
        }
    }
}
