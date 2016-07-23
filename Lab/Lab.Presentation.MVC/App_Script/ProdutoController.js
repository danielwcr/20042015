(function () {
    'use strict';

    angular.module('app.ProdutoController', [])
        .controller('ProdutoController', ['$scope', '$http', produtoController]);

    function produtoController($scope, $http) {
        $http.get('ObterProdutos').success(function (data) {
            $scope.produtos = data;
        });
    }
})();