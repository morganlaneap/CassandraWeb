cassandraWeb.service("ConnectionService", function($http) {
  this.getConnections = function() {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/GetConnections"
    });
  };
  this.newConnection = function(formData) {
    console.log(formData);
    return $http({
      method: "POST",
      url: API_URL() + "Connection/NewConnection",
      data: formData
    });
  };
  this.deleteConnection = function(id) {
    return $http({
      method: "POST",
      url: API_URL() + "Connection/DeleteConnection",
      params: {
        connectionId: id
      }
    });
  };
});
