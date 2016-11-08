messagesModule.controller("messagesDetailViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;

    //var initialize = function () {
    //    loadOrderDetail($routeParams.orderId, $routeParams.orderDetailId);
    //}

    //var loadOrderDetail = function (orderId, orderDetailId) {
    //    viewModelHelper.apiGet('api/order/detail/' + orderId + '/' + orderDetailId, null,
    //        function (result) {
    //            $scope.orderDetail = result.data;
    //        });
    //}

    initialize();
});
