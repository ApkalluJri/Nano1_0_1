<%@ Page Culture="es-MX" UICulture="es-MX" Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
    AutoEventWireup="True" CodeFile="TTFormatos_Lista.aspx.cs" Inherits="WebForms.TTFormatos_Lista"
    Theme="SpanishLanguage" Title="Lista de TTFormatos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentSlider" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="grid_div" style="overflow:scroll">                       
                    <asp:HiddenField ID="hfCurrentPage" runat="server" />
                    <asp:HiddenField ID="hfFilters" runat="server" />
                    <asp:HiddenField ID="hfsort" runat="server" />
                            <telerik:RadGrid ID="grdRadMov" AllowSorting="true" AllowPaging="true" AllowFilteringByColumn="true"
            AutoGenerateColumns="false" runat="server" EnableViewState="false" CellPadding="2" 
            BorderWidth="0" Font-Size="Small" GridLines="Vertical" HorizontalAlign="Center"  OnInit="grdRadMov_Init"
                        Skin="" CssClass="gridData" AllowMultiRowSelection="true">
            <MasterTableView DataKeyNames="TTFormatos_idFormato" ClientDataKeyNames="TTFormatos_idFormato" CurrentResetPageIndexAction="ReportError"
                BorderWidth="0" NoMasterRecordsText="No se encontraron registros" >
                <Columns>
                </Columns>
            </MasterTableView>
              <PagerStyle Mode="NextPrevNumericAndAdvanced" CssClass="topgrid_div" />
            <HeaderStyle CssClass="GridHeaderStyle" />
            <ItemStyle CssClass="GridRowStyle" />
            <AlternatingItemStyle CssClass="GridAlternateRowStyle" />
            <ClientSettings Selecting-AllowRowSelect="true" > 
                <ClientEvents OnCommand="RadGrid_Command" OnDataBinding="RadGrid_DataBinding" OnDataBound="RadGridDataBound" />
                <DataBinding Location="TTFormatos_Lista.aspx" SelectMethod="GetDataAndCount" EnableCaching="false" >
                </DataBinding>
            </ClientSettings>
            </telerik:RadGrid>                                                    
  </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MnuButtonsPlace">

    <script type="text/javascript">
        // GRID PAGER
        $($('.topgrid_div')[0].children.item(0).children.item(0).children.item(0).children.item(0).children.item(0).lastChild).addClass('lastchild');
        $($(".lastchild")[0].children.item(2)).addClass('child3');
        $($(".lastchild")[0].children.item(4)).addClass('child5');
        $($(".lastchild")[0].children.item(6)).addClass('child7');

        var Idelement = 0;
        var inicio = true;
        var first = true;

        function RadGridDataBound(sender, args) {
            if (first) {
                first = false;
                var update = false;
                var table = $find("<%= grdRadMov.ClientID %>").get_masterTableView();
                var currentPage = document.getElementById("<%= hfCurrentPage.ClientID %>").value;
                if (currentPage == table.CurrentPageIndex) {
                    update = true;
                }
                if (!update) {
                    table.set_currentPageIndex(parseInt(currentPage));
                }
            }
        }

        function RadGrid_DataBinding(sender, args) {
            args.get_methodArguments().saveState = !inicio;
            if (inicio) {
                inicio = false;
                var table = $find("<%= grdRadMov.ClientID %>").get_masterTableView();
                var filter = eval(document.getElementById("<%= hfFilters.ClientID %>").value);
                var sort = eval(document.getElementById("<%= hfsort.ClientID %>").value);

                var sortExpression = new Telerik.Web.UI.GridSortExpression();
                for (i = 0; i < $(sort).length; i++) {
                    var sort = sort[i];
                    sortExpression.set_fieldName(sort.FieldName);
                    sortExpression.set_sortOrder(sort.SortOrder);
                    table._sortExpressions.add(sortExpression);
                    //table._showSortIconForField(fieldName, sortOrder);
                }
                var filterExpression = new Telerik.Web.UI.GridFilterExpression();
                for (i = 0; i < $(filter).length; i++) {
                    var filter = filter[i];
                    filterExpression.set_fieldName(filter.FieldName);
                    filterExpression.set_fieldValue(filter.FieldValue);
                    filterExpression.set_dataTypeName(filter.DataTypeName);
                    filterExpression.set_filterFunction(filter.FilterFunction);
                    filterExpression.set_columnUniqueName(filter.ColumnUniqueName);
                    //table._updateFilterControlValue(filter.FieldValue, filter.ColumnUniqueName, filter.FilterFunction);
                    table._filterExpressions.add(filterExpression);
                }
                args.get_methodArguments().filterExpression = table._filterExpressions.toList();
                args.get_methodArguments().sortExpression = table._sortExpressions.toList();
            }
        }
      
        function RadGrid_Command(sender, args) {
            var command = args.get_commandName();
            if (command == "Delete") {
                Idelement = args.get_tableView().get_dataItems()[args.get_commandArgument()].getDataKeyValue('TTFormatos_idFormato');
                radconfirm(DeleteMessageConfirmation.value, confirmDeleteCallBackFn);
                return false;
            }
            else if (command == "Select") {
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: '{ Id: ' + sender._clientKeyValues[args.get_commandArgument()].TTFormatos_idFormato + '}',
                    dataType: 'json',
                    url: 'TTFormatos_lista.aspx/Select',
                    success: successCommandRedirect
                });
            }
            else if (command == "Consult") {
                SendFolio(args, 'TTFormatos_lista.aspx/Consult', successCommandRedirect);
            }
            else if (command == "Edit") {
                SendFolio(args, 'TTFormatos_lista.aspx/Edit', successCommandRedirect);
            }
            else if (command == "Print") {
                SendFolio(args, 'TTFormatos_lista.aspx/Print', successCommandPrint);
            }
        }

        function SendFolio(args, surl, onsuccess) {
            Idelement = args.get_tableView().get_dataItems()[args.get_commandArgument()].getDataKeyValue('TTFormatos_idFormato');
            if (Idelement != 0) {
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: '{ Folio: "' + Idelement + '"}',
                    dataType: 'json',
                    url: surl,
                    success: onsuccess
                });
            }
        }

        function confirmDeleteCallBackFn(arg) {
            var id = Idelement;
            Idelement = 0;
            if (id != 0 && arg) {
                var table = $find("<%= grdRadMov.ClientID %>").get_masterTableView();
                var sdata = '{ Folio: "' + id + '" , startRowIndex:' + table.PageSize * table.CurrentPageIndex + ', maximumRows:' + table.PageSize + ', sortExpression:' + JSON.stringify(table.get_sortExpressions()) + ', filterExpression:' + JSON.stringify(table.get_filterExpressions()) + '}';
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: sdata,
                    dataType: 'json',
                    url: 'TTFormatos_lista.aspx/Delete_Row',
                    success: successCommandDelete
                });
            }
        }

        function successCommandDelete(result) {
            if (result) {
                var oresult = result.d;
                if (oresult.success) {
                    var table = $find("<%= grdRadMov.ClientID %>").get_masterTableView();
                    table.set_dataSource(oresult.data.Data);
                    table.dataBind();
                    table.set_virtualItemCount();
                }
                else {
                    radalert(oresult.errorMessage, 530, 100, 'Mensaje');
                }
            }
        }

        function successCommandPrint(result) {
            if (result) {
                var oresult = result.d;
                if (oresult.success) {
                    var wind = radopen(oresult.data, "RadWindow1");
                    wind.SetSize(850, 530)
                    wind.Center();
                }
                else {
                    radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                }
            }
        }
        
        function successCommandRedirect(result) {
            if (result) {
                var oresult = result.d;
                if (oresult.success) {
                    window.location =oresult.data;
                }
                else {
                    radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                }
            }
        }
                function btn_nuevoClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + '}',
                dataType: 'json',
                url: 'TTFormatos_lista.aspx/New',
                success: successCommandRedirect
            });
        }
        function btn_todosClick() {
            var table = $find('<%=grdRadMov.ClientID%>').get_masterTableView();
            table.get_filterExpressions().clear();
            var columns = $(table.get_columns());
            for (i = 0; i < columns.length; i++) {
                columns[i].set_filterFunction("");
            }
            var filters = table.get_tableFilterRow().children;
            for (i = 0; i < filters.length; i++) {
                $(filters[i].firstChild).val("");
            }
            var sdata = '{ startRowIndex:' + table.PageSize * table.CurrentPageIndex + ', maximumRows:' + table.PageSize + ', sortExpression:' + JSON.stringify(table.get_sortExpressions()) + ', filterExpression: {"_array":[]}}';
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: sdata,
                dataType: 'json',
                url: 'TTFormatos_lista.aspx/GetAllDataAndCount',
                success: successCommandClear
            });
        }

        function successCommandClear(result) {
            if (result) {
                var oresult = result.d;
                var table = $find("<%= grdRadMov.ClientID %>").get_masterTableView();
                table.set_dataSource(oresult.Data);
                table.dataBind();
                table.set_virtualItemCount(oresult.Count);
            }
        }

        function btn_buscarClick() {
            document.getElementById("<%=cmdSearch.ClientID%>").click();
        }
        function btn_exportarClick() {
            document.getElementById("<%=cmdExport.ClientID%>").click();
        }
        function btn_imprimirClick() {
            var columns = $($find('<%=grdRadMov.ClientID%>').get_masterTableView().get_columns());
            arreglo = new Array();
            var position =0; 
            for (i = 0; i < columns.length; i++) {
                if(columns[i]._data.DataField)
                {
                    arreglo[position] = columns[i]._data.DataField;
                    position++;
                }
            }

            var sdata = '{ Columns:' + JSON.stringify(arreglo) + '}';
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: sdata,
                dataType: 'json',
                url: 'TTFormatos_lista.aspx/PrintAll',
                success: successCommandPrint
            });
        }
      
        function btn_configurarClick() {
            document.getElementById("<%=cmdConfiguration.ClientID%>").click();
        }
