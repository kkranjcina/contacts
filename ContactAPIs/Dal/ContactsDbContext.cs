using ContactAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAPIs.Dal
{
    public class ContactsDbContext : DbContext
    {
        private string _connectionString;

        public ContactsDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContactsDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString).LogTo(Console.WriteLine).EnableDetailedErrors();
            }
        }

        public virtual DbSet<Contact> Contact { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(c => c.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Contact>()
                .Property(c => c.Name)
                .HasMaxLength(50);
        }
    }
}
