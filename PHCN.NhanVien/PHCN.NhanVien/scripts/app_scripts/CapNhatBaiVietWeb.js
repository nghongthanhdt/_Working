$(document).ready(function () {
    

    bindbtnThemHinhAnh();
    bindfileuploadHinhAnh_Change();
    loadDanhSachHinhAnh();
    bindtxtTieuDe_Change();
    binddivAnhDaiDien_Click();
    bindbtnLuu_Click();
    loadDanhSachFileDinhKem();
    bindbtnThemFileDinhKem_Click();
    bindfileuploadDinhKem_Change();
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
            bindbtnHinhAnhBaiViet_Click();
            
        }
    });
}
function bindbtnThemHinhAnh() {
    $("#btnThemHinhAnh").unbind("click").click(function () {
        $("input#fileuploadHinhAnh").trigger("click");
    });
}
function bindfileuploadHinhAnh_Change() {
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
                loadDanhSachHinhAnh();
            }
        });
    });
}
function bindtxtTieuDe_Change() {
    $("#txtTieuDe").unbind("change").change(function () {
        var text = RewriteTieuDe($(this).val());
        $("#txtTieuDeRewrite").val(text);
    });
}
function binddivAnhDaiDien_Click() {
    $("#divAnhDaiDien").unbind("click").click(function () {
        if ($("#imgAnhDaiDien").attr("src") == "/Content/ImageManager/ClickChonAnhDaiDien.jpg") {
            thAlert("Vui lòng thêm hình vào trước, sau đó chọn ảnh làm đại điện");
        } else {
            //thAlert("Vui lòng chọn ảnh đã thêm làm đại điện");
            //var mabaiviet = $("#divAnhDaiDien").data("mabaiviet")
            //$("#hiddenMaBaiViet").val(mabaiviet);
            bindmodalTuyChonAnhDaiDien_btnXoaAnh_Click();
            $("#modalTuyChonAnhDaiDien").modal("show");
        }
    });
}
function bindmodalTuyChonAnhDaiDien_btnXoaAnh_Click() {
    $("#modalTuyChonAnhDaiDien_XoaAnh").unbind("click").click(function () {
        if (!confirm("Bạn thật sự muốn xóa ?")) {
            return;
        }
        var mabaiviet = $("#hiddenMaBaiViet").val();
        var _url = _ajaxUrl + "XoaAnhDaiDien";
        var _param = {
            MaBaiViet: mabaiviet
        }
        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                $("#imgAnhDaiDien").attr("src", _urlClickChonAnhDaiDien);
                $("#modalTuyChonAnhDaiDien").modal("hide");
            } else {
                alert("Lỗi hệ thống: " + result);
            }             
        });
    });
}


function bindbtnHinhAnhBaiViet_Click() {
    $(".btnHinhAnhBaiViet").unbind("click").click(function () {
        var src = $(this).data("src");
        var mahinhanh = $(this).data("mahinhanh");
        var mabaiviet = $(this).data("mabaiviet");
        $("#modalHinhAnh_HinhAnh").attr("src", src);
        $("#hiddenMaHinhAnh").val(mahinhanh)
        $("#hiddenMaBaiViet").val(mabaiviet)
        bindbtnDatLamAnhDaiDien();
        bindbtnThemVaoBaiViet(mahinhanh);
        bindbtnXoaAnh(mahinhanh);
        $("#modalHinhAnh").modal("show");
    });
}
function bindbtnDatLamAnhDaiDien() {
    $("#modalHinhAnh_btnDatLamAnhDaiDien").unbind("click").click(function () {
        var _mahinhanh = $("#hiddenMaHinhAnh").val();
        var _mabaiviet = $("#hiddenMaBaiViet").val();
        var _url = _ajaxUrl + "LuuHinhAnhDaiDienChoBaiViet";
        var _param = {
            MaBaiViet: _mabaiviet,
            MaHinhAnh: _mahinhanh
        }
        thAjaxReturnJson(_url, _param, function (result) {
                $("#imgAnhDaiDien").attr("src", result.DuongDan + result.TenFileDayDu);
                $("#modalHinhAnh").modal("hide");
        });

        
    });
}
function bindbtnThemVaoBaiViet(mahinhanh) {
    $("#modalHinhAnh_btnThemVaoBaiViet").unbind("click").click(function () {
        var src = $("#modalHinhAnh_HinhAnh").attr("src");
        var html = "<br/><br/><img src='"+src+"' style='width:100%' /><br/><br/>";
        CKEDITOR.instances.txtNoiDung.insertHtml(html);
        $("#modalHinhAnh").modal("hide");
    });
}
function bindbtnXoaAnh(mahinhanh) {
    $("#modalHinhAnh_btnXoaAnh").unbind("click").click(function () {
        if (!confirm("Bạn thật sự muốn xóa ?")) {
            return;
        }
        var url = _ajaxUrl + "XoaHinhAnh";
        var param = {                    
            MaHinhAnh: mahinhanh
        }
        thAjaxAction(url, param, function (result) {
                    
            if (result == "ok") {
                $("#modalHinhAnh").modal("hide");
                loadDanhSachHinhAnh();
            }
                
        });
    });
}

