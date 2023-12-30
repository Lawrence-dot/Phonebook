using Phonebook.Models;
using System.Linq.Expressions;

namespace Phonebook.Services.Interfaces
{
    public interface IScore
    {
        Task<bool> AddNew(AddScoreViewModel student);
        Task<bool> Update(Score student);
        IQueryable<Score> Query(Expression<Func<Score, bool>> predicate = null);
        Task<bool> Delete(Guid Id);
    }
}
