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

            
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];

            if (nhanVienDangNhap == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            ViewBag.MaNhanVienDangNhap = nhanVienDangNhap.MaNhanVien;
            


            BaiVietWeb bv;
            int maBaiViet = 0;
            if (id == null || id == "")
            {
                bv = new BaiVietWeb();                
                bv.MaNhanVien = ViewBag.MaNhanVienDangNhap;
                bv.Ngay = CodeController.GetServerDateTime();
                bv.Xoa = true;
                bv.CapNhatLanCuoi = CodeController.GetServerDateTime();                
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

        
        public ActionResult _pDanhSachHinhAnh(int MaBaiViet)
        {
            if (MaBaiViet <= 0)
            {
                return Content("");
            } else
            {
                var listHinhAnh = db.HinhAnh.Where(x => x.MaBaiViet == MaBaiViet && x.Xoa != true).OrderBy(x => x.MaHinhAnh).ToList();
                if(listHinhAnh.Any())
                {
                    return View(listHinhAnh);
                } else
                {
                    return Content("");
                }                
            }            
        }
        public ActionResult _pDanhSachFileDinhKem(int MaBaiViet)
        {
            if (MaBaiViet <= 0)
            {
                return Content("");
            }
            else
            {
                var listFileDinhKem = db.FileDinhKem.Where(x => x.MaBaiVietWeb == MaBaiViet && x.Xoa != true).OrderBy(x => x.MaFile).ToList();
                if (listFileDinhKem.Any())
                {
                    return View(listFileDinhKem);
                }
                else
                {
                    return Content("");
                }
            }
        }
    }
}