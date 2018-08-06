﻿using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class AjaxManagerController : Controller
    {
        // GET: AjaxManager
        PHCNEntities db = new PHCNEntities();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetListTinhThanh(string keyword)
        {
            
            var list = db.TinhThanh.Where(x => x.TenTinhThanh.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenTinhThanh).Take(10).ToList();            
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListHuyenThi(string keyword)
        {
            
            var list = db.HuyenThi.Where(x => x.TenHuyenThi.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenHuyenThi).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListXaPhuong(string keyword)
        {

            var list = db.XaPhuong.Where(x => x.TenXaPhuong.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenXaPhuong).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListDanToc(string keyword)
        {
            var list = db.DanToc.Where(x => x.TenDanToc.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenDanToc).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListTonGiao(string keyword)
        {
            var list = db.TonGiao.Where(x => x.TenTonGiao.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenTonGiao).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListTrinhDoChuyenMon(string keyword)
        {
            var list = db.TrinhDoChuyenMon.Where(x => x.TenTrinhDoChuyenMon.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenTrinhDoChuyenMon).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListChucDanhNgheNghiep(string keyword)
        {
            var list = db.ChucDanhNgheNghiep.Where(x => x.TenChucDanhNgheNghiep.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenChucDanhNgheNghiep).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public string LuuQuaTrinhLuong(DienBienQuaTrinhLuong qtLuong)
        {
            if (qtLuong.MaDienBienQuaTrinhLuong == 0)
            {
                db.DienBienQuaTrinhLuong.Add(qtLuong);
                db.SaveChanges();
            } else
            {
                db.Entry(qtLuong).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        public JsonResult GetDienBienQuaTrinhLuong(int id)
        {
            DienBienQuaTrinhLuong dienbien = new DienBienQuaTrinhLuong();
            dienbien = db.DienBienQuaTrinhLuong.Find(id);

            object _dienbien = new
            {
                MaDienBienQuaTrinhLuong = dienbien.MaDienBienQuaTrinhLuong,
                MaChucDanhNgheNghiep = dienbien.MaChucDanhNgheNghiep,
                BacLuong = dienbien.BacLuong,
                HeSo = dienbien.HeSo,
                VuotKhung = dienbien.VuotKhung,
                NgayHuong = DateTime.Parse(dienbien.NgayHuong.ToString()).ToString("dd/MM/yyyy"),
                PhuCapChucVu = dienbien.PhuCapChucVu,
                PhuCapKhac = dienbien.PhuCapKhac
            };
            return Json(_dienbien, JsonRequestBehavior.AllowGet);
        }
        public string XoaDienBienQuaTrinhLuong(int id)
        {
            //id: mã diễn biến
            DienBienQuaTrinhLuong dienbien = db.DienBienQuaTrinhLuong.Find(id);
            db.DienBienQuaTrinhLuong.Remove(dienbien);
            db.SaveChanges();
            return "ok";
        }
        public JsonResult GetLastDienBienQuaTrinhLuong(int maLyLichVienChuc)
        {
            var list = db.DienBienQuaTrinhLuong.Where(x => x.MaLyLichVienChuc == maLyLichVienChuc).OrderBy(x => x.NgayHuong).ToList();
            if (list.Any())
            {
                DienBienQuaTrinhLuong dienbien = new DienBienQuaTrinhLuong();
                dienbien = list.Last();
                object _dienbien = new
                {
                        MaDienBienQuaTrinhLuong = dienbien.MaDienBienQuaTrinhLuong,
                        MaChucDanhNgheNghiep = dienbien.MaChucDanhNgheNghiep,
                        MaSoChucDanhNgheNghiep = dienbien.ChucDanhNgheNghiep.MaSo,
                        TenChucDanh = dienbien.ChucDanhNgheNghiep.TenChucDanhNgheNghiep,
                        BacLuong = dienbien.BacLuong,
                        HeSo = dienbien.HeSo,
                        VuotKhung = dienbien.VuotKhung,
                        NgayHuong = DateTime.Parse(dienbien.NgayHuong.ToString()).ToString("dd/MM/yyyy"),
                        PhuCapChucVu = dienbien.PhuCapChucVu,
                        PhuCapKhac = dienbien.PhuCapKhac
                    };
                return Json(_dienbien, JsonRequestBehavior.AllowGet);
            } else return null;
            


            
        }

        public JsonResult GetDienBienDaoTaoBoiDuong(int id)
        {
            DienBienDaoTaoBoiDuong dienbien = new DienBienDaoTaoBoiDuong();
            dienbien = db.DienBienDaoTaoBoiDuong.Find(id);

            object _dienbien = new
            {
                TenTruong = dienbien.TenTruong,
                ChuyenNganhDaoTaoBoiDuong = dienbien.ChuyenNganhDaoTaoBoiDuong,
                TuThangNam = DateTime.Parse(dienbien.TuThangNam.ToString()).ToString("MM/yyyy"),
                DenThangNam = DateTime.Parse(dienbien.DenThangNam.ToString()).ToString("MM/yyyy"),
                MaHinhThucDaoTao = dienbien.MaHinhThucDaoTao,
                VanBangChungChiTrinhDo = dienbien.VanBangChungChiTrinhDo
            };
            return Json(_dienbien, JsonRequestBehavior.AllowGet);
        }
        public string LuuDienBienDaoTaoBoiDuong(DienBienDaoTaoBoiDuong dienbien)
        {
            if (dienbien.MaDienBienDaoTaoBoiDuong == 0)
            {
                db.DienBienDaoTaoBoiDuong.Add(dienbien);
                db.SaveChanges();
            }
            else
            {
                db.Entry(dienbien).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        public string XoaDienBienDaoTaoBoiDuong(int id)
        {
            //id: mã diễn biến
            DienBienDaoTaoBoiDuong dienbien = db.DienBienDaoTaoBoiDuong.Find(id);
            db.DienBienDaoTaoBoiDuong.Remove(dienbien);
            db.SaveChanges();
            return "ok";
        }
    }
}