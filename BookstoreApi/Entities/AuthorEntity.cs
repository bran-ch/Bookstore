using System.ComponentModel.DataAnnotations;

namespace BookstoreApi.Entities
{
    public class AuthorEntity
    {
        [Key]
        public int AuthorId { get; set; }

        public string Name { get; set; }
    }
}
