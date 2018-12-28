<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FormsSystem_MenuAdministracion" CodeFile="MenuAdministracion.ascx.cs" %>

    <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
    <div id="logo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Design/header.jpg" />
        <div id="config_icon">
        </div>
    </div>
    <div id="rad_menu" style="z-index: 80;">
        <telerik:radmenu id="RadMenu1" runat="server" style="z-index: 70;" enableautoscroll="true"  >
        </telerik:radmenu>
         <label runat="server" id="lblversion" style="bottom: 0;font-size: 11px;position: absolute; right: 30px; color:#ccc;" ></label>
            <label runat="server" id="lblcase" style="bottom: 0;font-size: 11px;position: absolute; right: 66px;color:#ccc;" ></label>
    </div>








