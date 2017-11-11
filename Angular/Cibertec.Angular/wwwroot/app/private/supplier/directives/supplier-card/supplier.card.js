(function () {
    'use strict';
    angular.module('app')
        .directive('customerCard', customerCard);
    function customerCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                id: '@',
                companyName: '@',
                contactName: '@',
                contactTitle: '@',
                country: '@',
                phone: '@'
            },
            templateUrl: 'app/private/supplier/directives/supplier-card/supplier-card.html'

        };
    }
})();