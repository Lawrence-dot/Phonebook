using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using System.Diagnostics;

namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext student;

        public HomeController(StudentDbContext student)
        {
            this.student = student;
        }

        public async Task<IActionResult> Index()
        {
            var students = await student.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}