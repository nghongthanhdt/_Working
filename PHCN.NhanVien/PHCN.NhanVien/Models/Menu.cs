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
    
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string MenuType { get; set; }
        public string Ten { get; set; }
        public string Url { get; set; }
        public int STT { get; set; }
        public int ParentId { get; set; }
        public int MenuLevel { get; set; }
        public string IconClass { get; set; }
        public string MaQuyen { get; set; }
        public bool Xoa { get; set; }
        public string LocalHost { get; set; }
        public string DeployHost { get; set; }
        public bool ExpandStartup { get; set; }
    }
}
