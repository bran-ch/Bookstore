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

        public void CreateBook(BookEntity book)
        {
            Books.Add(book);

            SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var found = Books.Where(b => b.BookId == bookId).FirstOrDefault();

            if (found is null)
            {
                return;
            }

            Books.Remove(found);

            SaveChanges();
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

        public void UpdateBook(int bookId, BookEntity book)
        {
            var entity = Books
                .Include(b => b.BookDetail)
                .Include(b => b.Author)
                .Where(b => b.BookId == bookId)
                .FirstOrDefault();

            if (entity is null)
            {
                return;
            }

            entity.Title = book.Title;
            entity.BookDetail.Description = book.BookDetail.Description;
            entity.BookDetail.ImagePath = book.BookDetail.ImagePath;
            entity.BookDetail.Price = book.BookDetail.Price;

            SaveChanges();
        }

        void IAuthorContext.CreateAuthor(AuthorEntity author)
        {
            Authors.Add(author);

            SaveChanges();
        }

        void IAuthorContext.DeleteAuthor(int authorId)
        {
            var found = Authors.Where(b => b.AuthorId == authorId).FirstOrDefault();
            Authors.Remove(found);

            SaveChanges();
        }

        AuthorEntity IAuthorContext.FindAuthor(int authorId)
        {
            return Authors.AsNoTracking()
                .Where(a => a.AuthorId == authorId)
                .FirstOrDefault();
        }

        IEnumerable<AuthorEntity> IAuthorContext.SearchAuthors()
        {
            return Authors
                .AsNoTracking()
                .ToList();
        }

        void IAuthorContext.UpdateAuthor(int authorId, AuthorEntity author)
        {
            var entity = Authors
                .Where(a => a.AuthorId == authorId)
                .FirstOrDefault();

            if (entity is null)
            {
                return;
            }

            entity.Name = author.Name;

            SaveChanges();
        }
    }
}
