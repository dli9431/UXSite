
var customerModule = angular.module('messages', ['common']);

customerModule.config(function ($routeProvider,
                                $locationProvider) {
    $routeProvider.when('/messages', {
        templateUrl: '/App/Messages/Views/MessagesHomeView.html',
        controller: 'messagesHomeViewModel'
    });
    $routeProvider.when('/messages/list', {
        templateUrl: '/App/Messages/Views/MessagesListView.html',
        controller: 'messagesListViewModel'
    });
    //$routeProvider.when('/messages/show/:Id', {
    //    templateUrl: '/App/Customer/Views/CustomerView.html',
    //    controller: 'customerViewModel'
    //});
    $routeProvider.otherwise({
        redirectTo: '/messages'
    });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

customerModule.factory('customerService',
    function ($http, $location, viewModelHelper) {
        return MyApp.customerService($http,
            $location, viewModelHelper);
    });

(function (myApp) {
    var customerService = function ($http, $location,
        viewModelHelper) {

        var self = this;

        self.customerId = 0;

        return this;
    };
    myApp.customerService = customerService;
}(window.MyApp));
