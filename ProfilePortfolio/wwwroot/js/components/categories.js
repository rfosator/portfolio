angular.module('profiler').component('categories', {
    templateUrl: "js/views/templates/categories.html",
    controller: ['$http','$scope', function ($http, $scope) {
        var ctrl = this;

        ctrl.items = [];
        ctrl.loading = false;

        ctrl.attach = function () {
            var content = {
                name: ctrl.name, enabled: true
            };

            $http.post("api/Categories", content).then(function () {
                _getAll();
            });
        };

        ctrl.update = function (selected) {
            ctrl.loading = true;
            $http.put("api/Categories/" + selected.id, selected).then(function () {
                ctrl.loading = false;
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
