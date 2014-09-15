'use strict';
app.controller('accountsController', ['$scope', '$location', 'authService', '$timeout', '$http', function ($scope, $location, authService, $timeout, $http) {

    //Scope variables
    $scope.recentTransactions = {};
    $scope.accountOverviews = [];
    $scope.newAccount = {
        name: '',
        initialBalance: null
    };
    $scope.showAddAccount = false;
    
    $scope.getAccountOverviews = function () {
        $http.get('/api/Accounts/GetAccountOverviews')
        .success(function (data, status, headers, config) {
            $scope.accountOverviews = data;
        })
        
    }

    $scope.getTransactions = function (accountId) {
        var transactionList = [];

        $http.get('/api/Accounts/GetRecentTransactionsForAccount', { params: { AccountId: accountId } })
        .success(function (data, status, headers, config) {
            for(var i=0; i < data.length; i++)
            {
                transactionList.push(data[i]);
            }
        })

        return transactionList;
    }

    //Make this a directive!
    $scope.postNewAccount = function (item, event) {
        var dataObject = {
            name: $scope.newAccount.name,
            initialBalance: $scope.newAccount.initialBalance,
        };

        $http.post("/api/Accounts/PostNewAccount", dataObject, {})
        .success(function (dataFromServer, status, headers, config) {
            console.log(dataFromServer);
            //refresh account list to reflect changes
            getAccountOverviews();
        })
        .error(function (data, status, headers, config) {
            alert("Submitting form failed!");
        });
    }

    $scope.toggleAccountTransactions = function (accountId, forceRefresh) {

        forceRefresh = typeof forceRefresh !== 'undefined' ? forceRefresh : false;

        if (!$scope.recentTransactions[accountId] || forceRefresh == true) {
            $scope.recentTransactions[accountId] = {
                transactions : $scope.getTransactions(accountId),
                visible : true
            }
        }
        else
            $scope.recentTransactions[accountId].visible = $scope.recentTransactions[accountId].visible === false ? true : false;
    }

    //$scope.getTransactions();
    $scope.getAccountOverviews();

}]);