using Phonebook.Models;
using System.Linq.Expressions;

namespace Phonebook.Services.Interfaces
{
    public interface IStudent
    {
        Task<bool> AddNew(AddStudentViewModel student);
        Task<bool> Update(EditStudentViewModel student);
        IQueryable<Student> Query(Expression<Func<Student, bool>> predicate = null);
        Task<bool> Delete(Guid Id);
    }
}
