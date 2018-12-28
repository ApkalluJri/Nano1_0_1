<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
    AutoEventWireup="True" CodeFile="TTWorkFlow_Catalogo.aspx.cs" Inherits="WebForms.TTWorkFlow_Catalogo"
    Theme="SpanishLanguage" Title="Cat&aacute;logo de WorkFlow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo" TagPrefix="uc1" %>
<%@ Register Src="~/FormsSystem/TTbuttonLista.ascx" TagName="TTbuttonLista" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function adjustDivs() {
//            var df = document.getElementById('');
//            df.style.position = 'absolute';
//            df.style.left = (document.documentElement.scrollLeft + 45) + '%';
//            df.style.top = '50%'; //$('.ajax__tab_body')[0].offsetHeight/2 + 'px';
//            df.style.zIndex = "1";
        }
//        $(document).ready(function() {
//            $('.cdd2keys').each(function() {
//                $('#' + this.id.replace('cdd', 'ddl')).set_contextKey('valueyouwant');
//            });
//        });
        /*function fnWorkFlow()
        {
        //$('.selDiv option[value="'+$("#<%=txtFolio.ClientID %>").val()+'"]')
        //$('#<%=cddTTWorkFlow_Folio.ClientID %> option[value="'+$("#<%=txtFolio.ClientID %>").val()+'"]').attr("selected", "selected");
        //$('#<%=cddTTWorkFlow_Folio.ClientID %> option[text="'+$("#<%=txtNombre.ClientID %>").val()+'"]').attr("selected", "selected");
            
        //$('#ctl00_MainContent_TabControls_tabPagDatos_Generales_cddTTWorkFlow_Folio option[text="'+$("#ctl00_MainContent_TabControls_tabPagDatos_Generales_txtNombre").val()+'"]').attr("selected", "selected");
        //$("#ctl00_MainContent_TabControls_tabPagDatos_Generales_cddTTWorkFlow_Folio").val($("#<%=txtFolio.ClientID %>").val());
        //$('#<%=cddTTWorkFlow_Folio.ClientID %>').find("option[text='"+$("#<%=txtNombre.ClientID %>").val()+"']").attr("selected","selected");
        //alert($("#<%=txtFolio.ClientID %>").val());
        }
        
        $(document).ready(function() {
        fnWorkFlow();
        });*/

        window.onload = adjustDivs;
        window.onresize = adjustDivs;
        window.onscroll = adjustDivs;
        
    </script>

    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3" 
        DisplayAfter="0">
        <ProgressTemplate>
            <img style="z-index: 1;" src="~/images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>   
