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

        public string verifyinput(string value, string field)
        {
            if (value != null)
            {
                return $"The {field} is required";
            }
            else
            {
                return "";
            }
        }

        public void VerifyCourseFields(AddCourseViewModel data)
        {
            verifyinput(data.Code, "Code");
            verifyinput(data.Unit, "Unit");
            verifyinput(data.Title, "Title");
        }

        public void VerifyCourseFields(EditCourseViewModel data)
        {
            verifyinput(data.Code, "Code");
            verifyinput(data.Unit, "Unit");
            verifyinput(data.Title, "Title");
        }

        public bool validatedata(string value)
        {
            if (value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public async Task<IActionResult> AddNewCourses(AddCourseViewModel student)
        {
            VerifyCourseFields(student);
            if (validatedata(student.Code) && validatedata(student.Title) && validatedata(student.Unit))
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
                return RedirectToAction("ViewCourses", "Course");
            } else
            {
                return RedirectToAction("Error", "Course");
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
            VerifyCourseFields(editcourse);
            if (validatedata(editcourse.Code) && validatedata(editcourse.Title) && validatedata(editcourse.Unit))
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
                return RedirectToAction("Error", "Coursee");
            }
        }



    }
}
