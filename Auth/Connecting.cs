using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class Account
    {
        [Key]
        public int account_id { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
    }

    internal class Connecting : DbContext
    {
        public DbSet<Account> accounts { get; set; } = null!;

        public Connecting()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" +
                "Database=test_auth;Username=postgres;Password=123321");
        }
    }
}
