$(document).ready(function () {
    bindbtnNgungHoatDong_OnClick();
});

function bindbtnNgungHoatDong_OnClick() {
    $("#btnNgungHoatDong").unbind("click").click(function () {
        var listCheckedBaiViet = $('.checkboxChonBaiViet:checkbox:checked').map(function () {
            return $(this).data("mabaiviet");
        }).get();
        listBaiViet = listCheckedBaiViet.join(",");
        if (listBaiViet == "") {
            thAlertShowError("Chưa chọn bài viết");
            return;
        }

        if (!confirm("Bạn muốn ngưng hoạt động bài viết ?")) {
            return;
        }

        // thực hiện cập nhật ngưng hoạt động bài viết
    });    
}