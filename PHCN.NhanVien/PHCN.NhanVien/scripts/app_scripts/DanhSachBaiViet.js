$(document).ready(function () {
    bindbtnNgungHoatDong_OnClick();
    bindbtnHoatDong_OnClick();
    bindbtnXoa_OnClick();
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

        var _url = _ajaxUrl + "NgungHoatDongBaiViet";
        var _param = {
            ListBaiViet: listBaiViet
        }

        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                window.location = window.location;
            } else {
                alert(result);
            }
        });
        // thực hiện cập nhật ngưng hoạt động bài viết
    });    
}
function bindbtnHoatDong_OnClick() {
    $("#btnHoatDong").unbind("click").click(function () {
        var listCheckedBaiViet = $('.checkboxChonBaiViet:checkbox:checked').map(function () {
            return $(this).data("mabaiviet");
        }).get();
        listBaiViet = listCheckedBaiViet.join(",");
        if (listBaiViet == "") {
            thAlertShowError("Chưa chọn bài viết");
            return;
        }

        if (!confirm("Bạn muốn bài viết hoạt động trở lại?")) {
            return;
        }

        var _url = _ajaxUrl + "HoatDongBaiViet";
        var _param = {
            ListBaiViet: listBaiViet
        }

        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                window.location = window.location;
            } else {
                alert(result);
            }
        });

    });
}
function bindbtnXoa_OnClick() {
    $("#btnXoa").unbind("click").click(function () {
        var listCheckedBaiViet = $('.checkboxChonBaiViet:checkbox:checked').map(function () {
            return $(this).data("mabaiviet");
        }).get();
        listBaiViet = listCheckedBaiViet.join(",");
        if (listBaiViet == "") {
            thAlertShowError("Chưa chọn bài viết");
            return;
        }

        if (!confirm("Bạn thật sự muốn xóa bài viết ?")) {
            return;
        }

        var _url = _ajaxUrl + "XoaBaiViet";
        var _param = {
            ListBaiViet: listBaiViet
        }

        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                window.location = window.location;
            } else {
                alert(result);
            }
        });
        // thực hiện cập nhật ngưng hoạt động bài viết
    });
}