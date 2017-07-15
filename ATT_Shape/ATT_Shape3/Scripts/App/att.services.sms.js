var sms = {}
//att.services.sms = att.services.sms || {};

sms.send = function (data, onSuccess, onError) {
    var url = 'api/sms/cars';
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        type: 'POST',
        data: data,
        success: onSuccess,
        error: onError
    };
    $.ajax(url, settings);
}