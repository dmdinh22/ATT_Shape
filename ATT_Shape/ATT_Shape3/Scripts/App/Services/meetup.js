(function () {
    "use strict";

    angular.module("attApp")
        .factory("meetupService", meetupServiceFactory);

    function meetupServiceFactory() {

        var aMeetupServiceObject = att.services.meetup;
        console.log("Meetup Service created successfully");
        return aMeetupServiceObject;
    }

})();