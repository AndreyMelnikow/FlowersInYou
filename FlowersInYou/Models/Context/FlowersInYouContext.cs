using FlowersInYou.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou;

public partial class FlowersInYouContext : DbContext
{
    public FlowersInYouContext()
    {
    }

    public FlowersInYouContext(DbContextOptions<FlowersInYouContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddedFlower> AddedFlower { get; set; }

    public virtual DbSet<Administrator> Administrator { get; set; }

    public virtual DbSet<Busket> Busket { get; set; }

    public virtual DbSet<BusketOrder> BusketOrder { get; set; }

    public virtual DbSet<Client> Client { get; set; }

    public virtual DbSet<Comment> Comment { get; set; }

    public virtual DbSet<CompletedOrder> CompletedOrder { get; set; }

    public virtual DbSet<ConfigurateProduct> ConfigurateProduct { get; set; }

    public virtual DbSet<ConfirmedOrder> ConfirmedOrder { get; set; }

    public virtual DbSet<Courier> Courier { get; set; }

    public virtual DbSet<Florist> Florist { get; set; }

    public virtual DbSet<Material> Material { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductType> ProductType { get; set; }

    public virtual DbSet<Size> Size { get; set; }

    public virtual DbSet<Storage> Storage { get; set; }

    public virtual DbSet<StorageProduct> StorageProduct { get; set; }

    public virtual DbSet<Zone> Zone { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5A00NSN\\SQLEXPRESS;Database=FlowersInYou;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddedFlower>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.ToTable("Administrator");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);

            entity.HasOne(d => d.IdStorageNavigation).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.IdStorage)
                .HasConstraintName("FK_Administrator_Storage");
        });

        modelBuilder.Entity<Busket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ConfigurateProductBusket");

            entity.ToTable("Busket");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Buskets)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigurateProductBusket_Client");

            entity.HasOne(d => d.IdConfigurateProductNavigation).WithMany(p => p.Buskets)
                .HasForeignKey(d => d.IdConfigurateProduct)
                .HasConstraintName("FK_ConfigurateProductBusket_ConfigurateProduct");
        });

        modelBuilder.Entity<BusketOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BuscketOrder");

            entity.ToTable("BusketOrder");

            entity.HasOne(d => d.IdBusketNavigation).WithMany(p => p.BusketOrders)
                .HasForeignKey(d => d.IdBuscket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BusketOrder_Busket");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.BusketOrder)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_BusketOrder_Order");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Comment_Client");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comment_Product");
        });

        modelBuilder.Entity<CompletedOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductsCompletedOrders");

            entity.ToTable("CompletedOrder");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdAddFlowerNavigation).WithMany(p => p.CompletedOrder)
                .HasForeignKey(d => d.IdAddFlower)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CompletedOrder_AddedFlowers");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.CompletedOrder)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CompletedOrder_Material");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.CompletedOrder)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_ProductsCompletedOrders_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.CompletedOrder)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_CompletedOrder_Product");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.CompletedOrder)
                .HasForeignKey(d => d.IdSize)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CompletedOrder_Size");
        });

        modelBuilder.Entity<ConfigurateProduct>(entity =>
        {
            entity.ToTable("ConfigurateProduct");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdAddFlowerNavigation).WithMany(p => p.ConfigurateProduct)
                .HasForeignKey(d => d.IdAddFlower)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ConfigurateProduct_AddedFlowers");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.ConfigurateProduct)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ConfigurateProduct_Material");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ConfigurateProduct)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_ConfigurateProduct_Product");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.ConfigurateProduct)
                .HasForeignKey(d => d.IdSize)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ConfigurateProduct_Size");
        });

        modelBuilder.Entity<ConfirmedOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ConfirmedOrders");

            entity.ToTable("ConfirmedOrder");

            entity.HasOne(d => d.IdCourierNavigation).WithMany(p => p.ConfirmedOrder)
                .HasForeignKey(d => d.IdCourier)
                .HasConstraintName("FK_ConfirmedOrders_Courier");

            entity.HasOne(d => d.IdFloristNavigation).WithMany(p => p.ConfirmedOrder)
                .HasForeignKey(d => d.IdFlorist)
                .HasConstraintName("FK_ConfirmedOrders_Florist");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ConfirmedOrder)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_ConfirmedOrders_Order");

            entity.HasOne(d => d.IdZoneNavigation).WithMany(p => p.ConfirmedOrder)
                .HasForeignKey(d => d.IdZone)
                .HasConstraintName("FK_ConfirmedOrders_Zones");
        });

        modelBuilder.Entity<Courier>(entity =>
        {
            entity.ToTable("Courier");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Florist>(entity =>
        {
            entity.ToTable("Florist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Material");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.StartPrice).HasColumnType("money");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.ToTable("Size");

            entity.Property(e => e.Size1).HasColumnName("Size");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.ToTable("Storage");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Capacity).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StorageProduct>(entity =>
        {
            entity.ToTable("StorageProduct");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.StorageProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_StorageProduct_Product");

            entity.HasOne(d => d.IdStorageNavigation).WithMany(p => p.StorageProducts)
                .HasForeignKey(d => d.IdStorage)
                .HasConstraintName("FK_StorageProduct_Storage");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.Property(e => e.ZoneCost).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
