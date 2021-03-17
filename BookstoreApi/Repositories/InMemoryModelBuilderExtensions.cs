using BookstoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Repositories
{
    public static class InMemoryModelBuilderExtensions
    {
        public static void HasSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>().HasData(
                new AuthorEntity { AuthorId = 1, Name = "J.K. Rowling" },
                new AuthorEntity { AuthorId = 2, Name = "George R.R. Martin" }
            );

            modelBuilder.Entity<BookDetailEntity>().HasData(
                new BookDetailEntity
                {
                    BookDetailId = 1,
                    BookId = 1,
                    Description = @"Harry Potter has been living a difficult life, regularly abused by his cold aunt and uncle...",
                    Price = 21.99M,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/en/thumb/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg/220px-Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg"
                },
                new BookDetailEntity
                {
                    BookDetailId = 2,
                    BookId = 2,
                    Description = @"On Harry Potter's twelfth birthday, the Dursleys—Vernon, Petunia, and Dudley—hold a dinner party...",
                    Price = 15.99M,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/en/5/5c/Harry_Potter_and_the_Chamber_of_Secrets.jpg"
                },
                new BookDetailEntity
                {
                    BookDetailId = 3,
                    BookId = 3,
                    Description = @"Upon the death of Lord Jon Arryn, the principal advisor to King Robert Baratheon...",
                    Price = 18.99M,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/en/thumb/9/93/AGameOfThrones.jpg/220px-AGameOfThrones.jpg"
                },
                new BookDetailEntity
                {
                    BookDetailId = 4,
                    BookId = 4,
                    Description = @"A Clash of Kings depicts the Seven Kingdoms of Westeros in civil war, while the Night's Watch mounts...",
                    Price = 10.99M,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/en/3/39/AClashOfKings.jpg"
                }
            );

            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity { BookId = 1, AuthorId = 1, Title = "Harry Potter and the Philosopher's Stone" },
                new BookEntity { BookId = 2, AuthorId = 1, Title = "Harry Potter and the Chamber of Secrets" },
                new BookEntity { BookId = 3, AuthorId = 2, Title = "A Game of Thrones" },
                new BookEntity { BookId = 4, AuthorId = 2, Title = "A Clash of Kings" }
            );
        }
    }
}
