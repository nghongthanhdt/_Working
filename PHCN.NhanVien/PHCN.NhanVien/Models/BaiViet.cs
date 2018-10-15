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
    
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            this.FileDinhKem = new HashSet<FileDinhKem>();
            this.GuiNhan = new HashSet<GuiNhan>();
        }
    
        public int MaBaiViet { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public int LoaiBaiViet { get; set; }
        public bool Xoa { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
        public string NguoiXoa { get; set; }
        public System.DateTime Ngay { get; set; }
        public int MaNhanVien { get; set; }
        public Nullable<int> MaNhanVienCapNhat { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
    
        public virtual LoaiBaiViet LoaiBaiViet1 { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual NhanVien NhanVien1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileDinhKem> FileDinhKem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuiNhan> GuiNhan { get; set; }
    }
}
