using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Publisher
    {
        public Publisher()
        {

        }

        [Key]
        public int publisher_id { get; set; }

        public string? publisher_name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
