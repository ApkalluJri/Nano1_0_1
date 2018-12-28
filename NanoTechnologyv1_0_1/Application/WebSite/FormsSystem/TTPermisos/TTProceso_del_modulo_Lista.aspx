<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="FormsSystem_TTPermisos_TTProceso_del_modulo_Lista"
    Title="Procesos del Módulo" CodeFile="TTProceso_del_modulo_Lista.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblModulo" runat="server" Text="Módulo " Font-Names="Tahoma" Font-Size="Small"></asp:Label>
            <asp:DropDownList ID="cbIdModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbIdModulo_SelectedIndexChanged"
                DataSourceID="objDSModulo" DataTextField="TTModulo_Nombre" DataValueField="TTModulo_IdModulo"
                EnableViewState="true" OnDataBound="cbIdModulo_DataBound">
                <asp:ListItem Text="- Seleccione -" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvModulo" runat="server" ErrorMessage="Seleccione el Módulo"
                InitialValue="" ControlToValidate="cbIdModulo">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="objDSModulo" runat="server" SelectMethod="SelAll" TypeName="TTModuloCS.objectBussinessTTModulo">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ConRelaciones" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <script type="text/javascript">
        function ToggleCheck(objCheckBox, value) {
            tableCheckBoxes = $get('<%=grvProcesos.ClientID %>_ctl00');
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="grvProcesos" runat="server" AutoGenerateColumns="False" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="IdProceso" DataField="IdProceso" UniqueName="IdProceso"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblProceso" runat="server" Text='<%#Eval("IdProceso")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Proceso/Descripción" ReadOnly="True"
                                UniqueName="Proceso">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Disponible" DataField="Disponible" UniqueName="Disponible">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxDisponibleHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderDisponible" runat="server" Text="Disponible"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxDisponible" Checked='<%#Convert.ToBoolean(Eval("Disponible"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MnuButtonsPlace" runat="Server">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="cmdAcept" runat="server" Text="Aceptar" OnClick="cmdAcept_Click"
                Style="visibility: hidden" />
            <asp:Button ID="cmdCancel" runat="server" Text="Cancelar" CausesValidation="False"
                OnClick="cmdCancel_Click" Style="visibility: hidden" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>









