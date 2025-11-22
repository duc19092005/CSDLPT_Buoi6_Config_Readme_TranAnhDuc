using System;
using System.Collections.Generic;
using CSDLPT_Tuan6_API.Dtos;
using CSDLPT_Tuan6_API.Entities;
using CSDLPT_Tuan6_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSDLPT_Tuan6_API.Context;

public partial class MyDbContext2 : DbContext , IDBContext
{
    public MyDbContext2()
    {
    }

    public MyDbContext2(DbContextOptions<MyDbContext2> options)
        : base(options)
    {
    }

    public virtual DbSet<SanphamManh2> SanphamManh2s { get; set; }
    
    public List<DbContextDtos> getAllDatabases()
    {
        return SanphamManh2s.Select(x => new DbContextDtos()
        {
            maSanPham = x.Masanpham,
            giaBan = x.Giaban,
            maKhoHang = x.Makhohang
        }).ToList();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SanphamManh2>(entity =>
        {
            entity.HasKey(e => e.Masanpham).HasName("PK_SANPHAMM2");

            entity.ToTable("SANPHAM_MANH2", tb =>
                {
                    tb.HasTrigger("MSmerge_del_B8381EF9D4FF454580A2C634E9D3D963");
                    tb.HasTrigger("MSmerge_ins_B8381EF9D4FF454580A2C634E9D3D963");
                    tb.HasTrigger("MSmerge_upd_B8381EF9D4FF454580A2C634E9D3D963");
                });

            entity.HasIndex(e => e.Rowguid, "MSmerge_index_933578364").IsUnique();

            entity.Property(e => e.Masanpham)
                .ValueGeneratedNever()
                .HasColumnName("MASANPHAM");
            entity.Property(e => e.Giaban).HasColumnName("GIABAN");
            entity.Property(e => e.Makhohang).HasColumnName("MAKHOHANG");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
