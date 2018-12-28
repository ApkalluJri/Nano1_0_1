<%@ Page Language="C#" AutoEventWireup="true" Inherits="WebForms_Relogin"
    runat="server" CodeFile="Relogin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Relogin</title>



    <link href="../App_Themes/layout.css" rel="stylesheet" type="text/css" />
</head>
<body onload="MM_preloadImages('..Images/Relogin/entrar2-01.png')">
    <script language="javascript" type="text/javascript">
        function updateFromOpener(isDetail, idProces) {
            var openW = window.parent;
            if (openW != null) {
                window.parent.Relogin(isDetail, idProces);
            }
        }

        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }
        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
            }

        function btn_LoginButtonClick() {
            document.getElementById("<%=LoginButton.ClientID%>").click();
        }
        function btn_AbandonButtonClick() {
            document.getElementById("<%=AbandonButton.ClientID%>").click();
        }
    </script>
    <form id="form1" runat="server">
    <div id="relogin_frame">
        <div class="login_tittle" id="top_redbox">
            ReLogin
        </div>
        <div id="controls_box">
            <div class="login_labels" id="label_user">
                Usuario</div>
            <div id="box_usuario">
                <asp:TextBox ID="txtUser" runat="server" Font-Size="Small" Width="117px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUser"
                    ErrorMessage="El nombre de usuario es requerido:" ToolTip="El nombre de usuario es requerido:"
                    ValidationGroup="Login1">*</asp:RequiredFieldValidator>
            </div>
            <div class="login_labels" id="label_pass">
                Password
            </div>
            <div id="box_password">
                <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" TextMode="Password"
                    Width="117px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Contraseña es requerida" ToolTip="Contraseña es requerida" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
            </div>
            
            <div id="btn_entrar_relogin" onclick="btn_LoginButtonClick();">
                <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image3','','../Images/Relogin/entrar2-01.png',1)">
                <img src="../Images/Relogin/entrar-01.png" alt="" name="Image3" width="118" height="20" border="0" id="Image3" />
                </a>
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Verdana"
                    Font-Size="1em" OnClick="LoginButton_Click" Text="Entrar" ValidationGroup="Login1" style="visibility:hidden;" />
            </div>
   
            <div id="btn_salir_relogin" onclick="btn_AbandonButtonClick();">
                <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','../Images/Relogin/btn_salir2.png',1)">
                <img src="../Images/Relogin/btn_salir.png" alt="" name="Image2" width="118" height="20" border="0" id="Image2" />
                </a>
                <asp:Button ID="AbandonButton" runat="server" CommandName="Abandon" Font-Names="Verdana"
                    Font-Size="1em" OnClick="AbandonButton_Click" Text="Cerrar" ValidationGroup="Login1"
                    CausesValidation="false" style="visibility:hidden;" />
            </div>
        </div>
    </div>
    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
    </form>
</body>
</html>








