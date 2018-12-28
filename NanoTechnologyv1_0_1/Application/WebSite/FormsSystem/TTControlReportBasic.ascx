<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FormsSystem_TTControlReportBasic" CodeFile="TTControlReportBasic.ascx.cs" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=3.1.9.807, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>

<script type='text/javascript'>
    function OnClientClose(oWnd, args) {
        if (oWnd.ID = "windowPrint") {
            var button = $get('<%=btnRefresh.ClientID%>');
            button.click();
        }
        else {
            oWnd.Close();
        }
    }

    function adjustGrid() {
        var grid = $find("<%= radGridReport.ClientID %>");
        if (grid) {
            grid.repaint();
        }
    }

    function OpenDetailsWindow(idProcess, repIndex, idProcessParent) {
        //var oWnd = radopen("TTSearchAdvanced.aspx?ProcessId=" + idProcess + "&idReport=" + '<%=idReport%>' + "&IsModoConsulta=false&IsDetail=true&IsQuestionable=false&repIndex=" + repIndex + "&ParentProcessId="+idProcessParent, idProcess);
        var oWnd = radopen("TTSearch.aspx?ProcessId=" + idProcess + "&idReport=" + '<%=idReport%>' + "&IsModoConsulta=false&IsDetail=true&IsQuestionable=false&repIndex=" + repIndex + "&ParentProcessId=" + idProcessParent, idProcess);
        oWnd.setSize(650, 450);
        oWnd.center();
    }

    function UpdateFromWindow(isDetail, idWindow) {
        if (isDetail) {
            var oWnd = $find(idWindow);
            oWnd.close();
        }
        else
            $get("<%= btnRefresh.ClientID %>").click();
    }

    function btn_btnFiltersClick() {
        document.getElementById("<%=btnFilters.ClientID%>").click();
    }
    function btn_btnImprimirClick() {
        document.getElementById("<%=btnImprimir.ClientID%>").click();
    }
    function btn_btnRefreshClick() {
        document.getElementById("<%=btnRefresh.ClientID%>").click();
    }
    function btn_btnExportClick() {
        document.getElementById("<%=btnExport.ClientID%>").click();
    }
                 		        
</script>

