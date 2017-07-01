(function () {

    'use strict';

    angular.module('attApp')
        .factory('peopleService', peopleServiceFactory);

    function peopleServiceFactory() {

        var aPeopleServiceObject = app.services.people;
        console.log('People Service created successfully');
        return aPeopleServiceObject;

    };

})();