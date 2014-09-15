'use strict';
app.controller('profileController', ['$scope', '$location', 'authService', '$timeout', '$http', function ($scope, $location, authService, $timeout, $http) {

    //Scope variables
    $scope.profileData = {};

    $scope.getProfileData = function () {
        $http.get('/api/Profile/GetProfileData')
        .success(function (data, status, headers, config) {
            $scope.profileData = data;
            console.log(data);
        })
        
    }

    $scope.submitProfileChanges = function () {

        $http.post('/api/SubmitProfileChanges', {profileData : $scope.profileData})
        .success(function (data, status, headers, config) {
            $scope.getProfileData();
        })
    }

    $scope.getProfileData();

}]);