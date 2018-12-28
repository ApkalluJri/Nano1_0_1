<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTUsuarios_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de Usuarios" CodeFile="TTUsuarios_Catalogo.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo" TagPrefix="uc1" %>
<%@ Register Src="~/FormsSystem/TTbuttonLista.ascx" TagName="TTbuttonLista" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
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
                            <asp:Label ID="lblIdUsuario" runat="server" Text="Clave: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblIdUsuario" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtIdUsuario" Columns="4"   runat="server" Font-Names="Arial"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVIdUsuario" runat="server" ControlToValidate="TxtIdUsuario" Display="Dynamic" ErrorMessage="El campo Clave debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVIdUsuario" runat="server" ErrorMessage="El campo Clave es obligatorio" ControlToValidate="TxtIdUsuario" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
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
                             <asp:TextBox ID="txtNombre" TextMode="MultiLine" Rows="2" Columns="80" runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="El campo Nombre es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trClave_de_Acceso">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblClave_de_Acceso" runat="server" Text="Clave de Acceso: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblClave_de_Acceso" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtClave_de_Acceso"  Columns="30"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVClave_de_Acceso" runat="server" ControlToValidate="TxtClave_de_Acceso" Display="Dynamic" ErrorMessage="El campo Clave de Acceso debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVClave_de_Acceso" runat="server" ControlToValidate="TxtClave_de_Acceso" Display="Dynamic" ErrorMessage="El campo Clave de Acceso es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

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
                             <asp:TextBox ID="txtContrasena"  Columns="30"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVContrasena" runat="server" ControlToValidate="TxtContrasena" Display="Dynamic" ErrorMessage="El campo Contraseña debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVContrasena" runat="server" ControlToValidate="TxtContrasena" Display="Dynamic" ErrorMessage="El campo Contraseña es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trActivo">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblActivo" runat="server" Text="Activo: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblActivo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                        <asp:PlaceHolder ID="phActivo2" runat="server">
                          <asp:Panel ID="PnlActivo2" runat="server" Height="100%" Width="100%">
                            <asp:CheckBox ID="ChActivo" runat="server" />               
                          </asp:Panel>
                        </asp:PlaceHolder>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="tridGrupoUsuarios">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblidGrupoUsuarios" runat="server" Text="Grupo de Usuarios: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblidGrupoUsuarios" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                            <asp:DropDownList ID="ddlidGrupoUsuarios" runat="server" Width="213px"  OnSelectedIndexChanged="ddlidGrupoUsuarios_SelectedIndexChanged"  AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
                            &nbsp;<uc1:TTbuttonCatalogo ID="TTbcidGrupoUsuarios" runat="server" IdProceso="6394" />
                            &nbsp;<asp:RequiredFieldValidator ID="RFVidGrupoUsuarios" runat="server" ControlToValidate="ddlidGrupoUsuarios" Display="Dynamic" ErrorMessage="El campo Grupo de Usuarios es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>                            
                            
                            <%--<cc1:CascadingDropDown ID="cddidGrupoUsuarios" runat="server" TargetControlID="ddlidGrupoUsuarios"
                            Category="idGrupoUsuarios" PromptText="[Seleccionar un valor...]" ServicePath="http://localhost/WebServices/TTUsuariosWS.asmx"
                            ServiceMethod="FillDataidGrupoUsuariosCDD" UseContextKey="true" />--%>

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
                        <asp:Label ID="lblGrabar" runat="server" Text="Grabar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_1_catalog">
                </div>
                <div id="btn_grabar_nuevo_catalog" onclick="btn_cmdSaveNewClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblGrabaryNuevo" runat="server" Text="Grabar y Nuevo"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_2_catalog">
                </div>
                <div id="btn_grabar_copiar_catalog" onclick="btn_cmdSaveCopyClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblGrabaryCopiar" runat="server" Text="Grabar y Copiar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_3_catalog">
                </div>
                <div id="btn_limpiar_catalog" onclick="btn_cmdClearClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblLimpiar" runat="server" Text="Limpiar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_4_catalog">
                </div>
                <div id="btn_cancelar_catalog" onclick="btn_cmdCloseClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblCancelar" runat="server" Text="Cancelar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_5_catalog">
                </div>
                <div id="btn_ayuda_catalog" onclick="btn_cmdHelpClick();" runat="server" style="visibility:hidden;" >
                    <p class="btns">
                        <asp:Label ID="lblAyuda" runat="server" Text="Ayuda"></asp:Label>
                    </p>
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










