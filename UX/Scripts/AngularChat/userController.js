(function () {
    'use strict';

    var controllerId = 'userController';

    angular.module('UsersApp').controller(controllerId,
        ['$scope', 'userFactory', userController]);

    function userController($scope, userFactory) {
        $scope.users = [];

        userFactory.getUser().success(function (data) {
            $scope.user = data;
        }).error(function (error) {
            console.log(error);
        });
    }
})();
