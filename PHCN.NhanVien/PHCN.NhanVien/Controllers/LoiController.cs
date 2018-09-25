using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class LoiController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: Loi
        public ActionResult ThongBao(string id)
        {
            var loi = db.Loi.Find(id);
            ViewBag.TenLoi = loi.TenLoi;            
            return View();
        }
        public ActionResult LoiHeThong(string id)
        {
            var loi = db.Loi.Find(id);
            ViewBag.TenLoi = loi.TenLoi;
            return View();
        }

    }
}