using Data.Entries;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class SaleCakesDbContext : DbContext
{
    public SaleCakesDbContext()
    {
    }

    public SaleCakesDbContext(DbContextOptions<SaleCakesDbContext> options)
        : base(options)
    {
    }

    internal virtual DbSet<AppUserEntry> AppUsersEntries { get; set; } = null!;
    internal virtual DbSet<AuthorizationUserEntry> AuthorizationUsersEntries { get; set; } = null!;
    internal virtual DbSet<CakeEntry> CakesEntries { get; set; } = null!;
    internal virtual DbSet<CakeDesign> CakeDesignsEntries { get; set; } = null!;
    internal virtual DbSet<ClientEntry> ClientsEntries { get; set; } = null!;
    internal virtual DbSet<ClientDesign> ClientDesignsEntries { get; set; } = null!;
    internal virtual DbSet<DecorEntry> DecorsEntries { get; set; } = null!;
    internal virtual DbSet<EmployeeEntry> EmployeesEntries { get; set; } = null!;
    internal virtual DbSet<OrderClientEntry> OrderClientsEntries { get; set; } = null!;
    internal virtual DbSet<ShortcakeEntry> ShortcakesEntries { get; set; } = null!;
    internal virtual DbSet<StuffingEntry> StuffingsEntries { get; set; } = null!;
    internal virtual DbSet<TierEntry> TiersEntries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUserEntry>(entity =>
        {
            entity.ToTable("app_users");

            entity.HasIndex(e => e.UserRole, "UQ__app_user__68057FED8DA7F0EF")
                .IsUnique();

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

            entity.HasIndex(e => e.UserLogin, "UQ__authoriz__9EA1B5AFB2ACD5DC")
                .IsUnique();

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
                .HasConstraintName("FK__authoriza__user___3C69FB99");
        });

        modelBuilder.Entity<CakeEntry>(entity =>
        {
            entity.ToTable("cake");

            entity.HasIndex(e => e.Name, "UQ__cake__72E12F1B2489319B")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<CakeDesign>(entity =>
        {
            entity.ToTable("cakeDesign");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CakeId).HasColumnName("cakeId");

            entity.Property(e => e.TierId).HasColumnName("tierId");

            entity.HasOne(d => d.Cake)
                .WithMany(p => p.CakeDesigns)
                .HasForeignKey(d => d.CakeId)
                .HasConstraintName("FK__cakeDesig__cakeI__656C112C");

            entity.HasOne(d => d.Tier)
                .WithMany(p => p.CakeDesigns)
                .HasForeignKey(d => d.TierId)
                .HasConstraintName("FK__cakeDesig__tierI__66603565");
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
                .HasConstraintName("FK__client__client_o__5AEE82B9");
        });

        modelBuilder.Entity<ClientDesign>(entity =>
        {
            entity.ToTable("clientDesign");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.ClientId).HasColumnName("clientId");

            entity.Property(e => e.OrderId).HasColumnName("orderId");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.ClientDesigns)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__clientDes__clien__6A30C649");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.ClientDesigns)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__clientDes__order__6B24EA82");
        });

        modelBuilder.Entity<DecorEntry>(entity =>
        {
            entity.ToTable("decor");

            entity.HasIndex(e => e.Name, "UQ__decor__72E12F1B60B27930")
                .IsUnique();

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

            entity.HasIndex(e => e.EmployeeEmail, "UQ__employee__0A874BCF1F9A6B7B")
                .IsUnique();

            entity.HasIndex(e => e.AutorizedData, "UQ__employee__131C23AE115BDCB0")
                .IsUnique();

            entity.HasIndex(e => e.EmployeePhone, "UQ__employee__A10A0FADECE93707")
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

            entity.Property(e => e.IsWork).HasColumnName("isWork");

            entity.HasOne(d => d.AutorizedDataNavigation)
                .WithOne(p => p.Employee)
                .HasForeignKey<EmployeeEntry>(d => d.AutorizedData)
                .HasConstraintName("FK__employee__autori__619B8048");
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
                .HasConstraintName("FK__order_cli__order__5535A963");

            entity.HasOne(d => d.OrderConditesNavigation)
                .WithMany(p => p.OrderClientOrderConditesNavigations)
                .HasForeignKey(d => d.OrderCondites)
                .HasConstraintName("FK__order_cli__order__5629CD9C");

            entity.HasOne(d => d.OrderEmoloyeeNavigation)
                .WithMany(p => p.OrderClientOrderEmoloyeeNavigations)
                .HasForeignKey(d => d.OrderEmoloyee)
                .HasConstraintName("FK__order_cli__order__571DF1D5");
        });

        modelBuilder.Entity<ShortcakeEntry>(entity =>
        {
            entity.ToTable("shortcake");

            entity.HasIndex(e => e.Name, "UQ__shortcak__72E12F1BA5D3FC4A")
                .IsUnique();

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

            entity.HasIndex(e => e.Name, "UQ__stuffing__72E12F1B5ECB5124")
                .IsUnique();

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
                .HasConstraintName("FK__tiers__decor__4CA06362");

            entity.HasOne(d => d.ShortcakeNavigation)
                .WithMany(p => p.Tiers)
                .HasForeignKey(d => d.Shortcake)
                .HasConstraintName("FK__tiers__shortcake__4D94879B");

            entity.HasOne(d => d.StuffingNavigation)
                .WithMany(p => p.Tiers)
                .HasForeignKey(d => d.Stuffing)
                .HasConstraintName("FK__tiers__stuffing__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}