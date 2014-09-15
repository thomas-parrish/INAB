'use strict';
app.controller('dashboardController', ['$scope', '$location', 'authService', '$timeout', '$http', function ($scope, $location, authService, $timeout, $http) {

    //Scope variables
    $scope.recentTransactions = [];
    $scope.accountOverviews = [];
    
    $scope.getAccountOverviews = function () {
        $http.get('/api/Dashboard/GetAccountOverviews')
        .success(function (data, status, headers, config) {
            $scope.accountOverviews = data;
        })
        
    }

    $scope.getTransactions = function () {

        $http.get('/api/Dashboard/GetRecentTransactions')
        .success(function (data, status, headers, config) {
            $scope.recentTransactions = data;
        })
    }

    $scope.getTransactions();
    $scope.getAccountOverviews();

}]);