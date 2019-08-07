cassandraWeb.controller('connectionTableController', function ($scope, CassandraService, ngToast, $stateParams) {
    $scope.table = null;
    
    $scope.init = function () {
        $scope.connectionId = $stateParams.connectionId;
        $scope.keyspaceName = $stateParams.keyspaceName;
        $scope.tableName = $stateParams.tableName;
        $scope.getTableSchema();
    };

    $scope.getTableSchema = function () {
        CassandraService.getTableSchema($scope.connectionId, $scope.keyspaceName, $scope.tableName).then(function (success) {
            $scope.table = success.data;
        }, function (error) {
            // TODO: add something here
        });
    };
    
    $scope.init();
});