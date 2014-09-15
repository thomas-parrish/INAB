'use strict';
app.controller('IndexController', ['$scope', '$location', 'authService', '$timeout', function ($scope, $location, authService, $timeout) {

    //Scope variables
    $scope.authentication = authService.authentication;
    $scope.name = authService.authentication.name;
    console.log($scope.authentication);
    //ng-click functions
    function onLoad() {
        if ($scope.authentication.isAuth)
            $location.path('/dashboard');
        else
            $location.path('/login');
    }

    $scope.logout = function () {
        authService.logOut();
        $location.path('/login');
    }

    onLoad();
}]);
