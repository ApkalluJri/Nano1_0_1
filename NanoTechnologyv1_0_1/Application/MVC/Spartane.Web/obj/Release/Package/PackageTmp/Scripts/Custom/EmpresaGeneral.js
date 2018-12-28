

//Begin Declarations for Foreigns fields for Detalle_Sucursal_de_Empresa MultiRow
var Detalle_Sucursal_de_EmpresacountRowsChecked = 0;
function GetDetalle_Sucursal_de_Empresa_CiudadName(Id) {
    for (var i = 0; i < Detalle_Sucursal_de_Empresa_CiudadItems.length; i++) {
        if (Detalle_Sucursal_de_Empresa_CiudadItems[i].Clave == Id) {
            return Detalle_Sucursal_de_Empresa_CiudadItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Sucursal_de_Empresa_CiudadDropDown() {
    var Detalle_Sucursal_de_Empresa_CiudadDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Detalle_Sucursal_de_Empresa_CiudadDropdown);

    for (var i = 0; i < Detalle_Sucursal_de_Empresa_CiudadItems.length; i++) {
        $('<option />', { value: Detalle_Sucursal_de_Empresa_CiudadItems[i].Clave, text: Detalle_Sucursal_de_Empresa_CiudadItems[i].Nombre }).appendTo(Detalle_Sucursal_de_Empresa_CiudadDropdown);
    }
    return Detalle_Sucursal_de_Empresa_CiudadDropdown;
}


function GetInsertDetalle_Sucursal_de_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Sucursal_de_Empresa_Nombre Nombre').attr('id', 'Detalle_Sucursal_de_Empresa_Nombre_' + index).attr('data-field', 'Nombre');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Sucursal_de_Empresa_Direccion Direccion').attr('id', 'Detalle_Sucursal_de_Empresa_Direccion_' + index).attr('data-field', 'Direccion');
    columnData[2] = $(GetDetalle_Sucursal_de_Empresa_CiudadDropDown()).addClass('Detalle_Sucursal_de_Empresa_Ciudad Ciudad').attr('id', 'Detalle_Sucursal_de_Empresa_Ciudad_' + index).attr('data-field', 'Ciudad');


    initiateUIControls();
    return columnData;
}

function Detalle_Sucursal_de_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMR()) {
    var prevData = Detalle_Sucursal_de_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Sucursal_de_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Nombre: ($('.NombreHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Direccion: ($('.DireccionHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Ciudad: ($('.CiudadHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Detalle_Sucursal_de_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Sucursal_de_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Sucursal_de_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMR();
  }
}

function Detalle_Sucursal_de_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Sucursal_de_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Sucursal_de_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Sucursal_de_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Sucursal_de_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
    Detalle_Sucursal_de_EmpresacountRowsChecked--;
}

function GetDetalle_Sucursal_de_EmpresaFromDataTable() {
    var Detalle_Sucursal_de_EmpresaData = [];
    var gridData = Detalle_Sucursal_de_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Sucursal_de_EmpresaData.push({
                Folio: gridData[i].Folio
                ,Nombre: gridData[i].Nombre
                ,Direccion: gridData[i].Direccion
                ,Ciudad: gridData[i].Ciudad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Sucursal_de_EmpresaData.length; i++) {
        if (removedDetalle_Sucursal_de_EmpresaData[i] != null && removedDetalle_Sucursal_de_EmpresaData[i].Folio > 0)
            Detalle_Sucursal_de_EmpresaData.push({
                Folio: removedDetalle_Sucursal_de_EmpresaData[i].Folio
                ,Nombre: removedData[i].Nombre
                ,Direccion: removedData[i].Direccion
                ,Ciudad: removedCiudadData[i].Ciudad

                , Removed: true
            });
    }	

    return Detalle_Sucursal_de_EmpresaData;
}

function Detalle_Sucursal_de_EmpresaEditRow(rowIndex) {
    Detalle_Sucursal_de_EmpresacountRowsChecked++;
    var Detalle_Sucursal_de_EmpresaRowElement = "Detalle_Sucursal_de_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Sucursal_de_EmpresaTable.fnGetData(rowIndex);
    var row = Detalle_Sucursal_de_EmpresaTable.fnGetNodes(rowIndex, "Detalle_Sucursal_de_Empresa_", "_" + rowIndex);
    row.innerHTML = "";

    var controls = Detalle_Sucursal_de_EmpresaGetUpdateRowControls(prevData, "Detalle_Sucursal_de_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Sucursal_de_EmpresaRowElement + "')){ Detalle_Sucursal_de_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Detalle_Sucursal_de_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('.' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td>').appendTo(row));
        }
    }

    initiateUIControls();
}

