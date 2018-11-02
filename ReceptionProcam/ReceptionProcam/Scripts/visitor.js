
$(function () {
    jQuery("#webcam").webcam({
        width: 320,
        height: 240,
        mode: "save",
        swffile: '/Scripts/jscam.swf',
        onSave: function (data, ab) {

            $.ajax({
                type: "POST",
                url: '/Visitor/GetCapture',
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    $("#imgCapture").css("visibility", "visible");
                    $("#imgCapture").attr("src", r);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        },
        onCapture: function () {
            webcam.save('/Visitor/Capture');
        }
    });
});
function Capture() {
    webcam.capture();
}

//$(document).ready(function () {
//    $('input[type=datetime]').datepicker({
//        minDate:0,
//        dateFormat: "dd/MM/yy",
//        changeMonth: true,
//        changeYear: true,
//        yearRange: "-60:+0",

//    });

//});
$(document).ready(function () {
    $('#txtValidUpto').datepicker({
        minDate: 0,
        dateFormat: "dd/MM/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0",

    });

});

function Print(formContainer) {
    $.ajax({
        type: "POST",
        url: '/Visitor/VisitorIndex',
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {

        },
        failure: function (response) {
            alert(response.d);
        }
    });
    var wnd = window.open("");
    wnd.document.write($("#printPage").html());
    wnd.print();
}

function Cancel() {
    window.location = '';
}