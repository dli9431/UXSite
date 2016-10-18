function GetMessagesUser(email) {
    var app = angular.module('msg-app', []);
    app.controller('MsgController',
        function($scope, $http) {
            console.log(email);
            var msgs = [];
            //get list of messages
            //$.getJSON('/api/Messages/GetMsgs',
            //    function(response) {
            //        msgs = response.messages;
            //    });
            $http({
                    url: '/api/Messages/GetMsgs',
                    method: 'GET',
                    params: { id: email }
                })
                .then(function(response) {
                    //msgs = response.messages;
                    //console.log(msgs);
                    //console.log(response);
                    //$("#messageList").append(response);
                    $scope.messages = response.data;

                }), function error(response) {
                console.log(response);
            };


    //$http.get('/api/Message/GetMsgs?displayName=').then(function (response) {
    //    $scope.messages = response.data;
    //});

    });
};


//(function () {
//    var app = angular.module('msg-app', []);
//    app.controller('MsgController', function ($scope, $http) {
//        //var user = $("#currentUser").val();
//        //console.log(user);
//        //var msgDict =
//        //get list of messages
//        $http.get('/api/Message/GetMsgs?displayName=').then(function(response) {
//            $scope.messages = response.data;
//        });
        
        
//    });
//}());