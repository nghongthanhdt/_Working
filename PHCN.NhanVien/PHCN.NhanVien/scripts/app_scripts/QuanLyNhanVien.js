$(document).ready(function () {

    $("#btnXemChiTiet").unbind("click").click(function () {
        $("#modalXemChiTiet").modal("show");
    });

    


    loadThongTinLienHe();
    // end document.ready();
});

function loadThongTinLienHe() {
    var _url = _ajaxThisUrl + "_pThongTinLienHe";
    var _param = { id: _maNhanVien };
    thAjaxLoadHtml(_url, _param, successLoadThongTinLienHe);
}
function successLoadThongTinLienHe(result) {
    $("#divThongTinLienHe").html(result);
    $("#btnCapNhatThongTinLienHe").unbind("click").click(function () {
        $("#modalThongTinLienHe").modal("show");
        bindbtn_modalThongTinLienHe_btnLuu();
    });

    $("#btnDoiMatKhauNhanVien").unbind("click").click(function () {
        $("#modalDoiMatKhau").modal("show");
        btnbtn_modalDoiMatKhau_btnLuu();
    });
}
function bindbtn_modalThongTinLienHe_btnLuu() {


    $("#modalThongTinLienHe_btnLuu").unbind("click").click(function () {
        var maNhanVien = $(this).data("manhanvien");
        var email = $("#modalLienHe_txtEmail").val();
        var dienThoai = $("#modalLienHe_txtDienThoai").val();
        var dienThoaiNoiBo = $("#modalLienHe_txtDienThoaiNoiBo").val();
        var _url = _ajaxManager + "LuuThongTinLienHeNhanVien";
        var _param = { id: maNhanVien, Email:email, DienThoai: dienThoai, DienThoaiNoiBo: dienThoaiNoiBo};
        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                //thAlertShowSuccess("Đã cập nhật thành công");
                $("#modalThongTinLienHe").modal("hide");
                loadThongTinLienHe();
                thAlertShowSuccess("Đã lưu liên hệ");
            } else {
                thAlertShowError(result);
            }

        });
    });


}

function btnbtn_modalDoiMatKhau_btnLuu() {
    $("#modalDoiMatKhau_btnLuu").unbind("click").click(function () {
        //var matKhauCu = $("#modalDoiMatKhau_txtMatKhauCu").val();
        var matKhauMoi = $("#modalDoiMatKhau_txtMatKhauMoi").val();
        var nhapLaiMatKhauMoi = $("#modalDoiMatKhau_txtNhapLaiMatKhauMoi").val();

        //if (matKhauCu == "") {
        //    $("#modalDoiMatKhau_spanThongBao").html("Nhập mật khẩu cũ");
        //    return;
        //}
        if (matKhauMoi == "") {
            $("#modalDoiMatKhau_spanThongBao").html("Nhập mật khẩu mới");
            return;
        }
        if (nhapLaiMatKhauMoi == "") {
            $("#modalDoiMatKhau_spanThongBao").html("Nhập lại mật khẩu mới");
            return;
        }
        if (matKhauMoi != nhapLaiMatKhauMoi) {
            $("#modalDoiMatKhau_spanThongBao").html("Nhập lại mật khẩu mới chưa trùng khớp");
            return;
        }
        
        var _url = _ajaxManager + "DoiMatKhauNhanVien";
        var _param = { id: _maNhanVien, MatKhauMoi: matKhauMoi }
        thAjaxAction(_url, _param, successDoiMatKhau);


    });
}
function successDoiMatKhau(result) {
    
    if (result == "ok") {
        //$("#modalDoiMatKhau_txtMatKhauCu").val("");
        $("#modalDoiMatKhau_txtMatKhauMoi").val("");
        $("#modalDoiMatKhau_txtNhapLaiMatKhauMoi").val("");
        $("#modalDoiMatKhau_spanThongBao").html("");
        $("#modalDoiMatKhau").modal("hide");
        thAlertShowSuccess("Đã đổi mật khẩu");
        return;
    } else {
        //$("#modalDoiMatKhau_txtMatKhauCu").val("");
        $("#modalDoiMatKhau_txtMatKhauMoi").val("");
        $("#modalDoiMatKhau_txtNhapLaiMatKhauMoi").val("");
        $("#modalDoiMatKhau_spanThongBao").html("");
        $("#modalDoiMatKhau").modal("hide");
        alert("Lỗi hệ thống, vui lòng liên hệ quản trị: " + result);
        return;
    }

}
