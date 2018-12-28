<%@ Control Language="C#" AutoEventWireup="True" Inherits="FormsSystem_TTbuttonCatalogoMultiEdit"
    CodeFile="TTbuttonCatalogoMultiEdit.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

    <style>
        .Hide { display:none; } 
    </style> 

<asp:ImageButton ID="cmdCatalogo" runat="server" CssClass="Hide"
    CausesValidation="false" onclick="cmdCatalogo_Click" />

<telerik:RadWindow ID="windowCatalogo" runat="server" ShowContentDuringLoad="false"  
    Width="800" Height="450" Behaviors="Default" VisibleStatusbar="false" Modal="true" 
    VisibleOnPageLoad="false">
</telerik:RadWindow>







