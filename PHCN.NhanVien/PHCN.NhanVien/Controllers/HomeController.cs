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

        [HttpPost]
        public ActionResult Login(string tenDangNhap, string matKhau, bool nhoTaiKhoan)
        {
            // nếu thành công, trả về mã nhân viên, nếu sai trả về false;
            var nhanVien = db.NhanVien.Where(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau).ToList();
            if (nhanVien.Any())
            {
                this.Session["NhanVienDangNhap"] = nhanVien.First();
                return RedirectToAction("Index", "ThuNoiBo");
            }
            else
            {
                ViewBag.Result = "false";
                return View("DangNhap");
            }
        }

        public ActionResult Logout()
        {
            this.Session["NhanVienDangNhap"] = null;
            return RedirectToAction("DangNhap", "Home");
        }
    }
}