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
    
    public partial class SoKSK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoKSK()
        {
            this.LuotKSK = new HashSet<LuotKSK>();
        }
    
        public int MaSoKSK { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public Nullable<int> NamSinh { get; set; }
        public string SoCMND { get; set; }
        public Nullable<System.DateTime> NgayCapCMND { get; set; }
        public string NoiCapCMND { get; set; }
        public string HoKhauThuongTru { get; set; }
        public string ChoOHienTai { get; set; }
        public string NgheNghiep { get; set; }
        public string NoiCongTacHocTap { get; set; }
        public Nullable<System.DateTime> NgayBatDauHocTapLamviec { get; set; }
        public string NgheCongViecTruocDay { get; set; }
        public string TienSuBenhTatCuaGiaDinh { get; set; }
        public string TienSuBanThan { get; set; }
        public string LapSoKSK_NoiKy { get; set; }
        public Nullable<System.DateTime> LapSoKSK_NgayKy { get; set; }
        public string LapSoKSK_NguoiKy { get; set; }
        public Nullable<int> MaNhanVienNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<bool> Xoa { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotKSK> LuotKSK { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
