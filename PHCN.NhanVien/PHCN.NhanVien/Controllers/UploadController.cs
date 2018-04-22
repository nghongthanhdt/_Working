using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class UploadController : Controller
    {
        PHCNEntities db = new PHCNEntities();
        [HttpPost]
        public ActionResult UploadFile(int id, HttpPostedFileBase file)
        {
            // id là mã bài viết
            try
            {
                    //var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var fileExtension = Path.GetExtension(file.FileName).ToLower();
                        var serverDateTime = CodeController.GetServerDateTime();
                        var fileFullName = fileName.Replace(fileExtension, "") + "-" +  serverDateTime.ToString("yyyyMMddhhmmss") + fileExtension;
                        var path = Path.Combine(Server.MapPath("~/Content/FileManager/"), fileFullName);
                        file.SaveAs(path);

                        FileDinhKem fileDinhKem = new FileDinhKem();

                        fileDinhKem.MaBaiViet = id;
                        fileDinhKem.TenFile = fileName;
                        fileDinhKem.TenFileFull = fileFullName;
                        fileDinhKem.PhanMoRong = fileExtension;
                        fileDinhKem.NgayTaiLen = CodeController.GetServerDateTime();

                        db.FileDinhKem.Add(fileDinhKem);
                        db.SaveChanges();
                        return Content("true");
                    }
                    else return Content("File không hợp lệ !");
                
            } catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }

        [HttpPost] 
        public ActionResult XoaFileDinhKem(int id)
        {
            try
            {
                // id là mã file đính kèm // set bit xóa của file đính kèm là true
                var fileDinhKem = db.FileDinhKem.Find(id);
                fileDinhKem.Xoa = true;
                db.SaveChanges();
                return Content("true");
            } catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }

    }
}