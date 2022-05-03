using app.Models;

namespace library.Repository
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {

        public MemberRepository(Data.ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
