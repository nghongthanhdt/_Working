using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: QuanLyNhanVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Xem(int? id)
        {

            return View();
        }
        public ActionResult TaoLyLichVienChuc(int id)
        {
            // id: mã nhân viên
            Models.NhanVien nv = db.NhanVien.Find(id);           
            LyLichVienChuc lylich = new LyLichVienChuc();
            lylich.MaDonVi = int.Parse(CodeController.layThamSoHeThong("madonvisudungvienchucmacdinh"));
            lylich.MaLoaiHopDong = int.Parse(CodeController.layThamSoHeThong("loaihopdongvienchucmacdinh"));
            lylich.MaNhanVien = id;
            lylich.HoTenKhaiSinh = nv.HoTen;
            lylich.DanToc = CodeController.layThamSoHeThong("dantocmacdinh");
            lylich.TonGiao = CodeController.layThamSoHeThong("tongiaomacdinh");
            lylich.NguoiKhai = nv.HoTen;
            lylich.ThuTruongKyTen = CodeController.layThamSoHeThong("thutruongdonvi");
            lylich.ThuTruongKy_NoiKy = CodeController.layThamSoHeThong("noikymacdinh");
            
            db.LyLichVienChuc.Add(lylich);
            db.SaveChanges();
            return RedirectToAction("CapNhat", "QuanLyLyLichVienChuc", new { @id = lylich.MaLyLichVienChuc });

        }
    }
}