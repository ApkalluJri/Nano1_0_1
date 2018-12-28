<%@ Page Culture="es-MX" UICulture="es-MX" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="true" Inherits="TTLanguage_Lista"
    Theme="SpanishLanguage" Title="Lista de TTLanguage" CodeFile="TTLanguage_Lista.aspx.cs" %>
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

<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="server">
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
                <div id="btn_filters">
                    <img alt="" src="../../Images/Design/filters.png" onclick="toggleItem();" style="cursor: hand;
                        cursor: pointer;" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../JSScripts/Funciones.js" type="text/javascript"></script>
    <script type="text/javascript">
        //  keeps track of the delete button for the row
        //  that is going to be removed
        //  rad_menu esta en el master page
        //  setDivsVisible esta en Funcion.js
        
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
            setDivsVisible(false);
        }

        function okClick() {
            //  find the confirm ModalPopup and hide it    
            this._popup.hide();
            //  use the cached button as the postback source
            __doPostBack(this._source.name, '');
            setDivsVisible(true);
        }

        function cancelClick() {
            //  find the confirm ModalPopup and hide it 
            this._popup.hide();
            //  clear the event source
            this._source = null;
            this._popup = null;
            setDivsVisible(true);
        }
              
        function toggleItem() {
            var panelBar = $find("<%=rpbFiltros.ClientID%>");
            var item = panelBar.findItemByValue("Filtros");

            if (item) {
                if (!item.get_expanded()) {
                    item.expand();
                }
                else {
                    item.collapse();
                }
            }
            else {
                alert("Item with text Filtros not found.");
            }
        }
    </script>

    <div id="grid_div" style="overflow:scroll">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td>   
                                <telerik:RadPanelBar ID="rpbFiltros" runat="server" Width="600px">
                                    <Items>
                                        <telerik:RadPanelItem Value="Filtros" Text="Filtro" runat="server" Height="1">
                                            <Items>
                                                <telerik:RadPanelItem runat="server" Value="templateHolder">
                                                    <ItemTemplate>
                                                        <div style="overflow: auto; height: 400px;">
                                                            <table runat="server" id="tblFiltros">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TTQuickFilterControl ID="TTSearchControl1" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="btnFilter" runat="server" ImageUrl="../../Images/Design/btn_filtros_rapidos-01.png" OnClick="btnFilter_Click" />
                                                                    <asp:ImageButton ID="btnClearFilter" runat="server" ImageUrl="../../Images/Design/btn_filtros_rapidos-02.png" OnClick="btnClearFilter_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </telerik:RadPanelItem>
                                            </Items>
                                        </telerik:RadPanelItem>                            
                                    </Items>
                                </telerik:RadPanelBar>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>                            
                    <asp:GridView ID="grdMov" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="2" Font-Size="Small" GridLines="Vertical" Height="84px" HorizontalAlign="Center"
                        OnRowCommand="GrdMov_RowCommand" DataKeyNames="TTLanguage_idLanguage" OnSorting="grdMov_Sorting"
                        OnRowCreated="grdMov_OnRowCreated" OnRowDeleting="GrdMov_RowDeleting" DataSourceID="ODSGrdMov"
                        PagerSettings-Visible="false">
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
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" ImageUrl="~/images/select.png" runat="server" OnClick="BtnSelect_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeaderStyle" />
                        <RowStyle CssClass="GridRowStyle" />
                        <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSGrdMov" runat="server" SelectMethod="SelAll" OnObjectCreating="ODSGrdMov_ObjectCreating"
                        OnSelected="ODSGrdMov_OnSelected" TypeName="TTLanguageCS.objectBussinessTTLanguage"
                        EnablePaging="True" SelectCountMethod="SelCount">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="grdMov" DefaultValue="" Name="sortDirection" PropertyName="SortDirection"
                                Type="String" />
                            <asp:ControlParameter ControlID="grdMov" Name="sortExpression" PropertyName="SortExpression"
                                Type="String" />
                            <asp:ControlParameter Name="maximumRows" Type="Int32" ControlID="grdMov" PropertyName="PageSize"
                                DefaultValue="15" />
                            <asp:ControlParameter Name="startRowIndex" Type="Int32" ControlID="grdMov" PropertyName="PageIndex"
                                DefaultValue="1" />                            
                        </SelectParameters>
                    </asp:ObjectDataSource>                                                       
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mdlPopup" runat="server"
        TargetControlID="div" PopupControlID="div" OkControlID="btnOk" OnOkScript="okClick();"
        CancelControlID="btnNo" OnCancelScript="cancelClick();" BackgroundCssClass="modalBackground" />
    <div id="div" runat="server" align="center" class="confirm" style="display: none">
        <img align="absmiddle" src="../Images/warning.jpg" />�Est�s seguro que deseas borrar
        este registro?
        <br />
        <asp:Button ID="btnOk" runat="server" Text="S�" Width="50px" />
        <asp:Button ID="btnNo" runat="server" Text="No" Width="50px" />
    </div>
  </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MnuButtonsPlace">

