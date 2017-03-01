$(document).ready(function () {
    $('input[type=text]').addClass('form-control');
    //setApplicationTitle();
    $(".lang-fa").farsiInput();
    //$(".lang-fa").farsiInput();settexttime
    //if ($('span').find("[data-valmsg-for='ServerError']").text()!='') {
    //    alert('gggg');
    //}

    //$('.ullevel3').mouseover(function () {
    //    $('.ullevel2 li').each(function () {
    //    });
    //});    

    //$.ajaxSetup({
    //    error: function (x) {
    //        alert("bbbb");
    //        alert(x);
    //        if (x.status == 403) {
    //            alert("aaaa");
    //            window.location = "~/Account/Login";
    //        }
    //    }
    //});

    $.ajaxSetup({
        complete: function (xhr, textStatus) {            
            if (xhr.status == 401) {                
                window.location = "/Account/Login";
            }
        }
    });
});

function crudcreate(e, url) {
    if ($(e).hasClass('disabled') == false) {
        window.location = url;
    }
}

function crudedit(e, url) {
    var rowId = $('.rowId', 'tbody > .selected').html();
    if (!(typeof rowId === 'undefined' || rowId == '') && $(e).hasClass('disabled') == false) {
        window.location = url + rowId;
    }
}

function cruddelete(e, url) {
    var rowId = $('.rowId', 'tbody > .selected').html();
    if (!(typeof rowId === 'undefined' || rowId == '') && $(e).hasClass('disabled') == false) {
        window.location = url + rowId;
    }
}

//function crudcreate(e, url) {
//    if ($(e).hasClass('disabled') == false) {
//        window.location = url;
//    }
//}

//function crudedit(e, url) {    
//    if (!(typeof $('.selected .rowid').val() === 'undefined') && $(e).hasClass('disabled') == false) {
//        window.location = url + $('.selected .rowid').val();
//    }
//}

//function cruddelete(e, url) {
//    alert(url);
//    if (!(typeof $('.selected .rowid').val() === 'undefined') && $(e).hasClass('disabled') == false) {
//        window.location = url + $('.selected .rowid').val();
//    }
//}

function cancelSaveEntity(e, url) {
    if (url == "") {
        history.go(-1);
    }
    else {
        window.location = url;
    }
}

function deleteConfirmation() {
    if (confirm("آیا از حذف اطلاعات اطمینان دارید؟") == true) {
        return true;
    }
    else {
        return false;
    }
}

$(".dropdown-menu li a", ".field-datatable").click(function () {
    $(this).parents('.open', '.btn-group').find('.dropdown-toggle').html($(this).html() + ' <span name="' + $(this).parent().prop('id') + '" id="' + $(this).parent().prop('id') + '" class="caret"></span>');
    dropdownSelected($(this).parents('.open','.btn-group').prop('id'), $(this).parent().prop('id'));
});

function setDropDownSelecedChangeEvent() {
    $(".dropdown-menu li a").click(function () {        
        $(this).parents('.open', '.btn-group').find('.dropdown-toggle').html($(this).html() + ' <span name="' + $(this).parent().prop('id') + '" id="' + $(this).parent().prop('id') + '" class="caret"></span>');
        dropdownSelected($(this).parents('.open', '.btn-group').prop('id'), $(this).parent().prop('id'));
    });
}

function showErrorMessage(message, controlId) {
    if (message != '' && message != 'undefined') {
        $('.apperror').html('');
        $('.apperror').html('<div style="padding:10px;color:#000">' + message + '</span>');
        $('.apperror').dialog({
            modal: true,
            width: '450px',
            'height': 'auto',
            zIndex: 15000,
            title: 'خطا',
            buttons: {}
        });

        if (controlId != '' && controlId != 'undefined') {
            $('#' + controlId).addClass('control-data-error');
        }
    }
}

function replaceAll(find, replace, str) {
    while (str.indexOf(find) > -1) {
        str = str.replace(find, replace);
    }
    return str;
}
//function fnajax(url, type, data) {
//    type = typeof type !== 'undefined' ? type : 'post';
//    var returnedValue=null;
//    $.ajax({
//        type: type,
//        url: url,
//        data: data,
//        success: function (result) {
//            returnedValue = result;
//        },
//        error: function (result) {
//            alert("عملیات  با خطا مواجه شد.");
//        }
//    }).complete(function (){
//        alert('returnedValue=' + returnedValue);
//        return returnedValue;
//    });
//}

function startAjax() {
    $('#divMessageWait').show();
}

function stopAjax() {
    $('#divMessageWait').hide();
}

function isvalidTime(hour, min) {
    if (hour == '' || hour == undefined || hour < 0 || hour > 24) {
        return false;
    }

    if (min == '' || min == undefined || min < 0 || min > 60) {
        return false;
    }

    return true
}

function isvalidFromToTime(hourTime1, minTime1, hourTime2, minTime2) {
    if ((hourTime1 + minTime1) >= (hourTime2 + minTime2)) {
        return false;
    }

    return true
}


