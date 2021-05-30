(function () {
    'use strict';

    angular
        .module('App')
        .controller('CtrlTareas', CtrlTareas);

    /* Inyecto el servicio que cree en Main.js = mainService */
    CtrlTareas.$inject = ['$scope', 'mainService'];

    function CtrlTareas($scope, mS) {
        $scope.data = {};
        var urlBase = "";

        $scope.initialLoad = function () {
            $scope.tareas = [];
            mS.getData("GET", "Tarea/ListTarea").then(function (response) {
                if (response.code == "0") {
                    $scope.isNotify("error", response.message, response.messageTitle);
                } else if (response.code == "1") {
                    $scope.tareas = response.payload;
                }
            }, function (error) {
                $scope.isNotify("error", error.status, "Error");
            });
        }
        $scope.initialLoad();

        $scope.operationTarea = function () {
            if ($scope.data.operation === 0) {
                urlBase = "/Tarea/AddTarea";
            } else if ($scope.data.operation === 1) {
                urlBase = "/Tarea/UpdateTarea";
            } else if ($scope.data.operation === 2) {
                urlBase = "/Tarea/DeleteTarea";
            }           
            mS.getData("POST", urlBase, $scope.data).then(function (response) {
                if (response.code == "0") {
                    $scope.isNotify("error", response.message, response.messageTitle);
                } else if (response.code == "1") {
                    $scope.initialLoad();
                    $("#tareaModal").modal("hide");
                    if ($scope.data.operation === 2) {
                        $scope.isNotify("success", response.message, response.messageTitle);
                        $("#delete").modal("hide");
                    }  
                }
            }, function (error) {               
                $scope.isNotify("error", error.status, 'Error');                
            });
        }

        $scope.openModal = function (data, operation) {
            if (operation === 0) {               
                $scope.data.iconModal = "fa fa-plus";
                $scope.data.tituloModal = "Agregar";
                $scope.data.operation = operation;
                $("#tareaModal").modal("show");
                return;
            }

            if (operation === 1) {
                $scope.data = data;
                $scope.data.iconModal = "fa fa-edit";
                $scope.data.tituloModal = "Actualizar";
                $scope.data.operation = operation;
                $("#tareaModal").modal("show");
                return;
            }

            if (operation === 2) {
                $scope.data = data;
                $scope.data.iconModal = "fa fa-trash";
                $scope.data.tituloModal = "Eliminar";
                $scope.data.operation = operation;
                $("#delete").modal("show");
                return;
            }
            
        }

        $scope.isNotify = function (type, message, title) {
            Swal.fire({
                icon: type,
                title: title,
                text: message
            });
        }

        $('#tareaModal' || '#delete').on('hide.bs.modal', function () {
            $scope.data = {};
        });

    }
})(window.angular);
