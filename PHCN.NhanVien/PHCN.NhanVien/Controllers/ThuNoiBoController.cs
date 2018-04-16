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
        int _maNhanVienDangNhap = 1;
        // GET: ThuNoiBo

        public ActionResult Index()
        {
            ViewBag.TrangThai = "ThuDen";
            if (this.Request.QueryString["box"] != null && this.Request.QueryString["box"] != "")
            {
                ViewBag.TrangThai = this.Request.QueryString["box"].ToString();
            }
            return View();
        }
        public ActionResult _pDanhSachThu(int maNhanVienDangNhap, string trangThai)
        {
            List<GuiNhan> listGuiNhan = new List<GuiNhan>();
            switch (trangThai)
            {
                case "ThuDen":
                    listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false && x.DaNhan == true && x.QuanTrong == false).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                    break;
                case "DaGui":
                    listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false && x.NguoiGui == maNhanVienDangNhap).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                    break;
                case "QuanTrong":
                    listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false && x.DaNhan == true && x.QuanTrong == true).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                    break;
                case "DaXoa":
                    listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false && x.DaNhan == true && x.QuanTrong == false && x.DaXoa == true).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                    break;
                default:
                    //listGuiNhan = null;//db.GuiNhan.Where(x => x.NguoiNhan == maNhanVienDangNhap && x.BaiViet.Xoa == false).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                    break;
            }
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
            ViewBag.MaNhanVienDangNhap = _maNhanVienDangNhap;
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GuiThu(int maBaiViet, string tieuDe, string noiDung, int nguoiGui, string listNguoiNhan)
        {
            // ajax
            // maBaiViet = 1
            // tieuDe = ...
            // noiDung = ...
            // nguoiDung = 1
            // listNguoiNhan = 2,3,4

            try
            {
                BaiViet baiViet = db.BaiViet.Find(maBaiViet);
                baiViet.TieuDe = tieuDe;
                baiViet.NoiDung = noiDung;
                baiViet.Ngay = CodeController.GetServerDateTime();
                baiViet.Xoa = false;
                var listIntNguoiNhan = listNguoiNhan.Split(',').Select(Int32.Parse).ToList();
                foreach (var item in listIntNguoiNhan)
                {
                    GuiNhan gn = new GuiNhan();
                    gn.NguoiGui = nguoiGui;
                    gn.NguoiNhan = item;
                    gn.DaNhan = true;
                    gn.DaXem = false;
                    gn.QuanTrong = false;
                    gn.DaXoa = false;
                    gn.GhiChu = "";
                    baiViet.GuiNhan.Add(gn);
                }
                db.SaveChanges();
                return Content("true");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
    }
}