function validateRequestDocTime() {
    showErrorMessage('');
    $('#Req_Start_Time-Container').css('border', '0');
    $('#Req_End_Time-Container').css('border', '0');
    var fromtime = $('#tpFromTimeValue', '#frmRequestDoc').text();
    //alert('fromtime=' + fromtime + '--------|' + fromtime.substring(4));
    //var startTimeHour = $('#Req_Start_Time1', '#Req_Start_Time-Container');
    var startTimeHour = $('#tpFromTimeValue', '#frmRequestDoc').text().substring(0, 2);
    var startTimeMin = $('#tpFromTimeValue', '#frmRequestDoc').text().substring(3, 2);

    var endTimeHour = $('#Req_End_Time1', '#Req_End_Time-Container');
    var endTimeMin = $('#Req_End_Time2', '#Req_End_Time-Container');
    //alert(startTimeHour + ':' + startTimeMin + '----------' + endTimeHour.val() + ':' + endTimeMin.val());
    return;
    if (isvalidTime(startTimeHour, startTimeMin) == false) {
        showErrorMessage('مقدار "از ساعت" صحیح نمی باشد');
        $('#tpFromTimeValue', '#frmRequestDoc').parent().css('border', 'solid 1px red');
        return false;
    }
    else if (isvalidTime(endTimeHour.val(), endTimeMin.val()) == false) {
        showErrorMessage('مقدار "تا ساعت" صحیح نمی باشد');
        $('#Req_End_Time-Container').css('border', 'solid 1px red');
        return false;
    }
    else if (isvalidFromToTime(startTimeHour, startTimeMin, endTimeHour.val(), endTimeMin.val()) == false) {
        showErrorMessage('بازه انتخابی "از ساعت" - "تا ساعت" صحیح نمی باشد');
        return false;
    }

    $('#Req_Start_Time').val((startTimeHour * 60) + startTimeMin);
    $('#Req_End_Time').val((endTimeHour.val() * 60) + endTimeMin.val());

    return true;
}

function stringHasValue(value) {
    if (typeof value === 'undefined' || value === null || value == '') {
        return false;
    }

    return true;
}
///////////////////////////////////////////////////////////////////////////////////////////PersonInfoLookup
function personInfoLookupFor(lookupControlId) {
    $('.txtLookup', ('#' + lookupControlId)).keyup(function () {
        getpersoninfo(lookupControlId, false);
    });

    if (stringHasValue($('.txtLookup', ('#' + lookupControlId)).val())) {
        getpersoninfo(lookupControlId, true);
    }

    //var index = 0;
    //$('.txtLookup', ('#' + lookupControlId)).keydown(function (e) {

    //    if (e.keyCode === 38 || e.keyCode === 40) {
    //        if (e.keyCode === 40) {///////////////////Down Key
    //            index = index + 1 >= $('.lookup-inline-datatable tr', ('#' + lookupControlId)).length ? $('.lookup-inline-datatable', ('#' + lookupControlId)).length - 1 : index + 1;
    //        }
    //        if (e.keyCode === 38) {///////////////////Up Key
    //            index = (index == 0) ? 0 : index - 1;
    //        }
    //        $('.panel-heading').html(index);
    //        $('.lookup-inline-datatable-activerow', ('#' + lookupControlId)).removeClass('lookup-inline-datatable-activerow');
    //        $('.lookup-inline-datatable tr:eq(' + index + ')', ('#' + lookupControlId)).addClass('lookup-inline-datatable-activerow');
    //    }
    //});
}

