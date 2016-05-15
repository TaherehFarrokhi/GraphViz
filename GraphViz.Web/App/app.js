(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules
        'ngRoute'

        // Custom modules

        // 3rd Party Modules
        
    ]);

    app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/', {
            templateUrl: 'app/views/graph.html',
            controller: 'graphController',
            controllerAs : 'vm'
        }).

        otherwise({
            redirectTo: '/'
        });
  }]);
})();
