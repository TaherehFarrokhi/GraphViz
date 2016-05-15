(function () {
    'use strict';

    angular
        .module('app')
        .service('graphService', graphService);

    graphService.$inject = ['$http'];

    function graphService($http) {
        this.getGraph = getGraph;

        function getGraph() {
            return $http.get('/api/graph');
        }
    }
})();