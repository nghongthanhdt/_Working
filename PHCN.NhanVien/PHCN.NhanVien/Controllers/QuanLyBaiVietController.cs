using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyBaiVietController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: QuanLyBaiViet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _pDanhSachBaiViet()
        {
            return View();
        }

        public ActionResult CapNhat(string id)
        {

            // nhớ chỉnh lại thông tin người cập nhật cho đúng với người đăng nhập
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];

            //if (nhanVienDangNhap == null)
            //{
            //    return RedirectToAction("DangNhap", "Home");
            //}
            //ViewBag.MaNhanVienDangNhap = nhanVienDangNhap.MaNhanVien;
            ViewBag.MaNhanVienDangNhap = 1;


            BaiVietWeb bv;
            int maBaiViet = 0;
            if (id == null || id == "")
            {
                bv = new BaiVietWeb();
                bv.MaNhanVien = 1;
                //bv.MaNhanVien = ViewBag.MaNhanVienDangNhap;
                bv.Ngay = CodeController.GetServerDateTime();
                bv.Xoa = true;
                bv.CapNhatLanCuoi = CodeController.GetServerDateTime();
                bv.MaNhanVienCapNhat = 1;
                //bv.MaNhanVienCapNhat = ViewBag.MaNhanVienDangNhap;
                db.BaiVietWeb.Add(bv);
                db.SaveChanges();
                return RedirectToAction("CapNhat", new { id = bv.MaBaiViet });
            }
            try
            {
                maBaiViet = int.Parse(id);
            }
            catch { }
            if (maBaiViet <= 0)
            {
                return RedirectToAction("ThongBao", "Loi", new { id = "khongtimthaybaiviet" });
            }
            bv = db.BaiVietWeb.Find(maBaiViet);
            return View(bv);

        }
    }
}