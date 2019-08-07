cassandraWeb.controller('connectionController', function ($scope, CassandraService, ngToast, $stateParams) {
    $scope.keyspaces = [];
    $scope.selectedKeyspace = null;

    $scope.init = function () {
        $scope.connectionId = $stateParams.connectionId;
        $scope.getKeyspaces();
    };

    $scope.getKeyspaces = function () {
        CassandraService.getKeyspaces($scope.connectionId).then(function (success) {
            $scope.keyspaces = success.data;
        }, function (error) {
            // TODO: add something here
        });
    };

    $scope.selectKeyspace = function (keyspace) {
        $scope.selectedKeyspace = keyspace;
        CassandraService.getTablesInKeyspace($scope.connectionId, keyspace.keyspaceName).then(function (success) {
            $scope.selectedKeyspace.tables = success.data;
        }, function (error) {
            // TODO: add something here
        });
    };

    $scope.init();
});