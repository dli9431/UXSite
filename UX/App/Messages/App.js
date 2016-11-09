
var messagesModule = angular.module("messages", ["common"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when("/messages", { templateUrl: "/App/Messages/Views/MessagesHomeView.html", controller: "messagesHomeViewModel" });
        $routeProvider.when('/messages/list', { templateUrl: '/App/Messages/Views/MessagesListView.html', controller: 'messagesListViewModel' });
        $routeProvider.when('/messages/send', { templateUrl: '/App/Messages/Views/MessagesSendView.html', controller: 'messagesSendViewModel' });
        
        //$routeProvider.when('/order/detail/:orderId/:orderDetailId', { templateUrl: '/App/Order/Views/OrderDetailView.html', controller: 'orderDetailViewModel' });
        $routeProvider.otherwise({ redirectTo: "/messages" });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

messagesModule.factory("messagesService", function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.messagesService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var messagesService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.orderId = 0;

        return this;
    };
    myApp.messagesService = messagesService;
}(window.MyApp));
