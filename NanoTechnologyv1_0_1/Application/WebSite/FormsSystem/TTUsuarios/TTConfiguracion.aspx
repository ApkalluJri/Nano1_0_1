<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="FormsSystem.TTUsuarios.FormsSystem_TTConfiguracion"
    Title="" CodeFile="TTConfiguracion.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script type="text/javascript">
        function processText(control, columna, renglon, tipo) {
            var sValor = "";
            if (tipo == "1") {
                TBox = document.getElementById("ctl00_MainContent_" + control);
                sValor = TBox.checked;
            } else {
                TBox = document.getElementById("ctl00_MainContent_" + control);
                sValor = TBox.value;
            }
            callserver(sValor + "@" + columna + "@" + renglon + "@" + tipo);

        }

        function ReceiveServerData(arg, context) {
            if (arg != null);
            {
                var arr = arg.split('@');
                var Tbox = document.getElementById(arr[0]);
                if (Tbox != null)
                    Tbox.value = arr[1];
            }
        }

        function btn_cmdGrabarClick() {
            document.getElementById("<%=cmdGrabar.ClientID%>").click();
        }
        function btn_cmdCancelarClick() {
            document.getElementById("<%=cmdCancelar.ClientID%>").click();
        }
    </script>

    <div id="grid_div">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" CssClass="panelConfiguracion">
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="horizontal_menu_div">
        <div id="btn_guardar_list" onclick="btn_cmdGrabarClick();">
            <p class="btns">
                <asp:Label ID="lblGuardar" runat="server" Text="Guardar"></asp:Label></p>
        </div>
        <div id="btn_divider_1">
        </div>
        <div id="btn_cancelar_list" onclick="btn_cmdCancelarClick();">
            <p class="btns">
                <asp:Label ID="lblCancelar" runat="server" Text="Cancelar"></asp:Label>
            </p>
        </div>
        <div id="btn_divider_2">
        </div>
    </div>
    <asp:Button ID="cmdGrabar" runat="server" Text="Grabar" OnClick="cmdGrabar_Click"
        Style="visibility: hidden;" />
    <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" OnClick="cmdCancelar_Click"
        Style="visibility: hidden;" />
</asp:Content>








