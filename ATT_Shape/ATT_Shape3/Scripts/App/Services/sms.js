(function () {

    'use strict';

    angular.module('attApp')
        .factory('smsService', SmsServiceFactory);

    function SmsServiceFactory() {

        var object = sms;
        console.log('sms Service created successfully');
        return object;

    };

})();