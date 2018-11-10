﻿using System;
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
        
        public SewingStudioContext(DbContextOptions<SewingStudioContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__employer__73C69839C65602EF");

                entity.ToTable("employers");

                entity.Property(e => e.Id).HasColumnName("idEmployees");

                entity.Property(e => e.Date_of_delivery)
                    .HasColumnName("Date_of_delivery")
                    .HasColumnType("date");

                entity.Property(e => e.Execution_start_date)
                    .HasColumnName("Execution_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

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

                entity.Property(e => e.Id).HasColumnName("idMaterials");

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

                entity.HasIndex(e => e.IdProduct)
                    .HasName("idProducts_idx");

                entity.Property(e => e.Id).HasColumnName("idOrders");

                entity.Property(e => e.Date_of_order)
                    .HasColumnName("Date_of_order")
                    .HasColumnType("date");

                entity.Property(e => e.Date_of_sale)
                    .HasColumnName("Date_of_sale")
                    .HasColumnType("date");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            });

            modelBuilder.Entity<ProductComposition>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__productc__32102AF03704E1B7");

                entity.ToTable("productcomposition");

                entity.Property(e => e.Id).HasColumnName("idProductComposition");

                entity.Property(e => e.MaterialId).HasColumnName("idMaterial");

                entity.Property(e => e.ProductId).HasColumnName("idProduct");

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

                entity.ToTable("supply");

                entity.HasIndex(e => e.IdMaterials)
                    .HasName("idMaterials_idx");

                entity.Property(e => e.Id).HasColumnName("idSupply");

                entity.Property(e => e.Delivery_date)
                    .HasColumnName("Delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdMaterials).HasColumnName("idMaterials");

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);


            });
        }

    }

}