<%@ Control Language="C#" AutoEventWireup="true" Inherits="FormsSystem_TTbuttonCatalogo"
    CodeFile="TTbuttonCatalogo.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:ImageButton ID="cmdCatalogo" runat="server" CommandArgument="1" style="vertical-align:middle" ImageUrl="~/Images/Design/new_item.png"
    CausesValidation="false" OnClick="cmdCatalogo_Click" />
    
<%-- IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013--%>
<%-- OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. --%>
<%-- region --%>
<asp:ImageButton ID="cmdCatalogoModify" runat="server" CommandArgument="2" Style="vertical-align: middle"
    ImageUrl="~/Images/Design/modify_item.png" ValidationGroup="CatalogModifyDelete"
    CausesValidation="true" OnClick="cmdCatalogo_Click" />
<asp:ImageButton ID="cmdCatalogoDelete" runat="server" CommandArgument="3" Style="vertical-align: middle"
    ImageUrl="~/Images/Design/delete_item.png" ValidationGroup="CatalogModifyDelete"
    CausesValidation="true" OnClientClick="return false;" OnClick="cmdCatalogo_Click" />
<%-- endregion --%>

<telerik:RadWindow ID="windowCatalogo" runat="server" ShowContentDuringLoad="false"
    Width="800" Height="450" Behaviors="Default" VisibleStatusbar="false" Modal="true"
    VisibleOnPageLoad="false">
</telerik:RadWindow>  

<%-- IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013--%>
<%-- OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. --%>
<%-- region --%>
<asp:CustomValidator ID="RFVCatalogModify" ValidationGroup="CatalogModifyModify"
    EnableClientScript="true" runat="server" ClientValidationFunction="RFVCatalog_Client"
    Display="Dynamic" ErrorMessage="Debe seleccionar una opcion del combo." Text="*"
    Style="vertical-align: super"></asp:CustomValidator>

<asp:CustomValidator ID="RFVCatalogDelete" ValidationGroup="CatalogModifyDelete"
    EnableClientScript="true" runat="server" ClientValidationFunction="RFVCatalog_Client"
    Display="Dynamic" ErrorMessage="Debe seleccionar una opcion del combo." Text="*"
    Style="vertical-align: super"></asp:CustomValidator>

<asp:ValidationSummary ID="SummaryCatalogModify" runat="server" ShowMessageBox="True"
    ShowSummary="False" ValidationGroup="CatalogModifyDelete" HeaderText="Se encontraron los siguientes errores:"
    Height="19px" Width="270px" />

<asp:ValidationSummary ID="SummaryCatalogDelete" runat="server" ShowMessageBox="True"
    ShowSummary="False" ValidationGroup="CatalogModifyDelete" HeaderText="Se encontraron los siguientes errores:"
    Height="19px" Width="270px" />
<%-- endregion --%>








