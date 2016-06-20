$(document).ready(function () {
    console.log("***Getting Products...");
    getProducts = function () {
        $.ajax("/api/products", {
            success: function (data) {
                products.removeAll();
                for (var i = 0; i < data.length; i++) {
                    products.push(data[i]);
                }
                console.log("***Received Products...");
                console.log(products);
            }
        })
    };
    ko.applyBindings();
});