<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edicion_Formatos.aspx.cs" Inherits="WebForms.Edicion_Formatos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:Transparent;overflow: auto;" >
<head runat="server">
    <title></title>
    <script src="../JSScripts/Funciones.js" type="text/javascript"></script>
    <link href="../App_Themes/layout_master_page_rad.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Regresar() {
            setTimeout(function() {
                var wn = GetRadWindow();
                wn.setUrl("Impresion_Formatos.aspx?idProceso=" + document.getElementById("hfIdProceso").value + "&IDM=" + document.getElementById("hfIDM").value);
                wn.set_height(530);
                wn.center();
            }, 0);
        }
    </script>
</head>
<body style="background-color:Transparent;overflow: auto;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scpm2" runat="server"></asp:ScriptManager>
    <div>
        <asp:HiddenField ID="hfID" runat="server" />
        <asp:HiddenField ID="hfIdProceso" runat="server" />
        <asp:HiddenField ID="hfIDM" runat="server" />
        <table>
            <tr>
                <td colspan="2">
                    Cabecero
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:radeditor skinid="BasicSetOfTools" height="250" id="txtCabecero" runat="server"
                        CssClass="Reditor">
                                    <Tools>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FindAndReplace" />
                                            <telerik:EditorTool Name="SelectAll" />
                                            <telerik:EditorTool Name="Cut" />
                                            <telerik:EditorTool Name="Copy" />
                                            <telerik:EditorTool Name="Paste" />
                                            <telerik:EditorTool Name="PasteFromWord" />
                                            <telerik:EditorTool Name="PastePlainText" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Undo" />
                                            <telerik:EditorTool Name="Redo" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="ForeColor" />
                                            <telerik:EditorTool Name="BackColor" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertSymbol" />
                                            <telerik:EditorTool Name="InsertTable" />
                                            <telerik:EditorTool Name="ImageManager" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FontName" />
                                            <telerik:EditorTool Name="RealFontSize" />
                                            <telerik:EditorTool Name="Bold" />
                                            <telerik:EditorTool Name="Italic" />
                                            <telerik:EditorTool Name="Underline" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="JustifyLeft" />
                                            <telerik:EditorTool Name="JustifyCenter" />
                                            <telerik:EditorTool Name="JustifyRight" />
                                            <telerik:EditorTool Name="JustifyFull" />
                                            <telerik:EditorTool Name="JustifyNone" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Indent" />
                                            <telerik:EditorTool Name="Outdent" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertOrderedList" />
                                            <telerik:EditorTool Name="InsertUnorderedList" />
                                        </telerik:EditorToolGroup>
                                    </Tools>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:radeditor>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Contenido
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:radeditor skinid="BasicSetOfTools" height="600" id="txtFormato" runat="server"
                        CssClass="Reditor">
                                    <Tools>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FindAndReplace" />
                                            <telerik:EditorTool Name="SelectAll" />
                                            <telerik:EditorTool Name="Cut" />
                                            <telerik:EditorTool Name="Copy" />
                                            <telerik:EditorTool Name="Paste" />
                                            <telerik:EditorTool Name="PasteFromWord" />
                                            <telerik:EditorTool Name="PastePlainText" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Undo" />
                                            <telerik:EditorTool Name="Redo" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="ForeColor" />
                                            <telerik:EditorTool Name="BackColor" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertSymbol" />
                                            <telerik:EditorTool Name="InsertTable" />
                                            <telerik:EditorTool Name="ImageManager" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FontName" />
                                            <telerik:EditorTool Name="RealFontSize" />
                                            <telerik:EditorTool Name="Bold" />
                                            <telerik:EditorTool Name="Italic" />
                                            <telerik:EditorTool Name="Underline" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="JustifyLeft" />
                                            <telerik:EditorTool Name="JustifyCenter" />
                                            <telerik:EditorTool Name="JustifyRight" />
                                            <telerik:EditorTool Name="JustifyFull" />
                                            <telerik:EditorTool Name="JustifyNone" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Indent" />
                                            <telerik:EditorTool Name="Outdent" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertOrderedList" />
                                            <telerik:EditorTool Name="InsertUnorderedList" />
                                        </telerik:EditorToolGroup>
                                    </Tools>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:radeditor>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Pie de pagina
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:radeditor height="250" id="txtPie" runat="server" cssclass="Reditor">
                                    <Tools>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FindAndReplace" />
                                            <telerik:EditorTool Name="SelectAll" />
                                            <telerik:EditorTool Name="Cut" />
                                            <telerik:EditorTool Name="Copy" />
                                            <telerik:EditorTool Name="Paste" />
                                            <telerik:EditorTool Name="PasteFromWord" />
                                            <telerik:EditorTool Name="PastePlainText" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Undo" />
                                            <telerik:EditorTool Name="Redo" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="ForeColor" />
                                            <telerik:EditorTool Name="BackColor" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertSymbol" />
                                            <telerik:EditorTool Name="InsertTable" />
                                            <telerik:EditorTool Name="ImageManager" />
                                        </telerik:EditorToolGroup>
                                        <telerik:EditorToolGroup Tag="">
                                            <telerik:EditorTool Name="FontName" />
                                            <telerik:EditorTool Name="RealFontSize" />
                                            <telerik:EditorTool Name="Bold" />
                                            <telerik:EditorTool Name="Italic" />
                                            <telerik:EditorTool Name="Underline" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="JustifyLeft" />
                                            <telerik:EditorTool Name="JustifyCenter" />
                                            <telerik:EditorTool Name="JustifyRight" />
                                            <telerik:EditorTool Name="JustifyFull" />
                                            <telerik:EditorTool Name="JustifyNone" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="Indent" />
                                            <telerik:EditorTool Name="Outdent" />
                                            <telerik:EditorSeparator />
                                            <telerik:EditorTool Name="InsertOrderedList" />
                                            <telerik:EditorTool Name="InsertUnorderedList" />
                                        </telerik:EditorToolGroup>
                                    </Tools>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:radeditor>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="upBotonesd" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="botones" OnClientClick="Regresar();" />
                            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="botones" OnClick="btnPDF_Click" />                            
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar en campo" CssClass="botones"
                                OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botones" OnClientClick="CloseWindow();" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnPDF" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>               
            </tr>
        </table>
    </div>
    </form>
</body>
</html>








