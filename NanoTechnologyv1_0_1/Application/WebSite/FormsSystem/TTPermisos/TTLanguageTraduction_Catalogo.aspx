<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTLanguageTraduction_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTLanguageTraduction" CodeFile="TTLanguageTraduction_Catalogo.aspx.cs" %>
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
                    <tr id="tridTraduction">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblidTraduction" runat="server" Text="Folio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblidTraduction" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtidTraduction" Columns="9"   runat="server" Font-Names="Arial"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVidTraduction" runat="server" ControlToValidate="TxtidTraduction" Display="Dynamic" ErrorMessage="El campo Folio debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVidTraduction" runat="server" ErrorMessage="El campo Folio es obligatorio" ControlToValidate="TxtidTraduction" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trTexto">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblTexto" runat="server" Text="Texto: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblTexto" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtTexto" TextMode="MultiLine" Rows="7" Columns="80" runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVTexto" runat="server" ControlToValidate="TxtTexto" Display="Dynamic" ErrorMessage="El campo Texto debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVTexto" runat="server" ControlToValidate="TxtTexto" Display="Dynamic" ErrorMessage="El campo Texto es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trIdioma">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblIdioma" runat="server" Text="Idioma: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblIdioma" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlIdioma" runat="server" Width="213px"  OnSelectedIndexChanged="ddlIdioma_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcIdioma" runat="server" IdProceso="6834" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVIdioma" runat="server" ControlToValidate="ddlIdioma" Display="Dynamic" ErrorMessage="El campo Idioma es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddIdioma" runat="server" TargetControlID="ddlIdioma"
                            Category="Idioma" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTLanguageTraductionWS.asmx"
                            ServiceMethod="FillDataIdiomaCDD" UseContextKey="true" />--%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trRelacionProceso">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblRelacionProceso" runat="server" Text="RelacionProceso: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblRelacionProceso" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlRelacionProceso" runat="server" Width="213px"  OnSelectedIndexChanged="ddlRelacionProceso_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcRelacionProceso" runat="server" IdProceso="6391" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVRelacionProceso" runat="server" ControlToValidate="ddlRelacionProceso" Display="Dynamic" ErrorMessage="El campo RelacionProceso es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddRelacionProceso" runat="server" TargetControlID="ddlRelacionProceso"
                            Category="RelacionProceso" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTLanguageTraductionWS.asmx"
                            ServiceMethod="FillDataRelacionProcesoCDD" UseContextKey="true" />--%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trRelacionDominio">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblRelacionDominio" runat="server" Text="RelacionDominio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblRelacionDominio" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlRelacionDominio" runat="server" Width="213px"  OnSelectedIndexChanged="ddlRelacionDominio_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcRelacionDominio" runat="server" IdProceso="6403" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVRelacionDominio" runat="server" ControlToValidate="ddlRelacionDominio" Display="Dynamic" ErrorMessage="El campo RelacionDominio es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddRelacionDominio" runat="server" TargetControlID="ddlRelacionDominio"
                            Category="RelacionDominio" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTLanguageTraductionWS.asmx"
                            ServiceMethod="FillDataRelacionDominioCDD" UseContextKey="true" />--%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trRelacionDT">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblRelacionDT" runat="server" Text="RelacionDT: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblRelacionDT" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlRelacionDT" runat="server" Width="213px"  OnSelectedIndexChanged="ddlRelacionDT_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcRelacionDT" runat="server" IdProceso="6386"/>
                            &nbsp;<asp:RequiredFieldValidator ID="RFVRelacionDT" runat="server" ControlToValidate="ddlRelacionDT" Display="Dynamic" ErrorMessage="El campo RelacionDT es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                            
                            <%--<cc1:CascadingDropDown ID="cddRelacionDT" runat="server" TargetControlID="ddlRelacionDT"
                            Category="RelacionDT" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTLanguageTraductionWS.asmx"
                            ServiceMethod="FillDataRelacionDTwithParentCDD" UseContextKey="true" ParentControlID="ddlRelacionDominio" /> --%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trRelacionMessage">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblRelacionMessage" runat="server" Text="RelacionMessage: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblRelacionMessage" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtRelacionMessage" Columns="5"   runat="server" Font-Names="Arial"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVRelacionMessage" runat="server" ControlToValidate="TxtRelacionMessage" Display="Dynamic" ErrorMessage="El campo RelacionMessage debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVRelacionMessage" runat="server" ErrorMessage="El campo RelacionMessage es obligatorio" ControlToValidate="TxtRelacionMessage" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
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










