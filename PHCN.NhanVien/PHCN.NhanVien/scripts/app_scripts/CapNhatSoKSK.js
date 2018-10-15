$(document).ready(function () {
    bindbtnLuu_OnClick();
    bindlinkThemBenh_OnClick();
    loadDanhSachBenh();
    bindbtnSaoChepLanTruoc_OnClick();
    bindbtnTaoNgayKhamMau_OnClick();
});
function bindcheckboxNamNuClick() {
    $("#checkboxGioiTinhNam").unbind("click").click(function () {
        $("#checkboxGioiTinhNu").prop('checked', false)
    });
    $("#checkboxGioiTinhNu").unbind("click").click(function () {
        $("#checkboxGioiTinhNam").prop('checked', false)
    });

}
function bindbtnLuu_OnClick() {
    $("#linkLuuSoKSK").unbind("click").click(function () {
        $("#btnLuu").click();
    });
    $("#btnLuu").unbind("click").click(function () {
        var pMaSoKSK = $("#hiddenMaSoKSK").val();
        var pMaNhanVien = $("#hiddenMaNhanVien").val();
        var pMaSo = $("#txtMaSo").val();
        var pHoTen = $("#txtHoTen").val();
        var pGioiTinh = 0;
        if ($("#checkboxGioiTinhNam").is(":checked")) {
            pGioiTinh = 1;
        } else if ($("#checkboxGioiTinhNu").is(":checked")) {
            pGioiTinh = 2;
        }
        var pNamSinh = $("#txtNamSinh").val();
        var pSoCMND = $("#txtSoCMND").val();
        var pNgayCapCMND = $("#txtNgayCapCMND").val();
        var pNoiCapCMND = $("#txtNoiCapCMND").val();
        var pHoKhauThuongTru = $("#txtHoKhauThuongTru").val();
        var pChoOHienTai = $("#txtChoOHienTai").val();
        var pNgheNghiep = $("#txtNgheNghiep").val();
        var pNoiCongTacHocTap = $("#txtNoiCongTacHocTap").val();
        var pNgayBatDauHocTapLamviec = $("#txtNgayBatDauHocTapLamviec").val();
        var pNgheCongViecTruocDay = $("#txtNgheCongViecTruocDay").val();
        var pTienSuBenhTatCuaGiaDinh = $("#txtTienSuBenhTatCuaGiaDinh").val();
        var pTienSuBanThan = $("#txtTienSuBanThan").val();
        var pLapSoKSK_NoiKy = $("#txtLapSoKSK_NoiKy").val();
        var pLapSoKSK_NgayKy = $("#txtLapSoKSK_NgayKy").val();
        var pLapSoKSK_NguoiKy = $("#txtLapSoKSK_NguoiKy").val();
        // MaNhanVienNhap
        // NgayNhap
        // Xoa
        // NgayXoa


        var param = {
            MaSoKSK:pMaSoKSK,
            MaNhanVien:pMaNhanVien,
            MaSo:pMaSo,
            HoTen:pHoTen,
            GioiTinh:pGioiTinh,
            NamSinh:pNamSinh,
            SoCMND:pSoCMND,
            NgayCapCMND:pNgayCapCMND,
            NoiCapCMND:pNoiCapCMND,
            HoKhauThuongTru:pHoKhauThuongTru,
            ChoOHienTai:pChoOHienTai,
            NgheNghiep:pNgheNghiep,
            NoiCongTacHocTap:pNoiCongTacHocTap,
            NgayBatDauHocTapLamviec:pNgayBatDauHocTapLamviec,
            NgheCongViecTruocDay:pNgheCongViecTruocDay,
            TienSuBenhTatCuaGiaDinh:pTienSuBenhTatCuaGiaDinh,
            TienSuBanThan:pTienSuBanThan,
            LapSoKSK_NoiKy:pLapSoKSK_NoiKy,
            LapSoKSK_NgayKy:pLapSoKSK_NgayKy,
            LapSoKSK_NguoiKy:pLapSoKSK_NguoiKy
	//MaNhanVienNhap, 
	//NgayNhap
	//Xoa
	//NgayXoa
        }

        //chua validate


        //chua save
        $("#loading").fadeIn(200);
        var url = urlController + "LuuSoKSK";
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã cập nhật dữ liệu");
                setInterval(function () { location.reload();}, 500);
                $("#loading").fadeOut(200);
            }
        });

    });
}
function bindlinkThemBenh_OnClick() {
    $("#linkThemBenh").unbind("click").click(function () {
        //chua validate
        $("#hiddenMaBenh").val(0);

        $("#selectLoaiBenh").val("false");
        $("#txtPhatHienNam").val("");
        $("#txtTenBenh").val("");
        $("#modalChiTietBenh").modal("show");
        bindbtnLuuBenh_OnClick();
    });
}
function loadDanhSachBenh() {
    //$("#divSoKSKDanhSachBenh").val();
    var maSoKSK = $("#hiddenMaSoKSK").val();
    var param = {
        id: maSoKSK
    };
    var url = urlController + "_pSoKSK_Benh";

    thAjaxLoadHtml(url, param, function (result) {
        $("#divSoKSKDanhSachBenh").html(result);
        bindrowSuaBenhKSK_OnClick();
        bindrowXoaBenhKSK_OnClick();
    });
}
function bindrowSuaBenhKSK_OnClick() {
    $(".rowSuaBenhKSK").unbind("click").click(function () {
        var maBenh = $(this).data("mabenh");
        $("#hiddenMaBenh").val(maBenh);
        
        var url = urlController + "GetBenhSoKSK";
        var param = {
            id: maBenh
        }
        thAjaxReturnJson(url, param, function (result) {
            if (result.BenhNgheNghiep == true) {
                $("#selectLoaiBenh").val("true");
            } else {
                $("#selectLoaiBenh").val("false");
            }
            $("#txtPhatHienNam").val(result.PhatHienNam);
            $("#txtTenBenh").val(result.TenBenh);
            $("#modalChiTietBenh").modal("show");
            bindbtnLuuBenh_OnClick();
        });
    });
}
function bindrowXoaBenhKSK_OnClick() {
    $(".rowXoaBenhKSK").unbind("click").click(function () {
        if (!confirm("Bạn thật sự muốn xóa ?")) {
            return;
        }
        var maBenh = $(this).data("mabenh");
        //$("#hiddenMaBenh").val(maBenh);
        var url = urlController + "XoaBenh";
        var param = {
            id: maBenh
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                loadDanhSachBenh();                
            }
        });
    });
}