</script>
          <div id="horizontal_menu_div">
            <div id="btn_nuevo" onclick="btn_nuevoClick();" runat="server">
                <p class="btns">
                    <asp:Label ID="lblNuevo" runat="server" Text="Nuevo"></asp:Label>
                </p>
            </div>
            
            <div id="btn_divider_1">
            </div>
            
           <div id="btn_todos" onclick="btn_todosClick();" runat="server">
                <p class="btns">
                    <asp:Label ID="lblTodos" runat="server" Text="Nuevo"></asp:Label>
                </p>
            </div>

           <div id="btn_divider_2">
            </div>
            
   <%--        <div id="btn_buscar" onclick="btn_buscarClick();" runat="server">
                <p class="btns">
                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
                </p>
            </div>--%>
            
           <div id="btn_divider_3">
            </div>
            
           <div id="btn_exportar" onclick="btn_exportarClick();" runat="server">
                <p class="btns">
                    <asp:Label ID="lblExportar" runat="server" Text="Exportar"></asp:Label>
                </p>
            </div>
            
           <div id="btn_divider_4">
            </div>
            
           <div id="btn_imprimir" onclick="btn_imprimirClick();" runat="server">
                <p class="btns">
                    <asp:Label ID="lblImprimir" runat="server" Text="Imprimir"></asp:Label>
                </p>
            </div>
             
            <div id="btn_divider_5">
            </div>
            
            

            <div id="btn_divider_6">
            </div>
            <div id="btn_divider_7">
            </div>
          </div>
    
    <asp:ImageButton ID="cmdSelection" runat="server" Width="0" Height="0"  style="visibility:hidden;" __designer:wfdid="w11"
        ImageUrl="~/App_Themes/SpanishLanguage/Seleccionar.gif"></asp:ImageButton>&nbsp;
    <asp:ImageButton id="cmdSearch" runat="server" style="visibility:hidden;" __designer:wfdid="w3" ImageUrl="~/App_Themes/SpanishLanguage/BUSCAR.gif" OnClick="cmdSearch_Click"></asp:ImageButton>&nbsp; 
    <asp:ImageButton ID="cmdExport" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w5" ImageUrl="~/App_Themes/SpanishLanguage/EXPORTAR.gif"
        OnClick="cmdExport_Click"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdViews" runat="server" style="visibility:hidden;" Width="0" Height="0" __designer:wfdid="w7" ImageUrl="~/App_Themes/SpanishLanguage/Vistas.gif">
    </asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdConfiguration" runat="server" style="visibility:hidden;" Width="0" Height="0"  __designer:wfdid="w8" ImageUrl="~/App_Themes/SpanishLanguage/CONFIGURAR.gif"
        OnClick="cmdConfiguration_Click"></asp:ImageButton>&nbsp;
    <asp:ImageButton ID="cmdHelp" runat="server" style="visibility:hidden;" Width="0" Height="0"  __designer:wfdid="w10" ImageUrl="~/App_Themes/SpanishLanguage/AYUDA.gif">
    </asp:ImageButton>&nbsp;
</asp:Content>








