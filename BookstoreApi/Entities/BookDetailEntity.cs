using System.ComponentModel.DataAnnotations;

namespace BookstoreApi.Entities
{
    public class BookDetailEntity
    {
        [Key]
        public int BookDetailId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
