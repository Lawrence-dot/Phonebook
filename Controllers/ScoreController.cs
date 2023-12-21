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

        public async Task<IActionResult> Add()
        {
            var courses = await scores.Courses.ToListAsync();
            ViewBag.coursedata = courses;  
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
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

        public async Task<IActionResult> AddScore(AddScoreViewModel newscore)
        {
            var courser = await scores.Courses.FirstOrDefaultAsync(a => a.Code == newscore.Course);
            if (ModelState.IsValid && courser is Course)
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
                return RedirectToAction("Index", "Score");
            }
            else
            {
                return View("~/Views/Score/Add.cshtml", newscore);
            }
        }

        public async Task<IActionResult> EditScore(Score newscore)
        {
            var data = await scores.Scores.FindAsync(newscore.Id);
            if (ModelState.IsValid)
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
                return View("~/Views/Score/Edit.cshtml", newscore);
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
