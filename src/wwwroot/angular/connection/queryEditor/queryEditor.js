cassandraWeb.controller("connectionQueryEditorController", function(
  $scope,
  CassandraService,
  ngToast,
  $stateParams
) {
  $scope.table = null;

  $scope.init = function() {
    $scope.connectionId = $stateParams.connectionId;
    $scope.keyspaceName = $stateParams.keyspaceName;
    $scope.tableName = $stateParams.tableName;
  };

  $scope.init();
});
