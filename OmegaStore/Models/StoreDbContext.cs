using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OmegaStore.Models;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<DetailOrder> DetailOrders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsImage> ProductsImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Slideshow> Slideshows { get; set; }

    public virtual DbSet<WebsiteInfo> WebsiteInfos { get; set; }

    public virtual DbSet<Wishlist> Wishlist { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=OmegaShopConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            // Tên bảng
            entity.ToTable("accounts");

            // Khóa chính
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd(); // Tương đương [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

            // Thuộc tính Fullname
            entity.Property(e => e.Fullname)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("fullname");

            // Thuộc tính Gender
            entity.Property(e => e.Gender)
                  .IsRequired()
                  .HasColumnName("gender");

            // Thuộc tính Email
            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("email");

            // Thuộc tính Phone
            entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasMaxLength(20)
                  .HasColumnName("phone");

            // Thuộc tính Username
            entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("username");

            // Thuộc tính Password
            entity.Property(e => e.Password)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("password");

            // Thuộc tính Address
            entity.Property(e => e.Address)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("address");

            // Thuộc tính CreatedAt
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("GETDATE()")
                  .HasColumnType("datetime")
                  .HasColumnName("created_at");

            // Thuộc tính RoleId
            entity.Property(e => e.RoleId)
                  .IsRequired()
                  .HasColumnName("role_id");

            // Thuộc tính Status
            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasColumnName("status");

            // Khóa ngoại đến bảng Roles
            entity.HasOne(e => e.Role)
                  .WithMany(r => r.Accounts)
                  .HasForeignKey(e => e.RoleId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_accounts_roles");

            // Cấu hình mối quan hệ một-nhiều với Order
            entity.HasMany(a => a.Orders)  // Một Account có thể có nhiều Order
                .WithOne(o => o.Account)  // Mỗi Order chỉ thuộc về một Account
                .HasForeignKey(o => o.AccountId)  // Khóa ngoại trỏ đến AccountId trong Order
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Account, xóa các Order liên quan

            // Cấu hình mối quan hệ với Wishlist
            entity.HasMany(a => a.Wishlists)  // Một tài khoản có thể có nhiều Wishlist
                .WithOne(w => w.Account)  // Mỗi Wishlist có một Account
                .HasForeignKey(w => w.AccountId)  // Khóa ngoại trỏ đến AccountId trong Wishlist
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Account, xóa các Wishlist liên quan

        });// Đã sửa

        modelBuilder.Entity<Blog>(entity =>
        {
            // Tên bảng
            entity.ToTable("blogs");

            // Khóa chính
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd(); // Tương đương [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            // Thuộc tính Author
            entity.Property(e => e.Author)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("author");

            // Thuộc tính Title
            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("title");

            // Thuộc tính Thumbnail
            entity.Property(e => e.Thumbnail)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("thumbnail");

            // Thuộc tính Slug
            entity.Property(e => e.Slug)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("slug");

            // Thuộc tính Thumbnail
            entity.Property(e => e.ListContent)
                  .IsRequired()
                  .HasColumnType("ntext") // Nếu cần kiểu dữ liệu ntext
                  .HasColumnName("listcontent");

            // Thuộc tính Thumbnail
            entity.Property(e => e.ShortContent)
                  .IsRequired()
                  .HasColumnType("ntext") // Nếu cần kiểu dữ liệu ntext
                  .HasColumnName("shortcontent");

            // Thuộc tính Content
            entity.Property(e => e.Content)
                  .IsRequired()
                  .HasColumnType("ntext") // Nếu cần kiểu dữ liệu ntext
                  .HasColumnName("content");

            // Thuộc tính CreatedAt
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("(getdate())") // Đặt giá trị mặc định là ngày giờ hiện tại
                  .HasColumnType("datetime")
                  .HasColumnName("created_at");
        });// Đã sửa

        modelBuilder.Entity<Category>(entity =>
        {
            // Tên bảng
            entity.ToTable("categories");

            // Khóa chính
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd(); // Tương đương [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

            // Thuộc tính Name
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("name");

            // Thuộc tính Description
            entity.Property(e => e.Description)
                  .HasMaxLength(100)
                  .HasColumnName("description");

            // Thuộc tính Slug
            entity.Property(e => e.Slug)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("slug");

            // Thuộc tính Status
            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasColumnName("status");

            // Quan hệ một-nhiều với Products
            entity.HasMany(e => e.Products)
                  .WithOne(p => p.Category)
                  .HasForeignKey(p => p.CategoryId)
                  .HasConstraintName("FK_products_categories_categories");
        });// Đã sửa

        modelBuilder.Entity<Contact>(entity =>
        {
            // Tên bảng
            entity.ToTable("contacts");

            // Khóa chính (ContactId)
            entity.HasKey(e => e.ContactId); // Đảm bảo ContactId là khóa chính

            // Cột Email
            entity.Property(e => e.Email)
                  .HasMaxLength(50)
                  .IsRequired()  // Bắt buộc nhập
                  .HasColumnName("email");

            // Cột Fullname
            entity.Property(e => e.Fullname)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("fullname");

            // Cột Subject
            entity.Property(e => e.Subject)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("subject");

            // Cột Message
            entity.Property(e => e.Message)
                  .HasMaxLength(500) // Message có thể không bắt buộc
                  .HasColumnName("message");

            // Cột CreatedAt
            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("(getdate())") // Đặt giá trị mặc định là ngày giờ hiện tại
                  .HasColumnType("datetime")
                  .HasColumnName("created_at");

            // Cột Status
            entity.Property(e => e.Status)
                  .IsRequired()  // Bắt buộc nhập
                  .HasColumnName("status");
        });


        modelBuilder.Entity<DetailOrder>(entity =>
        {
            // Tên bảng
            entity.ToTable("detail_orders");

            // Khóa chính là sự kết hợp của OrderId và ProductId
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            // Thuộc tính OrderId và ProductId
            entity.Property(e => e.OrderId)
                  .HasColumnName("order_id");

            entity.Property(e => e.ProductId)
                  .HasColumnName("product_id");

            // Thuộc tính Quantity
            entity.Property(e => e.Quantity)
                  .IsRequired()
                  .HasColumnName("quantity");

            // Thuộc tính TotalPrice
            entity.Property(e => e.TotalPrice)
                  .IsRequired()
                  .HasColumnType("decimal(12,2)")
                  .HasColumnName("total_price");

            // Mối quan hệ với bảng Order
            entity.HasOne(d => d.Order)
                  .WithMany(p => p.DetailOrders)  // Một Order có thể có nhiều DetailOrder
                  .HasForeignKey(d => d.OrderId)  // Khóa ngoại OrderId
                  .HasConstraintName("FK_detail_orders_orders")
                  .OnDelete(DeleteBehavior.Cascade);  // Xóa DetailOrder khi Order bị xóa

            // Mối quan hệ với bảng Product
            entity.HasOne(d => d.Product)
                  .WithMany(p => p.DetailOrders)
                  .HasForeignKey(d => d.ProductId)
                  .HasConstraintName("FK_detail_orders_products")
                  .OnDelete(DeleteBehavior.Restrict);  // Giữ nguyên các DetailOrder khi Product bị xóa
        });// Đã sửa

        modelBuilder.Entity<Order>(entity =>
        {
            // Tên bảng
            entity.ToTable("orders");

            // Khóa chính
            entity.HasKey(e => e.Id);

            // Các thuộc tính với ràng buộc
            entity.Property(e => e.OrderCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("order_code");

            entity.Property(e => e.Fullname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("fullname");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("address");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            entity.Property(e => e.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(12,2)")
                .HasColumnName("total_amount");

            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasColumnName("payment_method");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");

            entity.Property(e => e.Note)
                .HasMaxLength(500) // Giới hạn tối đa 500 ký tự
                .IsUnicode(true);  // Cho phép lưu Unicode

            // Cấu hình mối quan hệ với Account: Một Account có thể có nhiều Order
            entity.HasOne(o => o.Account)  // Mỗi Order thuộc về một Account
                .WithMany(a => a.Orders)  // Một Account có thể có nhiều Order
                .HasForeignKey(o => o.AccountId)  // Khóa ngoại trỏ đến AccountId trong Order
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Account, xóa các Order liên quan

            // Mối quan hệ với bảng DetailOrder (một Order có thể có nhiều DetailOrder)
            entity.HasMany(e => e.DetailOrders)
                .WithOne(d => d.Order) // Mỗi DetailOrder chỉ thuộc một Order
                .HasForeignKey(d => d.OrderId) // Khóa ngoại là OrderId trong bảng DetailOrder
                .HasConstraintName("FK_detail_orders_orders")
                .OnDelete(DeleteBehavior.Cascade);  // Xóa các DetailOrder khi Order bị xóa
        });// Đã sửa

        modelBuilder.Entity<Product>(entity =>
        {
            // Tên bảng
            entity.ToTable("products");

            // Khóa chính
            entity.HasKey(e => e.Id);

            // Các thuộc tính với ràng buộc
            entity.Property(e => e.ProductCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_code");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Thumbnail)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("thumbnail");

            entity.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(12,2)")
                .HasColumnName("price");

            entity.Property(e => e.DiscountRate)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("discount_rate");

            entity.Property(e => e.Slug)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("slug");

            entity.Property(e => e.Stock)
                .IsRequired()
                .HasColumnName("stock");

            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("status");

            entity.Property(e => e.CategoryId)
                .IsRequired()
                .HasColumnName("category_id");

            // Mối quan hệ với bảng Category (mỗi Product thuộc một Category)
            entity.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("FK_products_categories")
                .OnDelete(DeleteBehavior.Cascade);

            // Mối quan hệ với bảng DetailOrder (một Product có thể có nhiều DetailOrder)
            entity.HasMany(e => e.DetailOrders)
                .WithOne(d => d.Product)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_detail_orders_products");

            // Mối quan hệ với bảng ProductsImage (một Product có thể có nhiều ProductsImage)
            entity.HasMany(e => e.ProductsImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_products_images_products");

            // Mối quan hệ với bảng Review (một Product có thể có nhiều Review)
            entity.HasMany(e => e.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .HasConstraintName("FK_reviews_products");

            // Cấu hình mối quan hệ với Wishlist
            entity.HasMany(p => p.Wishlists)  // Một sản phẩm có thể có nhiều Wishlist
                .WithOne(w => w.Product)  // Mỗi Wishlist có một Product
                .HasForeignKey(w => w.ProductId)  // Khóa ngoại trỏ đến ProductId trong Wishlist
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Product, xóa các Wishlist liên quan


        });// Đã sửa

        modelBuilder.Entity<ProductsImage>(entity =>
        {
            // Tên bảng
            entity.ToTable("products_images");

            // Cấu hình khóa chính với 2 trường (ProductId và Image)
            entity.HasKey(e => new { e.ProductId, e.Image });

            // Cấu hình các thuộc tính
            entity.Property(e => e.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image")
                .IsRequired();

            // Mối quan hệ với bảng Product (ProductsImage thuộc về Product)
            entity.HasOne(e => e.Product)
                .WithMany(p => p.ProductsImages)
                .HasForeignKey(e => e.ProductId)
                .HasConstraintName("FK_products_images_products")
                .OnDelete(DeleteBehavior.Cascade);
        });// Đã sửa

        modelBuilder.Entity<Wishlist>(entity =>
        {
            // Tên bảng
            entity.ToTable("wishlists");

            // Cấu hình khóa chính hợp nhất: kết hợp ProductId và AccountId tạo thành khóa chính
            entity.HasKey(e => new { e.ProductId, e.AccountId });

            // Cấu hình mối quan hệ với Product
            entity.HasOne(e => e.Product)  // Mỗi Wishlist có một Product
                .WithMany(p => p.Wishlists)  // Một Product có thể có nhiều Wishlist
                .HasForeignKey(e => e.ProductId)  // Cấu hình khóa ngoại với ProductId
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Product, xóa các Wishlist liên quan

            // Cấu hình mối quan hệ với Account
            entity.HasOne(e => e.Account)  // Mỗi Wishlist có một Account
                .WithMany(a => a.Wishlists)  // Một Account có thể có nhiều Wishlist
                .HasForeignKey(e => e.AccountId)  // Cấu hình khóa ngoại với AccountId
                .OnDelete(DeleteBehavior.Cascade);  // Nếu xóa Account, xóa các Wishlist liên quan
        });// Đã sửa

        modelBuilder.Entity<Role>(entity =>
        {
            // Tên bảng
            entity.ToTable("roles");

            // Cấu hình khóa chính
            entity.HasKey(e => e.Id);

            // Cấu hình thuộc tính Id
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); // Tự động tăng, mặc định với Identity

            // Cấu hình thuộc tính Name
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            // Cấu hình thuộc tính Description
            entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(100);

            // Mối quan hệ với bảng Account
            entity.HasMany(e => e.Accounts)
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId)
                .HasConstraintName("FK_accounts_roles");
        });// Đã sửa

        modelBuilder.Entity<Slideshow>(entity =>
        {
            // Tên bảng
            entity.ToTable("slideshows");

            // Cấu hình khóa chính
            entity.HasKey(e => e.Id);

            // Cấu hình thuộc tính Id
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); // Tự động tăng, mặc định với Identity

            // Cấu hình thuộc tính Image
            entity.Property(e => e.Image)
                .HasColumnName("image")
                .IsRequired()
                .HasMaxLength(255);

            // Cấu hình thuộc tính Link
            entity.Property(e => e.Link)
                .HasColumnName("link")
                .IsRequired()
                .HasMaxLength(255);
        });// Đã sửa

        modelBuilder.Entity<WebsiteInfo>(entity =>
        {
            // Tên bảng
            entity.ToTable("website_info");

            // Cấu hình khóa chính
            entity.HasKey(e => e.Id);

            // Cấu hình thuộc tính Id
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); // Tự động tăng, mặc định với Identity

            // Cấu hình thuộc tính ContactInfo
            entity.Property(e => e.ContactInfo)
                .HasColumnName("contact_info")
                .HasMaxLength(255);

            // Cấu hình thuộc tính Map
            entity.Property(e => e.Map)
                .HasColumnName("map");

            // Cấu hình thuộc tính Fanpage
            entity.Property(e => e.Fanpage)
                .HasColumnName("fanpage");

			// Cấu hình thuộc tính Logo
			entity.Property(e => e.Logo)
				.HasColumnName("logo");
		});// Đã sửa

        modelBuilder.Entity<Review>(entity =>
        {
            // Tên bảng
            entity.ToTable("reviews");

            // Cấu hình khóa chính (chìa khóa bao gồm cả ProductId và Email)
            entity.HasKey(e => new { e.ProductId, e.Email });

            // Cấu hình thuộc tính ProductId
            entity.Property(e => e.ProductId)
                .HasColumnName("product_id");

            // Cấu hình thuộc tính Email
            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(50);

            // Cấu hình thuộc tính Fullname
            entity.Property(e => e.Fullname)
                .HasColumnName("fullname")
                .HasMaxLength(100);

            // Cấu hình thuộc tính Rating
            entity.Property(e => e.Rating)
                .HasColumnName("rating")
                .IsRequired()
                .HasDefaultValue(1); // Đảm bảo Rating có giá trị mặc định hợp lệ

            // Cấu hình thuộc tính Comment
            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasMaxLength(500);

            // Cấu hình thuộc tính CreatedAt
            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            // Cấu hình mối quan hệ với bảng Product
            entity.HasOne(e => e.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Nếu xóa Product thì sẽ xóa Review liên quan
        });// Đã sửa


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
