<%@ Page Language="C#" AutoEventWireup="true" Inherits="FormsSystem.TTPermisos.WebForms_Reporte_por_Renglon" CodeFile="Reporte_por_Renglon.aspx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
  <%--  <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../WebForms/formatocatalogos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function imprimir()
        {                   

window.document.execCommand('print', false, null);
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <div>
        <table style="width: 100%">
            <tr>
                <td align="center">
                <!--#include file="inc_header.aspx"-->                    
                </td>
            </tr>
            <tr>
                <td align="center">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" style="height: 65px">
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
                </td>
            </tr>
            <tr>
<td style="text-align:center;" >
<asp:Button ID="btnPrintCtrlP" Text="Imprimir" runat="server" OnClientClick="imprimir(); return false;" />
                </td>
            </tr>
        </table>
    </div>
    </form>
     
   
    
</body>
 
</html>













