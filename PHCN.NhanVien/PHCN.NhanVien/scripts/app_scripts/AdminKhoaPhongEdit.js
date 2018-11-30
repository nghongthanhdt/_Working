$(document).ready(function () {
    btnLuu_OnClick();
    btnXoa_OnClick();
});

function btnLuu_OnClick() {
    $("#btnLuu").unbind("click").click(function () {
        var pMaKhoa = $("#txtMaKhoa").val();
        var pSTT = $("#txtSTT").val();
        var pTenKhoa = $("#txtTenKhoa").val();
        var pMode = mode;       

        //validate 
        if (pMaKhoa == "") {
            thAlertShowError("Chưa nhập mã khoa");
            return;
        }
        if (pSTT == "") {
            thAlertShowError("Chưa nhập STT");
            return;
        }
        if (pTenKhoa == "") {
            thAlertShowError("Chưa nhập tên khoa");
            return;
        }
        //end validate
        var url = urlController + "Save";
        var param = {
            MaKhoa: pMaKhoa,
            STT: pSTT,
            TenKhoa: pTenKhoa,
            Mode: pMode
        }
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã lưu khoa phòng");
                
                setInterval(function () {
                    if (mode == "new") {
                        window.location = window.location;
                    } else {
                        window.location = urlController;
                    }
                    
                }, 1000);
            }
        });
    });
}
function btnXoa_OnClick() {
    $("#btnXoa").unbind("click").click(function () {
        thConfirm("Bạn thật sự muốn xóa khoa phòng ?", function () {
            var pMaKhoa = maKhoa;
            var param = {
                MaKhoa: pMaKhoa
            }
            var url = urlController + "Delete";
            thAjaxAction(url, param, function (result) {
                if (result == "ok") {
                    thAlertShowSuccess("Đã xóa khoa phòng");
                    setInterval(function () {
                        window.location = urlController;
                    }, 1000);                    
                } else {
                    thAlertShowSystemError(result);
                }
            });
        });
    });
    
}