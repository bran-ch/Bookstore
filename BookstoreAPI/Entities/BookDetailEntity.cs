namespace BookstoreAPI.Entities
{
    public class BookDetailEntity
    {
        public int BookDetailId { get; set; }

        public int BookId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
