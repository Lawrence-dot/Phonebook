using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class PhoneController : Controller
    {
        public string errorMessage = "";

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

        public bool verifystring (string value) {
            if (value.Length > 0 && value != null)
            {
                return true;
            } else {
                return false;
            }
        }

        public bool verifyphone (string value) {
            if(value.StartsWith("0") && value.Length == 11) {
                return true;
            } else if(value.StartsWith("+234") && value.Length == 14) {
                return true;
            } 
             else {
                return false;
            }
        }

        public async Task<IActionResult> AddContact(AddPhoneViewModel newuser)
        {
            if (verifystring(newuser.First_name) && verifystring(newuser.Last_name) && verifyphone(newuser.Primary_phone) && verifyphone(newuser.Secondary_phone))
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
            } else {
                return new EmptyResult();
            }
        }

        public async Task<IActionResult> ViewPhone(Guid id)
        {
            var data = await contacts.Contact.FindAsync(id);
            if (data != null)
            {
                return View(data);
            } else
            {
                return new EmptyResult();
            }
            
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
                return RedirectToAction("Index", "Home");
            }
            
        }

        public async Task<IActionResult> EditPhone(EditPhoneViewModel newphone)
        {
            if (verifystring(newphone.First_name) && verifystring(newphone.Last_name) && verifyphone(newphone.Primary_phone) && verifyphone(newphone.Secondary_phone))
            {
            var data = await contacts.Contact.FindAsync(newphone.Id);

            if (data != null)
            {
                data.Primary_phone = newphone.Primary_phone;
                data.Secondary_phone = newphone.Secondary_phone;
                data.Last_name = newphone.Last_name;
                data.First_name = newphone.First_name;
                await contacts.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
            } else {
                return new EmptyResult();
            }
        }
    }
}
