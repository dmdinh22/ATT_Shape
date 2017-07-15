(function () {
    'use strict';

    angular.module('attApp').factory('newsEntertainmentService', NewsEntertainmentService);
    NewsService.$inject = ['$http', '$q'];

    function NewsEntertainmentService($http, $q) {
        var srv = {
            get: _get,
            //put: _put,
            //deleteThis: _deleteThis,
            //post: _post
        };

        return srv;

        function _get(newsType) {
            return $http.get('https://newsapi.org/v1/articles?source=entertainment-weekly&sortBy=top&apiKey=c0f1a9cdf5b74ce6901a3bcb63edf7d8')
                .then(getSuccess)
                .catch(getError);

            function getSuccess(response) {
                console.log(response);
                console.log(response.data.articles);
                return response.data.articles;
            }

            function getError(response) {
                return $q.reject(response);
            }
        }
    }
})();