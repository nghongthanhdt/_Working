$(document).ready(function () {

    loadDanhSachThu();
    loadThongTinSoThu(_trangThai);
    bindbtnDanhDauDaXem();
    bindbtnDanhDauChuaXem();
    bindbtnDanhDauDaXemTatCa();

    setInterval(function () {
        loadDanhSachThu();
        loadThongTinSoThu(_trangThai);
    }, 60000);
    
});
function loadDanhSachThu() {
    var url = _urlDanhSachThu;

    var param = {
        TrangThai: _trangThai,
        TieuDe: _getTieuDe,
        NguoiGui: _getNguoiGui,
        NgayGui: _getNgayGui
    }
    $.ajax({
        type: "POST",
        url: url,
        data: param,
        success: function (data) {
            $("#divDanhSachThu").html(data);
        },
        dataType: "html"
    });
}
$("#btnChonTatCa").click(function () {
    if ($(".checkboxThu").prop("checked") == false) {
        $(".checkboxThu").prop("checked", true);
    } else {
        $(".checkboxThu").prop("checked", false);
    }

});

$("#btnTraVeThuDen").click(function () {
    var listCheckedThu = $('.checkboxThu:checkbox:checked').map(function () {
        return $(this).data("id-gui-nhan");
    }).get();
    listThuDaChon = listCheckedThu.join(",");
    if (listThuDaChon == "") {
        alert("Chưa chọn thư nào");
        return;
    }
    if (!confirm("Bạn muốn trả thư này về hộp thư đến ?")) {
        return;
    }
    // send ajax - đánh dấu trả về thư đến
    var url = _urlTraVeThuDen;
    var param = {
        listGuiNhanTraVeThuDen: listThuDaChon
    }
    $.ajax({
        type: "POST",
        url: url,
        data: param,
        success: function (result) {
            if (result == "true") {
                //alert ("Đã trả về hộp thư đến thành công");
                loadDanhSachThu();
            } else {
                alert(result);
            }
        },
        dataType: "html"
    });
});
$("#btnXoaThu").click(function () {
    if (_trangThai == "DaGui") {
        alert("Không thể xóa thư đã gửi");
        return;
    }
    var listCheckedThu = $('.checkboxThu:checkbox:checked').map(function () {
        return $(this).data("id-gui-nhan");
    }).get();
    listThuDaChon = listCheckedThu.join(",");
    if (listThuDaChon == "") {
        alert("Chưa chọn thư nào");
        return;
    }
    if (_trangThai != "DaXoa") {
        if (confirm("Bạn thật sự muốn xóa ?") == false) {
            return;
        }
        // send ajax - đánh dấu xóa
        var url = _urlDanhDauXoa;
        var param = {
            listGuiNhanXoa: listThuDaChon
        }
        $.ajax({
            type: "POST",
            url: url,
            data: param,
            success: function (result) {
                if (result == "true") {
                    //alert ("Đã xóa thư thành công");
                    loadDanhSachThu();
                } else {
                    alert(result);
                }
            },
            dataType: "html"
        });
    } else {
        if (confirm("Bạn thật sự muốn xóa vĩnh viễn các thư này ?") == false) {
            return;
        }
        // send ajax xóa vĩnh viễn        
        var url = _urlXoaThuVinhVien;
        var param = {
            listGuiNhanXoa: listThuDaChon
        }
        $.ajax({
            type: "POST",
            url: url,
            data: param,
            success: function (result) {
                if (result == "true") {                    
                    loadDanhSachThu();
                } else {
                    alert(result);
                }
            },
            dataType: "html"
        });
    }

});

function loadThongTinSoThu(trangthai) {
    var param = {
        TrangThai: trangthai
    }
    $.ajax({
        type: "POST",
        url: _urlLayTongSoThu,
        data: param,
        success: function (result) {
            if (result.TrangThai == "ThuDen") {
                var str = "";
                if (result.SoThuChuaDoc > 0) {
                    str = "Hộp thư đến có <span style='font-weight:bold;'>" + result.TongSoThu + "</span> thư, có <span style='color:red;font-weight:bold;'>" + result.SoThuChuaDoc + "</span> thư chưa đọc.";
                } else {
                    str = "Hộp thư đến có <span style='font-weight:bold;'>" + result.TongSoThu + "</span> thư.";
                }
                $("#thongtinThu").html(str);
            }
            if (result.TrangThai == "DaGui") {
                var str = "";                
                str = "Thư đã gửi có <span style='font-weight:bold;'>" + result.TongSoThu + "</span> thư.";                
                $("#thongtinThu").html(str);
            }
            if (result.TrangThai == "DaXoa") {
                var str = "";
                str = "Thư đã xóa có <span style='font-weight:bold;'>" + result.TongSoThu + "</span> thư.";
                $("#thongtinThu").html(str);
            }
        },
        dataType: "json"
    });
}
function bindbtnDanhDauDaXem() {
    $("#btnDanhDauDaXem").unbind("click").click(function () {
        var listCheckedThu = $('.checkboxThu:checkbox:checked').map(function () {
            return $(this).data("id-gui-nhan");
        }).get();
        listThuDaChon = listCheckedThu.join(",");
        if (listThuDaChon == "") {
            alert("Chưa chọn thư nào");
            return;
        }
        if (!confirm("Bạn muốn đánh dấu đã xem các thư này ?")) {
            return;
        }
        // send ajax - đánh dấu trả về thư đến
        var url = _urlDanhDauDaXemList;
        var param = {
            listGuiNhanDaXem: listThuDaChon
        }
        $.ajax({
            type: "POST",
            url: url,
            data: param,
            success: function (result) {
                if (result == "true") {
                    //alert ("Đã trả về hộp thư đến thành công");
                    loadDanhSachThu();
                    loadThongTinSoThu(_trangThai);
                } else {
                    alert(result);
                }
            },
            dataType: "html"
        });
    });
}
function bindbtnDanhDauChuaXem() {
    $("#btnDanhDauChuaXem").unbind("click").click(function () {
        var listCheckedThu = $('.checkboxThu:checkbox:checked').map(function () {
            return $(this).data("id-gui-nhan");
        }).get();
        listThuDaChon = listCheckedThu.join(",");
        if (listThuDaChon == "") {
            alert("Chưa chọn thư nào");
            return;
        }
        if (!confirm("Bạn muốn đánh dấu chưa xem các thư này ?")) {
            return;
        }
        // send ajax - đánh dấu trả về thư đến
        var url = _urlDanhDauChuaXemList;
        var param = {
            listGuiNhanChuaXem: listThuDaChon
        }
        $.ajax({
            type: "POST",
            url: url,
            data: param,
            success: function (result) {
                if (result == "true") {
                    //alert ("Đã trả về hộp thư đến thành công");
                    loadDanhSachThu();
                    loadThongTinSoThu(_trangThai);
                } else {
                    alert(result);
                }
            },
            dataType: "html"
        });
    });
}
function bindbtnDanhDauDaXemTatCa() {
    $("#btnDanhDauDaXemTatCa").unbind("click").click(function () {
        
        if (!confirm("Bạn muốn đánh dấu đã xem tất cả thư ?")) {
            return;
        }
        // send ajax - đánh dấu trả về thư đến
        var url = _urlDanhDauDaXemTatCa;
        var param = {};
        $.ajax({
            type: "POST",
            url: url,
            data: param,
            success: function (result) {
                if (result == "true") {
                    //alert ("Đã trả về hộp thư đến thành công");
                    loadDanhSachThu();
                    loadThongTinSoThu(_trangThai);
                } else {
                    alert(result);
                }
            },
            dataType: "html"
        });
    });
}