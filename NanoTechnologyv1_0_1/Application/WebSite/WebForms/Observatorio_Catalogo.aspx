<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
    AutoEventWireup="true" CodeFile="Observatorio_Catalogo.aspx.cs" Inherits="WebForms.Observatorio_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de Observatorio" %>
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
                    url: "Observatorio_Catalogo.aspx/SetSession",
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
            url: 'Observatorio_Catalogo.aspx/EnviaDato',
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
                    <tr id="trClave">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblClave" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtClave" Columns="9"   runat="server" Font-Names="Arial" onblur="EjecutaRN(141057,29984,0)"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVClave" runat="server" ControlToValidate="TxtClave" Display="Dynamic" ErrorMessage="El campo Clave debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVClave" runat="server" ErrorMessage="El campo Clave es obligatorio" ControlToValidate="TxtClave" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
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
                             <asp:TextBox ID="txtNombre"  Columns="50"  runat="server" Font-Names="Arial" onblur="EjecutaRN(141058,29984,0)"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trIcono">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblIcono" runat="server" Text="Ícono: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblIcono" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtIcono" runat="server" Columns="5" Font-Names="Arial" style="display:none" onblur="EjecutaRN(141059,29984,0)"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerIcono" onclick="lkbVerIcono_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoIcono" runat="server" Visible="False" OnClick="IbtnCambiarArchivoIcono_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoIcono" runat="server" Visible="False" OnClick="IbtnBorrarArchivoIcono_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVIcono" runat="server" ControlToValidate="TxtIcono" Display="Dynamic" ErrorMessage="El campo Ícono es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerIcono">
                                    <telerik:RadUpload
                                        ID="fuaIcono" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf,.xml" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaIcono" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitIcono" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitIcono_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadIcono" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            var ctlRadUpload = getRadUpload('<%= fuaIcono.ClientID %>');
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
                                            <asp:Label ID="labelNoResultsIcono" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsIcono" runat="server" Visible="False">
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
                    <tr id="trColor">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblColor" runat="server" Text="Color: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblColor" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlColor" runat="server" EnableViewState="true" onchange="EjecutaRN(141060,29984,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcColor" runat="server" IdProceso="29992"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVColor" runat="server" ControlToValidate="ddlColor" Display="Dynamic" ErrorMessage="El campo Color es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trTipo_de_Observatorio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblTipo_de_Observatorio" runat="server" Text="Tipo de Observatorio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblTipo_de_Observatorio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlTipo_de_Observatorio" runat="server" EnableViewState="true" onchange="EjecutaRN(141063,29984,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcTipo_de_Observatorio" runat="server" IdProceso="29985"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVTipo_de_Observatorio" runat="server" ControlToValidate="ddlTipo_de_Observatorio" Display="Dynamic" ErrorMessage="El campo Tipo de Observatorio es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                          <tr id="trCodigos">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiCodigos" GroupingText="Códigos del Observatorio">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerCodigos" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerCodigos_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiCodigos" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowCodigos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowCodigos_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewCodigos" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdCodigosAdd_Click" CommandName="Insert" ValidationGroup="VGCodigos" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewCodigos" Visible="true" runat="server" IdProceso="29986" IdProcesoPrincipal="29984" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditCodigos" Visible="true" runat="server" IdProceso="29986" IdProcesoPrincipal="29984" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultCodigos" Visible="true" runat="server" IdProceso="29986" IdProcesoPrincipal="29984" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivCodigos">
                                        <asp:GridView ID="grdMultiCodigos" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Observatorio" OnRowCreated="grdMultiCodigos_OnRowCreated"
                                            OnPageIndexChanging="grdMultiCodigos_PageIndexChanging" onrowdatabound="grdMultiCodigos_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiCodigos','Codigos',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Codigos',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Codigos',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="50" Text='<%# Bind("Codigo") %>' DTid="141066" idProceso="29986"
                                onblur=<%# string.Format("SetValue(this,'Modify', 'Codigos', 'txtCodigo' , '{0}', this.value, 'Codigo');EjecutaRN('141066','29986',this.id)", Eval("Clave")) %>>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtEstatus" DTid="141680" Proceso="29986" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="355px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Codigos" ControlId="txtEstatus" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Estatus") %>' CurrentValue='<%# Eval("Estatus") %>' Field="Estatus" OnItemsRequested="ddlLista_ItemsRequested"
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
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Expiración">
                        <ItemTemplate>
                            <telerik:RadDatePicker  MinDate="01/01/1900" ID="txtExpiracion" runat="server" DateInput-ClientEvents-OnValueChanged="OnChangeDateInputMultiPage"
                                SelectedDate='<%# (Eval("Expiracion") != null && Eval("Expiracion") is DateTime) ? Convert.ToDateTime(Eval("Expiracion")) : (DateTime?)null %>' >
                                <DateInput DateFormat="yyyy/MM/dd" DisplayDateFormat='<%# System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString() %>' DTid="143572" idProceso="29986"
                                    Operation="Modify" Multirenglon="Codigos" ControlId="txtExpiracion" Key='<%#Eval("Clave")%>' Field="Expiracion" />
                            </telerik:RadDatePicker>                                                               
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Número de Accesos">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="txtAccesos" runat="server" MaxLength="9" Text='<%#Eval("Accesos")%>'
                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ClientEvents-OnValueChanged="OnChangeNumericTextBoxPage" 
                                Operation="Modify" Multirenglon="Codigos" ControlId="txtAccesos" Key='<%#Eval("Clave")%>' Field="Accesos"
                                DTid="143573" idProceso="29986">                            
                            </telerik:RadNumericTextBox>
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
                        </tr>                    <tr id="trAdministrador">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAdministrador" runat="server" Text="Administrador: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAdministrador" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
    <asp:DropDownList ID="ddlAdministrador" runat="server" EnableViewState="true" onchange="EjecutaRN(141905,29984,0)"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcAdministrador" runat="server" IdProceso="30351"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVAdministrador" runat="server" ControlToValidate="ddlAdministrador" Display="Dynamic" ErrorMessage="El campo Administrador es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                          <tr id="trEquipo_de_Trabajo">
                              <td colspan="4">
                                  <asp:Panel runat="server" ID="panMultiEquipo_de_Trabajo" GroupingText="Equipo de Trabajo">
 	                                    <table>
                                        <tr>
                                            <td>
                                                <TTPagers:PageNumbersPager ID="grdPagerEquipo_de_Trabajo" runat="server" CssClass="GridHeaderStyle" onpagenumberchanged="grdPagerEquipo_de_Trabajo_PageNumberChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblShowMultiEquipo_de_Trabajo" runat="server" Text="Mostrar:"></asp:Label>
                                                <asp:DropDownList ID="cmbShowEquipo_de_Trabajo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowEquipo_de_Trabajo_SelectedIndexChanged"
                                                    EnableViewState="true">
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                    <asp:ListItem Text="100" Value="100" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="cmdNewEquipo_de_Trabajo" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                    OnClick="cmdEquipo_de_TrabajoAdd_Click" CommandName="Insert" ValidationGroup="VGEquipo_de_Trabajo" />
                                                <uc3:TTbuttonCatalogoMulti ID="TTbcNewEquipo_de_Trabajo" Visible="true" runat="server" IdProceso="30353" IdProcesoPrincipal="29984" />
                                                <uc4:TTbuttonCatalogoMultiEdit ID="TTbcEditEquipo_de_Trabajo" Visible="true" runat="server" IdProceso="30353" IdProcesoPrincipal="29984" />
                                                <uc5:TTbuttonCatalogoMultiConsult ID="TTbcConsultEquipo_de_Trabajo" Visible="true" runat="server" IdProceso="30353" IdProcesoPrincipal="29984" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div runat="server" id="asyncDivEquipo_de_Trabajo">
                                        <asp:GridView ID="grdMultiEquipo_de_Trabajo" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Clave, Observatorio" OnRowCreated="grdMultiEquipo_de_Trabajo_OnRowCreated"
                                            OnPageIndexChanging="grdMultiEquipo_de_Trabajo_PageIndexChanging" onrowdatabound="grdMultiEquipo_de_Trabajo_RowDataBound" 
                                            PagerSettings-Visible="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" >
                                                            <asp:Image ID="cmdDelete" runat="server" onclick=<%# string.Format("DeleteRow('ctl00_MainContent_grdMultiEquipo_de_Trabajo','Equipo_de_Trabajo',this,'{0}');", Eval("Clave")) %>  ImageUrl="~/images/delete.png" />
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdEdit" ImageUrl="~/images/edit.png" runat="server" CausesValidation="false" OnClientClick=<%# string.Format("processText('Edit', 'Equipo_de_Trabajo',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdConsult" ImageUrl="~/images/look.png" runat="server" visible="false" CausesValidation="false" OnClientClick=<%# string.Format("processText('Consult', 'Equipo_de_Trabajo',null,'{0}', null, null)", Eval("Clave")) %> />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtNombre" DTid="143626" Proceso="30353" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="710px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Equipo_de_Trabajo" ControlId="txtNombre" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Nombre") %>' CurrentValue='<%# Eval("Nombre") %>' Field="Nombre" OnItemsRequested="ddlLista_ItemsRequested"
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
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="Rol">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="txtRol" DTid="143629" Proceso="30353" runat="server" 
                                OnClientSelectedIndexChanged="RadComboSelectedIndexChangedPage" Width="355px" OnDataBound="GridViewRadCombo_OnDataBound" 
                                Operation="Modify" Multirenglon="Equipo_de_Trabajo" ControlId="txtRol" Key='<%#Eval("Clave")%>'
                                Text='<%# Eval("Rol") %>' CurrentValue='<%# Eval("Rol") %>' Field="Rol" OnItemsRequested="ddlLista_ItemsRequested"
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
                url: 'Observatorio_Catalogo.aspx/Cancel',
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
                url: 'Observatorio_Catalogo.aspx/Clear',
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
                url: 'Observatorio_Catalogo.aspx/EvaluaRN',
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
                url: 'Observatorio_Catalogo.aspx/EjecutaQuery',
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
                url: 'Observatorio_Catalogo.aspx/AsignaVariableGlobal',
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
                url: 'Observatorio_Catalogo.aspx/ObtenVariableGlobal',
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
                url: 'Observatorio_Catalogo.aspx/ObtenVariableGlobal',
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
                            url: 'Observatorio_Catalogo.aspx/setValueToRadComboBox',
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
                    url: 'Observatorio_Catalogo.aspx/FiltraCombo',
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
                url: 'Observatorio_Catalogo.aspx/' + metodo,
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
                url: 'Observatorio_Catalogo.aspx/ObtenVariableGlobal',
                success: function(Result) {
                    if (Result.d.data == '1') {
                        SetSessionName('PageLoad', '0');
                        EjecutaRN('','29984','');
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
