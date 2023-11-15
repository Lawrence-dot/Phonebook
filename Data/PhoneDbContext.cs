using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook.Data
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
