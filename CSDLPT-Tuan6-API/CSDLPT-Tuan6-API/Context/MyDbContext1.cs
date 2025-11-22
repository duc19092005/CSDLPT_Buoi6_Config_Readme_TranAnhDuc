using System;
using System.Collections.Generic;
using CSDLPT_Tuan6_API.Dtos;
using CSDLPT_Tuan6_API.Entities;
using CSDLPT_Tuan6_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSDLPT_Tuan6_API.Context;

public partial class MyDbContext1 : DbContext , IDBContext
{
    public MyDbContext1()
    {
    }

    public MyDbContext1(DbContextOptions<MyDbContext1> options)
        : base(options)
    {
    }

    public virtual DbSet<SanphamManh1> SanphamManh1s { get; set; }

    public List<DbContextDtos> getAllDatabases()
    {
        return SanphamManh1s.Select(x => new DbContextDtos()
        {
            maSanPham = x.Masanpham,
            tenSanPham = x.Tensanpham
        }).ToList();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SanphamManh1>(entity =>
        {
            entity.HasKey(e => e.Masanpham).HasName("PK_SANPHAMM1");

            entity.ToTable("SANPHAM_MANH1", tb =>
                {
                    tb.HasTrigger("MSmerge_del_13C2632D122A4BA39093217E5EB0241C");
                    tb.HasTrigger("MSmerge_ins_13C2632D122A4BA39093217E5EB0241C");
                    tb.HasTrigger("MSmerge_upd_13C2632D122A4BA39093217E5EB0241C");
                });

            entity.HasIndex(e => e.Rowguid, "MSmerge_index_901578250").IsUnique();

            entity.Property(e => e.Masanpham)
                .ValueGeneratedNever()
                .HasColumnName("MASANPHAM");
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
