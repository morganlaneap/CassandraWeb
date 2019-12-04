cassandraWeb.controller("dashboardController", function(
  $scope,
  ConnectionService,
  ngToast
) {
  $scope.connectionList = [];
  $scope.newConnectionForm = {
    username: "",
    password: ""
  };

  $scope.init = function() {
    $scope.getConnections();
    $scope.clearNewConnectionForm();
  };

  $scope.clearNewConnectionForm = function() {
    $scope.newConnectionForm = {
      connectionId: null,
      connectionName: "",
      contactPoint: "",
      port: 0,
      username: "",
      password: ""
    };
  };

  $scope.getConnections = function() {
    ConnectionService.getConnections().then(
      function(success) {
        $scope.connectionList = success.data;
      },
      function(error) {
        // TODO: add something handle this here
      }
    );
  };

  $scope.newConnectionSubmit = function() {
    ConnectionService.newConnection($scope.newConnectionForm).then(
      function(success) {
        $scope.getConnections();
        jQuery("#newConnectionModal").modal("hide");
        ngToast.create("Connection created!");
        $scope.clearNewConnectionForm();
      },
      function(error) {
        // TODO: add something handle this here
      }
    );
  };

  $scope.deleteConnection = function(connectionId) {
    ConnectionService.deleteConnection(connectionId).then(
      function(success) {
        $scope.getConnections();
        ngToast.create("Connection deleted!");
      },
      function(error) {
        // TODO: add something handle this here
      }
    );
  };

  $scope.init();
});
