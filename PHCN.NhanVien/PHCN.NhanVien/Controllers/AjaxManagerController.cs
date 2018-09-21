using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class AjaxManagerController : Controller
    {
        // GET: AjaxManager
        PHCNEntities db = new PHCNEntities();
        public ActionResult Index()
        {
            return View();
        }

        // load avatar 
        public JsonResult GetLastAvatar(int id)
        {
            // id: mã lý lịch viên chức
            var list = db.HinhAnh.Where(x => x.MaLyLichVienChuc == id).OrderByDescending(x => x.MaHinhAnh).ToList();
            if (list.Any())
            {
                HinhAnh hinhAnh = list.First();
                var result = new
                {
                    MaLyLichVienChuc = id,
                    MaHinhAnh = hinhAnh.MaHinhAnh,
                    UrlAvatar = hinhAnh.DuongDan + hinhAnh.TenFileDayDu
                };
                return Json(result, JsonRequestBehavior.DenyGet); 
            } else
            {
                var result = new
                {
                    MaLyLichVienChuc = 0,
                    MaHinhAnh = 0,
                    UrlAvatar = ""
                };
                return Json(result, JsonRequestBehavior.DenyGet);
            }
        }
        public string XoaAvatar(int id)
        {
            //update cho đường dẫn của ảnh đại diện về mặc định
            // id: mã hình ảnh
            var hinhAnh = db.HinhAnh.Find(id);
            hinhAnh.TenFileDayDu = "default-avatar.png";
            db.Entry(hinhAnh).State = EntityState.Modified;
            db.SaveChanges();
            return "ok";
        }


        // các autocomplete
        public JsonResult GetListTinhThanh(string keyword)
        {
            
            var list = db.TinhThanh.Where(x => x.TenTinhThanh.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenTinhThanh).Take(10).ToList();            
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListHuyenThi(string keyword)
        {
            
            var list = db.HuyenThi.Where(x => x.TenHuyenThi.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenHuyenThi).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListXaPhuong(string keyword)
        {

            var list = db.XaPhuong.Where(x => x.TenXaPhuong.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenXaPhuong).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListDanToc(string keyword)
        {
            var list = db.DanToc.Where(x => x.TenDanToc.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenDanToc).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListTonGiao(string keyword)
        {
            var list = db.TonGiao.Where(x => x.TenTonGiao.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenTonGiao).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListChuyenMon(string keyword)
        {
            var list = db.ChuyenMon.Where(x => x.TenChuyenMon.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenChuyenMon).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListChucDanhNgheNghiep(string keyword)
        {
            var list = db.ChucDanhNgheNghiep.Where(x => x.TenChucDanhNgheNghiep.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenChucDanhNgheNghiep).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListPhamViHoatDongChuyenMon(string keyword)
        {
            var list = db.PhamViHoatDongChuyenMon.Where(x => x.TenPhamViHoatDongChuyenMon.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenPhamViHoatDongChuyenMon).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListNgheNghiep(string keyword)
        {
            var list = db.NgheNghiep.Where(x => x.TenNgheNghiep.Contains(keyword)).OrderBy(x => x.STT).Select(x => x.TenNgheNghiep).Take(10).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // quá trình lương
        public string LuuQuaTrinhLuong(DienBienQuaTrinhLuong qtLuong)
        {
            if (qtLuong.MaDienBienQuaTrinhLuong == 0)
            {
                db.DienBienQuaTrinhLuong.Add(qtLuong);
                db.SaveChanges();
            } else
            {
                db.Entry(qtLuong).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        public JsonResult GetDienBienQuaTrinhLuong(int id)
        {
            DienBienQuaTrinhLuong dienbien = new DienBienQuaTrinhLuong();
            dienbien = db.DienBienQuaTrinhLuong.Find(id);

            object _dienbien = new
            {
                MaDienBienQuaTrinhLuong = dienbien.MaDienBienQuaTrinhLuong,
                MaChucDanhNgheNghiep = dienbien.MaChucDanhNgheNghiep,
                BacLuong = dienbien.BacLuong,
                HeSo = dienbien.HeSo,
                VuotKhung = dienbien.VuotKhung,
                NgayHuong = DateTime.Parse(dienbien.NgayHuong.ToString()).ToString("dd/MM/yyyy"),
                PhuCapChucVu = dienbien.PhuCapChucVu,
                PhuCapKhac = dienbien.PhuCapKhac
            };
            return Json(_dienbien, JsonRequestBehavior.AllowGet);
        }
        public string XoaDienBienQuaTrinhLuong(int id)
        {
            //id: mã diễn biến
            DienBienQuaTrinhLuong dienbien = db.DienBienQuaTrinhLuong.Find(id);
            db.DienBienQuaTrinhLuong.Remove(dienbien);
            db.SaveChanges();
            return "ok";
        }
        public JsonResult GetLastDienBienQuaTrinhLuong(int maLyLichVienChuc)
        {
            var list = db.DienBienQuaTrinhLuong.Where(x => x.MaLyLichVienChuc == maLyLichVienChuc).OrderBy(x => x.NgayHuong).ToList();
            if (list.Any())
            {
                DienBienQuaTrinhLuong dienbien = new DienBienQuaTrinhLuong();
                dienbien = list.Last();
                object _dienbien = new
                {
                        MaDienBienQuaTrinhLuong = dienbien.MaDienBienQuaTrinhLuong,
                        MaChucDanhNgheNghiep = dienbien.MaChucDanhNgheNghiep,
                        MaSoChucDanhNgheNghiep = dienbien.ChucDanhNgheNghiep.MaSo,
                        TenChucDanh = dienbien.ChucDanhNgheNghiep.TenChucDanhNgheNghiep,
                        BacLuong = dienbien.BacLuong,
                        HeSo = dienbien.HeSo,
                        VuotKhung = dienbien.VuotKhung,
                        NgayHuong = DateTime.Parse(dienbien.NgayHuong.ToString()).ToString("dd/MM/yyyy"),
                        PhuCapChucVu = dienbien.PhuCapChucVu,
                        PhuCapKhac = dienbien.PhuCapKhac
                    };
                return Json(_dienbien, JsonRequestBehavior.AllowGet);
            } else return null;
            


            
        }

        // đào tạo bồi dưỡng
        public JsonResult GetDienBienDaoTaoBoiDuong(int id)
        {
            DienBienDaoTaoBoiDuong dienbien = new DienBienDaoTaoBoiDuong();
            dienbien = db.DienBienDaoTaoBoiDuong.Find(id);

            object _dienbien = new
            {
                TenTruong = dienbien.TenTruong,
                ChuyenNganhDaoTaoBoiDuong = dienbien.ChuyenNganhDaoTaoBoiDuong,
                TuThangNam = DateTime.Parse(dienbien.TuThangNam.ToString()).ToString("MM/yyyy"),
                DenThangNam = DateTime.Parse(dienbien.DenThangNam.ToString()).ToString("MM/yyyy"),
                MaHinhThucDaoTao = dienbien.MaHinhThucDaoTao,
                VanBangChungChiTrinhDo = dienbien.VanBangChungChiTrinhDo
            };
            return Json(_dienbien, JsonRequestBehavior.AllowGet);
        }
        public string LuuDienBienDaoTaoBoiDuong(DienBienDaoTaoBoiDuong dienbien)
        {
            if (dienbien.MaDienBienDaoTaoBoiDuong == 0)
            {
                db.DienBienDaoTaoBoiDuong.Add(dienbien);
                db.SaveChanges();
            }
            else
            {
                db.Entry(dienbien).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        public string XoaDienBienDaoTaoBoiDuong(int id)
        {
            //id: mã diễn biến
            DienBienDaoTaoBoiDuong dienbien = db.DienBienDaoTaoBoiDuong.Find(id);
            db.DienBienDaoTaoBoiDuong.Remove(dienbien);
            db.SaveChanges();
            return "ok";
        }

        // quá trình công tác
        public JsonResult GetDienBienQuaTrinhCongTac(int id)
        {
            DienBienQuaTrinhCongTac dienbien = new DienBienQuaTrinhCongTac();
            dienbien = db.DienBienQuaTrinhCongTac.Find(id);

            object _dienbien = new
            {
                
                TuThangNam = DateTime.Parse(dienbien.TuThangNam.ToString()).ToString("MM/yyyy"),
                DenThangNam = DateTime.Parse(dienbien.DenThangNam.ToString()).ToString("MM/yyyy"),                
                NoiDungCongTac = dienbien.NoiDungCongTac
            };
            return Json(_dienbien, JsonRequestBehavior.AllowGet);
        }
        public string LuuDienBienQuaTrinhCongTac(DienBienQuaTrinhCongTac dienbien)
        {
            if (dienbien.MaDienBienQuaTrinhCongTac == 0)
            {
                db.DienBienQuaTrinhCongTac.Add(dienbien);
                db.SaveChanges();
            }
            else
            {
                db.Entry(dienbien).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        public string XoaDienBienQuaTrinhCongTac(int id)
        {
            //id: mã diễn biến
            DienBienQuaTrinhCongTac dienbien = db.DienBienQuaTrinhCongTac.Find(id);
            db.DienBienQuaTrinhCongTac.Remove(dienbien);
            db.SaveChanges();
            return "ok";
        }


        // lưu lý lịch viên chức
        [HttpPost]
        public string LuuLyLichVienChuc(LyLichVienChuc lylich)
        {

            if (lylich.MaLyLichVienChuc > 0)
            {
                //update lý lịch
                db.Entry(lylich).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
        //public string XoaLyLichVienChuc()

        // lưu thông tin liên hệ nhân viên
        [HttpPost]
        public string LuuThongTinLienHeNhanVien(int id, string Email, string DienThoai, string DienThoaiNoiBo)
        {
            //id: Mã nhân viên
            try
            {
                PHCN.NhanVien.Models.NhanVien nv = db.NhanVien.Find(id);
                nv.Email = Email;
                nv.SoDienThoai = DienThoai;
                nv.SoDienThoaiNoiBo = DienThoaiNoiBo;
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return "ok";
            } catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        [HttpPost]
        public string DoiMatKhauNhanVien(int id, string MatKhauCu, string MatKhauMoi)
        {
            try
            {
                PHCN.NhanVien.Models.NhanVien nv = db.NhanVien.Find(id);
                nv.MatKhau = MatKhauMoi;
                nv.MatKhauMD5 = CodeController.GetMD5(MatKhauMoi);
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return "ok";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // diễn biến bổ sung phạm vi hoạt động chuyên môn
        public JsonResult GetDienBienBoSungPhamViHDCM(int id)
        {
            BoSungPhamViHDCM bs = new BoSungPhamViHDCM();
            bs = db.BoSungPhamViHDCM.Find(id);
            object _bs = new
            {
                SoQuyetDinh = bs.SoQuyetDinh,
                NgayCap = bs.NgayCap.ToString("dd/MM/yyyy"),
                NoiDungBoSung = bs.NoiDungBoSung
            };
            return Json(_bs, JsonRequestBehavior.AllowGet);
        }
        public string XoaDienBienBoSungPhamViHDCM(int id)
        {
            //id: mã diễn biến
            BoSungPhamViHDCM bs = db.BoSungPhamViHDCM.Find(id);
            db.BoSungPhamViHDCM.Remove(bs);
            db.SaveChanges();
            return "ok";
        }
        public string LuuDienBienBoSungPhamViHDCM(BoSungPhamViHDCM bs)
        {
            if (bs.MaBoSungPhamViHDCM == 0)
            {
                db.BoSungPhamViHDCM.Add(bs);
                db.SaveChanges();
            }
            else
            {
                db.Entry(bs).State = EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }

        // cập nhật hình ảnh đại diện của bài viết
        public JsonResult LuuHinhAnhDaiDienChoBaiViet(int MaBaiViet, int MaHinhAnh)
        {
            
            var listHinhAnh = db.HinhAnh.Where(x => x.LoaiHinhAnh == "baivietweb" && x.Xoa != true && x.MaBaiViet == MaBaiViet).ToList();
            foreach (var item in listHinhAnh)
            {
                item.DaiDienBaiVietWeb = false;
            }
            db.SaveChanges();
            var hinhanh = db.HinhAnh.Find(MaHinhAnh);
            hinhanh.DaiDienBaiVietWeb = true;
            db.SaveChanges();
            return Json(hinhanh);
        }
        public string GetDuongDanHinhAnh(int MaHinhAnh)
        {
            var hinhanh = db.HinhAnh.Find(MaHinhAnh);
            if (hinhanh != null)
            {
                string str = hinhanh.DuongDan + hinhanh.TenFileDayDu;
                return str;
            } else
            {
                return "";
            }
        }
        public string XoaHinhAnh(int MaHinhAnh)
        {
            try
            {
                var hinhanh = db.HinhAnh.Find(MaHinhAnh);
                hinhanh.Xoa = true;
                db.SaveChanges();
                return "ok";
            } catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        [HttpPost]
        public string XoaFileDinhKemWeb(int MaFile)
        {
            try
            {
                var file = db.FileDinhKem.Find(MaFile);
                file.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaAnhDaiDien(int MaBaiViet)
        {
            try
            {
                var listHinhAnh = db.HinhAnh.Where(x => x.LoaiHinhAnh == "baivietweb" && x.Xoa != true && x.MaBaiViet == MaBaiViet).ToList();
                foreach (var item in listHinhAnh)
                {
                    item.DaiDienBaiVietWeb = false;
                }                
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [ValidateInput(false)]
        public string LuuBaiVietWeb(BaiVietWeb baiviet)
        {

            if (baiviet.MaBaiViet > 0)
            {
                //update bài viết
                baiviet.CapNhatLanCuoi = DateTime.Now;                
                db.Entry(baiviet).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return "ok";
        }
    }
}