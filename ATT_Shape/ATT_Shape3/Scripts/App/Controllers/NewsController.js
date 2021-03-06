﻿(function () {
    'use strict';

    angular.module('attApp').controller('newsController', NewsController);
    NewsController.$inject = ['newsService', '$scope', '$location', '$window'];

    function NewsController(newsService, $scope, $location, $window) {
        var vm = this;
        vm.newsService = newsService;
        vm.$scope = $scope;
        vm.$location = $location;
        vm.$window = $window;

        //functionality
        vm.getNews = _getNews;

        //object container
        vm.listNews = [];

        _getNews();

        function _getNews() {
            console.log('herro');
            return vm.newsService.get().then(function (data) {
                vm.listNews = data;
                console.log('look here', vm.listNews);
            })
        }
    }
})();