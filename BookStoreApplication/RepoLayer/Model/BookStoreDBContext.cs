using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepoLayer.Model
{
    public partial class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
        {
        }

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrdersSummary> OrdersSummary { get; set; }
        public virtual DbSet<PriceDetail> PriceDetail { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Address__UserID__3B75D760");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Books__3DE0C2277BC4AA78");

                entity.Property(e => e.Author).IsUnicode(false);

                entity.Property(e => e.Images).IsUnicode(false);

                entity.Property(e => e.Isbn).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__OrderDet__D3B9D30C1041AD95");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__OrderDeta__BookI__3E52440B");
            });

            modelBuilder.Entity<OrdersSummary>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrdersSu__C3905BCFD047D56F");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.OrdersSummary)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__OrdersSum__Addre__45F365D3");

                entity.HasOne(d => d.PriceDetail)
                    .WithMany(p => p.OrdersSummary)
                    .HasForeignKey(d => d.PriceDetailId)
                    .HasConstraintName("FK__OrdersSum__Price__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrdersSummary)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__OrdersSum__UserI__44FF419A");
            });

            modelBuilder.Entity<PriceDetail>(entity =>
            {
                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.PriceDetail)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK__PriceDeta__Total__412EB0B6");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC2ED2FAA2");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
