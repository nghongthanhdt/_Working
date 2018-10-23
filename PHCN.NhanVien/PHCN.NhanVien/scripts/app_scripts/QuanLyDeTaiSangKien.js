$(document).ready(function () {
    bindrowXoa_OnClick();
});
function bindrowXoa_OnClick() {
    $(".rowXoaDeTaiSangKien").unbind("click").click(function () {
        var pId = $(this).data("madetaisangkien");
        if (!confirm("Bạn thật sự muốn xóa ?")) {
            return;
        }
        var url = urlController + "XoaDeTaiSangKien";
        var param = {
            id: pId
        };
        thAjaxAction(url, param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã xóa dữ liệu thành công");
                setInterval(function () {
                    location.reload();
                }, 1500);
            } else {
                alert(result);
            }
        })

    });
}