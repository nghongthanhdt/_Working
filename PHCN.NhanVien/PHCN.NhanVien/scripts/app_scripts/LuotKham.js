$(document).ready(function () {
    //bindbtnLuu_OnClick();
    //bindlinkThemBenh_OnClick();
    //loadDanhSachBenh();



    var url = urlController + "GetListNoiDungKSK";    
    bindSuggest(".noidungksk", url);


    bindtxtNgay_OnChange();
    bindbtnLuu_OnClick();
    if ($("#txtNgay").val() == "01/01/0001") {
        $("#txtNgay").val("");
    }    
    $("#txtNgay").focus();


    $(':input').focus(function () {
        var center = $(window).height() / 3;
        var top = $(this).offset().top;
        if (top > center) {
            $('html, body').animate({ scrollTop: top - center }, 'fast');
        }
    });

    
});
function bindtxtNgay_OnChange() {
    $("#txtNgay").unbind("change").change(function () {
        var ngay = $(this).val();
        $("#txtKL_NgayKy").val(ngay);
    });
}
function bindbtnLuu_OnClick() {
    $("#btnLuu").unbind("click").click(function () {
        
        var pMaLuotKSK = $("#hiddenMaLuotKSK").val();
        var pMaSoKSK = $("#hiddenMaSoKSK").val();
        var pNgay = $("#txtNgay").val();
        var pTienSuBenhTat = $("#txtTienSuBenhTat").val();
        var pTL_ChieuCao = $("#txtTL_ChieuCao").val();
        var pTL_CanNang = $("#txtTL_CanNang").val();
        var pTL_ChiSoBMI = $("#txtTL_ChiSoBMI").val();
        var pTL_Mach = $("#txtTL_Mach").val();
        var pTL_HuyetAp = $("#txtTL_HuyetAp").val();
        var pTL_PhanLoaiTheLuc = $("#selectTL_PhanLoaiTheLuc").val();
        var pLS_NoiKhoa_TuanHoan = $("#txtLS_NoiKhoa_TuanHoan").val();
        var pLS_NoiKhoa_TuanHoan_PhanLoai = $("#selectLS_NoiKhoa_TuanHoan_PhanLoai").val();
        var pLS_NoiKhoa_HoHap = $("#txtLS_NoiKhoa_HoHap").val();
        var pLS_NoiKhoa_HoHap_PhanLoai = $("#selectLS_NoiKhoa_HoHap_PhanLoai").val();
        var pLS_NoiKhoa_TieuHoa = $("#txtLS_NoiKhoa_TieuHoa").val();
        var pLS_NoiKhoa_TieuHoa_PhanLoai = $("#selectLS_NoiKhoa_TieuHoa_PhanLoai").val();
        var pLS_NoiKhoa_ThanTietNieu = $("#txtLS_NoiKhoa_ThanTietNieu").val();
        var pLS_NoiKhoa_ThanTietNieu_PhanLoai = $("#selectLS_NoiKhoa_ThanTietNieu_PhanLoai").val();
        var pLS_NoiKhoa_NoiTiet = $("#txtLS_NoiKhoa_NoiTiet").val();
        var pLS_NoiKhoa_NoiTiet_PhanLoai = $("#selectLS_NoiKhoa_NoiTiet_PhanLoai").val();
        var pLS_NoiKhoa_CoXuongKhop = $("#txtLS_NoiKhoa_CoXuongKhop").val();
        var pLS_NoiKhoa_CoXuongKhop_PhanLoai = $("#selectLS_NoiKhoa_CoXuongKhop_PhanLoai").val();
        var pLS_NoiKhoa_ThanKinh = $("#txtLS_NoiKhoa_ThanKinh").val();
        var pLS_NoiKhoa_ThanKinh_PhanLoai = $("#selectLS_NoiKhoa_ThanKinh_PhanLoai").val();
        var pLS_NoiKhoa_TamThan = $("#txtLS_NoiKhoa_TamThan").val();
        var pLS_NoiKhoa_ThamThan_PhanLoai = $("#selectLS_NoiKhoa_ThamThan_PhanLoai").val();
        var pLS_NoiKhoa_BacSiKy = $("#selectLS_NoiKhoa_BacSiKy").val();
        var pLS_NgoaiKhoa = $("#txtLS_NgoaiKhoa").val();
        var pLS_NgoaiKhoa_PhanLoai = $("#selectLS_NgoaiKhoa_PhanLoai").val();
        var pLS_NgoaiKhoa_BacSiKy = $("#selectLS_NgoaiKhoa_BacSiKy").val();
        var pLS_SanPhuKhoa = $("#txtLS_SanPhuKhoa").val();
        var pLS_SanPhuKhoa_PhanLoai = $("#selectLS_SanPhuKhoa_PhanLoai").val();
        var pLS_SanPhuKhoa_BacSiKy = $("#selectLS_SanPhuKhoa_BacSiKy").val();
        var pLS_Mat_KhongKinhMatPhai = $("#txtLS_Mat_KhongKinhMatPhai").val();
        var pLS_Mat_KhongKinhMatTrai = $("#txtLS_Mat_KhongKinhMatTrai").val();
        var pLS_Mat_CoKinhMatPhai = $("#txtLS_Mat_CoKinhMatPhai").val();
        var pLS_Mat_CoKinhMatTrai = $("#txtLS_Mat_CoKinhMatTrai").val();
        var pLS_Mat_CacBenhVeMat = $("#txtLS_Mat_CacBenhVeMat").val();
        var pLS_Mat_PhanLoai = $("#selectLS_Mat_PhanLoai").val();
        var pLS_Mat_BacSiKy = $("#selectLS_Mat_BacSiKy").val();
        var pLS_TaiMuiHong_TaiTraiNoiThuong = $("#txtLS_TaiMuiHong_TaiTraiNoiThuong").val();
        var pLS_TaiMuiHong_TaiTraiNoiTham = $("#txtLS_TaiMuiHong_TaiTraiNoiTham").val();
        var pLS_TaiMuiHong_TaiPhaiNoiThuong = $("#txtLS_TaiMuiHong_TaiPhaiNoiThuong").val();
        var pLS_TaiMuiHong_TaiPhaiNoiTham = $("#txtLS_TaiMuiHong_TaiPhaiNoiTham").val();
        var pLS_TaiMuiHong_CacBenhVeTaiMuiHong = $("#txtLS_TaiMuiHong_CacBenhVeTaiMuiHong").val();
        var pLS_TaiMuiHong_PhanLoai = $("#selectLS_TaiMuiHong_PhanLoai").val();
        var pLS_TaiMuiHong_BacSiKy = $("#selectLS_TaiMuiHong_BacSiKy").val();
        var pLS_RangHamMat_HamTren = $("#txtLS_RangHamMat_HamTren").val();
        var pLS_RangHamMat_HamDuoi = $("#txtLS_RangHamMat_HamDuoi").val();
        var pLS_RangHamMat_CacBenhVeRangHamMat = $("#txtLS_RangHamMat_CacBenhVeRangHamMat").val();
        var pLS_RangHamMat_PhanLoai = $("#selectLS_RangHamMat_PhanLoai").val();
        var pLS_RangHamMat_BacSiKy = $("#selectLS_RangHamMat_BacSiKy").val();
        var pLS_DaLieu = $("#txtLS_DaLieu").val();
        var pLS_DaLieu_PhanLoai = $("#selectLS_DaLieu_PhanLoai").val();
        var pLS_DaLieu_BacSiKy = $("#selectLS_DaLieu_BacSiKy").val();
        var pCLS_XetNghiemMau_HongCau = $("#txtCLS_XetNghiemMau_HongCau").val();
        var pCLS_XetNghiemMau_BachCau = $("#txtCLS_XetNghiemMau_BachCau").val();
        var pCLS_XetNghiemMau_TieuCau = $("#txtCLS_XetNghiemMau_TieuCau").val();
        var pCLS_XetNghiemMau_HCT = $("#txtCLS_XetNghiemMau_HCT").val();
        var pCLS_XetNghiemMau_Glucose = $("#txtCLS_XetNghiemMau_Glucose").val();
        var pCLS_XetNghiemMau = $("#txtCLS_XetNghiemMau").val();
        var pCLS_XetNghiemNuocTieu_Glucose = $("#txtCLS_XetNghiemNuocTieu_Glucose").val();
        var pCLS_XetNghiemNuocTieu_Protein = $("#txtCLS_XetNghiemNuocTieu_Protein").val();
        var pCLS_XetNghiemNuocTieu_pH = $("#txtCLS_XetNghiemNuocTieu_pH").val();
        var pCLS_XetNghiemNuocTieu = $("#txtCLS_XetNghiemNuocTieu").val();
        var pCLS_XetNghiemPhan = $("#txtCLS_XetNghiemPhan").val();
        var pCLS_CacXetNghiemKhac = $("#txtCLS_CacXetNghiemKhac").val();
        var pCLS_DanhGia = $("#txtCLS_DanhGia").val();
        var pCLS_BacSiKy = $("#selectCLS_BacSiKy").val();
        var pKL_PhanLoaiSucKhoe = $("#selectKL_PhanLoaiSucKhoe").val();
        var pKL_PhanLoaiSucKhoe_GhiChu = $("#txtKL_PhanLoaiSucKhoe_GhiChu").val();
        var pKL_CacBenhTatNeuCo = $("#txtKL_CacBenhTatNeuCo").val();
        var pKL_NoiKy = $("#txtKL_NoiKy").val();
        var pKL_NgayKy = $("#txtKL_NgayKy").val();
        var pKL_NguoiKetLuan = $("#selectKL_NguoiKetLuan").val();
        //var pMaNhanVienNhap  
        //var pNgayNhap  
        //var pXoa
        //var pNgayXoa  


        if (pNgay == "") {
            thAlertShowError("Chưa nhập ngày khám");
            return;
        }

        
        var pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
        if (!pattern.test(pNgay)) {
            //alert(_TuThangNam);
            thAlertShowError("Ngày khám chưa đúng định dạng");
            return;
        }
        
        var currentYear = new Date().getFullYear();
        var ngaySplit = pNgay.split("/");
        if (ngaySplit[2] < 1900 || ngaySplit[2] > currentYear) {
            thAlertShowError("Năm khám quá nhỏ hoặc quá lớn hơn năm hiện tại, vui lòng kiểm tra lại");
            return;
        }

        if (!isValidDate(ngaySplit[0], ngaySplit[1], ngaySplit[2])) {
            thAlertShowError("Ngày khám không có thật, vui lòng kiểm tra lại");
            return;
        }
        

        var param = {
            MaLuotKSK : pMaLuotKSK,
            MaSoKSK: pMaSoKSK,
            Ngay: pNgay,
            TienSuBenhTat : pTienSuBenhTat,
            TL_ChieuCao : pTL_ChieuCao,
            TL_CanNang : pTL_CanNang, 
            TL_ChiSoBMI : pTL_ChiSoBMI, 
            TL_Mach : pTL_Mach,  
            TL_HuyetAp : pTL_HuyetAp, 
            TL_PhanLoaiTheLuc : pTL_PhanLoaiTheLuc, 
            LS_NoiKhoa_TuanHoan : pLS_NoiKhoa_TuanHoan,  
            LS_NoiKhoa_TuanHoan_PhanLoai : pLS_NoiKhoa_TuanHoan_PhanLoai, 
            LS_NoiKhoa_HoHap : pLS_NoiKhoa_HoHap,  
            LS_NoiKhoa_HoHap_PhanLoai : pLS_NoiKhoa_HoHap_PhanLoai, 
            LS_NoiKhoa_TieuHoa : pLS_NoiKhoa_TieuHoa,  
            LS_NoiKhoa_TieuHoa_PhanLoai : pLS_NoiKhoa_TieuHoa_PhanLoai, 
            LS_NoiKhoa_ThanTietNieu : pLS_NoiKhoa_ThanTietNieu, 
            LS_NoiKhoa_ThanTietNieu_PhanLoai : pLS_NoiKhoa_ThanTietNieu_PhanLoai, 
            LS_NoiKhoa_NoiTiet : pLS_NoiKhoa_NoiTiet,  
            LS_NoiKhoa_NoiTiet_PhanLoai : pLS_NoiKhoa_NoiTiet_PhanLoai, 
            LS_NoiKhoa_CoXuongKhop : pLS_NoiKhoa_CoXuongKhop,  
            LS_NoiKhoa_CoXuongKhop_PhanLoai : pLS_NoiKhoa_CoXuongKhop_PhanLoai, 
            LS_NoiKhoa_ThanKinh : pLS_NoiKhoa_ThanKinh,  
            LS_NoiKhoa_ThanKinh_PhanLoai : pLS_NoiKhoa_ThanKinh_PhanLoai, 
            LS_NoiKhoa_TamThan : pLS_NoiKhoa_TamThan,  
            LS_NoiKhoa_ThamThan_PhanLoai : pLS_NoiKhoa_ThamThan_PhanLoai, 
            LS_NoiKhoa_BacSiKy : pLS_NoiKhoa_BacSiKy, 
            LS_NgoaiKhoa : pLS_NgoaiKhoa,  
            LS_NgoaiKhoa_PhanLoai : pLS_NgoaiKhoa_PhanLoai, 
            LS_NgoaiKhoa_BacSiKy : pLS_NgoaiKhoa_BacSiKy, 
            LS_SanPhuKhoa : pLS_SanPhuKhoa,  
            LS_SanPhuKhoa_PhanLoai : pLS_SanPhuKhoa_PhanLoai, 
            LS_SanPhuKhoa_BacSiKy : pLS_SanPhuKhoa_BacSiKy, 
            LS_Mat_KhongKinhMatPhai : pLS_Mat_KhongKinhMatPhai,
            LS_Mat_KhongKinhMatTrai : pLS_Mat_KhongKinhMatTrai, 
            LS_Mat_CoKinhMatPhai : pLS_Mat_CoKinhMatPhai, 
            LS_Mat_CoKinhMatTrai : pLS_Mat_CoKinhMatTrai, 
            LS_Mat_CacBenhVeMat : pLS_Mat_CacBenhVeMat, 
            LS_Mat_PhanLoai : pLS_Mat_PhanLoai, 
            LS_Mat_BacSiKy : pLS_Mat_BacSiKy, 
            LS_TaiMuiHong_TaiTraiNoiThuong : pLS_TaiMuiHong_TaiTraiNoiThuong, 
            LS_TaiMuiHong_TaiTraiNoiTham : pLS_TaiMuiHong_TaiTraiNoiTham, 
            LS_TaiMuiHong_TaiPhaiNoiThuong : pLS_TaiMuiHong_TaiPhaiNoiThuong, 
            LS_TaiMuiHong_TaiPhaiNoiTham : pLS_TaiMuiHong_TaiPhaiNoiTham, 
            LS_TaiMuiHong_CacBenhVeTaiMuiHong : pLS_TaiMuiHong_CacBenhVeTaiMuiHong,  
            LS_TaiMuiHong_PhanLoai : pLS_TaiMuiHong_PhanLoai, 
            LS_TaiMuiHong_BacSiKy : pLS_TaiMuiHong_BacSiKy, 
            LS_RangHamMat_HamTren : pLS_RangHamMat_HamTren, 
            LS_RangHamMat_HamDuoi : pLS_RangHamMat_HamDuoi, 
            LS_RangHamMat_CacBenhVeRangHamMat : pLS_RangHamMat_CacBenhVeRangHamMat,  
            LS_RangHamMat_PhanLoai : pLS_RangHamMat_PhanLoai, 
            LS_RangHamMat_BacSiKy : pLS_RangHamMat_BacSiKy, 
            LS_DaLieu : pLS_DaLieu,  
            LS_DaLieu_PhanLoai : pLS_DaLieu_PhanLoai, 
            LS_DaLieu_BacSiKy : pLS_DaLieu_BacSiKy, 
            CLS_XetNghiemMau_HongCau : pCLS_XetNghiemMau_HongCau, 
            CLS_XetNghiemMau_BachCau : pCLS_XetNghiemMau_BachCau, 
            CLS_XetNghiemMau_TieuCau : pCLS_XetNghiemMau_TieuCau, 
            CLS_XetNghiemMau_HCT : pCLS_XetNghiemMau_HCT, 
            CLS_XetNghiemMau_Glucose : pCLS_XetNghiemMau_Glucose, 
            CLS_XetNghiemMau : pCLS_XetNghiemMau,  
            CLS_XetNghiemNuocTieu_Glucose : pCLS_XetNghiemNuocTieu_Glucose, 
            CLS_XetNghiemNuocTieu_Protein : pCLS_XetNghiemNuocTieu_Protein, 
            CLS_XetNghiemNuocTieu_pH : pCLS_XetNghiemNuocTieu_pH, 
            CLS_XetNghiemNuocTieu : pCLS_XetNghiemNuocTieu,  
            CLS_XetNghiemPhan : pCLS_XetNghiemPhan,  
            CLS_CacXetNghiemKhac : pCLS_CacXetNghiemKhac, 
            CLS_DanhGia : pCLS_DanhGia, 
            CLS_BacSiKy : pCLS_BacSiKy, 
            KL_PhanLoaiSucKhoe : pKL_PhanLoaiSucKhoe, 
            KL_PhanLoaiSucKhoe_GhiChu : pKL_PhanLoaiSucKhoe_GhiChu,  
            KL_CacBenhTatNeuCo : pKL_CacBenhTatNeuCo, 
            KL_NoiKy : pKL_NoiKy, 
            KL_NgayKy : pKL_NgayKy,  
            KL_NguoiKetLuan : pKL_NguoiKetLuan
	        //MaNhanVienNhap  
	        //NgayNhap  
	        //Xoa bit 
	        //NgayXoa  
        }

        $("#loading").fadeIn(200);

        var url = urlController + "LuuLuotKham";
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã lưu dữ liệu");
                $("#loading").fadeOut(200);
            }
        });
    });
}



