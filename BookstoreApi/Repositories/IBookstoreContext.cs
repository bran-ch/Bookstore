using System.Collections.Generic;
using BookstoreApi.Entities;
using BookstoreApi.Models;

namespace BookstoreApi.Repositories
{
    public interface IBookstoreContext
    {
        BookEntity FindBook(int bookId);

        IEnumerable<BookEntity> SearchBooks();

        BookEntity DeleteBook(int bookId);

        BookEntity CreateBook(BookModel book);

        BookEntity UpdateBook(int bookId, BookModel book);
    }
}
