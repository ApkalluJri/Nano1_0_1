<%@ Page Title="" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master" AutoEventWireup="True" CodeFile="TTFormato_Asignacion_de_Permisos.aspx.cs" Inherits="FormsSystem.TTFormatos.TTFormato_Asignacion_de_Permisos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content3" ContentPlaceHolderID="PagerPlace" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblGrupodeUsuarios" runat="server" Text="Grupo de Usuarios " Font-Names="Tahoma"
                Font-Size="Small"></asp:Label>
            <asp:DropDownList ID="cbIdGrupodeUsuarios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbIdGrupodeUsuarios_SelectedIndexChanged"
                DataSourceID="objDSGrupodeUsuarios" DataTextField="TTGrupo_de_Usuario_Descripcion"
                DataValueField="TTGrupo_de_Usuario_IdGrupoUsuario" EnableViewState="true" OnDataBound="cbIdGrupodeUsuarios_DataBound">
                <asp:ListItem Text="- Seleccione -" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvGrupodeUsuarios" runat="server" ErrorMessage="Seleccione el Grupo de Usuarios"
                InitialValue="" ControlToValidate="cbIdGrupodeUsuarios">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="objDSGrupodeUsuarios" runat="server" SelectMethod="SelAll"
                TypeName="TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ConRelaciones" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function ToggleCheck(objCheckBox, value) {
            tableCheckBoxes = $get('<%=grvFormatos.ClientID %>_ctl00');
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

        function handleScrolling(sender, args) {
            //check if the items are scrolled to bottom and get additional items
            if (args.get_isOnBottom()) {
                var master = sender.get_masterTableView();
                if (master.get_pageSize() < master.get_virtualItemCount()) {
                    //changing page size causes automatic rebind
                    master.set_pageSize(master.get_pageSize() + 20);
                }
            }
        }

        function btn_cmdGrabarClick() {
            document.getElementById("<%=cmdAcept.ClientID%>").click();
        }
        function btn_cmdCancelarClick() {
            document.getElementById("<%=cmdCancel.ClientID%>").click();
        }
    </script>

    <div id="grid_div">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="grvFormatos" runat="server" AutoGenerateColumns="False" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="IdFormato" DataField="IdFormato" UniqueName="IdFormato"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormato" runat="server" Text='<%#Eval("idFormato")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Formato/Descripción" ReadOnly="True"
                                UniqueName="Nombre">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Imprimir" DataField="Imprimir" UniqueName="Imprimir">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxImprimirHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderImprimir" runat="server" Text="Imprimir"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxImprimir" Checked='<%#Convert.ToBoolean(Eval("Imprimir"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="Editar" DataField="Editar" UniqueName="Editar">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxEditarHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderEditar" runat="server" Text="Editar"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxEditar" Checked='<%#Convert.ToBoolean(Eval("Editar"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                                                         <telerik:GridTemplateColumn HeaderText="Guardar en campo" DataField="Guardar" UniqueName="Guardar">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxGuardarHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderGuardar" runat="server" Text="Guardar"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxGuardar" Checked='<%#Convert.ToBoolean(Eval("Guardar"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling UseStaticHeaders="true" />
                        <%--AllowScroll="true"<ClientEvents OnScroll="handleScrolling" />--%>
                    </ClientSettings>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MnuButtonsPlace" runat="server">
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








