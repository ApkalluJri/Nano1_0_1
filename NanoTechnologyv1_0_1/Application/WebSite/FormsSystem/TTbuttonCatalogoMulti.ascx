<%@ Control Language="C#" AutoEventWireup="True" Inherits="FormsSystem_TTbuttonCatalogoMulti"
    CodeFile="TTbuttonCatalogoMulti.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:ImageButton ID="cmdCatalogo" runat="server" 
    ImageUrl="~/Images/Design/add_item.png" 
    CausesValidation="false" onclick="cmdCatalogo_Click" />

<telerik:RadWindow ID="windowCatalogo" runat="server" ShowContentDuringLoad="false"  
    Width="800" Height="450" Behaviors="Default" VisibleStatusbar="false" Modal="true" 
    VisibleOnPageLoad="false">
</telerik:RadWindow>







