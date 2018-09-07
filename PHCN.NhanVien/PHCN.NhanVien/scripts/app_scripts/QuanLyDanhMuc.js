$(document).ready(function () {
    bindtabDanhMuc();
    bindbtnTimKiem();
    bindtxtTimKiem();
    bindbtnThemDanhMuc();
    bindbtnXoaDanhMuc();
});

function bindtxtTimKiem() {
    $('#txtTimKiem').keypress(function (e) {
        if (e.keyCode == 13) {

            $("#btnTimKiem").click();
        }        
    });
}
function bindbtnTimKiem() {
    $("#btnTimKiem").unbind("click").click(function () {
        var tenDanhMuc = "_p" + $("#hiddenSelectedDanhMuc").val();
        var timKiem = $("#txtTimKiem").val();

        if (tenDanhMuc == "_p") {
            thAlertShowError("Chưa chọn danh mục");
        }
        loadDanhSachDanhMuc(tenDanhMuc, timKiem);
    });
}
function bindtabDanhMuc() {
    $(".tabDanhMuc").unbind("click").click(function () {
        $(".tabDanhMuc").removeClass("active");
        $(this).addClass("active");
        $('#txtTimKiem').attr("placeholder", "Tìm kiếm...");
        var tenDanhMuc = "_p" + $(this).data("tendanhmuc");
        $("#hiddenSelectedDanhMuc").val($(this).data("tendanhmuc").toLowerCase());
        loadDanhSachDanhMuc(tenDanhMuc, "");
        
    });
}
function loadDanhSachDanhMuc(tenDanhMuc, timKiem) {
    var _url = _ajaxQuanLyDanhMuc + tenDanhMuc;
    var _param = {
        timkiem: timKiem
    }
    thAjaxLoadHtml(_url, _param, function (result) {
        $("#divDanhMuc").html(result);

        
        bindbtnThemDanhMuc();
        
    });         
}

function bindbtnThemDanhMuc() {
    $("#btnThemDanhMuc").unbind("click").click(function () {
        var tenDanhMuc = "_p" + $("#hiddenSelectedDanhMuc").val();
        //var timKiem = $("#txtTimKiem").val();
        if (tenDanhMuc == "_p") {
            thAlertShowError("Chưa chọn danh mục");
        } else {
            $("#modalDanhMuc").modal("show");
            bindmask_modalDanhMuc();
        }
        
        
        
    });
}


function bindmask_modalDanhMuc() {
    $('.number').mask('00000000000');
}

