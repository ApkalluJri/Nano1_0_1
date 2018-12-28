<%@ Page Title="" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    ValidateRequest="false" AutoEventWireup="true"
    Inherits="FormsSystem_TTBusinessRules_TTBusinessRules_Catalogo" CodeFile="TTBusinessRules_Catalogo.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="Server">
    <telerik:RadScriptBlock runat="Server" ID="RadScriptBlock1">

        <script type="text/javascript">
            //![CDATA[

            //]]>             
        </script>

    </telerik:RadScriptBlock>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:RadTabStrip ID="rtsBusinessRules" runat="server" MultiPageID="RadMultiPage1"
                SelectedIndex="0" OnTabClick="rtsBusinessRules_TabClick" Skin="Outlook">
                <Tabs>
                    <telerik:RadTab Text="General Info" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Conditions">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Actions">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Relations" Visible="false">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Reports" Visible="false">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Rights" Visible="false">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>            
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="pageViewAdmin">
                <telerik:RadPageView ID="rpvGeneral" runat="server">
                    <asp:Panel ID="PanelDatosGenerales" runat="server" GroupingText="Datos Generales" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblidBusinessRule" runat="server" Text="Folio:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtidBusinessRule" runat="server" ReadOnly="true"></asp:TextBox>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblIdProceso" runat="server" Text="Proceso:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="txtIdProceso" runat="server" ValidationGroup="MainValidation"></asp:TextBox>&nbsp;--%>
                                    <asp:RequiredFieldValidator ID="valddlProceso" runat="server" ErrorMessage="El Campo Proceso es requerido"
                                        ControlToValidate="ddlProceso" ValidationGroup="MainValidation" Display="Dynamic"
                                        InitialValue="">*</asp:RequiredFieldValidator>&nbsp;
                                    <telerik:RadComboBox ID="ddlProceso" runat="server" EnableLoadOnDemand="True" OnItemsRequested="ddlProceso_ItemsRequested"
                                        EmptyMessage="Seleccione el proceso" HighlightTemplatedItems="true" Width="300px"
                                        ValidationGroup="MainValidation" DropDownWidth="300px">
                                        <HeaderTemplate>
                                            <table cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 40px;">
                                                        Folio
                                                    </td>
                                                    <td style="width: 236px;">
                                                        Proceso
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 40px;">
                                                        <%# DataBinder.Eval(Container, "Attributes['TTProceso_IdProceso']")%>
                                                    </td>
                                                    <td style="width: 236px;">
                                                        <%# DataBinder.Eval(Container, "Attributes['TTProceso_Nombre']")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <%--<uc1:TTbuttonCatalogo ID="TTbcSelProcess" runat="server" URL="~/FormsSystem/TTBusquedaCatalogo.aspx" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server" TextMode="MultiLine" ValidationGroup="MainValidation" Width="400px"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="valTxtNombre" runat="server" ErrorMessage="El Campo Nombre es requerido"
                                        Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="MainValidation">*</asp:RequiredFieldValidator>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaAlta" runat="server" Text="Fecha de Alta:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtFecha_de_Alta" runat="server">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="valDtFecha_de_Alta" runat="server" ErrorMessage="Campo Fecha de Alta es requerido"
                                        ControlToValidate="dtFecha_de_Alta" ValidationGroup="MainValidation" Display="Dynamic">*</asp:RequiredFieldValidator>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAlcance" runat="server" GroupingText="Alcance" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cbAlcance" runat="server" DataSourceID="ODScbAlcance" DataTextField="Descripcion"
                                        DataValueField="idAlcance" OnSelectedIndexChanged="cbAlcance_SelectedIndexChanged"
                                        AutoPostBack="True" ValidationGroup="MainValidation">
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="valCbAlcance" runat="server" ErrorMessage="El Campo Alcance es requerido"
                                        Display="Dynamic" ControlToValidate="cbAlcance" InitialValue="" ValidationGroup="MainValidation">*</asp:RequiredFieldValidator>&nbsp;
                                    <asp:ObjectDataSource ID="ODScbAlcance" runat="server" SelectMethod="FillDataAlcance"
                                        TypeName="TTBusinessRulesCS.objectBussinessTTBusinessRules"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="cmdAlcanceNuevo" runat="server" Text="Nuevo" Enabled="False" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelOperacion" runat="server" GroupingText="Operación" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:ListBox ID="lstOperacion" runat="server" DataSourceID="ODSlstOperacion" DataTextField="Descripcion"
                                        DataValueField="idOperacion" SelectionMode="Multiple" ValidationGroup="MainValidation">
                                    </asp:ListBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="valLstOperacion" runat="server" ErrorMessage="El Campo Operacio es requerido"
                                        Display="Dynamic" ControlToValidate="lstOperacion" InitialValue="" ValidationGroup="MainValidation">*</asp:RequiredFieldValidator>&nbsp;
                                    <asp:ObjectDataSource ID="ODSlstOperacion" runat="server" SelectMethod="FillDataOperacion"
                                        TypeName="TTBusinessRulesCS.objectBussinessTTBusinessRules"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="cmdOperacionNuevo" runat="server" Text="Nuevo" Enabled="False" /><br />
                                    <asp:Button ID="cmdOperacionAlls" runat="server" Text="Todos" CommandArgument="SelectAll"
                                        OnClick="cmdOperacion_Click" /><br />
                                    <asp:Button ID="cmdOperacionNone" runat="server" Text="Ninguno" CommandArgument="ClearAll"
                                        OnClick="cmdOperacion_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelEventoDelProceso" runat="server" GroupingText="Evento del Proceso" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:ListBox ID="lstEvento_Proceso" runat="server" DataSourceID="ODSlstEvento_Proceso"
                                        DataTextField="Descripcion" DataValueField="idEvent" SelectionMode="Multiple"
                                        ValidationGroup="MainValidation"></asp:ListBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="valLstEvento_Proceso" runat="server" ErrorMessage="El Campo Evento del Proceso requerido"
                                        Display="Dynamic" ControlToValidate="lstEvento_Proceso" InitialValue="" ValidationGroup="MainValidation">*</asp:RequiredFieldValidator>&nbsp;
                                    <asp:ObjectDataSource ID="ODSlstEvento_Proceso" runat="server" TypeName="TTBusinessRulesCS.objectBussinessTTBusinessRules"
                                        SelectMethod="FillDataEvento_Proceso"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="cmdEvento_ProcesoNuevo" runat="server" Text="Nuevo" Enabled="False" /><br />
                                    <asp:Button ID="cmdEvento_ProcesoAlls" runat="server" Text="Todos" CommandArgument="SelectAll"
                                        OnClick="cmdEvento_Proceso_Click" /><br />
                                    <asp:Button ID="cmdEvento_ProcesoNone" runat="server" Text="Ninguno" CommandArgument="ClearAll"
                                        OnClick="cmdEvento_Proceso_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelEventoDelCampo" runat="server" GroupingText="Evento del Campo" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:ListBox ID="lstEvento_Campo" runat="server" DataSourceID="ODSlstEvento_Campo"
                                        DataTextField="Descripcion" DataValueField="idEvent" SelectionMode="Multiple"
                                        ValidationGroup="MainValidation"></asp:ListBox>
                                    <asp:RequiredFieldValidator ID="valLstEvento_Campo" runat="server" ErrorMessage="El Campo Evento del Campo es requerido"
                                        Display="Dynamic" ControlToValidate="lstEvento_Campo" InitialValue="" ValidationGroup="MainValidation">*</asp:RequiredFieldValidator>&nbsp;
                                    &nbsp;
                                    <asp:ObjectDataSource ID="ODSlstEvento_Campo" runat="server" TypeName="TTBusinessRulesCS.objectBussinessTTBusinessRules"
                                        SelectMethod="FillDataEvento_Campo"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="cmdEvento_CampoNuevo" runat="server" Text="Nuevo" Enabled="False" /><br />
                                    <asp:Button ID="cmdEvento_CampoAlls" runat="server" Text="Todos" CommandArgument="SelectAll"
                                        OnClick="cmdEvento_Campo_Click" /><br />
                                    <asp:Button ID="cmdEvento_CampoNone" runat="server" Text="Ninguno" CommandArgument="ClearAll"
                                        OnClick="cmdEvento_Campo_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvConditions" runat="server">
                    <asp:Panel ID="PanelConditions" runat="server" GroupingText="Condiciones" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Button ID="cmdCondicionesPopup" runat="server" Text="Nuevo" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="grvCondiciones" runat="server" AllowPaging="True" GridLines="None" Skin="Office2007"
                                        AutoGenerateColumns="False" ShowStatusBar="True" EnableLinqExpressions="False"
                                        OnItemDataBound="grvCondiciones_ItemDataBound" OnItemCommand="grvCondiciones_ItemCommand">
                                        <MasterTableView CommandItemDisplay="Top" EditMode="InPlace" DataKeyNames="idBusinessRules, idFolio, CondicionOperador, Tipo_Operador1, Valor_Operador1, Condicion, Tipo_Operador2, Valor_Operador2">
                                            <CommandItemSettings AddNewRecordText="Agregar nuevo registro" RefreshText="Actualizar" />
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Operador de Condición">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlOperadorDeCondicion" runat="server" Enabled="false" DataSourceID="ODSCondicionOperador"
                                                            DataTextField="Descripcion" DataValueField="idOperator">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlOperadorDeCondicionF" runat="server" DataSourceID="ODSCondicionOperador"
                                                            DataTextField="Descripcion" DataValueField="idOperator">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Operador 1">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeOperador1" runat="server" Enabled="false" DataSourceID="ODSTipo_Operador1"
                                                            DataTextField="Descripcion" DataValueField="idOperator">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeOperador1F" runat="server" DataSourceID="ODSTipo_Operador1"
                                                            DataTextField="Descripcion" DataValueField="idOperator" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDeOperador1F_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Valor del Operador 1">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdValorDelOperador1" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblValorDelOperador1" runat="server" Text="Valor 1"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlValorDelOperador1" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtValorDelOperador1" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Condición">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlCondicion" runat="server" Enabled="false" DataSourceID="ODSCondicion"
                                                            DataTextField="Descripcion" DataValueField="idCondicion">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlCondicionF" runat="server" DataSourceID="ODSCondicion" DataTextField="Descripcion"
                                                            DataValueField="idCondicion">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Operador 2">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeOperador2" runat="server" Enabled="false" DataSourceID="ODSTipo_Operador2"
                                                            DataTextField="Descripcion" DataValueField="idOperator">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeOperador2F" runat="server" DataSourceID="ODSTipo_Operador2"
                                                            DataTextField="Descripcion" DataValueField="idOperator" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDeOperador2F_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Valor del Operador 2">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdValorDelOperador2" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblValorDelOperador2" runat="server" Text="Valor 2"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlValorDelOperador2" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtValorDelOperador2" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                                                <telerik:GridButtonColumn ConfirmText="¿Confirma que desea borrar el registro?" ConfirmDialogType="RadWindow"
                                                    ConfirmTitle="Borrar" ButtonType="ImageButton" CommandName="Delete" Text="Borrar"
                                                    UniqueName="DeleteColumn">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn UniqueName="EditCommandColumn1">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <PagerStyle PagerTextFormat="Cambiar p&#225;gina: {4} &#160;|&#160; P&#225;gina {0} de {1}, &#237;tems {2} a {3} de {5}." />
                                        <FilterMenu>
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </FilterMenu>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <asp:ObjectDataSource ID="ODSgrvCondiciones" runat="server" SelectMethod="SelAll"
                                        TypeName="TTBusinessRules_ConditionCS.objectBussinessTTBusinessRules_Condition">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="true" Name="ConRelaciones" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ODSCondicionOperador" runat="server" SelectMethod="FillDataCondicionOperador"
                                        TypeName="TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions">
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ODSTipo_Operador1" runat="server" SelectMethod="FillDataTipo_Operador1"
                                        TypeName="TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions">
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ODSCondicion" runat="server" SelectMethod="FillDataCondicion"
                                        TypeName="TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions">
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ODSTipo_Operador2" runat="server" SelectMethod="FillDataTipo_Operador2"
                                        TypeName="TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvActions" runat="server">
                    <asp:Panel ID="PanelActions" runat="server" GroupingText="If Full Fills" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Button ID="cmdAcciones_TruePopup" runat="server" Text="..." Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="grvAcciones_True" runat="server" AllowPaging="True" GridLines="None" Skin="Office2007"
                                        AutoGenerateColumns="False" ShowStatusBar="True" EnableLinqExpressions="False"
                                        OnItemDataBound="grvAcciones_ItemDataBound" OnItemCommand="grvAcciones_True_ItemCommand">
                                        <MasterTableView CommandItemDisplay="Top" EditMode="InPlace" DataKeyNames="idBusinessRules, idFolio, Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5">
                                            <CommandItemSettings AddNewRecordText="Agregar nuevo registro" RefreshText="Actualizar" />
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Acción">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccion" runat="server" Enabled="false" DataSourceID="ODSTipoDeAccion"
                                                            DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionF" runat="server" DataSourceID="ODSTipoDeAccion"
                                                            DataTextField="Descripcion" DataValueField="idAccion" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDeAccionF_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Acción de Resultado">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionDeResultado" runat="server" Enabled="false"
                                                            DataSourceID="ODSTipoDeAccionDeResultado" DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionDeResultadoF" runat="server" DataSourceID="ODSTipoDeAccionDeResultado"
                                                            DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn  HeaderText="Parametro 1">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro1" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro1" runat="server" Text="Parametro 1"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro1" runat="server" OnSelectedIndexChanged="ddlParametro1_SelectedIndexChanged" >
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro1" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 2">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro2" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro2" runat="server" Text="Parametro 2"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro2" runat="server" >
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro2" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 3">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro3" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro3" runat="server" Text="Parametro 3"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro3" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro3" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 4">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro4" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro4" runat="server" Text="Parametro 4"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro4" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro4" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 5">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro5" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro5" runat="server" Text="Parametro 5"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro5" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro5" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                                                <telerik:GridButtonColumn ConfirmText="¿Confirma que desea borrar el registro?" ConfirmDialogType="RadWindow"
                                                    ConfirmTitle="Borrar" ButtonType="ImageButton" CommandName="Delete" Text="Borrar"
                                                    UniqueName="DeleteColumn">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn UniqueName="EditCommandColumn1">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <PagerStyle PagerTextFormat="Cambiar p&#225;gina: {4} &#160;|&#160; P&#225;gina {0} de {1}, &#237;tems {2} a {3} de {5}." />
                                        <FilterMenu>
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </FilterMenu>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" GroupingText="If Not FullFills" CssClass="BRTabPanel">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Button ID="cmdAcciones_FalsePopup" runat="server" Text="..." Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="grvAcciones_False" runat="server" AllowPaging="True" GridLines="None" Skin="Office2007"
                                        AutoGenerateColumns="False" ShowStatusBar="True" EnableLinqExpressions="False"
                                        OnItemDataBound="grvAcciones_ItemDataBound" OnItemCommand="grvAcciones_False_ItemCommand">
                                        <MasterTableView CommandItemDisplay="Top" EditMode="InPlace" DataKeyNames="idBusinessRules, idFolio, Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5">
                                            <CommandItemSettings AddNewRecordText="Agregar nuevo registro" RefreshText="Actualizar" />
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Acción">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccion" runat="server" Enabled="false" DataSourceID="ODSTipoDeAccion"
                                                            DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionF" runat="server" DataSourceID="ODSTipoDeAccion"
                                                            DataTextField="Descripcion" DataValueField="idAccion" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDeAccionF_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tipo de Acción de Resultado">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionDeResultado" runat="server" Enabled="false"
                                                            DataSourceID="ODSTipoDeAccionDeResultado" DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTipoDeAccionDeResultadoF" runat="server" DataSourceID="ODSTipoDeAccionDeResultado"
                                                            DataTextField="Descripcion" DataValueField="idAccion">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 1">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro1" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro1" runat="server" Text="Parametro 1"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlParametro1_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro1" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 2">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro2" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro2" runat="server" Text="Parametro 2"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro2" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro2" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 3">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro3" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro3" runat="server" Text="Parametro 3"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro3" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro3" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 4">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro4" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro4" runat="server" Text="Parametro 4"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro4" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro4" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Parametro 5">
                                                    <ItemTemplate>
                                                        <asp:Button ID="cmdParametro5" runat="server" Enabled="false" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblParametro5" runat="server" Text="Parametro 5"></asp:Label><br />
                                                        <telerik:RadComboBox ID="ddlParametro5" runat="server">
                                                        </telerik:RadComboBox>
                                                        <telerik:RadTextBox ID="txtParametro5" runat="server" TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                                                <telerik:GridButtonColumn ConfirmText="¿Confirma que desea borrar el registro?" ConfirmDialogType="RadWindow"
                                                    ConfirmTitle="Borrar" ButtonType="ImageButton" CommandName="Delete" Text="Borrar"
                                                    UniqueName="DeleteColumn">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn UniqueName="EditCommandColumn1">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <PagerStyle PagerTextFormat="Cambiar p&#225;gina: {4} &#160;|&#160; P&#225;gina {0} de {1}, &#237;tems {2} a {3} de {5}." />
                                        <FilterMenu>
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </FilterMenu>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="ODSTipoDeAccion" runat="server" SelectMethod="FillDataTipo_Accion"
                            TypeName="TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue">
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ODSTipoDeAccionDeResultado" runat="server" SelectMethod="FillDataTipo_Accion_Resultado"
                            TypeName="TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue">
                        </asp:ObjectDataSource>
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvRelations" runat="server">
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <asp:ValidationSummary ID="VSRequerid" runat="server" ValidationGroup="MainValidation"
                ShowMessageBox="True" ShowSummary="False" HeaderText="Se encontraron los siguientes errores:"
                Height="19px" Width="270px" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MnuButtonsPlace" runat="Server">

    <script type="text/javascript" language="javascript">
        function btn_cmdSaveCopyClick() {
            document.getElementById("<%=cmdSaveCopy.ClientID%>").click();
        }
        function btn_cmdSaveNewClick() {
            document.getElementById("<%=cmdSaveNew.ClientID%>").click();
        }
        function btn_cmdSaveClick() {
            document.getElementById("<%=cmdSave.ClientID%>").click();
        }
        function btn_cmdCloseClick() {
            document.getElementById("<%=cmdClose.ClientID%>").click();
        }
        function btn_cmdNewClick() {
            document.getElementById("<%=cmdNew.ClientID%>").click();
        }
        function btn_cmdHelpClick() {
            document.getElementById("<%=cmdHelp.ClientID%>").click();
        }        
    </script>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="horizontal_menu_div_catalog">
                <!-- -------DIVIDER------- -->
                <div id="btn_grabar_bussines_rules" onclick="btn_cmdSaveClick();">
                    <p class="btns" id="pGuardar">
                        Grabar</p>
                </div>
                <div id="btn_divider_1_catalog">
                </div>
                <div id="btn_grabar_nuevo_bussines_rules" onclick="btn_cmdSaveNewClick();">
                    <p class="btns">
                        Grabar y Nuevo</p>
                </div>
                <div id="btn_divider_2_catalog">
                </div>
                <div id="btn_grabar_copiar_bussines_rules" onclick="btn_cmdSaveCopyClick();">
                    <p class="btns">
                        Grabar y Copiar</p>
                </div>
                <div id="btn_divider_3_catalog">
                </div>
                <div id="btn_limpiar_bussines_rules" onclick="btn_cmdNewClick();">
                    <p class="btns">
                        Limpiar</p>
                </div>
                <div id="btn_divider_4_catalog">
                </div>
                <div id="btn_cerrar_bussines_rules" onclick="btn_cmdCloseClick();">
                    <p class="btns">
                        Cerrar</p>
                </div>
                <div id="btn_divider_5_catalog">
                </div>
                <div id="btn_ayuda_bussines_rules" onclick="btn_cmdHelpClick();">
                    <p class="btns">
                        Ayuda</p>
                </div>
            </div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Button ID="cmdSaveCopy" runat="server" Text="Guardar y Copiar" ValidationGroup="MainValidation"
                            Style="visibility: hidden" CausesValidation="true" OnClick="cmdSaveCopy_Click" />&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdSaveNew" runat="server" Text="Guardar y Nuevo" ValidationGroup="MainValidation"
                            Style="visibility: hidden" CausesValidation="true" OnClick="cmdSaveNew_Click" />&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdSave" runat="server" Text="Guardar" OnClick="cmdSave_Click" ValidationGroup="MainValidation"
                            Style="visibility: hidden" CausesValidation="true" />&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdClose" runat="server" Text="Cerrar" OnClick="cmdClose_Click" Style="visibility: hidden" />&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdNew" runat="server" Text="Limpiar" OnClick="cmdNew_Click" Style="visibility: hidden" />&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdHelp" runat="server" Text="Ayuda" Style="visibility: hidden" />&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div>
                <div>
                    <span>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text="" Font-Bold="True" ForeColor="#CC0000"
                            EnableViewState="false"></asp:Label><br />
                        <br />
                    </span>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>











