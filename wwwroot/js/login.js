$(document).ready(function () {


})

//On the Click Of Login Button
$("#loginButton").click(function (e) {
    e.preventDefault();

    var userNamevalue = $("#UserName").val();
    var Passwordvalue = $("#Password").val();

    if (userNamevalue != "" && userNamevalue != "") {
        $.ajax({
            url: $('#login_url').data('request-url'),
            data: { Username: userNamevalue, Password: Passwordvalue },
            type: "Get",
            contentType: "application/json",
            success: function (response) {
                console.log(response.RespCode);
                if (response.respCode == 0) {

                    window.location = 'Home/AdminView';
                }
                else if (response.respCode == 1) {

                    window.location = 'Home/EmployeeView';
                }
                else {
                    swal(
                        'Error!',
                        "User Does Not Exist, Contact Adminstrator",
                        'error'
                    )
                }
            }
        });
    }
    else {
        swal(
            'error',
            "User Name or Password Cannot Be Empty",
            'error'
        );
        return false;
    }
})