messagesModule.controller("messagesSendViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;
    
    //var initialize = function () {
    //    var user = $("#currentUser").text();
    //    $scope.sendMsg(user, $scope.todisplay, $scope.subject, $scope.body);
    //}
    var user = $("#currentUser").text();
    $("#sendMsg")
        .click(function() {
            //.sendMsg = function (user, to, subject, body) {
            viewModelHelper.apiPost("api/Messages/PutMsg?id=" +
                user +
                "&to=" +
                $scope.todisplay +
                "&title=" +
                $scope.subject +
                "&body=" +
                $scope.body,
                null,
                function(result) {
                    $scope.messages = result.data;
                });
        });

    //var loadOrderDetail = function (orderId, orderDetailId) {
    //    viewModelHelper.apiGet('api/order/detail/' + orderId + '/' + orderDetailId, null,
    //        function (result) {
    //            $scope.orderDetail = result.data;
    //        });
    //}

    //initialize();
});
