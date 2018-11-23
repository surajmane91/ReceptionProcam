
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
    $("#SubmitBtn").removeAttr("disabled","disabled")
}
function displayToastr() {
    toastr.success('Image Captured');
}

function displayMessage(msg) {
    toastr.success(msg);
}

function Cancel() {
    window.location = '';
}

$(document).ready(function () {
    $('#txtDOB').datepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        changeTime: false,
        endDate: new Date()
    });

});

$(document).ready(function () {
    $('#txtVisitorId').attr('readonly', true)
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

//$(document).ready(function () {
//    $('#txtValidUpto').datetimepicker({
//        autoclose: true,
//        startDate: new Date()
//    });

//});
$(document).ready(function () {
    if ($("#imgCapture").val() == "") {
        toastr.warning("Please Capture Photo first!!")
        $("#SubmitBtn").attr("disabled", "disabled")

    }
})
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

$(document).ready(function () {
    $("#ddlDays").change(function () {
        //debugger;
        var AddDays = $('#ddlDays').val();
        var startDate = new Date();
        var timeIn = $('#hfTimeIn').val();
        var ValidityDate = new Date();
        if (AddDays == 1) {
            $('#txtValidUpto').datetimepicker('remove');
            ValidityDate.setDate(ValidityDate.getDate() + 0);
            $('#txtValidUpto').attr('readonly', true)
        }
        else if (AddDays == 3) {
            $('#txtValidUpto').datetimepicker('remove');
            ValidityDate.setDate(ValidityDate.getDate() + 2);
            $('#txtValidUpto').attr('readonly', true)
        }
        else if (AddDays == 7) {
            $('#txtValidUpto').datetimepicker('remove');
            ValidityDate.setDate(ValidityDate.getDate() + 6);
            $('#txtValidUpto').attr('readonly', true)
        }
        else if (AddDays == 8) {
            $('#txtValidUpto').attr('readonly', false)
            $('#txtValidUpto').datetimepicker({
                autoclose: true,
                startDate: new Date()
            });
        }
        var dd = ValidityDate.getDate();
        var mm = ValidityDate.getMonth()+1;
        var yyyy = ValidityDate.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        ValidityDate = dd + '-' + mm + '-' + yyyy+' 23:59';
        $('#txtValidUpto').val(ValidityDate);
        
        //if (Date.parse(timeIn) >= Date.parse(ValidityDate))
        //{
        //    toastr.warning("Validity date  must be greater than InTime.");
        //    $('#txtValidUpto').val(ValidityDate);
        //    //$('#txtValidUpto').val("");
        //}
        });
});

//function Check()
//{
//    if ($("#imgCapture").val() == "")
//    {
//        toastr.warning("Please Capture Photo first!!")
//    }
//}