using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Interfaces;
using System.Linq.Expressions;
using static System.Formats.Asn1.AsnWriter;

namespace Phonebook.Services.Implementation
{
    public class ScoreService : IScore
    {
        private readonly StudentDbContext _score;
        public ScoreService(StudentDbContext score)
        {
            _score = score;
        }
        public async Task<bool> AddNew(AddScoreViewModel score)
        {
            try
            {
                var data = new Score();
                var courser = await _score.Courses.FirstOrDefaultAsync(a => a.Code == score.Course);
                if (score != null)
                {
                    data = new Score()
                    {
                        Id = new Guid(),
                        CA_1 = score.CA_1,
                        CA_2 = score.CA_2,  
                        CA_3 = score.CA_3,
                        Course_id = courser.Id,
                        Exam_score = score.Exam_score,
                        Level = score.Level,
                        Matric_number = score.Matric_number,
                        Semester = score.Semester,
                        Year = score.Year
                    };
                    await _score.Scores.AddAsync(data);
                    await _score.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var data = await _score.Scores.FindAsync(Id);
                if (data != null)
                {
                    _score.Scores.Remove(data);
                    await _score.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Score> Query(Expression<Func<Score, bool>> predicate)
        {
            IQueryable<Score> scores = null;
            try
            {
                if (predicate == null)
                {
                    scores = _score.Scores.AsQueryable();
                }
                else
                {
                    scores = _score.Scores.Where(predicate);
                }
            }
            catch
            {
                throw;
            }
            return scores;
        }

        public async Task<bool> Update(Score score)
        {
            try
            {
                var data = await _score.Scores.FindAsync(score.Id);
                if (data != null)
                {
                    data.CA_3 = score.CA_3;
                    data.CA_2 = score.CA_2;
                    data.CA_1 = score.CA_1;
                    data.Semester = score.Semester;
                    data.Level = score.Level;
                    data.Year = score.Year;
                    data.Course_id = score.Course_id;
                    data.Exam_score = score.Exam_score;
                    data.Matric_number = score.Matric_number;
                    await _score.SaveChangesAsync();
                }
                return (data != null) ? true : false;
            }
            catch
            {
                throw;
            }

        }
    }
}
