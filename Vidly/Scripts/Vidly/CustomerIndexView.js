$(document).ready(function () {

    var custTable = $('#customers').DataTable({
        "lengthMenu": [5, 10, 15]
    });

    $("#MembershipTypes").DataTable({
        ajax: {
            url: "/api/MembershipTypes",
            dataSrc: ""
        },
        columns: [
            {
                data: "memberShipDescription"
            },
            {
                data: "signUpFee"
            },
            {
                data: "durationInMonths"
            },
            {
                data: "discountRate"
            },
        ],
        lengthMenu: [5, 10, 15]
    })

    $("#customers").on("click", ".js-btn-delete", function () {
        var id = $(this).attr("data-customer-id");
        var customer = $(this);
        bootbox.confirm("Hello do you want to delete me?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customers/" + id,
                    method: "DELETE",
                    success: function () {
                        custTable.row(customer.parents("tr")).remove().draw();
                        bootbox.alert("Customer ID " + id + " deleted");
                    }
                });
            }
        });
    })
})