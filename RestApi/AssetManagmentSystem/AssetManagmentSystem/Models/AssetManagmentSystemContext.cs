using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagmentSystem.Models
{
    public partial class AssetManagmentSystemContext : DbContext
    {
        public AssetManagmentSystemContext()
        {
        }

        public AssetManagmentSystemContext(DbContextOptions<AssetManagmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=JUNAIDKV\\SQLEXPRESS;Initial Catalog=AssetManagmentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED0F151DE2A");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId)
                    .HasColumnName("am_ad_id")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.AmAtypeId)
                    .HasColumnName("am_atype_id")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmForm)
                    .HasColumnName("am_form")
                    .HasColumnType("date");

                entity.Property(e => e.AmMakeId)
                    .HasColumnName("am_make_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmMyyear)
                    .HasColumnName("am_myyear")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AmPdate)
                    .HasColumnName("am_pdate")
                    .HasColumnType("date");

                entity.Property(e => e.AmSnumber)
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTo)
                    .HasColumnName("am_to")
                    .HasColumnType("date");

                entity.Property(e => e.AmWaranty)
                    .HasColumnName("am_waranty")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F8ECF2F894");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEA0D0F21AB");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UserRegist__l_id__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
