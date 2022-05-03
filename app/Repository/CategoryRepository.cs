using app.Models;

namespace library.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(Data.ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
