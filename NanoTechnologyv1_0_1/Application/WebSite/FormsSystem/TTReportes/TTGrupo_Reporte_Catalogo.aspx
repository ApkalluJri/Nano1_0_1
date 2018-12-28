<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTGrupo_Reporte_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTGrupo de Reporte" CodeFile="TTGrupo_Reporte_Catalogo.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo"
    TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../WebForms/Funcion.js" type="text/javascript"></script>

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
                <cc1:TabPanel ID="tabPagDatos_Generales" Style="text-align: left;" runat="server"
                    HeaderText="Datos Generales">
                    <ContentTemplate>
                        <table id="tbDatos_Generales" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
                            <tr id="trIdGrupoReporte" runat="server">
                                <td valign="middle" class="columna1_empty" style="width: 34%;">
                                    <asp:Label ID="lblIdGrupoReporte" runat="server" Text="Id Grupo de Reporte: "></asp:Label>&#160;
                                </td>
                                <td class="icon_labels" valign="middle" style="width: 1%;">
                                    <asp:Image ID="imgOblIdGrupoReporte" runat="server" ImageUrl="~/Images/Design/green_arrow.png"
                                        Style="vertical-align: middle" />
                                </td>
                                <td class="columna_controls" valign="middle" style="width: 65%;">
                                    <table width="380px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="control_style">
                                                <asp:TextBox ID="txtIdGrupoReporte" Columns="6" runat="server" Font-Names="Arial"></asp:TextBox>&#160;
                                                <asp:CompareValidator ID="CVIdGrupoReporte" runat="server" ControlToValidate="txtIdGrupoReporte"
                                                    Display="Dynamic" ErrorMessage="El campo Id Grupo de Reporte debe ser de tipo Numerico"
                                                    Operator="DataTypeCheck" Type="Integer" Style="vertical-align: super">
                                                </asp:CompareValidator>&#160;&#160;&#160;
                                                <asp:RequiredFieldValidator ID="RFVIdGrupoReporte" runat="server" ErrorMessage="El campo Id Grupo de Reporte es obligatorio"
                                                    ControlToValidate="TxtIdGrupoReporte" Display="Dynamic" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>&#160;&#160;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trNombre" runat="server">
                                <td valign="middle" class="columna1_empty" style="width: 34%;">
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>&#160;
                                </td>
                                <td class="icon_labels" valign="middle" style="width: 1%;">
                                    <asp:Image ID="imgOblNombre" runat="server" ImageUrl="~/Images/Design/green_arrow.png"
                                        Style="vertical-align: middle" />
                                </td>
                                <td class="columna_controls" valign="middle" style="width: 65%;">
                                    <table width="380px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="control_style">
                                                <asp:TextBox ID="txtNombre" Columns="80" runat="server" Font-Names="Arial"></asp:TextBox>&#160;<asp:CompareValidator
                                                    ID="CVNombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                                                    ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>&#160;<asp:RequiredFieldValidator
                                                        ID="RFVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic"
                                                        ErrorMessage="El campo Nombre es obligatorio" Enabled="True" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trFechaCreacion" runat="server">
                                <td valign="middle" class="columna1_empty" style="width: 34%;">
                                    <asp:Label ID="lblFechaCreacion" runat="server" Text="Fecha de Creacion: "></asp:Label>&#160;
                                </td>
                                <td class="icon_labels" valign="middle" style="width: 1%;">
                                    <asp:Image ID="imgOblFechaCreacion" runat="server" ImageUrl="~/Images/Design/green_arrow.png"
                                        Style="vertical-align: middle" />
                                </td>
                                <td class="columna_controls" valign="middle" style="width: 65%;">
                                    <table width="380px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="control_style">
                                                &#160;<telerik:RadDatePicker ID="RDTFecha" runat="server" Culture="Spanish (Mexico)">
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput LabelCssClass="" Width="">
                                                    </DateInput>
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                                <br />
                                                <asp:CompareValidator ID="CVFechaCreacion" runat="server" ControlToValidate="RDTFecha"
                                                    Display="Dynamic" ErrorMessage="El campo Fecha de Creacion debe ser de tipo Fecha"
                                                    Operator="DataTypeCheck" Type="Date" Style="vertical-align: super"></asp:CompareValidator>&nbsp;
                                                <asp:RequiredFieldValidator ID="RFVFechaCreacion" runat="server" ControlToValidate="RDTFecha"
                                                    Display="Dynamic" ErrorMessage="El campo Fecha de Creacion es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
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
<asp:Content runat="server" ContentPlaceHolderID="MnuButtonsPlace">
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
                            OnClick="cmdSave_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveNew" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-NUEVO.gif"
                            OnClick="cmdSaveNew_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveCopy" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-COPIAR.gif"
                            OnClick="cmdSaveCopy_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClose" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LISTA.gif"
                            OnClick="cmdClose_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClear" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LIMPIAR.gif"
                            OnClick="cmdClear_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdHelp" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif"
                            OnClick="cmdHelp_Click" Style="visibility: hidden;"></asp:ImageButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>











