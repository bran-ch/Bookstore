using System.Collections.Generic;
using BookstoreApi.Entities;

namespace BookstoreApi.Repositories
{
    public interface IAuthorContext
    {
        AuthorEntity FindAuthor(int authorId);

        IEnumerable<AuthorEntity> SearchAuthors();

        void DeleteAuthor(int authorId);

        void CreateAuthor(AuthorEntity author);

        void UpdateAuthor(int authorId, AuthorEntity author);
    }
}
