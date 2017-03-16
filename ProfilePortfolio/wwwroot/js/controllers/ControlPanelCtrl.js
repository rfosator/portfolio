angular.module('profiler').controller('controlPanelCtrl', ['$scope', function ($scope) {
    var ctrl = this;

    var _skill = {
        name: '', level: {}, category: {}
    };

    var _categories = [{
        value: 1,
        name: "Programming Languages"
    }, {
        value: 2,
        name: "Framework"
        }];

    var _levels = [{
        value: 1, name: "Basic"
    }, {
        value: 2, name: "Intermediate"
    }, {
        value: 3, name: "Advanced"
    }];

    var _skills = [];

    ctrl.skill = _skill;
    ctrl.skills = _skills;
    ctrl.categories = _categories;
    ctrl.levels = _levels;

    ctrl.attach = function () {
        _skills.push({ name: _skill.name, level: _skill.level, category: _skill.category });
        _skill.name = '';        
    };


}]);