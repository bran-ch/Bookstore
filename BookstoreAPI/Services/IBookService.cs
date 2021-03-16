using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookstoreAPI.Services
{
    public interface IBookService
    {
        BookModel GetBook(int bookId);

        BookModel GetBooks();

        BookModel CreateBook();

        BookModel UpdateBook();

        void DeleteBook();
    }
}
