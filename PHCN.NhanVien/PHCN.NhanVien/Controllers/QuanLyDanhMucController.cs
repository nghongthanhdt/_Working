using PHCN.NhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHCN.NhanVien.Controllers
{
    public class QuanLyDanhMucController : Controller
    {
        PHCN.NhanVien.Models.PHCNEntities db = new Models.PHCNEntities();
        // GET: QuanLyDanhMuc
        public ActionResult Index(string tendanhmuc, string timkiem)
        {
            return View();
        }


        [HttpPost]
        public ActionResult _pTinhThanh(string timkiem)
        {
            var listTinhThanh = new List<TinhThanh>();
            if (timkiem != "")
            {
                listTinhThanh = db.TinhThanh.Where(x => x.Xoa == false && x.TenTinhThanh.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaTinhThanh).ToList();
            } else
            {
                listTinhThanh = db.TinhThanh.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaTinhThanh).ToList();
            }          
                
            return View(listTinhThanh);
        }
        [HttpPost]
        public string LuuTinhThanh(int MaDanhMuc, string TenDanhMuc, int STT)
        {
            
            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.TinhThanh.Find(MaDanhMuc);
                    dm.TenTinhThanh = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                } else
                {
                    TinhThanh dm = new TinhThanh();
                    dm.TenTinhThanh = TenDanhMuc;
                    dm.STT = STT;
                    db.TinhThanh.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }                
            } catch (Exception ex)
            {
                return ex.Message;
            }            
        }
        [HttpPost]
        public string XoaTinhThanh(int MaDanhMuc)
        {
            try
            {                
                var dm = db.TinhThanh.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pHuyenThi(string timkiem)
        {
            var listHuyenThi = new List<HuyenThi>();
            if (timkiem != "")
            {
                listHuyenThi = db.HuyenThi.Where(x => x.Xoa == false && x.TenHuyenThi.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaHuyenThi).ToList();
            }
            else
            {
                listHuyenThi = db.HuyenThi.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaHuyenThi).ToList();
            }

            return View(listHuyenThi);
        }
        [HttpPost]
        public string LuuHuyenThi(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.HuyenThi.Find(MaDanhMuc);
                    dm.TenHuyenThi = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    HuyenThi dm = new HuyenThi();
                    dm.TenHuyenThi = TenDanhMuc;
                    dm.STT = STT;
                    db.HuyenThi.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaHuyenThi(int MaDanhMuc)
        {
            try
            {
                var dm = db.HuyenThi.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pXaPhuong(string timkiem)
        {
            var listXaPhuong = new List<XaPhuong>();
            if (timkiem != "")
            {
                listXaPhuong = db.XaPhuong.Where(x => x.Xoa == false && x.TenXaPhuong.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaXaPhuong).ToList();
            }
            else
            {
                listXaPhuong = db.XaPhuong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaXaPhuong).ToList();
            }

            return View(listXaPhuong);
        }
        [HttpPost]
        public string LuuXaPhuong(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.XaPhuong.Find(MaDanhMuc);
                    dm.TenXaPhuong = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    XaPhuong dm = new XaPhuong();
                    dm.TenXaPhuong = TenDanhMuc;
                    dm.STT = STT;
                    db.XaPhuong.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaXaPhuong(int MaDanhMuc)
        {
            try
            {
                var dm = db.XaPhuong.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpPost]
        public ActionResult _pDonVi(string timkiem)
        {
            var listDonVi = new List<DonVi>();
            if (timkiem != "")
            {
                listDonVi = db.DonVi.Where(x => x.Xoa == false && x.TenDonVi.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaDonVi).ToList();
            }
            else
            {
                listDonVi = db.DonVi.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaDonVi).ToList();
            }

            return View(listDonVi);
        }
        [HttpPost]
        public string LuuDonVi(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.DonVi.Find(MaDanhMuc);
                    dm.TenDonVi = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    DonVi dm = new DonVi();
                    dm.TenDonVi = TenDanhMuc;
                    dm.STT = STT;
                    db.DonVi.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaDonVi(int MaDanhMuc)
        {
            try
            {
                var dm = db.DonVi.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pHocHam(string timkiem)
        {
            var listHocHam = new List<HocHam>();
            if (timkiem != "")
            {
                listHocHam = db.HocHam.Where(x => x.Xoa == false && x.TenHocHam.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaHocHam).ToList();
            }
            else
            {
                listHocHam = db.HocHam.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaHocHam).ToList();
            }

            return View(listHocHam);
        }
        [HttpPost]
        public string LuuHocHam(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.HocHam.Find(MaDanhMuc);
                    dm.TenHocHam = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    HocHam dm = new HocHam();
                    dm.TenHocHam = TenDanhMuc;
                    dm.STT = STT;
                    db.HocHam.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaHocHam(int MaDanhMuc)
        {
            try
            {
                var dm = db.HocHam.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pHocVi(string timkiem)
        {
            var listHocVi = new List<HocVi>();
            if (timkiem != "")
            {
                listHocVi = db.HocVi.Where(x => x.Xoa == false && x.TenHocVi.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaHocVi).ToList();
            }
            else
            {
                listHocVi = db.HocVi.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaHocVi).ToList();
            }

            return View(listHocVi);
        }
        [HttpPost]
        public string LuuHocVi(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.HocVi.Find(MaDanhMuc);
                    dm.TenHocVi = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    HocVi dm = new HocVi();
                    dm.TenHocVi = TenDanhMuc;
                    dm.STT = STT;
                    db.HocVi.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaHocVi(int MaDanhMuc)
        {
            try
            {
                var dm = db.HocVi.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pChuyenMon(string timkiem)
        {
            var listChuyenMon = new List<ChuyenMon>();
            if (timkiem != "")
            {
                listChuyenMon = db.ChuyenMon.Where(x => x.Xoa == false && x.TenChuyenMon.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaChuyenMon).ToList();
            }
            else
            {
                listChuyenMon = db.ChuyenMon.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaChuyenMon).ToList();
            }

            return View(listChuyenMon);
        }
        [HttpPost]
        public string LuuChuyenMon(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.ChuyenMon.Find(MaDanhMuc);
                    dm.TenChuyenMon = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    ChuyenMon dm = new ChuyenMon();
                    dm.TenChuyenMon = TenDanhMuc;
                    dm.STT = STT;
                    db.ChuyenMon.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaChuyenMon(int MaDanhMuc)
        {
            try
            {
                var dm = db.ChuyenMon.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pHinhThucDaoTao(string timkiem)
        {
            var listHinhThucDaoTao = new List<HinhThucDaoTao>();
            if (timkiem != "")
            {
                listHinhThucDaoTao = db.HinhThucDaoTao.Where(x => x.Xoa == false && x.TenHinhThucDaoTao.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaHinhThucDaoTao).ToList();
            }
            else
            {
                listHinhThucDaoTao = db.HinhThucDaoTao.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaHinhThucDaoTao).ToList();
            }

            return View(listHinhThucDaoTao);
        }
        [HttpPost]
        public string LuuHinhThucDaoTao(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.HinhThucDaoTao.Find(MaDanhMuc);
                    dm.TenHinhThucDaoTao = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    HinhThucDaoTao dm = new HinhThucDaoTao();
                    dm.TenHinhThucDaoTao = TenDanhMuc;
                    dm.STT = STT;
                    db.HinhThucDaoTao.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaHinhThucDaoTao(int MaDanhMuc)
        {
            try
            {
                var dm = db.HinhThucDaoTao.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pLoaiHopDong(string timkiem)
        {
            var listLoaiHopDong = new List<LoaiHopDong>();
            if (timkiem != "")
            {
                listLoaiHopDong = db.LoaiHopDong.Where(x => x.Xoa == false && x.TenLoaiHopDong.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaLoaiHopDong).ToList();
            }
            else
            {
                listLoaiHopDong = db.LoaiHopDong.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaLoaiHopDong).ToList();
            }

            return View(listLoaiHopDong);
        }
        [HttpPost]
        public string LuuLoaiHopDong(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.LoaiHopDong.Find(MaDanhMuc);
                    dm.TenLoaiHopDong = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    LoaiHopDong dm = new LoaiHopDong();
                    dm.TenLoaiHopDong = TenDanhMuc;
                    dm.STT = STT;
                    db.LoaiHopDong.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaLoaiHopDong(int MaDanhMuc)
        {
            try
            {
                var dm = db.LoaiHopDong.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pDanToc(string timkiem)
        {
            var listDanToc = new List<DanToc>();
            if (timkiem != "")
            {
                listDanToc = db.DanToc.Where(x => x.Xoa == false && x.TenDanToc.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaDanToc).ToList();
            }
            else
            {
                listDanToc = db.DanToc.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaDanToc).ToList();
            }

            return View(listDanToc);
        }
        [HttpPost]
        public string LuuDanToc(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.DanToc.Find(MaDanhMuc);
                    dm.TenDanToc = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    DanToc dm = new DanToc();
                    dm.TenDanToc = TenDanhMuc;
                    dm.STT = STT;
                    db.DanToc.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaDanToc(int MaDanhMuc)
        {
            try
            {
                var dm = db.DanToc.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public ActionResult _pTonGiao(string timkiem)
        {
            var listTonGiao = new List<TonGiao>();
            if (timkiem != "")
            {
                listTonGiao = db.TonGiao.Where(x => x.Xoa == false && x.TenTonGiao.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaTonGiao).ToList();
            }
            else
            {
                listTonGiao = db.TonGiao.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaTonGiao).ToList();
            }

            return View(listTonGiao);
        }
        [HttpPost]
        public string LuuTonGiao(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.TonGiao.Find(MaDanhMuc);
                    dm.TenTonGiao = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    TonGiao dm = new TonGiao();
                    dm.TenTonGiao = TenDanhMuc;
                    dm.STT = STT;
                    db.TonGiao.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaTonGiao(int MaDanhMuc)
        {
            try
            {
                var dm = db.TonGiao.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]

        public ActionResult _pChinhQuyen(string timkiem)
        {
            var listChinhQuyen = new List<ChinhQuyen>();
            if (timkiem != "")
            {
                listChinhQuyen = db.ChinhQuyen.Where(x => x.Xoa == false && x.TenChinhQuyen.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaChinhQuyen).ToList();
            }
            else
            {
                listChinhQuyen = db.ChinhQuyen.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaChinhQuyen).ToList();
            }

            return View(listChinhQuyen);
        }
        [HttpPost]
        public string LuuChinhQuyen(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.ChinhQuyen.Find(MaDanhMuc);
                    dm.TenChinhQuyen = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    ChinhQuyen dm = new ChinhQuyen();
                    dm.TenChinhQuyen = TenDanhMuc;
                    dm.STT = STT;
                    db.ChinhQuyen.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaChinhQuyen(int MaDanhMuc)
        {
            try
            {
                var dm = db.ChinhQuyen.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pDoanThe(string timkiem)
        {
            var listDoanThe = new List<DoanThe>();
            if (timkiem != "")
            {
                listDoanThe = db.DoanThe.Where(x => x.Xoa == false && x.TenDoanThe.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaDoanThe).ToList();
            }
            else
            {
                listDoanThe = db.DoanThe.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaDoanThe).ToList();
            }

            return View(listDoanThe);
        }
        [HttpPost]
        public string LuuDoanThe(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.DoanThe.Find(MaDanhMuc);
                    dm.TenDoanThe = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    DoanThe dm = new DoanThe();
                    dm.TenDoanThe = TenDanhMuc;
                    dm.STT = STT;
                    db.DoanThe.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaDoanThe(int MaDanhMuc)
        {
            try
            {
                var dm = db.DoanThe.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pDang(string timkiem)
        {
            var listDang = new List<Dang>();
            if (timkiem != "")
            {
                listDang = db.Dang.Where(x => x.Xoa == false && x.TenDang.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaDang).ToList();
            }
            else
            {
                listDang = db.Dang.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaDang).ToList();
            }

            return View(listDang);
        }
        [HttpPost]
        public string LuuDang(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.Dang.Find(MaDanhMuc);
                    dm.TenDang = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    Dang dm = new Dang();
                    dm.TenDang = TenDanhMuc;
                    dm.STT = STT;
                    db.Dang.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaDang(int MaDanhMuc)
        {
            try
            {
                var dm = db.Dang.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pMaCCHN(string timkiem)
        {
            var listMaCCHN = new List<MaCCHN>();
            if (timkiem != "")
            {
                listMaCCHN = db.MaCCHN.Where(x => x.Xoa == false && x.TenMaCCHN.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaMaCCHN).ToList();
            }
            else
            {
                listMaCCHN = db.MaCCHN.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaMaCCHN).ToList();
            }

            return View(listMaCCHN);
        }
        [HttpPost]
        public string LuuMaCCHN(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.MaCCHN.Find(MaDanhMuc);
                    dm.TenMaCCHN = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    MaCCHN dm = new MaCCHN();
                    dm.TenMaCCHN = TenDanhMuc;
                    dm.STT = STT;
                    db.MaCCHN.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaMaCCHN(int MaDanhMuc)
        {
            try
            {
                var dm = db.MaCCHN.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pPhamViHoatDongChuyenMon(string timkiem)
        {
            var listPhamViHoatDongChuyenMon = new List<PhamViHoatDongChuyenMon>();
            if (timkiem != "")
            {
                listPhamViHoatDongChuyenMon = db.PhamViHoatDongChuyenMon.Where(x => x.Xoa == false && x.TenPhamViHoatDongChuyenMon.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaPhamViHoatDongChuyenMon).ToList();
            }
            else
            {
                listPhamViHoatDongChuyenMon = db.PhamViHoatDongChuyenMon.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaPhamViHoatDongChuyenMon).ToList();
            }

            return View(listPhamViHoatDongChuyenMon);
        }
        [HttpPost]
        public string LuuPhamViHoatDongChuyenMon(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.PhamViHoatDongChuyenMon.Find(MaDanhMuc);
                    dm.TenPhamViHoatDongChuyenMon = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    PhamViHoatDongChuyenMon dm = new PhamViHoatDongChuyenMon();
                    dm.TenPhamViHoatDongChuyenMon = TenDanhMuc;
                    dm.STT = STT;
                    db.PhamViHoatDongChuyenMon.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaPhamViHoatDongChuyenMon(int MaDanhMuc)
        {
            try
            {
                var dm = db.PhamViHoatDongChuyenMon.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pNgheNghiep(string timkiem)
        {
            var listNgheNghiep = new List<NgheNghiep>();
            if (timkiem != "")
            {
                listNgheNghiep = db.NgheNghiep.Where(x => x.Xoa == false && x.TenNgheNghiep.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaNgheNghiep).ToList();
            }
            else
            {
                listNgheNghiep = db.NgheNghiep.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaNgheNghiep).ToList();
            }

            return View(listNgheNghiep);
        }
        [HttpPost]
        public string LuuNgheNghiep(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.NgheNghiep.Find(MaDanhMuc);
                    dm.TenNgheNghiep = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    NgheNghiep dm = new NgheNghiep();
                    dm.TenNgheNghiep = TenDanhMuc;
                    dm.STT = STT;
                    db.NgheNghiep.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaNgheNghiep(int MaDanhMuc)
        {
            try
            {
                var dm = db.NgheNghiep.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ActionResult _pChuyenMuc(string timkiem)
        {
            var listChuyenMuc = new List<ChuyenMuc>();
            if (timkiem != "")
            {
                listChuyenMuc = db.ChuyenMuc.Where(x => x.Xoa == false && x.TenChuyenMuc.Contains(timkiem)).OrderBy(x => x.STT).ThenBy(x => x.MaChuyenMuc).ToList();
            }
            else
            {
                listChuyenMuc = db.ChuyenMuc.Where(x => x.Xoa == false).OrderBy(x => x.STT).ThenBy(x => x.MaChuyenMuc).ToList();
            }

            return View(listChuyenMuc);
        }
        [HttpPost]
        public string LuuChuyenMuc(int MaDanhMuc, string TenDanhMuc, int STT)
        {

            try
            {
                if (MaDanhMuc > 0)
                {
                    var dm = db.ChuyenMuc.Find(MaDanhMuc);
                    dm.TenChuyenMuc = TenDanhMuc;
                    dm.STT = STT;
                    db.SaveChanges();
                    return "ok";
                }
                else
                {
                    ChuyenMuc dm = new ChuyenMuc();
                    dm.TenChuyenMuc = TenDanhMuc;
                    dm.STT = STT;
                    db.ChuyenMuc.Add(dm);
                    db.SaveChanges();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public string XoaChuyenMuc(int MaDanhMuc)
        {
            try
            {
                var dm = db.ChuyenMuc.Find(MaDanhMuc);
                dm.Xoa = true;
                db.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}