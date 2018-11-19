
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
    displayToastr();
}
function displayToastr() {
    toastr.success('Image Captured');
}
function show() {
    document.getElementById('imageDiv').style.maxHeight = "200px";
    var images = document.querySelector("#imageDiv img");
    images[0].src = document.getElementById("ImageId");
    
}



function Cancel() {
    window.location = '';
}

$(document).ready(function () {
    $('#txtDOB').datetimepicker({
        dateFormat: 'dd-mm-yy',
        changeTime:false
    });

});


$(document).ready(function () {
    $('#txtValidUpto').datetimepicker({
    });

});

$(document).ready(function () {

    $('#txtInTime').datetimepicker({
    });

});

$(document).ready(function () {
    $("#txtValidUpto").change(function () {
        var startDate = $('#txtInTime').val();
        var endDate = $('#txtValidUpto').val();

        if (Date.parse(startDate) >= Date.parse(endDate)) {
            alert("Validity Date and time is older than in Date time");

            $('#txtValidUpto').val("");
        }
        
    });
});


