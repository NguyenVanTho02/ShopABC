using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShopABC.Entities;

namespace ShopABC.AppDbContext
{
    public partial class ShopABCContext : DbContext
    {
        public ShopABCContext()
        {
        }

        public ShopABCContext(DbContextOptions<ShopABCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCart> ProductCarts { get; set; } = null!;
        public virtual DbSet<ProductOrder> ProductOrders { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<RegistrationUserToken> RegistrationUserTokens { get; set; } = null!;
        public virtual DbSet<ResetPasswordToken> ResetPasswordTokens { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H91LLQ7\\MSSQLSERVER02;Initial Catalog=ShopABC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Idbrand);

                entity.ToTable("Brand");

                entity.Property(e => e.Idbrand).HasColumnName("IDBrand");

                entity.Property(e => e.NameBrand)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Idcart);

                entity.ToTable("Cart");

                entity.Property(e => e.Idcart).HasColumnName("IDCart");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Cart_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory);

                entity.ToTable("Category");

                entity.Property(e => e.Idcategory)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idorder);

                entity.ToTable("Order");

                entity.Property(e => e.Idorder)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOrder");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Idship).HasColumnName("IDShip");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdshipNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idship)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Order_Shipping");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Idpost);

                entity.ToTable("Post");

                entity.Property(e => e.Idpost).HasColumnName("IDPost");

                entity.Property(e => e.ContentPost).HasColumnType("text");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct);

                entity.ToTable("Product");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.Property(e => e.AgeGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Describle).HasColumnType("text");

                entity.Property(e => e.Guide).HasColumnType("text");

                entity.Property(e => e.Idbrand).HasColumnName("IDBrand");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.Idpromotion).HasColumnName("IDPromotion");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdbrandNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idbrand)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.IdpromotionNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Idpromotion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Product_Promotion");
            });

            modelBuilder.Entity<ProductCart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductCart");

                entity.Property(e => e.Idcart).HasColumnName("IDCart");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductOrder");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idorder)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ProductOrder_Order");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ProductOrder_Product");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.Idpromotion);

                entity.ToTable("Promotion");

                entity.Property(e => e.Idpromotion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPromotion");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistrationUserToken>(entity =>
            {
                entity.HasKey(e => e.Idrutoken);

                entity.ToTable("RegistrationUserToken");

                entity.Property(e => e.Idrutoken)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRUToken");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.RegistrationUserTokens)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RegistrationUserToken_User");
            });

            modelBuilder.Entity<ResetPasswordToken>(entity =>
            {
                entity.HasKey(e => e.Idrptoken);

                entity.ToTable("ResetPasswordToken");

                entity.Property(e => e.Idrptoken)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRPToken");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.ResetPasswordTokens)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ResetPasswordToken_User");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.Idship);

                entity.ToTable("Shipping");

                entity.Property(e => e.Idship).HasColumnName("IDShip");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("User");

                entity.Property(e => e.Iduser)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUser");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
