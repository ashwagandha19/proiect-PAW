using app.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
              
        }
        // folosesc code first deoarece creez tabelul in baza de date pe baza modelului din cod
        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Bill>? Bills { get; set; }
        public DbSet<Member>? Members { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
    }
}
