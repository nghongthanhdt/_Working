var _MaNhanVienDangNhap = 1;


$(document).ready(function () {
    $("#btnThemNhanhQuaTrinhLuong").click(function () {
        showModalDienBienQuaTrinhLuong(0);
    });


    $('.date').mask('00/00/0000', { placeholder: "__/__/____" });
    $('.number').mask('00000000000');
    $('.decimal').mask('0.00', { placeholder: "_.__" });
    $('.giaoducphothong').mask('00/00', { placeholder: "__/__" });
    $('.thangnam').mask('00/0000', { placeholder: "__/____" });



    var listTrinhDoChuyenMonCaoNhat = [
        "Bác sĩ",
        "Bác sĩ Chuyên khoa I",
        "Bác sĩ Chuyên khoa II",
        "Cao đẳng",
        "Cử nhân",
        "Đại học",
        "Kỹ sư",
        "Kỹ thuật viên trung cấp",
        "Trung cấp",
        "Y sĩ"
    ];
    $("#txtTrinhDoChuyenMonCaoNhat").autocomplete({
        source: listTrinhDoChuyenMonCaoNhat
    });


    var listTinhTrangSucKhoe = [
        "Tốt"    
    ];
    $("#txtTinhTrangSucKhoe").autocomplete({
        source: listTinhTrangSucKhoe
    });






    $("#btnThemTomTatQuaTrinhCongTac").click(function () {
        $("#modalTomTatQuaTrinhCongTac").modal("show");
    });
    

    //var json_result_listTinhThanh;
    //$("#txtNoiSinh_Tinh").change(function () {
        
    //    var keyword = "Đồng";
    //    $.ajax({
    //        url: _ajaxUrl + "GetListTinh",
    //        dataType: "jsonp",
    //        data: {
    //            id: keyword
    //        },
    //        success: function (data) {
    //            json_result_listTinhThanh = data;
    //        }
    //    });
    //});

    bindAutoComplete("#txtNoiSinh_Xa", "GetListXaPhuong");
    bindAutoComplete("#txtNoiSinh_Huyen", "GetListHuyenThi");
    bindAutoComplete("#txtNoiSinh_Tinh", "GetListTinhThanh");
    bindAutoComplete("#txtQueQuan_Xa", "GetListXaPhuong");
    bindAutoComplete("#txtQueQuan_Huyen", "GetListHuyenThi");
    bindAutoComplete("#txtQueQuan_Tinh", "GetListTinhThanh");
    bindAutoComplete("#txtNoiDangKyHKTT_Xa", "GetListXaPhuong");
    bindAutoComplete("#txtNoiDangKyHKTT_Huyen", "GetListHuyenThi");
    bindAutoComplete("#txtNoiDangKyHKTT_Tinh", "GetListTinhThanh");
    bindAutoComplete("#txtNoiOHienNay_Xa", "GetListXaPhuong");
    bindAutoComplete("#txtNoiOHienNay_Huyen", "GetListHuyenThi");
    bindAutoComplete("#txtNoiOHienNay_Tinh", "GetListTinhThanh");
    bindAutoComplete("#txtNgheNghiepKhiDuocTuyenDung", "GetListTrinhDoChuyenMon");
    bindAutoComplete("#txtChucVuChucDanhHienTai", "GetListTrinhDoChuyenMon");
    bindAutoComplete("#txtDanToc", "GetListDanToc");
    bindAutoComplete("#txtTonGiao", "GetListTonGiao");

    //$("#txtNoiSinh_Tinh").autocomplete({
    //    source:listTrinhDoChuyenMonCaoNhat
    //});



    //

    loadDienBienQuaTrinhLuong();
    $('#modalChucDanhNgheNghiepVienChuc').on('hidden.bs.modal', function () {
        loadDienBienQuaTrinhLuong();
    })





    getLastDienBienQuaTringLuong();


    // kiểm tra khi click checkbox Nam Nữ

    $("#checkboxGioiTinhNam").unbind("click").click(function () {
        $("#checkboxGioiTinhNu").prop('checked', false)
    });
    $("#checkboxGioiTinhNu").unbind("click").click(function () {
        $("#checkboxGioiTinhNam").prop('checked', false)
    });




    loadDienBienQuaTrinhDaoTaoBoiDuong();
    bindbtnThemDaoTaoBoiDuongChuyenMon();

    // end document ready
    
});

