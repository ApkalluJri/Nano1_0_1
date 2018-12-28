<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TTReportDefaultMenu.aspx.cs" Inherits="FormsSystem_TTReportDefaultMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="TTControlReportBasic.ascx" TagName="TTControlReportBasic" TagPrefix="TTCRB" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    <script src="../JSScripts/jquery-1.4.2.js" type="text/javascript"></script>

    <link href="../App_Themes/ReportMain.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/config_list_horizontal_default.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/layout_catalog.css" rel="stylesheet" type="text/css" />
<meta http-equiv="X-UA-Compatible" content="IE=8"> 
<script src="../JSScripts/jquery-1.4.2.js" type="text/javascript"></script>
<script type="text/javascript">

       function pageLoad() {
       }
        function radalert(r,t,y,u) {
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

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../JSScripts/jquery-1.4.2.js" />
            <asp:ScriptReference Path="../JSScripts/jquery.corner.js" />
            <asp:ScriptReference Path="../JSScripts/WebKit.js" />
            <asp:ScriptReference Path="../JSScripts/Funciones.js" />
        </Scripts>
    </asp:ScriptManager>
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
    </div>
    </form>
</body>
</html>








