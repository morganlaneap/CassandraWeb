cassandraWeb.service("ConnectionService", function($http) {
  this.getConnections = function() {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/GetConnections"
    });
  };
});
