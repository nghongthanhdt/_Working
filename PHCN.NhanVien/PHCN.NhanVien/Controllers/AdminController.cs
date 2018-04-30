using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class AdminController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhanVien()
        {
            var listKhoaPhong = db.KhoaPhong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ToList();
            return View(listKhoaPhong);
        }
        public ActionResult ThongTinNhanVien(int? id)
        {
            var listKhoaPhong = db.KhoaPhong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ToList();
            ViewBag.ListKhoaPhong = listKhoaPhong;
            if (id != null && id != 0)
            {
                PHCN.NhanVien.Models.NhanVien nv = db.NhanVien.Find(id);
                return View(nv);
            }
            else
            {
                PHCN.NhanVien.Models.NhanVien nv = new NhanVien.Models.NhanVien();
                return View(nv);
            }
        }
        public ActionResult KhoaPhong()
        {
            List<KhoaPhong> listKhoaPhong = db.KhoaPhong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ToList();
            return View(listKhoaPhong);
        }
        public ActionResult ThongTinKhoaPhong(string id)
        {
            if (id != null && id != "")
            {
                KhoaPhong kp = db.KhoaPhong.Find(id);
                return View(kp);
            } else
            {
                KhoaPhong kp = new KhoaPhong();
                return View(kp);
            }
            
        }
        public ActionResult LuuKhoaPhong(KhoaPhong kp, string mode)
        {
            if (mode == "edit")
            {
                
                db.Entry(kp).State = EntityState.Modified;
                db.SaveChanges();
                
            } else
            {
                try
                {
                    kp.MaKhoa = kp.MaKhoa.ToUpper();
                    db.KhoaPhong.Add(kp);
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("ThongBao", "Loi", new { id = "makhoaphongdatontai" });
                }
            }
            return RedirectToAction("KhoaPhong");

        }
        public ActionResult XoaKhoaPhong(string id)
        {
            KhoaPhong kp = db.KhoaPhong.Find(id);
            db.KhoaPhong.Remove(kp);
            try
            {
                db.SaveChanges();
                return RedirectToAction("KhoaPhong", "Admin");
            }
            catch
            {
                return RedirectToAction("ThongBao", "Loi", new { @id = "khoaphongtontainhanvien" });
            }
            
        }
        public ActionResult ThamSoHeThong()
        {
            var listThamSoHeThong = db.ThamSoHeThong.ToList();
            return View(listThamSoHeThong);
        }
        public ActionResult ThongTinThamSoHeThong(string id)
        {
            if (id != null && id != "")
            {
                var thamso = db.ThamSoHeThong.Find(id);
                return View(thamso);
            } else
            {
                ThamSoHeThong thamso = new ThamSoHeThong();
                return View(thamso);
            }
            
        }
        public ActionResult LuuThamSoHeThong(ThamSoHeThong thamSo)
        {   
            db.Entry(thamSo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ThamSoHeThong", "Admin");
        }
    }
}