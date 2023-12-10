using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using System.Linq;

namespace Phonebook.Controllers
{
    public class ScoreController : Controller
    {
        private readonly StudentDbContext scores;

        public ScoreErrorViewModel scoredata = new ScoreErrorViewModel();

        public async Task<IActionResult> Index()
        {
            var allscores = await scores.Scores.ToListAsync();
            return View(allscores);
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Console.WriteLine(id.GetType());
            var data = await scores.Scores.FindAsync(id);
            if (data != null)
            {
                return View(data);
            } else { 
                return RedirectToAction("Index", "Score"); 
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await scores.Scores.FindAsync(id);
            if (data != null)
            {
                scores.Scores.Remove(data);
                await scores.SaveChangesAsync();
                return RedirectToAction("Index", "Score");
            } else
            {
                return RedirectToAction("Index", "Score");
            }
            
            
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

        public string verifyinput(int value, string field)
        {
            if (value > 0)
            {
                return $"The {field} is required";
            }
            else
            {
                return "";
            }
        }

        public string verifyinput(Decimal value, string field)
        {
            if (value > 0)
            {
                return $"The {field} is required";
            }
            else
            {
                return "";
            }
        }

        public bool validateCA(int value)
        {
            if (value > 0 && value <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validateCA(Decimal value)
        {
            if (value > 0 && value <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validateExam(int value)
        {
            if(value > 0 && value <= 70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validateExam(Decimal value)
        {
            if (value > 0 && value <= 70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validatedata(int value)
        {
            if (value > 0 && value < 2006)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validatedata(string value)
        {
            if (value != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VerifyScoreFields(AddScoreViewModel data)
        {
            verifyinput(data.CA_1, "CA 1");
            verifyinput(data.CA_2, "CA 2");
            verifyinput(data.CA_3, "CA 3");
            verifyinput(data.Exam_score, "Exam Score");
            verifyinput(data.Matric_number, "Matric Number");
            verifyinput(data.Year, "Year");
            verifyinput(data.Level, "Level");
            verifyinput(data.Semester, "Semester");
        }

        public void VerifyScoreFields(Score data)
        {
            verifyinput(data.CA_1, "CA 1");
            verifyinput(data.CA_2, "CA 2");
            verifyinput(data.CA_3, "CA 3");
            verifyinput(data.Exam_score, "Exam Score");
            verifyinput(data.Matric_number, "Matric Number");
            verifyinput(data.Year, "Year");
            verifyinput(data.Level, "Level");
            verifyinput(data.Semester, "Semester");
        }

        public async Task<IActionResult> AddScore(AddScoreViewModel newscore)
        {
            VerifyScoreFields(newscore);
            if (validateCA(newscore.CA_1) && validateCA(newscore.CA_2) && validateCA(newscore.CA_3) && validateExam(newscore.Exam_score) && validatedata(newscore.Semester) && validatedata(newscore.Year) && validatedata(newscore.Level))
            {
                var courser = await scores.Courses.FirstOrDefaultAsync(a => a.Code == newscore.Course);
                if (courser is Course)
                {
                    var score = new Score()
                    {
                        Id = Guid.NewGuid(),
                        Course_id = courser.Id,
                        CA_1 = newscore.CA_1,
                        CA_2 = newscore.CA_2,
                        CA_3 = newscore.CA_3,
                        Exam_score = newscore.Exam_score,
                        Level = newscore.Level,
                        Matric_number = newscore.Matric_number,
                        Semester = newscore.Semester,
                        Year = newscore.Year,
                    };
                    await scores.Scores.AddAsync(score);
                    await scores.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Score");
            } else
            {
                return RedirectToAction("Error", "Score");
            }
        }

        public async Task<IActionResult> EditScore(Score newscore)
        {
            VerifyScoreFields(newscore);
            var data = await scores.Scores.FindAsync(newscore.Id);
            if (validateCA(newscore.CA_1) && validateCA(newscore.CA_2) && validateCA(newscore.CA_3) && validateExam(newscore.Exam_score) && validatedata(newscore.Semester) && validatedata(newscore.Year) && validatedata(newscore.Level))
            {
                if (data != null)
                {
                    data.Id = newscore.Id;
                    data.CA_1 = newscore.CA_1;
                    data.CA_2 = newscore.CA_2;
                    data.CA_3 = newscore.CA_3;
                    data.Exam_score = newscore.Exam_score;
                    data.Level = newscore.Level;
                    data.Matric_number = newscore.Matric_number;
                    data.Semester = newscore.Semester;
                    data.Year = newscore.Year;
                };
                await scores.SaveChangesAsync();
                return RedirectToAction("Index", "Score");
            }
            else
            {
                return RedirectToAction("Error", "Score");
            }
        }

        public IActionResult Error()
        {
            return View(scoredata);
        }


        public ScoreController(StudentDbContext Scores)
        {
            scores = Scores;
        }
    }
}
