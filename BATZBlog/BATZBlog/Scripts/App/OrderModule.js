var myApp = angular.module("ordersApp", [])

myApp.factory('ordersFactory',
    function ($http) {
        var webAPIProvider = {};

        var url = '/api/order';

        webAPIProvider.getOrders = function () {
            return $http.get(url);       

        };           
        webAPIProvider.changeStatus = function (orderId) {
            return $http.post(url + '/'+ orderId);
        };

        return webAPIProvider;
    });


    myApp.filter('sumOfValue', function () {
        return function (data, key) {
            if (angular.isUndefined(data) && angular.isUndefined(key))
                return 0;
            var sum = 0;
            angular.forEach(data, function (value) {
                sum = sum + parseInt(value[key]);
            });
            return sum;
        }
    }).filter('totalSumPriceQty', function () {
        return function (data, key1, key2) {
            if (angular.isUndefined(data) && angular.isUndefined(key1) && angular.isUndefined(key2))
                return 0;
            var sum = 0;
            angular.forEach(data, function (value) {
                sum = sum + (parseInt(value[key1]) * parseInt(value[key2]));
            });
            return sum;
        }
    }).controller('ordersController',
        function ($scope, $window, ordersFactory) {
        ordersFactory.getOrders()
            .success(function (data) {
                $scope.orders = data;

            });
        $scope.changeit = function (orderId) {
            ordersFactory.changeStatus(orderId)
                .success(function (data) {
                    
                    ordersFactory.getOrders()
     .              success(function (data) {
                     $scope.orders = data;

                        });
                    //$window.location.reload();
                });
        };

    });
