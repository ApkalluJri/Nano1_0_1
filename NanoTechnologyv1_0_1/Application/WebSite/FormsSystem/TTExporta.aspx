<%@ Page Language="C#" MasterPageFile="~/MasterTitulo.master" AutoEventWireup="true" Inherits="FormsSystem_TTExporta" Title="Untitled Page" CodeFile="TTExporta.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=3.1.9.807, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">    
    <telerik:ReportViewer ID="trvwReport" runat="server" Width="100%" Height="440px">
    </telerik:ReportViewer>    
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>