function loadDanhSachFileDinhKem() {
    var ajaxActionName = "_pDanhSachFileDinhKem";
    var _paramMaBaiViet = $("#divDanhSachFileDinhKem").data("mabaiviet");
    var param = {
        MaBaiViet: _paramMaBaiViet
    }
    $.ajax({
        url: _ajaxThisUrl + ajaxActionName,
        dataType: "html",
        data: param,
        success: function (result) {
            $("#divDanhSachFileDinhKem").html(result);
            bindlinkFileDinhKem_Click();
        }
    });
}
function bindlinkFileDinhKem_Click() {
    $(".linkFileDinhKem").unbind("click").click(function () {
        var tenfile = $(this).data("tenfile");
        var tenfilefull = $(this).data("tenfilefull");
        var mafile = $(this).data("mafile");
        $("#lblTenFile").html(tenfile);
        $("#modalFileDinhKem_btnXoaFile").attr("data-mafile", mafile);
        $("#modalFileDinhKem_btnTaiFile").attr("href", _FileManagerUrl + tenfilefull)
        bindmodalFileDinhKem_btnXoaFile_Click();
        $("#modalFileDinhKem").modal("show");
    });
}
function bindbtnThemFileDinhKem_Click() {
    $("#btnThemFileDinhKem").click(function () {
        $("input#fileuploadDinhKem").trigger('click');
    });
}
function bindfileuploadDinhKem_Change() {
    $("input#fileuploadDinhKem").on('change', function () {
        var allowedExtensions = /(\.xls|\.xlsx|\.ppt|\.pptx|\.doc|\.docx|\.pdf|\.zip|\.rar|\.jpg|\.jpeg|\.png|\.gif)$/i;
        if (!allowedExtensions.exec(this.value)) {
            alert('Chỉ cho phép đính kèm các file xls,xlsx,doc,docx,pdf,zip,rar,jpg,jpeg,png,gif');
            this.value = "";
            return;
        }
        if (this.files[0].size > 52428800) {
            alert("Vui lòng không gửi file quá 50MB!");
            this.value = "";
            return;
        };
        $("form#formFileDinhKem").ajaxSubmit({
            type: "post",
            success: function () {
                $("input#fileuploadDinhKem").val(null);
                loadDanhSachFileDinhKem();
            }
        });
    });
}

/// còn lỗi lưu ảnh đại diện chưa chính xác
function bindmodalFileDinhKem_btnXoaFile_Click() {
    $("#modalFileDinhKem_btnXoaFile").unbind("click").click(function () {
        if (!confirm("Bạn thật sự muốn xóa ?")) {
            return;
        }
        var mafile = $(this).data("mafile");
        var _url = _ajaxUrl + "XoaFileDinhKemWeb";
        var _param = {
            MaFile: mafile
        }
        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                $("#modalFileDinhKem").modal("hide");
                loadDanhSachFileDinhKem();
            } else {
                alert("Lỗi hệ thống: " + result);
            }
        });

        

    });
}

function bindbtnLuu_Click() {
    $("#btnLuu").unbind("click").click(function () {
        
        var maChuyenMuc = $("#selectChuyenMuc").val();
        var maNhanVien = _maNhanVien;
        var maHinhAnh = $("#divAnhDaiDien").data("mahinhanh");        
        
        var tieuDe = $("#txtTieuDe").val();
        var ngay = $("#txtNgay").val();
        var tomTat = $("#txtTomTat").val();
        var noiDung = CKEDITOR.instances.txtNoiDung.getData();
        var tacGia = $("#txtTacGia").val();
        var hienThiTrenTrangChu = false;
        if ($("#checkboxHienThiTrenTrangChu").is(":checked")) {
            hienThiTrenTrangChu = true;
        }
        var tieuDeRewrite = $("#txtTieuDeRewrite").val();


        // validate
        if (tieuDe == "") {
            thAlertShowError("Chưa nhập tiêu đề");
            return;
        }
        if (maChuyenMuc == "") {
            thAlertShowError("Chưa chọn chuyên mục");
            return;
        }
        if (tomTat == "") {
            thAlertShowError("Chưa nhập tóm tắt");
            return;
        }
        if (noiDung == "") {
            thAlertShowError("Chưa nhập nội dung");
            return;
        }
        if (tieuDeRewrite == "") {
            thAlertShowError("Chưa nhập tên đường dẫn");
            return;
        }

        var _url = _ajaxUrl + "LuuBaiVietWeb";
        var _param = {
            MaBaiViet: _maBaiViet,
            maChuyenMuc: maChuyenMuc,
            MaNhanVien: _maNhanVien,
            MaHinhAnh: _maHinhAnh,
            TieuDe: tieuDe,
            TieuDeRewrite: tieuDeRewrite,
            TomTat: tomTat,
            NoiDung: noiDung,
            Ngay: ngay,
            HienThiTrenTrangChu: hienThiTrenTrangChu,
            Xoa: false,
            TacGia: tacGia,
            CapNhatLanCuoi: null
        }        
        thAjaxAction(_url, _param, function (result) {
            if (result == "ok") {
                thAlertShowSuccess("Đã lưu bài viết");
            } else {
                alert(result);
            }
        });

    });
}