--%>
    <div style="visibility: hidden; display: none;">
        <asp:DropDownList ID="cddTTWorkFlow_Folio" runat="server" EnableViewState="true"
            OnChange=<%# string.Format("processText('Modify', 'WorkFlow', 'ddlTTWorkFlow_Folio' , '{0}', this.value, 'WorkFlow')", Eval("Folio")) %>>
        </asp:DropDownList>
        <cc1:CascadingDropDown ID="ddlTTWorkFlow_Folio" runat="server" TargetControlID="cddTTWorkFlow_Folio"
            SelectedValue='<%# Eval("WorkFlow") %>' Category="TTWorkFlow" PromptText="[Seleccionar un valor...]"
            ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_FasesWS.asmx"
            ServiceMethod="FillDataWorkFlowCDD" UseContextKey="true" />
    </div>
    <cc1:TabContainer ID="TabControls" runat="server" ScrollBars="None">
        <cc1:TabPanel ID="tabPagDatos_Generales" Style="text-align: left;" runat="server"
            HeaderText="Datos Generales">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbDatos_Generales" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
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
                                                <asp:TextBox ID="txtFolio" Columns="9" runat="server" Font-Names="Arial"></asp:TextBox>
                                                &nbsp;<asp:CompareValidator ID="CVFolio" runat="server" ControlToValidate="TxtFolio"
                                                    Display="Dynamic" ErrorMessage="El campo Folio debe ser de tipo Numerico" Operator="DataTypeCheck"
                                                    Type="Integer" ValidationGroup="none" Style="vertical-align: super"></asp:CompareValidator>&nbsp;&nbsp;
                                                &nbsp;<asp:RequiredFieldValidator ID="RFVFolio" runat="server" ErrorMessage="El campo Folio es obligatorio"
                                                    ControlToValidate="TxtFolio" Display="Dynamic" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>&nbsp;
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
                                                <asp:TextBox ID="txtNombre" TextMode="MultiLine" Rows="2" Columns="80" runat="server"
                                                    Font-Names="Arial"></asp:TextBox>
                                                &nbsp;<asp:CompareValidator ID="CVNombre" runat="server" ControlToValidate="TxtNombre"
                                                    Display="Dynamic" ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                                                &nbsp;<asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre"
                                                    Display="Dynamic" ErrorMessage="El campo Nombre es obligatorio" Enabled="False"
                                                    Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trDescripcion">
                                <td valign="middle" class="columna1_empty" style="width: 34%;">
                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción: "></asp:Label>
                                </td>
                                <td class="icon_labels" valign="middle" style="width: 1%;">
                                    <asp:Image ID="imgOblDescripcion" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                                </td>
                                <td class="columna_controls" valign="middle" style="width: 65%;">
                                    <table width="380px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="control_style">
                                                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="7" Columns="80" runat="server"
                                                    Font-Names="Arial"></asp:TextBox>
                                                &nbsp;<asp:CompareValidator ID="CVDescripcion" runat="server" ControlToValidate="TxtDescripcion"
                                                    Display="Dynamic" ErrorMessage="El campo Descripción debe ser de tipo Texto"
                                                    Operator="DataTypeCheck"></asp:CompareValidator>
                                                &nbsp;<asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TxtDescripcion"
                                                    Display="Dynamic" ErrorMessage="El campo Descripción es obligatorio" Enabled="False"
                                                    Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trObjetivo">
                                <td valign="middle" class="columna1_empty" style="width: 34%;">
                                    <asp:Label ID="lblObjetivo" runat="server" Text="Objetivo: "></asp:Label>
                                </td>
                                <td class="icon_labels" valign="middle" style="width: 1%;">
                                    <asp:Image ID="imgOblObjetivo" runat="server" ImageUrl="~/Images/Design/green_arrow.png" />
                                </td>
                                <td class="columna_controls" valign="middle" style="width: 65%;">
                                    <table width="380px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="control_style">
                                                <asp:TextBox ID="txtObjetivo" TextMode="MultiLine" Rows="7" Columns="80" runat="server"
                                                    Font-Names="Arial"></asp:TextBox>
                                                &nbsp;<asp:CompareValidator ID="CVObjetivo" runat="server" ControlToValidate="TxtObjetivo"
                                                    Display="Dynamic" ErrorMessage="El campo Objetivo debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
                                                &nbsp;<asp:RequiredFieldValidator ID="RFVObjetivo" runat="server" ControlToValidate="TxtObjetivo"
                                                    Display="Dynamic" ErrorMessage="El campo Objetivo es obligatorio" Enabled="False"
                                                    Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
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
                                                <asp:DropDownList ID="ddlEstatus" runat="server" EnableViewState="true">
                                                </asp:DropDownList>
                                                &nbsp;<uc1:TTbuttonCatalogo ID="TTbcEstatus" runat="server" IdProceso="15800" />
                                                &nbsp;<asp:RequiredFieldValidator ID="RFVEstatus" runat="server" ControlToValidate="ddlEstatus"
                                                    Display="Dynamic" ErrorMessage="El campo Estatus es obligatorio" Style="vertical-align: super">Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagFases" Style="text-align: left;" runat="server" HeaderText="Fases">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbFases" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr id="trFases">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiFases" GroupingText="Fases">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerFases" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiFases" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowFases" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowFases_SelectedIndexChanged"
                                                        EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewFases" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                        OnClick="cmdFasesAdd_Click" CommandName="Insert" ValidationGroup="VGFases" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivFases">
                                            <asp:GridView ID="grdMultiFases" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="Folio, WorkFlow" OnRowCreated="grdMultiFases_OnRowCreated" OnPageIndexChanging="grdMultiFases_PageIndexChanging"
                                                OnRowDataBound="grdMultiFases_RowDataBound" PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Fases',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="N&uacute;mero de Fase">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="txtNumero_de_Fase" runat="server" Text='<%#Eval("Numero_de_Fase")%>'
                                                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" ClientEvents-OnValueChanged="OnChangeNumericTextBox"
                                                                Operation="Modify" Multirenglon="Fases" ControlId="txtNumero_de_Fase" Key='<%#Eval("Folio")%>'
                                                                Field="Numero_de_Fase">
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' onblur=<%# string.Format("processText('Modify', 'Fases', 'txtNombre' , '{0}', this.value, 'Nombre')", Eval("Folio")) %>>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo de Fase">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddTipo_de_Fase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Fases', 'ddlTipo_de_Fase' , '{0}', this.value, 'Tipo_de_Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlTipo_de_Fase" runat="server" TargetControlID="cddTipo_de_Fase"
                                                                SelectedValue='<%# Eval("Tipo_de_Fase") %>' Category="Tipo_de_Fase" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_FasesWS.asmx"
                                                                ServiceMethod="FillDataTipo_de_FaseCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo de Distribuci&oacute;n de Trabajo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddTipo_de_Distribucion_de_Trabajo" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Fases', 'ddlTipo_de_Distribucion_de_Trabajo' , '{0}', this.value, 'Tipo_de_Distribucion_de_Trabajo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlTipo_de_Distribucion_de_Trabajo" runat="server" TargetControlID="cddTipo_de_Distribucion_de_Trabajo"
                                                                SelectedValue='<%# Eval("Tipo_de_Distribucion_de_Trabajo") %>' Category="Tipo_de_Distribucion_de_Trabajo"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_FasesWS.asmx"
                                                                ServiceMethod="FillDataTipo_de_Distribucion_de_TrabajoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo de Control de Flujo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddTipo_de_Control_de_Flujo" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Fases', 'ddlTipo_de_Control_de_Flujo' , '{0}', this.value, 'Tipo_de_Control_de_Flujo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlTipo_de_Control_de_Flujo" runat="server" TargetControlID="cddTipo_de_Control_de_Flujo"
                                                                SelectedValue='<%# Eval("Tipo_de_Control_de_Flujo") %>' Category="Tipo_de_Control_de_Flujo"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_FasesWS.asmx"
                                                                ServiceMethod="FillDataTipo_de_Control_de_FlujoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estatus de Fase">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddEstatus_de_Fase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Fases', 'ddlEstatus_de_Fase' , '{0}', this.value, 'Estatus_de_Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlEstatus_de_Fase" runat="server" TargetControlID="cddEstatus_de_Fase"
                                                                SelectedValue='<%# Eval("Estatus_de_Fase") %>' Category="Estatus_de_Fase" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_FasesWS.asmx"
                                                                ServiceMethod="FillDataEstatus_de_FaseCDD" UseContextKey="true" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagEstados" Style="text-align: left;" runat="server" HeaderText="Estados">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbEstados" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr id="trEstados">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiEstados" GroupingText="Estados">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerEstados" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiEstados" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowEstados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShowEstados_SelectedIndexChanged"
                                                        EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewEstados" ImageUrl="~/images/Design/add_item.png" runat="server"
                                                        OnClick="cmdEstadosAdd_Click" CommandName="Insert" ValidationGroup="VGEstados" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivEstados">
                                            <asp:GridView ID="grdMultiEstados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="Folio, TTWorkFlow" OnRowCreated="grdMultiEstados_OnRowCreated"
                                                OnPageIndexChanging="grdMultiEstados_PageIndexChanging" OnRowDataBound="grdMultiEstados_RowDataBound"
                                                PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Estados',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fase">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddFase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Estados', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" ParentControlID="cddTTWorkFlow_Folio"
                                                                SelectedValue='<%# Eval("Fase") %>' Category="Fase" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proceso">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddProceso" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Estados', 'ddlProceso' , '{0}', this.value, 'Proceso')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlProceso" runat="server" TargetControlID="cddProceso"
                                                                SelectedValue='<%# Eval("Proceso") %>' Category="Proceso" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataProcesoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Campo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddCampo" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Estados', 'ddlCampo' , '{0}', this.value, 'Campo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlCampo" runat="server" TargetControlID="cddCampo" SelectedValue='<%# Eval("Campo") %>'
                                                                Category="Campo" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataCampowithParentCDD" UseContextKey="true" ParentControlID="cddProceso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="C&oacute;digo Estado">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="txtCodigo_Estado" runat="server" Text='<%#Eval("Codigo_Estado")%>'
                                                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" ClientEvents-OnValueChanged="OnChangeNumericTextBox"
                                                                Operation="Modify" Multirenglon="Estados" ControlId="txtCodigo_Estado" Key='<%#Eval("Folio")%>'
                                                                Field="Codigo_Estado">
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado (Nombre)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' onblur=<%# string.Format("processText('Modify', 'Estados', 'txtNombre' , '{0}', this.value, 'Nombre')", Eval("Folio")) %>>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado (Valor)">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="txtValor" runat="server" Text='<%#Eval("Valor")%>'
                                                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" ClientEvents-OnValueChanged="OnChangeNumericTextBox"
                                                                Operation="Modify" Multirenglon="Estados" ControlId="txtValor" Key='<%#Eval("Folio")%>'
                                                                Field="Valor">
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado (Texto)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTexto" runat="server" Text='<%# Bind("Texto") %>' onblur=<%# string.Format("processText('Modify', 'Estados', 'txtTexto' , '{0}', this.value, 'Texto')", Eval("Folio")) %>>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagCondiciones_por_Estado" Style="text-align: left;" runat="server"
            HeaderText="Condiciones por Estado">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbCondiciones_por_Estado" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
                            <tr id="trCondiciones_por_Estado">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiCondiciones_por_Estado" GroupingText="Condiciones por Estado">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerCondiciones_por_Estado" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiCondiciones_por_Estado" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowCondiciones_por_Estado" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="cmbShowCondiciones_por_Estado_SelectedIndexChanged" EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewCondiciones_por_Estado" ImageUrl="~/images/Design/add_item.png"
                                                        runat="server" OnClick="cmdCondiciones_por_EstadoAdd_Click" CommandName="Insert"
                                                        ValidationGroup="VGCondiciones_por_Estado" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivCondiciones_por_Estado">
                                            <asp:GridView ID="grdMultiCondiciones_por_Estado" runat="server" AllowPaging="True"
                                                AutoGenerateColumns="False" DataKeyNames="Folio, TTWorkFlow" OnRowCreated="grdMultiCondiciones_por_Estado_OnRowCreated"
                                                OnPageIndexChanging="grdMultiCondiciones_por_Estado_PageIndexChanging" OnRowDataBound="grdMultiCondiciones_por_Estado_RowDataBound"
                                                PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Condiciones_por_Estado',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fase">
                                                        <ItemTemplate>
                                                            <%--<asp:DropDownList ID="cddFase" runat="server" EnableViewState="true"
                                OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                            </asp:DropDownList>
                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                ServiceMethod="FillDataFasewithParentCDD" UseContextKey="true" />--%>
                                                            <asp:DropDownList ID="cddFase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" ParentControlID="cddTTWorkFlow_Folio"
                                                                UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddEstado" runat="server" CssClass="cdd2keys" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlEstado' , '{0}', this.value, 'Estado')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlEstado" runat="server" TargetControlID="cddEstado"  ContextKey='<%# Eval("TTWorkFlow") %>'
                                                                SelectedValue='<%# Eval("Estado") %>' Category="Estado" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataEstadowithParentCDD2" UseContextKey="true" ParentControlID="cddFase" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Operador de Condici&oacute;n">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddOperador_de_Condicion" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlOperador_de_Condicion' , '{0}', this.value, 'Operador_de_Condicion')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlOperador_de_Condicion" runat="server" TargetControlID="cddOperador_de_Condicion"
                                                                SelectedValue='<%# Eval("Operador_de_Condicion") %>' Category="Operador_de_Condicion"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataOperador_de_CondicionCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proceso">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddProceso" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlProceso' , '{0}', this.value, 'Proceso')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlProceso" runat="server" TargetControlID="cddProceso"
                                                                SelectedValue='<%# Eval("Proceso") %>' Category="Proceso" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataProcesoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Campo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddCampo" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlCampo' , '{0}', this.value, 'Campo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlCampo" runat="server" TargetControlID="cddCampo" SelectedValue='<%# Eval("Campo") %>'
                                                                Category="Campo" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataCampowithParentCDD" UseContextKey="true" ParentControlID="cddProceso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Condici&oacute;n">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddCondicion" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlCondicion' , '{0}', this.value, 'Condicion')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlCondicion" runat="server" TargetControlID="cddCondicion"
                                                                SelectedValue='<%# Eval("Condicion") %>' Category="Condicion" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataCondicionCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Operador">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddOperador" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'ddlOperador' , '{0}', this.value, 'Operador')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlOperador" runat="server" TargetControlID="cddOperador"
                                                                SelectedValue='<%# Eval("Operador") %>' Category="Operador" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataOperadorCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Valor Operador">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtValor_Operador" runat="server" Text='<%# Bind("Valor_Operador") %>'
                                                                onblur=<%# string.Format("processText('Modify', 'Condiciones_por_Estado', 'txtValor_Operador' , '{0}', this.value, 'Valor_Operador')", Eval("Folio")) %>>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Prioridad">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="txtPrioridad" runat="server" Text='<%#Eval("Prioridad")%>'
                                                                Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" ClientEvents-OnValueChanged="OnChangeNumericTextBox"
                                                                Operation="Modify" Multirenglon="Condiciones_por_Estado" ControlId="txtPrioridad"
                                                                Key='<%#Eval("Folio")%>' Field="Prioridad">
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
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagInformacion_por_Estado" Style="text-align: left;" runat="server"
            HeaderText="Información por Estado">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbInformacion_por_Estado" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
                            <tr id="trInformacion_por_Estado">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiInformacion_por_Estado" GroupingText="Informaci&oacute;n por Estado">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerInformacion_por_Estado" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiInformacion_por_Estado" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowInformacion_por_Estado" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="cmbShowInformacion_por_Estado_SelectedIndexChanged" EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblFaseMultiInformacion_por_Estado" runat="server" Text="Fase:"></asp:Label>
                                                    <asp:DropDownList ID="cddFaseMultiInformacion_por_Estado" runat="server" EnableViewState="true" >
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFaseMultiInformacion_por_Estado" runat="server" TargetControlID="cddFaseMultiInformacion_por_Estado"
                                                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" ParentControlID="cddTTWorkFlow_Folio"
                                                                UseContextKey="true" /><asp:RequiredFieldValidator ID="RFVFaseMultiInformacion_por_Estado" runat="server" ControlToValidate="cddFaseMultiInformacion_por_Estado"
                                                                 ValidationGroup="VGInformacion_por_Estado" Text="*"> </asp:RequiredFieldValidator>
                                                
                                                </td>
                                                <td>
                                                <asp:Label ID="lblProcesoMultiInformacion_por_Estado" runat="server" Text="Proceso:"></asp:Label>
                                                    <asp:DropDownList ID="cddProcesoMultiInformacion_por_Estado" runat="server" EnableViewState="true" >
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlProcesoMultiInformacion_por_Estado" runat="server" TargetControlID="cddProcesoMultiInformacion_por_Estado"
                                                                SelectedValue='<%# Eval("Proceso") %>' Category="Proceso" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataProcesoCDD" UseContextKey="true" />
                                                                <asp:RequiredFieldValidator ID="RFVProcesoMultiInformacion_por_Estado" runat="server" ControlToValidate="cddProcesoMultiInformacion_por_Estado"
                                                                 ValidationGroup="VGInformacion_por_Estado" Text="*"> </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewInformacion_por_Estado" ImageUrl="~/images/Design/add_item.png"
                                                        runat="server" OnClick="cmdInformacion_por_EstadoAdd_Click" CommandName="Insert"
                                                        ValidationGroup="VGInformacion_por_Estado"  />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivInformacion_por_Estado">
                                            <asp:GridView ID="grdMultiInformacion_por_Estado" runat="server" AllowPaging="True"
                                                AutoGenerateColumns="False" DataKeyNames="Folio, TTWorkFlow" OnRowCreated="grdMultiInformacion_por_Estado_OnRowCreated"
                                                OnPageIndexChanging="grdMultiInformacion_por_Estado_PageIndexChanging" OnRowDataBound="grdMultiInformacion_por_Estado_RowDataBound"
                                                PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Informacion_por_Estado',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fase">
                                                        <ItemTemplate>
                                                            <%--<asp:DropDownList ID="cddFase" runat="server" EnableViewState="true"
                                OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                            </asp:DropDownList>
                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                ServiceMethod="FillDataFasewithParentCDD" UseContextKey="true" /> --%>
                                                            <asp:DropDownList ID="cddFase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" ParentControlID="cddTTWorkFlow_Folio"
                                                                UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddEstado" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlEstado' , '{0}', this.value, 'Estado')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlEstado" runat="server" TargetControlID="cddEstado" ContextKey='<%# Eval("TTWorkFlow") %>'
                                                                SelectedValue='<%# Eval("Estado") %>' Category="Estado" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataEstadowithParentCDD2" UseContextKey="true" ParentControlID="cddFase" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proceso">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddProceso" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlProceso' , '{0}', this.value, 'Proceso')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlProceso" runat="server" TargetControlID="cddProceso"
                                                                SelectedValue='<%# Eval("Proceso") %>' Category="Proceso" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataProcesoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Carpeta">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddCarpeta" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlCarpeta' , '{0}', this.value, 'Carpeta')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlCarpeta" runat="server" TargetControlID="cddCarpeta"
                                                                SelectedValue='<%# Eval("Carpeta") %>' Category="Carpeta" PromptText="[Seleccionar un valor...]"
                                                                ParentControlID="cddProceso" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataCarpetawithParentCDD " UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Visible">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddVisible" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlVisible' , '{0}', this.value, 'Visible')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlVisible" runat="server" TargetControlID="cddVisible"
                                                                SelectedValue='<%# Eval("Visible") %>' Category="Visible" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataVisibleCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Solo Lectura">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddSolo_Lectura" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlSolo_Lectura' , '{0}', this.value, 'Solo_Lectura')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlSolo_Lectura" runat="server" TargetControlID="cddSolo_Lectura"
                                                                SelectedValue='<%# Eval("Solo_Lectura") %>' Category="Solo_Lectura" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataSolo_LecturaCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Obligatorios">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddObligatorios" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'ddlObligatorios' , '{0}', this.value, 'Obligatorios')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlObligatorios" runat="server" TargetControlID="cddObligatorios"
                                                                SelectedValue='<%# Eval("Obligatorios") %>' Category="Obligatorios" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Informacion_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataObligatoriosCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Etiqueta">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtEtiqueta" runat="server" Text='<%# Bind("Etiqueta") %>' onblur=<%# string.Format("processText('Modify', 'Informacion_por_Estado', 'txtEtiqueta' , '{0}', this.value, 'Etiqueta')", Eval("Folio")) %>>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagRoles_por_Estado" Style="text-align: left;" runat="server"
            HeaderText="Roles por Estado">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbRoles_por_Estado" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
                            <tr id="trRoles_por_Estado">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiRoles_por_Estado" GroupingText="Roles por Estado">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerRoles_por_Estado" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiRoles_por_Estado" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowRoles_por_Estado" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="cmbShowRoles_por_Estado_SelectedIndexChanged" EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewRoles_por_Estado" ImageUrl="~/images/Design/add_item.png"
                                                        runat="server" OnClick="cmdRoles_por_EstadoAdd_Click" CommandName="Insert" ValidationGroup="VGRoles_por_Estado" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivRoles_por_Estado">
                                            <asp:GridView ID="grdMultiRoles_por_Estado" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="Folio, TTWorkFlow" OnRowCreated="grdMultiRoles_por_Estado_OnRowCreated"
                                                OnPageIndexChanging="grdMultiRoles_por_Estado_PageIndexChanging" OnRowDataBound="grdMultiRoles_por_Estado_RowDataBound"
                                                PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Roles_por_Estado',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fase">
                                                        <ItemTemplate>
                                                            <%--<asp:DropDownList ID="cddFase" runat="server" EnableViewState="true"
                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                            </asp:DropDownList>
                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                ServiceMethod="FillDataFasewithParentCDD" UseContextKey="true" /> --%>
                                                            <asp:DropDownList ID="cddFase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" ParentControlID="cddTTWorkFlow_Folio"
                                                                UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddEstado" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlEstado' , '{0}', this.value, 'Estado')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlEstado" runat="server" TargetControlID="cddEstado" ContextKey='<%# Eval("TTWorkFlow") %>'
                                                                SelectedValue='<%# Eval("Estado") %>' Category="Estado" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataEstadowithParentCDD2" UseContextKey="true" ParentControlID="cddFase" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rol de Usuario">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddRol_de_Usuario" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlRol_de_Usuario' , '{0}', this.value, 'Rol_de_Usuario')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlRol_de_Usuario" runat="server" TargetControlID="cddRol_de_Usuario"
                                                                SelectedValue='<%# Eval("Rol_de_Usuario") %>' Category="Rol_de_Usuario" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataRol_de_UsuarioCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transici&oacute;n de Fase">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddTransicion_de_Fase" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlTransicion_de_Fase' , '{0}', this.value, 'Transicion_de_Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlTransicion_de_Fase" runat="server" TargetControlID="cddTransicion_de_Fase"
                                                                SelectedValue='<%# Eval("Transicion_de_Fase") %>' Category="Transicion_de_Fase"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataTransicion_de_FaseCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Consultar">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Consultar" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Consultar' , '{0}', this.value, 'Permiso_Consultar')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Consultar" runat="server" TargetControlID="cddPermiso_Consultar"
                                                                SelectedValue='<%# Eval("Permiso_Consultar") %>' Category="Permiso_Consultar"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_ConsultarCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Nuevo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Nuevo" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Nuevo' , '{0}', this.value, 'Permiso_Nuevo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Nuevo" runat="server" TargetControlID="cddPermiso_Nuevo"
                                                                SelectedValue='<%# Eval("Permiso_Nuevo") %>' Category="Permiso_Nuevo" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_NuevoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Modificar">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Modificar" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Modificar' , '{0}', this.value, 'Permiso_Modificar')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Modificar" runat="server" TargetControlID="cddPermiso_Modificar"
                                                                SelectedValue='<%# Eval("Permiso_Modificar") %>' Category="Permiso_Modificar"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_ModificarCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Eliminar">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Eliminar" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Eliminar' , '{0}', this.value, 'Permiso_Eliminar')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Eliminar" runat="server" TargetControlID="cddPermiso_Eliminar"
                                                                SelectedValue='<%# Eval("Permiso_Eliminar") %>' Category="Permiso_Eliminar" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_EliminarCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Exportar">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Exportar" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Exportar' , '{0}', this.value, 'Permiso_Exportar')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Exportar" runat="server" TargetControlID="cddPermiso_Exportar"
                                                                SelectedValue='<%# Eval("Permiso_Exportar") %>' Category="Permiso_Exportar" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_ExportarCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Imprimir">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Imprimir" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Imprimir' , '{0}', this.value, 'Permiso_Imprimir')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Imprimir" runat="server" TargetControlID="cddPermiso_Imprimir"
                                                                SelectedValue='<%# Eval("Permiso_Imprimir") %>' Category="Permiso_Imprimir" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_ImprimirCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permiso Configuraci&oacute;n">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddPermiso_Configuracion" runat="server" EnableViewState="true"
                                                                OnChange=<%# string.Format("processText('Modify', 'Roles_por_Estado', 'ddlPermiso_Configuracion' , '{0}', this.value, 'Permiso_Configuracion')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlPermiso_Configuracion" runat="server" TargetControlID="cddPermiso_Configuracion"
                                                                SelectedValue='<%# Eval("Permiso_Configuracion") %>' Category="Permiso_Configuracion"
                                                                PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Roles_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataPermiso_ConfiguracionCDD" UseContextKey="true" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPagMatriz_de_Estados" Style="text-align: left;" runat="server"
            HeaderText="Matriz de Estados">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table id="tbMatriz_de_Estados" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="0">
                            <tr id="trMatriz_de_Estados">
                                <td colspan="4">
                                    <asp:Panel runat="server" ID="panMultiMatriz_de_Estados" GroupingText="Matriz de Estados">
                                        <table>
                                            <tr>
                                                <td>
                                                    <TTPagers:PageNumbersPager ID="grdPagerMatriz_de_Estados" runat="server" CssClass="GridHeaderStyle" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShowMultiMatriz_de_Estados" runat="server" Text="Mostrar:"></asp:Label>
                                                    <asp:DropDownList ID="cmbShowMatriz_de_Estados" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="cmbShowMatriz_de_Estados_SelectedIndexChanged" EnableViewState="true">
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="10" Value="10" Selected="True" />
                                                        <asp:ListItem Text="20" Value="20" />
                                                        <asp:ListItem Text="50" Value="50" />
                                                        <asp:ListItem Text="100" Value="100" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="cmdNewMatriz_de_Estados" ImageUrl="~/images/Design/add_item.png"
                                                        runat="server" OnClick="cmdMatriz_de_EstadosAdd_Click" CommandName="Insert" ValidationGroup="VGMatriz_de_Estados" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="asyncDivMatriz_de_Estados">
                                            <asp:GridView ID="grdMultiMatriz_de_Estados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="Folio, TTWorkFlow" OnRowCreated="grdMultiMatriz_de_Estados_OnRowCreated"
                                                OnPageIndexChanging="grdMultiMatriz_de_Estados_PageIndexChanging" OnRowDataBound="grdMultiMatriz_de_Estados_RowDataBound"
                                                PagerSettings-Visible="false" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="cmdDelete" ImageUrl="~/images/delete.png" runat="server" CausesValidation="false"
                                                                OnClientClick=<%# string.Format("processText('Delete', 'Matriz_de_Estados',null,'{0}', null, null)", Eval("Folio")) %> />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fase">
                                                        <ItemTemplate>
                                                            <%--<asp:DropDownList ID="cddFase" runat="server" EnableViewState="true"
                                OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                            </asp:DropDownList>
                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                ServiceMethod="FillDataFasewithParentCDD" UseContextKey="true" ParentControlID="cddTTWorkFlow_Folio" /> --%>
                                                            <asp:DropDownList ID="cddFase" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlFase' , '{0}', this.value, 'Fase')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlFase" runat="server" TargetControlID="cddFase" SelectedValue='<%# Eval("Fase") %>'
                                                                Category="Fase" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_EstadosWS.asmx"
                                                                ServiceMethod="FillDataFasewithParentCDD" ParentControlID="cddTTWorkFlow_Folio"
                                                                UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddEstado" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlEstado' , '{0}', this.value, 'Estado')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlEstado" runat="server" TargetControlID="cddEstado" ContextKey='<%# Eval("TTWorkFlow") %>'
                                                                SelectedValue='<%# Eval("Estado") %>' Category="Estado" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Condiciones_por_EstadoWS.asmx"
                                                                ServiceMethod="FillDataEstadowithParentCDD2" UseContextKey="true" ParentControlID="cddFase" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proceso">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddProceso" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlProceso' , '{0}', this.value, 'Proceso')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlProceso" runat="server" TargetControlID="cddProceso"
                                                                SelectedValue='<%# Eval("Proceso") %>' Category="Proceso" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                                                ServiceMethod="FillDataProcesoCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Campo">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddCampo" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlCampo' , '{0}', this.value, 'Campo')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlCampo" runat="server" TargetControlID="cddCampo" SelectedValue='<%# Eval("Campo") %>'
                                                                Category="Campo" PromptText="[Seleccionar un valor...]" ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                                                ServiceMethod="FillDataCampowithParentCDD" UseContextKey="true" ParentControlID="cddProceso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Visible">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddVisible" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlVisible' , '{0}', this.value, 'Visible')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlVisible" runat="server" TargetControlID="cddVisible"
                                                                SelectedValue='<%# Eval("Visible") %>' Category="Visible" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                                                ServiceMethod="FillDataVisibleCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Obligatorio">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddObligatorio" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlObligatorio' , '{0}', this.value, 'Obligatorio')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlObligatorio" runat="server" TargetControlID="cddObligatorio"
                                                                SelectedValue='<%# Eval("Obligatorio") %>' Category="Obligatorio" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                                                ServiceMethod="FillDataObligatorioCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Solo Lectura">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="cddSolo_Lectura" runat="server" EnableViewState="true" OnChange=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'ddlSolo_Lectura' , '{0}', this.value, 'Solo_Lectura')", Eval("Folio")) %>>
                                                            </asp:DropDownList>
                                                            <cc1:CascadingDropDown ID="ddlSolo_Lectura" runat="server" TargetControlID="cddSolo_Lectura"
                                                                SelectedValue='<%# Eval("Solo_Lectura") %>' Category="Solo_Lectura" PromptText="[Seleccionar un valor...]"
                                                                ServicePath="http://192.168.1.101/WebServicesNanoTechnologyv1_0_1/TTWorkFlow_Matriz_de_EstadosWS.asmx"
                                                                ServiceMethod="FillDataSolo_LecturaCDD" UseContextKey="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Etiqueta">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtEtiqueta" runat="server" Text='<%# Bind("Etiqueta") %>' onblur=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'txtEtiqueta' , '{0}', this.value, 'Etiqueta')", Eval("Folio")) %>>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Valor por Defecto">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtValor_por_Defecto" runat="server" Text='<%# Bind("Valor_por_Defecto") %>'
                                                                onblur=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'txtValor_por_Defecto' , '{0}', this.value, 'Valor_por_Defecto')", Eval("Folio")) %>>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Texto de Ayuda">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTexto_de_Ayuda" runat="server" Text='<%# Bind("Texto_de_Ayuda") %>'
                                                                onblur=<%# string.Format("processText('Modify', 'Matriz_de_Estados', 'txtTexto_de_Ayuda' , '{0}', this.value, 'Texto_de_Ayuda')", Eval("Folio")) %>>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <asp:ValidationSummary ID="VSRequerid" runat="server" ShowMessageBox="True" ShowSummary="False"
        HeaderText="Se encontraron los siguientes errores:" Height="19px" Width="270px" />
    <br />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MnuButtonsPlace">
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
                <div id="btn_ayuda_catalog" onclick="btn_cmdHelpClick();" runat="server" style="visibility: hidden;">
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
                            __designer:wfdid="w15" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClear" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LIMPIAR.gif"
                            __designer:wfdid="w16" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdHelp" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif"
                            __designer:wfdid="w17" OnClick="cmdHelp_Click" Style="visibility: hidden;"></asp:ImageButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

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
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + '}',
                dataType: 'json',
                url: 'TTWorkFlow_Catalogo.aspx/Cancel',
                success: successCommandRedirect
            });
        }
        function btn_cmdClearClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + '}',
                dataType: 'json',
                url: 'TTWorkFlow_Catalogo.aspx/Clear',
                success: successCommandRedirect
            });
        }
        function btn_cmdHelpClick() {
            document.getElementById("<%=cmdHelp.ClientID%>").click();
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
    </script>

</asp:Content>














