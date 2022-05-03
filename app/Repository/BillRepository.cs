using app.Models;
using library.Data;

namespace library.Repository
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
