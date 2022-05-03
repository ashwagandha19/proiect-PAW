using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Category
    {
        public Category()
        {

        }

        [Key]
        public int category_id { get; set; }

        [DisplayName("Category Name")]
        public string? category_name { get; set; }

        //public ICollection<Book> Books { get; set; }   
    }
}
