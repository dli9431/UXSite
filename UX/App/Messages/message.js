var app = angular.module("msg-app", []);
app.controller("MsgController",
    function ($scope, $http) {
        //$scope.send = function () {
        //    console.log($scope.messages);
        //};
        var email = $("#currentUser").text();
        console.log(email);
        var msgs = [];
        //get list of messages
        
        $http({
            url: "/api/Messages/GetMsgs",
            method: "GET"
        }).then(function (response) {
            msgs = response.messages;
            //console.log(msgs);
            //console.log(response.data);
            $scope.messages = response.data;
            console.log($scope.messages);
        }), function error(response) {
            console.log(response);
        };

        //$scope.send = function () {
        //    console.log($scope.messages[0].ToDisplay);
        //    console.log($scope.messages[0].FromDisplay);
        //    console.log($scope.messages[0].Created);
        //};
    }
);

app.controller('sendMsg', function ($scope, $http) {
    //$scope.firstname = "John";
    //$scope.lastname = "Doe";

    $("#sendMsg").click(function () {
        var to = $scope.todisplay;
        var subject = $scope.subject;
        var body = $scope.body;
        var from = $("#currentUser").text();
        
        //var message = { Created: "1/1/2016", ToDisplay: to, FromDisplay: "admin", Title: subject, Body: body };

        $http({
            url: "/api/Messages/PutMsg",
            method: "PUT",
            params: { id: from, to: to, title: subject, body: body }
            //params: { message: message }
        }).then(function (response) {
            //msgs = response.messages;
            //console.log(msgs);
            //console.log(response.data);
            //$scope.messages = response.data;
            //console.log($scope.messages);
            console.log("ok");

        }), function error(response) {
            console.log(response);
        };

        //console.log($scope.firstname + " " + $scope.lastname);
        //console.log($("#msgList").text());
    });
});
