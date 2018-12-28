<%@ Page Culture="es-MX" UICulture="es-MX" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTGrupo_Reporte_Lista"
    Theme="SpanishLanguage" Title="Lista de TTGrupo de Reporte" CodeFile="TTGrupo_Reporte_Lista.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentSlider" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="pages_slider">
                <asp:TTPageSlider ID="TTPageSlide" runat="server" />
            </div>
            <div id="ProgressImage">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <img alt="" src="../../Images/progress.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagerPlace" runat="server">
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <div id="topgrid_div">
                <div id="row_info">
                    <div class="topgrid_info" id="row_info_label_div">
                        <asp:Label ID="lblTotalRecords" runat="server" Text="Registros:" Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div id="num_rows">
                    <div class="mostrar_label_format" id="mostrar_div">
                        <asp:Label ID="lblshow" runat="server" Font-Size="Small" Text="Mostrar"></asp:Label>
                    </div>
                    <div id="mostrar_cmbShow">
                        <asp:DropDownList ID="cmbShow" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbShow_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../WebForms/Funcion.js" type="text/javascript"></script>

    <script type="text/javascript">
        //  keeps track of the delete button for the row
        //  that is going to be removed
        var _source;
        // keep track of the popup div
        var _popup;

        function OpenImage(img) {
            var largo = 260;
            var altura = 200;
            var top = (screen.height - altura) / 2;
            var izquierda = (screen.width - largo) / 2;

            foto1 = new Image();
            foto1.src = (img);
            ancho = foto1.width + 20;
            alto = foto1.height + 20;
            cadena = "width=" + ancho + ",height=" + alto + ",top=" + top + ",left=" + izquierda;
            ventana = window.open("MuestraArchivos.aspx?archivo=" + img, "null", cadena);
        }

        function showConfirm(source) {
            this._source = source;
            this._popup = $find('mdlPopup');

            //  find the confirm ModalPopup and show it    
            this._popup.show();
        }

        function okClick() {
            //  find the confirm ModalPopup and hide it    
            this._popup.hide();
            //  use the cached button as the postback source
            __doPostBack(this._source.name, '');
        }

        function cancelClick() {
            //  find the confirm ModalPopup and hide it 
            this._popup.hide();
            //  clear the event source
            this._source = null;
            this._popup = null;
        }        
    </script>

    <div id="grid_div" style="overflow:scroll">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grdMov" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="2" Font-Size="Small" GridLines="Vertical" Height="84px" HorizontalAlign="Center"
                    OnPageIndexChanging="grdMov_PageIndexChanging" DataSourceID="ODSGrvMov" OnSorting="grdMov_Sorting"
                    OnRowCommand="GrdMov_RowCommand" DataKeyNames="TTGrupo_Reporte_IdGrupoReporte"
                    OnRowDeleting="GrdMov_RowDeleting" PagerSettings-Visible="false" OnRowCreated="grdMov_OnRowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Select" FooterText="&quot;order&quot;">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:ImageButton ID="IbtnBorrarSeleccion" runat="server" ImageUrl="~/images/delete.png"
                                    OnClick="IbtnBorrarSeleccion_Click"></asp:ImageButton>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" ImageUrl="~/images/delete.png" runat="server" OnClientClick="showConfirm(this); return false;"
                                    OnClick="BtnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeaderStyle" />
                    <RowStyle CssClass="GridRowStyle" />
                    <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                    <PagerStyle CssClass="GridHeaderStyle" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ODSGrvMov" runat="server" SelectMethod="SelAll" OnSelected="ODSGrdMov_OnSelected"
                    TypeName="TTGrupo_ReporteCS.objectBussinessTTGrupo_Reporte">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="ConRelaciones" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <cc1:ModalPopupExtender BehaviorID="mdlPopup" runat="server" TargetControlID="div"
            PopupControlID="div" OkControlID="btnOk" OnOkScript="okClick();" CancelControlID="btnNo"
            OnCancelScript="cancelClick();" BackgroundCssClass="modalBackground" />
        <div id="div" runat="server" align="center" class="confirm" style="display: none">
            <img align="absmiddle" src="../../Images/warning.jpg" />�Est�s seguro que deseas
            borrar este registro?
            <br />
            <asp:Button ID="btnOk" runat="server" Text="S�" Width="50px" />
            <asp:Button ID="btnNo" runat="server" Text="No" Width="50px" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MnuButtonsPlace">

    <script type="text/javascript">
        function btn_nuevoClick() {
            document.getElementById("<%=cmdNew.ClientID%>").click();
        }
        function btn_todosClick() {
            document.getElementById("<%=cmdAll.ClientID%>").click();
        }
        function btn_buscarClick() {
            document.getElementById("<%=cmdSearch.ClientID%>").click();
        }
        function btn_exportarClick() {
            document.getElementById("<%=cmdExport.ClientID%>").click();
        }
        function btn_imprimirClick() {
            document.getElementById("<%=cmdPrint.ClientID%>").click();
        }
        function btn_filtrarClick() {
            toggleItem();
        }
        function btn_configurarClick() {
            document.getElementById("<%=cmdConfiguration.ClientID%>").click();
        }        
    </script>

    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
        <ContentTemplate>
            <div id="horizontal_menu_div">
                <div id="btn_nuevo" onclick="btn_nuevoClick();" runat="server">
                    <p class="btns">
                        Nuevo</p>
                </div>
                <div id="btn_divider_1">
                </div>
                <div id="btn_todos" onclick="btn_todosClick();" runat="server">
                    <p class="btns">
                        Todos</p>
                </div>
                <div id="btn_divider_2">
                </div>
                <div id="btn_buscar" onclick="btn_buscarClick();" runat="server" style="visibility: hidden">
                    <p class="btns">
                        Buscar</p>
                </div>
                <div id="btn_divider_3">
                </div>
                <div id="btn_exportar" onclick="btn_exportarClick();" runat="server">
                    <p class="btns">
                        Exportar</p>
                </div>
                <div id="btn_divider_4">
                </div>
                <div id="btn_imprimir" onclick="btn_imprimirClick();" runat="server">
                    <p class="btns">
                        Imprimir</p>
                </div>
                <div id="btn_divider_5">
                </div>
                <div id="btn_filtrar" onclick="btn_filtrarClick();" runat="server" style="visibility: hidden">
                    <p class="btns">
                        Filtrar</p>
                </div>
                <div id="btn_divider_6">
                </div>
                <div id="btn_configurar" onclick="btn_configurarClick();" runat="server">
                    <p class="btns">
                        Configurar</p>
                </div>
                <div id="btn_divider_7">
                </div>
            </div>
            <asp:ImageButton ID="cmdSelection" runat="server" Width="0" Height="0" Style="visibility: hidden;"
                __designer:wfdid="w11" ImageUrl="~/App_Themes/SpanishLanguage/Seleccionar.gif">
            </asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdNew" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w1" ImageUrl="~/App_Themes/SpanishLanguage/NUEVO.gif"
                OnClick="cmdNew_Click"></asp:ImageButton>
            <asp:ImageButton ID="cmdAll" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w2" ImageUrl="~/App_Themes/SpanishLanguage/TODOS.gif"
                OnClick="cmdAll_Click"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdSearch" runat="server" Style="visibility: hidden;" __designer:wfdid="w3"
                ImageUrl="~/App_Themes/SpanishLanguage/BUSCAR.gif" OnClick="cmdSearch_Click">
            </asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdExport" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w5" ImageUrl="~/App_Themes/SpanishLanguage/EXPORTAR.gif"
                OnClick="cmdExport_Click"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdPrint" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w6" ImageUrl="~/App_Themes/SpanishLanguage/IMPRIMIR.gif"
                OnClick="cmdPrint_Click"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdViews" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w7" ImageUrl="~/App_Themes/SpanishLanguage/Vistas.gif">
            </asp:ImageButton>&nbsp;
            <img alt="" src="../../App_Themes/SpanishLanguage/FILTRAR.png" width="0" height="0"
                onclick="toggleItem();" style="cursor: hand; cursor: pointer;" />&nbsp;
            <asp:ImageButton ID="cmdConfiguration" runat="server" Style="visibility: hidden;"
                Width="0" Height="0" __designer:wfdid="w8" ImageUrl="~/App_Themes/SpanishLanguage/CONFIGURAR.gif"
                OnClick="cmdConfiguration_Click"></asp:ImageButton>&nbsp;
            <asp:ImageButton ID="cmdHelp" runat="server" Style="visibility: hidden;" Width="0"
                Height="0" __designer:wfdid="w10" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif">
            </asp:ImageButton>&nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <telerik:RadWindow ID="rwExport" runat="server" VisibleOnPageLoad="false" Width="850"
                Height="530" Behaviors="Default" VisibleStatusbar="false" Modal="true" Animation="Fade">
            </telerik:RadWindow>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>









