using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyDeTaiSangKienController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        // GET: QuanLyDeTaiSangKien
        public ActionResult Index()
        {
            var listDeTaiSangKien = db.DeTaiSangKien.OrderBy(x => x.MaDeTaiSangKien).ToList();
            return View(listDeTaiSangKien);
        }
        public ActionResult CapNhat(int? id)
        {
            if (id == null)
            {
                DeTaiSangKien detai = new DeTaiSangKien();
                detai.MaDeTaiSangKien = 0;
                return View(detai);
            } else
            {
                DeTaiSangKien detai = db.DeTaiSangKien.Find(id);
                if (detai == null || detai.Xoa == true)
                {
                    return RedirectToAction("ThongBao", "Loi", new { @id = "duongdankhonghople"});
                }
                return View(detai);
            }
            
        }

        public ActionResult LuuDeTaiSangKien(DeTaiSangKien detai)
        {
            try
            {
                if (detai.MaDeTaiSangKien == 0)
                {
                    db.DeTaiSangKien.Add(detai);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(detai).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        public ActionResult XoaDeTaiSangKien(int id)
        {
            //id: mã đề tài sáng kiến
            try
            {
                var detai = db.DeTaiSangKien.Find(id);
                db.DeTaiSangKien.Remove(detai);
                db.SaveChanges();
                return Content("ok");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
    }
}