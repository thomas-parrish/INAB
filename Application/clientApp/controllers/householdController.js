'use strict';
app.controller('householdController', ['$scope', '$location', 'authService', '$timeout', '$http', function ($scope, $location, authService, $timeout, $http) {

    //Scope variables
    $scope.householdMembers = {};
    $scope.confirmLeave = false;
    $scope.inviteEmail = "";

    $scope.getProfileData = function () {
        $http.get('/api/Household/GetProfileData')
        .success(function (data, status, headers, config) {
            if (data != null)
                $scope.householdMembers = data;
            else
                //Handle the case when user is not in a household
                var x = 1;
                

            console.log(data);
        })
        
    }

    $scope.sendInvite = function () {
        alert("Sending an invite to " + $scope.inviteEmail + "!");
    }

    $scope.leaveHousehold = function () {
        alert("Oh no, you left the household!");
    }

    $scope.getProfileData();

}]);