function bindbtnLuuBenh_OnClick() {
    $("#btnLuuBenh").unbind("click").click(function () {
        var maBenh = $("#hiddenMaBenh").val();
        var maSoKSK = $("#hiddenMaSoKSK").val();
        var tenBenh = $("#txtTenBenh").val();
        var benhNgheNghiep = $("#selectLoaiBenh").val();
        var phatHienNam = $("#txtPhatHienNam").val();

        // validate
        if (phatHienNam == "") {
            thAlertShowError("Chưa nhập năm phát hiện");
            return;
        }
        if (phatHienNam.length > 4 || phatHienNam.length < 4) {
            thAlertShowError("Năm phát hiện không hợp lệ");
            return;
        }
        if (tenBenh == "") {
            thAlertShowError("Chưa nhập tên bệnh");
            return;
        }

        // validate ok
        var url = urlController + "LuuBenh";
        var param = {
            MaBenh: maBenh,
            MaSoKSK: maSoKSK,
            TenBenh: tenBenh,
            BenhNgheNghiep: benhNgheNghiep,
            PhatHienNam: phatHienNam
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                loadDanhSachBenh();
                $("#modalChiTietBenh").modal("hide");
            } else {
                alert("result");
            }
        });

    });
}
function bindbtnSaoChepLanTruoc_OnClick() {
    $("#btnSaoChepLanTruoc").unbind("click").click(function () {
        
        var maSoKSK = $("#hiddenMaSoKSK").val();
        var url = urlController + "SaoChepLanTruoc";

        param = {
            id: maSoKSK
        };
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                location.reload();
            } else {
                alert(result);
            }
        });
    });
}
function bindbtnTaoNgayKhamMau_OnClick() {
    $("#btnTaoNgayKhamMau").unbind("click").click(function () {
        var maSoKSK = $("#hiddenMaSoKSK").val();
        var url = urlController + "TaoNgayKhamMau";

        param = {
            id: maSoKSK
        };
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                location.reload();
            } else {
                alert(result);
            }
        });
    });
}