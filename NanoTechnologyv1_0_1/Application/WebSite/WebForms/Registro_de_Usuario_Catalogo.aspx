﻿<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
    AutoEventWireup="true" CodeFile="Registro_de_Usuario_Catalogo.aspx.cs" Inherits="WebForms.Registro_de_Usuario_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de Registro de Usuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo" TagPrefix="uc1" %>
<%@ Register Src="~/FormsSystem/TTbuttonLista.ascx" TagName="TTbuttonLista" TagPrefix="uc2" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogoMulti.ascx" TagName="TTbuttonCatalogoMulti" TagPrefix="uc3" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogoMultiEdit.ascx" TagName="TTbuttonCatalogoMultiEdit" TagPrefix="uc4" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogoMultiConsult.ascx" TagName="TTbuttonCatalogoMultiConsult" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../JSScripts/ajaxupload.js" type="text/javascript"></script>
<script type="text/javascript">
    function clearWord() {
        userWord = "";
    }
    var userWord = "";
    function TrapKey(obj, e) {
        thekey = String.fromCharCode(event.keyCode);
        userWord += thekey;
        for (var i = 0; i < obj.options.length; i++) {
            var txt = obj.options[i].text.toUpperCase();
            if (txt.indexOf(userWord) != -1) {
                obj.options[i].selected = true;
                obj.options[i].focus();
                break;
            }
        }
        setTimeout("clearWord()", 3000)
    }

        function validatipo(file, ext, estatus) {
            if (!(ext && /^(png|jpg|txt|doc|docx|zip|rar|pdf|xls|xlsx|pdf|mpp|xml|ppt|pptx)$/i.test(ext))) {
                alert('Formato no valido.');
                return false;
                }
                $(estatus).html("Subiendo...");
            }
            function deleteFile(objfile, key) {
             $.ajax({ url: '../TempFiles/FileUploadHandler.upload?del=' + $(objfile).parent().find('span').text() });
             var upload = $(objfile).parent().children()[1].id;
             var ids = upload.replace("uploadFile", "").replace(key, "").split("grdMulti");
             var label = $('#' + upload).parent().find('span')[0];
             $('#' + upload).css("display", "block");
             $($('#' + upload).parent().children()[5]).hide();
             label.innerText = ''; 
             //processText('Modify', ids[1], label.id, key, '', ids[0]) 
             EnviaDato('Modify', ids[1], label.id, key, '', ids[0]); 
             //return false; 
            }
            function completeFile(file, estatus, lista, upload, imagen, key ) {
                $('#' + upload).css("display", "none");
                $($('#' + upload).parent().children()[5]).show();
                var ids = upload.replace("uploadFile", "").replace(key, "").split("grdMulti");
                var label = $('#' + upload).parent().find('span')[0];
                label.innerText = file;

                EnviaDato('Modify', ids[1], label.id, key, file, ids[0]); 
                //processText('Modify', ids[1], label.id, key, file, ids[0]) 
            }

            function clickverarchivo(objfile) {
                var value = '1';
                $.ajax({
                    type: "POST",
                    url: "Registro_de_Usuario_Catalogo.aspx/SetSession",
                    data: '{value: "' + value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function(response) {
                        alert(response.d);
                    }
                });
                eval($(objfile).parent().find('a').url());
            }

            function OnSuccess(response) {
                
            }
    </script>
    <script type="text/javascript">

    function RadComboSelectedIndexChangedPage(sender, e) {
        var attribs = $get(sender.get_id());
        var item = e.get_item();
        if (item != null) {

            //sender.set_text(item.get_value() + ' -  ' + item.get_text());
            sender.set_text(item.get_text());
            SetValue(sender,attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), item.get_value(), attribs.getAttribute('Field'));
        }
        var atributos = $get(sender.get_id());
        EjecutaRN(atributos.getAttribute('DTid'), atributos.getAttribute('Proceso'), sender.get_id());
    }

    function OnChangeDateInputMultiPage(sender, e) {
        OnChangeDatePage(sender, e.get_newValue(), false);
    }

    function OnChangeDatePage(sender, value, isBussines) {
        var currentTime, hours, minutes, seconds, inputValue;
        if (value != null) {
            inputValue = value;

            var attribs = $get(sender.get_id());
            if (isBussines) {
                //sender.set_selectedDate(inputValue);
                SetValue(sender, attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), inputValue, attribs.getAttribute('Field'), isBussines);
            }
            else {
                //sender.set_value(inputValue);
                SetValue(sender, attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), inputValue, attribs.getAttribute('Field'), isBussines);
            }

        }
        var atributos = $get(sender.get_id());
        EjecutaRN(atributos.getAttribute('DTid'), atributos.getAttribute('idProceso'), sender.get_id());

    }

    function OnChangeHourInputMultiPage(sender, e) {
        if (e.get_newValue() != null) {
            OnChangeHourPage(sender, e.get_newValue(), false);
        }
    }


    function OnChangeHourPage(sender, value, isBussines) {
        var currentTime, hours, minutes, seconds, inputValue;
        if (value != null) {
            inputValue = value;
            inputValue = inputValue.toUpperCase();
            if (inputValue.indexOf('M') > 0) {
                var indice = inputValue.indexOf('M');
                var valorAgregado = inputValue.substring(0, indice);
                if (IsNumeric(valorAgregado)) {
                    currentTime = new Date();
                    hours = currentTime.getHours();
                    minutes = parseInt(currentTime.getMinutes()) + parseInt(valorAgregado);
                    seconds = currentTime.getSeconds();
                    minutes = minutes < 10 ? "0" + minutes : minutes;
                    seconds = seconds < 10 ? "0" + seconds : seconds;
                    inputValue = FormatValidTime(hours, minutes, seconds);
                }
                else
                    inputValue = SetDefaultDate();
            }
            else if (inputValue.indexOf('H') > 0) {
                var indice = inputValue.indexOf('H');
                var valorAgregado = inputValue.substring(0, indice);
                if (IsNumeric(valorAgregado)) {
                    currentTime = new Date();
                    hours = parseInt(currentTime.getHours()) + parseInt(valorAgregado);
                    minutes = currentTime.getMinutes();
                    seconds = currentTime.getSeconds();
                    minutes = minutes < 10 ? "0" + minutes : minutes;
                    seconds = seconds < 10 ? "0" + seconds : seconds;
                    inputValue = FormatValidTime(hours, minutes, seconds);
                }
                else
                    inputValue = SetDefaultDate();
            }
            else if (inputValue.indexOf('S') > 0) {
                var indice = inputValue.indexOf('S');
                var valorAgregado = inputValue.substring(0, indice);
                if (IsNumeric(valorAgregado)) {
                    currentTime = new Date();
                    hours = currentTime.getHours();
                    minutes = currentTime.getMinutes();
                    seconds = parseInt(currentTime.getSeconds()) + parseInt(valorAgregado);
                    minutes = minutes < 10 ? "0" + minutes : minutes;
                    seconds = seconds < 10 ? "0" + seconds : seconds;
                    inputValue = FormatValidTime(hours, minutes, seconds);
                }
                else
                    inputValue = SetDefaultDate();
            }
            var attribs = $get(sender.get_id());
            if (!isBussines) {
                //sender.set_value(inputValue);
                SetValue(sender,attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), inputValue, attribs.getAttribute('Field'), isBussines);
            }
        }
        var atributos = $get(sender.get_id());
        EjecutaRN(atributos.getAttribute('DTid'), atributos.getAttribute('idProceso'), sender.get_id());
    }

    function OnChangeNumericTextBoxPage(sender, e) {
        var attribs = $get(sender.get_id());
        inputValue = e.get_newValue();
        SetValue(sender, attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), inputValue, attribs.getAttribute('Field'));
        var atributos = $get(sender.get_id());
        EjecutaRN(atributos.getAttribute('DTid'), atributos.getAttribute('idProceso'), sender.get_id());        
    }


    function EnviaDato(commandName,multiRenlgonName, controlId, Skey, ValueData, columName) {
        jQuery.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: '{ commandName: "' + commandName + '", multiRenlgonName: "' + multiRenlgonName + '", controlId: "' + controlId + '", Skey: "' + Skey + '", ValueData: "' + ValueData + '", columName: "' + columName + '" }',
            dataType: 'json',
            url: 'Registro_de_Usuario_Catalogo.aspx/EnviaDato',
            success: OnSuccess
        });

    }

    function OnChangeDateInputPage(obj) {
        var currentTime, hours, minutes, seconds;
        obj.value = obj.value.toUpperCase();
        if (obj.value.indexOf('M') > 0) {
            var indice = obj.value.indexOf('M');
            var valorAgregado = obj.value.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = currentTime.getHours();
                minutes = parseInt(currentTime.getMinutes()) + parseInt(valorAgregado);
                seconds = currentTime.getSeconds();
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                obj.value = FormatValidTime(hours, minutes, seconds);
            }
            else
                obj.value = SetDefaultDate();
        }
        else if (obj.value.indexOf('H') > 0) {
            var indice = obj.value.indexOf('H');
            var valorAgregado = obj.value.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = parseInt(currentTime.getHours()) + parseInt(valorAgregado);
                minutes = currentTime.getMinutes();
                seconds = currentTime.getSeconds();
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                obj.value = FormatValidTime(hours, minutes, seconds);
            }
            else
                obj.value = SetDefaultDate();
        }
        else if (obj.value.indexOf('S') > 0) {
            var indice = obj.value.indexOf('S');
            var valorAgregado = obj.value.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = currentTime.getHours();
                minutes = currentTime.getMinutes();
                seconds = parseInt(currentTime.getSeconds()) + parseInt(valorAgregado);
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                obj.value = FormatValidTime(hours, minutes, seconds);
            }
            else
                obj.value = SetDefaultDate();
        }
        var atributos = $get(obj.get_id());
        EjecutaRN(atributos.getAttribute('DTid'), atributos.getAttribute('idProceso'), '');        
    }


        function ShowNewWindow(ruta) {
            //Show new window
            //not providing a name as a second parameter
            //creates a new window
            var oWindow = window.radopen(ruta, null);
            //Using the reference to the window its clientside methods can be called
            oWindow.Modal = true;
            oWindow.setSize(800, 450);
        }

        function adjustDivs() {
            var df = document.getElementById('<%=UpdateProgress1.ClientID %>');
            df.style.position = 'absolute';
            df.style.left = (document.documentElement.scrollLeft + 45) + '%';
            df.style.top = '50%'; //$('.ajax__tab_body')[0].offsetHeight/2 + 'px';
            df.style.zIndex = "1";

            var df = document.getElementById('<%=UpdateProgress2.ClientID %>');
            df.style.position = 'absolute';
            df.style.left = (document.documentElement.scrollLeft + 45) + '%';
            df.style.top = '50%'; //$('.ajax__tab_body')[0].offsetHeight/2 + 'px';
            df.style.zIndex = "1";
        }

        window.onload = adjustDivs;
        window.onresize = adjustDivs;
        window.onscroll = adjustDivs;

        function GetRadWindow()
        {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow()
        {
            var oWnd = GetRadWindow();
            oWnd.close();
        }

        //Funcion que elimina un renglon
        function DeleteRow(controlName, multirenlgon, boton, key) {
            var multi = multirenlgon;
            var botonBorrar = boton;
            var rowIndex = botonBorrar.parentNode.parentNode.parentNode.rowIndex;
            var row = $(botonBorrar).closest('tr');
            row.remove();
            var rowsLeft = $('#ctl00_MainContent_grdMulti' + multi).find('tr.GridRowStyle').length;
            if (rowsLeft == 0) {
                $('#ctl00_MainContent_grdMulti' + multi + ' tr.GridHeaderStyle').remove();
            } 
            EnviaDato('Delete', multi, '', key, '', ''); 
        }


        //Funcion que agrega un renglon
        function AddRow(controlName, multirenlgon) {
            var multi = multirenlgon;
            var row = $('#' + controlName + ' img:last').closest('tr').clone(true);
            $('#' + controlName + ' tbody:first').append(row);
            EnviaDato('Add', multi, '', '', '', '');
        }

    </script>

    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img style="z-index: 1;" src="../images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>  
   <script type="text/javascript">
       var prm = Sys.WebForms.PageRequestManager.getInstance();
       var originalClientSubmit;

       if (!originalClientSubmit) {
           originalClientSubmit = Telerik.Web.UI.RadProgressManager.prototype._clientSubmitHandler;
       }

       Telerik.Web.UI.RadProgressManager.prototype._clientSubmitHandler = function(e) {
           if (!prm._postBackSettings.async) {
               originalClientSubmit.apply(this, [e]);
           }
       }
    </script>  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="tt-tabs-controls"> 
            <telerik:RadTabStrip ID="TabControls" runat="server" MultiPageID="RadMultiPage1"
                CausesValidation="false" Skin="Outlook" SelectedIndex="0">
                <Tabs>
                    
                    <telerik:RadTab runat="server" Text="Datos Generales" PageViewID="tabPagDatos_Generales" Value="tabPagDatos_Generales" />
                </Tabs>
            </telerik:RadTabStrip> 
            </div>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" ScrollBars="None" CssClass="rad_tab_strip_tabs_controls" > 
                
                <telerik:RadPageView ID="tabPagDatos_Generales" runat="server"> 
                <table id="tbDatos_Generales" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
                    <tr id="trFolio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFolio" runat="server" Text="Folio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFolio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtFolio" Columns="9"   runat="server" Font-Names="Arial" onblur="EjecutaRN(141033,29981,0)"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVFolio" runat="server" ControlToValidate="TxtFolio" Display="Dynamic" ErrorMessage="El campo Folio debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVFolio" runat="server" ErrorMessage="El campo Folio es obligatorio" ControlToValidate="TxtFolio" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trUsuario_que_Registra">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblUsuario_que_Registra" runat="server" Text="Usuario que Registra: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblUsuario_que_Registra" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlUsuario_que_Registra" runat="server" EnableViewState="true" onchange="EjecutaRN(141034,29981,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcUsuario_que_Registra" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVUsuario_que_Registra" runat="server" ControlToValidate="ddlUsuario_que_Registra" Display="Dynamic" ErrorMessage="El campo Usuario que Registra es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFecha_de_Registro">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFecha_de_Registro" runat="server" Text="Fecha de Registro: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFecha_de_Registro" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtFecha_de_Registro" runat="server" onkeyup="rad_keyup(this,event);" onkeydown="rad_keydown(this,event);" DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="141035" idProceso="29981"
                                                    ToolTip="Opciones: <br /> H = hoy <br /> M = mañana <br/> Dn = hoy + n días <br/> Sn = hoy + n semanas <br/> Alt Gr + Mn = hoy + n meses <br/> An = hoy + n Años" />
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFecha_de_Registro" runat="server" ControlToValidate="TxtFecha_de_Registro" Display="Dynamic" ErrorMessage="El campo Fecha de Registro es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trHora_de_Registro">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblHora_de_Registro" runat="server" Text="Hora de Registro: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblHora_de_Registro" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadTimePicker ID="txtHora_de_Registro" runat="server"  DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                <DateInput DateFormat="HH:mm:ss" DisplayDateFormat="HH:mm:ss" OnChange="OnChangeDateInput(this)"  DTid="141036" idProceso="29981"></DateInput>
                                <ClientEvents>
                                </ClientEvents>
                                <TimeView TimeFormat="HH:mm:ss" RenderDirection="Vertical" HeaderText="">
                                </TimeView>
                            </telerik:RadTimePicker>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVHora_de_Registro" runat="server" ControlToValidate="TxtHora_de_Registro" Display="Dynamic" ErrorMessage="El campo Hora de Registro es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trNombre">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblNombre" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtNombre" TextMode="MultiLine" Rows="2" Columns="100"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141037,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trApellido">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblApellido" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtApellido" TextMode="MultiLine" Rows="2" Columns="100"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141038,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVApellido" runat="server" ControlToValidate="TxtApellido" Display="Dynamic" ErrorMessage="El campo Apellido debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVApellido" runat="server" ControlToValidate="TxtApellido" Display="Dynamic" ErrorMessage="El campo Apellido es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trNombre_Completo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblNombre_Completo" runat="server" Text="Nombre Completo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblNombre_Completo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtNombre_Completo" TextMode="MultiLine" Rows="3" Columns="80" runat="server" Font-Names="Arial" onkeypress="keypress(event,this)" onkeyUp="maximo_largo(this)" onblur="EjecutaRN(141039,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVNombre_Completo" runat="server" ControlToValidate="TxtNombre_Completo" Display="Dynamic" ErrorMessage="El campo Nombre Completo debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVNombre_Completo" runat="server" ControlToValidate="TxtNombre_Completo" Display="Dynamic" ErrorMessage="El campo Nombre Completo es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trCorreo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblCorreo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtCorreo"  Columns="50"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141040,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVCorreo" runat="server" ControlToValidate="TxtCorreo" Display="Dynamic" ErrorMessage="El campo Correo debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVCorreo" runat="server" ControlToValidate="TxtCorreo" Display="Dynamic" ErrorMessage="El campo Correo es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                             &nbsp;<asp:RegularExpressionValidator id="valRegExCorreo" runat="server" ControlToValidate="txtCorreo" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ErrorMessage="El campo Correo es inválido" display="dynamic">Correo inválido</asp:RegularExpressionValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trContrasena">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblContrasena" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtContrasena"  Columns="50"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141041,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVContrasena" runat="server" ControlToValidate="TxtContrasena" Display="Dynamic" ErrorMessage="El campo Contraseña debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVContrasena" runat="server" ControlToValidate="TxtContrasena" Display="Dynamic" ErrorMessage="El campo Contraseña es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trConfirmar_Contrasena">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblConfirmar_Contrasena" runat="server" Text="Confirmar Contraseña: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblConfirmar_Contrasena" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtConfirmar_Contrasena"  Columns="50"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141042,29981,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVConfirmar_Contrasena" runat="server" ControlToValidate="TxtConfirmar_Contrasena" Display="Dynamic" ErrorMessage="El campo Confirmar Contraseña debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVConfirmar_Contrasena" runat="server" ControlToValidate="TxtConfirmar_Contrasena" Display="Dynamic" ErrorMessage="El campo Confirmar Contraseña es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trAcepta_Terminos">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAcepta_Terminos" runat="server" Text="Acepta Términos y Condiciones: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAcepta_Terminos" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                        <asp:PlaceHolder ID="phAcepta_Terminos2" runat="server">
                          <asp:Panel ID="PnlAcepta_Terminos2" runat="server" Height="100%" Width="100%">
                            <asp:CheckBox ID="ChAcepta_Terminos" runat="server" onclick="EjecutaRN(141043,29981,0)"/>               
                          </asp:Panel>
                        </asp:PlaceHolder>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFoto_de_Perfil">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFoto_de_Perfil" runat="server" Text="Foto de Perfil: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFoto_de_Perfil" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtFoto_de_Perfil" runat="server" Columns="5" Font-Names="Arial" style="display:none" onblur="EjecutaRN(141044,29981,0)"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerFoto_de_Perfil" onclick="lkbVerFoto_de_Perfil_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoFoto_de_Perfil" runat="server" Visible="False" OnClick="IbtnCambiarArchivoFoto_de_Perfil_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoFoto_de_Perfil" runat="server" Visible="False" OnClick="IbtnBorrarArchivoFoto_de_Perfil_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVFoto_de_Perfil" runat="server" ControlToValidate="TxtFoto_de_Perfil" Display="Dynamic" ErrorMessage="El campo Foto de Perfil es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerFoto_de_Perfil">
                                    <telerik:RadUpload
                                        ID="fuaFoto_de_Perfil" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf,.xml" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaFoto_de_Perfil" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitFoto_de_Perfil" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitFoto_de_Perfil_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadFoto_de_Perfil" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            var ctlRadUpload = getRadUpload('<%= fuaFoto_de_Perfil.ClientID %>');
                                            if (ctlRadUpload != null)
                                                arguments.IsValid = ctlRadUpload.validateExtensions();
                                        } 
                                    </script>    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="smallModule">
                                        <div class="rc1"><div class="rc2"><div class="rc3" style="width:240px">
                                            <asp:Label ID="labelNoResultsFoto_de_Perfil" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsFoto_de_Perfil" runat="server" Visible="False">
                                                <HeaderTemplate>
                                                    <div class="title">Archivos: </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "FileName")%>
                                                    <%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%> 
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div></div></div>
                                    </div>
                                </td>
                            </tr>
                      </table>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trUsuario_del_Sistema">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblUsuario_del_Sistema" runat="server" Text="Usuario del Sistema: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblUsuario_del_Sistema" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlUsuario_del_Sistema" runat="server" EnableViewState="true" onchange="EjecutaRN(141104,29981,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcUsuario_del_Sistema" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVUsuario_del_Sistema" runat="server" ControlToValidate="ddlUsuario_del_Sistema" Display="Dynamic" ErrorMessage="El campo Usuario del Sistema es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>

                    
                </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <asp:ValidationSummary ID="VSRequerid" runat="server" ShowMessageBox="True" ShowSummary="False"
                HeaderText="Se encontraron los siguientes errores:" Height="19px" Width="270px" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MnuButtonsPlace">
    <telerik:RadProgressManager ID="Radprogressmanager2" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
        DisplayAfter="0">
        <ProgressTemplate>
            <img style="z-index: 1;" src="../images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="horizontal_menu_div_catalog" class="horizontal_menu_div_catalog" runat="server">
                <asp:Repeater id="myRepeaterImage" runat="server" 
                           onitemdatabound="myRepeaterImage_ItemDataBound" >
	                <ItemTemplate>
	                    <asp:HiddenField ID="hfNombreMetodo" runat="server" Value='<%# Eval("Click") %>' />
	                    <asp:ImageButton ID="cmd" runat="server" Style="visibility: hidden;" Campo='<%# Eval("Campo") %>' Valor='<%# Eval("Valor") %>'   />
                        <div id="btn_grabar_catalog" runat="server"  class="btn_catalog" onclick='<%# Eval("ClickJavaScript") %>' >
                            <img src=<%# string.Format("{0}", Eval("Imagen")) %>  >
                            </img>
                            <asp:Label ID="lblGrabar" runat="server" Text='<%# Eval("Nombre") %>' class="btns" ></asp:Label>
                        </div>
                         <div id="divider" class="btn_divider_generic_catalog">
                        </div>
	                </ItemTemplate>
                </asp:Repeater>
                        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function btn_cmdCloseClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            var pf = getQuerystring('pf') == "1" ? "true" : "false";
            var Fase = getQuerystring('Fase');
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + ', pf: ' + pf + ' ,Fase:"' + Fase + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/Cancel',
                success: successCommandRedirect
            });
        }
        function btn_cmdClearClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            var pf = getQuerystring('pf') == "1" ? "true" : "false";
            var Fase = getQuerystring('Fase');
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + ', pf: ' + pf + ' ,Fase:"' + Fase + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/Clear',
                success: successCommandRedirect
            });
        }


        function successCommandRedirect(result) {
            if (result) {
                var oresult = result.d;
                if (oresult.success) {
                    window.location = oresult.data;
                }
                else {
                    radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                }
            }
        }

        /*********************************************************************/
        /*********************************************************************/
        /******************EJECUCION DE REGLAS DE NEGOCIO*********************/
        /*********************************************************************/
        /*********************************************************************/
        //Variable Global que es asiganado el valor del Query
        var queryReturn = '';
        var PageLoad = '0';

        function OnChangeDateRN(sender, e) {
            var attribs = $get(sender.get_id());

            EjecutaRN(attribs.getAttribute('DTid'), attribs.getAttribute('idProceso'), '0');
        }

        //Metodo encargado de asignar el valor de resultado del Metodo EjecutaQuery a la variable queryReturn
        function QueryRN(result) {
            queryReturn = result.d.data;
        }

        //Metodo encargado de Obtener la cadena a evaluar
        function EjecutaRN(DTid, idProceso, indexRow) {
            jQuery.ajax({
                type: 'POST',
                async: true,
                cache: true, 
                contentType: 'application/json; charset=utf-8',
                data: '{ DTid: "' + DTid + '", idProceso: "' + idProceso + '", indexRow: "' + indexRow + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/EvaluaRN',
                success: evaluaRN
            });
        }

        function replaceall(str, replace, with_this) {
            var str_hasil = "";
            var temp;

            for (var i = 0; i < str.length; i++) // not need to be equal. it causes the last change: undefined..
            {
                if (str[i] == replace) {
                    temp = with_this;
                }
                else {
                    temp = str[i];
                }

                str_hasil += temp;
            }

            return str_hasil;
        }

        //Metodo encargado de Ejecutar el Metodo EjecutaQuery
        function EjecutaQuery(query) {
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,
                data: '{ Query: "' + query + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/EjecutaQuery',
                success: QueryRN
            });
        }

        function AsignaVariableGlobal(result) {
        }


        function SetSessionName(NombreVariable, Valor) {
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,                
                data: '{ NombreVariable: "' + NombreVariable + '", Valor: "' + Valor + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/AsignaVariableGlobal',
                success: AsignaVariableGlobal
            });
        }
        
        function GetSessionName(NombreVariable) {
            var result = "";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,
                data: '{ NombreVariable: "' + NombreVariable + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/ObtenVariableGlobal',
                success: function(data) {
                    result = data.d.data;
                }
            });
            return result;
        } 
        


        function evaluaRN(result) {
            if (result) {
                var contenido = result.d.data;
                var cadena = '';
                var cadenaActual = '';
                var resultado = '';
                var control = '';
                var controlValue = '';
                var controlOriginal = '';
                var query = '';
                var queryOriginal = '';
                SetSessionName('PostBack', '0');
                
                if (contenido != '') {
                    var cadenas = contenido.split('@@SEPARADOR@@');
                    //alert('CANT. REGLAS:' + cadenas.length);
                    for (var i = 0; i < cadenas.length; i++) {
                        cadena = cadenas[i];
                        cadena = cadena.replace('@@SEPARADOR@@', '');
                        cadena = cadena.replace(/(\r\n|\n|\r)/gm, '@LB@');
                        if (cadena != '') {
                            while (cadena.indexOf('@Q[@') != -1) {
                                query = cadena.substring(cadena.indexOf('@Q[@') + 4, cadena.indexOf('@]Q@'));
                                queryOriginal = query;
                                query = replaceall(query, '#', '');
                                //alert('QUERY ORIGINAL: ' + query);

                                while (query.indexOf('FLD[') != -1) {
                                    control = query.substring(query.indexOf('FLD[') + 4, query.indexOf(']'));
                                    control = control.replace('#', '');
                                    var ctrl = $find(control);
                                    if (ctrl != null) //control de telerik
                                    {

                                        try {
                                            switch (Object.getType(ctrl).__typeName) {
                                                case "Telerik.Web.UI.RadNumericTextBox":
                                                    controlValue = controlValue = ctrl._value;
                                                    break;
                                                case "Telerik.Web.UI.RadComboBox":
                                                    controlValue = ctrl._selectedItem._attributes._data.Clave;
                                                    break;
                                                default:
                                                    controlValue = ctrl._dateInput._text;
                                                    if (ctrl._maxDate != '') {
                                                        //controlValue = controlValue.substring(3, 5) + '/' + controlValue.substring(0, 2) + '/' + controlValue.substring(6, 10);
                                                    }
                                            } 


                                        }
                                        catch (ex) {

                                            try {
                                                controlValue = ctrl._selectedItem._attributes._data.Clave;
                                            }
                                            catch (ex2) {


                                                if (control.indexOf('txt') > 0 || control.indexOf('ddl') > 0 || control.indexOf('cdd') > 0 )
                                                    controlValue = $('#' + control).val();
                                                else if (control.indexOf('_Ch') > 0){
                                        		var ctlDOM = $get(control);
                                        		if (ctlDOM != null) 
                                        		{
                                            			if (ctlDOM.tagName=="INPUT")
                                            			{
                                                			if (ctlDOM.type == "checkbox")
                                                			{
                                                 		  		 controlValue = $('#' + control).is(':checked');
                                                			}
                                            			}
                                        		}
                                            	}
                                            }
                                        }
                                    }
                                    else {
                                        if (control.indexOf('txt') > 0 || control.indexOf('ddl') > 0 || control.indexOf('cdd') > 0 )
                                            controlValue = $('#' + control).val();
					else if (control.indexOf('_Ch') > 0) {
	                                        var ctlDOM = $get(control);
	                                        if (ctlDOM != null) {
	                                            if (ctlDOM.tagName == "INPUT") {
	                                                if (ctlDOM.type == "checkbox") {
	                                                    controlValue = $('#' + control).is(':checked');
	                                                }
	                                            }
                                        	}
                                    	}
                                    }
                                    control = 'FLD[' + control + ']';
                                    if (controlValue == '//') { controlValue = ''; }

                                    query = query.replace(control, controlValue);
                                    //alert('CONTROL ' + control + ' VALOR:' + controlValue);
                                }
                                //alert('QUERY DEPURADO:' + query);
                                EjecutaQuery(query);
                                if (!isNaN(parseFloat(queryReturn)) && isFinite(queryReturn)) {
                                    queryOriginal = '\'@Q[@' + queryOriginal + '@]Q@\'';
                                    if (cadena.indexOf('val(' + queryOriginal + ')') != -1) {
                                        cadena = cadena.replace(queryOriginal, '\'' + queryReturn + '\'');
                                    } else {
                                        cadena = cadena.replace(queryOriginal, queryReturn);
                                    }
                                } else {
                                    queryOriginal = '@Q[@' + queryOriginal + '@]Q@';
                                    cadena = cadena.replace(queryOriginal, queryReturn);
                                }
                                
                                
                                //alert('QUERY:\n' + query + '\n\nRESULTADO:\n' + queryReturn);
                            }

                            while (cadena.indexOf('FLD[') != -1) {
                                control = cadena.substring(cadena.indexOf('FLD[') + 4, cadena.indexOf(']'));
                                controlOriginal = control;
                                control = replaceall(control, '#', '');control = replaceall(control, '\'', '');
                                var ctrl = $find(control);
                                if (ctrl != null) //control de telerik
                                {
                                    try {
                                        switch (Object.getType(ctrl).__typeName) {
                                            case "Telerik.Web.UI.RadNumericTextBox":
                                                controlValue = controlValue = ctrl._value;
                                                break;
                                            case "Telerik.Web.UI.RadComboBox":
                                                controlValue = ctrl._selectedItem._attributes._data.Clave;
                                                break;
                                            default:
                                                controlValue = ctrl._dateInput._text;
                                                if (ctrl._maxDate != '') {
                                                    //controlValue = controlValue.substring(3, 5) + '/' + controlValue.substring(0, 2) + '/' + controlValue.substring(6, 10);
                                                }

                                        } 

                                    }
                                    catch (ex) {
                                        try {
                                            controlValue = ctrl._selectedItem._attributes._data.Clave;
                                        }
                                        catch (ex2) {
                                            if (control.indexOf('txt') > 0 || control.indexOf('ddl') > 0 || control.indexOf('cdd') > 0 )
                                                controlValue = $('#' + control).val();
                                            else if (control.indexOf('_Ch') > 0){
                                        	var ctlDOM = $get(control);
                                        	if (ctlDOM != null) 
                                        	{
                                            		if (ctlDOM.tagName=="INPUT")
                                            		{
                                                		if (ctlDOM.type == "checkbox")
                                                		{
                                                 		   controlValue = $('#' + control).is(':checked');
                                                		}
                                            		}
                                        	}
                                            }
                                        }
                                    }
                                }
                                else {
                                    if (control.indexOf('txt') > 0 || control.indexOf('ddl') > 0 || control.indexOf('cdd') > 0 )
                                        controlValue = $('#' + control).val();
					else if (control.indexOf('_Ch') > 0) {
	                                        var ctlDOM = $get(control);
	                                        if (ctlDOM != null) {
	                                            if (ctlDOM.tagName == "INPUT") {
	                                                if (ctlDOM.type == "checkbox") {
	                                                    controlValue = $('#' + control).is(':checked');
	                                                }
	                                            }
                                        	}
                                    	}
                                }


                                if (controlValue == '//') { controlValue = ''; }
                                controlOriginal = 'FLD[' + controlOriginal + ']';
                                cadena = cadena.replace(controlOriginal, controlValue);
                                
                                //alert('CONTROL ' + control + ' VALOR:' + controlValue);
                            }
                            //alert('CADENA A EVALUAR:' + cadena);
                            try {
                                eval(cadena);
                            }
                            catch (ex) {
				cadena=replaceall(cadena, '{','{\n');
				cadena=replaceall(cadena, ';',';\n');
                                alert('STRING DE RN CON ERRORES: ' + ex.message + '\n\n' + 'CADENA EVALUADA:' + cadena);
                            }
                        }
                    }
                }
            }
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,
                data: '{ NombreVariable: "PostBack"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/ObtenVariableGlobal',
                success: function(Result) {
                    if (Result.d.data == '1') {
                        SetSessionName('PostBack', '0');
                        SetSessionName('PageLoad', '1');
                        var UpdatePanel1 = '<%=UpdatePanel1.ClientID%>';
                        __doPostBack(UpdatePanel1, '')
                    }
                }
            });
            
        }

       function findNextBracket(cadena, startIndex) {

            for (var i = startIndex; i <= cadena.length; i++) {
                if (cadena[i] == ']') return i;
            }
        }

        function parseDate(input) {
            if (input != '') {
                var parts = input.split('/');
                return new Date(parts[2], parts[1] - 1, parts[0]); // Note: months are 0-based
            }
        }

        function AddNewItem(control, value) {
            if (control != '' && value != '') {
                control = control.replace('#', '');
                var combo = $find(control);
                if (combo != null) {
                    var DTid = combo._attributes._data.DTid;
                    var Proceso = combo._attributes._data.Proceso;

                    try {
                        var desc = null;
                        jQuery.ajax({
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            async: false,
                            cache: false,
                            data: '{ DTid: "' + DTid + '", Proceso: "' + Proceso + '", Value: "' + value + '"}',
                            dataType: 'json',
                            url: 'Registro_de_Usuario_Catalogo.aspx/setValueToRadComboBox',
                            success: function(Result) {
                                desc = Result.d.data;
                            },
                            error: function(Result) {
                                alert("Error en WebMethod: setValueToRadComboBox");
                            }
                        });
                        if (desc != null) {
                            combo.set_value(value);
                            combo.set_text(desc);
                            var attribs = $get(combo.get_id());
                            SetValue(combo, attribs.getAttribute('Operation'), attribs.getAttribute('Multirenglon'), attribs.getAttribute('ControlId'), attribs.getAttribute('Key'), value, attribs.getAttribute('Field'));
                            EjecutaRN(attribs.getAttribute('DTid'), attribs.getAttribute('Proceso'), combo.get_id());
                        }
                    } catch (ex) {
                        alert('ERROR AddNewItem:' + ex.message);
                    }
                }
            }
        } 
        

        function FiltraCombo(controlname, query) {
            try {
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    async: false,
                    cache: false,                    
                    data: '{ Query: "' + query + '"}',
                    dataType: 'json',
                    url: 'Registro_de_Usuario_Catalogo.aspx/FiltraCombo',
                    success: function(Result) {
                    Result = Result.d;
                    var selectedValue = $('#' + controlname).val(); 
                        $('#' + controlname).html("");
                        $.each(Result, function(key, value) {
                            $('#' + controlname).append($('<option></option>').val
                    (value.ComboId).html(value.ComboName));
                        });
                        if (selectedValue != null) {
                            $('#' + controlname).val(selectedValue);
                        } 
                    },
                    error: function(Result) {
                        alert("Error al filtrar combo " + controlname + " con el query \n\n" + query);
                    }
                });
            } catch (ex) {
                alert('ERROR FiltraCombo:' + ex.message);
            }
        }


        function Filtrar(result) {
            queryReturn = result.d.data;
        }

        function SetValue(control, commandName, multiRenlgonName, controlId, Skey, ValueData, columName) {
            //var rowIndex = control.parentNode.parentNode.rowIndex;
            //var rowIndex = 0;
            //    try {
            //        rowIndex = parseInt(control.id.substring(control.id.indexOf('_ctl') + 4, control.id.indexOf('_', control.id.indexOf('_ctl') + 4)))-1;
            //    }
            //    catch (ex) {
            //        rowIndex = parseInt(control._clientID.substring(control._clientID.indexOf('_ctl') + 4, control._clientID.indexOf('_', control._clientID.indexOf('_ctl') + 4)))-1;
            //    }
            //EnviaDato(commandName, multiRenlgonName, controlId, rowIndex, ValueData, columName);
            EnviaDato(commandName, multiRenlgonName, controlId, Skey , ValueData, columName);            
        }

        function ShowHideColumn(tipo, nombreGrid, nombreCampo) {
            try {
                var headers = $('#ctl00_MainContent_' + nombreGrid + ' th')
                for (var i = 0; i < headers.length; i++) {
                    if (headers[i].innerText == nombreCampo) {
                        if (tipo == '1') {
                            $('#ctl00_MainContent_' + nombreGrid + ' th:nth-child(' + i + ')').hide();
                            $('#ctl00_MainContent_' + nombreGrid + ' td:nth-child(' + i + ')').hide();
                        }
                        else {
                            $('#ctl00_MainContent_' + nombreGrid + ' th:nth-child(' + i + ')').show();
                            $('#ctl00_MainContent_' + nombreGrid + ' td:nth-child(' + i + ')').show();
                        }
                        break;
                    }
                }
            }
            catch (ex) {
            }
        }

        function autoPopulateGrid(querySQL, metodo) {
            querySQL = querySQL.replace('@Q[', '');
            querySQL = querySQL.replace(']Q@', '');
            SetSessionName('PostBack', '1');
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,                
                data: '{ querySQL: "' + querySQL + '"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/' + metodo,
                success: populateGrid
            });
        }

        function populateGrid(result) {

        }

        function AsignaVariableGlobal(result) {
        }

        function pageLoad() {
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                async: false,
                cache: false,
                data: '{ NombreVariable: "PageLoad"}',
                dataType: 'json',
                url: 'Registro_de_Usuario_Catalogo.aspx/ObtenVariableGlobal',
                success: function(Result) {
                    if (Result.d.data == '1') {
                        SetSessionName('PageLoad', '0');
                        EjecutaRN('','29981','');
                    }
                }
            });
        }

        function setValueToControl(controlName, controlValue) {
            var ctlDOM = $get(controlName);
            var ctlObject = $find(controlName);

            /*Control is JavaScript Object?*/
            if (ctlObject != null) {
                switch (Object.getType(ctlObject).__typeName) {
                    /* RadNumericTextBox */ 
                    case "Telerik.Web.UI.RadNumericTextBox":
                        ctlObject.set_value(controlValue);
                        break;
                    /* RadComboBox */ 
                    case "Telerik.Web.UI.RadComboBox":
                        AddNewItem(controlName, controlValue);
                        break;
                    /* RadDatePicker */ 
                    case "Telerik.Web.UI.RadDatePicker":
                        if (controlValue == "") {
                            ctlObject.clear();
                        }
                        else {
                            ctlObject.set_selectedDate(parseDate(controlValue));
                        }
                        break;
                    /* RadTimePicker */ 
                    case "Telerik.Web.UI.RadDateTimePicker":
                        if (controlValue == "") {
                            ctlObject.clear();
                        }
                        else {
                            ctlObject.set_selectedDate(parseDate(controlValue));
                        }
                        break;
                    default:

                        break;

                }
            }
            else {
                /*Control is DOM Element?*/
                if (ctlDOM != null) {
                    switch (ctlDOM.tagName) {
                        /* TextBox Control */ 
                        case "INPUT":
                            if (ctlDOM.type == "checkbox") {
                                ctlDOM.checked = controlValue;
                                $("#" + ctlDOM.id).trigger("click");
                            } else {
                                ctlDOM.value = controlValue;
                                $("#" + ctlDOM.id).trigger("blur");
                            }
                            break;
                        case "TEXTAREA":
                            ctlDOM.value = controlValue;
                            $("#" + ctlDOM.id).trigger("blur");
                            break; 
                        /* DropDownList Control*/ 
                        case "SELECT":
                            ctlDOM.value = controlValue
                            $("#" + ctlDOM.id).trigger("change"); 
                            break;

                    }
                }
            }

        } 


        /*********************************************************************/
        /*********************************************************************/
        /*********************************************************************/
        /*********************************************************************/
        /*********************************************************************/

    </script>
</asp:Content>
