messagesModule.controller("rootViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'orderModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Order.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Messages";
    }

    $scope.msgList = function () {
        viewModelHelper.navigateTo("messages/list");
    }
    $scope.sendMsg = function () {
        viewModelHelper.navigateTo("messages/send");
    }

    //$scope.showOrder = function () {
    //    if (orderService.orderId != 0) {
    //        $scope.flags.shownFromList = false;
    //        viewModelHelper.navigateTo('order/show/' + orderService.orderId);
    //    }
    //}

    initialize();
});
