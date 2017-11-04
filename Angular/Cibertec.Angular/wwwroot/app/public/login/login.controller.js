(function () {
    'use strict';
    angular.module('app').controller('loginController', loginController);

    loginController.$inject = ['$http', 'authenticationService', 'configService', '$state'];

    function loginController($http, authenticationService, configService, $state) {
        var vm = this;
        vm.user = {};
        vm.title = 'login';
        vm.login = login;

        init();

        function init() {
            if (configService.setLogin()) $state.go("Home");
            authenticationService.logout();
        }
        function login() {
            authenticationService.login(vm.user);
        }

    }
})();