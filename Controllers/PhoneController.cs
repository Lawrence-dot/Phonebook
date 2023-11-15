using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using System.Security.Cryptography;

namespace Phonebook.Controllers
{
    
    public class PhoneController : Controller
    {
        public string successMessage;

        private readonly PhoneDbContext contacts;

        public PhoneController(PhoneDbContext contacts)
        {
            this.contacts = contacts;
        }

        public async Task<IActionResult> Index()
        {
            var data = await contacts.Contact.ToListAsync();
            return View(data);
        }

        public IActionResult AddPhone()
        {
            return View();
        }



        public async Task<IActionResult> AddContact(AddPhoneViewModel newuser)
        {
            var data = new Contact()
            {
                Id = new Guid(),
                First_name = newuser.First_name,
                Last_name = newuser.Last_name,
                Primary_phone = newuser.Primary_phone,
                Secondary_phone = newuser.Secondary_phone
            };
            await contacts.AddAsync(data);
            await contacts.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ViewPhone(Guid id)
        {
            var data = await contacts.Contact.FindAsync(id);
            return View(data);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await contacts.Contact.FindAsync(id);
            if (data != null)
            {
                contacts.Contact.Remove(data);
                await contacts.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await contacts.Contact.FindAsync(id);
            if (data != null)
            {
                var contact = new EditPhoneViewModel()
                {
                    Id = data.Id,
                    First_name = data.First_name,
                    Last_name = data.Last_name,
                    Primary_phone = data.Primary_phone,
                    Secondary_phone = data.Secondary_phone
                };
                return View(contact);
            } else
            {
                return View();
            }
            
        }

        public async Task<IActionResult> EditPhone(EditPhoneViewModel newphone)
        {
            Console.WriteLine(newphone.Id);
            var ide = Request.Form["id"];
            var data = await contacts.Contact.FindAsync(newphone.Id);

        /*    Console.WriteLine(ide);*/

            if (data != null)
            {
                data.Primary_phone = newphone.Primary_phone;
                data.Secondary_phone = newphone.Secondary_phone;
                data.Last_name = newphone.Last_name;
                data.First_name = newphone.First_name;
                Console.WriteLine(data.First_name);
                await contacts.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