<script type="text/javascript">
        function btn_nuevoClick(){
        document.getElementById("<%=cmdNew.ClientID%>").click();
        }
        function btn_todosClick(){
        document.getElementById("<%=cmdAll.ClientID%>").click();
        }
        function btn_buscarClick(){
        document.getElementById("<%=cmdSearch.ClientID%>").click();
        }
        function btn_exportarClick(){
        document.getElementById("<%=cmdExport.ClientID%>").click();
        }
        function btn_imprimirClick(){
        document.getElementById("<%=cmdPrint.ClientID%>").click();
        }
        function btn_filtrarClick(){
        toggleItem();
        }
        function btn_configurarClick(){
        document.getElementById("<%=cmdConfiguration.ClientID%>").click();
        }        
</script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
          <div id="horizontal_menu_div">
            <div id="btn_nuevo" onclick="btn_nuevoClick();" runat="server"><p class="btns">Nuevo</p>
            </div>
            
            <div id="btn_divider_1">
            </div>
            
           <div id="btn_todos" onclick="btn_todosClick();" runat="server"><p class="btns">Todos</p>
            </div>

           <div id="btn_divider_2">
            </div>
            
           <div id="btn_buscar" onclick="btn_buscarClick();" runat="server"><p class="btns">Buscar</p>
            </div>
            
           <div id="btn_divider_3">
            </div>
            
           <div id="btn_exportar" onclick="btn_exportarClick();" runat="server"><p class="btns">Exportar</p>
            </div>
            
           <div id="btn_divider_4">
            </div>
            
           <div id="btn_imprimir" onclick="btn_imprimirClick();" runat="server"><p class="btns">Imprimir</p>
            </div>
             
            <div id="btn_divider_5">
            </div>
            
           <div id="btn_filtrar" onclick="btn_filtrarClick();" runat="server"><p class="btns">Filtrar</p>
            </div>
            
            <div id="btn_divider_6">
            </div>
            
           <div id="btn_configurar" onclick="btn_configurarClick();" runat="server"><p class="btns">Configurar</p>
            </div>
            
            <div id="btn_divider_7">
            </div>
          </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:ImageButton ID="cmdSelection" runat="server" Width="0" Height="0"  style="visibility:hidden;" __designer:wfdid="w11"
        ImageUrl="~/App_Themes/SpanishLanguage/Seleccionar.gif"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdNew" runat="server" style="visibility:hidden;" Width=0 Height=0  __designer:wfdid="w1" ImageUrl="~/App_Themes/SpanishLanguage/NUEVO.gif"
        OnClick="cmdNew_Click"></asp:ImageButton>
    <asp:ImageButton ID="cmdAll" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w2" ImageUrl="~/App_Themes/SpanishLanguage/TODOS.gif"
        OnClick="cmdAll_Click"></asp:ImageButton>&nbsp;       
    <asp:ImageButton id="cmdSearch" runat="server" style="visibility:hidden;" __designer:wfdid="w3" ImageUrl="~/App_Themes/SpanishLanguage/BUSCAR.gif" OnClick="cmdSearch_Click"></asp:ImageButton>&nbsp;
    <%--<asp:ImageButton ID="cmdExtraService" style="visibility:hidden;" runat="server" __designer:wfdid="w4" ImageUrl="~/App_Themes/SpanishLanguage/EXTRAS.gif">
    </asp:ImageButton>&nbsp;--%>                 
    <asp:ImageButton ID="cmdExport" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w5" ImageUrl="~/App_Themes/SpanishLanguage/EXPORTAR.gif"
        OnClick="cmdExport_Click"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdPrint" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w6" ImageUrl="~/App_Themes/SpanishLanguage/IMPRIMIR.gif"
        OnClick="cmdPrint_Click"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdViews" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w7" ImageUrl="~/App_Themes/SpanishLanguage/Vistas.gif">
    </asp:ImageButton>&nbsp;
    <img alt="" src="../../App_Themes/SpanishLanguage/FILTRAR.png" Width="0" Height="0"  onclick="toggleItem();" style="cursor:hand; cursor:pointer;"/>&nbsp;
    <asp:ImageButton ID="cmdConfiguration" runat="server" style="visibility:hidden;" Width="0" Height="0"  __designer:wfdid="w8" ImageUrl="~/App_Themes/SpanishLanguage/CONFIGURAR.gif"
        OnClick="cmdConfiguration_Click"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdHelp" runat="server" style="visibility:hidden;" Width="0" Height="0"  __designer:wfdid="w10" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif">
    </asp:ImageButton>&nbsp;
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <telerik:RadWindow ID="rwExport" runat="server" VisibleOnPageLoad="false" Width="850"
                Height="530" Behaviors="Default" VisibleStatusbar="false" Modal="true" Animation="Fade">
            </telerik:RadWindow>            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>








