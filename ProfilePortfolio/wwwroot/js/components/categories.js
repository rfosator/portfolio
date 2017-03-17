angular.module('profiler').component('categories', {
    templateUrl: "js/views/templates/categories.html",
    controller: ['$http','$scope', function ($http, $scope) {
        var ctrl = this;

        ctrl.items = [];

        ctrl.attach = function () {
            var content = {
                name: ctrl.name, enabled: true
            };

            $http.post("api/Categories", content).then(function () {
                _getAll();
            });
        };

        ctrl.update = function (c) {
            $http.put("api/Categories/" + c.id, c).then(function () {
                console.log('updated');
            });
        };

        var _getAll = function () {
            $http.get("api/Categories").then(function (response) {
                ctrl.items = response.data;
            });
        };

        this.$onInit = function () {
            _getAll();
        };
        
    }],
    controllerAs: "categories"
});
