﻿using PHCN.NhanVien.Models;
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
            try
            {
                var nhanVien = db.NhanVien.Where(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau).ToList();
                if (nhanVien.Any())
                {
                    this.Session["NhanVienDangNhap"] = nhanVien.First();
                    Session.Timeout = 86000;
                    return RedirectToAction("Index", "ThuNoiBo");
                }
                else
                {
                    ViewBag.Result = "false";
                    return View("DangNhap");
                }
            } catch (Exception ex)
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
                var nhanVien = db.NhanVien.Where(x => x.TenDangNhap == TenDangNhap && x.MatKhauMD5 == MatKhau).ToList();
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
    }
}