using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchfulEye.Data;
using WatchfulEye.Models;
using WatchfulEye.ViewModels;

namespace WatchfulEye.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly WatchfulEyeContext _ctx;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, WatchfulEyeContext ctx)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ctx = ctx;
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var resp = new LoginViewModel();
            return View(resp);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
                if(passwordCheck)
                {
                    var res = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if(res.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Login Failed: Bad Password.";
                return View(login);
            }

            TempData["Error"] = "Login Failed: User Does Not Exist.";
            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new NewLoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(NewLoginViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Home");
        }
    }
}
