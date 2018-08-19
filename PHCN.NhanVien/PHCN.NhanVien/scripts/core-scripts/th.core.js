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
      'Thành công',
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