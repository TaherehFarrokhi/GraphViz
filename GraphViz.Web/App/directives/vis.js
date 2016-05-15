(function () {
    'use strict';

    angular
        .module('app')
        .directive('vis', visDirective);

    function visDirective() {
        return {
            restrict: 'A',
            scope: {
                graph: '='
            },
            link: function (scope, elem, attrs) {
                scope.$watch('graph', function(newValue, oldValue) {
                    var options = {};
                    var nodes = [];
                    var edges = [];

                    if (newValue) {
                        angular.forEach(newValue.nodes, function(n) {
                            nodes.push({ id: n.id, label: n.name });
                        });

                        angular.forEach(newValue.edges, function(n) {
                            edges.push({ from: n.sourceId, to: n.targetId, arrows: 'to' });
                        });

                        var data = {
                            nodes: new vis.DataSet(nodes),
                            edges: new vis.DataSet(edges)
                        };

                        var network = new vis.Network(elem[0], data, options);
                    }
                });
            }
        };

    }
})();
