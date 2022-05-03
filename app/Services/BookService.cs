using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System.Linq.Expressions;

namespace library.Service
{
    public class BookService : BaseService
    {
        public BookService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }

        public List<Book> GetBooks()
        {
            return repositoryWrapper.BookRepository.FindAll().ToList();
        }

        public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> expression)
        {
            return repositoryWrapper.BookRepository.FindByCondition(expression).ToList();
        }

        public void AddBook(Book Book)
        {
            repositoryWrapper.BookRepository.Create(Book);
        }

        public void UpdateBook(Book Book)
        {
            repositoryWrapper.BookRepository.Update(Book);
        }

        public void DeleteBook(Book Book)
        {
            repositoryWrapper.BookRepository.Delete(Book);
        }
    }
}
