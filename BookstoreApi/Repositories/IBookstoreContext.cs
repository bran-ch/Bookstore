using System.Collections.Generic;
using BookstoreApi.Entities;
using BookstoreApi.Models;

namespace BookstoreApi.Repositories
{
    public interface IBookstoreContext
    {
        BookEntity FindBook(int bookId);

        IEnumerable<BookEntity> SearchBooks();

        void DeleteBook(int bookId);

        void CreateBook(BookEntity book);

        void UpdateBook(int bookId, BookEntity book);
    }
}
