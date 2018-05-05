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
                nv.NhanThu = true;
                return View(nv);
            }
        }
        public ActionResult LuuThongTinNhanVien(NhanVien.Models.NhanVien nv, string mode)
        {
            
            if (mode == "edit")
            {
                db.Entry(nv).State = EntityState.Modified;
                nv.MatKhauMD5 = CodeController.GetMD5(nv.MatKhau);
                db.SaveChanges();
            } else
            {
                bool tontaiTenDangNhap = db.NhanVien.Where(x => x.TenDangNhap == nv.TenDangNhap).ToList().Any();
                if (tontaiTenDangNhap) return RedirectToAction("ThongBao", "Loi", new { @id = "tendangnhapdatontai" });
                nv.MatKhauMD5 = CodeController.GetMD5(nv.MatKhau);
                db.NhanVien.Add(nv);
                db.SaveChanges();
            }                                
            return RedirectToAction("NhanVien");
        }
        public ActionResult DanhDauXoaNhanVien(int maNhanVien)
        {
            
            var nv = db.NhanVien.Find(maNhanVien);                                           
            if (nv.TenDangNhap == "admin")
            {
                return RedirectToAction("ThongBao", "Loi", new { @id = "khongthexoaadmin" });
            }
            nv.Xoa = true;
            db.SaveChanges();
            return RedirectToAction("NhanVien", "Admin");
        }
        public ActionResult PhanQuyen()
        {
            return View();
        }
        public ActionResult LuuPhanQuyenNhanVien(string MaQuyen, int MaNhanVien) 
        {
            var listKiemTra = db.PhanQuyen.Where(x => x.MaQuyen == MaQuyen && x.MaNhanVien == MaNhanVien);
            if (listKiemTra.Any()) return RedirectToAction("PhanQuyen");

            PhanQuyen phanQuyen = new PhanQuyen();
            phanQuyen.MaQuyen = MaQuyen;
            phanQuyen.MaNhanVien = MaNhanVien;
            db.PhanQuyen.Add(phanQuyen);
            db.SaveChanges();
            return RedirectToAction("PhanQuyen");
        }
        public ActionResult XoaPhanQuyenNhanVien(int id)
        {
            var phanquyen = db.PhanQuyen.Find(id);
            db.PhanQuyen.Remove(phanquyen);
            db.SaveChanges();
            return RedirectToAction("PhanQuyen");
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