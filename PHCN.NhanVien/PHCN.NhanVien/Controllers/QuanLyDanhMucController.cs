using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyDanhMucController : Controller
    {
        PHCN.NhanVien.Models.PHCNEntities db = new Models.PHCNEntities();
        // GET: QuanLyDanhMuc
        public ActionResult Index(string tendanhmuc, string timkiem)
        {
            return View();
        }

        public ActionResult _pTinhThanh(string timkiem)
        {
            var listTinhThanh = new List<TinhThanh>();
            if (timkiem != "")
            {
                listTinhThanh = db.TinhThanh.Where(x => x.Xoa == false && x.TenTinhThanh.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaTinhThanh).ToList();
            } else
            {
                listTinhThanh = db.TinhThanh.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaTinhThanh).ToList();
            }          
                
            return View(listTinhThanh);
        }
        [HttpPost]
        public string LuuTinhThanh(int MaDanhMuc, string TenDanhMuc, int STT)
        {
            try
            {
                var dm = db.TinhThanh.Find(MaDanhMuc);
                dm.TenTinhThanh = TenDanhMuc;
                dm.STT = STT;
                db.SaveChanges();
                return "ok";
            } catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        public ActionResult _pHuyenThi(string timkiem)
        {
            return View();
        }
        public ActionResult _pXaPhuong(string timkiem)
        {
            return View();
        }
    }
}