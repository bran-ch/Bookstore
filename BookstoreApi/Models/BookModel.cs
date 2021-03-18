namespace BookstoreApi.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
