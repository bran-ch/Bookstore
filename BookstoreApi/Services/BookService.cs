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
        private readonly IBookContext _bookContext;

        private readonly IMapper _mapper;

        private readonly ILogger<BookService> _logger;

        public BookService(IBookContext bookContext, IMapper mapper, ILogger<BookService> logger)
        {
            _bookContext = bookContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreateBook(BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            _bookContext.CreateBook(bookEntity);
        }

        public void DeleteBook(int bookId)
        {
            _bookContext.DeleteBook(bookId);
        }

        public BookModel GetBook(int bookId)
        {
            var bookEntity = _bookContext.FindBook(bookId);

            var bookModel = _mapper.Map<BookModel>(bookEntity);

            return bookModel;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var bookEntities = _bookContext.SearchBooks();

            var bookModels = _mapper.Map<IEnumerable<BookModel>>(bookEntities);

            return bookModels;
        }

        public void UpdateBook(int bookId, BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            _bookContext.UpdateBook(bookId, bookEntity);
        }
    }
}
