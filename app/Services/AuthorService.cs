using app.Models;
using library.Repository.Interfaces;
using library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace library.Services
{
    public class AuthorService : BaseService
    {
        public AuthorService(IRepositoryWrapper repositoryWrapper)
           : base(repositoryWrapper)
        {
        }

        public List<Author> GetAuthors()
        {
            return repositoryWrapper.AuthorRepository.FindAll().ToList();
        }

        public List<Author> GetAuthorsByCondition(Expression<Func<Author, bool>> expression)
        {
            return repositoryWrapper.AuthorRepository.FindByCondition(expression).ToList();
        }

        public void AddAuthor(Author Author)
        {
            repositoryWrapper.AuthorRepository.Create(Author);
        }

        public void UpdateAuthor(Author Author)
        {
            repositoryWrapper.AuthorRepository.Update(Author);
        }

        public void DeleteAuthor(Author Author)
        {
            repositoryWrapper.AuthorRepository.Delete(Author);
        }
    }
}