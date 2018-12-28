
$('.modal').on('hidden.bs.modal', function (e) {

    if ($('.modal').hasClass('in')) {
        $('body').addClass('modal-open');
    }
    if (!$('.modal').is(':visible')) {
        $('body').removeClass('modal-open');
    }

});

$(function () {
    // display focus in and out as per validation
    $('.inputclientrequired').blur(function () {
        if ($(this).val() == '') {
            $(this).parent().closest('.form-group').addclass('has-error');
        } else {
            $(this).parent().closest('.form-group').removeclass('has-error');
        }
    });
});

function setDynamicRenderElement() {
    // display focus in and out as per validation
    $('.inputClientRequired').blur(function () {
        if ($(this).val() == '') {
            $(this).addClass('has-error');
        } else {
            $(this).removeClass('showRequired');
        }
    });
}
function setInputEntityAttributes(inpuElementArray, selectorType, elementType) {
    for (var i = 0; i < inpuElementArray.length; i++) {
        var element = $('' + selectorType + inpuElementArray[i].inputId);
        if (element != undefined) {
            //if (element.val() != undefined) {
                if (!inpuElementArray[i].IsVisible) {
                    if (elementType == 0) {
                        $('' + selectorType + inpuElementArray[i].inputId + 'Header').hide()
                        element.parent().hide();
                    } else {
                        element.parent().closest('.form-group').hide();
                    }
                }
                if (inpuElementArray[i].IsRequired) {
                    element.addClass('inputClientRequired');
                    //element.after('<input type="hidden" value="' + inpuElementArray[i].selectDefaultValidationValue + '" />');
                }
                else
                {
                    element.removeClass('inputClientRequired');
                }
                if (element.val() != undefined) {
                    if (inpuElementArray[i].DefaultValue != '') {
                        switch (inpuElementArray[i].inputType.toString().toLowerCase()) {
                            case 'text':
                                if (element.val() == '' || element.val().trim() == 0) {
                                    element.val(inpuElementArray[i].DefaultValue);
                                }
                                break;
                            case 'select':
                                if ($("" + selectorType + inpuElementArray[i].inputId + " option[value='" + inpuElementArray[i].DefaultValue + "']").length > 0) {
                                    element.val(inpuElementArray[i].DefaultValue);
                                }
                                break;
                            case 'file':
                                break;
                            case 'checkbox':
                                element.attr('checked', true);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (inpuElementArray[i].HelpText != '') {
                    element.attr('title', inpuElementArray[i].HelpText);
                }
                if (inpuElementArray[i].IsReadOnly) {
                    element.attr('disabled', true);
                }
            }
        //}
    }
}


function htmlEncode(html) {
    return document.createElement('a').appendChild(
        document.createTextNode(html)).parentNode.innerHTML;
};

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}

function closeOpenAllNodes(jsTree) {
    jsTree.jstree('open_all');
    jsTree.jstree('close_all');
}



function checkClientValidate(formSelector) {
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
        if (this.nodeName.toString().toLowerCase() == 'select') {
            if ($(this).val() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                $(this).focus();
                elementValid = false;
            } else {
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
        else if (this.nodeName.toString().toLowerCase() == 'textarea' && $(this).data('type') == 'ckEditor') {          
            if (CKEDITOR.instances[this.name].getData() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                $(this).focus();
                elementValid = false;
            } else {
                $("textarea#" + this.name).val(htmlEncode(CKEDITOR.instances[this.name].getData()));
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }

        else {
            if ($(this).val() == '' || $(this).val() ==null) {
                $(this).parent().closest('.form-group').addClass('has-error');
                $(this).focus();
                elementValid = false;
            } else {
                //$(this).removeClass('showRequired');
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
    });
    return elementValid;
}
function dynamicFieldValidation(formSelector) {
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
		if($(this).css('display') != 'none')
		{
			if (this.nodeName.toString().toLowerCase() == 'select') {
				if ($(this).val() == '' || $(this).val() == $(this).next().val()) {
					$(this).addClass('showRequired');
					$(this).focus();
					elementValid = false;
				} else {
					$(this).removeClass('showRequired');
				}
			} else {
				if ($(this).val() == '') {
					$(this).addClass('showRequired');
					$(this).focus();
					elementValid = false;
				} else {
					$(this).removeClass('showRequired');
				}
			}
		}
    });

    setDynamicRenderElement();
    return elementValid;
}

$('body').on('keydown', '.inputNumber', function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

function ajaxindicatorstart(text) {
    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {
        jQuery('body').append('<div id="resultLoading" class="pace pace-active"><div class="bg"><div class="loading-spinner"><div class="sk-spinner sk-spinner-chasing-dots"><div class="sk-dot1"></div><div class="sk-dot2"></div></div></div></div></div>');
    }
    jQuery('#resultLoading').css({
        'width': '100%',
        'height': '100%',
        'position': 'fixed',
        'z-index': '10000000',
        'top': '0',
        'left': '0',
        'right': '0',
        'bottom': '0',
        'margin': 'auto',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').css({
        'background': 'rgba(0, 0, 0, .7) none repeat scroll 0 0',
        'width': '100%',
        'height': '100%',
        'position': 'absolute',
        'top': '0',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeIn(300);
    jQuery('body').css('cursor', 'wait');
}

function ajaxindicatorstop() {
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeOut(300);
    jQuery('body').css('cursor', 'default');
}

//LOADING
//jQuery(document).ajaxStart(function () {
//    ajaxindicatorstart('loading data.. please wait..');
//}).ajaxStop(function () {
//    //hide ajax indicator
//    ajaxindicatorstop();
//});


function ReplaceFLD(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
		valueOfVar = '';
        nameOfVar = nameOfTable + matches[1] + rowIndex;
		if($('#' + nameOfVar).is('input:checkbox'))
		{
			valueOfVar = $('#' + nameOfVar).is(':checked');
		}
		if($('#' + nameOfVar).is('input:text'))
		{			
			valueOfVar = $('#' + nameOfVar).val();
		}
		if($('#' + nameOfVar).is('select'))
		{			
			valueOfVar = $('#' + nameOfVar).val();
		}
		if($('#' + nameOfVar).is('input:text') && $('#' + nameOfVar).parent().id == 'datetimepicker1' )
		{
			valueOfVar = $('#' + nameOfVar).datepicker({ dateFormat: 'dd-mm-yy' }).val();
		}
		if($.trim(valueOfVar) == '' || valueOfVar == undefined)
		{
			valueOfVar = null;
		}
        text = text.replace(matches[0], valueOfVar);
		text = text.replace("\'null\'", '');
		text = text.replace("\'null\'", "\'\'");
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceFLDP(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDP\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = $('#' + nameOfVar).val();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceFLDD(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = nameOfTable + matches[1] + rowIndex;
        valueOfVar = $('#' + nameOfVar).text();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

//For HTML field
function ReplaceFLDH(text) {
    var regExp = /FLDH\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = CKEDITOR.instances[nameOfVar].getData();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceGLOBAL(text) {
    var nameOfVar;
    var valueOfVar;
    var regExp = /GLOBAL\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = GetSessionValue(nameOfVar);
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function EvaluaQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQuery",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    //return res;
    return TryParseInt(res, res);
}
function DecodifyText(text, rowIndex, nameOfTable) {
    text = ReplaceFLD(text, rowIndex, nameOfTable);
    text = ReplaceFLDD(text, rowIndex, nameOfTable);
    text = ReplaceGLOBAL(text);
    return text;
}


function GetSessionValue(name) {
    var res = '';
    $.ajax({
        url: url_content + "Frontal/General/GetSessionVar?name=" + name,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error buscando variable", "error");
        }
    });
    return res;
}

function CreateSessionVar(name, value) {
    $.ajax({
        url: url_content + "Frontal/General/AddSessionVar?name=" + name + "&val=" + value,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return result;
        },
        error: function (result) {
            showNotification("Error creando variable", "error");
        }
    });
}

//TextBox(Texto, Fecha, Hora)
function ShowHideTextbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableTextbox(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueTextbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}

//DropDown
function ShowHideDropdown(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableDropdown(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueDropdown(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}
//HTML Editor
function ShowHideHTMLEditor(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableHTMLEditor(idField, trueOrFalse) {
    CKEDITOR.instances['JobDescription'].config.readOnly = !trueOrFalse;
}
function DefaultValueHTMLEditor(idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            CKEDITOR.instances[idField].insertText(result);
        });
    }
    else {
        CKEDITOR.instances[idField].insertText(val);
    }
}
//CheckBox
function ShowHideCheckbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableCheckbox(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', trueOrFalse);
}
function DefaultValueCheckbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).prop('checked', result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).prop('checked', val);
    }
}
//AutoComplete
function ShowHideAutocomplete(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableAutocomplete(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', !trueOrFalse);
}
function DefaultValueAutocomplete(idForm, idField, valId, text/*Aqui deberia ir la query*/, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).append($('<option>', {
                value: valId,
                text: result
            }));
            $("form#" + idForm + " #" + idField).val(valId).trigger("change");
        });
    }
    else {
        $("form#" + idForm + " #" + idField).append($('<option>', {
            value: valId,
            text: text
        }));
        $("form#" + idForm + " #" + idField).val(valId).trigger("change");
    }
}
//RadioButton
function ShowHideRadiobutton(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableRadiobutton(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueRadiobutton(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).filter('[value="' + result + '"]').attr('checked', true);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).filter('[value="' + val + '"]').attr('checked', true);
    }
}

//FileUpload
function ShowHideFileupload(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableFileupload(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField + "File").prop('disabled', disabledOrEmpty);
}
function DefaultValueFileupload(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            getFileNameById(result, function (name) {
                $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
            });
            $("form#" + idForm + " #Default" + idField).val(result);
        });
    }
    else {
        getFileNameById(val, function (name) {
            $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
        });
        $("form#" + idForm + " #Default" + idField).val(val);
    }
}

