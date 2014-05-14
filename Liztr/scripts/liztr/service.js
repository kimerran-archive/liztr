/*
    liztr/service.js

    Contains the followign angular.service - LiztrServices

*/
angular.module('LiztrServices', ['ngResource'])
  .factory('EventFactory', function ($resource) {
      return $resource('/api/event/:Id', { Id: '@Id' });
  })
  .factory('UserFactory', function ($resource) {
      return $resource('api/user/:Id', { Id: '@Id' });
  })
  .factory('RegistrationFactory', function ($resource) {
      return $resource('api/reg/:EventId', { EventId: '@EventId' });
  })

