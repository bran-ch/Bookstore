namespace BookstoreApi.Entities
{
    public class BookEntity
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public BookDetailEntity BookDetail { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
