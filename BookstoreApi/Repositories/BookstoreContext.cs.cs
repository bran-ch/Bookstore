using BookstoreApi.Entities;
using BookstoreApi.Models;
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

        public BookEntity CreateBook(BookModel book)
        {
            throw new System.NotImplementedException();
        }

        public BookEntity DeleteBook(int bookId)
        {
            throw new System.NotImplementedException();
        }

        public BookEntity FindBook(int bookId)
        {
            throw new System.NotImplementedException();
        }

        public BookEntity SearchBooks()
        {
            throw new System.NotImplementedException();
        }

        public BookEntity UpdateBook(int bookId, BookModel book)
        {
            throw new System.NotImplementedException();
        }
    }
}
