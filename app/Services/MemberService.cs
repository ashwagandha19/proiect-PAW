using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System.Linq.Expressions;

namespace library.Service
{
    public class MemberService : BaseService
    {
        public MemberService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }

        public List<Member> GetMembers()
        {
            return repositoryWrapper.MemberRepository.FindAll().ToList();
        }

        public List<Member> GetMembersByCondition(Expression<Func<Member, bool>> expression)
        {
            return repositoryWrapper.MemberRepository.FindByCondition(expression).ToList();
        }

        public void AddMember(Member Member)
        {
            repositoryWrapper.MemberRepository.Create(Member);
        }

        public void UpdateMember(Member Member)
        {
            repositoryWrapper.MemberRepository.Update(Member);
        }

        public void DeleteMember(Member Member)
        {
            repositoryWrapper.MemberRepository.Delete(Member);
        }
    }
}
