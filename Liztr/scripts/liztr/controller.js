var LiztrControllers = angular.module('LiztrControllers', []);

// EventCtrl
LiztrControllers.controller('EventCtrl', ['$scope', 'EventFactory','UserFactory', '$routeParams','$location',
    function ($scope, EventFactory, UserFactory, $routeParams, $location) {

        $scope.ownedEvents = [];
        $scope.event = {};

        $scope.$on('$locationChangeStart', function (e, url) {
          
              
        });

       

        $scope.loadAllEvents = function () {
            $scope.ownedEvents = EventFactory.query();
        };

        $scope.loadEdit = function () {
            console.log("loadEdit");
            EventFactory.get({ Id: $routeParams.EventId }, function (res) {

                $scope.event =  res.r ;

                
            });
         
        };

        
        $scope.addEvent = function () {
            $scope.event.Id = 0;
            var res = EventFactory.save($scope.event);
            console.log("%O", res);
        };

        $scope.editEvent = function () {
            EventFactory.save($scope.event, function () {
                $location.path('/events/all');
            });
          
        };


        $scope.test = function () {

            console.log("%O", $scope.ownedEvents);
        };

    }]);

// Event registration controller
LiztrControllers.controller('EventRegCtrl', ['$scope', 'EventFactory', 'UserFactory', 'RegistrationFactory', '$routeParams', '$location',
    function ($scope,EventFactory,UserFactory,RegistrationFactory, $routeParams,$location) {
       
        $scope.event = {};
        $scope.new_registration = {};
        $scope.registrations = [];
        $scope.eventid = 0;
        $scope.selected_tab = 1;

        $scope.init = function () {
            $scope.eventid = $routeParams.EventId;

            EventFactory.get({ Id: $routeParams.EventId }, function (res) {
                $scope.event = res.r;



                $scope.registrations = res.r.Registrations;
            });


        }

        $scope.addRegistration = function () {
            $scope.new_registration.EventId = $scope.event.Id;
            RegistrationFactory.save($scope.new_registration);
            $scope.registrations.push($scope.new_registration);
            $scope.new_registration = {};
        }

        $scope.$on('$viewContentLoaded', function () {

           
        });
        
    }]);
