using System.Collections.Generic;
using AutoMapper;
using BookstoreApi.Entities;
using BookstoreApi.Models;
using BookstoreApi.Repositories;
using Microsoft.Extensions.Logging;

namespace BookstoreApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBookstoreContext _bookstoreContext;

        private readonly IMapper _mapper;

        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IBookstoreContext bookstoreContext, IMapper mapper, ILogger<AuthorService> logger)
        {
            _bookstoreContext = bookstoreContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreateAuthor(AuthorModel AuthorModel)
        {
            var bookEntity = _mapper.Map<BookEntity>(AuthorModel);

            _bookstoreContext.CreateAuthor(bookEntity);
        }

        public void DeleteAuthor(int bookId)
        {
            _bookstoreContext.DeleteAuthor(bookId);
        }

        public AuthorModel GetAuthor(int bookId)
        {
            var bookEntity = _bookstoreContext.FindAuthor(bookId);

            var AuthorModel = _mapper.Map<AuthorModel>(bookEntity);

            return AuthorModel;
        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            var bookEntities = _bookstoreContext.SearchAuthors();

            var AuthorModels = _mapper.Map<IEnumerable<AuthorModel>>(bookEntities);

            return AuthorModels;
        }

        public void UpdateAuthor(int bookId, AuthorModel AuthorModel)
        {
            var bookEntity = _mapper.Map<AuthorEntity>(AuthorModel);

            _bookstoreContext.UpdateAuthor(bookId, bookEntity);
        }
    }
}