function getFileNameById(id, callbak) {
    $.ajax({
        url: url_content + "Frontal/General/GetFileNameById?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return callbak(result);
        },
        error: function (result) {
            showNotification("Error buscando file", "error");
        }
    });
}

//GRID RULES

//Show/Hide es el mismo metodo para cualquier columna
function ShowHideGridColumn(idForm, idField, blockOrNone) {
    $("#" + idForm + " ." + idField + 'Header').css('display', blockOrNone);
}

//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridTextbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridCheckbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridDropdown(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridAutomcomplete(idForm, idField, trueOrFalse) {
    $("#" + idForm + " ." + idField).prop('disabled', !trueOrFalse);
}

function SetRequiredToControl(id) {
	 $('#' + id).addClass('inputClientRequired');
	/*
    ReadScriptSettings(function () {
        $.each(mainElementObject, function (i) {
            if (mainElementObject[i].inputId == id) {
                mainElementObject[i].IsRequired = true;
            }
        });
        setInputEntityAttributes(mainElementObject, "#", 1);
        SaveSettingsWithoutReload();
    });*/

}

function SetNotRequiredToControl(id) {
	 $('#' + id).removeClass('inputClientRequired');
	/*
    ReadScriptSettings(function () {
        $.each(mainElementObject, function (i) {
            if (mainElementObject[i].inputId == id) {
                mainElementObject[i].IsRequired = false;
            }
        });
        setInputEntityAttributes(mainElementObject, "#", 1);
        SaveSettingsWithoutReload();
    });*/
}

