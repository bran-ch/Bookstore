using System.Collections.Generic;
using System.Linq;
using BookstoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Repositories
{
    public class BookstoreContext :
        BaseContext,
        IBookContext,
        IAuthorContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSeedData();
        }

        public BookEntity CreateBook(BookEntity book)
        {
            Books.Add(book);

            SaveChanges();

            return book;
        }

        public BookEntity DeleteBook(int bookId)
        {
            var found = Books.Where(b => b.BookId == bookId).FirstOrDefault();

            if (found is null)
            {
                return null;
            }

            Books.Remove(found);

            SaveChanges();

            return found;
        }

        public BookEntity FindBook(int bookId)
        {
            return Books
                .Include(b => b.BookDetail)
                .Include(b => b.Author)
                .AsNoTracking()
                .Where(b => b.BookId == bookId)
                .FirstOrDefault();
        }

        public IEnumerable<BookEntity> SearchBooks()
        {
            return Books
                .Include(b => b.BookDetail)
                .Include(b => b.Author)
                .AsNoTracking()
                .ToList();
        }

        public BookEntity UpdateBook(int bookId, BookEntity book)
        {
            var entity = Books
                .Include(b => b.BookDetail)
                .Include(b => b.Author)
                .Where(b => b.BookId == bookId)
                .FirstOrDefault();

            if (entity is null)
            {
                return null;
            }

            entity.Title = book.Title;
            entity.BookDetail.Description = book.BookDetail.Description;
            entity.BookDetail.ImagePath = book.BookDetail.ImagePath;
            entity.BookDetail.Price = book.BookDetail.Price;

            SaveChanges();

            return entity;
        }

        public AuthorEntity CreateAuthor(AuthorEntity author)
        {
            Authors.Add(author);

            SaveChanges();

            return author;
        }

        public AuthorEntity DeleteAuthor(int authorId)
        {
            var found = Authors.Where(b => b.AuthorId == authorId).FirstOrDefault();

            if (found is null)
            {
                return null;
            }

            Authors.Remove(found);

            SaveChanges();

            return found;
        }

        public AuthorEntity FindAuthor(int authorId)
        {
            return Authors.AsNoTracking()
                .Where(a => a.AuthorId == authorId)
                .FirstOrDefault();
        }

        public IEnumerable<AuthorEntity> SearchAuthors()
        {
            return Authors
                .AsNoTracking()
                .ToList();
        }

        public AuthorEntity UpdateAuthor(int authorId, AuthorEntity author)
        {
            var entity = Authors
                .Where(a => a.AuthorId == authorId)
                .FirstOrDefault();

            if (entity is null)
            {
                return null;
            }

            entity.Name = author.Name;

            SaveChanges();

            return entity;
        }
    }
}
