using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class ThuNoiBoController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: ThuNoiBo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _pDanhSachThu(int maNhanVienDangNhap)
        {
            var listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
            ViewBag.ListGuiNhan = listGuiNhan;
            return PartialView("_pDanhSachThu");
        }
        public ActionResult _pDanhSachFileDinhKem(int id)
        {
            // id là mã bài viết
            BaiViet bv = db.BaiViet.Find(id);
            var listFileDinhKem = bv.FileDinhKem.Where(x => x.Xoa == false).OrderBy(x => x.MaFile).ToList();
            ViewBag.ListFileDinhKem = listFileDinhKem;
            return PartialView();
        }
        public ActionResult SoanThu(string id)
        {
            int newMaBaiViet = 0;
            if (id == null || id == "")
            {
                BaiViet bv = new BaiViet();
                bv.LoaiBaiViet = 0;
                bv.TieuDe = "";                
                bv.Xoa = true;
                bv.Ngay = CodeController.GetServerDateTime();
                db.BaiViet.Add(bv);
                int result = db.SaveChanges();
                if (result == 1)
                {
                    newMaBaiViet = bv.MaBaiViet;
                }
                return RedirectToAction("SoanThu", new { id = newMaBaiViet });
            } else
            {
                try
                {
                    int _id = int.Parse(id);
                    return View(new { id = _id });
                } catch
                {
                    return RedirectToAction("ThongBao", "Loi", new { id = "khongtimthaybaiviet"});
                }
                
            }
            
        }
    }
}