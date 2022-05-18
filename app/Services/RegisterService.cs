using library.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace library.Services
{
    public class RegisterService : BaseService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public RegisterService(IRepositoryWrapper repositoryWrapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : base(repositoryWrapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(IdentityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
    }
}
