using System.Collections.Generic;
using BookstoreApi.Models;

namespace BookstoreApi.Services
{
    public interface IAuthorService
    {
        AuthorModel GetAuthor(int authorId);

        IEnumerable<AuthorModel> GetAuthors();

        void CreateAuthor(AuthorModel authorModel);

        void UpdateAuthor(int authorId, AuthorModel bookModel);

        void DeleteAuthor(int authorId);
    }
}
