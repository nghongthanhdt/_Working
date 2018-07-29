using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyLyLichVienChucController : Controller
    {
        // GET: QuanLyLyLichVienChuc
        PHCNEntities db = new PHCNEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult CapNhat(string id)
        {
            LyLichVienChuc lyLich;
            int maLyLichVienChuc = 0;
            if (id == null || id == "")
            {
                lyLich = new LyLichVienChuc();
                lyLich.HoTenKhaiSinh = "< nhân viên mới >";
                lyLich.Xoa = true;
                db.LyLichVienChuc.Add(lyLich);
                db.SaveChanges();
                return RedirectToAction("CapNhat", new { id = lyLich.MaLyLichVienChuc });
            }                
            try
            {
                maLyLichVienChuc = int.Parse(id);
            }
            catch { }
            if (maLyLichVienChuc <= 0)
            {
                return RedirectToAction("ThongBao", "Loi", new { id = "khongtimthayhoso" });
            }
            lyLich = db.LyLichVienChuc.Find(maLyLichVienChuc);
            return View(lyLich);
        }
    }
}