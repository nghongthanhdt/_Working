using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{

    public class ThongTinThu
    {
        public string TrangThai = "";
        public int TongSoThu = 0;
        public int SoThuChuaDoc = 0;
    }
    public class ThuNoiBoController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        
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
        
        [ValidateInput(false)]
        public ActionResult _pDanhSachThu(string TrangThai, string TieuDe, int NguoiGui, DateTime? NgayGui)
        {
            TieuDe = HttpUtility.HtmlDecode(TieuDe);
            DateTime ? ngayGuiAdd1 = null;
            DateTime? ngayGui = null;
            if (NgayGui != null)
            {
                ngayGui = DateTime.Parse(DateTime.Parse(NgayGui.ToString()).ToShortDateString());
                ngayGuiAdd1 = DateTime.Parse(DateTime.Parse(NgayGui.ToString()).AddDays(1).ToShortDateString());
            }

            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];
            if (nhanVienDangNhap != null)
            {
                List<GuiNhan> listBaiViet = new List<GuiNhan>();
                switch (TrangThai)
                {
                    case "ThuDen":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien 
                                                                && x.Xoa == false 
                                                                && x.DaNhan == true                                                                 
                                                                && x.DaXoa == false
                                                                && (TieuDe == "" || x.BaiViet.TieuDe.Contains(TieuDe))
                                                                && (NguoiGui == 0 || x.BaiViet.MaNhanVien == NguoiGui)
                                                                && (NgayGui == null || (x.BaiViet.Ngay <= ngayGuiAdd1 && x.BaiViet.Ngay >= NgayGui))
                                                                ).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();                        
                        break;
                    case "DaGui":
                        listBaiViet = db.GuiNhan.Where(x => x.BaiViet.MaNhanVien == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false 
                                                                && x.DaNhan == true                                                                
                                                                && x.DaXoa == false
                                                                && x.STTGui == 1).OrderByDescending(x => x.BaiViet.MaBaiViet).ToList();
                        // gửi cho 5 người thì bảng GuiNhan cột STTGui se đánh số từ 1 đến 5, nên chỉ cần lấy ra STTGui là 1
                        break;                    
                    case "DaXoa":
                        listBaiViet = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true                                                                
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
                bv.MaNhanVien = nhanVienDangNhap.MaNhanVien;
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

            NhanVien.Models.NhanVien nhanVienDangNhap = (NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];
            GuiNhan guiNhan = db.GuiNhan.Find(id);
            guiNhan.DaXem = true;            
            db.SaveChanges();
            BaiViet baiViet = db.BaiViet.Find(guiNhan.MaBaiViet);            
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
            gn.DaXem = true;
            if (gn.DaXoa == true) gn.DaXoa = false; else gn.DaXoa = true;
            db.SaveChanges();
            return Content("true");
        }
        public ActionResult DanhDauXoaList(string listGuiNhanXoa)
        {
            try
            {
                var listIntGuiNhanXoa = listGuiNhanXoa.Split(',').Select(Int32.Parse).ToList();                
                foreach (var item in listIntGuiNhanXoa)
                {
                    GuiNhan gn = db.GuiNhan.Find(item);
                    gn.DaXoa = true;
                    gn.DaXem = true;                
                }
                db.SaveChanges();
                return Content("true");
            } catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        public ActionResult DanhDauDaXemList(string listGuiNhanDaXem)
        {
            try
            {
                var listIntGuiNhanDaXem = listGuiNhanDaXem.Split(',').Select(Int32.Parse).ToList();
                foreach (var item in listIntGuiNhanDaXem)
                {
                    GuiNhan gn = db.GuiNhan.Find(item);
                    gn.DaXem = true;
                }
                db.SaveChanges();
                return Content("true");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        public ActionResult DanhDauChuaXemList(string listGuiNhanChuaXem)
        {
            try
            {
                var listIntGuiNhanChuaXem = listGuiNhanChuaXem.Split(',').Select(Int32.Parse).ToList();
                foreach (var item in listIntGuiNhanChuaXem)
                {
                    GuiNhan gn = db.GuiNhan.Find(item);
                    gn.DaXem = false;
                }
                db.SaveChanges();
                return Content("true");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        public ActionResult DanhDauDaXemTatCa()
        {
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];

            if (nhanVienDangNhap == null)
            {
                return Content("Phiên làm việc hết hạn, vui lòng đăng nhập lại");
            }
            try
            {
                var listGuiNhan = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien);
                foreach (var item in listGuiNhan)
                {                    
                    item.DaXem = true;
                }
                db.SaveChanges();
                return Content("true");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        public ActionResult TraVeThuDenList(string listGuiNhanTraVeThuDen)
        {
            try
            {
                var listIntGuiNhanTraVe = listGuiNhanTraVeThuDen.Split(',').Select(Int32.Parse).ToList();
                foreach (var item in listIntGuiNhanTraVe)
                {
                    GuiNhan gn = db.GuiNhan.Find(item);
                    gn.DaXoa = false;
                }
                db.SaveChanges();
                return Content("true");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        public ActionResult XoaVinhVienList(string listGuiNhanXoa)
        {
            try
            {
                var listIntGuiNhanXoa = listGuiNhanXoa.Split(',').Select(Int32.Parse).ToList();
                foreach (var item in listIntGuiNhanXoa)
                {
                    GuiNhan gn = db.GuiNhan.Find(item);
                    db.GuiNhan.Remove(gn);
                }
                db.SaveChanges();
                return Content("true");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }

        public JsonResult LayTongSoThu(string trangthai)
        {            
            PHCN.NhanVien.Models.NhanVien nhanVienDangNhap = (PHCN.NhanVien.Models.NhanVien)Session["NhanVienDangNhap"];
            ThongTinThu thongtin = new ThongTinThu();
            if (nhanVienDangNhap != null)
            {
                List<GuiNhan> listGuiNhan = new List<GuiNhan>();
                switch (trangthai)
                {
                    case "ThuDen":
                        thongtin.TrangThai = trangthai;
                        thongtin.TongSoThu = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true
                                                                && x.DaXoa == false).Count();
                        thongtin.SoThuChuaDoc = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true
                                                                && x.DaXoa == false
                                                                && x.DaXem == false).Count();
                        break;

                    case "DaGui":
                        thongtin.TrangThai = trangthai;
                        thongtin.TongSoThu = db.GuiNhan.Where(x => x.BaiViet.MaNhanVien == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true
                                                                && x.DaXoa == false
                                                                && x.STTGui == 1).Count();
                        // gửi cho 5 người thì bảng GuiNhan cột STTGui se đánh số từ 1 đến 5, nên chỉ cần lấy ra STTGui là 1
                        break;
                    case "DaXoa":
                        thongtin.TrangThai = trangthai;
                        thongtin.TongSoThu = db.GuiNhan.Where(x => x.NguoiNhan == nhanVienDangNhap.MaNhanVien
                                                                && x.Xoa == false
                                                                && x.DaNhan == true
                                                                && x.DaXoa == true).OrderByDescending(x => x.BaiViet.MaBaiViet).Count();
                        break;

                    default:
                        thongtin.TrangThai = "";
                        thongtin.TongSoThu = 0;
                        thongtin.SoThuChuaDoc = 0;
                        break;
                }
                return Json(thongtin);
            }
            else
            {
                thongtin.TrangThai = "";
                thongtin.TongSoThu = 0;
                thongtin.SoThuChuaDoc = 0;
                return Json(thongtin);
            }
        }
    }
}