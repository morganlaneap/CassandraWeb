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
  };
  this.addTableColumn = function(connectionId, keyspaceName, tableName, newColumn) {
    return $http({
      method: "POST",
      url: API_URL() + "Cassandra/AddTableColumn",
      params: {
        connectionId: connectionId,
        keyspaceName: keyspaceName,
        tableName: tableName,
        columnName: newColumn.columnName,
        dataType: newColumn.dataType
      }
    });
  };
  this.deleteTableColumn = function(connectionId, keyspaceName, tableName, columnName) {
    return $http({
      method: "POST",
      url: API_URL() + "Cassandra/DeleteTableColumn",
      params: {
        connectionId: connectionId,
        keyspaceName: keyspaceName,
        tableName: tableName,
        columnName: columnName
      }
    });
  };
});
