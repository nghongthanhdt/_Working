$(document).ready(function () {
    bindtabDanhMuc();
    bindbtnTimKiem();
    bindtxtTimKiem();
});

function bindtxtTimKiem() {
    $('#txtTimKiem').keypress(function (e) {
        if (e.keyCode == 13) {

            $("#btnTimKiem").click();
        }        
    });
}
function bindbtnTimKiem() {
    $("#btnTimKiem").unbind("click").click(function () {
        var tenDanhMuc = "_p" + $("#hiddenSelectedDanhMuc").val();
        var timKiem = $("#txtTimKiem").val();

        if (tenDanhMuc == "_p") {
            thAlertShowError("Chưa chọn danh mục");
        }
        loadDanhSachDanhMuc(tenDanhMuc, timKiem);
    });
}
function bindtabDanhMuc() {
    $(".tabDanhMuc").unbind("click").click(function () {
        $(".tabDanhMuc").removeClass("active");
        $(this).addClass("active");
        $('#txtTimKiem').attr("placeholder", "Tìm kiếm...");
        var tenDanhMuc = "_p" + $(this).data("tendanhmuc");
        $("#hiddenSelectedDanhMuc").val($(this).data("tendanhmuc").toLowerCase());
        loadDanhSachDanhMuc(tenDanhMuc, "");
        
    });
}
function loadDanhSachDanhMuc(tenDanhMuc, timKiem) {
    var _url = _ajaxQuanLyDanhMuc + tenDanhMuc;
    var _param = {
        timkiem: timKiem
    }
    thAjaxLoadHtml(_url, _param, function (result) {
        $("#divDanhMuc").html(result);

        bindbtnLuuDanhMuc();

    });
}
function bindbtnLuuDanhMuc() {
    $(".btnLuu").unbind("click").click(function () {
        var maDanhMuc = $(this).data("madanhmuc");
        var tenDanhMuc = $("#txtTenDanhMuc_" + maDanhMuc).val();
        var stt = $("#txtSTT_" + maDanhMuc).val();

        if (tenDanhMuc == "") {
            thAlertShowError("Tên danh mục không thể để trống");
            return;
        }
        if (stt == "") {
            thAlertShowError("Số thứ tự không thể để trống");
            return;
        }


        var loaiDanhMuc = "TinhThanh";
        var _url = _ajaxQuanLyDanhMuc + "Luu" + loaiDanhMuc;
        var _param = {
            MaDanhMuc: maDanhMuc,
            TenDanhMuc: tenDanhMuc,
            STT: stt
        }
        
        

        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã cập nhật danh mục");
                loadDanhSachDanhMuc("_p" + loaiDanhMuc, "");
            }
        });
    });
}