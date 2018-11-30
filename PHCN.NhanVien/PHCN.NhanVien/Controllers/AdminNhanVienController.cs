using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class AdminNhanVienController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: AdminNhanVien
        public ActionResult Index(string timkiem) 
        {
            string tukhoa = "";
            if (timkiem != null && timkiem != "")
            {
                tukhoa = timkiem;
            }
            ViewBag.ListNhanVien = db.NhanVien.Where(x => x.Xoa != true && (tukhoa == "" || x.HoTen.Contains(tukhoa))).OrderBy(x => x.STT).ToList();
            ViewBag.ListKhoaPhong = db.KhoaPhong.Where(x => x.Xoa != true).OrderBy(x => x.STT).ToList();
            return View();
        }
        public ActionResult Edit(int id) 
        {
            var listKhoaPhong = db.KhoaPhong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ToList();
            ViewBag.ListKhoaPhong = listKhoaPhong;
            if (id != 0)
            {
                PHCN.NhanVien.Models.NhanVien nv = db.NhanVien.Find(id);
                if (nv.Xoa == true)
                {
                    return RedirectToAction("TuChoiTruyCap", "Admin");
                } else
                {
                    var listPhanQuyen = nv.PhanQuyen.OrderBy(x => x.MaQuyen).ToList();
                    ViewBag.ListPhanQuyen = listPhanQuyen;
                    var listTatCaQuyen = db.Quyen.OrderBy(x => x.MaQuyen).ToList();
                    ViewBag.TatCaQuyen = listTatCaQuyen;
                    return View(nv);
                }
                    
            }
            
            NhanVien.Models.NhanVien nv2 = new Models.NhanVien();
            return View(nv2);
        }
        public ActionResult Save(int MaNhanVien, string HoTen, string ChucVu, string MaKhoa, int STT, string Email, string SoDienThoai, string SoDienThoaiNoiBo, string TenDangNhap, string MatKhau, bool NhanThu)
        {
            try
            {
                if (MaNhanVien == 0)
                {
                    NhanVien.Models.NhanVien nv = new Models.NhanVien();
                    nv.HoTen = HoTen;
                    nv.ChucVu = ChucVu;
                    nv.MaKhoa = MaKhoa;
                    nv.STT = STT;
                    nv.Email = Email;
                    nv.SoDienThoai = SoDienThoai;
                    nv.SoDienThoaiNoiBo = SoDienThoaiNoiBo;
                    nv.TenDangNhap = TenDangNhap;
                    nv.MatKhau = MatKhau;
                    nv.MatKhauMD5 = CodeController.GetMD5(MatKhau);
                    nv.NhanThu = NhanThu;
                    db.NhanVien.Add(nv);
                    db.SaveChanges();
                }
                else
                {
                    NhanVien.Models.NhanVien nv = db.NhanVien.Find(MaNhanVien);
                    nv.HoTen = HoTen;
                    nv.ChucVu = ChucVu;
                    nv.MaKhoa = MaKhoa;
                    nv.STT = STT;
                    nv.Email = Email;
                    nv.SoDienThoai = SoDienThoai;
                    nv.SoDienThoaiNoiBo = SoDienThoaiNoiBo;
                    nv.TenDangNhap = TenDangNhap;
                    //nv.MatKhau = MatKhau;
                    //nv.MatKhauMD5 = CodeController.GetMD5(MatKhau);
                    nv.NhanThu = NhanThu;
                    db.SaveChanges();
                }
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        public ActionResult ThemPhanQuyen(int MaNhanVien, string MaQuyen) 
        {
            try
            {
                if (db.PhanQuyen.Where(x => x.MaNhanVien == MaNhanVien && x.MaQuyen == MaQuyen).ToList().Any())
                {
                    return Content("phanquyendatontai");
                }
                PhanQuyen phanquyen = new PhanQuyen();
                phanquyen.MaNhanVien = MaNhanVien;
                phanquyen.MaQuyen = MaQuyen;
                db.PhanQuyen.Add(phanquyen);
                db.SaveChanges();
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult XoaPhanQuyen(int MaPhanQuyen)
        {
            try
            {
                var phanquyen = db.PhanQuyen.Find(MaPhanQuyen);
                db.PhanQuyen.Remove(phanquyen);
                db.SaveChanges();
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult AdminDoiMatKhau(int MaNhanVien, string MatKhau)
        {
            try
            {
                NhanVien.Models.NhanVien nv = db.NhanVien.Find(MaNhanVien);
                nv.MatKhauMD5 = CodeController.GetMD5(MatKhau);
                db.SaveChanges();
                return Content("ok");
            } catch ( Exception ex)
            {
                return Content(ex.Message);
            }            
        }
        [HttpPost]
        public ActionResult UserDoiMatKhau(int MaNhanVien, string MatKhau, string MatKhauMoi)
        {
            try
            {
                NhanVien.Models.NhanVien nv = db.NhanVien.Find(MaNhanVien);
                string matKhauMd5 = CodeController.GetMD5(MatKhau);
                if (nv.MatKhauMD5 != matKhauMd5)
                {
                    return Content("matkhaucukhongdung");
                }
                nv.MatKhauMD5 = CodeController.GetMD5(MatKhau);
                db.SaveChanges();
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult XoaNhanVien(int MaNhanVien)
        {
            try
            {
                NhanVien.Models.NhanVien nv = db.NhanVien.Find(MaNhanVien);
                nv.Xoa = true;                
                db.SaveChanges();
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}