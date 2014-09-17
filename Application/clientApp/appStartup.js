var app = angular.module('INAB', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap', 'smart-table']);

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

    $routeProvider.when("/household", {
        controller: "householdController",
        templateUrl: "/Application/clientApp/views/household.html"
    });

    $routeProvider.when("/accounts/:accountId/transactions", {
        controller: "transactionsController",
        templateUrl: "/Application/clientApp/views/transactions.html"
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

