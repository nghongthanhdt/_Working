//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DienBienQuaTrinhLuong
    {
        public int MaDienBienQuaTrinhLuong { get; set; }
        public int MaLyLichVienChuc { get; set; }
        public int MaChucDanhNgheNghiep { get; set; }
        public Nullable<int> BacLuong { get; set; }
        public Nullable<decimal> HeSo { get; set; }
        public Nullable<System.DateTime> NgayHuong { get; set; }
        public Nullable<decimal> PhuCapChucVu { get; set; }
        public Nullable<decimal> PhuCapKhac { get; set; }
        public Nullable<int> VuotKhung { get; set; }
        public Nullable<int> Nhap_MaNhanVien { get; set; }
        public Nullable<System.DateTime> Nhap_Ngay { get; set; }
        public Nullable<int> CapNhat_MaNhanVien { get; set; }
        public Nullable<System.DateTime> CapNhat_Ngay { get; set; }
        public bool Xoa { get; set; }
        public Nullable<int> Xoa_MaNhanVien { get; set; }
        public Nullable<System.DateTime> Xoa_Ngay { get; set; }
    
        public virtual ChucDanhNgheNghiep ChucDanhNgheNghiep { get; set; }
        public virtual LyLichVienChuc LyLichVienChuc { get; set; }
    }
}
