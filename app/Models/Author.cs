using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Author
    {
        public Author()
        {

        }

        [Key]
        public int author_id { get; set; }

        public string? author_name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
