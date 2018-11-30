$(document).ready(function () {
    btnCapNhatSTT_OnClick();
    btnXoa_OnClick();
});
function btnCapNhatSTT_OnClick() {
    $("#btnCapNhatSTT").unbind("click").click(function () {
        
        var sttIsNull = false;
        var sttIsMaxLength = false;
        $(".txtSTT").each(function () {
            if ($(this).val() == "") {
                sttIsNull = true;                
            }
            if ($(this).val().length > 5) {
                sttIsMaxLength = true;                
            }
        });
        if (sttIsNull) {
            thAlertShowError("STT không được để trống");
            return;
        }
        if (sttIsMaxLength) {
            thAlertShowError("STT không quá 5 ký tự");
            return;
        }
        

        var _listSTTValue = $('.txtSTT').map(function () {
            return $(this).val();
        }).get();
        var listSTTValue = _listSTTValue.join(",");
        var _listSTTMaKhoa = $('.txtSTT').map(function () {
            return $(this).data("makhoa");
        }).get();
        var listSTTMaKhoa = _listSTTMaKhoa.join(",");
        
        var pListMaKhoa = listSTTMaKhoa;
        var pListSTTValue = listSTTValue;

        var url = urlController + "CapNhatSTT";
        var param = {
            ListMaKhoa: pListMaKhoa,
            ListSTTValue: pListSTTValue
        };
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã cập nhật STT");
                setInterval(function () {                    
                    window.location = window.location;
                },1500);
                
            } else {
                thAlertShowSystemError(result);
            }
        });
    });
}
function btnXoa_OnClick() {
    $(".btnXoa").unbind("click").click(function () {
        var maKhoa = $(this).data("makhoa");
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