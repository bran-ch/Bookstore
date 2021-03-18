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

        public BookModel CreateBook(BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            var created = _bookContext.CreateBook(bookEntity);

            return _mapper.Map<BookModel>(created);
        }

        public BookModel DeleteBook(int bookId)
        {
            var deleted = _bookContext.DeleteBook(bookId);

            return _mapper.Map<BookModel>(deleted);
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

        public BookModel UpdateBook(int bookId, BookModel bookModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(bookModel);

            var updated = _bookContext.UpdateBook(bookId, bookEntity);

            return _mapper.Map<BookModel>(updated);
        }
    }
}