function loadDienBienQuaTrinhDaoTaoBoiDuong() {
    var ajaxActionName = "_pDienBienQuaTrinhDaoTaoBoiDuong";
    var _paramMaLyLichVienChuc = $("#divDienBienQuaTrinhDaoTaoBoiDuong").data("malylichvienchuc");
    var param = {
        id: _paramMaLyLichVienChuc
    }
    $.ajax({
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDienBienQuaTrinhDaoTaoBoiDuong").html(result);
            bindrowSuaDaoTaoBoiDuongChuyenMon();
            bindrowXoaQuaTrinhDaoTaoBoiDuong();
        }
    });
}

function bindrowSuaDaoTaoBoiDuongChuyenMon() {
    $(".rowQuaTrinhDaoTaoBoiDuong").unbind("click").click(function () {
        var idDienBien = $(this).data("madienbiendaotaoboiduong");
        showModalDaoTaoBoiDuongNghiepVuChuyenMon(idDienBien);
    });
}
function bindrowXoaQuaTrinhDaoTaoBoiDuong() {
    $(".rowXoaQuaTrinhDaoTaoBoiDuong").unbind("click").click(function () {
        if (confirm("Bạn thật sự muốn xóa ?")) {
            var idDienBien = $(this).data("madienbiendaotaoboiduong");
            var param = {
                id: idDienBien
            }
            $.ajax({
                url: _ajaxUrl + "XoaDienBienDaoTaoBoiDuong",
                data: param,
                success: function (data) {
                    if (data == "ok") {                        
                        loadDienBienQuaTrinhDaoTaoBoiDuong();
                    }
                }
            });
        }
    });
}
function bindbtnThemDaoTaoBoiDuongChuyenMon() {
    $("#btnThemDaoTaoBoiDuongChuyenMon").unbind("click").click(function () {
        showModalDaoTaoBoiDuongNghiepVuChuyenMon(0);
    });
}
function showModalDaoTaoBoiDuongNghiepVuChuyenMon(idDienBien) {

    // idDienBien = 0: new
    // idDienBien > 0: edit

    // gửi ajax lấy về diễn biến theo mã được chọn
    var _selectedDienBien;
    if (idDienBien > 0) {
        var ajaxActionName = "GetDienBienDaoTaoBoiDuong";
        $.ajax({
            url: _ajaxUrl + ajaxActionName,
            dataType: "json",
            data: {
                id: idDienBien
            },
            success: function (result) {
                _selectedDienBien = result;
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTenTruong").val(_selectedDienBien.TenTruong);
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtChuyenNganhDaoTao").val(_selectedDienBien.ChuyenNganhDaoTaoBoiDuong);
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTuThangNam").val(_selectedDienBien.TuThangNam);
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtDenThangNam").val(_selectedDienBien.DenThangNam);
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_selectHinhThucDaoTao").val(_selectedDienBien.MaHinhThucDaoTao);
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtVanBangChungChiTrinhDo").val(_selectedDienBien.VanBangChungChiTrinhDo);

            }
        });

    } else {
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTenTruong").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtChuyenNganhDaoTao").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTuThangNam").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtDenThangNam").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_selectHinhThucDaoTao").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtVanBangChungChiTrinhDo").val("");
    }
    $("#modalDaoTaoBoiDuongNghiepVuChuyenMon").modal("show");
    bindbtn_modalDaoTaoBoiDuongNghiepVuChuyenMon_btnLuu(idDienBien);


}

