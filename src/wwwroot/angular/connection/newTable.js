cassandraWeb.controller('connectionNewTableController', function ($scope, CassandraService, ngToast, $stateParams, $state) {
    $scope.newTable = {
        connectionId: null,
        keyspaceName: null,
        tableName: 'NewTable',
        columns: []
    };
    
    $scope.init = function () {
        $scope.connectionId = $stateParams.connectionId;
        $scope.keyspaceName = $stateParams.keyspaceName;

        $scope.newTable.connectionId = $scope.connectionId;
        $scope.newTable.keyspaceName = $scope.keyspaceName;
    };

    $scope.addTableColumn = function (newColumn) {
        $scope.newTable.columns.push(newColumn);
    };

    $scope.deleteTableColumn = function (columnName) {

    };

    $scope.createTable = function () {
        // TODO: add validation etc.
        CassandraService.createNewTable($scope.newTable).then(function (success) {
            ngToast.create(`Table ${$scope.newTable.tableName} has been created.`);
            $state.go(`connection({connectionId: ${$scope.connectionId}})`);
        }, function (error) {
            // TODO: add something here
        });
    };

    $scope.init();
});