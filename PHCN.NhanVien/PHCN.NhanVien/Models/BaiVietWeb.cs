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
    
    public partial class BaiVietWeb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiVietWeb()
        {
            this.FileDinhKem = new HashSet<FileDinhKem>();
        }
    
        public int MaBaiViet { get; set; }
        public Nullable<int> MaChuyenMuc { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeRewrite { get; set; }
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<bool> HienThiTrenTrangChu { get; set; }
        public Nullable<bool> Xoa { get; set; }
        public string TacGia { get; set; }
        public Nullable<System.DateTime> CapNhatLanCuoi { get; set; }
    
        public virtual ChuyenMuc ChuyenMuc { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileDinhKem> FileDinhKem { get; set; }
    }
}