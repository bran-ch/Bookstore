using System.Collections.Generic;
using BookstoreApi.Entities;

namespace BookstoreApi.Repositories
{
    public interface IBookContext
    {
        BookEntity FindBook(int bookId);

        IEnumerable<BookEntity> SearchBooks();

        void DeleteBook(int bookId);

        void CreateBook(BookEntity book);

        void UpdateBook(int bookId, BookEntity book);
    }
}
