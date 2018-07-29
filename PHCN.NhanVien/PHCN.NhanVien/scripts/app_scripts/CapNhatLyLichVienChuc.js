$(document).ready(function () {
    $("#btnThemChucDanhNgheNghiep").click(function () {
        $("#modalChucDanhNgheNghiepVienChuc").modal("show");
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




    $("#btnThemDaoTaoBoiDuongChuyenMon").click(function () {
        $("#modalDaoTaoBoiDuongNghiepVuChuyenMon").modal("show");
    });

    $("#btnThemTomTatQuaTrinhCongTac").click(function () {
        $("#modalTomTatQuaTrinhCongTac").modal("show");
    });
    $("#btnThemQuaTrinhLuong").click(function () {
        $("#modalChucDanhNgheNghiepVienChuc").modal("show");
        

        $("#modalQuaTrinhLuong_btnLuuDienBienQuaTrinhLuong").click(function () {
            var quaTrinhLuong = {
                MaDienBienQuaTrinhLuong: 0,
                MaLyLichVienChuc: 1,
                MaChucDanhNgheNghiep: 1,
                BacLuong: 2,
                HeSo: 1.2,
                NgayHuong: '2018/02/01',
                PhuCapChucVu: 1.3,
                PhuCapKhac: 1.4,
                VuotKhung: 15,
                Nhap_MaNhanVien: 1,
                Nhap_Ngay: '2018/04/17',
                CapNhat_MaNhanVien: 1,
                CapNhat_Ngay: '2018/04/17',
                Xoa: false,
                Xoa_MaNhanVien: null,
                Xoa_Ngay: null
            }
            $.ajax({
                url: _ajaxUrl + "LuuQuaTrinhLuong",
                data: quaTrinhLuong,
                success: function (data) {
                    alert(data);
                }
            });

        });

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

    //$("#txtNoiSinh_Tinh").autocomplete({
    //    source:listTrinhDoChuyenMonCaoNhat
    //});

});

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





