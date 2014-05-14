Liztr.config(['$routeProvider',
    function ($routeProvider) {

        $routeProvider
            .when('/events/new', {
                templateUrl: 'partials/event/create',
                controller: 'EventCtrl'
            })
            .when('/events/:EventId/reg', {
                templateUrl: 'partials/event/reg',
                controller: 'EventRegCtrl'
            })
            .when('/events/:EventId/pre', {
                templateUrl: 'partials/event/pre',
                controller: 'EventRegCtrl'
            })
            .when('/events/:EventId/edit', {
                templateUrl: 'partials/event/edit',
                controller: 'EventCtrl'
            })
            .when('/events/all', {
                templateUrl: 'partials/event/all',
                controller: 'EventCtrl'
            })
            .when('/', {
                redirectTo: '/'
            })
            .otherwise({
                redirectTo: '/notfound.html'
            });
    }]);