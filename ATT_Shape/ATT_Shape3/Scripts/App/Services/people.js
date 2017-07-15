(function () {

    'use strict';

    angular.module('attApp')
        .factory('peopleService', peopleServiceFactory);

    function peopleServiceFactory() {

        var aPeopleServiceObject = att.services.people;
        console.log('People Service created successfully');
        return aPeopleServiceObject;

    };

})();