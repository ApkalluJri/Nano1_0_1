<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FormsSystem_TTSearchControl" CodeFile="TTSearchControl.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script type='text/javascript'>
    function OnClientClose(oWnd, args) {
    }

    function OpenDetailsWindow(idProcess, repIndex, idProcessParent) {
        var openW = window.parent;
        if (openW != null) {
            window.parent.OpenDetailsWindow(idProcess, repIndex, idProcessParent);
        }
    }
</script>

<table id="tbl1" runat="server" style="font-family: Tahoma; font-size: small;">
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="lblDT" runat="server" Text="Etiqueta:" Visible="False"></asp:Label>
        </td>
        <td colspan="1" rowspan="1">
            <asp:CheckBox ID="chkQuestion" runat="server" Visible="False" />
            <asp:Label ID="lblFrom" runat="server" Text="Desde:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtFromNumeric" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="lblTo" runat="server" Text="Hasta:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtToNumeric" runat="server" Visible="False"></asp:TextBox><br />
            <asp:TextBox ID="txtFromDecimal" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtToDecimal" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtFromMoney" runat="server" Visible="False"></asp:TextBox><br />
            <asp:TextBox ID="txtToMoney" runat="server" Visible="False"></asp:TextBox><br />
            <asp:DropDownList ID="ddlText" runat="server" Visible="False">
                <asp:ListItem>Igual</asp:ListItem>
                <asp:ListItem Selected="True">Que Contenga</asp:ListItem>
                <asp:ListItem>Que empieze</asp:ListItem>
                <asp:ListItem>Que termine</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtText" runat="server" Width="340px" Visible="False"></asp:TextBox><br />
            <asp:DropDownList ID="ddlDep" runat="server" Visible="False">
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="cbLogic" runat="server" Visible="False">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtFromHour" runat="server" Visible="False"></asp:TextBox><asp:TextBox
                ID="txtToHour" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtToDate" runat="server" Visible="False"></asp:TextBox>
            <telerik:RadDatePicker ID="radFromDate" runat="server" Visible="false" Culture="Spanish (Mexico)">
                <DateInput DateFormat="yyyy/MM/dd">
                </DateInput>
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                </Calendar>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <asp:TextBox ID="txtFromDate" runat="server" Visible="False"></asp:TextBox>
            <telerik:RadDatePicker ID="radToDate" runat="server" Visible="false" Culture="Spanish (Mexico)">
                <DateInput DateFormat="yyyy/MM/dd">
                </DateInput>
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                </Calendar>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <br />
            <asp:Button ID="cmdDetails" runat="server" Text="Detalles" Visible="False" OnClientClick="OpenDetailsWindow();" />
            <asp:Button ID="cmdClearDetails" runat="server" Text="Limpiar" Visible="False" OnClick="cmdClearDetails_Click" />&nbsp;
            <asp:ListBox ID="lstDep" runat="server" Visible="False" Height="164px" SelectionMode="Multiple">
            </asp:ListBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
<%--<asp:Panel ID="Panel1" runat="server" GroupingText="Panel">    
</asp:Panel>--%>







