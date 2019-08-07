cassandraWeb.controller('dashboardController', function ($scope, ConnectionService) {
    $scope.connectionList = [];
    
    $scope.init = function () {
        ConnectionService.getConnections().then(function (success) {
            $scope.connectionList = success.data;
        }, function (error) {
            // TODO: add something handle this here
        });
    };

    $scope.init();
});