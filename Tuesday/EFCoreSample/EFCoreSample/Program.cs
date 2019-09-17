using System;

namespace EFCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BooksContext();
            bool created = context.Database.EnsureCreated();
            Console.WriteLine($"database created: {created}");
        }
    }
}