function Detalle_Sucursal_de_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Sucursal_de_EmpresaTable.fnGetData().length;
    Detalle_Sucursal_de_EmpresafnClickAddRow();
    GetAddDetalle_Sucursal_de_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Sucursal_de_EmpresaEditRowPopup(rowIndex) {
    var Detalle_Sucursal_de_EmpresaRowElement = "Detalle_Sucursal_de_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Sucursal_de_EmpresaTable.fnGetData(rowIndex);
    GetAddDetalle_Sucursal_de_EmpresaPopup(rowIndex, 1);
    $('#NombrePop').val(prevData.Nombre);
    $('#DireccionPop').val(prevData.Direccion);
    $('#CiudadPop').val(prevData.Ciudad);

    initiateUIControls();

}

function Detalle_Sucursal_de_EmpresaAddInsertRow() {
    if (Detalle_Sucursal_de_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Sucursal_de_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true
        ,Nombre: ""
        ,Direccion: ""
        ,Ciudad: ""

    }
}

function Detalle_Sucursal_de_EmpresafnClickAddRow() {
    Detalle_Sucursal_de_EmpresacountRowsChecked++;
    Detalle_Sucursal_de_EmpresaTable
        .fnAddData(Detalle_Sucursal_de_EmpresaAddInsertRow(), true);
    initiateUIControls();
}

