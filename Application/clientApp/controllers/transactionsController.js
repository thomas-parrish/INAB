'use strict';
app.controller('transactionsController',
    ['$scope', '$location', 'authService', '$timeout', '$http', '$routeParams', 
        function ($scope, $location, authService, $timeout, $http, $routeParams) {
        //Scope variables
        $scope.accountId = $routeParams.accountId;
        $scope.transactions = [];
        $scope.categories = [];
        $scope.newCategory = {};

       

        $scope.getAllTransactions = function () {
            $http.get('/api/Transactions/GetAllTransactions', { params: { AccountId: $scope.accountId } })
            .success(function (data, status, headers, config) {
                $scope.transactions = data;
            })
        }

        $scope.getCategories = function () {
            $http.get('/api/Transactions/GetCategories')
            .success(function (data, status, headers, config) {
                $scope.categories = data;
                window.cat = $scope.categories;
            })
        }

        $scope.testAdd = function () {
            $scope.transactions.push({
                accountId: 12,
                amount: 700,
                amountReconciled: null,
                authorizedBy: 1,
                categoryId: 1,
                createdOn: "2014-09-11T16:48:38.6+00:00",
                description: "Account Creation",
                id: 22,
                isDeposit: true,
                isReconciled: true,
                updatedOn: null
        });
        }

        $scope.submitCategory = function () {
            if ($scope.newCategory != null)
                $http.post('/api/Transactions/SubmitCategory', { entry: $scope.newCategory })
                .success(function () {
                    $scope.newCategory = {};
                    $scope.getCategories();
                });
        }


        $scope.getAllTransactions();
        $scope.getCategories();

            //$('#transactionTable').dataTable({ aaData: $scope.transactions });
        $scope.displayTransactions = [].concat($scope.transactions);
    }
]);