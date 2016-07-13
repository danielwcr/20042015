(function () {
    'use strict';

    var produtoService = angular.module('produtoService', ['ngResource']);

    produtoService.factory('Produto', ['$resource', function ($resource) {
        return $resource('/api/produto/', {}, {
            query: { method: 'GET', params: {}, isArray: true }
        });

    }]);

})();