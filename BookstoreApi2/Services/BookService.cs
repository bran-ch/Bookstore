using System.Collections.Generic;
using AutoMapper;
using BookstoreApi.Entities;
using BookstoreApi.Models;
using BookstoreApi.Repositories;
using Microsoft.Extensions.Logging;

namespace BookstoreApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookstoreContext _bookstoreContext;

        private readonly IMapper _mapper;

        private readonly ILogger<BookService> _logger;

        public BookService(IBookstoreContext bookstoreContext, IMapper mapper, ILogger<BookService> logger)
        {
            _bookstoreContext = bookstoreContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreateBook(BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            _bookstoreContext.CreateBook(bookEntity);
        }

        public void DeleteBook(int bookId)
        {
            _bookstoreContext.DeleteBook(bookId);
        }

        public BookModel GetBook(int bookId)
        {
            var bookEntity = _bookstoreContext.FindBook(bookId);

            var bookModel = _mapper.Map<BookModel>(bookEntity);

            return bookModel;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var bookEntities = _bookstoreContext.SearchBooks();

            var bookModels = _mapper.Map<IEnumerable<BookModel>>(bookEntities);

            return bookModels;
        }

        public void UpdateBook(int bookId, BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            _bookstoreContext.UpdateBook(bookId, bookEntity);
        }
    }
}
