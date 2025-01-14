﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmegaStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            return View(); // Truyền danh sách sản phẩm vào View
        }

        public IActionResult List(string searchQuery = "", int page = 1, int Status = 1, int pageSize = 6)
        {
            var query = _context.Products.Where(p => p.Status == Status).ToList();
            var normalQuery = searchQuery;
            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = CreateUnaccentedTextSearch(searchQuery);
                query = query.Where(b => CreateUnaccentedTextSearch(b.Name).Contains(searchQuery)).ToList();
            }

            // Phân trang
            var totalItems = query.Count();
            var products = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchQuery = normalQuery;
            ViewBag.result = totalItems;
            ViewBag.status = Status;
            return PartialView("_ProductListPartial", products);
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

        //Trang Chỉnh sửa sản phẩm
        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .Include(p => p.ProductsImages)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId); // Danh sách categories
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(IEnumerable<String> removedImages, Product product, IEnumerable<IFormFile>? images, IFormFile? Thumbnail)
        {

            var productUpdate = _context.Products
                .Include(p => p.ProductsImages)
                .FirstOrDefault(p => p.Id == product.Id);
            if (product == null)
            {
                return NotFound();
            }
            ModelState.Remove("Slug");
            ModelState.Remove("Thumbnail");
            ModelState.Remove("Category");
            ModelState.Remove("DetailOrders");
            ModelState.Remove("ProductsImages");
            ModelState.Remove("Reviews");
            ModelState.Remove("Wishlists");
            if (ModelState.IsValid)
            {
                productUpdate.Name = product.Name;
                productUpdate.Description = product.Description;
                productUpdate.Price = product.Price;
                productUpdate.Stock = product.Stock;
                productUpdate.CategoryId = product.CategoryId;
                productUpdate.DiscountRate = product.DiscountRate;
                productUpdate.Slug = CreateUnaccentedText(RemoveExtraSpaces(product.Name));
                // Kiểm tra trong CSDL nếu Slug đã tồn tại
                var existingProduct = _context.Products
                    .Where(p => p.Slug == productUpdate.Slug && p.Id != productUpdate.Id)
                    .FirstOrDefault();
                if (existingProduct != null)
                {
                    return NotFound(existingProduct);
                }
                try
                {
                    _context.Update(productUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }


            var productImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "products");

            //Nếu có thay đổi ảnh đại diện
            if (Thumbnail != null)
            {

                if (!Directory.Exists(productImagesPath))
                {
                    Directory.CreateDirectory(productImagesPath);
                }

                //Tạo tên ảnh mới
                string fileName = $"{product.ProductCode}{Path.GetExtension(Thumbnail.FileName)}";

                //Tạo đường dẫn
                string filePath = Path.Combine(productImagesPath, fileName);

                //Xóa file ảnh cũ nếu tồn tại trong wwwroot
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                //Thêm file ảnh mới vào wwwroot
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Thumbnail.CopyTo(stream);
                }
            }

            //Nếu có ảnh bị xóa, xóa các ảnh trong danh sách RemovedImages
            if (removedImages != null && removedImages.Any())
            {
                //Bước 1: Lặp qua các ảnh trong list
                foreach (var imageName in removedImages)
                {
                    var productImage = _context.ProductsImages
                    .FirstOrDefault(pi => pi.ProductId == product.Id && pi.Image == imageName);

                    //Thực hiện xóa ảnh trong wwwroot
                    var filePath = Path.Combine(productImagesPath, imageName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);

                    }
                    // Xóa ảnh ra khỏi csdl
                    _context.ProductsImages.Remove(productImage);
                }
                //Lưu xuống csdl
                _context.SaveChanges();

                // Bước 2: Lấy danh sách các ảnh còn lại và cập nhật thứ tự trong CSDL
                var remainingImages = productUpdate.ProductsImages
                    .OrderBy(pi => pi.Image)
                    .ToList();

                // Bước 3: Cập nhật lại tên của ảnh trong wwwrooot và csdl theo thứ tự
                for (int i = 0; i < remainingImages.Count; i++)
                {
                    //Tên ảnh đầu tiên.
                    var newFileName = $"{product.ProductCode}_{i + 1}{Path.GetExtension(remainingImages[i].Image)}";

                    if (remainingImages[i].Image != newFileName)
                    {
                        // Đổi tên file trong wwwroot
                        var oldFilePath = Path.Combine(productImagesPath, remainingImages[i].Image);
                        var newFilePath = Path.Combine(productImagesPath, newFileName);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Move(oldFilePath, newFilePath);
                        }
                        remainingImages[i].Image = newFileName;
                        //// Xóa bản ghi cũ trong CSDL
                        //product.ProductsImages.Remove(remainingImages[i]);

                        //// Thêm bản ghi mới với tên đã cập nhật
                        //var updatedImage = new ProductsImage
                        //{
                        //    ProductId = product.Id,
                        //    Image = newFileName
                        //};
                        //_context.Add(updatedImage);
                    }
                }
                await _context.SaveChangesAsync();
            }

            //Nếu có ảnh mới, thêm ảnh mới với ProductCode_số thứ tự tiếp theo
            if (images != null && images.Any())
            {
                var remainingImages = _context.ProductsImages
                .Where(pi => pi.ProductId == product.Id)
                .OrderBy(pi => pi.Image) // Đảm bảo theo thứ tự tên file
                .ToList();

                int currentImageIndex = remainingImages.Count; // Số thứ tự tiếp theo

                foreach (var imageFile in images)
                {
                    if (imageFile.Length > 0)
                    {
                        currentImageIndex++;
                        var newFileName = $"{product.ProductCode}_{currentImageIndex}{Path.GetExtension(imageFile.FileName)}";
                        var newFilePath = Path.Combine(productImagesPath, newFileName);

                        // Lưu file vào thư mục
                        using (var stream = new FileStream(newFilePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }
                        // Xóa ảnh ra khỏi csdl
                        var productImage = new ProductsImage
                        {
                            ProductId = product.Id,
                            Image = newFileName
                        };
                        _context.ProductsImages.Add(productImage);
                    }
                }
                await _context.SaveChangesAsync();
            }

            ViewBag.ImageList = removedImages;
            return RedirectToAction("Index");
        }

        //Trang thêm sản phẩm
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            // Tạo SelectList từ danh sách Categories
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        //Xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);//Tìm sản phẩm có trùng id
                if (product == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Sản phẩm không tồn tại"
                    });
                }

                // Thay đổi trạng thái sản phẩm (0 = đã xóa)
                product.Status = 0;
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Sản phẩm đã được xóa.",
                    productId = product.Id,
                    newStatus = product.Status
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Có lỗi trong quá trình xử lý!",
                    details = ex.Message
                });
            }
        }

        //Thêm sản phẩm
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
                    return View("Create", product);
                }
                product.ProductCode = "No Code";
                product.Status = 1;
                product.Stock = 0;
                product.Thumbnail = "No Image";
                _context.Products.Add(product);
                _context.SaveChanges();

                product.ProductCode = GenerateProductCode(product.Id);

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

        //Tạo chữ ko dấu
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

        //Tạo chữ ko dấu cho search
        public static string CreateUnaccentedTextSearch(string input)
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
            return input.Replace(" ", "").ToLower();
        }

        //Loại bỏ khoảng trắng
        public static string RemoveExtraSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Tách các từ bằng khoảng trắng và loại bỏ các khoảng trắng thừa
            return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        //Tạo ProductCode
        public static string GenerateProductCode(int id)
        {
            // Lấy ngày/tháng/năm hiện tại theo định dạng ddMMyyyy
            string currentDate = DateTime.Now.ToString("yyyyMMdd");

            // Tạo chuỗi ProductCode từ SP+Ngày/tháng/năm+id
            return $"SP{currentDate}{id}";
        }

        //Xóa Review
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
            return RedirectToAction("Detail", new { slug = product.Slug }); // Truyền sản phẩm vào View
        }

        public JsonResult CheckSlug(string name, int id)
        {
            // Tạo slug từ tên sản phẩm
            var Slug = CreateUnaccentedText(RemoveExtraSpaces(name));

            // Kiểm tra trong CSDL nếu Slug đã tồn tại và không phải sản phẩm hiện tại
            var existingProduct = _context.Products
                .Where(p => p.Slug == Slug && p.Id != id)
                .FirstOrDefault();

            if (existingProduct != null)
            {
                return Json(new
                {
                    success = false,
                    message = "Tên sản phẩm đã tồn tại!",
                });
            }

            return Json(new
            {
                success = true,
            });
        }
    }    
}
