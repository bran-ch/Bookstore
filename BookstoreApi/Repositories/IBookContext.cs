using System.Collections.Generic;
using BookstoreApi.Entities;

namespace BookstoreApi.Repositories
{
    public interface IBookContext
    {
        BookEntity FindBook(int bookId);

        IEnumerable<BookEntity> SearchBooks();

        BookEntity DeleteBook(int bookId);

        BookEntity CreateBook(BookEntity book);

        BookEntity UpdateBook(int bookId, BookEntity book);
    }
}