function getpersoninfo(lookupControlId, iseditMode) {
    var value = $('.txtLookup', ('#' + lookupControlId)).val();
    if (value != undefined && value.length < 3) {
        $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
        $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
        return;
    }

    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/home/getperson',
        data: { "strkey": value },
        success: function (result) {

            var tbl = '<table class="table table-striped display lookup-inline-datatable"><tbody>';
            var splitstring;
            if (result.indexOf('accessdenied') !== -1) { window.location = '/Account/AccessDenied'; return; }
            $.each(result, function (index) {
                splitstring = result[index].toString().split(",");
                tbl += '<tr>';
                tbl += '<td>' + splitstring[0] + '</td>';
                tbl += '<td>' + splitstring[1] + '</td>';
                tbl += '<td>' + splitstring[2] + '</td>';
                tbl += '</tr>';
            });
            tbl += '</tbody></table>';

            $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
            $('.lookup-data', ('#' + lookupControlId)).html(tbl);

            if (iseditMode) {
                var trLookup = $('.lookup-inline-datatable > tbody > tr:first', ('#' + lookupControlId));

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(trLookup).find('td:first').next().html() + ' ' +
                    $(trLookup).find('td:first').next().next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            }

            $('.lookup-inline-datatable > tbody > tr', ('#' + lookupControlId)).click(function () {

                $('.txtLookup', ('#' + lookupControlId)).val($(this).find('td:first').html());
                $(('#' + lookupControlId + '_PersonCode'), ('#' + lookupControlId)).val($(this).find('td:first').html());

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(this).find('td:first').next().html() + ' ' +
                    $(this).find('td:first').next().next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            });

            $('.txtLookup', ('#' + lookupControlId)).click(function () {
                $(this).select();
                $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
            });

            //lookupcontrolnavigation(lookupControlId);
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}
///////////////////////////////////////////////////////////////////////////////////////////

function archiveRequestReferential(requestDocId, flowStepId, comment) {
    //alert(requestDocId + '--' + flowStepId + '--' + comment);
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Cartable/ArchiveRequestReferential',
        data: { 'requestDocId': requestDocId, 'flowStepId': flowStepId, 'comment': comment },
        success: function (result) {
            if (result != '') {
                showErrorMessage(result);
                return result;
            }
            else {
                getData(null, 1);
            }
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function setApplicationTitle() {
    startAjax();
    $.ajax({
        type: 'get',
        url: '/Home/ApplicationTitle',
        success: function (result) {            
            $('.applicationtitle').text(result);
        }
    }).always(function () {
        stopAjax();
    });

}

///////////////////////////////////////////////////////////////////////////////////////////CostCenterLookup
function costCenterLookupFor(lookupControlId) {
    $('.txtLookup', ('#' + lookupControlId)).keyup(function () {
        getpCostCenter(lookupControlId, false);
    });

    if (stringHasValue($('.txtLookup', ('#' + lookupControlId)).val())) {
        getpCostCenter(lookupControlId, true);
    }

    //var index = 0;
    //$('.txtLookup', ('#' + lookupControlId)).keydown(function (e) {

    //    if (e.keyCode === 38 || e.keyCode === 40) {
    //        if (e.keyCode === 40) {///////////////////Down Key
    //            index = index + 1 >= $('.lookup-inline-datatable tr', ('#' + lookupControlId)).length ? $('.lookup-inline-datatable', ('#' + lookupControlId)).length - 1 : index + 1;
    //        }
    //        if (e.keyCode === 38) {///////////////////Up Key
    //            index = (index == 0) ? 0 : index - 1;
    //        }
    //        $('.panel-heading').html(index);
    //        $('.lookup-inline-datatable-activerow', ('#' + lookupControlId)).removeClass('lookup-inline-datatable-activerow');
    //        $('.lookup-inline-datatable tr:eq(' + index + ')', ('#' + lookupControlId)).addClass('lookup-inline-datatable-activerow');
    //    }
    //});
}

function getpCostCenter(lookupControlId, iseditMode) {
    var value = $('.txtLookup', ('#' + lookupControlId)).val();
    if (value != undefined && value.length < 3) {
        $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
        $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
        return;
    }

    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/home/GetCostCenters',
        data: { "strkey": value },
        success: function (result) {

            var tbl = '<table class="table table-striped display lookup-inline-datatable"><tbody>';
            var splitstring;
            if (result.indexOf('accessdenied') !== -1) { window.location = '/Account/AccessDenied'; return; }
            $.each(result, function (index) {
                splitstring = result[index].toString().split(",");
                tbl += '<tr>';
                tbl += '<td>' + splitstring[0] + '</td>';
                tbl += '<td>' + splitstring[1] + '</td>';
                tbl += '</tr>';
            });
            tbl += '</tbody></table>';

            $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
            $('.lookup-data', ('#' + lookupControlId)).html(tbl);


            if (iseditMode) {
                var trLookup = $('.lookup-inline-datatable > tbody > tr:first', ('#' + lookupControlId));

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(trLookup).find('td:first').next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            }

            $('.lookup-inline-datatable > tbody > tr', ('#' + lookupControlId)).click(function () {

                $('.txtLookup', ('#' + lookupControlId)).val($(this).find('td:first').html());
                $(('#' + lookupControlId + '_PersonCode'), ('#' + lookupControlId)).val($(this).find('td:first').html());

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(this).find('td:first').next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            });

            $('.txtLookup', ('#' + lookupControlId)).click(function () {
                $(this).select();
                $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
            });

            //lookupcontrolnavigation(lookupControlId);
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}
///////////////////////////////////////////////////////////////////////////////////////////

//function lookupcontrolnavigation(lookupControlId) {
//    var active;
//    $('.txtLookup', ('#' + lookupControlId)).keydown(function (e) {        
//        active = $('tr.lookup-inline-datatable-activerow').removeClass('lookup-inline-datatable-activerow');
//        var x = active.index();
//        var y = active.closest('tr').index();
//        if (e.keyCode == 37) {
//            x--;
//        }
//        if (e.keyCode == 38) {
//            y--;
//        }
//        if (e.keyCode == 39) {
//            x++
//        }
//        if (e.keyCode == 40) {
//            y++
//        }
//        active = $('tr').eq(y).addClass('lookup-inline-datatable-activerow');
//    });
//}



///////////////////////////////////////////////////////////////////////////////////////////ProjectName
function projectInfoLookupFor(lookupControlId) {
    $('.txtLookup', ('#' + lookupControlId)).keyup(function (e) {
        getprojectinfo(lookupControlId);
    });

    $('.txtLookup').on("focus", function () {
        $(this).select();
    });

    $('.txtLookup', ('#' + lookupControlId)).keydown(function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            //e.preventDefault();
            if ($('.lookup-inline-datatable tr', ('#' + lookupControlId)).length == 1) {
                var trLookup = $('.lookup-inline-datatable > tbody > tr:first', ('#' + lookupControlId));

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(trLookup).find('td:first').next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');

                $('.txtLookup', ('#' + lookupControlId)).val(trLookup.find('td:first').html());
                $(('#' + lookupControlId + '_ProjectId'), ('#' + lookupControlId)).val(trLookup.find('td:last').html());
            }
        }
    });

    if (stringHasValue($('.txtLookup', ('#' + lookupControlId)).val())) {
        getprojectinfo(lookupControlId, true);
    }

    //$('.lookup-table', ('#' + lookupControlId)).parents('table').on('click',function () {
    //    alert('ggggggggggg');
    //    $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
    //})
}

function getprojectinfo(lookupControlId, iseditMode) {
    var value = $('.txtLookup', ('#' + lookupControlId)).val();
    if (iseditMode != true) {
        $(('#' + lookupControlId + '_ProjectId'), ('#' + lookupControlId)).val('');
    }

    if (value.length < 3) {
        $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
        $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
        return;
    }

    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/home/GetProjetcs',
        data: { "strkey": value },
        success: function (result) {
            var tbl = '<table class="table table-striped display lookup-inline-datatable"><tbody>';
            var splitstring;
            $.each(result, function (index) {
                splitstring = result[index].toString().split(",");
                tbl += '<tr>';
                tbl += '<td>' + splitstring[0] + '</td>';
                tbl += '<td>' + splitstring[1] + '</td>';
                tbl += '<td class="hide">' + splitstring[2] + '</td>';
                tbl += '</tr>';
            });
            tbl += '</tbody></table>';

            $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
            $('.lookup-data', ('#' + lookupControlId)).html(tbl);

            if (iseditMode) {
                var trLookup = $('.lookup-inline-datatable > tbody > tr:first', ('#' + lookupControlId));

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(trLookup).find('td:first').next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            }

            $('.lookup-inline-datatable > tbody > tr', ('#' + lookupControlId)).click(function () {

                $('.txtLookup', ('#' + lookupControlId)).val($(this).find('td:first').html());
                $(('#' + lookupControlId + '_ProjectId'), ('#' + lookupControlId)).val($(this).find('td:last').html());
                //alert(('#' + lookupControlId + '._ProjectId'));

                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text
                    (
                    $(this).find('td:first').next().html()
                    );
                $('.lookup-data', ('#' + lookupControlId)).addClass('hide');
            });

            $('.txtLookup', ('#' + lookupControlId)).click(function () {
                $(this).select();
                $('.lookup-data', ('#' + lookupControlId)).removeClass('hide');
                $('.lookup-lable-container .lookup-lable', ('#' + lookupControlId)).text('');
            });
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

////////////////////////////////////////////////////////////////////////////////////////////TimePicker

function controlToTimePickerFor(controlid) {
    var hour;
    var min;

    $('.txtTime', ('#' + controlid)).click(function () {
        if ($('.timePicker-data', ('#' + controlid)).hasClass('hide')) {
            $('.timePicker-data', ('#' + controlid)).removeClass('hide');
        }
        else {
            $('.timePicker-data', ('#' + controlid)).addClass('hide');
        }
    });

    $("#sliderhour", ("#" + controlid)).slider({
        orientation: "horizontal",
        range: "min",
        min: 6,
        max: 23,
        value: 0,
        slide: function (event, ui) {
            //$(".timePicker-displaypanel .lblhour", ("#" + controlid)).text((ui.value.toString().length == 1 ? '0' + ui.value : ui.value));
            //settimePickervalue(controlid);

            min = $("#slidermin", ("#" + controlid)).slider('value');
            $('#' + controlid + 'Value', ('#' + controlid)).text((ui.value.toString().length == 1 ? '0' + ui.value : ui.value) + ':' + (min.toString().length == 1 ? '0' + min : min));
            $(("#" + controlid + "_Hour"), ("#" + controlid)).val(ui.value);
        }
    });
    $("#slidermin", ("#" + controlid)).slider({
        orientation: "horizontal",
        range: "min",
        min: 0,
        max: 59,
        value: 0,
        slide: function (event, ui) {
            //$(".timePicker-displaypanel .lblmin", ("#" + controlid)).text((ui.value.toString().length == 1 ? '0' + ui.value : ui.value));
            //settimePickervalue(controlid);

            hour = $("#sliderhour", ("#" + controlid)).slider('value');
            $('#' + controlid + 'Value', ('#' + controlid)).text((hour.toString().length == 1 ? '0' + hour : hour) + ':' + (ui.value.toString().length == 1 ? '0' + ui.value : ui.value));
            $(("#" + controlid + "_Min"), ("#" + controlid)).val(ui.value);

        }
    });

    $(".timePicker-selecttime", ("#" + controlid)).click(function () {
        //$('#' + controlid + 'Value', ('#' + controlid)).text($(".lblhour", ("#" + controlid)).text() + ':' + $(".lblmin", ("#" + controlid)).text());
        //settimePickervalue(controlid);
        $('.timePicker-data', ('#' + controlid)).addClass('hide');
    });

    $(".timePicker-currenttime", ("#" + controlid)).click(function () {
        setslidervalue(controlid);
        settimePickervalue(controlid);
    });

    setslidervalue(controlid);
}

function settimePickervalue(controlid) {
    var hour = $("#sliderhour", ("#" + controlid)).slider('value');
    var min = $("#slidermin", ("#" + controlid)).slider('value');

    $(("#" + controlid + "_Hour"), ("#" + controlid)).val(hour);
    $(("#" + controlid + "_Min"), ("#" + controlid)).val(min);

    //$('#timePicker1Value').text(hour + ':' + min);

    //$('#' + controlid + 'Value', ('#' + controlid))
    //    .text(
    //    (hour.toString().length == 1 ? '0' + hour : hour) +
    //    ':' +
    //    (min.toString().length == 1 ? '0' + min : min)
    //    );

    //alert((hour.toString().length == 1 ? '0' + hour : hour) +
    //    ':' +
    //    (min.toString().length == 1 ? '0' + min : min));
}

function setslidervalue(controlid) {
    startAjax();

    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Home/GetServerTime',
        data: null,
        success: function (result) {
            //$(".lblhour", ("#" + controlid)).text(result.Hour);
            //$(".lblmin", ("#" + controlid)).text(result.Min);

            $("#sliderhour", ("#" + controlid)).slider('value', result.Hour);
            $("#slidermin", ("#" + controlid)).slider('value', result.Min);

            $('#' + controlid + 'Value', ('#' + controlid))
                .text(
                (result.Hour.toString().length == 1 ? '0' + result.Hour : result.Hour) +
                ':' +
                (result.Min.toString().length == 1 ? '0' + result.Min : result.Min)
                );
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

//////////////////////////////////////////////////////////////////////////////////////
function showRequestStepsTree(requestdoid) {
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Cartable/RequestStepsTree',
        data: { 'requestDocId': requestdoid },
        success: function (result) {
            $('#divRequestStepsTree').html(result);
            $('#divRequestStepsTree').dialog({
                modal: true,
                width: 700,
                hieght: 700,
                zIndex: 15000,
                title: 'گردش سند',
                buttons: {}
            });
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}


function expanditems(li) {
    if ($(li, '.requeststepstree').nextAll().hasClass('hide')) {
        $(li, '.requeststepstree').nextAll().removeClass('hide');
        $(li, '.requeststepstree').css('list-style-image', 'url("/Content/Styles/images/tree-expand.png")');
        $(li, '.requeststepstree').nextAll().css('list-style-image', 'url("/Content/Styles/images/tree-expand.png")');
    }
    else {
        $(li, '.requeststepstree').nextAll().addClass('hide');
        $(li, '.requeststepstree').css('list-style-image', 'url("/Content/Styles/images/tree-collapse.png")');
    }

    $('.requeststepstree > ul > li:last-child').css('list-style', 'none');
}

function settexttime(controlid) {
    $('.txthourfrom', ('#' + controlid)).focus();

    $('.txthourfrom', ('#' + controlid)).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.txtminfrom', ('#' + controlid)).focus();
            e.preventDefault();
        }
    });

    $('.txtminfrom', ('#' + controlid)).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;

        if (keyCode == 9) {
            //alert($(this).parents('tr').nextAll('tr').not(".hide").find(".aftertimecontrol:first").prop('name'));
            $(this).parents('tr').nextAll('tr').not(".hide").find(".aftertimecontrol:first").focus();
            e.preventDefault();
        }

        //if ($('.txtminfrom', ('#' + controlid)).val().length >= 2) {
        //    e.preventDefault();
        //}
    });

    $('.inputtime', ('#' + controlid)).keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });


    $('.inputtime', ('#' + controlid)).focusout(function () {
        if ($(this).val().trim() == '') {
            $(this).val('00');
        }

        if ($(this).val().trim().length == 1) {
            $(this).val('0' + $(this).val().trim());
        }
    });
}

