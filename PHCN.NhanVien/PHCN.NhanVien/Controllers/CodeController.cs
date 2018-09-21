using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public static class CodeController
    {
        static PHCNEntities db = new Models.PHCNEntities();
        // GET: Lib
        public static DateTime GetServerDateTime()
        {
            var dateQuery = db.Database.SqlQuery<DateTime>("SELECT getdate()");
            DateTime serverDate = dateQuery.AsEnumerable().First();
            return serverDate;
        }
        public static string GetMD5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString().ToLower();
        }
        public static string layThamSoHeThong(string maThamSo)
        {
            try
            {
                string result = db.ThamSoHeThong.Find(maThamSo).GiaTri;
                return result;
            } catch
            {
                string result = "[Không tìm thấy tham số]";
                return result;
            }
            
        }
        public static string ChuyenTiengVietCoDauSangKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}