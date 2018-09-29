using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult CapNhat(int? id)
        {
            SoKSK soKSK;            
            if (id == null)
            {
                //soKSK = new SoKSK();                
                //soKSK.Xoa = true;
                //db.SoKSK.Add(soKSK);
                //db.SaveChanges();
                //return RedirectToAction("CapNhat", new { id = soKSK.MaSoKSK });

                return RedirectToAction("ThongBao", "Loi", new { id = "duongdankhonghople" });
            }
            int maSoKSK = 0;
            try
            {
                maSoKSK = int.Parse(id.ToString());
            }
            catch { }
            if (maSoKSK <= 0)
            {
                return RedirectToAction("ThongBao", "Loi", new { id = "khongtimthaysoksk" });
            }
            soKSK = db.SoKSK.Find(maSoKSK);
            return View(soKSK);            
        }
        public ActionResult LuotKham()
        {
            return View();
        }
        public ActionResult _pThongTinChung()
        {
            return View();
        }
        public ActionResult _pSoKSK_Benh()
        {
            return View();
        }
        public ActionResult _pmodalChiTietBenh()
        {
            return View();
        }



        // ajax 
        [ValidateInput(false)]
        public ActionResult LuuSoKSK(SoKSK soKSK)
        {
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
        


    }
}