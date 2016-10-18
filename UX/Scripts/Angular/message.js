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

        $scope.send = function () {
            console.log($scope.messages[0].ToDisplay);
            console.log($scope.messages[0].FromDisplay);
            console.log($scope.messages[0].Created);
        };
    }
);


app.controller('myCtrl', function ($scope) {
    $scope.firstname = "John";
    $scope.lastname = "Doe";

    $("#sendMsg").click(function () {
        console.log($scope.firstname + " " + $scope.lastname);
        console.log($("#msgList").text());
    });
});
