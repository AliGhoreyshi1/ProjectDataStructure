function AddPartialList(counterId, objectName, action, controller) {

    var counter = document.getElementById(counterId).value;
   

    var route = "";
    $.each(document.getElementById(counterId).attributes, function (index, attribute) {
        if (attribute.name.substring(0, 2) == "dv") {
            route += "&" + attribute.name.substring(2, attribute.name.length) + "=" + attribute.value;
        }
    });

    $.ajax(
        {
            url: "/" + controller + "/" + action + "?Counter=" + counter + route,
            type: 'get',
            dataType: 'html',
            //async: true,
            cache: false,
            success: function (data) {
                var newdiv = document.createElement('div');
                newdiv.innerHTML = data;
                document.getElementById(objectName).appendChild(newdiv);
                Refresh(objectName);
            },
            fail: function (xhr, textStatus, errorThrown) {
                alert('request failed');
            }
        }
    );

    counter++;
    document.getElementById(counterId).value = counter;

}

$(document).ready(function () {
    Refresh();
});

function Refresh(panel) {
    $((panel ? '#' + panel + ' ' : '') + '[datacontrol=Autocomplete]').each(function (index) {
        if ($(this).attr("autocomplete") != "off")
            AddAutocomplete($(this).attr('DataName'), $(this).attr("DataAction"), $(this).attr("DataController"), $(this).attr("DataMinLength"), $(this).attr("DefaultValue"));
    });
}

function AddAutocomplete(name, action, controller, minLength, defaultValue) {

    var route = "";
    var ft = true;
    $.each(document.getElementById('txt' + name).attributes, function (index, attribute) {
        if (attribute.name.substring(0, 2) == "dv") {
            route += (ft ? "?" : "&") + attribute.name.substring(2, attribute.name.length) + "=" + attribute.value;
            ft = false;
        }
    });

    var ac = $("input[id='txt" + name + "']").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/" + controller + "/" + action + route,
                type: "GET",
                //async: true,
                dataType: "json",
                data: { Prefix: request.term, HID: name },
                success: function (data) {

                    response($.map(data, function (item) {

                        return { label: item.label, value: item.label, id: item.value, hid: item.HID/*, html: item.html*/ };
                    }));
                    //$('#' + data[0].HID).trigger('change');

                }
            });
        },
        minLength: minLength,
        select: function (event, ui) {
            //document.getElementById(ui.item.hid).value = ui.item.id;
            var el = document.getElementById(ui.item.hid);
            el.value = ui.item.id;
            PartialHiddenInputValueChanged(el);
        }
    });

    if (defaultValue) {
        $.ajax({
            url: "/" + controller + "/" + action + route,
            type: "GET",
            async: true,
            dataType: "json",
            data: { id: defaultValue, HID: name },
            success: function (data) {
                ac.val(data[0].label);
                document.getElementById(data[0].HID).value = data[0].value;
            }
        });
    }
    //if (hasHtmlDesign)
    //    ac.data("ui-autocomplete")._renderItem = function (ul, item) {
    //        return $("<li></li>")
    //            .data("ui-autocomplete-item", item)
    //            .append(item.html)
    //            .appendTo(ul);
    //    };
}

function onchecked(name) {
    var sum = 0;
    $('#div' + name + ' input:checked').each(function () {
        sum += parseInt($(this).val);
    });
    $('#' + name).val(sum);
}

function AddTypeList(selectTypeList, typeId, defaultValue) {
    //$.ajax({
    //    url: "/Products/TypeList?typeId=" + typeId,
    //    type: 'post',
    //    //dataType: 'json',
    //    success: function (response) {
    //        alert(response);
    //        //$("#" + selectTypeList).css("display", "block");
    //        //$("#" + selectTypeList).empty();
    //        //for (var i = 0; i < response.length; i++) {
    //        //    var value = response[i]['value'];
    //        //    var name = response[i]['name'];
    //        //    $("#" + selectTypeList).append("<option value='" + value + "'>" + name + "</option>");
    //        //}
    //    }
    //});
    $.getJSON("/Products/TypeList?typeId=" + typeId + "&defaultValue=" + defaultValue, function (data) {
        $("#" + selectTypeList).css("display", "block");
        $("#" + selectTypeList).empty();
        for (var i = 0; i < data.length; i++) {
            var dvalue = data[i]['defaultValue'];
            var value = data[i]['value'];
            var name = data[i]['name'];
            $("#" + selectTypeList).append("<option " + ((dvalue) ? "selected=selected" : "") + " value='" + value + "'>" + name + "</option>");
        }
    });
}



//$(document).on('change', '[id ^="storageReceipt.StorageReceiptDetails"][id $="ProductPropertyId"]', function (event) {
//    alert('sdasdasd');
//});

function PartialHiddenInputValueChanged(element) {

    if (element.id != null && element.id.includes("storageReceipt.StorageReceiptDetails") && element.id.includes("ProductPropertyId")) {

        $.ajax({
            url: "/StorageReceipt/_UnitItems?productPropertyId=" + element.value,
            type: "GET",
            async: true,
            success: function (data) {
                document.getElementById(element.id.replace("ProductPropertyId", "UnitId")).innerHTML = data;
            },
            error: function (err) {
                alert(err);
            }
        });
        $.ajax({
            url: "/StorageReceipt/_SearchStorages?productPropertyId=" + element.value,
            type: "GET",
            async: true,
            success: function (data) {
                document.getElementById(element.id.replace("ProductPropertyId", "StorageId")).innerHTML = data;
            },
            error: function (err) {
                alert(err);
            }
        });


    }
    else if (element.id != null && element.id.includes("storageRemittance.StorageRemittanceDetails") && element.id.includes("ProductPropertyId")) {

        $.ajax({
            url: "/StorageRemittance/_UnitItems?productPropertyId=" + element.value,
            type: "GET",
            async: true,
            //dataType: "json",
            //data: { productPropertyId: element.value },
            success: function (data) {
                document.getElementById(element.id.replace("ProductPropertyId", "UnitId")).innerHTML = data;
            },
            error: function (err) {
                alert(err);
            }
        });


    }
}
$(document).ready(function () {
    $("input[type=checkbox]").change(function () {

        if ($(this).attr("id")  != null && $(this).attr("id").indexOf("checkall") >= 0) {
            var chd = false;
            if ($(this).prop("checked")) {
                chd = true;
            }

            $('input[name*=".Selected"]').each(function (index, element) {
                $(element).val(chd);
                $(element).prop('checked', chd);
            });
        }
    });
});


//$('input[id ^="storageReceipt.StorageReceiptDetails"]').attrchange({
//    trackValues: true,
//    callback: function (event) {
//        alert($(this).val());
//    }
//});

