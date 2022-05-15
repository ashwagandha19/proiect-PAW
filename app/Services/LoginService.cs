//using app.Models;
//using library.Repository.Interfaces;
//using Microsoft.AspNetCore.Identity;

//namespace library.Services
//{
//    public class LoginService : BaseService
//    {
//        private readonly SignInManager<Member> _signInManager;
//        public LoginService(IRepositoryWrapper repositoryWrapper, SignInManager<Member> signInManager, IToastNotification toastNotification)
//             : base(repositoryWrapper)
//        {
//            _signInManager = signInManager;
//            _toastNotification = toastNotification;
//        }

//        public async Task<bool> Login(string username, string password, bool rememberMe)
//        {
//            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);
//            if (result.Succeeded)
//            {
//                _toastNotification.AddSuccessToastMessage("Login successful!");
//                return true;
//            }
//            return false;
//        }
//    }
//}
