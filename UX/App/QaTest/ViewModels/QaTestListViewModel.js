﻿qaTestModule.controller("qaTestListViewModel", function ($scope, qaTestService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.qaTestService = qaTestService;

    var initialize = function () {
        $scope.refreshTests();
    }

    $scope.refreshTests = function () {
        $http.get("/api/Tests/GetTests")
            .then(function(result) {
                $scope.tests = result.data;
            });
    }

    //$scope.showProduct = function (product) {
    //    $scope.flags.shownFromList = true;
    //    viewModelHelper.navigateTo('product/show/' + product.ProductId);
    //}

    initialize();
});
