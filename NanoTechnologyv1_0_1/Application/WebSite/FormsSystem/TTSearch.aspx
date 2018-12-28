<%@ Page Language="C#" AutoEventWireup="true" Inherits="FormsSystem_TTSearch" CodeFile="TTSearch.aspx.cs" %>
<%@ Register Src="TTSearchControl.ascx" TagName="TTSearchControl" TagPrefix="uc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Filtros</title>
    <script language="javascript" type="text/javascript">
        function updateFromOpener(isDetail, idProces) {
            var openW = window.parent;
            if (openW != null) {
                window.parent.UpdateFromWindow(isDetail, idProces);
            }            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
            <tr>
                <td>
                    <uc1:TTSearchControl ID="TTSearchControl1" runat="server" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAcept" runat="server" Text="Aceptar" 
                        onclick="btnAcept_Click" />
                    <asp:Button ID="btnClose" runat="server" Text="Cancelar" 
                        onclick="btnClose_Click" />
                </td>
            </tr>
        </table>                  
    </div>
    </form>
</body>
</html>








