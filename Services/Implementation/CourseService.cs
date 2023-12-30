using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Interfaces;
using System.Linq.Expressions;

namespace Phonebook.Services.Implementation
{
    public class CourseService : ICourse
    {
        private readonly StudentDbContext _student;
        public CourseService(StudentDbContext student)
        {
            _student = student;
        }
        public async Task<bool> AddNew(AddCourseViewModel course)
        {
            try
            {
                var data = new Course();
                if (course != null)
                {
                    data = new Course()
                    {
                        Id = new Guid(),
                        Code = course.Code,
                        Title = course.Title,
                    };
                    await _student.Courses.AddAsync(data);
                    await _student.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            } catch
            {
                throw;
            }

        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var data = await _student.Courses.FindAsync(Id);
                if (data != null)
                {
                    _student.Courses.Remove(data);
                    await _student.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            } catch
            {
                throw;
            }
        }

        public IQueryable<Course> Query(Expression<Func<Course, bool>> predicate)
        {
            IQueryable<Course> courses = null;
            try
            {
                if (predicate == null)
                {
                    courses = _student.Courses.AsQueryable();
                }
                else
                {
                    courses = _student.Courses.Where(predicate);
                }
            }
            catch
            {
                throw;
            }
            return courses;
        }

        public async Task<bool> Update(EditCourseViewModel course)
        {
            try
            {
                var data = await _student.Courses.FindAsync(course.Id);
                if (data != null)
                {
                    data.Title = course.Title;
                    data.Unit = course.Unit;
                    data.Code = course.Code;
                    await _student.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            } catch
            {
                throw;
            }

        }
    }
}
