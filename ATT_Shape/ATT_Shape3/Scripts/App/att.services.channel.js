att.services.channel = att.services.channel || {};

att.services.channel.addUser = function (id, onSuccess, onError) {
    var url = '/api/channel' + id;
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
};