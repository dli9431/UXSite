qaTestModule.controller("rootViewModel", function ($scope, qaTestService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'productModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Product.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.qaTestService = qaTestService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "QA Tests";
    }

    $scope.qaTestList = function () {
        viewModelHelper.navigateTo("tests/list");
    }

    initialize();
});
