using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class TinTucController : Controller
    {
        PHCN.NhanVien.Models.PHCNEntities db = new Models.PHCNEntities();
        // GET: TinTuc
        public ActionResult Index(string TenChuyenMucRewrite)
        {
            if (TenChuyenMucRewrite != "" && TenChuyenMucRewrite != null)
            {
                try
                {
                    var selectedChuyenMuc = db.ChuyenMuc.Where(x => x.TenChuyenMucRewrite == TenChuyenMucRewrite).First();
                }
                catch
                {
                    return RedirectToAction("ThongBao", "Loi", new { @id = "duongdankhonghople" });
                }

            }
            return View();
        }
        public ActionResult BaiViet(int id)
        {
            BaiVietWeb bv = db.BaiVietWeb.Find(id);
            return View(bv);
        }
        public ActionResult XemBaiViet(string TenChuyenMucRewrite, string TenBaiVietRewrite, int MaBaiViet)
        {
            var listBaiViet = db.BaiVietWeb.Where(x => x.Xoa != true && x.TieuDeRewrite == TenBaiVietRewrite && x.MaBaiViet == MaBaiViet && x.HienThiTrenTrangChu == true).ToList();
            if (listBaiViet.Any())
            {
                var baiviet = listBaiViet.First();
                return View("BaiViet", baiviet);
            }
            else
            {
                return RedirectToAction("ThongBao", "Loi", new { @id = "duongdankhonghople" });
            }


        }

    }
}