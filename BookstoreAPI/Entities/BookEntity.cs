namespace BookstoreAPI.Entities
{
    public class BookEntity
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public BookDetailEntity BookDetails { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
