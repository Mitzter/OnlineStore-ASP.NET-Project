function showConfirmation(url) {
    var isBulkClient = confirm("Your total price exceeds 1000 BGN. Would you like to register your company and receive our Bulk Discounts?");
    if (isBulkClient) {
        window.location.href = url;
    }
}


window.onload = function () {
    showConfirmation();
};