function SendEmail(to, subject, body) {
    to = ReplaceGLOBAL(to);
    subject = ReplaceFLD(subject);
    subject = ReplaceFLDD(subject);
    body = ReplaceFLD(body);
    body = ReplaceFLDD(body);
    body = ReplaceFLDH(body);

    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}

function SendEmailQuery(subject, to, body, rowIndex, nameOfTable) {
   
    subject = ReplaceFLD(subject, rowIndex, nameOfTable);
    subject = ReplaceFLDD(subject, rowIndex, nameOfTable);
    body = ReplaceFLD(body, rowIndex, nameOfTable);
    body = ReplaceFLDD(body, rowIndex, nameOfTable);
    body = ReplaceFLDH(body);
    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}


function fillMRFromQuery(nameOfTable, query) {
    var res = '';
    query = ReplaceFLD(query, '', '');
    query = ReplaceFLDD(query, '', '');
    query = ReplaceGLOBAL(query);
    var data = {
        query: query
    }

    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            var table = nameOfTable + 'Table';
            var data = eval(table);
            data.fnClearTable();
            $.each(jsonObj, function (index, element) {
                data.fnAddData(element, true);
                jQuery.globalEval(nameOfTable + 'EditRow(' + index + ')');
                jQuery.globalEval(nameOfTable + 'InsertRow(' + index + ')');
            });
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}


