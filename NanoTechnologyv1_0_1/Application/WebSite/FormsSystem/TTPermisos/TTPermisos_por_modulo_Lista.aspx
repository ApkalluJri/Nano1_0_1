<%@ Page Title="" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="FormsSystem_TTPermisos_TTPermisos_por_modulo_Lista" CodeFile="TTPermisos_por_modulo_Lista.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <script type="text/javascript">
        function ToggleCheck(objCheckBox, value) {
            tableCheckBoxes = $get('<%=grvPermisos.ClientID %>_ctl00');
            cellIndex = objCheckBox.parentNode.cellIndex;

            for (var i = 0; i < tableCheckBoxes.rows.length; i++) {
                var checkBox = tableCheckBoxes.rows[i].cells[cellIndex].firstChild;
                var findCheckBox = false;

                while (!findCheckBox) {
                    if (checkBox == null || checkBox.type != "checkbox")
                        checkBox = checkBox.nextSibling;
                    else {
                        findCheckBox = true;
                    }
                }
                checkBox.checked = value
            }
        }
        
        function btn_cmdGrabarClick() {
            document.getElementById("<%=cmdAcept.ClientID%>").click();
        }
        function btn_cmdCancelarClick() {
            document.getElementById("<%=cmdCancel.ClientID%>").click();
        }
        
    </script>

    <div id="grid_div" style="overflow:scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="grvPermisos" runat="server" GridLines="None" AutoGenerateColumns="False">
                    <MasterTableView>
                        <Columns>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling UseStaticHeaders="true" />
                        <%--AllowScroll="true" <ClientEvents OnScroll="handleScrolling" />--%>
                    </ClientSettings>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <div id="horizontal_menu_div">
        <div id="btn_guardar_list" onclick="btn_cmdGrabarClick();">
            <p class="btns">
                Guardar</p>
        </div>
        <div id="btn_divider_1">
        </div>
        <div id="btn_cancelar_list" onclick="btn_cmdCancelarClick();">
            <p class="btns">
                Cancelar</p>
        </div>
        <div id="btn_divider_2">
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button ID="cmdAcept" runat="server" Text="Aceptar" OnClick="cmdAcept_Click" style="visibility:hidden" />
            <asp:Button ID="cmdCancel" runat="server" Text="Cancelar" OnClick="cmdCancel_Click" CausesValidation="False" style="visibility:hidden"/>            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MnuButtonsPlace" runat="Server">    
</asp:Content>









