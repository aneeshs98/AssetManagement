using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class AssetDBContext : DbContext
    {
        

        public AssetDBContext(DbContextOptions<AssetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAssetDefinition> TblAssetDefinition { get; set; }
        public virtual DbSet<TblAssetMaster> TblAssetMaster { get; set; }
        public virtual DbSet<TblAssetType> TblAssetType { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual DbSet<TblUserRegistration> TblUserRegistration { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAssetDefinition>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__TblAsset__CAA5BA0F978BCF01");

                entity.Property(e => e.AdId).HasColumnName("ad_id");

                entity.Property(e => e.AdClass)
                    .HasColumnName("ad_class")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdName)
                    .HasColumnName("ad_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AdTypeId).HasColumnName("ad_type_id");

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.TblAssetDefinition)
                    .HasForeignKey(d => d.AdTypeId)
                    .HasConstraintName("FK_ASSET");
            });

            modelBuilder.Entity<TblAssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__TblAsset__B95A8ED035DD38DD");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId).HasColumnName("am_ad_id");

                entity.Property(e => e.AmAtypeId).HasColumnName("am_atype_id");

                entity.Property(e => e.AmFrom)
                    .HasColumnName("am_from")
                    .HasColumnType("date");

                entity.Property(e => e.AmMakeId).HasColumnName("am_make_id");

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

                entity.Property(e => e.AmWarranty)
                    .HasColumnName("am_warranty")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AmAd)
                    .WithMany(p => p.TblAssetMaster)
                    .HasForeignKey(d => d.AmAdId)
                    .HasConstraintName("FK_ASSET_AD");

                entity.HasOne(d => d.AmAtype)
                    .WithMany(p => p.TblAssetMaster)
                    .HasForeignKey(d => d.AmAtypeId)
                    .HasConstraintName("FK_ASSET_AT");

                entity.HasOne(d => d.AmMake)
                    .WithMany(p => p.TblAssetMaster)
                    .HasForeignKey(d => d.AmMakeId)
                    .HasConstraintName("FK_ASSET_V");
            });

            modelBuilder.Entity<TblAssetType>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__TblAsset__61F85988DF3E0E88");

                entity.Property(e => e.AtId).HasColumnName("at_id");

                entity.Property(e => e.AtName)
                    .HasColumnName("at_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__TblLogin__A7C7B6F838981704");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK__TblPurch__F7562CCFCBFA82AF");

                entity.Property(e => e.PdId).HasColumnName("pd_id");

                entity.Property(e => e.PdAdId).HasColumnName("pd_ad_id");

                entity.Property(e => e.PdDate)
                    .HasColumnName("pd_date")
                    .HasColumnType("date");

                entity.Property(e => e.PdDdate)
                    .HasColumnName("pd_ddate")
                    .HasColumnType("date");

                entity.Property(e => e.PdOrderNo)
                    .HasColumnName("pd_order_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PdQty).HasColumnName("pd_qty");

                entity.Property(e => e.PdStatus)
                    .HasColumnName("pd_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PdTypeId).HasColumnName("pd_type_id");

                entity.Property(e => e.PdVendorId).HasColumnName("pd_vendor_id");

                entity.HasOne(d => d.PdAd)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.PdAdId)
                    .HasConstraintName("FK_PURCHASE_AD");

                entity.HasOne(d => d.PdType)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.PdTypeId)
                    .HasConstraintName("FK_PURCHASE_AT");

                entity.HasOne(d => d.PdVendor)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.PdVendorId)
                    .HasConstraintName("FK_PURCHASE_V");
            });

            modelBuilder.Entity<TblUserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__TblUserR__B51D3DEA9B90B209");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.TblUserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_LOGIN");
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.VdId)
                    .HasName("PK__TblVendo__277BC6C005D86070");

                entity.Property(e => e.VdId).HasColumnName("vd_id");

                entity.Property(e => e.VdAddr)
                    .HasColumnName("vd_addr")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VdAtypeId).HasColumnName("vd_atype_id");

                entity.Property(e => e.VdFrom)
                    .HasColumnName("vd_from")
                    .HasColumnType("date");

                entity.Property(e => e.VdName)
                    .HasColumnName("vd_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VdTo)
                    .HasColumnName("vd_to")
                    .HasColumnType("date");

                entity.Property(e => e.VdType)
                    .HasColumnName("vd_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.VdAtype)
                    .WithMany(p => p.TblVendor)
                    .HasForeignKey(d => d.VdAtypeId)
                    .HasConstraintName("FK_VENDOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
