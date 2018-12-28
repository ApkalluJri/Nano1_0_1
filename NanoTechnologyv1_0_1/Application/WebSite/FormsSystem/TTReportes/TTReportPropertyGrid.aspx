<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="FormsSystem_TTReportes_TTReportPropertyGrid" CodeFile="TTReportPropertyGrid.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function updateFromOpener() {            
            var openW = window.parent;
            if (openW != null) {
                window.parent.UpdateFromPropertyWin();
            }            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanelProperties" runat="server">
            <ContentTemplate>--%>
                <asp:GridView ID="grdProperties" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    Font-Names="Arial" Font-Size="XX-Small" ForeColor="#333333" GridLines="None"
                    Width="100%" OnRowDataBound="grdProperties_RowDataBound">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Propiedad">
                            <EditItemTemplate>
                                <asp:Label ID="lblNombreEIT" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombreIT" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtValorEIT" runat="server" Text='<%# Bind("Valor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <div style="text-align: right">
                                    <asp:ImageButton ID="btnGrdPropertiesDel" runat="server" CausesValidation="false"
                                        ImageUrl="~/App_Themes/SpanishLanguage/off.gif" Style="height: 16px" OnClick="btnGrdPropertiesDel_Click" />
                                    <asp:ImageButton ID="btnGrdPropertiesSave" runat="server" CausesValidation="false"
                                        ImageUrl="~/App_Themes/SpanishLanguage/on.gif" OnClick="btnGrdPropertiesSave_Click"
                                        Style="height: 16px" /></div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtValorIT" runat="server" Text='<%# Bind("Valor") %>'></asp:TextBox>
                                <asp:DropDownList ID="ddlValorIT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlValorIT_SelectedIndexChanged">
                                </asp:DropDownList>
                                <telerik:RadNumericTextBox ID="radValorIT" runat="server" Value='<%# Eval("Valord") %>'></telerik:RadNumericTextBox>
                                <cc1:maskededitextender id="meeValorIT" runat="server" targetcontrolid="txtValorIT">
                                                            </cc1:maskededitextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo" Visible="false">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTipoEIT" runat="server" Text='<%# Bind("Tipo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTipoIT" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ArrayIndex" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblArrayIndexIT" runat="server" Text='<%# Bind("ArrayIndex") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ArrayName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblArrayNameIT" runat="server" Text='<%# Bind("ArrayName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>








