using Microsoft.EntityFrameworkCore;
using CosmosWithEFCore.Models;

namespace CosmosWithEFCore.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
    }
}
