(function () {
    "use strict";

    angular.module("attApp")
        .factory("channelService", ChannelService);

    function ChannelService() {

        var obj = att.services.channel;
        console.log("Channel Service created successfully");
        return obj;
    }

})();