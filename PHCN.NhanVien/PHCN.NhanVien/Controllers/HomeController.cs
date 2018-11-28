using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class HomeController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {

            return View();
        }
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        public ActionResult ThucHienDoiMatKhau(string MaNhanVien, string MatKhau, string MatKhauMoi, string NhapLaiMatKhauMoi)
        {
            try
            {
                int maNV = int.Parse(MaNhanVien);
                NhanVien.Models.NhanVien nv = db.NhanVien.Find(maNV);
                string matkhauMD5 = CodeController.GetMD5(MatKhau);
                if (nv.MatKhauMD5 != matkhauMD5)
                {
                    return RedirectToAction("DoiMatKhau", "Home", new { @thongbao = "matkhaucukhongdung" });
                }
                else
                {
                    nv.MatKhauMD5 = CodeController.GetMD5(MatKhauMoi);
                }
                db.SaveChanges();
                return RedirectToAction("DoiMatKhau", "Home", new { @thongbao = "thanhcong" });
            } catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult Login(string tenDangNhap, string matKhau)
        {
            // nếu thành công, trả về mã nhân viên, nếu sai trả về false;
            try
            {
                string matkhauMD5 = CodeController.GetMD5(matKhau);
                var nhanVien = db.NhanVien.Where(x => x.TenDangNhap == tenDangNhap && x.MatKhauMD5 == matkhauMD5).ToList();

                if (nhanVien.Any())
                {
                    // kiểm tra phân quyền đăng nhập
                    var nv = nhanVien.First();
                    var listQuyenNhanVien = nv.PhanQuyen.Where(x => x.MaQuyen == "admin" || x.MaQuyen == "dangnhapthietbididong").ToList();
                    if (!listQuyenNhanVien.Any())
                    {
                        return RedirectToAction("TuChoiTruyCap", "Admin");
                    }
                       
                    this.Session["NhanVienDangNhap"] = nhanVien.First();
                    Session.Timeout = 86000;
                    return RedirectToAction("Index", "ThuNoiBo");
                }
                else
                {
                    ViewBag.Result = "false";
                    return View("DangNhap");
                }
            } catch
            {
                ViewBag.Result = "khongketnoi";
                return View("DangNhap");
            }
            
        }
        [HttpGet]
        public ActionResult ClientLogin(string TenDangNhap, string MatKhau)
        {
            try
            {
                // kiểm tra tham số hệ thống cho phép đăng nhập client
                if (db.ThamSoHeThong.Find("dangnhapclient").GiaTri != "1")
                {
                    //hethongkhongchophepdangnhapclient
                    return RedirectToAction("LoiHeThong", "Loi", new { @id = "hethongkhongchophepdangnhapclient" });
                }
                // nếu thành công, trả về mã nhân viên, nếu sai trả về false;
                string md5TenDangNhap = CodeController.GetMD5(TenDangNhap);
                bool passOk = (md5TenDangNhap == MatKhau);
                var nhanVien = db.NhanVien.Where(x => x.TenDangNhap == TenDangNhap && (passOk)).ToList();
                if (nhanVien.Any())
                {
                    this.Session["NhanVienDangNhap"] = nhanVien.First();
                    Session.Timeout = 86000;
                    return RedirectToAction("Index", "ThuNoiBo");
                }
                else
                {
                    return RedirectToAction("LoiHeThong", "Loi", new { @id = "taikhoanhoacmatkhaukhongdung" });
                }
            } catch
            {
                ViewBag.Result = "khongketnoi";
                return View("DangNhap");
            }
            
        }

        public ActionResult Logout()
        {
            this.Session["NhanVienDangNhap"] = null;
            return RedirectToAction("DangNhap", "Home");
        }

        public ActionResult DichVu()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult HinhAnh()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult KhongDuocPhepTruyCap()
        {
            return View();
        }


    }
}