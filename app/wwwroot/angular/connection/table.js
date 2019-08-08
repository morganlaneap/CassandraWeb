cassandraWeb.controller('connectionTableController', function ($scope, CassandraService, ngToast, $stateParams) {
    $scope.table = null;
    $scope.newColumn = {
        columnName: '',
        dataType: ''
    };
    
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

    $scope.addTableColumn = function () {
        // TODO: add some validation here
        CassandraService.addTableColumn($scope.connectionId, $scope.keyspaceName, $scope.tableName, $scope.newColumn).then(function (success) {
            $scope.getTableSchema();
            ngToast.create(`Column ${$scope.newColumn.columnName} has been added.`);
        }, function (error) {
            // TODO: add something here
        });
    };

    $scope.deleteTableColumn = function (columnToDelete) {
        CassandraService.deleteTableColumn($scope.connectionId, $scope.keyspaceName, $scope.tableName, columnToDelete).then(function (success) {
            $scope.getTableSchema();
            ngToast.create(`Column ${columnToDelete} has been added.`);
        }, function (error) {
            // TODO: add something here
        });
    };
    
    $scope.init();
});