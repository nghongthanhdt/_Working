using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class VanBanController : Controller
    {
        // GET: VanBan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BangGiaDichVu()
        {
            return View();
        }

    }
}