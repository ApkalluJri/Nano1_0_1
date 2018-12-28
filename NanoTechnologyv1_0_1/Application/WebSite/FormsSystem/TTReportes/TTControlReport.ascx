<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TTControlReports" CodeFile="TTControlReport.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=3.1.9.807, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<table id="tblContainer" runat="server" visible="false" style="height: 100%; width: 100%">
    <tr>
        <td>
            <div id="divTituloReporte" runat="server" class="divTitulo">
                <b>
                    <asp:Label ID="lblReportName" runat="server" Text="Label"></asp:Label></b>
                <br />
            </div>
            <telerik:RadGrid ID="radGridReport" runat="server" GridLines="None" Width="100%"
                Style="overflow: auto" AllowPaging="True" AllowCustomPaging="true" PageSize="15"
                OnItemCommand="radGridReport_ItemCommand" OnPageSizeChanged="radGridReport_PageSizeChanged"
                OnPageIndexChanged="radGridReport_PageIndexChanged">
                <MasterTableView TableLayout="Fixed" />
                <ClientSettings>
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
    <tr>
        <td>
            <div id="chartContainer" runat="server">
                <telerik:RadChart ID="trchReport" runat="server" Height="580px" Width="960px" Skin="LightGreen"
                    AutoTextWrap="true" IntelligentLabelsEnabled="true">
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
    
</table>
<table runat="server" id="tblButtons" style="width: 100%; height: 1%" border="2">
    <tr visible="false">
        <td visible="false">
            <asp:Button ID="btnSuscribirme" runat="server" Text="Suscribirme" />
            <asp:Button ID="btnPublicar" runat="server" Text="Publicar" />
            <asp:Button ID="btnExport" runat="server" Text="Exportar" />
            <asp:Button ID="btnFilters" runat="server" Text="Filtros" Visible="False" />
            <asp:Button ID="btnPopUp" runat="server" Text="[+]" OnClick="btnPopUp_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtQuery" runat="server" Height="100px" ReadOnly="True" TextMode="MultiLine"
                Width="100%"></asp:TextBox>
        </td>
    </tr>    
</table>








