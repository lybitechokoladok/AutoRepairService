using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Infrastructure
{
    public sealed class AutoRepairServiceDbContext : DbContext
    {
        public AutoRepairServiceDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public  DbSet<Client> Clients { get; set; }

        public  DbSet<ClientService> ClientServices { get; set; }

        public  DbSet<DocumentByService> DocumentByServices { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<HistoryEnter> HistoryEnters { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<ProductSale> ProductSales { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ServiceDto> Services { get; set; }

        public DbSet<ServicePhoto> ServicePhotos { get; set; }

        public DbSet<TagDto> Tags { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Birthday).HasColumnType("date");
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.GenderCode)
                    .HasMaxLength(1)
                    .IsFixedLength();
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Patronymic).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.PhotoPath).HasMaxLength(1000);
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.GenderCodeNavigation).WithMany(p => p.Clients)
                    .HasForeignKey(d => d.GenderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");

                entity.HasMany(d => d.Tags).WithMany(p => p.Clients)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagOfClient",
                        r => r.HasOne<Tag>().WithMany()
                            .HasForeignKey("TagId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TagOfClient_Tag"),
                        l => l.HasOne<Client>().WithMany()
                            .HasForeignKey("ClientId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_TagOfClient_Client"),
                        j =>
                        {
                            j.HasKey("ClientId", "TagId");
                            j.ToTable("TagOfClient");
                            j.IndexerProperty<int>("ClientId").HasColumnName("ClientID");
                            j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                        });
            });

            modelBuilder.Entity<ClientService>(entity =>
            {
                entity.ToTable("ClientService");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ClientId).HasColumnName("ClientID");
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client).WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Client");

                entity.HasOne(d => d.Service).WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Service");
            });

            modelBuilder.Entity<DocumentByService>(entity =>
            {
                entity.ToTable("DocumentByService");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");
                entity.Property(e => e.DocumentPath).HasMaxLength(1000);

                entity.HasOne(d => d.ClientService).WithMany(p => p.DocumentByServices)
                    .HasForeignKey(d => d.ClientServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentByService_ClientService");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Gender");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();
                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<HistoryEnter>(entity =>
            {
                entity.ToTable("HistoryEnter");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User).WithMany(p => p.HistoryEnters)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryEnter_User");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Cost).HasColumnType("money");
                entity.Property(e => e.MainImagePath).HasMaxLength(1000);
                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");

                entity.HasMany(d => d.AttachedProducts).WithMany(p => p.MainProducts)
                    .UsingEntity<Dictionary<string, object>>(
                        "AttachedProduct",
                        r => r.HasOne<Product>().WithMany()
                            .HasForeignKey("AttachedProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_AttachedProduct_Product1"),
                        l => l.HasOne<Product>().WithMany()
                            .HasForeignKey("MainProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_AttachedProduct_Product"),
                        j =>
                        {
                            j.HasKey("MainProductId", "AttachedProductId");
                            j.ToTable("AttachedProduct");
                            j.IndexerProperty<int>("MainProductId").HasColumnName("MainProductID");
                            j.IndexerProperty<int>("AttachedProductId").HasColumnName("AttachedProductID");
                        });

                entity.HasMany(d => d.MainProducts).WithMany(p => p.AttachedProducts)
                    .UsingEntity<Dictionary<string, object>>(
                        "AttachedProduct",
                        r => r.HasOne<Product>().WithMany()
                            .HasForeignKey("MainProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_AttachedProduct_Product"),
                        l => l.HasOne<Product>().WithMany()
                            .HasForeignKey("AttachedProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_AttachedProduct_Product1"),
                        j =>
                        {
                            j.HasKey("MainProductId", "AttachedProductId");
                            j.ToTable("AttachedProduct");
                            j.IndexerProperty<int>("MainProductId").HasColumnName("MainProductID");
                            j.IndexerProperty<int>("AttachedProductId").HasColumnName("AttachedProductID");
                        });
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("ProductPhoto");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.PhotoPath).HasMaxLength(1000);
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPhoto_Product");
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.ToTable("ProductSale");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.HasOne(d => d.ClientService).WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.ClientServiceId)
                    .HasConstraintName("FK_ProductSale_ClientService");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Product");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Cost).HasColumnType("money");
                entity.Property(e => e.MainImagePath).HasMaxLength(1000);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<ServicePhoto>(entity =>
            {
                entity.ToTable("ServicePhoto");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.PhotoPath).HasMaxLength(1000);
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service).WithMany(p => p.ServicePhotos)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePhoto_Service");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Color)
                    .HasMaxLength(6)
                    .IsFixedLength();
                entity.Property(e => e.Title).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.LastEnter).HasColumnType("date");
                entity.Property(e => e.Login).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
