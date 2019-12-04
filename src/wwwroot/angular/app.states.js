cassandraWeb.config(function($stateProvider) {
  $stateProvider.state("dashboard", {
    url: "",
    views: {
      content: {
        templateUrl: "/angular/dashboard/dashboard.html",
        controller: "dashboardController"
      }
    }
  });

  $stateProvider.state("connection", {
    url: "/connection/:connectionId",
    views: {
      content: {
        templateUrl: "/angular/connection/connection.html",
        controller: "connectionController"
      }
    }
  });

  $stateProvider.state("connectionKeyspaceTable", {
    url: "/connection/:connectionId/keyspace/:keyspaceName/table/:tableName",
    views: {
      content: {
        templateUrl: "/angular/connection/table/table.html",
        controller: "connectionTableController"
      }
    }
  });

  $stateProvider.state("connectionKeyspaceNewTable", {
    url: "/connection/:connectionId/keyspace/:keyspaceName/new-table",
    views: {
      content: {
        templateUrl: "/angular/connection/newTable/newTable.html",
        controller: "connectionNewTableController"
      }
    }
  });
});
