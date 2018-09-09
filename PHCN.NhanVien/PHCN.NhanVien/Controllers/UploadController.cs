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
        public ActionResult UploadFileHinhAnh(HttpPostedFileBase file)
        {
            // ajax
            try
            {
                
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    var serverDateTime = CodeController.GetServerDateTime();
                    var fileFullName = fileName.Replace(fileExtension, "") + "-" + serverDateTime.ToString("yyyyMMddhhmmss") + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Content/ImageManager"), fileFullName);
                    file.SaveAs(path);
                    string serverPath = Url.Content("~/Content/ImageManager/" + fileFullName);
                    return Content(serverPath);
                }
                else return Content("false");

            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UploadFileAvatar(int id, HttpPostedFileBase file)
        {
            // ajax
            // id: Mã lý lịch viên chức

            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    var serverDateTime = CodeController.GetServerDateTime();
                    var fileFullName = CodeController.GetMD5(fileName.Replace(fileExtension, "") + "-" + serverDateTime.ToString()) + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Content/ImageAvatar"), fileFullName);
                    file.SaveAs(path);

                    HinhAnh hinhAnh = new HinhAnh();

                    hinhAnh.MaLyLichVienChuc = id;
                    hinhAnh.LoaiHinhAnh = "avatar";
                    hinhAnh.TenFile = "";
                    hinhAnh.TenFileDayDu = fileFullName;
                    hinhAnh.PhanMoRong = fileExtension;
                    hinhAnh.DuongDan = "/Content/ImageAvatar/";
                    hinhAnh.NgayTaiLen = CodeController.GetServerDateTime();

                    db.HinhAnh.Add(hinhAnh);
                    db.SaveChanges();

                    return Content("true");
                }
                else return Content("false");
            }
            catch (Exception ex)
            {
                return Content("Lỗi hệ thống: " + ex.Message);
            }
        }
        [HttpPost]
        public ActionResult UploadFileHinhAnhWeb(int id, HttpPostedFileBase file)
        {
            // ajax
            // id: Mã bài viết

            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    var serverDateTime = CodeController.GetServerDateTime();
                    var fileFullName = CodeController.GetMD5(fileName.Replace(fileExtension, "") + "-" + serverDateTime.ToString()) + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Content/ImageManager"), fileFullName);
                    file.SaveAs(path);
                    HinhAnh hinhAnh = new HinhAnh();
                    hinhAnh.MaBaiViet = id;
                    hinhAnh.LoaiHinhAnh = "baivietweb";
                    hinhAnh.TenFile = "";
                    hinhAnh.TenFileDayDu = fileFullName;
                    hinhAnh.PhanMoRong = fileExtension;
                    hinhAnh.DuongDan = "/Content/ImageManager/";
                    hinhAnh.NgayTaiLen = CodeController.GetServerDateTime();
                    db.HinhAnh.Add(hinhAnh);
                    db.SaveChanges();
                    return Content("true");
                }
                else return Content("false");
            }
            catch (Exception ex)
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