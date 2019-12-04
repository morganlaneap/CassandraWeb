cassandraWeb.service("ConnectionService", function($http) {
  this.getConnections = function() {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/GetConnections"
    });
  };
  this.newConnection = function(formData) {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/NewConnection",
      params: formData
    });
  };
  this.deleteConnection = function(id) {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/DeleteConnection",
      params: { // TODO: work out a better way to post the data
        connectionId: id
      }
    });
  };
});
