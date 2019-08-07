cassandraWeb.service("CassandraService", function($http) {
  this.getKeyspaces = function(connectionId) {
    return $http({
      method: "POST",
      url: API_URL() + "Cassandra/GetKeyspaces",
      params: {
        connectionId: connectionId
      }
    });
  };
});
