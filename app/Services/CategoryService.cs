using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System.Linq.Expressions;

namespace library.Service
{
    public class CategoryService : BaseService
    {
        public CategoryService(IRepositoryWrapper repositoryWrapper)
        : base(repositoryWrapper)
        {
        }

        public List<Category> GetCategories()
        {
            return repositoryWrapper.CategoryRepository.FindAll().ToList();
        }

        public List<Category> GetCategoriesByCondition(Expression<Func<Category, bool>> expression)
        {
            return repositoryWrapper.CategoryRepository.FindByCondition(expression).ToList();
        }

        public void AddCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Create(Category);
        }

        public void UpdateCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Update(Category);
        }

        public void DeleteCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Delete(Category );
        }
    }
}
