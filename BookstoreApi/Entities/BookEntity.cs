using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApi.Entities
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(BookDetail))]
        public int BookDetailId { get; set; }

        public string Title { get; set; }

        public BookDetailEntity BookDetail { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
