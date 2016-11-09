messagesModule.controller("messagesViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;

    var initialize = function () {
        $scope.refreshMessages($routeParams.msgId);
    }

    $scope.refreshMessages = function (msgId) {
        viewModelHelper.apiGet('api/Messages/GetMsg' + msgId, null,
            function (result) {
                messagesService.msgId = msgId;
                $scope.messages = result.data;
            });
    }
    
    initialize();
});
