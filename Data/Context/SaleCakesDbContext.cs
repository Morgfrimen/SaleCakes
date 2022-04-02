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
        _ = modelBuilder.Entity<AppUserEntry>(entity =>
        {
            _ = entity.ToTable("app_users");

            _ = entity.HasIndex(e => e.UserRole, "UQ__app_user__68057FED8DA7F0EF")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.UserRole)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("user_role");
        });

        _ = modelBuilder.Entity<AuthorizationUserEntry>(entity =>
        {
            _ = entity.ToTable("authorization_user");

            _ = entity.HasIndex(e => e.UserLogin, "UQ__authoriz__9EA1B5AFB2ACD5DC")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("createdAt");

            _ = entity.Property(e => e.UserGuid).HasColumnName("user_guid");

            _ = entity.Property(e => e.UserLogin)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("user_login");

            _ = entity.Property(e => e.UserPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_password");

            _ = entity.HasOne(d => d.UserGu)
                .WithMany(p => p.AuthorizationUsers)
                .HasForeignKey(d => d.UserGuid)
                .HasConstraintName("FK__authoriza__user___3C69FB99");
        });

        _ = modelBuilder.Entity<CakeEntry>(entity =>
        {
            _ = entity.ToTable("cake");

            _ = entity.HasIndex(e => e.Name, "UQ__cake__72E12F1B2489319B")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            _ = entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("weight");
        });

        _ = modelBuilder.Entity<CakeDesign>(entity =>
        {
            _ = entity.ToTable("cakeDesign");

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.CakeId).HasColumnName("cakeId");

            _ = entity.Property(e => e.TierId).HasColumnName("tierId");

            _ = entity.HasOne(d => d.Cake)
                .WithMany(p => p.CakeDesigns)
                .HasForeignKey(d => d.CakeId)
                .HasConstraintName("FK__cakeDesig__cakeI__656C112C");

            _ = entity.HasOne(d => d.Tier)
                .WithMany(p => p.CakeDesigns)
                .HasForeignKey(d => d.TierId)
                .HasConstraintName("FK__cakeDesig__tierI__66603565");
        });

        _ = modelBuilder.Entity<ClientEntry>(entity =>
        {
            _ = entity.ToTable("client");

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.ClientEmail)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("client_email");

            _ = entity.Property(e => e.ClientName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("client_name");

            _ = entity.Property(e => e.ClientOrders).HasColumnName("client_orders");

            _ = entity.Property(e => e.ClientPatronymic)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("client_patronymic");

            _ = entity.Property(e => e.ClientPhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("client_phone");

            _ = entity.Property(e => e.ClientSurname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("client_surname");

            _ = entity.HasOne(d => d.ClientOrdersNavigation)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientOrders)
                .HasConstraintName("FK__client__client_o__5AEE82B9");
        });

        _ = modelBuilder.Entity<ClientDesign>(entity =>
        {
            _ = entity.ToTable("clientDesign");

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.ClientId).HasColumnName("clientId");

            _ = entity.Property(e => e.OrderId).HasColumnName("orderId");

            _ = entity.HasOne(d => d.Client)
                .WithMany(p => p.ClientDesigns)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__clientDes__clien__6A30C649");

            _ = entity.HasOne(d => d.Order)
                .WithMany(p => p.ClientDesigns)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__clientDes__order__6B24EA82");
        });

        _ = modelBuilder.Entity<DecorEntry>(entity =>
        {
            _ = entity.ToTable("decor");

            _ = entity.HasIndex(e => e.Name, "UQ__decor__72E12F1B60B27930")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            _ = entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
        });

        _ = modelBuilder.Entity<EmployeeEntry>(entity =>
        {
            _ = entity.ToTable("employee");

            _ = entity.HasIndex(e => e.EmployeeEmail, "UQ__employee__0A874BCF1F9A6B7B")
                .IsUnique();

            _ = entity.HasIndex(e => e.AutorizedData, "UQ__employee__131C23AE115BDCB0")
                .IsUnique();

            _ = entity.HasIndex(e => e.EmployeePhone, "UQ__employee__A10A0FADECE93707")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.AutorizedData).HasColumnName("autorized_data");

            _ = entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employee_email");

            _ = entity.Property(e => e.EmployeeName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employee_name");

            _ = entity.Property(e => e.EmployeePatronymic)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employee_patronymic");

            _ = entity.Property(e => e.EmployeePhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("employee_phone");

            _ = entity.Property(e => e.EmployeeSurname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("employee_surname");

            _ = entity.Property(e => e.IsWork).HasColumnName("isWork");

            _ = entity.HasOne(d => d.AutorizedDataNavigation)
                .WithOne(p => p.Employee)
                .HasForeignKey<EmployeeEntry>(d => d.AutorizedData)
                .HasConstraintName("FK__employee__autori__619B8048");
        });

        _ = modelBuilder.Entity<OrderClientEntry>(entity =>
        {
            _ = entity.ToTable("order_client");

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.OrderAdress)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("order_adress");

            _ = entity.Property(e => e.OrderCake).HasColumnName("order_cake");

            _ = entity.Property(e => e.OrderCondites).HasColumnName("order_condites");

            _ = entity.Property(e => e.OrderCreatedAt)
                .HasColumnType("date")
                .HasColumnName("order_createdAt");

            _ = entity.Property(e => e.OrderEmoloyee).HasColumnName("order_emoloyee");

            _ = entity.Property(e => e.OrderSeller)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("order_seller");

            _ = entity.HasOne(d => d.OrderCakeNavigation)
                .WithMany(p => p.OrderClients)
                .HasForeignKey(d => d.OrderCake)
                .HasConstraintName("FK__order_cli__order__5535A963");

            _ = entity.HasOne(d => d.OrderConditesNavigation)
                .WithMany(p => p.OrderClientOrderConditesNavigations)
                .HasForeignKey(d => d.OrderCondites)
                .HasConstraintName("FK__order_cli__order__5629CD9C");

            _ = entity.HasOne(d => d.OrderEmoloyeeNavigation)
                .WithMany(p => p.OrderClientOrderEmoloyeeNavigations)
                .HasForeignKey(d => d.OrderEmoloyee)
                .HasConstraintName("FK__order_cli__order__571DF1D5");
        });

        _ = modelBuilder.Entity<ShortcakeEntry>(entity =>
        {
            _ = entity.ToTable("shortcake");

            _ = entity.HasIndex(e => e.Name, "UQ__shortcak__72E12F1BA5D3FC4A")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            _ = entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
        });

        _ = modelBuilder.Entity<StuffingEntry>(entity =>
        {
            _ = entity.ToTable("stuffing");

            _ = entity.HasIndex(e => e.Name, "UQ__stuffing__72E12F1B5ECB5124")
                .IsUnique();

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            _ = entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
        });

        _ = modelBuilder.Entity<TierEntry>(entity =>
        {
            _ = entity.ToTable("tiers");

            _ = entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("(newid())");

            _ = entity.Property(e => e.Decor).HasColumnName("decor");

            _ = entity.Property(e => e.Shortcake).HasColumnName("shortcake");

            _ = entity.Property(e => e.Stuffing).HasColumnName("stuffing");

            _ = entity.HasOne(d => d.DecorEntry)
                .WithMany(p => p.Tiers)
                .HasForeignKey(d => d.Decor)
                .HasConstraintName("FK__tiers__decor__4CA06362");

            _ = entity.HasOne(d => d.ShortcakeEntry)
                .WithMany(p => p.Tiers)
                .HasForeignKey(d => d.Shortcake)
                .HasConstraintName("FK__tiers__shortcake__4D94879B");

            _ = entity.HasOne(d => d.StuffingEntry)
                .WithMany(p => p.Tiers)
                .HasForeignKey(d => d.Stuffing)
                .HasConstraintName("FK__tiers__stuffing__4BAC3F29");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    //private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    //{
    //    throw new NotImplementedException();
    //}
}