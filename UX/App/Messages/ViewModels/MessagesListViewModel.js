messagesModule.controller("messagesListViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;

    //var initialize = function () {
    //    $scope.refreshOrders();
    //}

    //$scope.refreshOrders = function () {
    //    viewModelHelper.apiGet('api/orders', null,
    //        function (result) {
    //            $scope.orders = result.data;
    //        });
    //}

    //$scope.showOrder = function (order) {
    //    $scope.flags.shownFromList = true;
    //    viewModelHelper.navigateTo('order/show/' + order.OrderId);
    //}

    initialize();
});
