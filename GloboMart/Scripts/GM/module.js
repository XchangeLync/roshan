/// <reference path="../angular.js" />

var app = angular.module("GMartApp", ["ngRoute", "ngMessages"]);

//For CORS resolution
//app.config(['$httpProvider', function($httpProvider) {
//    $httpProvider.defaults.useXDomain = true;
//    delete $httpProvider.defaults.headers.common['X-Requested-With'];
//}]);


app.factory("ShareData", function () {
    return { value: 0 }
});

//app.config(function ($routeProvider, $locationProvider) {
//    $routeProvider
//        .when("/home", {
//            templateUrl: "Views/Home/index.cshtml",
//            controller: "productController"
//        })
//        .when("/addProduct", {
//            templateUrl: "Template/frmProduct.html",
//            controller: "addProductController"
//        })
//        .when("/editProduct", {
//            templateUrl: "Template/frmProduct.html",
//            controller: "editProductController"
//        })
//        .otherwise({
//            redirectTo: "/home"
//        });

//    $locationProvider.html5Mode(true);
//});