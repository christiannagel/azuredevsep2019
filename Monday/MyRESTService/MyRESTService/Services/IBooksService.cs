using System.Collections.Generic;
using MyRESTService.Models;

namespace MyRESTService.Services
{
    public interface IBooksService
    {
        Book AddBook(Book book);
        Book GetBookById(int id);
        IEnumerable<Book> GetBooks();
    }
}