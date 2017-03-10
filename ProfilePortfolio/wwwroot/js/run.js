angular.module('profiler', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                    templateUrl: 'js/views/inicio.html'
                });
        }
    ]);  