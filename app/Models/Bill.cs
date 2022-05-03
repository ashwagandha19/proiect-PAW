using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Bill
    {
        public Bill()
        {

        }

        [Key]
        public int bill_id { get; set; }

        public string? issue_date { get; set; }
        public string? due_date { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
