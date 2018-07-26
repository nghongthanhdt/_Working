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
    });
});