using System.Collections.Generic;
using BookstoreApi.Models;

namespace BookstoreApi.Services
{
    public interface IBookService
    {
        BookModel GetBook(int bookId);

        IEnumerable<BookModel> GetBooks();

        void CreateBook(BookModel bookModel);

        void UpdateBook(int bookId, BookModel bookModel);

        void DeleteBook(int bookId);
    }
}
