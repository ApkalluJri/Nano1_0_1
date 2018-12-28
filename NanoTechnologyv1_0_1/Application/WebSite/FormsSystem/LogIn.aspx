<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/MasterTitulo.master" Inherits="LogIn" CodeFile="LogIn.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="login_frame">
        <div class="login_tittle" id="top_redbox">
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
        </div>
        <div id="controls_box">
            <asp:Label ID="lblAtencion" CssClass="login_messages" style="color:red;font-size:11px;padding=3px;margin:2px;" runat="server"></asp:Label><br />
            <div class="login_labels" id="label_user">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
            </div>
            <div id="box_usuario">
                <asp:TextBox ID="txtUser" runat="server" Font-Size="Small" Width="117px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUser" CssClass="login_messages"
                    ErrorMessage="El nombre de usuario es requerido" ToolTip="El nombre de usuario es requerido" ForeColor="Yellow"
                    ValidationGroup="Login1">*</asp:RequiredFieldValidator>
            </div>
            <div class="login_labels" id="label_pass">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </div>
            <div id="box_password">
                <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" TextMode="Password"
                    Width="117px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" CssClass="login_messages" ForeColor="Yellow"
                    ErrorMessage="Contraseña es requerida" ToolTip="Contraseña es requerida" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
            </div>
            <div id="btn_entrar">
                <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','../Images/login/entrar2-01.png',1)"
                    onclick="LoginButton_nuevoClick();">
                    <img src="../Images/login/entrar-01.png" alt="" name="Image2" width="118" height="20"
                        border="0" id="Image2" /></a>
            </div>
            <div id="box_language">
                <asp:Label ID="lblLanguage" runat="server" Text="Lenguaje" CssClass="login_labels" ></asp:Label>    
                <telerik:RadComboBox ID="ddlLanguage" runat="server" DataSourceID="ODSLanguage" DataTextField="TTLanguage_Idioma"
                    DataValueField="TTLanguage_idLanguage" AutoPostBack="true">
                </telerik:RadComboBox>                                                
            </div>
            <asp:ObjectDataSource ID="ODSLanguage" runat="server" SelectMethod="SelAll" TypeName="TTLanguageCS.objectBussinessTTLanguage">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ConRelaciones" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Verdana"
                Style="visibility: hidden;" Font-Size="1em" OnClick="LoginButton_Click" Text="Entrar"
                ValidationGroup="Login1" BackColor="#42AEFF" />
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        function LoginButton_nuevoClick() {
            document.getElementById("<%= LoginButton.ClientID %>").click();
        }
    </script>

</asp:Content>








