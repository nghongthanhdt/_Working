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
    
    public partial class LyLichVienChuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LyLichVienChuc()
        {
            this.BoSungPhamViHDCM = new HashSet<BoSungPhamViHDCM>();
            this.DienBienDaoTaoBoiDuong = new HashSet<DienBienDaoTaoBoiDuong>();
            this.DienBienQuaTrinhCongTac = new HashSet<DienBienQuaTrinhCongTac>();
            this.DienBienQuaTrinhLuong = new HashSet<DienBienQuaTrinhLuong>();
        }
    
        public Nullable<int> MaNhanVien { get; set; }
        public int MaLyLichVienChuc { get; set; }
        public Nullable<int> MaDonVi { get; set; }
        public Nullable<int> MaDonViThamQuyenQuanLy { get; set; }
        public Nullable<int> MaLoaiHopDong { get; set; }
        public string SoHieuVienChuc { get; set; }
        public string HoTenKhaiSinh { get; set; }
        public string TenGoiKhac { get; set; }
        public Nullable<int> NgaySinh { get; set; }
        public Nullable<int> ThangSinh { get; set; }
        public Nullable<int> NamSinh { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public string NoiSinh_Xa { get; set; }
        public string NoiSinh_Huyen { get; set; }
        public string NoiSinh_Tinh { get; set; }
        public string QueQuan_Xa { get; set; }
        public string QueQuan_Huyen { get; set; }
        public string QueQuan_Tinh { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string NoiDangKyHKTT_SoNha { get; set; }
        public string NoiDangKyHKTT_Duong { get; set; }
        public string NoiDangKyHKTT_Xa { get; set; }
        public string NoiDangKyHKTT_Huyen { get; set; }
        public string NoiDangKyHKTT_Tinh { get; set; }
        public string NoiOHienNay_SoNha { get; set; }
        public string NoiOHienNay_Duong { get; set; }
        public string NoiOHienNay_Xa { get; set; }
        public string NoiOHienNay_Huyen { get; set; }
        public string NoiOHienNay_Tinh { get; set; }
        public string NgheNghiepKhiDuocTuyenDung { get; set; }
        public Nullable<System.DateTime> NgayTuyenDung { get; set; }
        public Nullable<int> MaCoQuanTuyenDung { get; set; }
        public Nullable<int> MaChinhQuyen { get; set; }
        public Nullable<int> MaDang { get; set; }
        public Nullable<int> MaDoanThe { get; set; }
        public Nullable<System.DateTime> NgayBoNhiemBoNhiemLai { get; set; }
        public string CongViecChinhDuocGiao { get; set; }
        public string TrinhDoGiaoDucPhoThong { get; set; }
        public string TrinhDoChuyenMonCaoNhat { get; set; }
        public Nullable<int> MaHocHam { get; set; }
        public Nullable<int> MaHocVi { get; set; }
        public Nullable<int> MaChuyenMon { get; set; }
        public string LyLuanChinhTri { get; set; }
        public string QuanLyNhaNuoc { get; set; }
        public string BoiDuongTheoTieuChuanCDNN { get; set; }
        public string NgoaiNgu { get; set; }
        public string TinHoc { get; set; }
        public string SoCCHN { get; set; }
        public string TenMaCCHN { get; set; }
        public Nullable<System.DateTime> NgayCapCCHN { get; set; }
        public string PhamViHoatDongChuyenMon { get; set; }
        public Nullable<System.DateTime> NgayVaoDangCSVN { get; set; }
        public Nullable<System.DateTime> NgayVaoDangCSVNChinhThuc { get; set; }
        public Nullable<System.DateTime> ToChucChinhTriXH_NgayThamGia { get; set; }
        public string ToChucChinhTriXH { get; set; }
        public Nullable<System.DateTime> NgayNhapNgu { get; set; }
        public Nullable<System.DateTime> NgayXuatNgu { get; set; }
        public string QuanHamCaoNhat { get; set; }
        public string DanhHieuDuocPhongTangCaoNhat { get; set; }
        public string SoTruongCongTac { get; set; }
        public string KhenThuong { get; set; }
        public string KyLuat { get; set; }
        public string TinhTrangSucKhoe { get; set; }
        public Nullable<decimal> ChieuCao { get; set; }
        public Nullable<int> CanNang { get; set; }
        public string NhomMau { get; set; }
        public string LaThuongBinhHang { get; set; }
        public string LaConGiaDinhChinhSach { get; set; }
        public string SoChungMinhNhanDan { get; set; }
        public Nullable<System.DateTime> NgayCap { get; set; }
        public string SoSoBHXH { get; set; }
        public string NhanXetDanhGiaCuaCoQuanDonVi { get; set; }
        public string NguoiKhai { get; set; }
        public string ThuTruongKyTen { get; set; }
        public Nullable<System.DateTime> ThuTruongKy_Ngay { get; set; }
        public string ThuTruongKy_NoiKy { get; set; }
        public Nullable<int> Nhap_MaNhanVien { get; set; }
        public Nullable<System.DateTime> Nhap_Ngay { get; set; }
        public Nullable<int> CapNhat_MaNhanVien { get; set; }
        public Nullable<System.DateTime> CapNhat_Ngay { get; set; }
        public Nullable<int> Xoa_MaNhanVien { get; set; }
        public Nullable<System.DateTime> Xoa_Ngay { get; set; }
        public Nullable<bool> Xoa { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoSungPhamViHDCM> BoSungPhamViHDCM { get; set; }
        public virtual ChinhQuyen ChinhQuyen { get; set; }
        public virtual ChuyenMon ChuyenMon { get; set; }
        public virtual Dang Dang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DienBienDaoTaoBoiDuong> DienBienDaoTaoBoiDuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DienBienQuaTrinhCongTac> DienBienQuaTrinhCongTac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DienBienQuaTrinhLuong> DienBienQuaTrinhLuong { get; set; }
        public virtual DoanThe DoanThe { get; set; }
        public virtual DonVi DonVi { get; set; }
        public virtual HocHam HocHam { get; set; }
        public virtual HocVi HocVi { get; set; }
        public virtual LoaiHopDong LoaiHopDong { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
