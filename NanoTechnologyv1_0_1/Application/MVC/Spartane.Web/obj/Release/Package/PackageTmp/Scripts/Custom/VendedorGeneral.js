        function RemoveAttachmentMainFotografia () {
            $("#hdnRemoveFotografia").val("1");
            $("#divAttachmentFotografia").hide();
        }


//Begin Declarations for Foreigns fields for Detalle_Familiar_de_Vendedor MultiRow
var Detalle_Familiar_de_VendedorcountRowsChecked = 0;
function GetDetalle_Familiar_de_Vendedor_ParentescoName(Id) {
    for (var i = 0; i < Detalle_Familiar_de_Vendedor_ParentescoItems.length; i++) {
        if (Detalle_Familiar_de_Vendedor_ParentescoItems[i].Clave == Id) {
            return Detalle_Familiar_de_Vendedor_ParentescoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Familiar_de_Vendedor_ParentescoDropDown() {
    var Detalle_Familiar_de_Vendedor_ParentescoDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Detalle_Familiar_de_Vendedor_ParentescoDropdown);

    for (var i = 0; i < Detalle_Familiar_de_Vendedor_ParentescoItems.length; i++) {
        $('<option />', { value: Detalle_Familiar_de_Vendedor_ParentescoItems[i].Clave, text: Detalle_Familiar_de_Vendedor_ParentescoItems[i].Descripcion }).appendTo(Detalle_Familiar_de_Vendedor_ParentescoDropdown);
    }
    return Detalle_Familiar_de_Vendedor_ParentescoDropdown;
}


function GetInsertDetalle_Familiar_de_VendedorRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Familiar_de_Vendedor_Nombre_del_Familiar Nombre_del_Familiar').attr('id', 'Detalle_Familiar_de_Vendedor_Nombre_del_Familiar_' + index).attr('data-field', 'Nombre_del_Familiar');
    columnData[1] = $(GetDetalle_Familiar_de_Vendedor_ParentescoDropDown()).addClass('Detalle_Familiar_de_Vendedor_Parentesco Parentesco').attr('id', 'Detalle_Familiar_de_Vendedor_Parentesco_' + index).attr('data-field', 'Parentesco');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Familiar_de_Vendedor_Fecha Fecha').attr('id', 'Detalle_Familiar_de_Vendedor_Fecha_' + index).attr('data-field', 'Fecha');
    columnData[3] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Familiar_de_Vendedor_Hora Hora').attr('id', 'Detalle_Familiar_de_Vendedor_Hora_' + index).attr('data-field', 'Hora');
    columnData[4] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Familiar_de_Vendedor_Con_Vida Con_Vida').attr('id', 'Detalle_Familiar_de_Vendedor_Con_Vida_' + index).attr('data-field', 'Con_Vida');
    columnData[5] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Familiar_de_Vendedor_Fotografia_FileUpload Fotografia').attr('id', 'Detalle_Familiar_de_Vendedor_Fotografia_' + index).attr('data-field', 'Fotografia');
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Familiar_de_Vendedor_Edad Edad').attr('id', 'Detalle_Familiar_de_Vendedor_Edad_' + index).attr('data-field', 'Edad');
    columnData[7] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Familiar_de_Vendedor_Estatura Estatura').attr('id', 'Detalle_Familiar_de_Vendedor_Estatura_' + index).attr('data-field', 'Estatura');
    columnData[8] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Familiar_de_Vendedor_Ingresos_Mensuales Ingresos_Mensuales').attr('id', 'Detalle_Familiar_de_Vendedor_Ingresos_Mensuales_' + index).attr('data-field', 'Ingresos_Mensuales');


    initiateUIControls();
    return columnData;
}

function Detalle_Familiar_de_VendedorInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMR()) {
    var prevData = Detalle_Familiar_de_VendedorTable.fnGetData(rowIndex);
    var data = Detalle_Familiar_de_VendedorTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Nombre_del_Familiar: ($('.Nombre_del_FamiliarHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Parentesco: ($('.ParentescoHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Fecha: ($('.FechaHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Hora: ($('.HoraHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Con_Vida: ($('.Con_VidaHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[0]).is(':checked') : ''
        ,FotografiaInfo: { FileName: prevData.FileInfo.FileName, FileId: prevData.FileInfo.FileId, FileSize: prevData.FileInfo.FileSize }
        ,FotografiaDetail: data.childNodes[6].childNodes[0].childNodes.length == 0 ? data.childNodes[6].childNodes[0] : null
        ,Edad: ($('.EdadHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Estatura: ($('.EstaturaHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Ingresos_Mensuales: ($('.Ingresos_MensualesHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Detalle_Familiar_de_VendedorTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Familiar_de_VendedorrowCreationGrid(data, newData, rowIndex);
    Detalle_Familiar_de_VendedorcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMR();
  }
}

function Detalle_Familiar_de_VendedorCancelRow(rowIndex) {
    var prevData = Detalle_Familiar_de_VendedorTable.fnGetData(rowIndex);
    var data = Detalle_Familiar_de_VendedorTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Familiar_de_VendedorTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Familiar_de_VendedorrowCreationGrid(data, prevData, rowIndex);
    }
    Detalle_Familiar_de_VendedorcountRowsChecked--;
}

function GetDetalle_Familiar_de_VendedorFromDataTable() {
    var Detalle_Familiar_de_VendedorData = [];
    var gridData = Detalle_Familiar_de_VendedorTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Familiar_de_VendedorData.push({
                Folio: gridData[i].Folio
                ,Nombre_del_Familiar: gridData[i].Nombre_del_Familiar
                ,Parentesco: gridData[i].Parentesco
                ,Fecha: gridData[i].Fecha
                ,Hora: gridData[i].Hora
                ,Con_Vida: gridData[i].Con_Vida
                ,FotografiaInfo: {
                    FotografiaFileName: gridData[i].FotografiaFileInfo.File_Name, FotografiaFile_Id: gridData[i].FotografiaFileInfo.FileId, FotografiaFileSize: gridData[i].FotografiaFileInfo.File_Size,
                    FotografiaControl: gridData[i].FotografiaFileDetail != null && gridData[i].FotografiaFileDetail.files != null && gridData[i].FotografiaFileDetail.files.length > 0 ? gridData[i].FotografiaFileDetail.files[0] : null,
                    FotografiaRemoveFile: gridData[i].FotografiaFileDetail != null
                }
                ,Edad: gridData[i].Edad
                ,Estatura: gridData[i].Estatura
                ,Ingresos_Mensuales: gridData[i].Ingresos_Mensuales

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Familiar_de_VendedorData.length; i++) {
        if (removedDetalle_Familiar_de_VendedorData[i] != null && removedDetalle_Familiar_de_VendedorData[i].Folio > 0)
            Detalle_Familiar_de_VendedorData.push({
                Folio: removedDetalle_Familiar_de_VendedorData[i].Folio
                ,Nombre_del_Familiar: removedData[i].Nombre_del_Familiar
                ,Parentesco: removedParentescoData[i].Parentesco
                ,Fecha: removedData[i].Fecha
                ,Hora: removedData[i].Hora
                ,Con_Vida: removedData[i].Con_Vida
                ,FotografiaFileInfo: {
                    FotografiaFileName: removedSpartane_FileData[i].FotografiaFileInfo.File_Name, FotografiaFile_Id: removedJobData[i].FotografiaFileInfo.FileId, FotografiaFileSize: removedSpartane_FileData[i].FotografiaFileInfo.File_Size,
                    FotografiaControl: removedSpartane_FileData[i].FotografiaFileDetail != null && removedSpartane_FileData[i].FotografiaFileDetail.files.length > 0 ? removedJobData[i].FotografiaFileDetail.files[0] : null,
                    FotografiaRemoveFile: removedSpartane_FileData[i].FotografiaFileDetail != null
                }
                ,Edad: removedData[i].Edad
                ,Estatura: removedData[i].Estatura
                ,Ingresos_Mensuales: removedData[i].Ingresos_Mensuales

                , Removed: true
            });
    }	

    return Detalle_Familiar_de_VendedorData;
}

function Detalle_Familiar_de_VendedorEditRow(rowIndex) {
    Detalle_Familiar_de_VendedorcountRowsChecked++;
    var Detalle_Familiar_de_VendedorRowElement = "Detalle_Familiar_de_Vendedor_" + rowIndex.toString();
    var prevData = Detalle_Familiar_de_VendedorTable.fnGetData(rowIndex);
    var row = Detalle_Familiar_de_VendedorTable.fnGetNodes(rowIndex, "Detalle_Familiar_de_Vendedor_", "_" + rowIndex);
    row.innerHTML = "";

    var controls = Detalle_Familiar_de_VendedorGetUpdateRowControls(prevData, "Detalle_Familiar_de_Vendedor_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Familiar_de_VendedorRowElement + "')){ Detalle_Familiar_de_VendedorInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Detalle_Familiar_de_VendedorCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
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

function Detalle_Familiar_de_VendedorfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Familiar_de_VendedorTable.fnGetData().length;
    Detalle_Familiar_de_VendedorfnClickAddRow();
    GetAddDetalle_Familiar_de_VendedorPopup(currentRowIndex, 0);
}

function Detalle_Familiar_de_VendedorEditRowPopup(rowIndex) {
    var Detalle_Familiar_de_VendedorRowElement = "Detalle_Familiar_de_Vendedor_" + rowIndex.toString();
    var prevData = Detalle_Familiar_de_VendedorTable.fnGetData(rowIndex);
    GetAddDetalle_Familiar_de_VendedorPopup(rowIndex, 1);
    $('#Nombre_del_FamiliarPop').val(prevData.Nombre_del_Familiar);
    $('#ParentescoPop').val(prevData.Parentesco);
    $('#FechaPop').val(prevData.Fecha);
    $('#HoraPop').val(prevData.Hora);
    $('#Con_VidaPop').prop('checked', prevData.Con_Vida);
    $('#EdadPop').val(prevData.Edad);
    $('#EstaturaPop').val(prevData.Estatura);
    $('#Ingresos_MensualesPop').val(prevData.Ingresos_Mensuales);

    initiateUIControls();
    $('#existingFotografia').html(prevData.FotografiaFileDetail == null && (prevData.FotografiaFileInfo.FileId == null || prevData.FotografiaFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.FotografiaFileInfo, prevData.FotografiaFileDetail));

}

function Detalle_Familiar_de_VendedorAddInsertRow() {
    if (Detalle_Familiar_de_VendedorinsertRowCurrentIndex < 1)
    {
        Detalle_Familiar_de_VendedorinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true
        ,Nombre_del_Familiar: ""
        ,Parentesco: ""
        ,Fecha: ""
        ,Hora: ""
        ,Con_Vida: ""
        ,Fotografia: ""
        ,Edad: ""
        ,Estatura: ""
        ,Ingresos_Mensuales: ""

    }
}

function Detalle_Familiar_de_VendedorfnClickAddRow() {
    Detalle_Familiar_de_VendedorcountRowsChecked++;
    Detalle_Familiar_de_VendedorTable
        .fnAddData(Detalle_Familiar_de_VendedorAddInsertRow(), true);
    initiateUIControls();
}

function Detalle_Familiar_de_VendedorClearGridData() {
    Detalle_Familiar_de_VendedorData = [];
    Detalle_Familiar_de_VendedordeletedItem = [];
    Detalle_Familiar_de_VendedorDataMain = [];
    Detalle_Familiar_de_VendedorDataMainPages = [];
    Detalle_Familiar_de_VendedornewItemCount = 0;
    Detalle_Familiar_de_VendedormaxItemIndex = 0;
    $("#Detalle_Familiar_de_VendedorGrid").DataTable().clear();
    $("#Detalle_Familiar_de_VendedorGrid").DataTable().destroy();
}

//Used to Get Vendedor Information
function GetDetalle_Familiar_de_Vendedor() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Familiar_de_VendedorData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Familiar_de_VendedorData[i].Folio);
        form_data.append('[' + i + '].Nombre_del_Familiar', Detalle_Familiar_de_VendedorData[i].Nombre_del_Familiar);
        form_data.append('[' + i + '].Parentesco', Detalle_Familiar_de_VendedorData[i].Parentesco);
        form_data.append('[' + i + '].Fecha', Detalle_Familiar_de_VendedorData[i].Fecha);
        form_data.append('[' + i + '].Hora', Detalle_Familiar_de_VendedorData[i].Hora);
        form_data.append('[' + i + '].Con_Vida', Detalle_Familiar_de_VendedorData[i].Con_Vida);
        form_data.append('[' + i + '].FotografiaFileInfo.FileId', Detalle_Familiar_de_VendedorData[i].FotografiaFileInfo.File_Id);
        form_data.append('[' + i + '].FotografiaFileInfo.FileName', Detalle_Familiar_de_VendedorData[i].FotografiaFileInfo.File_Name);
        form_data.append('[' + i + '].FotografiaFileInfo.FileSize', Detalle_Familiar_de_VendedorData[i].FotografiaFileInfo.File_Size);
        form_data.append('[' + i + '].FotografiaFileInfo.Control', Detalle_Familiar_de_VendedorData[i].FotografiaFileInfo.Control);
        form_data.append('[' + i + '].FotografiaFileInfo.RemoveFile', Detalle_Familiar_de_VendedorData[i].FotografiaFileInfo.RemoveFile);
        form_data.append('[' + i + '].Edad', Detalle_Familiar_de_VendedorData[i].Edad);
        form_data.append('[' + i + '].Estatura', Detalle_Familiar_de_VendedorData[i].Estatura);
        form_data.append('[' + i + '].Ingresos_Mensuales', Detalle_Familiar_de_VendedorData[i].Ingresos_Mensuales);

        form_data.append('[' + i + '].Removed', Detalle_Familiar_de_VendedorData[i].Removed);
    }
    return form_data;
}
function Detalle_Familiar_de_VendedorInsertRowFromPopup(rowIndex) {
    var prevData = Detalle_Familiar_de_VendedorTable.fnGetData(rowIndex);
    var data = Detalle_Familiar_de_VendedorTable.fnGetNodes(rowIndex);
    var newData = {
        Numero_de_Empleado: prevData.Numero_de_Empleado,
        IsInsertRow: false
        ,Nombre_del_Familiar: $('#Nombre_del_FamiliarPop').val()
        ,Parentesco: $('#dvParentesco').find('select').val()
        ,Fecha: $('#FechaPop').val()
        ,Hora: $('#HoraPop').val()
        ,Con_Vida: $('#Con_VidaPop').is(':checked')
        ,FotografiaFileInfo: { FotografiaFileName: prevData.FotografiaFileInfo.FileName, FotografiaFileId: prevData.FotografiaFileInfo.FileId, FotografiaFileSize: prevData.FotografiaFileInfo.FileSize }
        ,FotografiaFileDetail: $('#Fotografia').find('label').length == 0 ? $('#FotografiaFileInfoPop')[0] : prevData.FotografiaFileDetail
        ,Edad: $('#EdadPop').val()
        ,Estatura: $('#EstaturaPop').val()
        ,Ingresos_Mensuales: $('#Ingresos_MensualesPop').val()

    }

    Detalle_Familiar_de_VendedorTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Familiar_de_VendedorrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Familiar_de_Vendedor-form').modal({ show: false });
    $('#AddDetalle_Familiar_de_Vendedor-form').modal('hide');
}
function Detalle_Familiar_de_VendedorRemoveAddRow(rowIndex) {
    Detalle_Familiar_de_VendedorTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Familiar_de_Vendedor MultiRow


$(function () {
    function Detalle_Familiar_de_VendedorinitializeMainArray(totalCount) {
        if (Detalle_Familiar_de_VendedorDataMain.length != totalCount && !Detalle_Familiar_de_VendedorDataMainInitialized) {
            Detalle_Familiar_de_VendedorDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Familiar_de_VendedorDataMain[i] = null;
            }
        }
    }
    function Detalle_Familiar_de_VendedorremoveFromMainArray() {
        for (var j = 0; j < Detalle_Familiar_de_VendedordeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Familiar_de_VendedorDataMain.length; i++) {
                if (Detalle_Familiar_de_VendedorDataMain[i] != null && Detalle_Familiar_de_VendedorDataMain[i].Id == Detalle_Familiar_de_VendedordeletedItem[j]) {
                    hDetalle_Familiar_de_VendedorDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Familiar_de_VendedorcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Familiar_de_VendedorDataMain.length; i++) {
            data[i] = Detalle_Familiar_de_VendedorDataMain[i];

        }
        return data;
    }
    function Detalle_Familiar_de_VendedorgetNewResult() {
        var newData = copyMainDetalle_Familiar_de_VendedorArray();

        for (var i = 0; i < Detalle_Familiar_de_VendedorData.length; i++) {
            if (Detalle_Familiar_de_VendedorData[i].Removed == null || Detalle_Familiar_de_VendedorData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Familiar_de_VendedorData[i]);
            }
        }
        return newData;
    }
    function Detalle_Familiar_de_VendedorpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Familiar_de_VendedorDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Familiar_de_VendedorDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
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
    $("#ReferenceNumero_de_Empleado").val("0");
    $('#CreateVendedor')[0].reset();
    ClearFormControls();
    $("#Numero_de_EmpleadoId").val("0");
                Detalle_Familiar_de_VendedorClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateVendedor').trigger('reset');
    $('#CreateVendedor').find(':input').each(function () {
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
    var $myForm = $('#CreateVendedor');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Familiar_de_VendedorcountRowsChecked > 0)
    {
        alert('Ha dejado un renglón pendiente de guardar en Familiares')
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblNumero_de_Empleado").text("0");
}
$(document).ready(function () {
    $("form#CreateVendedor").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateVendedor").on('click', '#VendedorCancelar', function () {
        BackToGrid();
    });
	$("form#CreateVendedor").on('click', '#VendedorGuardar', function () {
        EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendVendedorData(function () {
                EjecutarValidacionesDespuesDeGuardar();
                BackToGrid();
            });
    });
	$("form#CreateVendedor").on('click', '#VendedorGuardarYNuevo', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation()) {
            SendVendedorData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();
                getDetalle_Familiar_de_VendedorData();

				EjecutarValidacionesDespuesDeGuardar();
            });
        }
    });
    $("form#CreateVendedor").on('click', '#VendedorGuardarYCopia', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendVendedorData(function (currentId) {
                $("#Numero_de_EmpleadoId").val("0");
                Detalle_Familiar_de_VendedorClearGridData();

                ResetClaveLabel();
                $("#ReferenceNumero_de_Empleado").val(currentId);
                getDetalle_Familiar_de_VendedorData();

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
var VendedorisdisplayBusinessPropery = false;
VendedorDisplayBusinessRuleButtons(VendedorisdisplayBusinessPropery);
function VendedorDisplayBusinessRule() {
    if (!VendedorisdisplayBusinessPropery) {
        $('#CreateVendedor').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = $(this).data('field-id');
            var fieldName = $(this).data('field-name');
            var attribute = $(this).data('attribute');
            mainElementAttributes += '<div class="displayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#VendedorPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.VendedordisplayBusinessPropery').remove();
    }
    VendedorDisplayBusinessRuleButtons(!VendedorisdisplayBusinessPropery);
    VendedorisdisplayBusinessPropery = (VendedorisdisplayBusinessPropery ? false : true);
}
function VendedorDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}
