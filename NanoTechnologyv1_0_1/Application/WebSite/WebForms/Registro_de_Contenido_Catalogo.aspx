<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
    AutoEventWireup="true" CodeFile="Registro_de_Contenido_Catalogo.aspx.cs" Inherits="WebForms.Registro_de_Contenido_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de Registro de Contenido" %>
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
                    url: "Registro_de_Contenido_Catalogo.aspx/SetSession",
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
            url: 'Registro_de_Contenido_Catalogo.aspx/EnviaDato',
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
                    
                    <telerik:RadTab runat="server" Text="Solicitud" PageViewID="tabPagSolicitud" Value="tabPagSolicitud" />
                    <telerik:RadTab runat="server" Text="Registro" PageViewID="tabPagRegistro" Value="tabPagRegistro" />
                    <telerik:RadTab runat="server" Text="Autorización" PageViewID="tabPagAutorizacion" Value="tabPagAutorizacion" />
                    <telerik:RadTab runat="server" Text="Notificaciones" PageViewID="tabPagNotificaciones" Value="tabPagNotificaciones" />
                </Tabs>
            </telerik:RadTabStrip> 
            </div>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" ScrollBars="None" CssClass="rad_tab_strip_tabs_controls" > 
                
                <telerik:RadPageView ID="tabPagSolicitud" runat="server"> 
                <table id="tbSolicitud" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
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
                              <asp:TextBox ID="txtFolio" Columns="9"   runat="server" Font-Names="Arial" onblur="EjecutaRN(141045,29982,0)"></asp:TextBox>
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
    <asp:DropDownList ID="ddlUsuario_que_Registra" runat="server" EnableViewState="true" onchange="EjecutaRN(141046,29982,0)"></asp:DropDownList>
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
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="141047" idProceso="29982"
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
                                <DateInput DateFormat="HH:mm:ss" DisplayDateFormat="HH:mm:ss" OnChange="OnChangeDateInput(this)"  DTid="141048" idProceso="29982"></DateInput>
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
                    <tr id="trObservatorio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblObservatorio" runat="server" Text="Observatorio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblObservatorio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:ListBox ID="lstObservatorio" runat="server" SelectionMode="Multiple"></asp:ListBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVObservatorio" runat="server" ControlToValidate="lstObservatorio" Display="Dynamic" ErrorMessage="El campo Observatorio es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trCategoria">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblCategoria" runat="server" Text="Categoría: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblCategoria" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlCategoria" runat="server" EnableViewState="true" onchange="EjecutaRN(141052,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcCategoria" runat="server" IdProceso="29983"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVCategoria" runat="server" ControlToValidate="ddlCategoria" Display="Dynamic" ErrorMessage="El campo Categoría es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trDescripcion_de_Solicitud">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblDescripcion_de_Solicitud" runat="server" Text="Descripción de Solicitud: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblDescripcion_de_Solicitud" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtDescripcion_de_Solicitud" TextMode="MultiLine" Rows="10" Columns="80" runat="server" Font-Names="Arial" onkeypress="keypress(event,this)" onkeyUp="maximo_largo(this)" onblur="EjecutaRN(143396,29982,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVDescripcion_de_Solicitud" runat="server" ControlToValidate="TxtDescripcion_de_Solicitud" Display="Dynamic" ErrorMessage="El campo Descripción de Solicitud debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVDescripcion_de_Solicitud" runat="server" ControlToValidate="TxtDescripcion_de_Solicitud" Display="Dynamic" ErrorMessage="El campo Descripción de Solicitud es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trReportero_Asignado">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblReportero_Asignado" runat="server" Text="Reportero Asignado: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblReportero_Asignado" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlReportero_Asignado" runat="server" EnableViewState="true" onchange="EjecutaRN(143392,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcReportero_Asignado" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVReportero_Asignado" runat="server" ControlToValidate="ddlReportero_Asignado" Display="Dynamic" ErrorMessage="El campo Reportero Asignado es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFecha_de_Compromiso">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFecha_de_Compromiso" runat="server" Text="Fecha de Compromiso: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFecha_de_Compromiso" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtFecha_de_Compromiso" runat="server" onkeyup="rad_keyup(this,event);" onkeydown="rad_keydown(this,event);" DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="143397" idProceso="29982"
                                                    ToolTip="Opciones: <br /> H = hoy <br /> M = mañana <br/> Dn = hoy + n días <br/> Sn = hoy + n semanas <br/> Alt Gr + Mn = hoy + n meses <br/> An = hoy + n Años" />
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFecha_de_Compromiso" runat="server" ControlToValidate="TxtFecha_de_Compromiso" Display="Dynamic" ErrorMessage="El campo Fecha de Compromiso es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trEstatus">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblEstatus" runat="server" Text="Estatus: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblEstatus" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlEstatus" runat="server" EnableViewState="true" onchange="EjecutaRN(141534,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcEstatus" runat="server" IdProceso="30050"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVEstatus" runat="server" ControlToValidate="ddlEstatus" Display="Dynamic" ErrorMessage="El campo Estatus es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trAdministrador_de_Observatorio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAdministrador_de_Observatorio" runat="server" Text="Administrador de Observatorio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAdministrador_de_Observatorio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlAdministrador_de_Observatorio" runat="server" EnableViewState="true" onchange="EjecutaRN(143609,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcAdministrador_de_Observatorio" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVAdministrador_de_Observatorio" runat="server" ControlToValidate="ddlAdministrador_de_Observatorio" Display="Dynamic" ErrorMessage="El campo Administrador de Observatorio es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>

                    
                </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="tabPagRegistro" runat="server"> 
                <table id="tbRegistro" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
                    <tr id="trReportero">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblReportero" runat="server" Text="Reportero: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblReportero" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlReportero" runat="server" EnableViewState="true" onchange="EjecutaRN(141530,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcReportero" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVReportero" runat="server" ControlToValidate="ddlReportero" Display="Dynamic" ErrorMessage="El campo Reportero es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trTitulo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblTitulo" runat="server" Text="Título del Contenido: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblTitulo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtTitulo"  Columns="80"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141049,29982,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVTitulo" runat="server" ControlToValidate="TxtTitulo" Display="Dynamic" ErrorMessage="El campo Título del Contenido debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVTitulo" runat="server" ControlToValidate="TxtTitulo" Display="Dynamic" ErrorMessage="El campo Título del Contenido es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trDescripcion">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción Breve: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblDescripcion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="7" Columns="80" runat="server" Font-Names="Arial" onkeypress="keypress(event,this)" onkeyUp="maximo_largo(this)" onblur="EjecutaRN(141050,29982,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVDescripcion" runat="server" ControlToValidate="TxtDescripcion" Display="Dynamic" ErrorMessage="El campo Descripción Breve debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TxtDescripcion" Display="Dynamic" ErrorMessage="El campo Descripción Breve es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trContenido">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblContenido" runat="server" Text="Contenido: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblContenido" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtContenido" TextMode="MultiLine" Rows="10" Columns="80" runat="server" Font-Names="Arial" onkeypress="keypress(event,this)" onkeyUp="maximo_largo(this)" onblur="EjecutaRN(141051,29982,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVContenido" runat="server" ControlToValidate="TxtContenido" Display="Dynamic" ErrorMessage="El campo Contenido debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVContenido" runat="server" ControlToValidate="TxtContenido" Display="Dynamic" ErrorMessage="El campo Contenido es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trImagen">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblImagen" runat="server" Text="Imagen: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblImagen" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtImagen" runat="server" Columns="5" Font-Names="Arial" style="display:none" onblur="EjecutaRN(141133,29982,0)"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerImagen" onclick="lkbVerImagen_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoImagen" runat="server" Visible="False" OnClick="IbtnCambiarArchivoImagen_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoImagen" runat="server" Visible="False" OnClick="IbtnBorrarArchivoImagen_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVImagen" runat="server" ControlToValidate="TxtImagen" Display="Dynamic" ErrorMessage="El campo Imagen es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerImagen">
                                    <telerik:RadUpload
                                        ID="fuaImagen" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf,.xml" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaImagen" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitImagen" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitImagen_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadImagen" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            var ctlRadUpload = getRadUpload('<%= fuaImagen.ClientID %>');
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
                                            <asp:Label ID="labelNoResultsImagen" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsImagen" runat="server" Visible="False">
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
                    <tr id="trImagen_Miniatura">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblImagen_Miniatura" runat="server" Text="Imagen Miniatura: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblImagen_Miniatura" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtImagen_Miniatura" runat="server" Columns="5" Font-Names="Arial" style="display:none" onblur="EjecutaRN(141911,29982,0)"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerImagen_Miniatura" onclick="lkbVerImagen_Miniatura_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoImagen_Miniatura" runat="server" Visible="False" OnClick="IbtnCambiarArchivoImagen_Miniatura_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoImagen_Miniatura" runat="server" Visible="False" OnClick="IbtnBorrarArchivoImagen_Miniatura_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVImagen_Miniatura" runat="server" ControlToValidate="TxtImagen_Miniatura" Display="Dynamic" ErrorMessage="El campo Imagen Miniatura es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerImagen_Miniatura">
                                    <telerik:RadUpload
                                        ID="fuaImagen_Miniatura" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf,.xml" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaImagen_Miniatura" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitImagen_Miniatura" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitImagen_Miniatura_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadImagen_Miniatura" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            var ctlRadUpload = getRadUpload('<%= fuaImagen_Miniatura.ClientID %>');
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
                                            <asp:Label ID="labelNoResultsImagen_Miniatura" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsImagen_Miniatura" runat="server" Visible="False">
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
                    <tr id="trEstilo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblEstilo" runat="server" Text="Estilo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblEstilo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlEstilo" runat="server" EnableViewState="true" onchange="EjecutaRN(141070,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcEstilo" runat="server" IdProceso="29987"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVEstilo" runat="server" ControlToValidate="ddlEstilo" Display="Dynamic" ErrorMessage="El campo Estilo es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                          <tr id="trEtiquetas">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiEtiquetas" GroupingText="Etiquetas">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerEtiquetas" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerEtiquetas_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiEtiquetas" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowEtiquetas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowEtiquetas_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewEtiquetas" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdEtiquetasAdd_Click" CommandName="Insert" ValidationGroup="VGEtiquetas" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewEtiquetas" Visible="true" runat="server" IdProceso="29989" IdProcesoPrincipal="29982" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditEtiquetas" Visible="true" runat="server" IdProceso="29989" IdProcesoPrincipal="29982" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultEtiquetas" Visible="true" runat="server" IdProceso="29989" IdProcesoPrincipal="29982" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivEtiquetas">
                                        <asp:GridView ID="grdMultiEtiquetas" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Articulo" OnRowCreated="grdMultiEtiquetas_OnRowCreated"
                                            OnPageIndexChanging="grdMultiEtiquetas_PageIndexChanging" onrowdatabound="grdMultiEtiquetas_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiEtiquetas','Etiquetas',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Etiquetas',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Etiquetas',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Etiqueta">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtEtiqueta" DTid="141077" Proceso="29989" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="355px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Etiquetas" ControlId="txtEtiqueta" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Etiqueta") %>' CurrentValue='<%# Eval("Etiqueta") %>' Field="Etiqueta" OnItemsRequested="ddlLista_ItemsRequested"
                                EnableLoadOnDemand="true">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Clave']")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Descripcion']")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                                             </Columns>
                                            <HeaderStyle CssClass="GridHeaderStyle" />
                                            <RowStyle CssClass="GridRowStyle" />
                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                            <PagerSettings Position="Top" />
                                            <PagerStyle CssClass="GridHeaderStyle" />
                                            <FooterStyle CssClass="GridFooterStyle" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </td> 
                        </tr>                          <tr id="trFuentes">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiFuentes" GroupingText="Fuentes">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerFuentes" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerFuentes_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiFuentes" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowFuentes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowFuentes_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewFuentes" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdFuentesAdd_Click" CommandName="Insert" ValidationGroup="VGFuentes" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewFuentes" Visible="true" runat="server" IdProceso="30048" IdProcesoPrincipal="29982" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditFuentes" Visible="true" runat="server" IdProceso="30048" IdProcesoPrincipal="29982" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultFuentes" Visible="true" runat="server" IdProceso="30048" IdProcesoPrincipal="29982" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivFuentes">
                                        <asp:GridView ID="grdMultiFuentes" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Articulo" OnRowCreated="grdMultiFuentes_OnRowCreated"
                                            OnPageIndexChanging="grdMultiFuentes_PageIndexChanging" onrowdatabound="grdMultiFuentes_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiFuentes','Fuentes',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Fuentes',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Fuentes',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fuente">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFuente" runat="server" MaxLength="1000" TextMode="MultiLine" Rows="5" Columns="60" Text='<%# Bind("Fuente") %>' DTid="141904" idProceso="30048"
                                onblur=<%# string.Format("SetValue(this,'Modify', 'Fuentes', 'txtFuente' , '{0}', this.value, 'Fuente');EjecutaRN('141904','30048',this.id)", Eval("Clave")) %>>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                                             </Columns>
                                            <HeaderStyle CssClass="GridHeaderStyle" />
                                            <RowStyle CssClass="GridRowStyle" />
                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                            <PagerSettings Position="Top" />
                                            <PagerStyle CssClass="GridHeaderStyle" />
                                            <FooterStyle CssClass="GridFooterStyle" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </td> 
                        </tr>                    <tr id="trAdjuntar_PDF">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAdjuntar_PDF" runat="server" Text="Adjuntar PDF: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAdjuntar_PDF" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtAdjuntar_PDF" runat="server" Columns="5" Font-Names="Arial" style="display:none" onblur="EjecutaRN(143404,29982,0)"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerAdjuntar_PDF" onclick="lkbVerAdjuntar_PDF_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoAdjuntar_PDF" runat="server" Visible="False" OnClick="IbtnCambiarArchivoAdjuntar_PDF_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoAdjuntar_PDF" runat="server" Visible="False" OnClick="IbtnBorrarArchivoAdjuntar_PDF_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVAdjuntar_PDF" runat="server" ControlToValidate="TxtAdjuntar_PDF" Display="Dynamic" ErrorMessage="El campo Adjuntar PDF es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerAdjuntar_PDF">
                                    <telerik:RadUpload
                                        ID="fuaAdjuntar_PDF" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf,.xml" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaAdjuntar_PDF" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitAdjuntar_PDF" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitAdjuntar_PDF_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadAdjuntar_PDF" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            var ctlRadUpload = getRadUpload('<%= fuaAdjuntar_PDF.ClientID %>');
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
                                            <asp:Label ID="labelNoResultsAdjuntar_PDF" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsAdjuntar_PDF" runat="server" Visible="False">
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
                    <tr id="trCaptura_Terminada">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblCaptura_Terminada" runat="server" Text="Captura Terminada: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblCaptura_Terminada" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                        <asp:PlaceHolder ID="phCaptura_Terminada2" runat="server">
                          <asp:Panel ID="PnlCaptura_Terminada2" runat="server" Height="100%" Width="100%">
                            <asp:CheckBox ID="ChCaptura_Terminada" runat="server" onclick="EjecutaRN(143568,29982,0)"/>               
                          </asp:Panel>
                        </asp:PlaceHolder>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>

                    
                </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="tabPagAutorizacion" runat="server"> 
                <table id="tbAutorizacion" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
                    <tr id="trAutorizado_por">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAutorizado_por" runat="server" Text="Autorizado por: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAutorizado_por" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlAutorizado_por" runat="server" EnableViewState="true" onchange="EjecutaRN(141729,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcAutorizado_por" runat="server" IdProceso=""/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVAutorizado_por" runat="server" ControlToValidate="ddlAutorizado_por" Display="Dynamic" ErrorMessage="El campo Autorizado por es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFecha_de_Revision">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFecha_de_Revision" runat="server" Text="Fecha de Revisión: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFecha_de_Revision" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtFecha_de_Revision" runat="server" onkeyup="rad_keyup(this,event);" onkeydown="rad_keydown(this,event);" DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="141730" idProceso="29982"
                                                    ToolTip="Opciones: <br /> H = hoy <br /> M = mañana <br/> Dn = hoy + n días <br/> Sn = hoy + n semanas <br/> Alt Gr + Mn = hoy + n meses <br/> An = hoy + n Años" />
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFecha_de_Revision" runat="server" ControlToValidate="TxtFecha_de_Revision" Display="Dynamic" ErrorMessage="El campo Fecha de Revisión es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trHora_de_Revision">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblHora_de_Revision" runat="server" Text="Hora de Revisión: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblHora_de_Revision" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadTimePicker ID="txtHora_de_Revision" runat="server"  DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                <DateInput DateFormat="HH:mm:ss" DisplayDateFormat="HH:mm:ss" OnChange="OnChangeDateInput(this)"  DTid="141731" idProceso="29982"></DateInput>
                                <ClientEvents>
                                </ClientEvents>
                                <TimeView TimeFormat="HH:mm:ss" RenderDirection="Vertical" HeaderText="">
                                </TimeView>
                            </telerik:RadTimePicker>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVHora_de_Revision" runat="server" ControlToValidate="TxtHora_de_Revision" Display="Dynamic" ErrorMessage="El campo Hora de Revisión es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trAutorizacion">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAutorizacion" runat="server" Text="Autorización: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAutorizacion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlAutorizacion" runat="server" EnableViewState="true" onchange="EjecutaRN(141734,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcAutorizacion" runat="server" IdProceso="30073"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVAutorizacion" runat="server" ControlToValidate="ddlAutorizacion" Display="Dynamic" ErrorMessage="El campo Autorización es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trMotivo_de_Rechazo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblMotivo_de_Rechazo" runat="server" Text="Motivo de Rechazo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblMotivo_de_Rechazo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtMotivo_de_Rechazo" TextMode="MultiLine" Rows="2" Columns="80" runat="server" Font-Names="Arial" onkeypress="keypress(event,this)" onkeyUp="maximo_largo(this)" onblur="EjecutaRN(141901,29982,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVMotivo_de_Rechazo" runat="server" ControlToValidate="TxtMotivo_de_Rechazo" Display="Dynamic" ErrorMessage="El campo Motivo de Rechazo debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVMotivo_de_Rechazo" runat="server" ControlToValidate="TxtMotivo_de_Rechazo" Display="Dynamic" ErrorMessage="El campo Motivo de Rechazo es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFecha_de_Inicio_de_Publicacion">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFecha_de_Inicio_de_Publicacion" runat="server" Text="Fecha de Inicio de Publicación: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFecha_de_Inicio_de_Publicacion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtFecha_de_Inicio_de_Publicacion" runat="server" onkeyup="rad_keyup(this,event);" onkeydown="rad_keydown(this,event);" DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="143405" idProceso="29982"
                                                    ToolTip="Opciones: <br /> H = hoy <br /> M = mañana <br/> Dn = hoy + n días <br/> Sn = hoy + n semanas <br/> Alt Gr + Mn = hoy + n meses <br/> An = hoy + n Años" />
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFecha_de_Inicio_de_Publicacion" runat="server" ControlToValidate="TxtFecha_de_Inicio_de_Publicacion" Display="Dynamic" ErrorMessage="El campo Fecha de Inicio de Publicación es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFecha_de_Termino">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFecha_de_Termino" runat="server" Text="Fecha de Término: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFecha_de_Termino" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtFecha_de_Termino" runat="server" onkeyup="rad_keyup(this,event);" onkeydown="rad_keydown(this,event);" DateInput-ClientEvents-OnValueChanged="OnChangeDateRN">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput  LabelCssClass="" Width="" ClientEvents-OnLoad="RadDate_Load" DTid="143406" idProceso="29982"
                                                    ToolTip="Opciones: <br /> H = hoy <br /> M = mañana <br/> Dn = hoy + n días <br/> Sn = hoy + n semanas <br/> Alt Gr + Mn = hoy + n meses <br/> An = hoy + n Años" />
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFecha_de_Termino" runat="server" ControlToValidate="TxtFecha_de_Termino" Display="Dynamic" ErrorMessage="El campo Fecha de Término es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>

                    
                </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="tabPagNotificaciones" runat="server"> 
                <table id="tbNotificaciones" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
                    <tr id="trSeleccionar_Todos_los_Observatorios">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblSeleccionar_Todos_los_Observatorios" runat="server" Text="Seleccionar Todos los Observatorios: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblSeleccionar_Todos_los_Observatorios" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                        <asp:PlaceHolder ID="phSeleccionar_Todos_los_Observatorios2" runat="server">
                          <asp:Panel ID="PnlSeleccionar_Todos_los_Observatorios2" runat="server" Height="100%" Width="100%">
                            <asp:CheckBox ID="ChSeleccionar_Todos_los_Observatorios" runat="server" onclick="EjecutaRN(149684,29982,0)"/>               
                          </asp:Panel>
                        </asp:PlaceHolder>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                          <tr id="trNotificaciones_por_Observatorios">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiNotificaciones_por_Observatorios" GroupingText="Notificaciones por Observatorios">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerNotificaciones_por_Observatorios" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerNotificaciones_por_Observatorios_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiNotificaciones_por_Observatorios" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowNotificaciones_por_Observatorios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowNotificaciones_por_Observatorios_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewNotificaciones_por_Observatorios" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdNotificaciones_por_ObservatoriosAdd_Click" CommandName="Insert" ValidationGroup="VGNotificaciones_por_Observatorios" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewNotificaciones_por_Observatorios" Visible="true" runat="server" IdProceso="31010" IdProcesoPrincipal="29982" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditNotificaciones_por_Observatorios" Visible="true" runat="server" IdProceso="31010" IdProcesoPrincipal="29982" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultNotificaciones_por_Observatorios" Visible="true" runat="server" IdProceso="31010" IdProcesoPrincipal="29982" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivNotificaciones_por_Observatorios">
                                        <asp:GridView ID="grdMultiNotificaciones_por_Observatorios" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Contenido" OnRowCreated="grdMultiNotificaciones_por_Observatorios_OnRowCreated"
                                            OnPageIndexChanging="grdMultiNotificaciones_por_Observatorios_PageIndexChanging" onrowdatabound="grdMultiNotificaciones_por_Observatorios_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiNotificaciones_por_Observatorios','Notificaciones_por_Observatorios',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Notificaciones_por_Observatorios',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Notificaciones_por_Observatorios',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notificar">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChNotificar" runat="server" Checked='<%#Convert.ToBoolean(Eval("Notificar"))%>'
                                onclick=<%# string.Format("SetValue(this,'Modify', 'Notificaciones_por_Observatorios', 'ChNotificar' , '{0}', this.checked, 'Notificar');EjecutaRN('149689','31010',this.id)", Eval("Clave")) %> />
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Observatorio">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtObservatorio" DTid="149690" Proceso="31010" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="355px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Notificaciones_por_Observatorios" ControlId="txtObservatorio" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Observatorio") %>' CurrentValue='<%# Eval("Observatorio") %>' Field="Observatorio" OnItemsRequested="ddlLista_ItemsRequested"
                                EnableLoadOnDemand="true">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Clave']")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Descripcion']")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                                             </Columns>
                                            <HeaderStyle CssClass="GridHeaderStyle" />
                                            <RowStyle CssClass="GridRowStyle" />
                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                            <PagerSettings Position="Top" />
                                            <PagerStyle CssClass="GridHeaderStyle" />
                                            <FooterStyle CssClass="GridFooterStyle" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </td> 
                        </tr>                    <tr id="trFiltrar_Usuarios_por_Observatorio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFiltrar_Usuarios_por_Observatorio" runat="server" Text="Filtrar Usuarios por Observatorio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFiltrar_Usuarios_por_Observatorio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlFiltrar_Usuarios_por_Observatorio" runat="server" EnableViewState="true" onchange="EjecutaRN(159065,29982,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcFiltrar_Usuarios_por_Observatorio" runat="server" IdProceso="29984"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVFiltrar_Usuarios_por_Observatorio" runat="server" ControlToValidate="ddlFiltrar_Usuarios_por_Observatorio" Display="Dynamic" ErrorMessage="El campo Filtrar Usuarios por Observatorio es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                          <tr id="trNotificaciones_por_Usuario">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiNotificaciones_por_Usuario" GroupingText="Notificaciones por Usuario">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerNotificaciones_por_Usuario" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerNotificaciones_por_Usuario_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiNotificaciones_por_Usuario" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowNotificaciones_por_Usuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowNotificaciones_por_Usuario_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewNotificaciones_por_Usuario" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdNotificaciones_por_UsuarioAdd_Click" CommandName="Insert" ValidationGroup="VGNotificaciones_por_Usuario" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewNotificaciones_por_Usuario" Visible="true" runat="server" IdProceso="31011" IdProcesoPrincipal="29982" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditNotificaciones_por_Usuario" Visible="true" runat="server" IdProceso="31011" IdProcesoPrincipal="29982" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultNotificaciones_por_Usuario" Visible="true" runat="server" IdProceso="31011" IdProcesoPrincipal="29982" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivNotificaciones_por_Usuario">
                                        <asp:GridView ID="grdMultiNotificaciones_por_Usuario" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Contenido" OnRowCreated="grdMultiNotificaciones_por_Usuario_OnRowCreated"
                                            OnPageIndexChanging="grdMultiNotificaciones_por_Usuario_PageIndexChanging" onrowdatabound="grdMultiNotificaciones_por_Usuario_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiNotificaciones_por_Usuario','Notificaciones_por_Usuario',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Notificaciones_por_Usuario',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Notificaciones_por_Usuario',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notificar">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChNotificar" runat="server" Checked='<%#Convert.ToBoolean(Eval("Notificar"))%>'
                                onclick=<%# string.Format("SetValue(this,'Modify', 'Notificaciones_por_Usuario', 'ChNotificar' , '{0}', this.checked, 'Notificar');EjecutaRN('149693','31011',this.id)", Eval("Clave")) %> />
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Observatorio">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtObservatorio" DTid="149694" Proceso="31011" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="355px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Notificaciones_por_Usuario" ControlId="txtObservatorio" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Observatorio") %>' CurrentValue='<%# Eval("Observatorio") %>' Field="Observatorio" OnItemsRequested="ddlLista_ItemsRequested"
                                EnableLoadOnDemand="true">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Clave']")%>
                                            </td>
                                            <td>
                                                <%# DataBinder.Eval(Container, "Attributes['Descripcion']")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="ID del Cliente">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="txtID_del_Cliente" runat="server" MaxLength="9" Text='<%#Eval("ID_del_Cliente")%>'
                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ClientEvents-OnValueChanged="OnChangeNumericTextBoxPage" 
                                Operation="Modify" Multirenglon="Notificaciones_por_Usuario" ControlId="txtID_del_Cliente" Key='<%#Eval("Clave")%>' Field="ID_del_Cliente"
                                DTid="149695" idProceso="31011">                            
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="200" TextMode="MultiLine" Rows="1" Columns="60" Text='<%# Bind("Nombre") %>' DTid="149696" idProceso="31011"
                                onblur=<%# string.Format("SetValue(this,'Modify', 'Notificaciones_por_Usuario', 'txtNombre' , '{0}', this.value, 'Nombre');EjecutaRN('149696','31011',this.id)", Eval("Clave")) %>>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                                             </Columns>
                                            <HeaderStyle CssClass="GridHeaderStyle" />
                                            <RowStyle CssClass="GridRowStyle" />
                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                                            <PagerSettings Position="Top" />
                                            <PagerStyle CssClass="GridHeaderStyle" />
                                            <FooterStyle CssClass="GridFooterStyle" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
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
                url: 'Registro_de_Contenido_Catalogo.aspx/Cancel',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/Clear',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/EvaluaRN',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/EjecutaQuery',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/AsignaVariableGlobal',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/ObtenVariableGlobal',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/ObtenVariableGlobal',
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
                            url: 'Registro_de_Contenido_Catalogo.aspx/setValueToRadComboBox',
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
                    url: 'Registro_de_Contenido_Catalogo.aspx/FiltraCombo',
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
                url: 'Registro_de_Contenido_Catalogo.aspx/' + metodo,
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
                url: 'Registro_de_Contenido_Catalogo.aspx/ObtenVariableGlobal',
                success: function(Result) {
                    if (Result.d.data == '1') {
                        SetSessionName('PageLoad', '0');
                        EjecutaRN('','29982','');
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
