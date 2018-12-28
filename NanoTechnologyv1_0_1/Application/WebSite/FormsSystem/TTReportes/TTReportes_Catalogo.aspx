<%@ Page Title="Catálogo de TTReportes" Language="C#" MasterPageFile="~/FormsSystem/MasterPageAdministracion.master" 
    AutoEventWireup="true" Inherits="FormsSystem_TTReportes_TTReportes_Catalogo" CodeFile="TTReportes_Catalogo.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="TTControlReport.ascx" TagName="TTControlReport" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PagerPlace" runat="Server">
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
    </style>
  
    <link href="../../CSS/Reporteador.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JSScripts/ajaxupload.3.5.js" ></script>
    
    <telerik:RadScriptBlock runat="Server" ID="RadScriptBlock1">

        <script type="text/javascript">
            /* <![CDATA[ */
            var gridIdCenter = "<%= txtFunctions.ClientID %>";
            var gridIdColumns = "<%= txtColumns.ClientID %>";
            var gridIdRows = "<%= txtRows.ClientID %>";

            function isMouseOverGrid(target) {
                parentNode = target;
                while (parentNode != null) {
                    if (parentNode.id == gridIdCenter || parentNode.id == gridIdColumns || parentNode.id == gridIdRows) {
                        return parentNode;
                    }
                    parentNode = parentNode.parentNode;
                }

                return null;
            }

            function onNodeDragging(sender, args) {
                var target = args.get_htmlElement();

                if (!target) return;

                if (target.tagName == "INPUT") {
                    target.style.cursor = "hand";
                }

                var grid = isMouseOverGrid(target)
                if (grid) {
                    grid.style.cursor = "hand";
                }
            }

            function dropOnHtmlElement(args) {
                if (droppedOnGrid(args))
                    return;
            }

            function droppedOnGrid(args) {
                var target = args.get_htmlElement();

                while (target) {
                    if (target.id == gridIdCenter || target.id == gridIdColumns || target.id == gridIdRows) {
                        args.set_htmlElement(target);
                        return;
                    }

                    target = target.parentNode;
                }
                args.set_cancel(true);
            }

            function droppedOnInput(args) {
                var target = args.get_htmlElement();
                if (target.tagName == "INPUT") {
                    target.style.cursor = "default";
                    target.value = args.get_sourceNode().get_text();
                    args.set_cancel(true);
                    return true;
                }
            }

            function dropOnTree(args) {
                var text = "";

                if (args.get_sourceNodes().length) {
                    var i;
                    for (i = 0; i < args.get_sourceNodes().length; i++) {
                        var node = args.get_sourceNodes()[i];
                        text = text + ', ' + node.get_text();
                    }
                }
            }

            function clientSideEdit(sender, args) {
                var destinationNode = args.get_destNode();

                if (destinationNode) {
                    var firstTreeView = $find('RadTreeView1');
                    var secondTreeView = $find('RadTreeView2');

                    firstTreeView.trackChanges();
                    secondTreeView.trackChanges();
                    var sourceNodes = args.get_sourceNodes();
                    for (var i = 0; i < sourceNodes.length; i++) {
                        var sourceNode = sourceNodes[i];
                        sourceNode.get_parent().get_nodes().remove(sourceNode);

                        if (args.get_dropPosition() == "over") destinationNode.get_nodes().add(sourceNode);
                        if (args.get_dropPosition() == "above") insertBefore(destinationNode, sourceNode);
                        if (args.get_dropPosition() == "below") insertAfter(destinationNode, sourceNode);
                    }
                    destinationNode.set_expanded(true);
                    firstTreeView.commitChanges();
                    secondTreeView.commitChanges();
                }
            }

            function insertBefore(destinationNode, sourceNode) {
                var destinationParent = destinationNode.get_parent();
                var index = destinationParent.get_nodes().indexOf(destinationNode);
                destinationParent.get_nodes().insert(index, sourceNode);
            }

            function insertAfter(destinationNode, sourceNode) {
                var destinationParent = destinationNode.get_parent();
                var index = destinationParent.get_nodes().indexOf(destinationNode);
                destinationParent.get_nodes().insert(index + 1, sourceNode);
            }

            function onNodeDropping(sender, args) {
                var dest = args.get_destNode();
                if (dest) {
                    var clientSide = document.getElementById('ChbClientSide').checked;

                    if (clientSide) {
                        clientSideEdit(sender, args);
                        args.set_cancel(true);
                        return;
                    }

                    dropOnTree(args);
                }
                else {
                    dropOnHtmlElement(args);
                }
            }
            //---------------------------------------------------------------------------
            function OnClientClose(oWnd, args) {
                if (oWnd.ID = "windowPrint") {
                    var button = $get('<%=btnFilters.ClientID%>');
                    button.click();
                }
                else {
                    oWnd.Close();
                }

            }

            function adjustGrid() {
                var grid = $find("<%= RadGCenter.ClientID %>");
                if (grid) {
                    grid.repaint();
                }
            }

            function OpenPropertyWindow(itemType, itemIndex) {
                var oWnd = radopen("TTReportPropertyGrid.aspx?itemType=" + itemType + "&itemIndex=" + itemIndex, "rwProperties");
                oWnd.setSize(320, 455);
                oWnd.set_title("Propiedades");
                oWnd.center();
                oWnd.SetModal(true);
            }

            function UpdateFromPropertyWin() {
                var oWnd = $find("rwProperties");
                oWnd.close();
                $get("<%= BtnRefresh.ClientID %>").click();
            }

            function OpenDetailsWindow(idProcess, repIndex, idProcessParent) {
                var oWnd = radopen("TTSearchAdvanced.aspx?ProcessId=" + idProcess + "&idReport=" + '<%=idReport%>' + "&IsModoConsulta=false&IsDetail=true&IsQuestionable=true&repIndex=" + repIndex + "&ParentProcessId=" + idProcessParent, idProcess);
                oWnd.setSize(650, 450);
                oWnd.set_modal(true);
                oWnd.center();
            }

            function UpdateFromWindow(isDetail, idWindow) {
                var oWnd = $find(idWindow);
                oWnd.close();
            }

            function ShowFilterWindow() {
                var idReport = "<%= objRep.idReporte %>";
                var combo = document.getElementById("<% =ddlProceso.ClientID%>");
                var idProceso = combo.value;
                var isValid = Page_ClientValidate();

                if (idProceso != null && idProceso != '' && isValid) {
                    var oWnd = radopen("TTSearchAdvanced.aspx?ProcessId=" + idProceso + "&idReport=" + idReport + "&IsModoConsulta=0&IsQuestionable=true", idProceso);
                    oWnd.set_modal(true);
                    oWnd.setSize(650, 450);
                    oWnd.center();
                }
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


            function enableDockDrag(enable, dockId, textboxId) { // this script enables/disables the RadDock dragging
                var dock = $find(dockId);
                if (enable) {
                    dock._initializeDrag();
                    var textbox = $find(textboxId);
                    if (textbox) {
                        $addHandler(textbox, "mousedown", function(e) {
                            e.stopPropagation();
                        });
                    }
                }
                else dock._disposeDrag();
            }

            function mostrarTexto(sender) {
                sender.parentNode.children[0].style.cssText = "";
                sender.parentNode.children[2].style.cssText = "";
                sender.style.cssText = "visibility:hidden;"
                sender.parentNode.style.cssText = "height:80px;width:300px;overflow:auto;";
                sender.parentNode.offsetParent.style.cssText = "width:300px;";
                enableDockDrag(false, sender.parentNode.offsetParent.id, sender.parentNode.children[0].id);
            }

            function ocultarTexto(sender) {
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: '{ id: "' + sender.parentNode.offsetParent.id + '", texto : "' + sender.parentNode.children[0].value + '" }',
                    dataType: 'json',
                    url: 'TTReportes_Catalogo.aspx/guardarTexto',
                    success: successTexto
                });
            }

            function successTexto(result) {
                if (result) {
                    var oresult = result.d;
                    if (oresult.success) {
                        var control = $find(oresult.data).get_titleBar();
                        control.children[0].style.cssText = "visibility:hidden;";
                        control.children[2].style.cssText = "visibility:hidden;";
                        control.children[1].style.cssText = "";
                        $(control.children[1]).addClass("LinkTitle");
                        control.children[0].parentNode.style.cssText = "";
                        //$(oresult.data).css("width", "150px");
                        $(control.offsetParent).css("width", "150px");
                        //control.children[1].text = control.children[0].value;
                        //$(control.children[1]).val(control.children[0].value);
                        $(control).children('a').html(control.children[0].value);
                        enableDockDrag(true, oresult.data, control.children[0].id);
                        
                    }
                    else {
                        radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                    }
                }
            }

            function guardarImagen(sender, imagen) {
                
                jQuery.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: '{ id: "' + sender[0].parentNode.offsetParent.id + '", texto : "' + imagen + '" }',
                    dataType: 'json',
                    url: 'TTReportes_Catalogo.aspx/guardarTexto',
                    success: successImagen
                });
            }

            function successImagen(result) {
                if (result) {
                    var oresult = result.d;
                    if (oresult.success) {
                    }
                    else {
                        radalert(oresult.errorMessage, 300, 100, 'Mensaje');
                    }
                }
            }

           /* ]]> */
        </script>

    </telerik:RadScriptBlock>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="../../Images/TelerikLoading.gif" />
        </ProgressTemplate>
    </asp:UpdateProgress>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <%--<asp:FileUpload ID="FileUpload" runat="server" />--%>
            <telerik:RadTabStrip ID="radTabStrip" runat="server" Width="100%" SelectedIndex="0"
                MultiPageID="radMultiPage" BorderStyle="None" Skin="Outlook" CausesValidation="false">
                <Tabs>
                    <telerik:RadTab Text="Configuración">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Vista Previa">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="radMultiPage" runat="server" SelectedIndex="0" CssClass="pageViewAdmin">
                <telerik:RadPageView ID="radPageVistaPrevia" runat="server">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Panel ID="Panel2" runat="server" Height="490px" ScrollBars="None">
                            <telerik:RadTreeView ID="RadTreeView1" runat="server" EnableDragAndDrop="True" LoadingMessage="Cargando ..."
                                OnNodeDrop="RadTreeView1_HandleDrop" OnClientNodeDropping="onNodeDropping" OnClientNodeDragging="onNodeDragging"
                                MultipleSelect="True" EnableDragAndDropBetweenNodes="True" CausesValidation="False"
                                DataFieldID="au_id">
                            </telerik:RadTreeView>
                            <asp:Literal ID="treeDNTsLiteral" runat="server" EnableViewState="False"></asp:Literal>
                        </asp:Panel>
                        <div id="divReportFields">
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
                                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TxtNombre"
                                            InitialValue="" ErrorMessage="El campo Nombre es obligatorio">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LblTipoPresentacion" runat="server" Text="Tipo de Presentacion"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoPresentacion" runat="server" Width="213px" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlTipoPresentacion_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valTipoPresentacion" runat="server" ErrorMessage="El Tipo de Presentacion es Requerido"
                                            Display="Dynamic" ControlToValidate="ddlTipoPresentacion" InitialValue="">*</asp:RequiredFieldValidator>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LblSubTipoPresentacion" runat="server" Text="Subtipo de Presentacion"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSubTipoPresentacion" runat="server" AutoPostBack="True"
                                            Width="213px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valSubTipoPresentacion" runat="server" ErrorMessage="El Subtipo de Presentacion es Requerido"
                                            Display="Dynamic" ControlToValidate="ddlSubTipoPresentacion" InitialValue="">*</asp:RequiredFieldValidator>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProcedimientoAlmacenado" runat="server" Text="Procedimiento Almacenado"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProcedimientoAlmacenado" runat="server"></asp:TextBox>&nbsp;
                                        <asp:DropDownList ID="ddlStoreRelationDT" runat="server" Width="213px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGrupoReporte" runat="server" Text="Grupo de Reporte"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGrupoReporte" runat="server" Width="213px" DataSourceID="ODSGrupoReporte"
                                            OnDataBound="ddlGrupoReporte_Databound" DataTextField="Nombre" DataValueField="IdGrupoReporte">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valGrupoReporte" runat="server" ErrorMessage="El Grupo de Reporte es Requerido"
                                            Display="Dynamic" ControlToValidate="ddlGrupoReporte" InitialValue="">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:ObjectDataSource ID="ODSGrupoReporte" runat="server" SelectMethod="FillDataIdGrupoReporte"
                                            TypeName="TTReportes.objectBussinessTTReportes"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr> 
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkTotalColumna" runat="server" Text="Total por columna" />
                                        <asp:CheckBox ID="chkTotalRenglon" runat="server" Text="Total por renglon" />
                                        <asp:CheckBox ID="chkContador" runat="server" Text="Contador de registros" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    Cabecero
                                    <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" >
                                        <%-- Encabezado--%>
                                        <asp:button id="btnFila" runat="server" text="Agregar fila" onclick="btnFila_Click" />
                                        <asp:button id="btnColumna" runat="server" text="Agregar columna" onclick="btnColumna_Click" />
                                        <asp:button id="btnBorrarFila" runat="server" text="Eliminar fila" onclick="btnBorrarFila_Click" />
                                        <asp:button id="BtnBorrarColumna" runat="server" text="Eliminar columna" onclick="BtnBorrarColumna_Click" />
                                        <%--<asp:button id="btnMerge" runat="server" text="Combinar celdas" onclick="btnMerge_Click" />
                                        <asp:button id="btnCancelar" runat="server" text="Cancelar" onclick="btnCancelar_Click" />--%>
                                        <asp:HiddenField ID="hfSeleccionados" runat="server" Value="" />
                                        <br />
                                        <telerik:RadDockLayout runat="server" id="RadDockLayout1" OnSaveDockLayout="RadDockLayout1_SaveDockLayout" 
                                        OnLoadDockLayout="RadDockLayout1_LoadDockLayout" >
                                            <table id="tableDock" runat="server" class="tableDock" border="0" cellpadding="0" cellspacing="0" >
                                            
                                                <%--<tr id="R1" runat="server" >
                                                    <td id="C1" runat="server" >
                                                        <telerik:raddockzone runat="server" id="RadDockZone1"  ></telerik:raddockzone>
                                                    </td>
                                                    </tr>--%>
                                                    
                                            </table>
                                            <br />
                                            Pie de pagina
                                            <br />
                                            <%-- Footer de pagina--%>
                                            <asp:button id="btnFilaFooter" runat="server" text="Agregar fila" onclick="btnFilaFooter_Click" />
                                            <asp:button id="btnColumnaFooter" runat="server" text="Agregar columna" onclick="btnColumnaFooter_Click" />
                                            <asp:button id="btnBorrarFilaFooter" runat="server" text="Eliminar fila" onclick="btnBorrarFilaFooter_Click" />
                                            <asp:button id="BtnBorrarColumnaFooter" runat="server" text="Eliminar columna" onclick="BtnBorrarColumnaFooter_Click" />
                                            <%--<asp:button id="btnMergeFooter" runat="server" text="Combinar celdas" onclick="btnMergeFooter_Click" />
                                            <asp:button id="btnCancelar" runat="server" text="Cancelar" onclick="btnCancelarFooter_Click" />--%>
                                            <asp:HiddenField ID="hfSeleccionadosFooter" runat="server" Value="" />
                                            <br />
                                            <table id="tableDockFooter" runat="server" class="tableDock" border="0" cellpadding="0" cellspacing="0" >                                                    
                                            </table>
                                        </telerik:RadDockLayout>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" >
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="style5">
                                        &nbsp;
                                        <table runat="server" border="1" id="tblGrids" class="tblGrids" style="width:auto;" >
                                            <tr id="Tr1" runat="server">
                                                <td id="Td1" runat="server">
                                                </td>
                                                <td id="Td2" runat="server">
                                                    <asp:TextBox ID="txtColumns" runat="server" ReadOnly="True" Text="Columnas"></asp:TextBox>
                                                    <telerik:RadGrid ID="RadGColumns" runat="server" GridLines="None" Height="16px" ShowHeader="False"
                                                        Skin="Simple" Width="148%" Visible="False">
                                                        <ClientSettings>
                                                            <Selecting AllowRowSelect="True" />
                                                        </ClientSettings>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server">
                                                <td id="Td3" runat="server">
                                                    <asp:TextBox ID="txtRows" runat="server" ReadOnly="True" Text="Renglones"></asp:TextBox>
                                                    <telerik:RadGrid ID="RadGRows" runat="server" GridLines="None" Height="16px" ShowHeader="False"
                                                        Skin="Simple" Width="148%" Visible="False">
                                                        <ClientSettings>
                                                            <Selecting AllowRowSelect="True" />
                                                        </ClientSettings>
                                                    </telerik:RadGrid>
                                                </td>
                                                <td id="Td4" runat="server">
                                                    <asp:TextBox ID="txtFunctions" runat="server" ReadOnly="True" Text="Funciones"></asp:TextBox>
                                                    <telerik:RadGrid ID="RadGCenter" runat="server" GridLines="None" Height="16px" ShowHeader="False"
                                                        Skin="Simple" Width="148%" Visible="False">
                                                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                                            <Selecting AllowRowSelect="True" />
                                                            <Resizing AllowRowResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="True"
                                                                AllowColumnResize="True"></Resizing>
                                                        </ClientSettings>
                                                        <MasterTableView>
                                                            <RowIndicatorColumn Visible="True">
                                                            </RowIndicatorColumn>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table id="dgReport" runat="server" border="1" style="width:auto;">
                                            <tr>
                                                <td style="width: 100px; height: 16px;">
                                                </td>
                                                <td style="width: 100px; height: 16px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 16px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 100px; height: 16px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" colspan="2">
                                        <asp:CheckBox ID="chkDistinct" runat="server" Text="Distinct" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtTop" runat="server" Width="77px"></asp:TextBox>&nbsp;
                                        <asp:Label ID="lblTop" runat="server" Text="Top"></asp:Label>&nbsp;
                                        <cc1:NumericUpDownExtender ID="UpDwTop" runat="server" Maximum="20" Minimum="0" ServiceDownMethod=""
                                            ServiceDownPath="" ServiceUpMethod="" TargetControlID="txtTop" Width="120" Enabled="True"
                                            RefValues="" Tag="" TargetButtonDownID="" TargetButtonUpID="">
                                        </cc1:NumericUpDownExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="pnlElemento" runat="server" Height="490px" ScrollBars="None" CssClass="panelElementos">                        
                            <div class="divElemento" >
                                <table>
                                    <tr>
                                        <td>
                                            Cabecero
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Button runat="server" CssClass="button" ID="btnFecha" Text="Fecha" OnClick="btnFecha_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnHora" Text="Hora" OnClick="btnHora_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnNumero" Text="Número página" OnClick="btnNumero_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnUsuario" Text="Usario" OnClick="btnUsuario_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnTexto" Text="Texto" OnClick="btnTexto_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnImagen" Text="Imagen" OnClick="btnImagen_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Pie de pagina
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" CssClass="button" ID="btnFechaFooter" Text="Fecha" OnClick="btnFechaFooter_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnHoraFooter" Text="Hora" OnClick="btnHoraFooter_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnNumeroFooter" Text="Número página" OnClick="btnNumeroFooter_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnUsuarioFooter" Text="Usario" OnClick="btnUsuarioFooter_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnTextoFooter" Text="Texto" OnClick="btnTextoFooter_Click" />
                                            <br />
                                            <asp:Button runat="server" CssClass="button" ID="btnImagenFooter" Text="Imagen" OnClick="btnImagenFooter_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>                               
                            </div>                      
                        </asp:Panel>
                        
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="radPageImpresion" runat="server">
                    <br />
                    <uc1:TTControlReport ID="TTControlRepPreview" runat="server"></uc1:TTControlReport>
                    <br />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
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
            <div id="horizontal_menu_div_catalog">
                <asp:Button ID="btnFilters" runat="server" Height="32px" Text="Filtros" Width="100px"
                    OnClick="btnFilters_Click" OnClientClick="ShowFilterWindow();" CausesValidation="false" />
                <asp:Button ID="btnReset" runat="server" Height="32px" Text="Reset Filtro" Width="100px"
                    CausesValidation="false" OnClick="btnReset_Click" />
                <asp:Button ID="btnPreview" runat="server" Height="32px" Text="Preview" Width="100px"
                    OnClick="btnPreview_Click" />
                <asp:Button ID="BtnSaveCopy" runat="server" Height="32px" Text="Guardar y Copiar"
                    OnClick="BtnSaveCopy_Click" Width="118px" />
                <asp:Button ID="BtnSaveNew" runat="server" Height="32px" Text="Guardar y Nuevo" Width="118px"
                    OnClick="BtnSaveNew_Click" />
                <asp:Button ID="BtnSave" runat="server" Height="32px" Text="Guardar" Width="100px"
                    OnClick="BtnSave_Click" CausesValidation="true" />
                <asp:Button ID="BtnClose" runat="server" CausesValidation="False" Height="32px" Text="Cerrar"
                    Width="100px" OnClick="BtnClose_Click" />
                <asp:Button ID="BtnClean" runat="server" CausesValidation="False" Height="32px" Text="Limpiar"
                    Width="100px" OnClick="BtnClean_Click" />
                <asp:Button ID="BtnRefresh" runat="server" CausesValidation="False" Text="Refresh"
                    Style="visibility: hidden;" OnClick="BtnRefresh_Click" />
            </div>
        </ContentTemplate>
         <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFecha" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnHora" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNumero" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnUsuario" EventName="Click" />                
                <asp:AsyncPostBackTrigger ControlID="btnFechaFooter" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnHoraFooter" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNumeroFooter" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnUsuarioFooter" EventName="Click" />       
            </Triggers>
    </asp:UpdatePanel>
    
    <script type="text/javascript">
        function selectMerge(sender) {
            var hf = document.getElementById("<%=hfSeleccionados.ClientID%>");
            if (hf.value.indexOf(sender.id) != -1) {
                sender.parentNode.className = ""
                sender.className = "RadDockZone RadDockZone_Default rdVertical Celdas";
                hf.value = hf.value.replace("," + sender.id, "");
            }
            else {
                sender.parentNode.className = "CeldasSeleccionadas"
                hf.value = hf.value + "," + sender.id;
            }
        }
        </script>
</asp:Content>











