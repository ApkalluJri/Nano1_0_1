<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTUsuarios_Por_Grupo_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTUsuarios_Por_Grupo" CodeFile="TTUsuarios_Por_Grupo_Catalogo.aspx.cs" %>
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
            <img src="../images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <cc1:TabContainer ID="TabControls" runat="server" ScrollBars="None">
                
                <cc1:TabPanel ID="tabPagDatos_Generales" style="text-align:left;" runat="server" HeaderText="Datos Generales">
                    <ContentTemplate>
                <table id="tbDatos_Generales" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">                    
                    <tr id="trIdUsuario">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblIdUsuario" runat="server" Text="Clave del Usuario: "></asp:Label>
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
                            &nbsp;<asp:RequiredFieldValidator ID="RFVIdUsuario" runat="server" ControlToValidate="ddlIdUsuario" Display="Dynamic" ErrorMessage="El campo Clave del Usuario es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddIdUsuario" runat="server" TargetControlID="ddlIdUsuario"
                            Category="IdUsuario" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTUsuarios_Por_GrupoWS.asmx"
                            ServiceMethod="FillDataIdUsuarioCDD" UseContextKey="true" />--%>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trIdGrupoUsuario">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblIdGrupoUsuario" runat="server" Text="Clave de Grupo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblIdGrupoUsuario" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlIdGrupoUsuario" runat="server" Width="213px"  OnSelectedIndexChanged="ddlIdGrupoUsuario_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcIdGrupoUsuario" runat="server" IdProceso="6394" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVIdGrupoUsuario" runat="server" ControlToValidate="ddlIdGrupoUsuario" Display="Dynamic" ErrorMessage="El campo Clave de Grupo es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddIdGrupoUsuario" runat="server" TargetControlID="ddlIdGrupoUsuario"
                            Category="IdGrupoUsuario" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTUsuarios_Por_GrupoWS.asmx"
                            ServiceMethod="FillDataIdGrupoUsuarioCDD" UseContextKey="true" />--%>

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










