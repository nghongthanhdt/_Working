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
    bindselectLoaiBaoCao_OnChange();
    loadDanhSach();
    bindbtnTimKiem_OnClick();
    bindtxtHoTenNhanVien_OnEnterKeyPress();
    bindlinkTuyChonNangCao_OnClick();
    bindmodalTuyChonNangCao_btnDongY_OnClick();
    bindtxtThoiDiem_EnterKeyPress();

});
function loadDanhSach() {
    var loaiBaoCao = $("#selectLoaiBaoCao").val();
    var thoidiem = $("#txtThoiDiem").val();
    if (thoidiem == "") {
        thAlertShowError("Chưa nhập thời điểm");
        return;
    }
    var thoidiemSplit = thoidiem.split("/");
    if (!isValidDate(thoidiemSplit[0], thoidiemSplit[1], thoidiemSplit[2])) {
        thAlertShowError("Thời điểm không có thật, vui lòng kiểm tra lại");
        return;
    }
    
    if (loaiBaoCao == "lylichvienchuc") {
        loadDanhSachLyLichVienChuc();
        $("#h3TenDanhSach").html("DANH SÁCH LÝ LỊCH VIÊN CHỨC ĐẾN NGÀY " + $("#txtThoiDiem").val());
    } else {
        loadDanhSachSucKhoeDinhKy();
        $("#h3TenDanhSach").html("DANH SÁCH LÝ SỨC KHỎE ĐỊNH KỲ ĐẾN NGÀY " + $("#txtThoiDiem").val());
    }
}

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
function bindlinkTuyChonNangCao_OnClick() {
    $("#linkTuyChonNangCao").unbind("click").click(function () {
        $("#modalTuyChonNangCao").modal("show");
    });
}

function loadDanhSachLyLichVienChuc() {
    var _hoten = $("#txtHoTenNhanVien").val();
    var _thoidiem = $("#txtThoiDiem").val();
    getSelectedKhoaPhong();
    var url = urlController + "_pDanhSachLyLichVienChuc";
    var param = {
        hopdong: listSelectedLoaiHopDong,
        khoaphong: listSelectedKhoaPhong,
        hoten: _hoten,
        thoidiem: _thoidiem
    };
    thAjaxLoadHtml(url, param, function (result) {
        $("#divDanhSachLyLichVienChuc").html(result);
    });
}
function loadDanhSachSucKhoeDinhKy() {
    var _hoten = $("#txtHoTenNhanVien").val();
    var _thoidiem = $("#txtThoiDiem").val();
    getSelectedKhoaPhong();
    var url = urlController + "_pDanhSachSucKhoeDinhKy";
    var param = {
        hopdong: listSelectedLoaiHopDong,
        khoaphong: listSelectedKhoaPhong,
        hoten: _hoten,
        thoidiem: _thoidiem
    };
    thAjaxLoadHtml(url, param, function (result) {
        $("#divDanhSachLyLichVienChuc").html(result);
    });
}

function bindbtnTimKiem_OnClick() {
    $("#btnTimKiem").unbind("click").click(function () {
        var tdiem = $("#txtThoiDiem").val();
        if (tdiem == "") {
            thAlertShowError("Chưa nhập thời điểm");
        }

        if (listSelectedLoaiHopDong == "") {
            thAlertShowError("Chưa chọn loại hợp đồng");
            return;
        }
        if (listSelectedKhoaPhong == "") {
            thAlertShowError("Chưa chọn khoa phòng");
            return;
        }
        
        
        loadDanhSach();
        //if (history.pushState) {
            
        //    var newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?thoidiem=' + tdiem;
        //    window.history.pushState({ path: newurl }, '', newurl);
        //}
    });
}
function bindtxtHoTenNhanVien_OnEnterKeyPress() {
    $("#txtHoTenNhanVien").keypress(function (e) {
        if (e.which == 13) {
            $("#btnTimKiem").click();
        }
    });
}

function bindselectLoaiBaoCao_OnChange() {
    $("#selectLoaiBaoCao").unbind("change").change(function () {
        var loai = $(this).val();
        if (loai == "lylichvienchuc") {
            $("#divLoaiHopDong").show();
            
        } else {
            $("#divLoaiHopDong").hide();
            

        }
    });
    
}
function bindmodalTuyChonNangCao_btnDongY_OnClick() {
    $("#modalTuyChonNangCao_btnDongY").unbind("click").click(function () {
        $("#modalTuyChonNangCao").modal("hide");
        $("#btnTimKiem").click();
    });
}
function bindtxtThoiDiem_EnterKeyPress() {
    $("#txtThoiDiem").keypress(function (e) {
        if (e.which == 13) {
            $("#btnTimKiem").click();
        }
    });
}