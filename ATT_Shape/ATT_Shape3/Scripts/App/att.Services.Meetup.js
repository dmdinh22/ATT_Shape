att.services.meetup = att.services.meetup || {};

att.services.meetup.getNearbyEvents = function (endpoint, onSuccess, onError) {
    var url = endpoint;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: 'GET',
        xhrFields: {
            withCredentials: true
        },
        crossDomain: true
    };
    $.ajax(url, settings);
} //getNearbyEvents