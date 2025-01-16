using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController( IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult LoginView()
        {
            return View("Login");
        }
        
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            if (username == null || password == null)
            {
                TempData["ErrorMessage"] = "Vui lòng nhập đầy đủ thông tin!";
                TempData["Username"] = username;
                return RedirectToAction("LoginView");
            }
            var user = _accountService.AuthenticateAdmin(username, password);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Sai tài khoản hoặc mật khẩu!";
                TempData["Username"] = username;
                return RedirectToAction("LoginView");
            }

            if (_accountService.IsAccountLocked(username))
            {
                TempData["ErrorMessage"] = "Tài khoản này đã bị khóa!";
                TempData["Username"] = username;
                return RedirectToAction("LoginView");
            }

            HttpContext.Session.SetString("AdminUsername", username);

            return RedirectToAction("Index", "Home");
        }//Xử lý đăng nhập tại trang đăng nhập

        //Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginView");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
