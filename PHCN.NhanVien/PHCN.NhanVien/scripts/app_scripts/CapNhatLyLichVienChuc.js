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
    loadDienBienQuaTrinhCongTac();
    bindbtnThemDienBienQuaTrinhCongTac();



    bindselectTaiKhoanNhanVien();


    bindbtnselectHinhAnh();


    loadHinhAnhVaoKhung();

    

    // end document ready

    
});


//diễn biến quá trình lương, chức danh nghề nghiệp
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
                $("#modalChucDanhNgheNghiepVienChuc_btnXoa").show();
                bindbtn_modalChucDanhNgheNghiepVienChuc_btnXoa(idDienBien);
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
        $("#modalChucDanhNgheNghiepVienChuc_btnXoa").hide();
    }    
    $("#modalChucDanhNgheNghiepVienChuc").modal("show");
    bindbtn_modalChucDanhNgheNghiepVienChuc_btnLuu(idDienBien);
}
function bindbtn_modalChucDanhNgheNghiepVienChuc_btnLuu(idDienBien) {
    $("#modalQuaTrinhLuong_btnLuuDienBienQuaTrinhLuong").unbind("click").click(function () {
        var _maLyLichVienChuc = $(this).data("malylichvienchuc");
        var _maChucDanhNgheNghiep = $("#modalQuaTrinhLuong_selectChucDanhNgheNghiep").val();
        var _bacLuong = $("#modalQuaTrinhLuong_txtBacLuong").val();
        var _heSo = $("#modalQuaTrinhLuong_txtHeSo").val();
        var _vuotKhung = $("#modalQuaTrinhLuong_txtVuotKhung").val();
        var _ngayHuong = revertDMY($("#modalQuaTrinhLuong_txtNgayHuong").val());
        var _phuCapChucVu = $("#modalQuaTrinhLuong_txtPhuCapChucVu").val();
        var _phuCapKhac = $("#modalQuaTrinhLuong_txtPhuCapKhac").val();
        if (_maChucDanhNgheNghiep == null || _maChucDanhNgheNghiep == "") {
            alert("Chưa chọn chức danh nghề nghiệp");
            return;
        }
        // kiểm tra ngày hưởng
        if (_ngayHuong == "") {
            alert("Chưa nhập ngày hưởng");
            return;
        }
        var ngayHuongSplit = _ngayHuong.split("/");
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
                    $("#modalChucDanhNgheNghiepVienChuc").modal("hide");
                }
            }
        });        
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
        id: _paramMaLyLichVienChuc
    }
    $.ajax({
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDienBienQuaTrinhLuong").html(result);
            bindbtncolDienBienQuaTrinhLuong();
        }
    });
    bindbtnThemDienBienQuaTrinhLuong();
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

// diễn biến đào tạo bồi dưỡng
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
                $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_btnLuu").text("Lưu diễn biến");
            }
        });
    } else {
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTenTruong").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtChuyenNganhDaoTao").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtTuThangNam").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtDenThangNam").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_selectHinhThucDaoTao").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_txtVanBangChungChiTrinhDo").val("");
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon_btnLuu").text("Thêm diễn biến");
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


// các hàm khác
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


// diễn biến quá trình công tác

