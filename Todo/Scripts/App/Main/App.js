/* Declaramos variable app, para su uso de manera global en el proyecto*/
var app = angular.module("App", ['ngSanitize']);


/* Servicios */
app.factory('mainService', mainService)
mainService.$inject = ['$http']

function mainService($http) {
    var service = {
        getData: getData
    }
    return service

    /* Recibo los parámetros desde controlador => Method = POST, GET, PUT, DELETE;
    url: "example/example"; "$scope.data" y retorno un objeto data desde la bd en response.data
    */
    function getData(method, url, data) {
        var serviceData = $http({
            method: method,
            url: url,
            data: data
        }).then(function (response) {
            return response.data
        });
        return serviceData
    }

}