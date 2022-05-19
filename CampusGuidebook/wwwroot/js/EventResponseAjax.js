

$(document).ready(function () {

    var isRejected = $("#isRejected").val();

    $("#isRejected").change(function () {

        isRejected = $("#isRejected").val();

        if (isRejected == 2) {
            $("#RejectionReason").removeAttr("hidden");
            $("#RejectionLabel").removeAttr("hidden");
            $("#ConditionsReason").removeAttr("hidden");
            $("#ConditionsLabel").removeAttr("hidden");
        } else {
            $("#RejectionReason").attr("hidden", "true");
            $("#RejectionLabel").attr("hidden", "true");
            $("#ConditionsReason").attr("hidden", "true");
            $("#ConditionsLabel").attr("hidden", "true");
        }
    });

    
    //$.ajax({
    //    type: "GET",
    //    url: 'https://localhost:7212/EventApi/',
    //    dataType: "test",
    //    success: function (data) {

    //    }
    //}
        
    //)
});