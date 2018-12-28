<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../WebForms/DefaultMasterCatalogos.master" Inherits="FormsSystem_TTReportMenu" CodeFile="TTReportMenu.aspx.cs" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="TTControlReportBasic.ascx" TagName="TTControlReportBasic" TagPrefix="TTCRB" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
   
   <script type="text/javascript">

       function pageLoad() {
       }

       function adjustDivs() {
           var df = document.getElementById('<%=UpdateProgress1.ClientID %>');
           df.style.position = 'absolute';
           df.style.left = (document.documentElement.scrollLeft + 45) + '%';
           df.style.top = (document.documentElement.scrollTop + 300) + 'px';
       }

       window.onload = adjustDivs;
       window.onresize = adjustDivs;
       window.onscroll = adjustDivs;
   
    </script>
       
    <asp:UpdatePanel ID="updatePanelMenu" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <TTCRB:TTControlReportBasic id="ttControlReportB" runat="server" Visible="false"></TTCRB:TTControlReportBasic>                        
                    </td>
                </tr>            
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="../Images/TelerikLoading.gif" />
        </ProgressTemplate>
     </asp:UpdateProgress>
</asp:Content>







