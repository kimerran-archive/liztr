
var liztr = angular.module('LiztrApp', ['LiztrControllers', 'LiztrServices', 'ngRoute']);

liztr.run(function ($rootScope, EventFactory, $location, $routeParams) {

    $rootScope.access = EventFactory.get({ Id: 0 });


    // fake login
    $rootScope.access = true;

    $rootScope.$on("$locationChangeStart", function (e, next, current) {

        if ($rootScope.access.allowed == false) {
            e.preventDefault();
        } else { //user is loggedin

        }
    });
});



window.Liztr = liztr;