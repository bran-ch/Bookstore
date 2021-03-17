using BookstoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Repositories
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        protected DbSet<BookEntity> Books { get; set; }

        protected DbSet<BookDetailEntity> BookDetails { get; set; }

        protected DbSet<AuthorEntity> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