function bindbtn_modalDaoTaoBoiDuongNghiepVuChuyenMon_btnLuu(idDienBien) {
    $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_btnLuu").unbind("click").click(function () {
        //var _maDienBienQuaTrinhLuong = $('#modalChucDanhNgheNghiepVienChuc').data("malylichvienchuc");
        var _maLyLichVienChuc = $(this).data("malylichvienchuc");
        var _TenTruong = $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTenTruong").val();
        var _ChuyenNganhDaoTaoBoiDuong = $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtChuyenNganhDaoTao").val();
        var _TuThangNam = "01/" + $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTuThangNam").val();
        var _DenThangNam = "01/" + $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtDenThangNam").val();
        var _maHinhThucDaoTao = $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_selectHinhThucDaoTao").val();
        var _VanBangChungChiTrinhDo = $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtVanBangChungChiTrinhDo").val();

        //alert(_ngayHuong);
        //return;
        if (_TenTruong == "") {
            alert("Chưa nhập tên trường");
            return;
        }

        // kiểm tra ngày
        if (_TuThangNam == "01/") {
            alert("Chưa nhập \"Từ tháng năm\"");
            return;
        }
        if (_DenThangNam == "01/") {
            alert("Chưa nhập \"Đến tháng năm\"");
            return;
        }

        var pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
        if (!pattern.test(_TuThangNam)) {
            //alert(_TuThangNam);
            alert("Ngày \"Từ tháng năm\" chưa đúng định dạng");
            return;
        }
        if (!pattern.test(_DenThangNam)) {
            alert("Ngày \"Đến tháng năm\" chưa đúng định dạng");
            return;
        }
        var ngayTuThangNamSplit = _TuThangNam.split("/");
        if (!isValidDate(ngayTuThangNamSplit[0], ngayTuThangNamSplit[1], ngayTuThangNamSplit[2])) {
            alert("Ngày \"Từ tháng năm\" không có thật, vui lòng kiểm tra lại");
            return;
        }
        var ngayDenThangNamSplit = _DenThangNam.split("/");
        if (!isValidDate(ngayDenThangNamSplit[0], ngayDenThangNamSplit[1], ngayDenThangNamSplit[2])) {
            alert("Ngày \"Đến tháng năm\" không có thật, vui lòng kiểm tra lại");
            return;
        }


        if (_maHinhThucDaoTao == null || _maHinhThucDaoTao == "") {
            alert("Chưa chọn hình thức đào tạo");
            return;
        }

        

       


        var dienbienDaoTaoBoiDuong = {
            MaDienBienDaoTaoBoiDuong: idDienBien,
            MaLyLichVienChuc: _maLyLichVienChuc,
            TenTruong: _TenTruong,
            ChuyenNganhDaoTaoBoiDuong: _ChuyenNganhDaoTaoBoiDuong,
            TuThangNam: _TuThangNam,
            DenThangNam: _DenThangNam,
            MaHinhThucDaoTao: _maHinhThucDaoTao,
            VanBangChungChiTrinhDo: _VanBangChungChiTrinhDo            
            
        }
        $.ajax({
            url: _ajaxUrl + "LuuDienBienDaoTaoBoiDuong",
            data: dienbienDaoTaoBoiDuong,
            success: function (data) {
                if (data == "ok") {
                    //alert(data);
                    $("#modalDaoTaoBoiDuongNghiepVuChuyenMon").modal("hide");
                    loadDienBienQuaTrinhDaoTaoBoiDuong();

                }
            }
        });
        
    });
}
function bindbtn_modalChucDanhNgheNghiepVienChuc_btnLuu(idDienBien) {
    $("#modalQuaTrinhLuong_btnLuuDienBienQuaTrinhLuong").unbind("click").click(function () {
        //var _maDienBienQuaTrinhLuong = $('#modalChucDanhNgheNghiepVienChuc').data("malylichvienchuc");
        var _maLyLichVienChuc = $(this).data("malylichvienchuc");
        var _maChucDanhNgheNghiep = $("#modalQuaTrinhLuong_selectChucDanhNgheNghiep").val();
        var _bacLuong = $("#modalQuaTrinhLuong_txtBacLuong").val();
        var _heSo = $("#modalQuaTrinhLuong_txtHeSo").val();
        var _vuotKhung = $("#modalQuaTrinhLuong_txtVuotKhung").val();
        var _ngayHuong = revertDMY($("#modalQuaTrinhLuong_txtNgayHuong").val());
        var _phuCapChucVu = $("#modalQuaTrinhLuong_txtPhuCapChucVu").val();
        var _phuCapKhac = $("#modalQuaTrinhLuong_txtPhuCapKhac").val();
        //alert(_ngayHuong);
        //return;

        if (_maChucDanhNgheNghiep == null || _maChucDanhNgheNghiep == "") {
            alert("Chưa chọn chức danh nghề nghiệp");
            return;
        }

        // kiểm tra ngày hưởng
        if (_ngayHuong == "") {
            alert("Chưa nhập ngày hưởng");
            return;
        }

        //var pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
        //if (pattern.test(_ngayHuong)) {
        //    alert("Ngày chưa đúng định dạng");
        //    return;
        //}

        var ngayHuongSplit = _ngayHuong.split("/");
        //alert(ngayHuongSplit[2] + "," + ngayHuongSplit[1] + "," + ngayHuongSplit[0]);
        if (!isValidDate(ngayHuongSplit[2], ngayHuongSplit[1], ngayHuongSplit[0])) {
            alert("Ngày hưởng không có thật, vui lòng kiểm tra lại");
            return;
        }
        

        var quaTrinhLuong = {
            MaDienBienQuaTrinhLuong: idDienBien,
            MaLyLichVienChuc: _maLyLichVienChuc,
            MaChucDanhNgheNghiep: _maChucDanhNgheNghiep,
            BacLuong: _bacLuong,
            HeSo: _heSo,
            NgayHuong: _ngayHuong,
            PhuCapChucVu: _phuCapChucVu,
            PhuCapKhac: _phuCapKhac,
            VuotKhung: _vuotKhung,
            Nhap_MaNhanVien: _MaNhanVienDangNhap,
            Nhap_Ngay: null, // vào server lấy ngày server
            CapNhat_MaNhanVien: null,
            CapNhat_Ngay: null,
            Xoa: false,
            Xoa_MaNhanVien: null,
            Xoa_Ngay: null
        }
        $.ajax({
            url: _ajaxUrl + "LuuQuaTrinhLuong",
            data: quaTrinhLuong,
            success: function (data) {
                if (data == "ok") {
                    //alert(data);
                    $("#modalChucDanhNgheNghiepVienChuc").modal("hide");


                }
            }
        });
        //loadDienBienQuaTrinhLuong();
    });
}
function bindbtn_modalChucDanhNgheNghiepVienChuc_btnXoa(idDienBien) {
    
    $("#modalChucDanhNgheNghiepVienChuc_btnXoa").unbind("click").click(function () {
        var maLyLichVienChuc = $(this).data("malylichvienchuc");
        if (confirm("Bạn thật sự muốn xóa ?")) {
            
            var param = {
                id: idDienBien
            }
            $.ajax({
                url: _ajaxUrl + "XoaDienBienQuaTrinhLuong",
                data: param,
                success: function (data) {
                    if (data == "ok") {
                        $("#modalChucDanhNgheNghiepVienChuc").modal("hide");
                        loadDienBienQuaTrinhLuong();
                    }
                }
            });
        }
    });


}
function loadDienBienQuaTrinhLuong() {
    var ajaxActionName = "_pDienBienQuaTrinhLuong";
    var _paramMaLyLichVienChuc = $("#divDienBienQuaTrinhLuong").data("malylichvienchuc");
    var param = {
        id:_paramMaLyLichVienChuc
    }
    $.ajax({
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDienBienQuaTrinhLuong").html(result);
            //bindbtnThemDienBienQuaTrinhLuong();
            bindbtncolDienBienQuaTrinhLuong();
        }
    });
    bindbtnThemDienBienQuaTrinhLuong();
    //bindbtncolDienBienQuaTrinhLuong();

    
    getLastDienBienQuaTringLuong();
}
function getLastDienBienQuaTringLuong() {
    //load các textbox chức danh nghề nghiệp viên chức
    var _maLyLichVienChuc = $("#divDienBienQuaTrinhLuong").data("malylichvienchuc");
    var param = {
        maLyLichVienChuc: _maLyLichVienChuc
    }
    var ajaxActionName = "GetLastDienBienQuaTrinhLuong";
    $.ajax({
        url: _ajaxUrl + ajaxActionName,
        dataType: "json",
        data: param,
        success: function (result) {
            
            $("#txtTenChucDanh").val(result.TenChucDanh);
            $("#txtMaSoChucDanhNgheNghiep").val(result.MaSoChucDanhNgheNghiep);
            $("#txtBacLuong").val(result.BacLuong);
            $("#txtHeSo").val(result.HeSo);
            $("#txtVuotKhung").val(result.VuotKhung);
            $("#txtNgayHuong").val(result.NgayHuong);
            $("#txtPhuCapChucVu").val(result.PhuCapChucVu);
            $("#txtPhuCapKhac").val(result.PhuCapKhac);
            //bindbtnThemDienBienQuaTrinhLuong();
            //bindbtncolDienBienQuaTrinhLuong();
        }
    });
}
function bindbtnThemDienBienQuaTrinhLuong() {
    $("#btnThemQuaTrinhLuong").unbind("click").click(function () {
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_btnXoa").hide();
        showModalDienBienQuaTrinhLuong(0);
    });
}
function bindbtncolDienBienQuaTrinhLuong() {
    $(".colDienBienQuaTrinhLuong").unbind("click").click(function () {
        var maDienBienQuaTrinhLuong = $(this).data("madienbienquatrinhluong");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_btnXoa").show();
        showModalDienBienQuaTrinhLuong(maDienBienQuaTrinhLuong);
    });
}
function bindAutoComplete(controlId, ajaxActionName) {
    $(controlId).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: _ajaxUrl + ajaxActionName,
                dataType: "json",
                data: {
                    keyword: request.term
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        delay: 500
    });
}

