﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHCN.NhanVien.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PHCNEntities : DbContext
    {
        public PHCNEntities()
            : base("name=PHCNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GuiNhan> GuiNhan { get; set; }
        public virtual DbSet<KhoaPhong> KhoaPhong { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<BaiViet> BaiViet { get; set; }
        public virtual DbSet<Loi> Loi { get; set; }
        public virtual DbSet<FileDinhKem> FileDinhKem { get; set; }
    }
}