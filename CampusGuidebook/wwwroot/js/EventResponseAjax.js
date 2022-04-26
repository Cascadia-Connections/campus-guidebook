

$(document).ready(function () {

    var isRejected = $("#isRejected").val();

    $("#isRejected").change(function () {

        isRejected = $("#isRejected").val();

        if (isRejected == 2) {
            $("#RejectionReason").removeAttr("hidden");
            $("#RejectionLabel").removeAttr("hidden");
        } else {
            $("#RejectionReason").attr("hidden", "true");
            $("#RejectionLabel").attr("hidden", "true");
        }
    });

    
    //$.ajax({
    //    type: "POST",
    //    url: 'https://localhost:7212/',
    //    dataType: "test",
    //    success: function (data) {

    //    }
    //}
        
    //)
});