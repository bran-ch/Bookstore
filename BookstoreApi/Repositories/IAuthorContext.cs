using System.Collections.Generic;
using BookstoreApi.Entities;

namespace BookstoreApi.Repositories
{
    public interface IAuthorContext
    {
        AuthorEntity FindAuthor(int authorId);

        IEnumerable<AuthorEntity> SearchAuthors();

        AuthorEntity DeleteAuthor(int authorId);

        AuthorEntity CreateAuthor(AuthorEntity author);

        AuthorEntity UpdateAuthor(int authorId, AuthorEntity author);
    }
}
