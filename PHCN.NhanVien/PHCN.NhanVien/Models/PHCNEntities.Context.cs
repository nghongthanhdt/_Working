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
    
        public virtual DbSet<KhoaPhong> KhoaPhong { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public virtual DbSet<Loi> Loi { get; set; }
        public virtual DbSet<GuiNhan> GuiNhan { get; set; }
        public virtual DbSet<ThamSoHeThong> ThamSoHeThong { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<ChucDanhNgheNghiep> ChucDanhNgheNghiep { get; set; }
        public virtual DbSet<DanToc> DanToc { get; set; }
        public virtual DbSet<DonVi> DonVi { get; set; }
        public virtual DbSet<HuyenThi> HuyenThi { get; set; }
        public virtual DbSet<LoaiHopDong> LoaiHopDong { get; set; }
        public virtual DbSet<TinhThanh> TinhThanh { get; set; }
        public virtual DbSet<TonGiao> TonGiao { get; set; }
        public virtual DbSet<XaPhuong> XaPhuong { get; set; }
        public virtual DbSet<DienBienQuaTrinhLuong> DienBienQuaTrinhLuong { get; set; }
        public virtual DbSet<DienBienDaoTaoBoiDuong> DienBienDaoTaoBoiDuong { get; set; }
        public virtual DbSet<HinhThucDaoTao> HinhThucDaoTao { get; set; }
        public virtual DbSet<DienBienQuaTrinhCongTac> DienBienQuaTrinhCongTac { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<ChuyenMon> ChuyenMon { get; set; }
        public virtual DbSet<HocHam> HocHam { get; set; }
        public virtual DbSet<HocVi> HocVi { get; set; }
        public virtual DbSet<ChinhQuyen> ChinhQuyen { get; set; }
        public virtual DbSet<Dang> Dang { get; set; }
        public virtual DbSet<DoanThe> DoanThe { get; set; }
        public virtual DbSet<MaCCHN> MaCCHN { get; set; }
        public virtual DbSet<PhamViHoatDongChuyenMon> PhamViHoatDongChuyenMon { get; set; }
        public virtual DbSet<NgheNghiep> NgheNghiep { get; set; }
        public virtual DbSet<BoSungPhamViHDCM> BoSungPhamViHDCM { get; set; }
        public virtual DbSet<BaiViet> BaiViet { get; set; }
        public virtual DbSet<FileDinhKem> FileDinhKem { get; set; }
        public virtual DbSet<BaiVietWeb> BaiVietWeb { get; set; }
        public virtual DbSet<HinhAnh> HinhAnh { get; set; }
        public virtual DbSet<LyLichVienChuc> LyLichVienChuc { get; set; }
        public virtual DbSet<ChuyenMuc> ChuyenMuc { get; set; }
        public virtual DbSet<SoKSK> SoKSK { get; set; }
    }
}
