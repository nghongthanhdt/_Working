using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyBaiVietController : Controller
    {
        // GET: QuanLyBaiViet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _pDanhSachBaiViet()
        {
            return View();
        }
    }
}