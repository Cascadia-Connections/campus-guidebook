

$(document).ready(function () {

    var isRejected = $("#isRejected").val();

    $("#isRejected").change(function () {
        isRejected = $("#isRejected").val();
        alert(isRejected);
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