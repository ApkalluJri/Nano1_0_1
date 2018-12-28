<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogos.master"  AutoEventWireup="true" Inherits="WebForms_CambiarPassword" Title="Cambiar Contraseña" CodeFile="CambiarContrasena.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript" src="pwd_strength.js"></script>

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
            <table style="width: 477px">
                <tr>
                    <td colspan="2">
                        <strong><span style="font-size: 12pt">Teclee su Usuario y Contraseña Actual</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 167px">
                    </td>
                    <td style="width: 156px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 167px; text-align: right; height: 16px;">
                        <span style="font-size: 11pt">Usuario:</span></td>
                    <td style="width: 156px; text-align: left; height: 16px;">
                        <asp:TextBox ID="txtUsuario" runat="server" Width="139px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 167px; text-align: right; height: 29px;">
                        <span style="font-size: 11pt">Contraseña:</span></td>
                    <td style="width: 156px; text-align: left; height: 29px;">
                        <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" EnableViewState="true"></asp:TextBox>
                        <br />                        
                        
                        </td>
                </tr>
                <tr>
                    <td style="width: 167px">
                    </td>
                    <td style="width: 156px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span style="font-size: 12pt"><strong>Teclee y Confirme su nueva Contraseña</strong></span></td>
                </tr>
                <tr>
                    <td style="width: 167px; text-align: right; height: 24px;">
                        <span style="font-size: 11pt">Nueva Contraseña:</span></td>
                    <td style="width: 156px; text-align: left; height: 24px;">
                        <asp:TextBox ID="txtContrasenia1" runat="server" TextMode="Password" EnableViewState="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 167px; text-align: right; height: 20px;">
                        <span style="font-size: 11pt">Confirme su Nueva Contraseña:</span></td>
                    <td style="width: 156px; text-align: left; height: 20px;">
                        <asp:TextBox ID="txtContrasenia2" runat="server" TextMode="Password" EnableViewState="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 167px; text-align: right">
                    </td>
                    <td style="width: 156px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
    <asp:ImageButton ID="IbtnGuardar" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR.gif"
        OnClick="IbtnGuardar_Click" />
                        &nbsp;
                        <asp:ImageButton ID="IbtnCancelar" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/b_cancelar.gif"
                            OnClick="IbtnCancelar_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label id="lblError" runat="server" ForeColor="Red" Width="251px" Visible="False" EnableTheming="False" Height="15px"></asp:Label></td>
                </tr>
            </table>
            &nbsp; 
            
            <cc1:PasswordStrength 
                id="PasswordStrength1" 
                runat="server" 
                TextStrengthDescriptions="Bajo;Regular;Medio;Bueno;Excelente" 
                PrefixText="Seguridad: " 
                TargetControlID="txtContrasenia1" 
                MinimumNumericCharacters="1" 
                PreferredPasswordLength="5" 
                MinimumUpperCaseCharacters="1"                 
                MinimumLowerCaseCharacters="1">
                </cc1:PasswordStrength> 
            <cc1:PasswordStrength id="PasswordStrength2" runat="server" TextStrengthDescriptions="Bajo;Regular;Medio;Bueno;Excelente" PrefixText="Seguridad: " TargetControlID="txtContrasenia2" PreferredPasswordLength="8"></cc1:PasswordStrength> 
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>









