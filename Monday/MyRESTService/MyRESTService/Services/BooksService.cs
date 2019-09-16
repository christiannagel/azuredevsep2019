using MyRESTService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRESTService.Services
{
    public class BooksService : IBooksService
    {
        private List<Book> _books = new List<Book>();

        public BooksService()
        {
            _books.Add(
                new Book { BookId = 1, Title = "Professional C# 7", Publisher = "Wrox Press" });
            _books.Add(
                new Book { BookId = 2, Title = "Professional C# 8", Publisher = "Wrox Press" });
        }

        public IEnumerable<Book> GetBooks() => _books;

        public Book GetBookById(int id)
        {
            return _books.SingleOrDefault(b => b.BookId == id);
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }
    }
}
