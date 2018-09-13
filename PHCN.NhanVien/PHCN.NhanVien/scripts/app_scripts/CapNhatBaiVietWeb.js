$(document).ready(function () {
    bindbtnThemHinhAnh();
    loadDanhSachHinhAnh();
});
function loadDanhSachHinhAnh() {
    var ajaxActionName = "_pDanhSachHinhAnh";
    var _paramMaBaiViet = $("#divDanhSachHinhAnh").data("mabaiviet");
    var param = {
        MaBaiViet: _paramMaBaiViet
    }
    $.ajax({
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDanhSachHinhAnh").html(result);
            //bindbtncolDienBienQuaTrinhLuong();
        }
    });
}
function bindbtnThemHinhAnh() {
    $("#btnThemHinhAnh").unbind("click").click(function () {
        $("input#fileuploadHinhAnh").trigger("click");
        $("input#fileuploadHinhAnh").on('change', function () {
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
            $("form#formUploadHinhAnhWeb").ajaxSubmit({
                type: "post",
                success: function (result) {
                    // result là đường dẫn sau khi upload
                    if (result == "true") {
                        //loadHinhAnhVaoKhung();
                        //$("#modalTuyChonAvatar").modal("hide");
                        //alert(result);
                        loadDanhSachHinhAnh();
                    }
                }
            });
        });
    });
}