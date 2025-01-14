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
        private readonly StoreDbContext _context;

        public AccountController(IAccountService accountService, StoreDbContext context)
        {
            _accountService = accountService;
            _context = context;
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



            var OrderAccount = _context.Orders.Include(o => o.Account).Include(o => o.DetailOrders).Where(o => o.AccountId == account.Id).Select(o => new
            {
                OrderId = o.Id,
                AccountId = o.Account.Id,
                Ordercode = o.OrderCode,
                Create_at = o.CreatedAt,
                Total = o.TotalAmount,
                Statuss = o.Status,

            }).ToList();
            ViewBag.OrderAccount = OrderAccount;






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

            string returnUrl = Request.Query["returnUrl"]!;

            Console.WriteLine("Duy dep trai" + returnUrl);

            ViewBag.returnUrl = returnUrl;

            return View("Login");
        }//Trang đăng nhập

        [HttpPost]
        public IActionResult Login(string username, string password, string? returnUrl)
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

            Console.WriteLine("Duy dep trai" + returnUrl);
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

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
                return Json(new { success = false, message = "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ với cửa hàng để được hỗ trợ", });
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

        [HttpGet]
        public JsonResult OrderStatus(int? status, int id)
        {


            if (status.HasValue)
            {
                var OrderStatus = _context.Orders.Include(o => o.Account).Include(o => o.DetailOrders).Where(o => o.AccountId == id && o.Status == status).Select(o => new
                {
                    OrderId = o.Id,
                    AccountId = o.Account.Id,
                    Ordercode = o.OrderCode,
                    Create_at = o.CreatedAt,
                    Total = o.TotalAmount,
                    Statuss = o.Status,

                }).ToList();
                return Json(OrderStatus);
            }
            else
            {
                var OrderStatus = _context.Orders.Include(o => o.Account).Include(o => o.DetailOrders).Where(o => o.AccountId == id && o.Status != 0).Select(o => new
                {
                    OrderId = o.Id,
                    AccountId = o.Account.Id,
                    Ordercode = o.OrderCode,
                    Create_at = o.CreatedAt,
                    Total = o.TotalAmount,
                    Statuss = o.Status,

                }).ToList();
                return Json(OrderStatus);
            }




        }
        [HttpPost]
        public IActionResult CancelOrder(int orderid, int status)
        {

            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.Id == orderid);
                if (order == null)
                {
                    return Json(new { success = false });
                }

                order.Status = status;
                _context.SaveChanges();
                var Getstatus = status;
                return Json(new { success = true, Getstatus });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }


    }

}
