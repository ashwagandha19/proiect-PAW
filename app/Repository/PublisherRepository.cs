using app.Models;

namespace library.Repository
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {

        public PublisherRepository(Data.ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
