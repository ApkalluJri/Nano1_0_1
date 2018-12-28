<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTBitacoraLogIn_LogOff_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTBitacoraLogIn_LogOff" CodeFile="TTBitacoraLogIn_LogOff_Catalogo.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo" TagPrefix="uc1" %>
<%@ Register Src="~/FormsSystem/TTbuttonLista.ascx" TagName="TTbuttonLista" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../JSScripts/Funciones.js" type="text/javascript"></script>
    <script type="text/javascript">
        function InStr(n, s1, s2) {
            var numargs = InStr.arguments.length;

            if (numargs < 3)
                return n.indexOf(s1) + 1;
            else
                return s1.indexOf(s2, n) + 1;
        }

        function processText(m, c, i) {
            if (eval(InStr(1, c, 'Delete')) > 0) {
                callserver(m + "@" + c + "@" + i);
            } else {
                TBox = document.getElementById(c + i);
                var data = TBox.value;
                callserver(m + "@" + c + "@" + i + "@" + data);
            }
        }

        function ReceiveServerData(arg, context) { }

        function OpenImage(img) {
            var largo = 260;
            var altura = 200;
            var top = (screen.height - altura) / 2;
            var izquierda = (screen.width - largo) / 2;

            foto1 = new Image();
            foto1.src = (img);
            ancho = foto1.width + 20;
            alto = foto1.height + 20;
            cadena = "width = " + ancho + ",height=" + alto + ",top = " + top + ",left = " + izquierda;
            ventana = window.open(img, "null", cadena);
        }
        function adjustDivs() {
            var df = document.getElementById('<%=UpdateProgress1.ClientID %>');
            df.style.position = 'absolute';
            df.style.left = (document.documentElement.scrollLeft + 45) + '%';
            df.style.top = (document.documentElement.scrollTop + 300) + 'px';
        }

        window.onload = adjustDivs;
        window.onresize = adjustDivs;
        window.onscroll = adjustDivs;
    </script>

    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <cc1:TabContainer ID="TabControls" runat="server" ScrollBars="None">
                
                <cc1:TabPanel ID="tabPagDatos_Generales" style="text-align:left;" runat="server" HeaderText="Datos Generales">
                    <ContentTemplate>
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
                              <asp:TextBox ID="txtFolio" Columns="4"   runat="server" Font-Names="Arial"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVFolio" runat="server" ControlToValidate="TxtFolio" Display="Dynamic" ErrorMessage="El campo Folio debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVFolio" runat="server" ErrorMessage="El campo Folio es obligatorio" ControlToValidate="TxtFolio" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trIdUsuario">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblIdUsuario" runat="server" Text="IdUsuario: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblIdUsuario" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlIdUsuario" runat="server" Width="213px"  OnSelectedIndexChanged="ddlIdUsuario_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcIdUsuario" runat="server" IdProceso="6395" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVIdUsuario" runat="server" ControlToValidate="ddlIdUsuario" Display="Dynamic" ErrorMessage="El campo IdUsuario es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddIdUsuario" runat="server" TargetControlID="ddlIdUsuario"
                            Category="IdUsuario" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTBitacoraLogIn_LogOffWS.asmx"
                            ServiceMethod="FillDataIdUsuarioCDD" UseContextKey="true" />--%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFechaHora_Entrada">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFechaHora_Entrada" runat="server" Text="Fecha de Entrada: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFechaHora_Entrada" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trFechaHora_Salida">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblFechaHora_Salida" runat="server" Text="Fecha de Salida: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblFechaHora_Salida" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trComputerName">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblComputerName" runat="server" Text="ComputerName: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblComputerName" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtComputerName"  Columns="50"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVComputerName" runat="server" ControlToValidate="TxtComputerName" Display="Dynamic" ErrorMessage="El campo ComputerName debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVComputerName" runat="server" ControlToValidate="TxtComputerName" Display="Dynamic" ErrorMessage="El campo ComputerName es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trServerName">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblServerName" runat="server" Text="Nombre del servidor: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblServerName" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtServerName"  Columns="50"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVServerName" runat="server" ControlToValidate="TxtServerName" Display="Dynamic" ErrorMessage="El campo Nombre del servidor debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVServerName" runat="server" ControlToValidate="TxtServerName" Display="Dynamic" ErrorMessage="El campo Nombre del servidor es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trDatabaseName">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblDatabaseName" runat="server" Text="Base de datos: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblDatabaseName" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtDatabaseName"  Columns="50"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVDatabaseName" runat="server" ControlToValidate="TxtDatabaseName" Display="Dynamic" ErrorMessage="El campo Base de datos debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVDatabaseName" runat="server" ControlToValidate="TxtDatabaseName" Display="Dynamic" ErrorMessage="El campo Base de datos es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trSystemName">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblSystemName" runat="server" Text="Nombre del sistema: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblSystemName" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtSystemName"  Columns="50"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVSystemName" runat="server" ControlToValidate="TxtSystemName" Display="Dynamic" ErrorMessage="El campo Nombre del sistema debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVSystemName" runat="server" ControlToValidate="TxtSystemName" Display="Dynamic" ErrorMessage="El campo Nombre del sistema es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trSystemVersion">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblSystemVersion" runat="server" Text="Version: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblSystemVersion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtSystemVersion" Columns="10"  runat="server"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVSystemVersion" runat="server" ControlToValidate="txtSystemVersion" Display="Dynamic" Type="Double" ErrorMessage="El campo Version debe ser de tipo Númerico Decimal" Style="vertical-align: super"></asp:CompareValidator >
                              &nbsp;<asp:RequiredFieldValidator ID="RFVSystemVersion" runat="server" ControlToValidate="txtSystemVersion" Display="Dynamic" ErrorMessage="El campo Version es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>&nbsp;
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trWindowsVersion">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblWindowsVersion" runat="server" Text="Version de Windows: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblWindowsVersion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtWindowsVersion"  Columns="80"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVWindowsVersion" runat="server" ControlToValidate="TxtWindowsVersion" Display="Dynamic" ErrorMessage="El campo Version de Windows debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVWindowsVersion" runat="server" ControlToValidate="TxtWindowsVersion" Display="Dynamic" ErrorMessage="El campo Version de Windows es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>

                    
                </table>
                    </ContentTemplate>
                </cc1:TabPanel>

            </cc1:TabContainer>
            <asp:ValidationSummary ID="VSRequerid" runat="server" ShowMessageBox="True" ShowSummary="False"
                HeaderText="Se encontraron los siguientes errores:" Height="19px" Width="270px" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MnuButtonsPlace">
    <script type="text/javascript">
        function btn_cmdSave_Click() {
            document.getElementById("<%=cmdSave.ClientID%>").click();
        }
        function btn_cmdSaveNewClick() {
            document.getElementById("<%=cmdSaveNew.ClientID%>").click();
        }
        function btn_cmdSaveCopyClick() {
            document.getElementById("<%=cmdSaveCopy.ClientID%>").click();
        }
        function btn_cmdCloseClick() {
            document.getElementById("<%=cmdClose.ClientID%>").click();
        }
        function btn_cmdClearClick() {
            document.getElementById("<%=cmdClear.ClientID%>").click();
        }
        function btn_cmdHelpClick() {
            document.getElementById("<%=cmdHelp.ClientID%>").click();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="horizontal_menu_div_catalog">
                <div id="btn_grabar_catalog" onclick="btn_cmdSave_Click();" runat="server">
                    <p class="btns">
                        Grabar</p>
                </div>
                <div id="btn_divider_1_catalog">
                </div>
                <div id="btn_grabar_nuevo_catalog" onclick="btn_cmdSaveNewClick();" runat="server">
                    <p class="btns">
                        Grabar y Nuevo</p>
                </div>
                <div id="btn_divider_2_catalog">
                </div>
                <div id="btn_grabar_copiar_catalog" onclick="btn_cmdSaveCopyClick();" runat="server">
                    <p class="btns">
                        Grabar y Copiar</p>
                </div>
                <div id="btn_divider_3_catalog">
                </div>
                <div id="btn_limpiar_catalog" onclick="btn_cmdClearClick();" runat="server">
                    <p class="btns">
                        Limpiar</p>
                </div>
                <div id="btn_divider_4_catalog">
                </div>
                <div id="btn_cancelar_catalog" onclick="btn_cmdCloseClick();" runat="server">
                    <p class="btns">
                        Cancelar</p>
                </div>
                <div id="btn_divider_5_catalog">
                </div>
                <div id="btn_ayuda_catalog" onclick="btn_cmdHelpClick();" runat="server" style="visibility:hidden;" >
                    <p class="btns">
                        Ayuda</p>
                </div>
            </div>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:ImageButton ID="cmdSave" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR.gif"
                            __designer:wfdid="w14" OnClick="cmdSave_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveNew" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-NUEVO.gif"
                            __designer:wfdid="w13" OnClick="cmdSaveNew_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveCopy" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-COPIAR.gif"
                            __designer:wfdid="w12" OnClick="cmdSaveCopy_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClose" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LISTA.gif"
                            __designer:wfdid="w15" OnClick="cmdClose_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClear" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LIMPIAR.gif"
                            __designer:wfdid="w16" OnClick="cmdClear_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdHelp" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif"
                            __designer:wfdid="w17" OnClick="cmdHelp_Click" Style="visibility: hidden;"></asp:ImageButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>










