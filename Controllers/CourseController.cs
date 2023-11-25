using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext courses;

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
            var courselist = await courses.Courses.ToListAsync();
            return View(courselist);

        }

        public async Task<IActionResult> ViewCourse(Guid Id)
        {

            var course = await courses.Courses.FindAsync(Id);
            return View(course);

        }

        public async Task<IActionResult> AddNewCourses(AddCourseViewModel student)
        {

            var data = new Course()
            {
                Id = new Guid(),
                Title = student.Title,
                Code = student.Code,
                Unit = student.Unit,
            };
            await courses.Courses.AddAsync(data);
            await courses.SaveChangesAsync();
            return RedirectToAction("Course", "ViewCourses");

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await courses.Courses.FindAsync(id);
            if (data != null)
            {
                courses.Courses.Remove(data);
                await courses.SaveChangesAsync();
            }
            return RedirectToAction("Course", "ViewCourses");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await courses.Courses.FindAsync(id);
            if (data != null)
            {
                var contact = new Course()
                {
                    Id = data.Id,
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

        public async Task<IActionResult> EditCourse(Course editcourse)
        {
            var data = await courses.Courses.FindAsync(editcourse.Id);
            if (data != null)
            {
                data.Title = editcourse.Title;  
                data.Code = editcourse.Code;
                data.Unit = editcourse.Unit;
                await courses.SaveChangesAsync();
                return RedirectToAction("Course", "ViewCourses");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }



    }
}
