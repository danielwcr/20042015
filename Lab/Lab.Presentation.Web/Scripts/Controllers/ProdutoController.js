(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProdutoController', ProdutoController);

    ProdutoController.$inject = ['$scope', 'Produto']; 

    function ProdutoController($scope, Produto) {
        $scope.produtos = Produto.query();
    }
})();
