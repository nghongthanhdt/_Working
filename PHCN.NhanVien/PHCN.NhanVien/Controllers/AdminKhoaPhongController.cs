using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class AdminKhoaPhongController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: AdminKhoaPhong
        public ActionResult Index()
        {
            List<KhoaPhong> listKhoaPhong = db.KhoaPhong.Where(x => x.Xoa != true).OrderBy(x => x.STT).ToList();
            return View(listKhoaPhong);            
        }
        public ActionResult Edit(string id)
        {
            if (id != null && id != "")
            {
                KhoaPhong kp = db.KhoaPhong.Find(id);
                if (kp.Xoa == true)
                {
                    return RedirectToAction("TuChoiTruyCap", "Admin");
                }
                return View(kp);
            }
            else
            {
                KhoaPhong kp = new KhoaPhong();
                kp.MaKhoa = "";
                return View(kp);
            }
        }
        public ActionResult Save(string MaKhoa, string TenKhoa, int STT, string Mode)
        {
            try
            {

                if (Mode == "edit")
                {
                    var khoa = db.KhoaPhong.Find(MaKhoa);
                    khoa.TenKhoa = TenKhoa;
                    khoa.STT = STT;
                    db.SaveChanges();
                }
                else
                {                   
                    KhoaPhong khoa = new KhoaPhong();
                    khoa.MaKhoa = MaKhoa.ToUpper();
                    khoa.TenKhoa = TenKhoa;
                    khoa.STT = STT;
                    db.KhoaPhong.Add(khoa);
                    db.SaveChanges();                    
                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult Delete(string MaKhoa)
        {
            try
            {
                NhanVien.Models.KhoaPhong khoaphong = db.KhoaPhong.Find(MaKhoa);
                khoaphong.Xoa = true;
                db.SaveChanges();
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult CapNhatSTT(string ListMaKhoa, string ListSTTValue)
        {
            try
            {
                var liststringMaKhoa = ListMaKhoa.Split(',').ToList();
                var liststringSTT = ListSTTValue.Split(',').Select(Int32.Parse).ToList();
                for (int i = 0; i < liststringMaKhoa.Count(); i++)
                {
                    var khoa = db.KhoaPhong.Find(liststringMaKhoa[i]);
                    khoa.STT = liststringSTT[i];
                }
                db.SaveChanges();
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }            
        }
    }
}