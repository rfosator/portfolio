angular.module('profiler')
    .config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                    templateUrl: 'js/views/inicio.html'
                });
        }
    ]);  