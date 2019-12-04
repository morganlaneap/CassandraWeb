cassandraWeb.controller("connectionQueryEditorController", function(
  $scope,
  CassandraService,
  ngToast,
  $stateParams
) {
  $scope.queryText = "";
  $scope.queryResults = null;

  $scope.init = function() {
    $scope.connectionId = $stateParams.connectionId;
  };

  $scope.executeQuery = function() {
    CassandraService.executeQuery($scope.connectionId, $scope.queryText).then(
      function(success) {
        ngToast.create(`Query executed successfully.`);
        $scope.queryResults = success.data;
        console.log(success);
      },
      function(error) {
        alert("Error running query: " + error.data);
      }
    );
  };

  $scope.init();
});
