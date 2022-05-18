using app.Models;
using library.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

namespace library.Services
{
    public class LoginService : BaseService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IToastNotification _toastNotification;
        public LoginService(IRepositoryWrapper repositoryWrapper, SignInManager<IdentityUser> signInManager, IToastNotification toastNotification)
             : base(repositoryWrapper)
        {
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }

        public async Task<bool> Login(string username, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Login successful!");
                return true;
            }
            return false;
        }
    }
}
