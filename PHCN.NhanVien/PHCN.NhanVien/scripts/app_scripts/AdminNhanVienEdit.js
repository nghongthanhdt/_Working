$(document).ready(function () {
    disabletxtMatKhau();
    btnLuuNhanVien_OnClick();
    btnDoiMatKhau_OnClick();
    btnXoaNhanVien_OnClick();
    btnThemPhanQuyen_OnClick();
    btnXoaPhanQuyen_OnClick();
});

function disabletxtMatKhau() {
    if (maNhanVien == 0) {
        $("#txtMatKhau").removeAttr("disabled", "disabled");
    } else {
        $("#txtMatKhau").attr("disabled", "disabled");
    }

}

function btnLuuNhanVien_OnClick() {
    $("#btnLuuNhanVien").unbind("click").click(function () {
        var pMaNhanVien = maNhanVien;
        var pHoTen = $("#txtHoTen").val();
        var pChucVu = $("#txtChucVu").val();
        var pMaKhoa = $("#selectKhoa").val();
        var pSTT = $("#txtSTT").val();
        var pEmail = $("#txtEmail").val();
        var pSoDienThoai = $("#txtSoDienThoai").val();
        var pSoDienThoaiNoiBo = $("#txtSoDienThoaiNoiBo").val();
        var pTenDangNhap = $("#txtTenDangNhap").val();
        var pMatKhau = $("#txtMatKhau").val();
        var pNhanThu = $("#checkboxNhanThu").is(":checked");

        //validate

        if (pHoTen == "") {
            thAlertShowError("Chưa nhập họ tên");
            return;
        }
        if (pMaKhoa == "") {
            thAlertShowError("Chưa chọn khoa phòng");
            return;
        }
        if (pSTT == "") {
            thAlertShowError("Chưa nhập STT");
            return;
        }
        if (pTenDangNhap == "") {
            thAlertShowError("Chưa nhập tên đăng nhập");
            return;
        }
        if (pMaNhanVien == 0 && pMatKhau == "") {
            thAlertShowError("Chưa nhập mật khẩu");
            return;
        }

        //end validate

        var url = urlController + "Save";
        var param = {
            MaNhanVien: pMaNhanVien,
            HoTen: pHoTen,
            ChucVu: pChucVu,
            MaKhoa: pMaKhoa,
            STT: pSTT,
            Email: pEmail,
            SoDienThoai: pSoDienThoai,
            SoDienThoaiNoiBo: pSoDienThoaiNoiBo,
            TenDangNhap: pTenDangNhap,
            MatKhau: pMatKhau,
            NhanThu: pNhanThu
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã lưu nhân viên");
                return;
            } else {
                thAlertShowSystemError(result);
                return;
            }
        });
    });
}

function btnDoiMatKhau_OnClick() {
    $("#btnDoiMatKhau").click(function () {
        $("#modalDoiMatKhau_txtMatKhauMoi").val("");
        $("#modalDoiMatKhau_txtNhapLaiMatKhauMoi").val("");
        modalDoiMatKhau_btnLuu_OnClick();
        $("#modalDoiMatKhau").modal("show");
    });
}
function btnXoaNhanVien_OnClick() {
    $("#btnXoaNhanVien").click(function () {
        thConfirm("Bạn thật sự muốn xóa nhân viên này ?", function () {
            var pMaNhanVien = maNhanVien;
            var url = urlController + "XoaNhanVien";
            var param = {
                MaNhanVien: pMaNhanVien
            }
            thAjaxAction(url, param, function (result) {
                if (result == "ok") {
                    thAlertShowSuccess("Đã xóa nhân viên");
                    setInterval(function () {
                        window.location = urlController;
                    }, 1000);
                    return;
                }
            });
            


        });
        
    });
}
function modalDoiMatKhau_btnLuu_OnClick() {
    $("#modalDoiMatKhau_btnLuu").unbind("click").click(function () {
        var pMaNhanVien = maNhanVien;
        var pMatKhau = $("#modalDoiMatKhau_txtMatKhauMoi").val();
        var pNhapLaiMatKhau = $("#modalDoiMatKhau_txtNhapLaiMatKhauMoi").val();
        
        //validate
        if (pMatKhau == "") {
            thAlertShowError("Nhập mật khẩu mới cần đổi");
            return;
        } else
        if (pNhapLaiMatKhau == "") {
            thAlertShowError("Nhập lại mật khẩu mới cần đổi");
            return;
        } else
        if (pMatKhau != pNhapLaiMatKhau) {
            thAlertShowError("Nhập lại mật khẩu chưa trùng khớp");
            return;
        }
        //end validate

        var url = urlController + "AdminDoiMatKhau";
        var param = {
            MaNhanVien: pMaNhanVien,
            MatKhau: pMatKhau
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã đổi mật khẩu");
                $("#modalDoiMatKhau").modal("hide");
                return;
            } else {
                thAlertShowSystemError(result);
                return;
            }
        });
        
    });
}


function btnThemPhanQuyen_OnClick() {
    $("#btnThemPhanQuyen").unbind("click").click(function () {
        modalThemPhanQuyen_btnThem_OnClick();
        $("#modalThemPhanQuyen").modal("show");
    });
    
}

function modalThemPhanQuyen_btnThem_OnClick() {
    $(".modalThemPhanQuyen_btnThem").unbind("click").click(function () {
        var pMaNhanVien = maNhanVien;
        var pMaQuyen = $(this).data("maquyen");

        var url = urlController + "ThemPhanQuyen";
        var param = {
            MaNhanVien:pMaNhanVien,
            MaQuyen:pMaQuyen
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                window.location = window.location;
            } else if (result == "phanquyendatontai") {
                $("#modalThemPhanQuyen").modal("hide");
                thAlert("Phân quyền đã tồn tại, vui lòng kiểm tra lại");
            } else {
                thAlertShowSystemError(result);
            }
        });
    });
}

function btnXoaPhanQuyen_OnClick() {
    $(".btnXoaPhanQuyen").unbind("click").click(function () {
        var pMaPhanQuyen = $(this).data("maphanquyen");

        thConfirm("Bạn thật sự muốn xóa phân quyền ?", function () {
            var url = urlController + "XoaPhanQuyen";
            var param = {
                MaPhanQuyen: pMaPhanQuyen
            }
            thAjaxAction(url, param, function (result) {
                if (result == "ok") {
                    window.location = window.location;
                } else {
                    thAlertShowSystemError(result);
                }
            });
        });
        
        
        
    });
}