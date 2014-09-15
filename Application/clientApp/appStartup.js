var app = angular.module('INAB', ['ngRoute', 'ngGrid', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap']);

app.config(function ($routeProvider) {

    $routeProvider.when("/dashboard", {
        controller: "dashboardController",
        templateUrl: "/Application/clientApp/views/dashboard.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/Application/clientApp/views/Login.html"
    });

    $routeProvider.when("/register", {
        controller: "registerController",
        templateUrl: "/Application/clientApp/views/register.html"
    });

    $routeProvider.when("/profile", {
        controller: "profileController",
        templateUrl: "/Application/clientApp/views/profile.html"
    });

    $routeProvider.when("/accounts", {
        controller: "accountsController",
        templateUrl: "/Application/clientApp/views/accounts.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

