using System.Collections.Generic;
using BookstoreApi.Models;

namespace BookstoreApi.Services
{
    public interface IAuthorService
    {
        AuthorModel GetAuthor(int authorId);

        IEnumerable<AuthorModel> GetAuthors();

        AuthorModel CreateAuthor(AuthorModel authorModel);

        AuthorModel UpdateAuthor(int authorId, AuthorModel bookModel);

        AuthorModel DeleteAuthor(int authorId);
    }
}
