using Microsoft.EntityFrameworkCore;

namespace WebApiEntityFramework.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; protected set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

        }
    }
}
