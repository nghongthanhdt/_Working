using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class NoiBoController : Controller
    {
        // GET: NoiBo
        public ActionResult Index()
        {
            return RedirectToAction("DangNhap", "Home");
        }
    }
}