cassandraWeb.config(function($stateProvider) {
    $stateProvider.state('dashboard', {
      name: 'dashboard',
      url: '',
      views: {
        'dashboard': {
          templateUrl: '/angular/dashboard/dashboard.html',
          controller: 'dashboardController',
        }
      }
    });
  });
  