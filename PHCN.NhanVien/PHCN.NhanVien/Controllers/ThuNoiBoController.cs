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
        int _maNhanVienDangNhap = 0;
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
        public ActionResult _pDanhSachThu(string trangThai)
        {
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];
            if (nhanVienDangNhap != null)
            {
                List<GuiNhan> listBaiViet = new List<GuiNhan>();
                switch (trangThai)
                {
                    case "ThuDen":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien 
                                                                && x.Xoa == false 
                                                                && x.DaNhan == true 
                                                                && x.QuanTrong == false 
                                                                && x.DaXoa == false).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();                        
                        break;
                    case "DaGui":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiGui == nhanVienDangNhap.MaNhanVien 
                                                                && x.Xoa == false 
                                                                && x.DaNhan == true 
                                                                && x.QuanTrong == false 
                                                                && x.DaXoa == false
                                                                && x.STTGui == 1).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                        // gửi cho 5 người thì bảng GuiNhan cột STTGui se đánh số từ 1 đến 5, nên chỉ cần lấy ra STTGui là 1
                        break;
                    case "QuanTrong":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien 
                                                                && x.Xoa == false 
                                                                && x.DaNhan == true 
                                                                && x.QuanTrong == true 
                                                                && x.DaXoa == false).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                        break;
                    case "DaXoa":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true
                                                                && x.QuanTrong == false
                                                                && x.DaXoa == true).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                        break;
                    default:

                        break;
                }
                ViewBag.ListBaiViet = listBaiViet;
                return PartialView("_pDanhSachThu");
            } else
            {
                string result = "Phiên làm việc hết hạn, vui lòng click <a href='" + Url.Action("DangNhap", "Home") + "'>vào đây</a> " + "để đăng nhập lại.";
                return Content(result);
            }

            
        }
        public ActionResult _pDanhSachFileDinhKem(int id, bool xem = false)
        {
            // id là mã bài viết
            // nếu xem == true thì ẩn đi nút xóa
            BaiViet bv = db.BaiViet.Find(id);
            var listFileDinhKem = bv.FileDinhKem.Where(x => x.Xoa == false).OrderBy(x => x.MaFile).ToList();
            ViewBag.ListFileDinhKem = listFileDinhKem;
            ViewBag.Xem = xem;

            return PartialView();
        }
        public ActionResult SoanThu(string id)
        {
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];

            if (nhanVienDangNhap == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            ViewBag.MaNhanVienDangNhap = nhanVienDangNhap.MaNhanVien;
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
                int i = 1;
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
                    gn.STTGui = i;
                    baiViet.GuiNhan.Add(gn);
                    i++;
                }
                db.SaveChanges();
                return Content("true");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }

        public ActionResult XemThu(int id)
        {

            
            BaiViet baiViet = db.BaiViet.Find(id);
            ViewBag.BaiViet = baiViet;
            
            return View();
        }

        public ActionResult DanhDauQuanTrong(int id)
        {
            // id của GuiNhan
            GuiNhan gn = db.GuiNhan.Find(id);
            if (gn.QuanTrong == false) gn.QuanTrong = true; else gn.QuanTrong = false;
            db.SaveChanges();
            return Content("true");
        }

        public ActionResult DanhDauXoa(int id)
        {
            // id của GuiNhan
            GuiNhan gn = db.GuiNhan.Find(id);
            gn.QuanTrong = false;
            if (gn.DaXoa == true) gn.DaXoa = false; else gn.DaXoa = true;
            db.SaveChanges();
            return Content("true");
        }
    }
}