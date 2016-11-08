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
            method: "GET",
            params: { id: email }
        }).then(function (response) {
            msgs = response.messages;
            //console.log(msgs);
            //console.log(response.data);
            $scope.messages = response.data;
        }), function error(response) {
            console.log(response);
        };
    }
);


app.controller('myCtrl', function ($scope, $http) {
    $scope.firstname = "John";
    $scope.lastname = "Doe";

    $("#sendMsg").click(function () {
        console.log("first");

        console.log($scope.firstname + " " + $scope.lastname);
        console.log($("#msgList").text());

        var msg = {
            Created: new Date(),
            Title: "Test Title",
            Body: "Test Body",
            FromDisplay: $scope.firstname + " " + $scope.lastname,
            ToDisplay: "admin"
        }

        console.log(msg);
        
        $http({
            url: "/api/Messages/SendMsg",
            method: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(msg)
            //params: {message: msg }
        }).then(function (response) {
            console.log(response.data);
            //msgs = response.messages;
            //console.log(msgs);
            //console.log(response.data);
            //$scope.messages = response.data;
        }), function error(response) {
            console.log(response);
        };
    });
});

$scope.send = function ($scope) {
    console.log($scope.messages.ToDisplay);
    console.log($scope.messages.FromDisplay);
    console.log($scope.messages.Created);
};