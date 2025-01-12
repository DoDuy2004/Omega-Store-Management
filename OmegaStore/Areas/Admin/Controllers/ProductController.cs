using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly StoreDbContext _context;

        public ProductController(StoreDbContext context)
        {
            _context = context;
        }

        //Trang Danh sách sản phẩm
        public IActionResult Index()
        {
            var products = _context.Products
                .ToList(); // Lấy tất cả các sản phẩm từ cơ sở dữ liệu
            return View(products); // Truyền danh sách sản phẩm vào View
        }

        //Trang Chi tiết sản phẩm
        [HttpGet("[Area]/[controller]/[action]/{slug}")]
        public IActionResult Detail(string slug)
        {
            var products = _context.Products;
            var product = products
                .Include(p => p.ProductsImages)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Slug == slug);
            
            List<Review> reviews = _context.Reviews.Where(p => p.ProductId == product.Id).ToList();
            if (product == null)
            {
                return NotFound(); // Nếu sản phẩm không tồn tại, trả về 404
            }

            ViewBag.Reviews = reviews;
            return View(product); // Truyền sản phẩm vào View
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId); // Danh sách categories
            return View(product);
        }

        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            // Tạo SelectList từ danh sách Categories
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        public IActionResult AddProduct(Product product, IEnumerable<IFormFile> images, IFormFile Thumbnail)
        {
            ModelState.Remove("ProductCode");
            ModelState.Remove("Status");
            ModelState.Remove("Slug");
            ModelState.Remove("Stock");
            ModelState.Remove("Thumbnail");
            ModelState.Remove("Category");
            ModelState.Remove("DetailOrders");
            ModelState.Remove("ProductsImages");
            ModelState.Remove("Reviews");
            ModelState.Remove("Wishlists");
            if (ModelState.IsValid)
            {
                product.Slug = CreateUnaccentedText(RemoveExtraSpaces(product.Name));
                // Kiểm tra xem Slug đã tồn tại chưa
                bool isSlugExists = _context.Products.Any(p => p.Slug == product.Slug);
                if (isSlugExists)
                {
                    ModelState.AddModelError("Name", "Tên sản phẩm này đã tồn tại!");
                    var categories = _context.Categories.ToList();
                    // Tạo SelectList từ danh sách Categories
                    ViewBag.Categories = new SelectList(categories, "Id", "Name");
                    return View("Create",product);
                }
                product.ProductCode = "No Code";
                product.Status = 1;
                product.Stock = 0;
                
                if (Thumbnail.Length > 0)
                {
                    // Đường dẫn lưu hình ảnh trên server
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/products");

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string fileName = $"{product.ProductCode}.jpg";
                    string filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Thumbnail.CopyTo(stream);
                    }
                    product.Thumbnail = fileName;
                }
                else
                {
                    product.Thumbnail = "No Image";
                }

                _context.Products.Add(product);
                _context.SaveChanges();

                product.ProductCode = GenerateProductCode(product.Id);
                _context.Update(product);
                _context.SaveChanges();

                // Xử lý việc lưu hình ảnh
                if (images != null && images.Any())
                {
                    int imageIndex = 1;

                    foreach (var image in images)
                    {
                        if (image.Length > 0)
                        {
                            // Đường dẫn lưu hình ảnh trên server
                            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/products");

                            if (!Directory.Exists(uploadPath))
                            {
                                Directory.CreateDirectory(uploadPath);
                            }

                            string fileName = $"{product.ProductCode}_{imageIndex}.jpg";
                            string filePath = Path.Combine(uploadPath, fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                image.CopyTo(stream);
                            }

                            // Thêm thông tin vào bảng ProductImage
                            var productImage = new ProductsImage
                            {
                                ProductId = product.Id,
                                Image = fileName
                            };

                            _context.ProductsImages.Add(productImage);
                            imageIndex++;
                        }
                    }
                    _context.SaveChanges();
                }
                TempData["Success"] = "Thêm sản phẩm mới thành công!";
                return RedirectToAction("Create");
            }
            TempData["Error"] = "Đã có lỗi xảy ra, hãy thử lại sau!";
            return RedirectToAction("Create");

        }
        public static string CreateUnaccentedText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;
            //Hàng đầu tiên là chữ không dấu, các hàng sau là chữ có dấu, sắp xếp đúng theo thứ tự của hàng đầu
            string[] vietnamese = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            // Thay thế các ký tự có dấu thành không dấu
            for (int i = 1; i < vietnamese.Length; i++)
            {
                foreach (var c in vietnamese[i])
                {
                    input = input.Replace(c, vietnamese[0][i - 1]);
                }
            }
            //Trả về kết quả,bỏ tất cả khoảng trắng, viết thường.
            return input.Replace(" ", "-").ToLower();
        }
        public static string RemoveExtraSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Tách các từ bằng khoảng trắng và loại bỏ các khoảng trắng thừa
            return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        public static string GenerateProductCode(int id)
        {
            // Lấy ngày/tháng/năm hiện tại theo định dạng ddMMyyyy
            string currentDate = DateTime.Now.ToString("yyyyMMdd");

            // Tạo chuỗi ProductCode từ SP+Ngày/tháng/năm+id
            return $"SP{currentDate}{id}";
        }

        public IActionResult DeleteReview(string email, int id)
        {
            var getReview = _context.Reviews.FirstOrDefault(p => p.Email == email && p.ProductId == id);
            if (getReview != null)
            {
                _context.Reviews.Remove(getReview);
                _context.SaveChanges();
                TempData["success"] = "Xóa đánh giá thành công";
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id); // Lấy sản phẩm theo ProductId

            List<Review> reviews = _context.Reviews.Where(p => p.ProductId == id).ToList();
            ViewBag.Reviews = reviews;
            return RedirectToAction("Detail", new {slug = product.Slug }); // Truyền sản phẩm vào View
        }
    }
}
