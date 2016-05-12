app.controller("productController", function ($scope, $location, ProductCRUDService, ShareData) {
    $scope.pageHeader = "Product Catalogue List";

    var promiseGetProducts = ProductCRUDService.getProducts();
    promiseGetProducts.then(
        function (response) { $scope.products = response.data },
        function (resError) { $scope.error = 'Failure loading list of Products', resError; }
    );

    $scope.editProduct = function (pCode) {
        ShareData.value = pCode;
        //$location.path("/editProduct");
    }

    $scope.addProduct = function () {
        $location.path("/addProduct");
    }

    $scope.deleteProduct = function (pCode) {
        ShareData.value = pCode;
        if (confirm("Are you sure to delete product " + pCode + " ?")) {
            deleteProduct();
        }

        function deleteProduct() {
            var promiseDeleteProduct = ProductCRUDService.delete(ShareData.value);
            promiseDeleteProduct.then(
                function (response) {
                    //$route.reload();
                    alert('Deleted');
                },
                function (resError) { $scope.error = 'Failure deleting Product', resError; }
            );
        };
    }
});

app.controller("editProductController", function ($scope, $location, ProductCRUDService, ShareData) {
    $scope.disable = true;
    $scope.pageHeader = "Edit Product Detail";

    var promiseGetProduct = ProductCRUDService.getProduct(ShareData.value);
    promiseGetProduct.then(
        function (response) { $scope.product = response.data; },
        function (resError) { $scope.error = 'Failure loading product details', resError; }
    );
    $scope.save = function () {
        var promisePutProduct = ProductCRUDService.put($scope.product.Code, $scope.product);
        promisePutProduct.then(
            function (response) { alert("Product edited successfully"); },
            function (resError) { $scope.error = 'Failure loading product details after edit', resError; }
        );
    };
    $scope.cancel = function () {  }
});

app.controller('addProductController', function ($scope, $location, ProductCRUDService) {
    $scope.product = {};
    $scope.disable = false;
    $scope.pageHeader = "Add New Product";
    $scope.save = function () {
        var Product = {
            Code: $scope.product.Code,
            Type: $scope.product.Type,
            Name: $scope.product.Name,
            Price: $scope.product.Price,
            Quantity: $scope.product.Quantity,
            IsActive: $scope.product.IsActive === undefined ? false : true
        };

        var promisePostProduct = ProductCRUDService.post(Product);
        promisePostProduct.then(
            function (response) {
                $scope.product.Code = response.data;
                if ($scope.product.Code != -1 && $scope.product.Code != undefined)
                    alert("Product added successfully");
                else if($scope.product.Code == -1)
                    alert("Product already exist");
            },
            function (resError) { $scope.error = 'Failure loading product details after add', resError; }
        );
    };
    $scope.cancel = function () {  }
});
