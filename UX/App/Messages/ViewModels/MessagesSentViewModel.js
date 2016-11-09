messagesModule.controller("messagesSentViewModel", function ($scope, messagesService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.messagesService = messagesService;
    
    var initialize = function () {
        
    }
    
    initialize();
});