function EvaluaQueryDictionary(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryDictionary",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}
function ReplaceQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);

    return query;
    //return TryParseInt(res, res);
}


function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }}
    if (retValue=="null"){retValue="";}
    return retValue;
}

function GetListOfColumns(query)
{
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            res = jsonObj['Root']['Data'];
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}

function RemoveRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
}

function AddRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired-hide')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
}

function GetValueByControlType(control, nameOfTable,rowIndex )
{
	var valueOfVar='';
	if(control.is('input:checkbox'))
	{
		valueOfVar = control.is(':checked');
	}
	if(control.is('input:text') || control.is('textarea'))
	{			
		valueOfVar = control.val();
	}
	if(control.is('select'))
	{			
		valueOfVar = control.val();
	}
	if(control.is('input:text') && control.parent().id == 'datetimepicker1' )
	{
		valueOfVar = control.datepicker({ dateFormat: 'dd-mm-yy' }).val();
	}
		if(control.is('td') )
	{
		control  = control[0].id.replace(nameOfTable,'').replace(rowIndex,'');
		rowIndex  = rowIndex.replace('_', '');
		nameOfTable = nameOfTable.slice(0,-1) + 'Table';
		var data = eval(nameOfTable);
		valueOfVar =data.fnGetData(rowIndex)[control];
	}
	return valueOfVar.toString();
}

function SetDefectValue(control, val) {
    var c = nameOfTable + control + rowIndex;
    if ($('#' + c).is('input:checkbox')) {
        $('#' + c).prop('checked', val == 'true');
    }
    else {
        $('#' + c).val(val);
    }
}

function GetFile(id) {
    var res = {
        id: 0,
        name: '',
        url: ''
    };
    $.ajax({
        url: url_content + "Frontal/General/GetSpartanFile?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            var description = result.Description;
            var id = result.File_Id;
            var url = url_content + 'Frontal/Client_Registration/GetFile?id=' + id;
            res.id = id;
            res.name = description;
            res.url = url;
        },
        error: function (result) {
            showNotification("Error obteniendo File", "error");
        }
    });
    return res;
}

function AsignarValor(nameOfControl, val) {
    var control = $('#' + nameOfControl);
    var controlFile = $('#' + nameOfControl + 'File');
    if (controlFile.length) {
        var file = GetFile(val)
        if ($('#' + nameOfControl).length) {
            $('#' + nameOfControl).val(587);
        }
        else {
            controlFile.parent().append('<input type="hidden" id="' + nameOfControl + '" name="' + nameOfControl + '" value="' + file.id + '" />')
        }
        controlFile.parent().append('<a href="' + file.url + '">' + file.name + '</a>');
    }
    else {
        if (control.is('input:checkbox')) {
            control.prop('checked', val);
        }
        if (control.is('input:text')) {
            control.val(val);
        }
        if (control.is('select')) {
            control.val(val);
        }
    }
}

