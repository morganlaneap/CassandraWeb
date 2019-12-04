cassandraWeb.factory("errorInterceptor", function($q) {
  var preventFurtherRequests = false;

  return {
    request: function(config) {
      if (preventFurtherRequests) {
        return;
      }

      return config || $q.when(config);
    },
    requestError: function(request) {
      return $q.reject(request);
    },
    response: function(response) {
      return response || $q.when(response);
    },
    responseError: function(response) {
      if (response && response.status === 401) {
        // log
      }
      if (response && response.status === 500) {
        preventFurtherRequests = true;
      }

      return $q.reject(response);
    }
  };
});

cassandraWeb.config(function($httpProvider) {
  $httpProvider.interceptors.push("errorInterceptor");
});
