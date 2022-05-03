using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Member
    {
        public Member()
        {

        }

        [Key]
        public int member_id { get; set; }
        public string? member_name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? dob { get; set; }
        public string? country { get; set; } 
        public string? city { get; set; }    
        public string? postal_code { get; set; } 
        //public string address { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
