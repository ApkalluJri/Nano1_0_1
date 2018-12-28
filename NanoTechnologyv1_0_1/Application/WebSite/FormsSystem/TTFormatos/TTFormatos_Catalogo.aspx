<%@ Page Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master"
    AutoEventWireup="True" CodeFile="TTFormatos_Catalogo.aspx.cs" Inherits="WebForms.TTFormatos_Catalogo"
    Theme="SpanishLanguage" Title="Catálogo de TTFormatos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/FormsSystem/TTbuttonCatalogo.ascx" TagName="TTbuttonCatalogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/FormsSystem/TTbuttonLista.ascx" TagName="TTbuttonLista" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    
    <style type="text/css">
        .style1
        {
            width: 100px;
            height: 25px;
        }
        .style2
        {
            width: 480px;
            height: 25px;
        }
        .style3
        {
            width: 1028px;
            height: 25px;
        }
        .style4
        {
            width: 100px;
            height: 196px;
        }
        .style5
        {
            height: 196px;
        }
        #divReportFields
        {
            right: 24px;
            top: 104px;
        }
        #ctl00_MainContent_RadTreeView1
        {
            top: 104px;
        }
        .Reditor
        {
            width: 95%;
        }
        .pageViewAdmin
        {
            top: 93px;
            overflow: visible;
        }
    </style>
   
    <script type="text/javascript">
        /*<![CDATA[*/

        function OnClientLoad() {
            var tree = $find("<%= RadTreeView1.ClientID %>");
            makeUnselectable(tree.get_element());
        }

        function OnClientNodeDragStart() {
            setOverlayVisible(true);
        }

        function OnClientNodeDropping(sender, args) {
            var editor = $find("<%=txtFormato.ClientID%>");
            var cabecero = $find("<%=txtCabecero.ClientID%>");
            var pie = $find("<%=txtPie.ClientID%>");

            var event = args.get_domEvent();

            document.body.style.cursor = "default";

            var result = isMouseOverEditor(editor, event);
            if (result) {
                var imageSrc = args.get_sourceNode();
                //                if (imageSrc && (imageSrc.indexOf(".gif") != -1 || imageSrc.indexOf(".jpg") != -1)) {
                //                    var imageSrc = "<img src='" + imageSrc + "'>";
                //                    editor.setFocus();
                //                    editor.pasteHtml(imageSrc);
                //                }
                //                else {
                var button = "<button v='" + imageSrc.get_value() + "' format='" + imageSrc.get_attributes().getAttribute("formato") + "' >@@" + imageSrc.get_text() + "@@</button>";
                editor.setFocus();
                editor.pasteHtml(button);
                //                }
            }
            var result = isMouseOverEditor(cabecero, event);
            if (result) {
                var imageSrc = args.get_sourceNode();
                var button = "<button v='" + imageSrc.get_value() + "' format='" + imageSrc.get_attributes().getAttribute("formato") + "' >@@" + imageSrc.get_text() + "@@</button>";
                cabecero.setFocus();
                cabecero.pasteHtml(button);
            }
            var result = isMouseOverEditor(pie, event);
            if (result) {
                var imageSrc = args.get_sourceNode();
                var button = "<button v='" + imageSrc.get_value() + "' format='" + imageSrc.get_attributes().getAttribute("formato") + "' >@@" + imageSrc.get_text() + "@@</button>";
                pie.setFocus();
                pie.pasteHtml(button);
            }
            setOverlayVisible(false);
        }


        function OnClientNodeDragging(sender, args) {
            var editor = $find("<%=txtFormato.ClientID%>");
            var cabecero = $find("<%=txtCabecero.ClientID%>");
            var pie = $find("<%=txtPie.ClientID%>");

            var event = args.get_domEvent();

            if (isMouseOverEditor(editor, event) || isMouseOverEditor(cabecero, event) || isMouseOverEditor(pie, event)) {
                document.body.style.cursor = "hand";
            }
            else {
                document.body.style.cursor = "no-drop";
            }
        }


        /* ================== Utility methods needed for the Drag/Drop ===============================*/

        //Make all treeview nodes unselectable to prevent selection in editor being lost
        function makeUnselectable(element) {
            var nodes = element.getElementsByTagName("*");
            for (var index = 0; index < nodes.length; index++) {
                var elem = nodes[index];
                elem.setAttribute("unselectable", "on");
            }
        }

        //Create and display an overlay to prevent the editor content area from capturing mouse events
        var shimId = null;
        function setOverlayVisible(toShow) {
            if (!shimId) {
                var div = document.createElement("DIV");
                document.body.appendChild(div);
                shimId = new Telerik.Web.UI.ModalExtender(div);
            }

            if (toShow) shimId.show();
            else shimId.hide();
        }


        //Check if the image is over the editor or not
        function isMouseOverEditor(editor, events) {
            var editorFrame = editor.get_contentAreaElement();
            var editorRect = $telerik.getBounds(editorFrame);

            var mouseX = events.clientX;
            var mouseY = events.clientY;

            if (mouseX < (editorRect.x + editorRect.width) &&
			    mouseX > editorRect.x &&
				mouseY < (editorRect.y + editorRect.height) &&
			    mouseY > editorRect.y) {
                return true;
            }
            return false;
        }


        /*]]>*/
    </script>

    <script type="text/javascript">
        function btn_cmdSave_Click() {
            document.getElementById("<%=cmdSave.ClientID%>").click();
        }
        function btn_cmdSaveNewClick() {
            document.getElementById("<%=cmdSaveNew.ClientID%>").click();
        }
        function btn_cmdSaveCopyClick() {
            document.getElementById("<%=cmdSaveCopy.ClientID%>").click();
        }
        function btn_cmdCloseClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + '}',
                dataType: 'json',
                url: 'TTFormatos_Catalogo.aspx/Cancel',
                success: successCommandRedirect
            });
        }
        function btn_cmdClearClick() {
            var MenuVisible = getQuerystring('MenuVisible') != "" ? "true" : "false";
            jQuery.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: '{ MenuVisible: ' + MenuVisible + '}',
                dataType: 'json',
                url: 'TTFormatos_Catalogo.aspx/Clear',
                success: successCommandRedirect
            });
        }

        function successCommandRedirect(result) {
            if (result) {
                var oresult = result.d;
                if (oresult.success) {
                    window.location = oresult.data;
                }
                else {
                    radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentProgress" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PagerPlace" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../JSScripts/jquery.jnotify.min.js" type="text/javascript"></script>
    <link type="text/css" href="../../CSS/jquery.jnotify-alt.css" rel="stylesheet" media="all" />
    <script src="../../JSScripts/ajaxupload.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(function() {
            //Function to upload file.
            new AjaxUpload('#uploadFile', {
                action: 'FileUploadHandler.upload',
                name: 'upload',
                onComplete: function(file) {
                    $('<div><img src="../../Images/delete.png" style="width:20px;height:20px" class="delete"/>' + file + '</div>').appendTo('#fileList');
                    $('#uploadStatus').html("Archivo subido.");
                    document.getElementById('uploadFile').disabled = true;
                },
                onSubmit: function(file, ext) {
                    if (!(ext && /^(png|jpg|txt|doc|docx|xls|pdf)$/i.test(ext))) {
                        alert('Formato no valido.');
                        return false;
                    }
                    $('#uploadStatus').html("Subiendo...");
                }
            });
            //Function to delete uploaded file in server.
            $('img').live("click", function() { $('#uploadStatus').html("Borrando..."); ; deleteFile($(this)); });
        });

        function deleteFile(objfile) {
            $.ajax({ url: '../../TempFiles/FileUploadHandler.upload?del=' + objfile.parent().text(), success: function() { objfile.parent().hide(); } });
            $('#uploadStatus').html("Borrado");
            document.getElementById('uploadFile').disabled = false;
        }
    </script>

    <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img style="z-index: 1;" src="../../images/indicator-big.gif" />Espere por favor
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="pageViewAdmin">
                <asp:Panel ID="Panel2" runat="server" Height="490px" ScrollBars="None">
                    <telerik:RadTreeView ID="RadTreeView1" runat="server" EnableDragAndDrop="true" OnClientNodeDragStart="OnClientNodeDragStart"
                        OnClientNodeDragging="OnClientNodeDragging" OnClientNodeDropping="OnClientNodeDropping"
                        Skin="Default" OnClientLoad="OnClientLoad">
                    </telerik:RadTreeView>
                    <%-- <asp:Literal ID="treeDNTsLiteral" runat="server" EnableViewState="False"></asp:Literal>--%>
                </asp:Panel>
                <div id="divReportFields">
                            <div id="uploadStatus" style="color: red;"></div>
                                <input type="button" id="uploadFile" value="Subir archivo" />
                            <div id="fileList"></div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblFolio" runat="server" Text="Folio"></asp:Label>
                            </td>
                            <td colspan="" rowspan="">
                                <asp:TextBox ID="txtFolio" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblModulo" runat="server" Text="Módulo"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cbIdModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbIdModulo_SelectedIndexChanged"
                                    DataTextField="TTModulo_Nombre" DataValueField="TTModulo_IdModulo" EnableViewState="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvModulo" runat="server" ErrorMessage="Seleccione el Módulo"
                                    InitialValue="" ControlToValidate="cbIdModulo">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlProceso" runat="server" EnableLoadOnDemand="True" OnItemsRequested="ddlProceso_ItemsRequested"
                                    EmptyMessage="Seleccione el proceso" HighlightTemplatedItems="true" Width="300px"
                                    ValidationGroup="MainValidation" DropDownWidth="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged">
                                    <HeaderTemplate>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width: 40px;">
                                                    Folio
                                                </td>
                                                <td style="width: 236px;">
                                                    Proceso
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width: 40px;">
                                                    <%# DataBinder.Eval(Container, "Attributes['TTProceso_IdProceso']")%>
                                                </td>
                                                <td style="width: 236px;">
                                                    <%# DataBinder.Eval(Container, "Attributes['TTProceso_Nombre']")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ErrorMessage="Seleccione el Proceso"
                                    InitialValue="" ControlToValidate="ddlProceso">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblProcesoDesc" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblColumna" runat="server" Text="Guardar formato en"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlColumna" runat="server" DataTextField="Nombre" DataValueField="DTID"
                                    EnableViewState="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre"
                                    InitialValue="" ErrorMessage="El campo Nombre es obligatorio">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Cabecero
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadEditor SkinID="BasicSetOfTools" Height="250" ID="txtCabecero" runat="server"
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
                                    <ContextMenus>
                                        <telerik:EditorContextMenu TagName="BUTTON">
                                            <telerik:EditorTool Name="Formato" Text="Formato" />
                                        </telerik:EditorContextMenu>
                                    </ContextMenus>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Contenido
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadEditor SkinID="BasicSetOfTools" Height="600" ID="txtFormato" runat="server"
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
                                    <ContextMenus>
                                        <telerik:EditorContextMenu TagName="BUTTON">
                                            <telerik:EditorTool Name="Formato" Text="Formato" />
                                        </telerik:EditorContextMenu>
                                    </ContextMenus>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Pie de pagina
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadEditor Height="250" ID="txtPie" runat="server" CssClass="Reditor">
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
                                    <ContextMenus>
                                        <telerik:EditorContextMenu TagName="BUTTON">
                                            <telerik:EditorTool Name="Formato" Text="Formato" />
                                        </telerik:EditorContextMenu>
                                    </ContextMenus>
                                    <Content></Content>
                                    <ImageManager DeletePaths="~/Tempfiles/Formatos/Imagenes" UploadPaths="~/Tempfiles/Formatos/Imagenes"
                                        ViewPaths="~/Tempfiles/Formatos/Imagenes" />
                                </telerik:RadEditor>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CompareValidator ID="CVNombre" runat="server" ControlToValidate="txtNombre"
        Display="None" ErrorMessage="El campo Nombre debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>
    <cc1:ValidatorCalloutExtender ID="VCENombre" runat="server" TargetControlID="CVNombre"
        Enabled="True">
    </cc1:ValidatorCalloutExtender>
    <asp:CompareValidator ID="CVProceso" runat="server" ControlToValidate="ddlProceso"
        Display="None" ErrorMessage="El campo Proceso debe ser de tipo Texto" Operator="DataTypeCheck"></asp:CompareValidator>&nbsp;
    <cc1:ValidatorCalloutExtender ID="VCEProceso" runat="server" TargetControlID="CVProceso"
        Enabled="True">
    </cc1:ValidatorCalloutExtender>
    <asp:CompareValidator ID="CVFolio" runat="server" ControlToValidate="TxtFolio" Display="None"
        ErrorMessage="El campo Folio secuencial debe ser de tipo Numerico" Operator="DataTypeCheck"
        Type="Integer" ValidationGroup="none"></asp:CompareValidator>
    <cc1:ValidatorCalloutExtender ID="VCEFolio" runat="server" TargetControlID="CVFolio"
        Enabled="True">
    </cc1:ValidatorCalloutExtender>
    &nbsp;&nbsp;
    <asp:ValidationSummary ID="VSRequerid" runat="server" HeaderText="Se encontraron los siguientes errores:"
        Height="19px" ShowMessageBox="True" ShowSummary="False" Width="270px" />

    <script type="text/javascript">
        //<![CDATA[
        Telerik.Web.UI.Editor.CommandList["Formato"] = function(commandName, editor, args) {
            var elem = editor.getSelectedElement(); //returns the selected element.
            //            alert(elem);
            //            if (elem.tagName == "A") {
            //                editor.selectElement(elem);
            //                argument = elem;
            //            }
            //            else {
            //                var content = editor.getSelectionHtml();
            //                var link = editor.get_document().createElement("A");
            //                link.innerHTML = content;
            //                argument = link;
            //            }
            argument = elem.attributes["format"].value;
            var myCallbackFunction = function(sender, args) {
                //editor.pasteHtml(String.format("<a href={0} target='{1}' class='{2}'>{3}</a> ", args.href, args.target, args.className, args.name))
                sender.ClientParameters.attributes["format"].value = args;
            }

            editor.showExternalDialog(
            'EditorDialogs/TTFormatProperty.aspx?format=' + argument,
            elem,
            270,
            300,
            myCallbackFunction,
            null,
            'Insert Link',
            true,
            Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
            false,
            true);
        };
		
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MnuButtonsPlace" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="horizontal_menu_div_catalog">
                <div id="btn_grabar_catalog" onclick="btn_cmdSave_Click();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblGrabar" runat="server" Text="Grabar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_1_catalog">
                </div>
                <div id="btn_grabar_nuevo_catalog" onclick="btn_cmdSaveNewClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblGrabaryNuevo" runat="server" Text="Grabar y Nuevo"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_2_catalog">
                </div>
                <div id="btn_grabar_copiar_catalog" onclick="btn_cmdSaveCopyClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblGrabaryCopiar" runat="server" Text="Grabar y Copiar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_3_catalog">
                </div>
                <div id="btn_limpiar_catalog" onclick="btn_cmdClearClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblLimpiar" runat="server" Text="Limpiar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_4_catalog">
                </div>
                <div id="btn_cancelar_catalog" onclick="btn_cmdCloseClick();" runat="server">
                    <p class="btns">
                        <asp:Label ID="lblCancelar" runat="server" Text="Cancelar"></asp:Label>
                    </p>
                </div>
                <div id="btn_divider_5_catalog">
                </div>
            </div>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:ImageButton ID="cmdSave" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR.gif"
                            __designer:wfdid="w14" OnClick="cmdSave_Click" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveNew" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-NUEVO.gif"
                            __designer:wfdid="w13" OnClick="cmdSaveNew_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdSaveCopy" runat="server" ImageUrl="~/App_Themes/SpanishLanguage/GUARDAR-Y-COPIAR.gif"
                            __designer:wfdid="w12" OnClick="cmdSaveCopy_Click" Style="visibility: hidden;">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClose" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LISTA.gif"
                            __designer:wfdid="w15" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="cmdClear" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/SpanishLanguage/LIMPIAR.gif"
                            __designer:wfdid="w16" Style="visibility: hidden;"></asp:ImageButton>&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentSlider" runat="server">
</asp:Content>











