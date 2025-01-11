using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OmegaStore.Models;
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
            if (username == null || password == null)
            {
                TempData["ErrorMessage"] = "Vui lòng nhập đầy đủ thông tin!";
                TempData["Username"] = username;
                return RedirectToAction("LoginView");
            }

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
            Response.Cookies.Delete("RememberMe"); // Xóa cookie
            return RedirectToAction("LoginView");
        }//Xử lý đăng xuất tại trang chi tiết tài khoản

        [HttpPost]
        public IActionResult LoginPopup(string username, string password, bool rememberMe)
        {
            var user = _accountService.Authenticate(username, password);
            if (username == null || password == null)
            {
                return Json(new { success = false, message = "Vui lòng nhập đầy đủ thông tin" });
            }
            if (user == null)
            {
                return Json(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
            }

            if (_accountService.IsAccountLocked(username))
            {
                return Json(new { success = false, message = "Tài khoản này đã bị khóa!", });
            }
            if (rememberMe)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7), // Thời gian sống của cookie (7 ngày)
                    HttpOnly = true, // Chỉ sử dụng qua HTTP
                    Secure = true // Chỉ hoạt động với HTTPS
                };
                Response.Cookies.Append("RememberMe", user.Username, cookieOptions);
            }
            HttpContext.Session.SetString("Username", user.Username);
            return Json(new { success = true, username = user.Fullname });
        }//Xử lý đăng nhập Popup

        public IActionResult LogoutPopup()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ dữ liệu trong Session
            Response.Cookies.Delete("RememberMe"); // Xóa cookie
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
        [HttpPost]
        public IActionResult CheckAvailability(string field, string value)
        {
            bool isExists = _accountService.CheckFieldExists(field, value);
            return Json(new { exists = isExists });
        }

        public IActionResult CreateAccount(Account account)
        {

            ModelState.Remove("Status");
            ModelState.Remove("RoleId");
            ModelState.Remove("Status");
            ModelState.Remove("Address");
            ModelState.Remove("Role");
            ModelState.Remove("Order");
            ModelState.Remove("Wishlist");
            if (ModelState.IsValid)
            {
                if (_accountService.CheckFieldExists("email", account.Email))
                {
                    if (_accountService.CheckFieldExists("username", account.Username))
                    {
                        TempData["ErrorMessage"] = "Tên đăng nhập và email đã tồn tại!";
                        return View("Register", account);
                    }
                    TempData["ErrorMessage"] = "Email đã tồn tại!";
                    return View("Register", account);
                }
                if (_accountService.CheckFieldExists("username", account.Username))
                {
                    TempData["ErrorMessage"] = "Tên đăng nhập đã tồn tại!";
                    return View("Register", account);
                }
                account.Status = 1;
                account.RoleId = 3;
                account.Address = "Chưa có địa chỉ";
                _accountService.Register(account);
                TempData["Success"] = "Tài khoản đã được tạo, hãy tiến hành đăng nhập!";
                return RedirectToAction("LoginView");
            }
            TempData["ErrorMessage"] = "Lỗi tạo tài khoản!";
            return View("Register", account);
        }

    }

}
