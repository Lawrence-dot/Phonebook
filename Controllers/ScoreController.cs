using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Phonebook.Services.Interfaces;
using System.Linq;

namespace Phonebook.Controllers
{
    public class ScoreController : Controller
    {
        private readonly StudentDbContext scores;

        private readonly IScore _scoreService;

        public ScoreErrorViewModel scoredata = new ScoreErrorViewModel();

        public ScoreController(StudentDbContext Scores, IScore scoreService)
        {
            scores = Scores;
            _scoreService = scoreService;
        }

        public async Task<IActionResult> Index()
        {
            var allscores = await _scoreService.Query().ToListAsync();
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
            await _scoreService.Delete(id);
            return RedirectToAction("Index", "Score");
        }

        public async Task<IActionResult> AddScore(AddScoreViewModel newscore)
        {
            if (ModelState.IsValid)
            {
                await _scoreService.AddNew(newscore);
                return RedirectToAction("Index", "Score");
            }
            else
            {
                return View("~/Views/Score/Add.cshtml", newscore);
            }
        }

        public async Task<IActionResult> EditScore(Score newscore)
        {
            if (ModelState.IsValid)
            {
                await _scoreService.Update(newscore);
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


        
    }
}
