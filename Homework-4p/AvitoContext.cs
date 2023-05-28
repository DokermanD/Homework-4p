using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Homework_4p;

public partial class AvitoContext : DbContext
{
    public AvitoContext()
    {
    }

    public AvitoContext(DbContextOptions<AvitoContext> options) : base(options)
    {
    }

    public virtual DbSet<ChatBuyer> ChatBuyers { get; set; }

    public virtual DbSet<ProductsSale> ProductsSales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost; port=5432; database=Avito; username=postgres; password=2323");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatBuyer>(entity =>
        {
            entity.HasKey(e => e.BuyerId).HasName("chat_buyer_pkey");

            entity.ToTable("chat_buyer");

            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");
            entity.Property(e => e.MessageChat).HasColumnName("message_chat");
        });

        modelBuilder.Entity<ProductsSale>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_sale_pkey");

            entity.ToTable("products_sale");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.ProductPrace).HasColumnName("product_prace");

            entity.HasOne(d => d.FkUser).WithMany(p => p.ProductsSales)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_sale_fk_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
