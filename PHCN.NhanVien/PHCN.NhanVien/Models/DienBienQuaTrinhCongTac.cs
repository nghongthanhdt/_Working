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
    
    public partial class DienBienQuaTrinhCongTac
    {
        public int MaDienBienQuaTrinhCongTac { get; set; }
        public int MaLyLichVienChuc { get; set; }
        public Nullable<System.DateTime> TuThangNam { get; set; }
        public Nullable<System.DateTime> DenThangNam { get; set; }
        public string NoiDungCongTac { get; set; }
        public Nullable<bool> DenNay { get; set; }
    
        public virtual LyLichVienChuc LyLichVienChuc { get; set; }
    }
}
