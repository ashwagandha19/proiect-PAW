using app.Models;
using library.Data;
using System.Linq.Expressions;

namespace library.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
