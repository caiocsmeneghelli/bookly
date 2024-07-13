using Bookly.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);
            
            modelBuilder.Entity<User>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Loan>()
                .HasKey(l => l.Id);
            
            modelBuilder.Entity<Loan>()
                .HasOne(reg => reg.User);

            modelBuilder.Entity<Loan>()
                .HasOne(reg => reg.Book);
        }
    }
}