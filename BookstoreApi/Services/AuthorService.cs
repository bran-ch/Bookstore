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
        private readonly IAuthorContext _authorContext;

        private readonly IMapper _mapper;

        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IAuthorContext authorContext, IMapper mapper, ILogger<AuthorService> logger)
        {
            _authorContext = authorContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void CreateAuthor(AuthorModel AuthorModel)
        {
            var authorEntity = _mapper.Map<AuthorEntity>(AuthorModel);

            _authorContext.CreateAuthor(authorEntity);
        }

        public void DeleteAuthor(int authorId)
        {
            _authorContext.DeleteAuthor(authorId);
        }

        public AuthorModel GetAuthor(int authorId)
        {
            var authorEntity = _authorContext.FindAuthor(authorId);

            var AuthorModel = _mapper.Map<AuthorModel>(authorEntity);

            return AuthorModel;
        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            var authorEntities = _authorContext.SearchAuthors();

            var AuthorModels = _mapper.Map<IEnumerable<AuthorModel>>(authorEntities);

            return AuthorModels;
        }

        public void UpdateAuthor(int bookId, AuthorModel authorModel)
        {
            var authorEntity = _mapper.Map<AuthorEntity>(authorModel);

            _authorContext.UpdateAuthor(bookId, authorEntity);
        }
    }
}
