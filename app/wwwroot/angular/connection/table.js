cassandraWeb.controller('connectionTableController', function ($scope, CassandraService, ngToast, $stateParams) {
    $scope.init = function () {
        $scope.connectionId = $stateParams.connectionId;
        $scope.keyspaceName = $stateParams.keyspaceName;
        $scope.tableName = $stateParams.tableName;
    };

    $scope.init();
});