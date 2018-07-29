using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
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
            }
            return "ok";
        }
    }
}