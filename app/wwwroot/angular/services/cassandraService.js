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
  this.getTablesInKeyspace = function(connectionId, keyspaceName) {
    return $http({
      method: "POST",
      url: API_URL() + "Cassandra/GetTablesInKeyspace",
      params: {
        connectionId: connectionId,
        keyspaceName: keyspaceName
      }
    });
  };
  this.getTableSchema = function(connectionId, keyspaceName, tableName) {
    return $http({
      method: "POST",
      url: API_URL() + "Cassandra/GetTableSchema",
      params: {
        connectionId: connectionId,
        keyspaceName: keyspaceName,
        tableName: tableName
      }
    });
  }
});
