using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}