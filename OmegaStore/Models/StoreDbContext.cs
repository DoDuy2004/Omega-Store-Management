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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=OmegaShopConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_accounts_roles");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("blogs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("contacts");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .HasColumnName("message");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<DetailOrder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("detail_orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_price");

            entity.HasOne(d => d.Order).WithMany(p => p.DetailOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_detail_orders_orders");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailOrders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_detail_orders_products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.HasIndex(e => e.OrderCode, "UQ_orders").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(50)
                .HasColumnName("order_code");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.HasIndex(e => e.ProductCode, "UQ_products_product_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.DiscountRate)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount_rate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(50)
                .HasColumnName("product_code");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_products_categories_categories");

            entity.HasMany(d => d.Accounts).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "Wishlist",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_wishlists_accounts"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_wishlists_products"),
                    j =>
                    {
                        j.HasKey("ProductId", "AccountId");
                        j.ToTable("wishlists");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("AccountId").HasColumnName("account_id");
                    });
        });

        modelBuilder.Entity<ProductsImage>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.Image }).HasName("PK_product_images");

            entity.ToTable("products_images");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("PK_product_images_products");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.AccountId });

            entity.ToTable("wishlists");

            entity.Property(e => e.ProductId)
                .HasColumnName("product_id");

            entity.Property(e => e.AccountId)
                .HasColumnName("account_id");

            entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_wishlists_products");

            entity.HasOne(d => d.Account)
            .WithOne(a => a.Wishlist) // Mỗi account chỉ có một wishlist
            .HasForeignKey<Wishlist>(d => d.AccountId)
            .OnDelete(DeleteBehavior.Cascade) // Xóa wishlist khi account bị xóa
            .HasConstraintName("FK_wishlists_accounts");
        });


        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Slideshow>(entity =>
        {
            entity.ToTable("slideshows");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
        });

        modelBuilder.Entity<WebsiteInfo>(entity =>
        {
            entity.ToTable("website_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .HasColumnName("contact_info");
            entity.Property(e => e.Fanpage)
                .HasColumnType("ntext")
                .HasColumnName("fanpage");
            entity.Property(e => e.Map)
                .HasColumnType("ntext")
                .HasColumnName("map");
        });
            

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
