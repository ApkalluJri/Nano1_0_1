<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FormsSystem_TTPageSlider" CodeFile="TTPageSlider.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<telerik:RadToolTip ID="RadToolTip1" runat="server" OffsetY="3" Position="TopCenter"
    ShowCallout="false" Height="20px" ShowEvent="fromcode" TargetControlID="RSPagination"
    HideEvent="FromCode" RelativeTo="Element" Sticky="true">
</telerik:RadToolTip>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script language="javascript" type="text/javascript">
        function OnClientValueChanging(sender, args) {
            // Show the tooltip only while the slider handle is sliding. In case the user simply clicks on the track of the slider to change the value
            // the change will be quick and the tooltip will show and hide too quickly.
            if (!isSliding) return;

            var tooltip = $find("<%= RadToolTip1.ClientID %>");

            ResetToolTipLocation(tooltip);
            var slider = $find("<%= RSPagination.ClientID %>");
            tooltip.set_text(slider.get_value());
            var txtslider = $get("<%= txtpage.ClientID %>");
            txtslider.value = slider.get_value();

        }

        var isSliding = false;
        function OnClientSlideStart(sender, args) {
            isSliding = true;

            var tooltip = $find("<%= RadToolTip1.ClientID %>");
            var slider = $find("<%= RSPagination.ClientID %>");

            tooltip.set_text(slider.get_value());
        }

        function OnClientSlideEnd(sender, args) {
            isSliding = false;

            var tooltip = $find("<%= RadToolTip1.ClientID %>");
            tooltip.hide();

            //            var slider = $find("<%= RSPagination.ClientID %>");
            //            var grid = parent.document.getElementById("<%= GrdMov.ClientID %>");
            //            
            //            grid.onload();
            ////            grid.setAttribute("PageIndex",slider.get_value())
            ////            grid.set_currentPageIndex(); 
            ////            grid.databind();
        }

        function ShowRadToolTip(tooltip, slider) {
            var activeHandle = slider.get_activeHandle();

            if (!activeHandle) return;
            tooltip.set_targetControl(activeHandle);
            ResetToolTipLocation(tooltip);
        }

        function ResetToolTipLocation(tooltip) {
            if (!tooltip.isVisible())
                tooltip.show();
            else
                tooltip.updateLocation();
        }
        function HandleValueChanged(sender, eventArgs) {
            alert($find("sliderValue"));
            $find("sliderValue").value = sender.get_value();
        }

    </script>

</telerik:RadCodeBlock>
<div id="SliderContainer" runat="server">
    <div id="slider_icon1">
        <asp:ImageButton runat="server" ID="btnRSPaginationFirst" OnClick="btnRSPaginationFirst_Click"
            ImageUrl="~/Images/firstpage.png" />
    </div>
    <div id="slider_icon2">
        <asp:ImageButton runat="server" ID="btnRSPaginationFastDecreased" OnClick="btnRSPaginationFastDecreased_Click"
            ImageUrl="~/Images/previousgroup.png" /></div>
    <div id="slider_icon3">
        <asp:ImageButton runat="server" ID="btnRSPaginationUnitDecreased" OnClick="btnRSPaginationUnitDecreased_Click"
            ImageUrl="~/Images/previouspage.png" /></div>
    <div id="slider">
        <telerik:RadSlider runat="server" AutoPostBack="true" ItemType="Tick" TrackPosition="TopLeft"
            Visible="false" ID="RSPagination" OnClientValueChange="OnClientValueChanging"
            OnValueChanged="RSPagination_OnValueChanged" OnClientSlideStart="OnClientSlideStart"
            OnClientSlideEnd="OnClientSlideEnd" ShowDecreaseHandle="false" ShowIncreaseHandle="false">
        </telerik:RadSlider>
    </div>
    <div id="slider_icon4">
        <asp:ImageButton runat="server" ID="btnRSPaginationUnitIncreased" OnClick="btnRSPaginationUnitIncreased_Click"
            ImageUrl="~/Images/nextpage.png" /></div>
    <div id="slider_icon5">
        <asp:ImageButton runat="server" ID="btnRSPaginationFastIncreased" OnClick="btnRSPaginationFastIncreased_Click"
            ImageUrl="~/Images/nextgroup.png" /></div>
    <div id="slider_icon6">
        <asp:ImageButton runat="server" ID="btnRSPaginationLast" OnClick="btnRSPaginationLast_Click"
            Visible="false" ImageUrl="~/Images/lastpage.png" /></div>
    <div id="goto_page">
        <div class="topgrid_info" id="ir_a_pagina_div">
            <asp:Label ID="lblGo" runat="server" Text="Página" Font-Size="X-Small"></asp:Label>
        </div>
        <div id="page_Textbox">
            <asp:TextBox ID="txtpage" runat="server" CausesValidation="True" Width="22px" Height="15px"
                MaxLength="9"></asp:TextBox>
        </div>
        <div class="topgrid_info" id="ir">
            <asp:LinkButton ID="LBgo" runat="server" OnClick="LBGo_Click" Font-Size="X-Small">Ir</asp:LinkButton>
        </div>
    </div>
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtpage"
        FilterType="Numbers">
    </cc1:FilteredTextBoxExtender>
</div>








