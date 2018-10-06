using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLySucKhoeController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: QuanLySucKhoe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TaoSoKSK(int id)
        {

            // id: MaNhanVien
            var list = db.SoKSK.Where(x => x.MaNhanVien == id && x.Xoa == false).ToList();
            if (list.Any())
            {
                SoKSK soKSK = list.Last();
                return RedirectToAction("CapNhat", new { id = soKSK.MaSoKSK });
            } else
            {
                SoKSK soKSK = new SoKSK();
                soKSK.MaNhanVien = id;
                soKSK.Xoa = true;
                db.SoKSK.Add(soKSK);
                db.SaveChanges();
                return RedirectToAction("CapNhat", new { id = soKSK.MaSoKSK });
            }
            
        }
        public ActionResult CapNhat(int id)
        {
            SoKSK soKSK;  
            soKSK = db.SoKSK.Find(id);
            if (soKSK != null)
            {
                return View(soKSK);
            } else
            {
                return RedirectToAction("ThongBao", "Loi", new { id = "khongtimthaysoksk" });
            }                      
        }

        public ActionResult _pThongTinChung()
        {
            return View();
        }
        public ActionResult _pSoKSK_Benh(int id)
        {
            //id : mã sổ KSK

            var listBenh = db.SoKSK_Benh.Where(x => x.MaSoKSK == id).OrderBy(x=> x.PhatHienNam).ToList();
            return View(listBenh);
        }
        public ActionResult _pmodalChiTietBenh()
        {
            return View();
        }



        // ajax 
        [ValidateInput(false)]

        public ActionResult LuuSoKSK(SoKSK soKSK)
        {
            Thread.Sleep(1000);
            try
            {
                if (soKSK.MaSoKSK > 0)
                {
                    soKSK.Xoa = false;
                    db.Entry(soKSK).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }            
        }        
        public ActionResult XoaSoKSK(int id)
        {
            try
            {
                //id : mã sổ KSK
                int? maNhanVien = 0;
                var soKSK = db.SoKSK.Find(id);
                maNhanVien = soKSK.MaNhanVien;
                soKSK.Xoa = true;
                db.SaveChanges();
                return RedirectToAction("Xem", "QuanLyNhanVien", new { @id = maNhanVien});
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult GetBenhSoKSK(int id)
        {   
            //id: mã bệnh
            PHCN.NhanVien.Models.SoKSK_Benh benh = db.SoKSK_Benh.Find(id);
            return Json(benh);             
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult LuuBenh(SoKSK_Benh benh)
        {
            try
            {
                if (benh.MaBenh > 0)
                {                    
                    db.Entry(benh).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                } else
                {
                    db.SoKSK_Benh.Add(benh);
                    db.SaveChanges();
                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult XoaBenh(int id)
        {
            // id: mã bệnh
            try
            {
                var benh = db.SoKSK_Benh.Find(id);
                db.SoKSK_Benh.Remove(benh);
                db.SaveChanges();                
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult ThemLuotKSK(int id)
        {            
            // id: mã sổ KSK            
            LuotKSK luotKSK = new LuotKSK();
            luotKSK.MaSoKSK = id;
            luotKSK.Ngay = DateTime.MinValue;
            luotKSK.Xoa = true;
            db.LuotKSK.Add(luotKSK);
            db.SaveChanges();
            return RedirectToAction("LuotKham", new { id = luotKSK.MaLuotKSK });
            
        }
        public ActionResult LuotKham(int id)
        {
            LuotKSK luotKSK;
            luotKSK = db.LuotKSK.Find(id);            
            if (luotKSK != null)
            {
                return View(luotKSK);
                
            } else
            {
                return RedirectToAction("ThongBao", "Loi", new { @id = "khongtimthayluotksk" });
            }
        }


        public ActionResult LuuLuotKham(LuotKSK luotKham)
        {
            try
            {
                Thread.Sleep(1000);
                //luotKham.MaNhanVienNhap = ??????
                luotKham.NgayNhap = DateTime.Now;
                luotKham.Xoa = false;
                db.Entry(luotKham).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        public ActionResult XoaLuotKham(int id)
        {
            //id: mã lượt khám
            var luotKham = db.LuotKSK.Find(id);
            int maSoKSK = luotKham.MaSoKSK;
            db.LuotKSK.Remove(luotKham);
            db.SaveChanges();
            return RedirectToAction("CapNhat", "QuanLySucKhoe", new { @id = maSoKSK });
        }


        //json
        [HttpPost]
        public JsonResult GetListNoiDungKSK(string keyword)
        {
            var list = db.NoiDungKSK.Where(x => (x.TenNoiDungKSK.Contains(keyword) && x.Xoa == false) || keyword == "").OrderBy(x => x.STT).Select(x => x.TenNoiDungKSK).Take(20).ToList();
            return Json(list);
        }




    }
}