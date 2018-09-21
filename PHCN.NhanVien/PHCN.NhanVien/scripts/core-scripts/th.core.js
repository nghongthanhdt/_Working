var daysInMonth = function (m, y) {
    switch (m) {
        case 1:
            return (y % 4 == 0 && y % 100) || y % 400 == 0 ? 29 : 28;
        case 8: case 3: case 5: case 10:
            return 30;
        default:
            return 31
    }
};
var isValidDate = function (d, m, y) {
    m = parseInt(m, 10) - 1;
    return m >= 0 && m < 12 && d > 0 && d <= daysInMonth(m, y);
};
function revertDMY(date) {
    var newdate = date.split('/').reverse().join('/');
    return newdate;
}


function thAlert(message) {
    swal(
      message,
      '',
      'success'
    )
}
function thAlertShowSuccess(message) {
    swal({
        type: 'success',
        title: message,            
        text: 'Thành công'
    })
}
function thAlertShowError(message) {
    swal({
        type: 'error',
        title: 'Lỗi',
        text: message
    })
}
function thAlertShowSystemError(message) {
    swal({
        type: 'error',
        title: 'Lỗi hệ thống, vui lòng liên hệ quản trị',
        text: message
    })
}

function thAjaxLoadHtml(_url, _param, _success) {
    $.ajax({
        method: "POST",
        type: "html",
        url: _url,
        data: _param,
        success: _success
    });
}
function thAjaxAction(_url, _param, _success) {
    $.ajax({
        method: "POST",        
        url: _url,
        data: _param,
        success: _success,
        error: function (xhr, ajaxOptions, thrownError) {            
            alert("Lỗi hệ thống, vui lòng liên hệ quản trị: #" + xhr.status + ": " + thrownError);
        }
    });
}
function thAjaxReturnJson(_url, _param, _success) {
    $.ajax({
        method: "POST",
        type: "json",
        url: _url,
        data: _param,
        success: _success,
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Lỗi hệ thống, vui lòng liên hệ quản trị: #" + xhr.status + ": " + thrownError);
        }
    });
}
function thAlertConfirm(message) {
    swal({
        title: 'Xác nhận',
        text: message,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Đồng ý',
        cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
        if (result.value) {
            return true;
        } else return false;
    })
}

function replaceAll(string, target, replacement) {

    var i = 0, length = string.length;

    for (i; i < length; i++) {

        string = string.replace(target, replacement);

    }

    return string;

}
function RewriteTieuDe(alias) {
    var str = alias;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g, " ");
    str = str.replace(/ + /g, " ");
    str = str.trim();

    str = replaceAll(str, " ", "-");
    return str;
}