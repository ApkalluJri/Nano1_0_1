<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="FormsSystem.TTWorkFlow.FormsSystem_TTBusquedaAvanzada"
    Title="Página de Búsqueda" CodeFile="TTBusquedaAvanzada.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../App_Themes/layout_list_horizontal_menu.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function processText(control, tipo, dtid, tabla, campo, renglon) {
            var sWhere = "";
            var sDesde = "";
            var sHasta = "";
            var sValor = "";
            var tipotexto = "";
            var cant = 0;

            if (tipo == "1") //Numerico
            {
                TBox = document.getElementById("ctl00_MainContent_CampoValorDesde_" + dtid);
                sDesde = TBox.value;

                TBox = document.getElementById("ctl00_MainContent_CampoValorHasta_" + dtid);
                sHasta = TBox.value;

                sWhere = " AND (" + tabla + "." + campo + " >= " + sDesde + " AND " + tabla + "." + campo + " <= " + sHasta + ")"
                if (sDesde == "" || sHasta == "") {
                    sWhere = "";
                }
            }
            if (tipo == "2") //Texto
            {

                TBox = document.getElementById("ctl00_MainContent_CampoValor_" + dtid);
                sValor = TBox.value;

                TBox = document.getElementById("ctl00_MainContent_Opciones_" + dtid);
                tipotexto = TBox.selectedIndex;
                if (tipotexto == "0") //Que empieze
                {
                    sWhere = " AND (" + tabla + "." + campo + " like '" + sValor + "%')";
                }
                if (tipotexto == "1") //Que contenga
                {
                    sWhere = " AND (" + tabla + "." + campo + " like '%" + sValor + "%')";
                }
                if (tipotexto == "2") //Que termine
                {
                    sWhere = " AND (" + tabla + "." + campo + " like '%" + sValor + "')";
                }
                if (tipotexto == "3") //Palabra exacta
                {
                    sWhere = " AND (" + tabla + "." + campo + " = '" + sValor + "')";
                }
                if (sValor == "") {
                    sWhere = "";
                }
            }
            if (tipo == "3") //Dependiente
            {
                TBox = document.getElementById("ctl00_MainContent_" + control);

                cant = TBox.length;
                for (i = 0; i < cant; i++) {
                    if (TBox.options[i].selected == true) {
                        sWhere = sWhere + " OR " + tabla + "." + campo + " = " + TBox.options[i].value;
                    }
                }
            }
            if (tipo == "4") //Fechas
            {
                TBox = document.getElementById("ctl00_MainContent_CampoValorDesde_" + dtid);
                sDesde = TBox.value;

                TBox = document.getElementById("ctl00_MainContent_CampoValorHasta_" + dtid);
                sHasta = TBox.value;

                sWhere = " AND (" + tabla + "." + campo + " >= '" + sDesde + "' AND " + tabla + "." + campo + " <= '" + sHasta + "')";

                if (sDesde == "" || sHasta == "") {
                    sWhere = "";
                }

            }
            if (tipo == "6") //Booleano
            {
                TBox = document.getElementById("ctl00_MainContent_CampoValor_" + dtid);
                sValor = TBox.value;

                if ( sValor != "" )
                    sWhere = " AND (" + tabla + "." + campo + " = " + sValor + ")";                
            }
            
            callserver(sWhere + "@" + dtid + "@" + renglon + "@" + tipo);

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

        function btn_cmdBuscarClick() {
            document.getElementById("<%=cmdBuscar.ClientID%>").click();
        }
        function btn_cmdCerrarClick() {
            document.getElementById("<%=cmdCerrar.ClientID%>").click();
        }
    </script>

    <div id="grid_div">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="panelConfiguracion">
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="horizontal_menu_div">
        <div id="btn_buscar_list" onclick="btn_cmdBuscarClick();">
            <p class="btns">
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label></p>
        </div>
        <div id="btn_divider_1">
        </div>
        <div id="btn_cancelar_list" onclick="btn_cmdCerrarClick();">
            <p class="btns">
                <asp:Label ID="lblCancelar" runat="server" Text="Cancelar"></asp:Label></p>
        </div>
        <div id="btn_divider_2">
        </div>
    </div>
    <asp:Button ID="cmdBuscar" OnClick="cmdBuscar_Click1" runat="server" Text="Buscar"
        Style="visibility: hidden"></asp:Button>&nbsp;
    <asp:Button ID="cmdCerrar" OnClick="cmdCerrar_Click" runat="server" Text="Cerrar"
        Style="visibility: hidden"></asp:Button>
</asp:Content>