function Detalle_Sucursal_de_EmpresaClearGridData() {
    Detalle_Sucursal_de_EmpresaData = [];
    Detalle_Sucursal_de_EmpresadeletedItem = [];
    Detalle_Sucursal_de_EmpresaDataMain = [];
    Detalle_Sucursal_de_EmpresaDataMainPages = [];
    Detalle_Sucursal_de_EmpresanewItemCount = 0;
    Detalle_Sucursal_de_EmpresamaxItemIndex = 0;
    $("#Detalle_Sucursal_de_EmpresaGrid").DataTable().clear();
    $("#Detalle_Sucursal_de_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresa Information
function GetDetalle_Sucursal_de_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Sucursal_de_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Sucursal_de_EmpresaData[i].Folio);
        form_data.append('[' + i + '].Nombre', Detalle_Sucursal_de_EmpresaData[i].Nombre);
        form_data.append('[' + i + '].Direccion', Detalle_Sucursal_de_EmpresaData[i].Direccion);
        form_data.append('[' + i + '].Ciudad', Detalle_Sucursal_de_EmpresaData[i].Ciudad);

        form_data.append('[' + i + '].Removed', Detalle_Sucursal_de_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Sucursal_de_EmpresaInsertRowFromPopup(rowIndex) {
    var prevData = Detalle_Sucursal_de_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Sucursal_de_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false
        ,Nombre: $('#NombrePop').val()
        ,Direccion: $('#DireccionPop').val()
        ,Ciudad: $('#dvCiudad').find('select').val()

    }

    Detalle_Sucursal_de_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Sucursal_de_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Sucursal_de_Empresa-form').modal({ show: false });
    $('#AddDetalle_Sucursal_de_Empresa-form').modal('hide');
}
function Detalle_Sucursal_de_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Sucursal_de_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Sucursal_de_Empresa MultiRow


$(function () {
    function Detalle_Sucursal_de_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Sucursal_de_EmpresaDataMain.length != totalCount && !Detalle_Sucursal_de_EmpresaDataMainInitialized) {
            Detalle_Sucursal_de_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Sucursal_de_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Sucursal_de_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Sucursal_de_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Sucursal_de_EmpresaDataMain.length; i++) {
                if (Detalle_Sucursal_de_EmpresaDataMain[i] != null && Detalle_Sucursal_de_EmpresaDataMain[i].Id == Detalle_Sucursal_de_EmpresadeletedItem[j]) {
                    hDetalle_Sucursal_de_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Sucursal_de_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Sucursal_de_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Sucursal_de_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Sucursal_de_EmpresagetNewResult() {
        var newData = copyMainDetalle_Sucursal_de_EmpresaArray();

        for (var i = 0; i < Detalle_Sucursal_de_EmpresaData.length; i++) {
            if (Detalle_Sucursal_de_EmpresaData[i].Removed == null || Detalle_Sucursal_de_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Sucursal_de_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Sucursal_de_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Sucursal_de_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Sucursal_de_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' readonly='readonly'>";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control' readonly='readonly' data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field) {
    
    var dataMain = data == null ? "Select" : data;
    
    return "<select class='" + field + " form-control' style='width: 250px'><option>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceClave").val("0");
    $('#CreateEmpresa')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
                Detalle_Sucursal_de_EmpresaClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateEmpresa').trigger('reset');
    $('#CreateEmpresa').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateEmpresa');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Sucursal_de_EmpresacountRowsChecked > 0)
    {
        alert('Ha dejado un renglón pendiente de guardar en Sucursales')
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateEmpresa").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateEmpresa").on('click', '#EmpresaCancelar', function () {
        BackToGrid();
    });
	$("form#CreateEmpresa").on('click', '#EmpresaGuardar', function () {
        EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendEmpresaData(function () {
                EjecutarValidacionesDespuesDeGuardar();
                BackToGrid();
            });
    });
	$("form#CreateEmpresa").on('click', '#EmpresaGuardarYNuevo', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation()) {
            SendEmpresaData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();
                getDetalle_Sucursal_de_EmpresaData();

				EjecutarValidacionesDespuesDeGuardar();
            });
        }
    });
    $("form#CreateEmpresa").on('click', '#EmpresaGuardarYCopia', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendEmpresaData(function (currentId) {
                $("#ClaveId").val("0");
                Detalle_Sucursal_de_EmpresaClearGridData();

                ResetClaveLabel();
                $("#ReferenceClave").val(currentId);
                getDetalle_Sucursal_de_EmpresaData();

				EjecutarValidacionesDespuesDeGuardar();
            });
    });
});
var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}
function setRequired(elementNumber, element, elementType) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        childElementObject[elementNumber].IsRequired = (childElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!childElementObject[elementNumber].IsVisible && childElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (childElementObject[elementNumber].IsReadOnly && childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && childElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsVisible = (childElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    }
}
function setReadOnly(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && !childElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsReadOnly = (childElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    }
}
function setDefaultValue(elementNumber, element, elementType) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Default Value');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Help Text');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue() {
    //debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            childElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            childElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(elementNumber) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (childElementObject[elementNumber].IsRequired == true ? "Required" : "Not Required") + '" onclick="setRequired(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (childElementObject[elementNumber].IsVisible == true ? "Visible" : "In Visible") + '" onclick="setVisible(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (childElementObject[elementNumber].IsReadOnly == true ? "Disabled" : "Enabled") + '" onclick="setReadOnly(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + elementNumber.toString() + '" class="defaultValueClick" title="' + (childElementObject[elementNumber].DefaultValue) + '" onclick="setDefaultValue(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].DefaultValue != '' && childElementObject[elementNumber].DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + elementNumber.toString() + '" class="helpTextClick" title="' + (childElementObject[elementNumber].HelpText) + '" onclick="setHelpText(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].HelpText != '' && childElementObject[elementNumber].HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}
var EmpresaisdisplayBusinessPropery = false;
EmpresaDisplayBusinessRuleButtons(EmpresaisdisplayBusinessPropery);
function EmpresaDisplayBusinessRule() {
    if (!EmpresaisdisplayBusinessPropery) {
        $('#CreateEmpresa').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = $(this).data('field-id');
            var fieldName = $(this).data('field-name');
            var attribute = $(this).data('attribute');
            mainElementAttributes += '<div class="displayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#EmpresaPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.EmpresadisplayBusinessPropery').remove();
    }
    EmpresaDisplayBusinessRuleButtons(!EmpresaisdisplayBusinessPropery);
    EmpresaisdisplayBusinessPropery = (EmpresaisdisplayBusinessPropery ? false : true);
}
function EmpresaDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}
