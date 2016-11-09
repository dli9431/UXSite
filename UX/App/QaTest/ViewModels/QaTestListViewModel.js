qaTestModule.controller("qaTestListViewModel", function ($scope, qaTestService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.qaTestService = qaTestService;

    var initialize = function () {
        $scope.refreshTests();
    }

    $scope.refreshTests = function () {
        var user = $("#currentUser").text();
        viewModelHelper.apiGet("api/Tests/GetTests?id=" + user, null,
            function (result) {
                $scope.tests = result.data;
            });
    }

    //$scope.showProduct = function (product) {
    //    $scope.flags.shownFromList = true;
    //    viewModelHelper.navigateTo('product/show/' + product.ProductId);
    //}

    initialize();
});
