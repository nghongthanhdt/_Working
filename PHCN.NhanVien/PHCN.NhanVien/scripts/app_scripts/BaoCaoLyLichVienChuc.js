// requires jquery library

var listSelectedLoaiHopDong = "";
var listSelectedKhoaPhong = "";
jQuery(document).ready(function () {
    jQuery(".main-table").clone(true).appendTo('#table-scroll').addClass('clone');
    bindbtnXuatExel_OnClick();
    getSelectedLoaiHopDong();
    getSelectedKhoaPhong();
    bindcheckboxLoaiHopDong_OnChange();
    bindcheckboxKhoaPhong_OnChange();
    loadDanhSachLyLichVienChuc();
    bindbtnTimKiem_OnClick();
    bindtxtHoTenNhanVien_OnEnterKeyPress();
});

function bindbtnXuatExel_OnClick() {
    $("#btnXuatExcel").unbind("click").click(function () {
        $("#tableLyLichVienChuc").table2excel({
            exclude: ".noExl",
            name: "Excel Document Name",
            filename: "DanhSachVienChuc.xls",
            fileext: ".xls",
            exclude_img: true,
            exclude_links: true,
            exclude_inputs: true
        });
    });
}


function bindcheckboxLoaiHopDong_OnChange() {
    $('.checkboxLoaiHopDong').on('ifChanged', function (event) {
        getSelectedLoaiHopDong();
    });
}
function bindcheckboxKhoaPhong_OnChange() {
    $('.checkboxKhoaPhong').on('ifChanged', function (event) {
        getSelectedKhoaPhong();
    });
}
function getSelectedLoaiHopDong() {
    var listCheckedLoaiHopDong = $('.checkboxLoaiHopDong:checkbox:checked').map(function () {
        return $(this).val();
    }).get();
    listSelectedLoaiHopDong = listCheckedLoaiHopDong.join(",");
    
}
function getSelectedKhoaPhong() {
    var listCheckedKhoaPhong = $('.checkboxKhoaPhong:checkbox:checked').map(function () {
        return $(this).val();
    }).get();
    listSelectedKhoaPhong = listCheckedKhoaPhong.join(",");
}

function loadDanhSachLyLichVienChuc() {
    var _hoten = $("#txtHoTenNhanVien").val();
    getSelectedKhoaPhong();
    var url = urlController + "_pDanhSachLyLichVienChuc";
    var param = {
        hopdong: listSelectedLoaiHopDong,
        khoaphong: listSelectedKhoaPhong,
        hoten: _hoten
    };
    thAjaxLoadHtml(url, param, function (result) {
        $("#divDanhSachLyLichVienChuc").html(result);
    });
}

function bindbtnTimKiem_OnClick() {
    $("#btnTimKiem").unbind("click").click(function () {

        if (listSelectedLoaiHopDong == "") {
            thAlertShowError("Chưa chọn loại hợp đồng");
            return;
        }
        if (listSelectedKhoaPhong == "") {
            thAlertShowError("Chưa chọn khoa phòng");
            return;
        }
        loadDanhSachLyLichVienChuc();
        
    });
}
function bindtxtHoTenNhanVien_OnEnterKeyPress() {
    $("#txtHoTenNhanVien").keypress(function (e) {
        if (e.which == 13) {
            $("#btnTimKiem").click();
        }
    });
}