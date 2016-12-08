function calculate() {
    var unitprice = $("#product_Price").val();
    var quantity = $("#order_Quantity").val();
    var total = unitprice * quantity;
    $("#total").text(total);
}

$(document).ready(function () {
    $("#order_Quantity").change(calculate)
});