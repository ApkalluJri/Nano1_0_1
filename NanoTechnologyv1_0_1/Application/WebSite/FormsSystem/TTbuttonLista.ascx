<%@ Control Language="C#" AutoEventWireup="true" Inherits="FormsSystem_TTbuttonLista" CodeFile="TTbuttonLista.ascx.cs" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:ImageButton ID="cmdLista" runat="server" 
    ImageUrl="~/Images/search.png" 
    CausesValidation="false" onclick="cmdLista_Click" />
<asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
<telerik:RadWindow ID="windowLista" runat="server" ShowContentDuringLoad="false"  
    Width="800" Height="600" Behaviors="Default" VisibleStatusbar="false" Modal="true" 
    VisibleOnPageLoad="false">
</telerik:RadWindow>







