using Microsoft.AspNetCore.Mvc;
using OmegaStore.Services;

namespace OmegaStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("LoginView");
            }
            // Lấy thông tin tài khoản từ service
            var account = _accountService.GetAccountByUsername(username);
            if (account == null)
            {
                return RedirectToAction("LoginView"); // Chuyển hướng nếu không tìm thấy tài khoản
            }
            ViewBag.Username = username;
            return View(account);
        }//Trang chi tiết tài khoản

        [HttpGet]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }//Trang Đăng ký

        [HttpGet]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult ForgotPassword()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }//Trang Quên mật khẩu
        [HttpGet]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult LoginView()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index");
            }
            return View("Login");
        }//Trang đăng nhập

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _accountService.Authenticate(username, password);

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

            HttpContext.Session.SetString("Username", username);
            return RedirectToAction("Index");
        }//Xử lý đăng nhập tại trang đăng nhập

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginView");
        }//Xử lý đăng xuất tại trang chi tiết tài khoản

        [HttpPost]
        public IActionResult LoginPopup(string username, string password)
        {
            var user = _accountService.Authenticate(username, password);

            if (user == null)
            {
                return Json(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
            }

            if (_accountService.IsAccountLocked(username))
            {
                return Json(new { success = false, message = "Tài khoản này đã bị khóa!" });
            }

            HttpContext.Session.SetString("Username", username);
            return Json(new { success = true });
        }//Xử lý đăng nhập Popup

        public IActionResult LogoutPopup()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ dữ liệu trong Session
            return Json(new { success = true });
        }//Xử lý đăng xuất

        [HttpGet]
        public IActionResult CheckSession()
        {
            var username = HttpContext.Session.GetString("Username");
            if (!string.IsNullOrEmpty(username))
            {
                return Json(new { isLoggedIn = true });
            }
            return Json(new { isLoggedIn = false });
        }//Kiểm tra đã đăng nhập hay chưa.
    }

}
