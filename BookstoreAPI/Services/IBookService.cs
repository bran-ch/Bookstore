using System.Collections.Generic;
using BookstoreApi.Models;

namespace BookstoreApi.Services
{
    public interface IBookService
    {
        BookModel GetBook(int bookId);

        IEnumerable<BookModel> GetBooks();

        BookModel CreateBook();

        BookModel UpdateBook();

        void DeleteBook();
    }
}