function revertDMY(date) {    
    var newdate = date.split('/').reverse().join('/');
    return newdate;
}


function showModalDienBienQuaTrinhLuong(idDienBien) {

    // idDienBien = 0: new
    // idDienBien > 0: edit

    // gửi ajax lấy về diễn biến theo mã được chọn
    var _selectedDienBien;
    if (idDienBien > 0) {
        var ajaxActionName = "GetDienBienQuaTrinhLuong";
        $.ajax({
            url: _ajaxUrl + ajaxActionName,
            dataType: "json",
            data: {
                id: idDienBien
            },
            success: function (result) {
                _selectedDienBien = result;
                $("#modalQuaTrinhLuong_selectChucDanhNgheNghiep").val(_selectedDienBien.MaChucDanhNgheNghiep);
                $("#modalQuaTrinhLuong_txtBacLuong").val(_selectedDienBien.BacLuong);
                $("#modalQuaTrinhLuong_txtHeSo").val(_selectedDienBien.HeSo);
                $("#modalQuaTrinhLuong_txtVuotKhung").val(_selectedDienBien.VuotKhung);
                $("#modalQuaTrinhLuong_txtNgayHuong").val(_selectedDienBien.NgayHuong);
                $("#modalQuaTrinhLuong_txtPhuCapChucVu").val(_selectedDienBien.PhuCapChucVu);
                $("#modalQuaTrinhLuong_txtPhuCapKhac").val(_selectedDienBien.PhuCapKhac);

                $("#modalQuaTrinhLuong_btnLuuDienBienQuaTrinhLuong").html("Cập nhật diễn biến");
            }
        });
        
    } else {
        $("#modalQuaTrinhLuong_selectChucDanhNgheNghiep").val("");
        $("#modalQuaTrinhLuong_txtBacLuong").val("");
        $("#modalQuaTrinhLuong_txtHeSo").val("");
        $("#modalQuaTrinhLuong_txtVuotKhung").val("");
        $("#modalQuaTrinhLuong_txtNgayHuong").val("");
        $("#modalQuaTrinhLuong_txtPhuCapChucVu").val("");
        $("#modalQuaTrinhLuong_txtPhuCapKhac").val("");
        $("#modalQuaTrinhLuong_btnLuuDienBienQuaTrinhLuong").html("Thêm diễn biến");
    }
    
    $("#modalChucDanhNgheNghiepVienChuc").modal("show");
    bindbtn_modalChucDanhNgheNghiepVienChuc_btnLuu(idDienBien);
    
    bindbtn_modalChucDanhNgheNghiepVienChuc_btnXoa(idDienBien);

    
}





var daysInMonth = function (m, y) {
    switch (m) {
        case 1:
            return (y % 4 == 0 && y % 100) || y % 400 == 0 ? 29 : 28;
        case 8: case 3: case 5: case 10:
            return 30;
        default:
            return 31
    }
};

var isValidDate = function (d, m, y) {
    m = parseInt(m, 10) - 1;
    return m >= 0 && m < 12 && d > 0 && d <= daysInMonth(m, y);
};
