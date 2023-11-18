using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using System.Diagnostics;

namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly PhoneDbContext contacts;

        public HomeController(PhoneDbContext contacts)
        {
            this.contacts = contacts;
        }

        public async Task<IActionResult> Index()
        {
            var users = await contacts.Contact.ToListAsync();
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}