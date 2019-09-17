using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = "Server=tcp:etcdb.database.windows.net,1433;Initial Catalog=etcdb1;Persist Security Info=False;User ID=sqladmin;Password=Pa$$w0rdPa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbSet<Book> Books { get; set; }

        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(25).IsRequired(false);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Professional C# 7", Publisher = "Wrox Press" },
                new Book { BookId = 2, Title = "Professional C# 9", Publisher = "Wrox Press" });

        }
    }
}
