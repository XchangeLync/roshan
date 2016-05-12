/// <reference path="../angular.js" />
/// <reference path="module.js" />

app.service("ProductCRUDService", function ($http) {

    //Function to Read All Products
    this.getProducts = function () {
        return $http.get("http://localhost:49855/api/Products");
    };

    //Function to Read product details based upon code
    this.getProduct = function (pCode) {
        return $http.get("http://localhost:49855/api/Product/" + pCode);
    };

    //Function to Add new Product
    this.post = function (product) {
        var request = $http({
            method: "post",
            url: "http://localhost:49855/api/AddProduct",
            data: product
        });
        return request;
    };
    //Function  to Edit Product based upon product code
    this.put = function (pCode, product) {
        var request = $http({
            method: "put",
            url: "http://localhost:49855/api/EditProduct/" + pCode,
            data: product
        });
        return request;
    };

    //Function to Delete Product based upon product code
    this.delete = function (pCode) {
        var request = $http({
            method: "delete",
            url: "http://localhost:49855/api/DeleteProduct/" + pCode
        });
        return request;
    };
});