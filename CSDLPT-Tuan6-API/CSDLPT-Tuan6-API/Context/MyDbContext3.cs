using System;
using System.Collections.Generic;
using CSDLPT_Tuan6_API.Dtos;
using CSDLPT_Tuan6_API.Entities;
using CSDLPT_Tuan6_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSDLPT_Tuan6_API.Context;

public partial class MyDbContext3 : DbContext , IDBContext
{
    public MyDbContext3()
    {
    }

    public MyDbContext3(DbContextOptions<MyDbContext3> options)
        : base(options)
    {
    }

    public virtual DbSet<SanphamManh3> SanphamManh3s { get; set; }

    public List<DbContextDtos> getAllDatabases()
    {
        return SanphamManh3s.Select(x => new DbContextDtos()
        {
            maSanPham = x.Masanpham,
            giaBan = x.Giaban,
            maKhoHang = x.Makhohang,
            tenSanPham = x.Tensanpham
        }).ToList();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SanphamManh3>(entity =>
        {
            entity.HasKey(e => e.Masanpham).HasName("PK_SANPHAM");

            entity.ToTable("SANPHAM_MANH3", tb =>
                {
                    tb.HasTrigger("MSmerge_del_0943EB9C659D4D67B83D0518197D79F5");
                    tb.HasTrigger("MSmerge_ins_0943EB9C659D4D67B83D0518197D79F5");
                    tb.HasTrigger("MSmerge_upd_0943EB9C659D4D67B83D0518197D79F5");
                });

            entity.HasIndex(e => e.Rowguid, "MSmerge_index_965578478").IsUnique();

            entity.Property(e => e.Masanpham)
                .ValueGeneratedNever()
                .HasColumnName("MASANPHAM");
            entity.Property(e => e.Giaban).HasColumnName("GIABAN");
            entity.Property(e => e.Makhohang).HasColumnName("MAKHOHANG");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(100)
                .HasColumnName("TENSANPHAM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
