<%@ Page Title="" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="FormsSystem_TTPermisos_TTPermisos_por_proceso_Lista" CodeFile="TTPermisos_por_proceso_Lista.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMsgGrupoUsuario" runat="server" Text="Grupo de Usuario " Font-Names="Tahoma"
                Font-Size="Small"></asp:Label>
            <asp:DropDownList ID="cbIdGrupoUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbIdGrupoUsuario_SelectedIndexChanged"
                DataSourceID="objDSGpoUsuario" DataTextField="TTGrupo_de_Usuario_Descripcion"
                DataValueField="TTGrupo_de_Usuario_IdGrupoUsuario" EnableViewState="true" OnDataBound="cbIdGrupoUsuario_DataBound">
                <asp:ListItem Text="- Seleccione -" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvGrupoUsuario" runat="server" ErrorMessage="Seleccione el Grupo de Usuario"
                InitialValue="" ControlToValidate="cbIdGrupoUsuario">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="objDSGpoUsuario" runat="server" SelectMethod="SelAll" TypeName="TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario">
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
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="grvPermisos" runat="server" AutoGenerateColumns="False" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="IdModulo" DataField="IdModulo" UniqueName="IdModulo"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdModulo" runat="server" Text='<%#Eval("IdModulo")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdProceso" DataField="IdProceso" UniqueName="IdProceso"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdProceso" runat="server" Text='<%#Eval("IdProceso")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Modulo" HeaderText="Módulo" ReadOnly="True" UniqueName="Modulo">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Proceso" HeaderText="Proceso/Descripción" ReadOnly="True"
                                UniqueName="Proceso">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Nuevo" DataField="Nuevo" UniqueName="Nuevo">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxNuevoHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderNuevo" runat="server" Text="Nuevo"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxNuevo" Checked='<%#Convert.ToBoolean(Eval("Nuevo"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Modificar" DataField="Modificar" UniqueName="Modificar">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxModificarHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderModificar" runat="server" Text="Modificar"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxModificar" Checked='<%#Convert.ToBoolean(Eval("Modificar"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Eliminar" DataField="Eliminar" UniqueName="Eliminar">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxEliminarHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderEliminar" runat="server" Text="Eliminar"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxEliminar" Checked='<%#Convert.ToBoolean(Eval("Eliminar"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Exportar" DataField="Exportar" UniqueName="Exportar">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxExportarHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderExportar" runat="server" Text="Exportar"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxExportar" Checked='<%#Convert.ToBoolean(Eval("Exportar"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Imprimir" DataField="Imprimir" UniqueName="Imprimir">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxImprimirHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderImprimir" runat="server" Text="Imprimir"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxImprimir" Checked='<%#Convert.ToBoolean(Eval("Imprimir"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Configuracion" DataField="Configuracion"
                                UniqueName="Configuracion">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxConfiguracionHeader" onclick="ToggleCheck(this, this.checked)" />
                                    <asp:Label ID="lblHeaderConfiguracion" runat="server" Text="Configuración"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="checkBoxConfiguracion" Checked='<%#Convert.ToBoolean(Eval("Configuracion"))%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdNuevo" DataField="IdNuevo" UniqueName="IdNuevo"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdNuevo" runat="server" Text='<%#Eval("IdNuevo")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdModificar" DataField="IdModificar" UniqueName="IdModificar"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdModificar" runat="server" Text='<%#Eval("IdModificar")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdEliminar" DataField="IdEliminar" UniqueName="IdEliminar"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdEliminar" runat="server" Text='<%#Eval("IdEliminar")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdExportar" DataField="IdExportar" UniqueName="IdExportar"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdExportar" runat="server" Text='<%#Eval("IdExportar")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdImprimir" DataField="IdImprimir" UniqueName="IdImprimir"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdImprimir" runat="server" Text='<%#Eval("IdImprimir")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="IdConfiguracion" DataField="IdConfiguracion"
                                UniqueName="IdConfiguracion" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdConfiguracion" runat="server" Text='<%#Eval("IdConfiguracion")%>'></asp:Label>
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