<div id="divTest">
</div>
<telerik:RadTabStrip ID="radTabStrip" runat="server" OnTabClick="radTabStrip_TabClick"
    SelectedIndex="0" MultiPageID="radMultiPage" BorderStyle="None" CausesValidation="False"
    CssClass="pageStrip">
    <Tabs>
        <telerik:RadTab Text="Vista Previa" Selected="True">
        </telerik:RadTab>
        <telerik:RadTab Text="Impresión">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage ID="radMultiPage" runat="server" SelectedIndex="0" CssClass="pageView">
    <telerik:RadPageView ID="radPageVistaPrevia" runat="server">
        <table id="tblContainer" runat="server" visible="false" style="height: 100%; width: 100%">
            <tr>
                <td>
                    <div id="divTituloReporte" runat="server" class="divTitulo">
                        <br />
                        <b>
                            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></b>
                        <br />
                        <br />
                    </div>
                    <telerik:RadGrid ID="radGridReport" runat="server" GridLines="None" AllowPaging="True"
                        AllowCustomPaging="true" PageSize="15" OnItemCommand="radGridReport_ItemCommand"
                        OnPageSizeChanged="radGridReport_PageSizeChanged" OnPageIndexChanged="radGridReport_PageIndexChanged">
					
                        <MasterTableView TableLayout="Fixed" ShowFooter="True" />


                    </telerik:RadGrid>
                    <asp:HiddenField ID="hfContador" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="chartContainer" runat="server">
                        <telerik:RadChart ID="trchReport" runat="server" Height="580px" Width="960px" AutoTextWrap="True" Skin="Vista"
                            IntelligentLabelsEnabled="True">
                        </telerik:RadChart>
                        <telerik:RadToolTipManager ID="rttmReport" runat="server" Animation="Slide" Position="TopCenter"
                            ToolTipZoneID="trchReport" AutoTooltipify="true">
                        </telerik:RadToolTipManager>
                    </div>
                </td>
                <td>
                    <div id="chartOptionsPlaceholder" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Apariencia:" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="SkinList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SkinList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblChartOrientation" runat="server" Text="Orientación:" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList AutoPostBack="true" ID="OrientationList" runat="server" OnSelectedIndexChanged="OrientationList_SelectedIndexChanged">
                                        <asp:ListItem Text="Horizontal" Value="Horizontal" />
                                        <asp:ListItem Text="Vertical" Value="Vertical" Selected="True" />
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblChartType" runat="server" Text="Tipo de Gráfica:" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" ID="SubtypeDropdown" runat="server" OnSelectedIndexChanged="SubtypeDropdown_SelectedIndexChanged">
                                        <asp:ListItem Text="Area" Value="Area" />
                                        <asp:ListItem Text="Bar" Value="Bar" Selected="True" />
                                        <asp:ListItem Text="Bubble" Value="Bubble" />
                                        <asp:ListItem Text="Line" Value="Line" />
                                        <asp:ListItem Text="Pie" Value="Pie" />
                                        <asp:ListItem Text="Point" Value="Point" />
                                        <asp:ListItem Text="Spline" Value="Spline" />
                                        <asp:ListItem Text="SplineArea" Value="SplineArea" />
                                        <asp:ListItem Text="StackedArea" Value="StackedArea" />
                                        <asp:ListItem Text="StackedArea100" Value="StackedArea100" />
                                        <asp:ListItem Text="Stacked Bar" Value="StackedBar" />
                                        <asp:ListItem Text="Stacked Bar 100" Value="StackedBar100" />
                                        <asp:ListItem Text="StackedLine" Value="StackedLine" />
                                        <asp:ListItem Text="StackedSpline" Value="StackedSpline" />
                                        <asp:ListItem Text="StackedSplineArea" Value="StackedSplineArea" />
                                        <asp:ListItem Text="StackedSplineArea100" Value="StackedSplineArea100" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
        <!-- Controles Para Filtros, Impresión y Refresh -->
        <div id="horizontal_menu_div">
            <div id="btn_filtros_report" runat="server" onclick="btn_btnFiltersClick();">
                <p class="btns">
                    Filtros</p>
            </div>
            <div id="btn_divider_1">
            </div>
            <div id="btn_imprimir_report" onclick="btn_btnImprimirClick();">
                <p class="btns">
                    Imprimir</p>
            </div>
            <div id="btn_divider_2">
            </div>
            <div id="btn_actualizar_report" onclick="btn_btnRefreshClick();">
                <p class="btns">
                    Actualizar</p>
            </div>
            <div id="btn_divider_3">
            </div>
            <div id="btn_exportar_report" onclick="btn_btnExportClick();">
                <p class="btns">
                    Exportar</p>
            </div>
            <div id="btn_divider_4">
            </div>
            <div runat="server" id="divExport">
                <asp:ImageButton ID="btnExport" runat="server" ImageUrl="../Images/EXPORTAR.gif"
                    OnClick="btnExport_Click" Style="visibility: hidden;" />
                <telerik:RadComboBox ID="ddlFileFormat" runat="server" HighlightTemplatedItems="true"
                    AutoPostBack="false" visible="false">
                    <Items>
                        <telerik:RadComboBoxItem Text="Excel 2003" Value="xls" Selected="true" />
                        <telerik:RadComboBoxItem Text="Excel 2007" Value="xlsx" />
                        <telerik:RadComboBoxItem Text="CSV" Value="csv" />
                        <telerik:RadComboBoxItem Text="Flat XML" Value="sxml" />
                        <telerik:RadComboBoxItem Text="HTML" Value="html" />
                        <telerik:RadComboBoxItem Text="XML" Value="xml" />
                        <telerik:RadComboBoxItem Text="PDF" Value="pdf" />
                    </Items>
                </telerik:RadComboBox>
                <asp:HyperLink ID="hplnkExportedFile" runat="server"></asp:HyperLink>
            </div>
        </div>
        <asp:Button ID="btnFilters" runat="server" OnClick="btnFilters_Click" Text="Filtros"
            Style="visibility: hidden;" />
        <asp:Button ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir"
            Style="visibility: hidden;" />
        <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh"
            Style="visibility: hidden;" />
    </telerik:RadPageView>
    <telerik:RadPageView ID="radPageImpresion" runat="server">
                <telerik:ReportViewer ID="trvwReport" runat="server" Style="width:100%; height:95%;" >
        </telerik:ReportViewer>
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
    ReloadOnShow="true" runat="server">
    <Windows>
        <telerik:RadWindow ID="windowPrint" runat="server" Title="Filtros" Width="650" Height="450"
            Behaviors="Default" VisibleOnPageLoad="false" OnClientClose="OnClientClose" Modal="true">
        </telerik:RadWindow>
        <telerik:RadWindow ID="windowSubProcess" runat="server" Title="Detalles" Width="650"
            Height="450" Behaviors="Default" VisibleOnPageLoad="false" NavigateUrl="TTSearchAdvanced.aspx"
            Modal="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>








