(function () {
    'use strict';
    
    var serviceId = 'userFactory';
    
    angular.module('UsersApp').factory(serviceId,
        ['$http', userFactory]);

    function userFactory($http) {

        function getUser() {
            return $http.get('/api/Users/GetUsers');
        }
        var service = {
            getUser: getUser
        };
        return service;
    }
})();