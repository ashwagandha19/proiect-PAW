using library.Data;
using library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _applicationDbContext;
        private IAuthorRepository? _authorRepository;
        private IBookRepository? _bookRepository;
        private ICategoryRepository? _categoryRepository;
        private IMemberRepository? _memberRepository;
        private IPublisherRepository? _publisherRepository;
        private IBillRepository? _billRepository;

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_applicationDbContext);
                }
                return _authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_applicationDbContext);
                }
                return _bookRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_applicationDbContext);
                }
                return _categoryRepository;
            }
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new MemberRepository(_applicationDbContext);
                }
                return _memberRepository;
            }
        }

        public IPublisherRepository PublisherRepository
        {
            get
            {
                if (_publisherRepository == null)
                {
                    _publisherRepository = new PublisherRepository(_applicationDbContext);
                }
                return _publisherRepository;
            }
        }

        public IBillRepository BillRepository
        {
            get
            {
                if (_billRepository == null)
                {
                    _billRepository = new BillRepository(_applicationDbContext);
                }
                return _billRepository;
            }
        }

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
