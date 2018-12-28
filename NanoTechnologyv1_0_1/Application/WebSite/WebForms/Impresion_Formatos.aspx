<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Impresion_Formatos.aspx.cs" Inherits="WebForms.Impresion_Formatos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:Transparent;">
<head runat="server">
    <title></title>
    <script src="../JSScripts/Funciones.js" type="text/javascript"></script>
    <link href="../App_Themes/layout_master_page_rad.css" rel="stylesheet" type="text/css" />
    
</head>
<body style="background-color:Transparent;">
<script type="text/javascript">
        function Editar() {
            var radioButtons = document.getElementsByName("<%=rbListFormatos.ClientID%>");
            var permisoImprimir = document.getElementById("<%=hfPermisoImprimir.ClientID%>").value;
            var permisoGuardar = document.getElementById("<%=hfPermisoGuardar.ClientID%>").value;
            
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value != "0") {
                        setTimeout(function() {
                            var wn = GetRadWindow();
                            wn.setUrl("Edicion_Formatos.aspx?ID=" + radioButtons[x].value + "&IDM=" + document.getElementById("<%=hfIDM.ClientID%>").value + "&Imprimir=" + permisoImprimir + "&Guardar=" + permisoGuardar)
                            wn.set_height(600);
                            wn.center();
                        }, 0);
                        break;
                    }
                }
            }
        }
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scpm3" runat="server"></asp:ScriptManager>
    <div style="width:835px;height:466px;overflow:auto;">
    <div style="width:835px;height:466px;overflow:auto;">
    <div>        
            <asp:HiddenField ID="hfIdProceso" runat="server" />
         <asp:HiddenField ID="hfIDM" runat="server" />
         <asp:HiddenField ID="hfPermisoImprimir" runat="server" />
         <asp:HiddenField ID="hfPermisoGuardar" runat="server" />
        <table style="margin-left:auto;margin-right:auto;min-height:300px" >
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbListFormatos" runat="server"  AutoPostBack="true"
                        AppendDataBoundItems="true" DataTextField="Nombre" 
                        DataValueField="idFormato" 
                        onselectedindexchanged="rbListFormatos_SelectedIndexChanged" >
                        <asp:ListItem Text="Impresión Detallada" Value="0" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upBotones" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="botones" OnClientClick="Editar();" Visible="false" />                            
                            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="botones" OnClick="btnImprimir_Click" />
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar en campo" CssClass="botones"  Visible="false"
                                OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botones" OnClientClick="CloseWindow();" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnImprimir" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>









