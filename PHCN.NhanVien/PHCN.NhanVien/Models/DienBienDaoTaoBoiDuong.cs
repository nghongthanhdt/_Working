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
    
    public partial class DienBienDaoTaoBoiDuong
    {
        public int MaDienBienDaoTaoBoiDuong { get; set; }
        public int MaLyLichVienChuc { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganhDaoTaoBoiDuong { get; set; }
        public Nullable<System.DateTime> TuThangNam { get; set; }
        public Nullable<System.DateTime> DenThangNam { get; set; }
        public Nullable<int> MaHinhThucDaoTao { get; set; }
        public string VanBangChungChiTrinhDo { get; set; }
    
        public virtual LyLichVienChuc LyLichVienChuc { get; set; }
        public virtual HinhThucDaoTao HinhThucDaoTao { get; set; }
    }
}
