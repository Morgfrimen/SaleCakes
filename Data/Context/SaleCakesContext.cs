using System;
using System.Collections.Generic;
using Data.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Context
{
    public partial class SaleCakesContext : DbContext
    {
        public SaleCakesContext()
        {
        }

        public SaleCakesContext(DbContextOptions<SaleCakesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUserEntry> AppUsers { get; set; } = null!;
        public virtual DbSet<AuthorizationUserEntry> AuthorizationUsers { get; set; } = null!;
        public virtual DbSet<CakeEntry> Cakes { get; set; } = null!;
        public virtual DbSet<ClientEntry> Clients { get; set; } = null!;
        public virtual DbSet<DecorEntry> Decors { get; set; } = null!;
        public virtual DbSet<EmployeeEntry> Employees { get; set; } = null!;
        public virtual DbSet<OrderClientEntry> OrderClients { get; set; } = null!;
        public virtual DbSet<ShortcakeEntry> Shortcakes { get; set; } = null!;
        public virtual DbSet<StuffingEntry> Stuffings { get; set; } = null!;
        public virtual DbSet<TierEntry> Tiers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MORGFRIMENPC\\SQLEXPRESS;Initial Catalog=SaleCakes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserEntry>(entity =>
            {
                entity.ToTable("app_users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            modelBuilder.Entity<AuthorizationUserEntry>(entity =>
            {
                entity.ToTable("authorization_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt");

                entity.Property(e => e.UserGuid).HasColumnName("user_guid");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.AuthorizationUsers)
                    .HasForeignKey(d => d.UserGuid)
                    .HasConstraintName("FK__authoriza__user___3A81B327");
            });

            modelBuilder.Entity<CakeEntry>(entity =>
            {
                entity.ToTable("cake");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Tiers).HasColumnName("tiers");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.TiersEntryNavigation)
                    .WithMany(p => p.Cakes)
                    .HasForeignKey(d => d.Tiers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cake__tiers__4CA06362");
            });

            modelBuilder.Entity<ClientEntry>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("client_email");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("client_name");

                entity.Property(e => e.ClientOrders).HasColumnName("client_orders");

                entity.Property(e => e.ClientPatronymic)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("client_patronymic");

                entity.Property(e => e.ClientPhone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("client_phone");

                entity.Property(e => e.ClientSurname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("client_surname");

                entity.HasOne(d => d.ClientOrdersNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientOrders)
                    .HasConstraintName("FK__client__client_o__5629CD9C");
            });

            modelBuilder.Entity<DecorEntry>(entity =>
            {
                entity.ToTable("decor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<EmployeeEntry>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.AutorizedData, "UQ__employee__131C23AE1E86D60F")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AutorizedData).HasColumnName("autorized_data");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("employee_email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("employee_name");

                entity.Property(e => e.EmployeePatronymic)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("employee_patronymic");

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("employee_phone");

                entity.Property(e => e.EmployeeSurname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("employee_surname");

                entity.HasOne(d => d.AutorizedDataNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<EmployeeEntry>(d => d.AutorizedData)
                    .HasConstraintName("FK__employee__autori__5AEE82B9");
            });

            modelBuilder.Entity<OrderClientEntry>(entity =>
            {
                entity.ToTable("order_client");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderAdress)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("order_adress");

                entity.Property(e => e.OrderCake).HasColumnName("order_cake");

                entity.Property(e => e.OrderCondites).HasColumnName("order_condites");

                entity.Property(e => e.OrderCreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("order_createdAt");

                entity.Property(e => e.OrderEmoloyee).HasColumnName("order_emoloyee");

                entity.Property(e => e.OrderSeller)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("order_seller");

                entity.HasOne(d => d.OrderCakeNavigation)
                    .WithMany(p => p.OrderClients)
                    .HasForeignKey(d => d.OrderCake)
                    .HasConstraintName("FK__order_cli__order__5070F446");

                entity.HasOne(d => d.OrderConditesNavigation)
                    .WithMany(p => p.OrderClientOrderConditesNavigations)
                    .HasForeignKey(d => d.OrderCondites)
                    .HasConstraintName("FK__order_cli__order__5165187F");

                entity.HasOne(d => d.OrderEmoloyeeNavigation)
                    .WithMany(p => p.OrderClientOrderEmoloyeeNavigations)
                    .HasForeignKey(d => d.OrderEmoloyee)
                    .HasConstraintName("FK__order_cli__order__52593CB8");
            });

            modelBuilder.Entity<ShortcakeEntry>(entity =>
            {
                entity.ToTable("shortcake");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<StuffingEntry>(entity =>
            {
                entity.ToTable("stuffing");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<TierEntry>(entity =>
            {
                entity.ToTable("tiers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Decor).HasColumnName("decor");

                entity.Property(e => e.Shortcake).HasColumnName("shortcake");

                entity.Property(e => e.Stuffing).HasColumnName("stuffing");

                entity.HasOne(d => d.DecorNavigation)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.Decor)
                    .HasConstraintName("FK__tiers__decor__47DBAE45");

                entity.HasOne(d => d.ShortcakeNavigation)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.Shortcake)
                    .HasConstraintName("FK__tiers__shortcake__48CFD27E");

                entity.HasOne(d => d.StuffingNavigation)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.Stuffing)
                    .HasConstraintName("FK__tiers__stuffing__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
