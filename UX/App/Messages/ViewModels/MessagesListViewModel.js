messagesModule.controller("messagesListViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;

    var initialize = function () {
        $scope.refreshMessages();
    }
    
    $scope.refreshMessages = function () {
        var user = $("#currentUser").text();
        viewModelHelper.apiGet("api/Messages/GetMsgs?id=" + user, null,
            function (result) {
                $scope.messages = result.data;
            });
    }

    //$scope.showMessages = function (msg) {
    //    $scope.flags.shownFromList = true;
    //    viewModelHelper.navigateTo("messages/show" + msg.ToUser);
    //}

    initialize();
});
