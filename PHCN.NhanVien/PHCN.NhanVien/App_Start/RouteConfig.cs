using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PHCN.NhanVien
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "XamBaiViet",
                url: "tin-tuc/{TenChuyenMucRewrite}/{TenBaiVietRewrite}.{MaBaiViet}.html",
                defaults: new { controller = "TinTuc", action = "XemBaiViet"}
            );
            routes.MapRoute(
                name: "TinTuc",
                url: "tin-tuc/{TenChuyenMucRewrite}",
                defaults: new { controller = "TinTuc", action = "Index", TenChuyenMucRewrite = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
