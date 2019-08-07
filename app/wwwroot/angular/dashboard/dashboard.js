cassandraWeb.controller('dashboardController', function ($scope, ConnectionService) {
    const newConnectionFormSchema = {
        connectionId: null,
        connectionName: '',
        contactPoint: '',
        port: 0,
        username: '',
        password: ''
    }
    
    $scope.connectionList = [];
    $scope.newConnectionForm = newConnectionFormSchema;
    
    $scope.init = function () {
        $scope.getConnections();
    };

    $scope.getConnections = function () {
        ConnectionService.getConnections().then(function (success) {
            $scope.connectionList = success.data;
        }, function (error) {
            // TODO: add something handle this here
        });
    };

    $scope.newConnectionSubmit = function () {
        ConnectionService.newConnection($scope.newConnectionForm).then(function (success) {
            $scope.getConnections();
            jQuery('#newConnectionModal').modal('hide');
        }, function (error) {
            // TODO: add something handle this here
        });
    };

    $scope.deleteConnection = function (connectionId) {
        ConnectionService.deleteConnection(connectionId).then(function (success) {
            $scope.getConnections();            
        }, function (error) {
            // TODO: add something handle this here
        });
    };

    $scope.init();
});