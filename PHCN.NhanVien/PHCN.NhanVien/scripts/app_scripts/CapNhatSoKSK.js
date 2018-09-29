$(document).ready(function () {
    bindbtnLuu_OnClick();
    bindlinkThemBenh_OnClick();


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
    $("#btnLuu").unbind("click").click(function () {
        var pMaSoKSK = $("#hiddenMaSoKSK").val();
        // MaNhanVien
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

    });
}
function bindlinkThemBenh_OnClick() {
    $("#linkThemBenh").unbind("click").click(function () {
        $("#modalChiTietBenh").modal("show");
    });
}