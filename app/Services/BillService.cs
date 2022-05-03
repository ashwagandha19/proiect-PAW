using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System.Linq.Expressions;

namespace library.Service
{
    public class BillService : BaseService
    {
        public BillService(IRepositoryWrapper repositoryWrapper)
        : base(repositoryWrapper)
        {
        }

        public List<Bill> GetBills()
        {
            return repositoryWrapper.BillRepository.FindAll().ToList();
        }

        public List<Bill> GetBillsByCondition(Expression<Func<Bill, bool>> expression)
        {
            return repositoryWrapper.BillRepository.FindByCondition(expression).ToList();
        }

        public void AddBill(Bill Bill)
        {
            repositoryWrapper.BillRepository.Create(Bill);
        }

        public void UpdateBill(Bill Bill)
        {
            repositoryWrapper.BillRepository.Update(Bill);
        }

        public void DeleteBill(Bill Bill)
        {
            repositoryWrapper.BillRepository.Delete(Bill);
        }
    }
}
