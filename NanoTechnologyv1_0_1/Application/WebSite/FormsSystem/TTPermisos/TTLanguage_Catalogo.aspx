<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTLanguage_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTLanguage" CodeFile="TTLanguage_Catalogo.aspx.cs" %>
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
                    <tr id="tridLanguage">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblidLanguage" runat="server" Text="Folio: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblidLanguage" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                              <asp:TextBox ID="txtidLanguage" Columns="2"   runat="server" Font-Names="Arial"></asp:TextBox>
                              &nbsp;<asp:CompareValidator ID="CVidLanguage" runat="server" ControlToValidate="TxtidLanguage" Display="Dynamic" ErrorMessage="El campo Folio debe ser de tipo Numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                              &nbsp;<asp:RequiredFieldValidator ID="RFVidLanguage" runat="server" ErrorMessage="El campo Folio es obligatorio" ControlToValidate="TxtidLanguage" Display="Dynamic" Style="vertical-align: super" >Requerido</asp:RequiredFieldValidator>&nbsp;
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
                             <asp:TextBox ID="txtIdioma"  Columns="50"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVIdioma" runat="server" ControlToValidate="TxtIdioma" Display="Dynamic" ErrorMessage="El campo Idioma debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVIdioma" runat="server" ControlToValidate="TxtIdioma" Display="Dynamic" ErrorMessage="El campo Idioma es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

                               </td>                               
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr id="trBandera">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblBandera" runat="server" Text="Bandera: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblBandera" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                      <asp:TextBox id="txtBandera" runat="server" Columns="5" Font-Names="Arial" Visible="False"></asp:TextBox> 
                      <asp:LinkButton id="lkbVerBandera" onclick="lkbVerBandera_Click" runat="server" Visible="False">Ver</asp:LinkButton>
                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton id="IbtnCambiarArchivoBandera" runat="server" Visible="False" OnClick="IbtnCambiarArchivoBandera_Click" ToolTip="Cambiar Archivo" ImageUrl="~/images/Imagen2.bmp"></asp:ImageButton>
                      &nbsp;&nbsp;<asp:ImageButton id="IbtnBorrarArchivoBandera" runat="server" Visible="False" OnClick="IbtnBorrarArchivoBandera_Click" ToolTip="borrar Archivo" ImageUrl="~/images/Imagen3.bmp"></asp:ImageButton>
                      &nbsp;<asp:RequiredFieldValidator ID="RFVBandera" runat="server" ControlToValidate="TxtBandera" Display="Dynamic" ErrorMessage="El campo Bandera es obligatorio" Enabled="False" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                      <table>
                            <tr>
                                <td id="controlContainerBandera">
                                    <telerik:RadUpload
                                        ID="fuaBandera" runat="server" 
                                        MaxFileInputsCount="1"
                                        TargetFolder="TempFiles" ControlObjectsVisibility="None" 
                                        Skin="Web20" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.xls,.xlsx,.doc,.docx,.ppt,.pptx,.txt,.zip,.rar,.pdf" >
                                        <Localization Select="Seleccionar" />
                                    </telerik:RadUpload>
                                    
                                    <telerik:RadProgressArea id="progressAreaBandera" runat="server" Language="" Skin="Web20">
                                        <Localization Uploaded="Uploaded" />
                                    </telerik:RadProgressArea>
                                    
                                    <asp:Button id="buttonSubmitBandera" runat="server" CssClass="RadUploadSubmit" 
                                        OnClick="buttonSubmitBandera_Click" text="Cargar Archivo" CausesValidation="false" />
                                    <asp:CustomValidator ID="cvRadUploadBandera" runat="server" Display="Dynamic" 
                                        ClientValidationFunction="validateRadUpload" >    
                                        <span style="FONT-SIZE: 11px;">* Extensión invalida (Extesiones permitidas: *.*).</span>
                                    </asp:CustomValidator>    
                                    <script type="text/javascript">
                                        function validateRadUpload(source, arguments) {
                                            arguments.IsValid = getRadUpload('<%= fuaBandera.ClientID %>').validateExtensions();
                                        }
                                    </script>    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="smallModule">
                                        <div class="rc1"><div class="rc2"><div class="rc3" style="width:240px">
                                            <asp:Label ID="labelNoResultsBandera" runat="server" ForeColor="#FF3300" >* No se han cargado archivos</asp:Label>                                          
                                            <asp:Repeater ID="repeaterResultsBandera" runat="server" Visible="False">
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
                    <tr id="trAbreviatura">
                        <td valign="middle" class="columna1_empty" style="width: 34%;">
                            <asp:Label ID="lblAbreviatura" runat="server" Text="Abreviatura: "></asp:Label>
                        </td>
                        <td class="icon_labels" valign="middle" style="width: 1%;">
                            <asp:Image ID="imgOblAbreviatura" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                        </td>
                        <td class="columna_controls" valign="middle" style="width: 65%;">
                           <table width="380px" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td class="control_style">
                             <asp:TextBox ID="txtAbreviatura"  Columns="10"  runat="server" Font-Names="Arial"></asp:TextBox>
                             &nbsp;<asp:CompareValidator ID="CVAbreviatura" runat="server" ControlToValidate="TxtAbreviatura" Display="Dynamic" ErrorMessage="El campo Abreviatura debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                             &nbsp;<asp:RequiredFieldValidator ID="RFVAbreviatura" runat="server" ControlToValidate="TxtAbreviatura" Display="Dynamic" ErrorMessage="El campo Abreviatura es obligatorio" Enabled="False" style="vertical-align: super">Requerido</asp:RequiredFieldValidator>

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










