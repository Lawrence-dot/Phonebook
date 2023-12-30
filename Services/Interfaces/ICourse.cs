using Phonebook.Models;
using System.Linq.Expressions;

namespace Phonebook.Services.Interfaces
{
    public interface ICourse
    {
        Task<bool> AddNew(AddCourseViewModel student);
        Task<bool> Update(EditCourseViewModel student);
        IQueryable<Course> Query(Expression<Func<Course, bool>> predicate = null);
        Task<bool> Delete(Guid Id);
    }
}