function loadDienBienQuaTrinhCongTac() {
    var ajaxActionName = "_pDienBienQuaTrinhCongTac";
    var _paramMaLyLichVienChuc = $("#divDienBienQuaTrinhCongTac").data("malylichvienchuc");
    var param = {
        id: _paramMaLyLichVienChuc
    }
    $.ajax({
        method: "POST",
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDienBienQuaTrinhCongTac").html(result);
            bindrowSuaDienBienQuaTrinhCongTac();
            bindrowXoaDienBienQuaTrinhCongTac();
        }
    });
}
function bindrowSuaDienBienQuaTrinhCongTac() {
    $(".rowsuaDienBienQuaTrinhCongTac").unbind("click").click(function () {
        var idDienBien = $(this).data("madienbienquatrinhcongtac");
        showModalDienBienQuaTrinhCongTac(idDienBien);
    });
}
function bindrowXoaDienBienQuaTrinhCongTac() {
    $(".rowXoaDienBienQuaTrinhCongTac").unbind("click").click(function () {
        if (confirm("Bạn thật sự muốn xóa ?")) {
            var idDienBien = $(this).data("madienbienquatrinhcongtac");
            var param = {
                id: idDienBien
            }
            $.ajax({
                method: "POST",
                url: _ajaxUrl + "XoaDienBienQuaTrinhCongTac",
                data: param,
                success: function (data) {
                    if (data == "ok") {
                        loadDienBienQuaTrinhCongTac();
                    }
                }
            });
        }
    });
}
function bindbtnThemDienBienQuaTrinhCongTac() {
    $("#btnThemDienBienQuaTrinhCongTac").unbind("click").click(function () {
        showModalDienBienQuaTrinhCongTac(0);
    });
}
function showModalDienBienQuaTrinhCongTac(idDienBien) {
    // idDienBien = 0: new
    // idDienBien > 0: edit
    // gửi ajax lấy về diễn biến theo mã được chọn
    var _selectedDienBien;
    if (idDienBien > 0) {
        var ajaxActionName = "GetDienBienQuaTrinhCongTac";
        $.ajax({
            method: "POST",
            url: _ajaxUrl + ajaxActionName,
            dataType: "json",
            data: {
                id: idDienBien
            },
            success: function (result) {
                _selectedDienBien = result;
                $("#modalDienBienQuaTrinhCongTac_txtTuThangNam").val(_selectedDienBien.TuThangNam);
                $("#modalDienBienQuaTrinhCongTac_txtDenThangNam").val(_selectedDienBien.DenThangNam);
                $("#modalDienBienQuaTrinhCongTac_txtNoiDungCongTac").val(_selectedDienBien.NoiDungCongTac);
                $("#modalDienBienQuaTrinhCongTac_btnLuu").text("Lưu diễn biến");
            }
        });
    } else {
        $("#modalDienBienQuaTrinhCongTac_txtTuThangNam").val("");
        $("#modalDienBienQuaTrinhCongTac_txtDenThangNam").val("");
        $("#modalDienBienQuaTrinhCongTac_txtNoiDungCongTac").val("");
        $("#modalDienBienQuaTrinhCongTac_btnLuu").text("Thêm diễn biến");        
    }
    $("#modalDienBienQuaTrinhCongTac").modal("show");
    bindbtn_modalDienBienQuaTrinhCongTac_btnLuu(idDienBien);
}
function bindbtn_modalDienBienQuaTrinhCongTac_btnLuu(idDienBien) {
    $("#modalDienBienQuaTrinhCongTac_btnLuu").unbind("click").click(function () {
        //var _maDienBienQuaTrinhLuong = $('#modalChucDanhNgheNghiepVienChuc').data("malylichvienchuc");
        var _maLyLichVienChuc = $(this).data("malylichvienchuc");
        var _TuThangNam = "01/" + $("#modalDienBienQuaTrinhCongTac_txtTuThangNam").val();
        var _DenThangNam = "01/" + $("#modalDienBienQuaTrinhCongTac_txtDenThangNam").val();
        var _NoiDungCongTac = $("#modalDienBienQuaTrinhCongTac_txtNoiDungCongTac").val();

        //alert(_ngayHuong);
        //return;
        

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




        if (_NoiDungCongTac == "") {
            alert("Chưa nhập nội dung công tác");
            return;
        }




        var dienbienQuaTrinhCongTac = {
            MaDienBienQuaTrinhCongTac: idDienBien,
            MaLyLichVienChuc: _maLyLichVienChuc,
            TuThangNam: _TuThangNam,
            DenThangNam: _DenThangNam,
            NoiDungCongTac: _NoiDungCongTac

        }
        $.ajax({
            method: "POST",
            url: _ajaxUrl + "LuuDienBienQuaTrinhCongTac",
            data: dienbienQuaTrinhCongTac,
            success: function (data) {
                if (data == "ok") {
                    //alert(data);
                    $("#modalDienBienQuaTrinhCongTac").modal("hide");
                    loadDienBienQuaTrinhCongTac();

                }
            }
        });

    });
}


