var qaTestModule = angular.module("qatest", ["common"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when("/tests", { templateUrl: "/App/QaTest/Views/QaTestHomeView.html", controller: "qaTestHomeViewModel" });
        $routeProvider.when('/tests/list', { templateUrl: "/App/QaTest/Views/QaTestListView.html", controller: "qaTestListViewModel" });
        $routeProvider.otherwise({ redirectTo: "tests" });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

qaTestModule.factory("qaTestService", function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.qaTestService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var qaTestService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.productId = 0;

        return this;
    };
    myApp.qaTestService = qaTestService;
}(window.MyApp));
