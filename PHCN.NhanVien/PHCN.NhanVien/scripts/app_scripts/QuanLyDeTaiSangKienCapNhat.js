$(document).ready(function () {
    bindbtnLuu_OnClick();
    
});

function bindbtnLuu_OnClick() {
    $("#btnLuu").unbind("click").click(function () {
        var pMaDeTaiSangKien = $("#hiddenMaDeTaiSangKien").val();
        var pTenDeTaiSangKien = $("#txtTenDeTai").val();
        
        var pMaNhanVien = $("#selectChuDeTai").val();
        var pMaNhanVien1 = $("#selectCongSu1").val();
        var pMaNhanVien2 = $("#selectCongSu2").val();
        var pMaNhanVien3 = $("#selectCongSu3").val();
        var pMaNhanVien4 = $("#selectCongSu4").val();
        var pKinhPhi = $("#txtKinhPhi").val();
        var pTuThang = "01/" + $("#txtTuThang").val();
        var pDenThang = "01/" + $("#txtDenThang").val();
        var pCapDeTai = $("#selectCapDeTai").val();


        var _TuThangNam = pTuThang;
        var _DenThangNam = pDenThang;

        // validate
        // kiểm tra ngày
        if (_TuThangNam == "01/") {
            thAlertShowError("Chưa nhập \"Từ tháng năm\"");
            return;
        }
        if (_DenThangNam == "01/") {
            thAlertShowError("Chưa nhập \"Đến tháng năm\"");
            return;
        }

        var pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
        if (!pattern.test(_TuThangNam)) {
            //alert(_TuThangNam);
            thAlertShowError("Ngày \"Từ tháng năm\" chưa đúng định dạng");
            return;
        }
        if (!pattern.test(_DenThangNam)) {
            thAlertShowError("Ngày \"Đến tháng năm\" chưa đúng định dạng");
            return;
        }
        var ngayTuThangNamSplit = _TuThangNam.split("/");
        if (!isValidDate(ngayTuThangNamSplit[0], ngayTuThangNamSplit[1], ngayTuThangNamSplit[2])) {
            thAlertShowError("Ngày \"Từ tháng năm\" không có thật, vui lòng kiểm tra lại");
            return;
        }
        var ngayDenThangNamSplit = _DenThangNam.split("/");
        if (!isValidDate(ngayDenThangNamSplit[0], ngayDenThangNamSplit[1], ngayDenThangNamSplit[2])) {
            thAlertShowError("Ngày \"Đến tháng năm\" không có thật, vui lòng kiểm tra lại");
            return;
        }

        var param = {
            MaDeTaiSangKien : pMaDeTaiSangKien,
            TenDeTaiSangKien: pTenDeTaiSangKien,
            CapDeTai: pCapDeTai,
            MaNhanVien : pMaNhanVien,
            MaNhanVien1 : pMaNhanVien1,
            MaNhanVien2 : pMaNhanVien2,
            MaNhanVien3 : pMaNhanVien3,
            MaNhanVien4 : pMaNhanVien4,
            KinhPhi : pKinhPhi,
            TuThang : pTuThang,
            DenThang : pDenThang,
            CapDeTai : pCapDeTai
        }
        var url = urlController + "LuuDeTaiSangKien";
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã lưu dữ liệu thành công");
            }
        });
	    //Xoa
	    //NgayXoa
    });
}
