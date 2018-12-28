var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
    
//NEWBUSINESSRULE_NONE//

});
function EjecutarValidacionesAlComienzo() {
    for (var i = 0; i < Spartan_Traduction_DetailTable.fnGetData().length; i++) {
        $('.Spartan_Traduction_Detail_' + i + ' > td > a.edit').click();
        $('#Spartan_Traduction_Detail_Concept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Detail_IdConcept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Detail_Original_Text_' + i).prop('disabled', 'disabled');

        $('#LanguageT').prop('disabled', 'disabled');
        $('#Object_Type').prop('disabled', 'disabled');
        $('#ObjectT').prop('disabled', 'disabled');
    }
//NEWBUSINESSRULE_SCREENOPENING//

}
function EjecutarValidacionesAntesDeGuardar(){
    var result = true;
    for (var i = 0; i < Spartan_Traduction_DetailTable.fnGetData().length; i++) {
        Spartan_Traduction_DetailInsertRow(i);
    }
//NEWBUSINESSRULE_BEFORESAVING//

    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//

}

function EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_Traduction_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_Traduction_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_Traduction_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_Traduction_Detail//
    return result;
}


