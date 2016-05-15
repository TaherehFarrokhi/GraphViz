(function () {
    'use strict';

    angular
        .module('app')
        .controller('graphController', graphController);

    graphController.$inject = ['graphService']; 

    function graphController(graphService) {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() {
            graphService.getGraph()
                .then(function(r) {
                    vm.model = r.data;
                }).catch(function(r) {

                });
        }
    }
})();
