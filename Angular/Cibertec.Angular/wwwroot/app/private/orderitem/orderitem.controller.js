﻿(function () {
    'use strict';
    angular.module('app')
        .controller('orderitemController', orderitemController);
    orderitemController.$inject = ['dataService', 'configService',
        '$state', '$scope'];
    function orderitemController(dataService, configService, $state,
        $scope) {
        var apiUrl = configService.getApiUrl();
        var vm = this;

        //Propiedades
        vm.orderitem = {};
        vm.orderitemList = [];
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;
        vm.modalTitle = '';
        vm.showCreate = false;
        vm.totalRecords = 0;
        vm.currentPage = 1;
        vm.maxSize = 10;
        vm.itemsPerPage = 30;

        vm.showDelete = false;
        //Funciones
        vm.getOrderItem = getOrderItem;
        vm.create = create;
        vm.edit = edit;
        vm.delete = orderitemDelete;
        vm.pageChanged = pageChanged;
        vm.closeModal = closeModal;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            configurePagination()
        }
            //In case mobile just show 5 pages
            var widthScreen = (window.innerWidth > 0) ?
                window.innerWidth : screen.width;
            if (widthScreen < 420) vm.maxSize = 5;
            totalRecords();
        }
            getPageRecords(vm.currentPage);
        }


            dataService.getData(apiUrl + '/orderitem/count')
                .then(function (result) {
                    vm.totalRecords = result.data;
                    getPageRecords(vm.currentPage);
                }
                , function (error) {
                    console.log(error);
                });
        }
            dataService.getData(apiUrl + '/orderitem/list/' + page + '/' + vm.itemsPerPage)
                .then(function (result) {
                    vm.orderitemList = result.data;
                },
                function (error) {
                    vm.orderitemList = [];
                    console.log(error);
                });
        }


            vm.orderitem = null;
            dataService.getData(apiUrl + '/orderitem/' + id)
                .then(function (result) {
                    vm.orderitem = result.data;
                },
                function (error) {
                    vm.orderitem = null;
                    console.log(error);
                });
        }
            if (!vm.orderitem) return;
            dataService.putData(apiUrl + '/orderitem', vm.orderitem)
                .then(function (result) {
                    vm.orderitem = {};
                    closeModal();
                },
                function (error) {
                    vm.orderitem = {};
                    console.log(error);
                });
        }


            if (!vm.orderitem) return;
            dataService.postData(apiUrl + '/orderitem', vm.orderitem)
                .then(function (result) {
                    getOrderItem(result.data);
                    detail();
                    getPageRecords(1);
                    vm.currentPage = 1;
                    vm.showCreate = true;
                },
                function (error) {
                    console.log(error);
                    closeModal();
                });
        }
            dataService.deleteData(apiUrl + '/orderitem/' + vm.orderitem.id)
                .then(function (result) {
                    getPageRecords(vm.currentPage);
                    closeModal();
                },
                function (error) {
                    console.log(error);
                });
        }


            vm.orderitem = {};
            vm.modalTitle = 'Create OrderItem';
            vm.modalButtonTitle = 'Create';
            vm.readOnly = false;
            vm.modalFunction = createOrderItem;
            vm.isDelete = false;
        }
            vm.showCreate = false;
            vm.modalTitle = 'Edit OrderItem';
            vm.modalButtonTitle = 'Update';
            vm.readOnly = false;
            vm.modalFunction = updateOrderItem;
            vm.isDelete = false;
        }
            vm.modalTitle = 'The New OrderItem Created';
            vm.modalButtonTitle = '';
            vm.readOnly = true;
            vm.modalFunction = null;
            vm.isDelete = false;
            vm.showCreate = false;
            vm.showDelete = true; //
            vm.modalTitle = 'Delete OrderItem';
            vm.modalButtonTitle = 'Delete';
            vm.readOnly = false;
            vm.modalFunction = deleteOrderItem;
            vm.isDelete = true;
        }
        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }
})();