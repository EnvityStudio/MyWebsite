namespace MyWebsite.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BLOG> BLOGs { get; set; }
        public virtual DbSet<DANH_MUC> DANH_MUC { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<DON_HANG_CT> DON_HANG_CT { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LIEN_HE> LIEN_HE { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<BLOG>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<DANH_MUC>()
                .HasMany(e => e.SAN_PHAM)
                .WithRequired(e => e.DANH_MUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.DON_HANG_CT)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.DON_HANG)
                .WithRequired(e => e.KHACH_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LIEN_HE>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<LIEN_HE>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SAN_PHAM>()
                .Property(e => e.ChiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.DON_HANG_CT)
                .WithRequired(e => e.SAN_PHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