// bindselectTaiKhoanNhanVien
function bindselectTaiKhoanNhanVien() {
    $("#selectTaiKhoanNhanVien").unbind("change").change(function () {
        var label = $(this.options[this.selectedIndex]).closest('optgroup').prop('label');
        $("#txtKhoaPhong").val(label);
    });
}


// bind btn select Avatar 
function bindbtnselectHinhAnh() {
    $("#btnselectHinhAnh").unbind("click").click(function () {
        

        var _imgSrc = $("#imgAvatar").attr("src");

        if (_imgSrc == "/Content/img/default-avatar.png" || _imgSrc == "/Content/ImageAvatar/default-avatar.png") {
            $("#modalTuyChonAnh_btnXoaAnh").hide();
            // bind btn chọn ảnh khác
            bindbtn_modalTuyChonAnh_btnChonAnhKhac();
        } else {
            $("#modalTuyChonAnh_btnXoaAnh").show();
            
            // bind btn chọn ảnh khác, xóa ảnh
            bindbtn_modalTuyChonAnh_btnChonAnhKhac();
            bindbtn_modalTuyChonAnh_btnXoaAnh();
        }
        $("#modalTuyChonAnh_imgXemAnh").attr("src", _imgSrc);
        $("#modalTuyChonAnh_btnXoaAnh").data("mahinhanh", modalTuyChonAnh_btnXoaAnh)
        $("#modalTuyChonAvatar").modal("show");
        return false;
        
    });
    

}
function bindbtn_modalTuyChonAnh_btnChonAnhKhac() {
    $("#modalTuyChonAnh_btnChonAnhKhac").unbind("click").click(function () {
        $("#fileuploadAvatar").trigger("click");
        $("input#fileuploadAvatar").on('change', function () {
            var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.bmp)$/i;
            if (!allowedExtensions.exec(this.value)) {
                alert('Chỉ cho phép đính kèm các file jpg,jpeg,png,gif,bmp');
                this.value = "";
                return;
            }
            if (this.files[0].size > 52428800) {
                alert("Vui lòng không gửi file quá 50MB!");
                this.value = "";
                return;
            };
            $("form#formAvatar").ajaxSubmit({
                type: "post",
                success: function (result) {
                    // result là đường dẫn sau khi upload
                    if (result == "true") {
                        loadHinhAnhVaoKhung();
                        $("#modalTuyChonAvatar").modal("hide");
                        
                    }
                }
            });
        });
    });
}

function bindbtn_modalTuyChonAnh_btnXoaAnh() {
    $("#modalTuyChonAnh_btnXoaAnh").unbind("click").click(function () {
        if (!confirm("Bạn thật sự muốn xóa ảnh ?")) return;

        var _id = $("#imgAvatar").data("mahinhanh");
        var param = {
            id: _id
        }
        $.ajax({
            method: "POST",
            url: _ajaxUrl + "XoaAvatar",
            type: "html",
            data: param,
            success: function (data) {
                if (data == "ok") {
                    loadHinhAnhVaoKhung();
                    $("#modalTuyChonAvatar").modal("hide");
                }
            }
        });
    });
}
function loadHinhAnhVaoKhung() {
    
    var ajaxActionName = "GetLastAvatar";
    var _maLyLichVienChuc = $("#btnselectHinhAnh").data("malylichvienchuc");
    var param = {
        id: _maLyLichVienChuc
    }
    $.ajax({
        method: "POST",
        url: _ajaxUrl + ajaxActionName,
        dataType: "json",
        data: param,
        success: function (result) {
            if (result.MaLyLichVienChuc == 0) {
                $("#imgAvatar").attr("src", "/Content/img/default-avatar.png");
                $("#imgAvatar").attr("data-mahinhanh", "0");
            } else {
                $("#imgAvatar").attr("src", result.UrlAvatar);
                $("#imgAvatar").attr("data-mahinhanh", result.MaHinhAnh);
            }            
        }
    });

        
    
    // load lại avatar gần nhất

        
    
}