function readonlyElements(el) {
    for (var i = 0; i < el.length; i++) {
        $(el[i]).prop("readonly", true);

        if ($(el[i]).is('[onclick]')) {
            $(el[i]).attr('onclick', '');
        }

        if ($(el[i]).prop("tagName").toLowerCase() == 'select') {
            $(el[i]).find('option:not(:selected)').prop("disabled", true).remove();
            $(el[i]).attr('readonly', true);
        }

        readonlyElements(el[i].children);
    }
}

function enableReadonlyElements(el) {
    for (var i = 0; i < el.length; i++) {
        $(el[i]).prop("readonly", false);

        enableReadonlyElements(el[i].children);
    }
}

function showRequestDetails(url) {
    startAjax();

    var wHeight = $(window).height();
    var dHeight = wHeight * 0.8;

    //$(".ui-icon-closethick").on('click', function () {
    //    $('.ui-dialog').remove();
    //    $('#divRequestDetails').html('');
    //});

    $.ajax({
        type: 'get',
        url: url,
        success: function (result) {
            $("#divRequestDetails").html(result);
            $("#divRequestDetails").dialog({
                modal: true,
                width: 'auto',
                title: 'مشاهده جزییات',
                "maxHeight": dHeight,
                zIndex: 15000,
                open: function (event, ui) {
                    $(this).css({ 'overflow-x': 'hidden', 'padding': '0' });
                },
                //position: {
                //    my: "center bottom",
                //    at: "center top",
                //    of: $("#divRequestDetails"),
                //    within: $(".content")
                //},
                close: function (event, ui) {
                    $('.ui-dialog').remove();
                    $('#divRequestDetails').html('');
                },
                buttons: {}
            }).prev(".ui-dialog-titlebar").css({ "background-color": "#f2a612", "border-color": "#ae7100", "color": "#fff", "background-image": "none" });
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function setFormSection(sectionNumber, requierFillData) {
    var panelwidth = $(window).width() * 0.8;
    $('.requestdetail-mainpanel').css({ 'width': panelwidth + 'px', 'left': '0' });

    $('.formsection').each(function () {
        $('.calendar-container img').remove();
        if ($(this).attr('sectionnumber') != sectionNumber || requierFillData == 'False') {
            readonlyElements($(this));
            $(this).find("[data-valmsg-for='ServerError']").remove();
            $(this).find("tfoot > tr:first-child").remove();
            $('textarea', $(this)).css('resize', 'none');

            $(':checkbox', $(this)).on('click', function (e) { return false; });
        }
        else {

            $(this).css({ 'border': 'solid 2px red' });
            //,'-moz-box-shadow': '3px 5px 6px #888888', '-webkit-box-shadow': '3px 5px 6px #888888', 'box-shadow': '3px 5px 6px #888888' 
        }
    });
}


function showRequestMoreInfo(id) {
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Cartable/ShowMoreInfo',
        data: { 'id': id },
        success: function (result) {
            if (result != '') {
                if (result == 'IsF1F2NotConfirmed') {
                    window.location = "/RequestDoc/EditTimeDoc?id=" + id;
                    return;
                }

                $('#divRequestDetails').html(result);
                $('#divRequestDetails').dialog({
                    modal: true,
                    width: 600,
                    hieght: 400,
                    zIndex: 15000,
                    title: 'مشاهده جزئیات درخواست',
                    buttons: {},
                    close: function () {
                        $('#divRequestDetails').html('');
                    }
                });
            }
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}



function printDiv(element) {
    // $('.formsection-panel-titlebar-container', element).remove();
    var divElements = $(element).html();
    //Get the HTML of whole page
    var oldPage = document.body.innerHTML;
    //alert(divElements);
    //Reset the page's HTML with div's HTML only
    document.body.innerHTML =
      "<html><head><title></title></head><body>" +
      divElements + "</body>";

    //Print Page

    window.print();
    //Restore orignal HTML
    document.body.innerHTML = oldPage;
    location.reload();
    $(element).on('onmouseover', function () { window.close(); });
    //alert(window.location.href);
    //window.location = window.location.href;
}

function isNullOrEmpty(s) {
    return (s == null || s === "");
}

String.prototype.repeat = function (count) {
    if (count < 1) return '';
    var result = '', pattern = this.valueOf();
    while (count > 1) {
        if (count & 1) result += pattern;
        count >>>= 1, pattern += pattern;
    }
    return result + pattern;
};

function settsmTimer() {
    //if (isNullOrEmpty(value)) {
    //    $('.tsmtimer').val('00:00');
    //}
    //else {
    //    $('.tsmtimer').val(value);
    //}

    $('.tsmtimer').on("click", function () {
        $(this).select();
    });

    $('.tsmtimer').on('keypress', function (e) {
        if (!jQuery.isNumeric(String.fromCharCode(e.which)) && String.fromCharCode(e.which) != ':') {
            e.preventDefault();
        }

        if ($(this).val() == '00:00') {
            $(this).select();
        }

        switch ($(this).val().length) {
            case 1:
                if (parseInt($(this).val() + String.fromCharCode(e.which)) > 23) {
                    $(this).val('0' + $(this).val());
                    //e.preventDefault();
                    //return;
                }
                break;

            case 2:
                if (parseInt(String.fromCharCode(e.which)) > 5) {
                    e.preventDefault();
                    return;
                }
                break;

            case 4:
                if (parseInt($(this).val().substring(3) + String.fromCharCode(e.which)) > 59) {
                    e.preventDefault();
                    return;
                }
                break;
        }

        if ($(this).val().length == 2) {
            $(this).val($(this).val() + ':');
        }
    });

    $('.tsmtimer').focusout(function () {
        if ($(this).val().indexOf(':') < 0) {
            if ($(this).val().length == 2) {
                $(this).val($(this).val() + ':00');
                return;
            }

            if ($(this).val().length == 4) {
                $(this).val($(this).val().substring(0, 2) + ':' + $(this).val().substring(2));
                return;
            }

            $(this).val('00:00');
            return;
        }

        var strSplited = $(this).val().split(':');
        strSplited[0] = '0'.repeat(2 - strSplited[0].length) + strSplited[0];
        strSplited[1] = '0'.repeat(2 - strSplited[1].length) + strSplited[1];

        if (parseInt(strSplited[0]) > 23 || parseInt(strSplited[1]) > 59) {
            $(this).val('00:00');
            return;
        }

        $(this).val(strSplited[0] + ':' + strSplited[1]);
    });
}

function referentialcloseItem(e) {
    $(e).parent().remove();
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////Shoe CostCenters//////////////
function costCenterDataPicker(controlId) {
    getCostCenterTitle($('.hdncostcode', '#div_' + controlId).val(), controlId);

}

function getCostCenterTitle(costCode, controlId) {
    if (isNullOrEmpty(costCode) == true) {
        return '';
    }

    //startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Home/GetCostCenterTitle',
        data: { 'costCode': costCode },
        success: function (result) {
            $('.txtcosttitle', '#div_' + controlId).val(result);
        },
        error: function (result) {
            alert("عملیات بازیابی مرکز هزینه با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function showCostList(el) {
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Home/ShowCostCenter',
        data: null,
        success: function (result) {
            $('.divcostcenters').html(result);
            $('.divcostcenters').dialog({
                modal: true,
                width: 550,
                hieght: 300,
                zIndex: 15000,
                title: 'مراکز هزینه',
                position: ['top', 100],
                buttons: {},
                close: function () {
                    $('.divcostcenters').html('');
                }
            });

            var oDataTable2 = $('#tblCostList').dataTable({
                "bServerSide": true,
                "sAjaxSource": "/Home/CostCostCenterData",
                "bProcessing": true,
                "scrollCollapse": true,
                "aoColumns":
                    [
                        { "sName": "Tot_Cost_Code", "sClass": "hide rowId", "bSearchable": false, "bSortable": false },
                        { "sName": "TOT_COST_DESC", "bSearchable": true, "bSortable": true },
                    {
                        "sName": "schema", "bSearchable": true, "bSortable": true,
                        "mRender": function (data, type, full) {
                            return '<a class="cblue" style="color:blue" href="#" onclick="setSelectdCostCenter(\'' + el + '\',\'' + full[0] + '\',\'' + full[1] + '\');">انتخاب</a>';
                        }
                    }
                    ]
            });

            initialCrudDatatable(oDataTable2);
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function SetTimeSheetSummary(persno, date) {
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/TimeSheet/GetTimeSheetSummary',
        data: { 'persNo': persno, 'date': date },
        success: function (result) {
            $('#lblTimeSheetSummary', '#tbltimesheet_' + date.replace('/', '').replace('/', '').substring(2)).html(result);

            //if ($('tr:not(.traddtimesheet)', '#tbltimesheet_' + date.replace('/', '').replace('/', '').substring(2)).length > 1) {
            //    alert('add');
            //    $('.tblKarkard-selectrowcolor', '#tblKarkard').find('td:first i').css({ 'color': 'orange' });
            //}
            //else {
            //    alert('remove');
            //    $('.tblKarkard-selectrowcolor', '#tblKarkard').find('td:first i').css({ 'color': '#fff' });
            //}
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function setSelectdCostCenter(element, ccode, ctitle) {
    var elId = '#' + element;
    $('.txtcosttitle', elId).val(ctitle.trim());
    $('.hdncostcode', elId).val(ccode);
    $('.divcostcenters').dialog('close')

    //$('.txtcosttitle', elId).attr('size', $('.txtcosttitle', elId).val().length);
    $('.txtcosttitle', elId).autoFit({});
}



function viewFormDoc(id, repname) {
    var win = window.open('/Report/' + repname + '/' + id, '_blank');
    win.focus();

    return;
    startAjax();
    type = typeof type !== 'undefined' ? type : 'post';
    $.ajax({
        type: 'get',
        url: '/Report/Rep1',
        data: { 'id': id },
        success: function (result) {
            $('#divPrintDoc').html(result);
            $('#divPrintDoc').dialog({
                modal: true,
                width: 'auto',
                height: 900,
                zIndex: 15000,
                title: 'پیش نمایش فرم',
                buttons: {},
                open: function () {
                    $('#divPrintDoc').css({ 'padding': '10px 0 0 0', 'overflow': 'hidden', 'font-size: ': '20px' });
                },
                close: function () {
                    $('#divPrintDoc').html('');
                }
            });
        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

function printDoc() {
    $('.formmodalcontainer').css({ 'width': '149mm', 'height': '210mm' });
    printDiv($('.formmodalcontainer'))
    $('.formmodalcontainer').css({ 'width': 'auto', 'height': 'auto' });
}

function cartable_ShowTimeSheetDetails(id, requester, fromReqDoneDate) {
    startAjax();
    $.ajax({
        type: 'get',
        url: '/Cartable/_TimeSheet?year=' + fromReqDoneDate.substring(0, 4) + '&month=' + fromReqDoneDate.substring(0, 7).substring(5) + '&personCode=' + requester,
        success: function (result) {
            $("#divTimeSheetDetails").html(result);
            $("#divTimeSheetDetails").dialog({
                modal: true,
                width: 700,
                title: 'مشاهده فعالیت های  ماه [' + requester + ']',
                //"maxHeight": dHeight,
                position: ['top', 100],
                zIndex: 15000,
                open: function (event, ui) {
                    $(this).css({ 'overflow-x': 'hidden', 'padding': '0' });
                    //$('#divTimeSheetDetails').css('top', '100px');
                },
                close: function (event, ui) {
                    $('.ui-dialog').remove();
                    $('#divTimeSheetDetails').html('');
                },
                buttons: {}
            });

            var oDataTableTimeSheet = $('#tblTimeSheet').dataTable({
                "bServerSide": true,
                "scrollY": "500px",
                "scrollCollapse": true,
                //"columnDefs": [
                //{ "visible": false, "targets": 1 }
                //],
                //"order": [[1, 'asc']],
                "sAjaxSource": "/Cartable/GetDataTimeSheet?year=" + $('#TimeSheet_Year').val() + '&month=' + $('#TimeSheet_Month').val() + '&personCode=' + $('#TimeSheet_PersonCode').val(),
                "bProcessing": true,
                //"drawCallback": function (settings) {
                //    var api = this.api();
                //    var rows = api.rows({ page: 'current' }).nodes();
                //    var last = null;

                //    api.column(1, { page: 'current' }).data().each(function (group, i) {
                //        if (last !== group) {
                //            $(rows).eq(i).before(
                //                '<tr class="group expand"><td colspan="5"><span class="pull-right">' + group + '</span></td></tr>'
                //            );

                //            last = group;
                //        }
                //    });
                //},
                "scrollCollapse": true,
                "aoColumns":
                    [
                        { "sName": "Id", "sClass": "hide rowId", "bSearchable": false, "bSortable": false },
                        { "sName": "Req_Done_Date", "bSearchable": true, "bSortable": true },
                        { "sName": "CompanyProjectTitle", "bSearchable": true, "bSortable": true },
                        { "sName": "Req_Time", "bSearchable": true, "bSortable": true },
                        { "sName": "ActivityType", "bSearchable": true, "bSortable": true },
                        { "sName": "ActivityTitle", "bSearchable": false, "bSortable": false }
                    ]
            });

            initialCrudDatatable(oDataTableTimeSheet);
            //$('#tblTimeSheet tbody').on('click', 'tr.group', function () {

            //    if ($(this).hasClass('expand') == true) {
            //        $(this).nextUntil('.group').addClass('rowcloseup');
            //        $(this).nextUntil('.group').removeClass('rowexpand');
            //        $(this).removeClass('expand');
            //    }
            //    else {
            //        $(this).nextUntil('.group').addClass('rowexpand');
            //        $(this).nextUntil('.group').removeClass('rowcloseup');
            //        $(this).addClass('expand');
            //    }

            //});

        },
        error: function (result) {
            alert("عملیات  با خطا مواجه شد.");
        }
    }).always(function () {
        stopAjax();
    });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
(function ($) {
    var methods = {
        init: function (options) {
            var settings = $.extend(true, {}, $.fn.autoFit.defaults, options);
            var $this = $(this);

            $this.keydown(methods.fit);

            methods.fit.call(this, null);

            return $this;
        },

        fit: function (event) {
            var $this = $(this);

            var val = $this.val().replace(' ', '-');
            var fontSize = $this.css('font-size');
            var padding = $this.outerWidth() - $this.width();
            var contentWidth = $('<span style="font-size: ' + fontSize + '; padding: 0 ' + padding / 2 + 'px; display: inline-block; position: absolute; visibility: hidden;">' + val + '</span>').insertAfter($this).outerWidth();

            $this.width((contentWidth + padding) + 'px');

            return $this;
        }
    };

    $.fn.autoFit = function (options) {
        if (typeof options == 'string' && methods[options] && typeof methods[options] === 'function') {
            return methods[options].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof options === 'object' || !options) {
            // Default to 'init'
            return this.each(function (i, element) {
                methods.init.apply(this, [options]);
            });
        } else {
            $.error('Method ' + options + ' does not exist on jquery.auto-fit.');
            return null;
        }
    };

    $.fn.autoFit.defaults = {};

})(this['jQuery']);


(function ($) {
    $.fn.hasVerticalScrollbar = function () {
        var divnode = this.get(0);
        if (divnode.scrollHeight > divnode.clientHeight)
            return true;

        return false;
    }
})(jQuery);

(function ($) {
    $.fn.hasHorizontalScrollbar = function () {
        var divnode = this.get(0);
        if (divnode.scrollWidth > divnode.clientWidth)
            return true;

        return false;
    }
})(jQuery);


// <![CDATA[
(function ($) {
    $.fn.farsiInput = function () {
        var defaults = {
            changeLanguageKey: 16 /* Scroll lock */
        };
        var options = $.extend(defaults, options);

        var lang = 'fa';

        var keys = new Array(1711, 0, 0, 0, 0, 1608, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1705, 1572, 0, 1548,
                             1567, 0, 1616, 1571, 8250, 0, 1615, 0, 0, 1570, 1577, 0, 0, 0, 1569, 1573, 0, 0, 1614, 1612, 1613, 0, 0,
                             8249, 1611, 171, 0, 187, 1580, 1688, 1670, 0, 1600, 1662, 1588, 1584, 1586, 1740, 1579, 1576, 1604, 1575,
                             1607, 1578, 1606, 1605, 1574, 1583, 1582, 1581, 1590, 1602, 1587, 1601, 1593, 1585, 1589, 1591, 1594, 1592);

        var substituteChar = function (charCode, e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                window.event.keyCode = charCode;
            }
            else {
                insertAtCaret(String.fromCharCode(charCode), e);
            }
        };

        var insertAtCaret = function (str, e) {
            var obj = e.target;
            var startPos = obj.selectionStart;
            var endPos = obj.selectionEnd;
            var scrollTop = obj.scrollTop;
            obj.value = obj.value.substring(0, startPos) + str + obj.value.substring(endPos, obj.value.length);
            obj.focus();
            obj.selectionStart = startPos + str.length;
            obj.selectionEnd = startPos + str.length;
            obj.scrollTop = scrollTop;
            e.preventDefault();
        };

        var keyDown = function (e) {
            var evt = e || window.event;
            var key = evt.keyCode ? evt.keyCode : evt.which;
            if (key == options.changeLanguageKey) {
                lang = (lang == 'en') ? 'fa' : 'en';
                return true;
            }
        };

        var fixYeKeHalfSpace = function (key, evt) {
            var originalKey = key;
            var arabicYeCharCode = 1610;
            var persianYeCharCode = 1740;
            var arabicKeCharCode = 1603;
            var persianKeCharCode = 1705;
            var halfSpace = 8204;

            switch (key) {
                case arabicYeCharCode:
                    key = persianYeCharCode;
                    break;
                case arabicKeCharCode:
                    key = persianKeCharCode;
                    break;
            }

            if (evt.shiftKey && key == 32) {
                key = halfSpace;
            }

            if (originalKey != key) {
                substituteChar(key, evt);
            }
        };

        var keyPress = function (e) {
            if (lang != 'fa')
                return;

            var evt = e || window.event;
            var key = evt.keyCode ? evt.keyCode : evt.which;
            fixYeKeHalfSpace(key, evt);
            var isNotArrowKey = (evt.charCode != 0) && (evt.which != 0);
            if (isNotArrowKey && (key > 38) && (key < 123)) {
                var pCode = (keys[key - 39]) ? (keys[key - 39]) : key;
                substituteChar(pCode, evt);
            }
        }

        return this.each(function () {
            var input = $(this);
            input.keypress(function (e) {
                keyPress(e);
            });
            input.keydown(function (e) {
                keyDown(e);
            });
        });
    };
})(jQuery);
// ]]>
//$(function () {

//    // Setup form validation on the #register-form element
//    $("#register-form").validate({

//        // Specify the validation rules
//        rules: {
//            firstname: "required",
//            lastname: "required",
//            email: {
//                required: true,
//                email: true
//            },
//            password: {
//                required: true,
//                minlength: 5
//            },
//            agree: "required"
//        },
//        // Specify the validation error messages
//        messages: {
//            firstname: "Please enter your first name",
//            lastname: "Please enter your last name",
//            password: {
//                required: "Please provide a password",
//                minlength: "Your password must be at least 5 characters long"
//            },
//            email: "Please enter a valid email address",
//            agree: "Please accept our policy"
//        },

//        submitHandler: function (form) {
//            form.submit();
//        }
//    });
//});


//function showResult(data) {
//    $("#divResult").html(data);
//    //alert(data);
//    $("#divResult").dialog({
//        modal: true,
//        width: 650,
//        open: function (event, ui) {
//            $(this).load('@Url.Action("Result")');
//        },
//        buttons: {
//            "بسته": function () {
//                $(this).dialog("close");
//                jQuery('#divResult').html('');
//            }
//        }
//    });




//function setselectedrowid(e) {
//    var url = $(e).attr('href') + '/' + $('.selected .rowid').val();
//    $(e).attr('href', '');
//    $(e).attr('href', url);
//}
