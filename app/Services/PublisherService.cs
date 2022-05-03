using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System.Linq.Expressions;

namespace library.Service
{
    public class PublisherService : BaseService
    {
        public PublisherService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }

        public List<Publisher> GetPublishers()
        {
            return repositoryWrapper.PublisherRepository.FindAll().ToList();
        }

        public List<Publisher> GetPublishersByCondition(Expression<Func<Publisher, bool>> expression)
        {
            return repositoryWrapper.PublisherRepository.FindByCondition(expression).ToList();
        }

        public void AddPublisher(Publisher Publisher)
        {
            repositoryWrapper.PublisherRepository.Create(Publisher);
        }

        public void UpdatePublisher(Publisher Publisher)
        {
            repositoryWrapper.PublisherRepository.Update(Publisher);
        }

        public void DeletePublisher(Publisher Publisher)
        {
            repositoryWrapper.PublisherRepository.Delete(Publisher);
        }
    }
}
