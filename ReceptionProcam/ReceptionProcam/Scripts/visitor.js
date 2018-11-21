
$(function () {
    jQuery("#webcam").webcam({
        width: 320,
        height: 240,
        mode: "save",
        swffile: '/Scripts/jscam.swf',
        onSave: function (data, ab) {

            $.ajax({
                type: "POST",
                url:'/Visitor/GetCapture',
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "text",
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
    displayToastr();
}
function displayToastr() {
    toastr.success('Image Captured');
}

function Cancel() {
    window.location = '';
}

$(document).ready(function () {
    $('#txtDOB').datepicker({
        dateFormat: 'dd-mm-yy',
        autoclose: true,
        changeTime: false,
        endDate: new Date()
    });

});

//function printdiv(printpage) {
//    var newstr = document.all.item(printpage).innerHTML;
//    var oldstr = document.body.innerHTML;
//    document.body.innerHTML = newstr;
//    window.print();
//    document.body.innerHTML = oldstr;
//    return false;
//}
function printdiv(printpage) {
    var content = document.all.item(printpage).innerHTML;
    var mywindow = window.open('', 'Print', 'height=600,width=800');
    mywindow.document.write(content);
    mywindow.document.close();
    mywindow.focus()
    mywindow.print();
    mywindow.close();
    return true;
}

$(document).ready(function () {
    $('#txtValidUpto').datetimepicker({
        autoclose: true,
        startDate: new Date()
    });

});

$(document).ready(function () {

    $('#txtInTime').datetimepicker({
        autoclose:true,
        startDate: new Date()
    });

});

$(document).ready(function () {
    $("#txtValidUpto").change(function () {
        var startDate = $('#txtInTime').val();
        var endDate = $('#txtValidUpto').val();

        if (Date.parse(startDate) >= Date.parse(endDate)) {
            toastr.warning("Validity date  must be greater than InTime.");
            $('#txtValidUpto').val("");
        }
        
    });
});

