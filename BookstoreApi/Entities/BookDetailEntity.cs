using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApi.Entities
{
    public class BookDetailEntity
    {
        [Key]
        public int BookDetailId { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public BookEntity Book { get; set; }
    }
}
