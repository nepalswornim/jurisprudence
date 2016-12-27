/// <reference path="angular.js" />



var myApp = angular.module("myApp", []);
myApp.controller("userCtrl", function ($scope, $http) {
    debugger;
    $scope.users = "";
    $http.get("/Case/GetAllUsers")
    .success(function (result) {
        $scope.users = result;
    })
.error(function (result) {
    console.log(result);
})})