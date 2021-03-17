using System.Collections.Generic;
using System.Linq;
using BookstoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Repositories
{
    public class BookstoreContext : DbContext, IBookstoreContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<BookDetailEntity> BookDetails { get; set; }

        public DbSet<AuthorEntity> Authors { get; set; }

        public void CreateBook(BookEntity book)
        {
            Books.Add(book);

            SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var found = Books.Where(b => b.BookId == bookId).FirstOrDefault();
            Books.Remove(found);

            SaveChanges();
        }

        public BookEntity FindBook(int bookId)
        {
            return Books.AsNoTracking()
                .Where(b => b.BookId == bookId)
                .FirstOrDefault();
        }

        public IEnumerable<BookEntity> SearchBooks()
        {
            return Books.AsNoTracking().ToList();
        }

        public void UpdateBook(int bookId, BookEntity book)
        {
            Books.Update(book);

            SaveChanges();
        }
    }
}
