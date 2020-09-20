$(document).ready(function () {

    $('#AddInventoryModal').hide();
})

$('#AddInventory').click(function (e) {
    e.preventDefault();

    $('#AddInventoryModal').show();
})

$('#acceptButton').click(function (e) {
    e.preventDefault();
    var model = {
        Id: $('#itemId').val(),
        InventoryItem : $('#inventoryItem').val(),
        EmployeeName: $('#employeeName').val(),
        WareHouse: $('#wareHouseName').val(),
        EmployeeRole: $('#employeeRole').val()
    };
    if (model.InventoryItem === "") {
        return (
            swal({
                title: 'Validation Error',
                text: 'Please Enter Inventory Item',
                type: 'error'
            })
            )
      
    };
    if (model.EmployeeName === "") {
        return (
            swal({
                title: 'Validation Error',
                text: 'Please Enter Employee Name',
                type: 'error'
            })
            )
       
    };
    if (model.WareHouse === "") {
        return (
            swal({
                title: 'Validation Error',
                text: 'Please Enter Ware House',
                type: 'error'
            })
        );

    };
    if (model.EmployeeRole === "") {
        return (
            swal({
                title: 'Validation Error',
                text: 'Please Enter Employee Role',
                type: 'error'
            })
        );

    };
    $.ajax({
        url: $('#addNewInventory').data('request-url'),
        type: "Get",
        contentType: "application/json",
        data: JSON.stringify(model),
        success: function (response) {
            if (response.RespCode == 0) {
                swal({
                    title: 'Success',
                    text: response.RespMessage,
                    type: 'success'
                })
                //window.location.reload('900000000000000000');
            }
            else {
                swal(
                    'Contact Administrator',
                    'Customer Information Could not be Updated',
                    'error'
                )
                // window.location.reload('90000000000000000000');
            }
        }
    });

});  