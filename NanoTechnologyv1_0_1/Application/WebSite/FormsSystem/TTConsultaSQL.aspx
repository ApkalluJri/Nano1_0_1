<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TTConsultaSQL.aspx.cs" MasterPageFile="~/WebForms/DefaultMasterCatalogosRad.master"
Inherits="FormsSystem.TTConsultaSQL" 
Theme="SpanishLanguage" Title="TTConsulta SQL"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
        function adjustDivs() {
            var df = document.getElementById('<%=UpdateProgress1.ClientID %>');
            df.style.position = 'absolute';
            df.style.left = (document.documentElement.scrollLeft + 45) + '%';
            df.style.top = '50%'; //$('.ajax__tab_body')[0].offsetHeight/2 + 'px';
            df.style.zIndex = "1";
        }

        window.onload = adjustDivs;
        window.onresize = adjustDivs;
        window.onscroll = adjustDivs;
    </script>

    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img style="z-index: 1;" src="../Images/indicator-big.gif"  />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" style="height:100%">
                <tr>
                    <td class="style1" style="color: #0000FF">
                        <span class="style3">Teclee la sentencia SQL que desea ejecutar:<br />
                        </span>&nbsp;<asp:TextBox ID="txtQuery" runat="server" Height="121px" TextMode="MultiLine" 
                            Width="100%"></asp:TextBox>
                    </td>
                    <td class="style2" style="vertical-align: top" align="left">
                        <br />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnEjecutar" runat="server" onclick="btnEjecutar_Click" 
                            Text="Ejecutar" />
                    </td>
                </tr>
               </table> 
               <table width="100%" style="height:100%">
                <tr>
                    <td class="style1" colspan="2">
                        <asp:TextBox ID="txtError" runat="server" ForeColor="Red" Height="64px" 
                            Visible="False" Width="100%"></asp:TextBox>
                        <br />
                        <asp:Panel ID="pnlResultado" runat="server" Height="400px" 
                            ScrollBars="Vertical" Visible="False" Width="100%">
                            <telerik:RadGrid ID="grdResultado" Width="100%" runat="server" Visible="False">
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </asp:Panel>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MnuButtonsPlace">
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">

    <style type="text/css">
        .style1
        {
        	width:80%;
        }
        .style2
        {
            width:10%;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
    
</asp:Content>









