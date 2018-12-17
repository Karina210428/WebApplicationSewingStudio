using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplicationSewingStudio.Models
{
    public class SewingStudioContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public SewingStudioContext(DbContextOptions<SewingStudioContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__employer__73C69839C65602EF");

                entity.ToTable("Employees");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Date_of_delivery)
                    .HasColumnName("Date_of_delivery")
                    .HasColumnType("date");

                entity.Property(e => e.Execution_start_date)
                    .HasColumnName("Execution_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.OrderId).HasColumnName("OrderId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__material__D80A2546DF1B26BF");

                entity.ToTable("materials");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__orders__57EB7B0DCE241BFD");

                entity.ToTable("orders");

                entity.HasIndex(e => e.ProductId)
                    .HasName("idProducts_idx");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Date_of_order)
                    .HasColumnName("Date_of_order")
                    .HasColumnType("date");

                entity.Property(e => e.Price).HasColumnName("Price").HasColumnType("float");

                entity.Property(e => e.Date_of_sale)
                    .HasColumnName("Date_of_sale")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
            });

            modelBuilder.Entity<ProductComposition>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__productc__32102AF03704E1B7");

                entity.ToTable("productcomposition");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialId");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");

                entity.Property(e => e.Quantity).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tmp_ms_x__E94C3637FD8BB1A5");

                entity.ToTable("supplies");

                entity.HasIndex(e => e.MaterialId)
                    .HasName("idMaterials_idx");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Delivery_date)
                    .HasColumnName("Delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.Price).HasColumnName("Price").HasColumnType("float");

                entity.Property(e=>e.Quantity).HasColumnName("QuantityMaterials").HasColumnType("int").HasDefaultValueSql("('0')");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialId");

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);


            });
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            base.OnModelCreating(modelBuilder);
        }

    }

}
