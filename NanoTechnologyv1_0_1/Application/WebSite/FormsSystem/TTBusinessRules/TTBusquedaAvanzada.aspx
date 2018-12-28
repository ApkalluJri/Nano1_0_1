<%@ Page Language="C#" MasterPageFile="~/MasterTitulo.master" AutoEventWireup="true" Inherits="FormsSystem.TTBusinessRules.FormsSystem_TTBusquedaAvanzada" Title="Untitled Page" CodeFile="TTBusquedaAvanzada.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
function processText(control,tipo,dtid,tabla,campo,renglon)
{
    var sWhere="";
    var sDesde="";
    var sHasta="";
    var sValor="";
    var tipotexto="";
    var cant =0;  
  
    if (tipo=="1") //Numerico
    {
        TBox = document.getElementById("ctl00_MainContent_CampoValorDesde_" + dtid);
        sDesde = TBox.value;

        TBox = document.getElementById("ctl00_MainContent_CampoValorHasta_" + dtid);
        sHasta = TBox.value;
        
        sWhere = " AND (" + tabla + "_" + campo + " >= " + sDesde + " AND " + tabla + "_" + campo + " <= " + sHasta + ")"
        if (sDesde=="" || sHasta=="")
        {
            sWhere="";
        }
    }
    if (tipo=="2") //Texto
    {
        
        TBox = document.getElementById("ctl00_MainContent_CampoValor_" + dtid);
        sValor = TBox.value;
        
        TBox = document.getElementById("ctl00_MainContent_Opciones_" + dtid);
        tipotexto = TBox.selectedIndex;
        if (tipotexto=="0") //Que empieze
        {
            sWhere = " AND (" + tabla + "_" + campo + " like '" + sValor + "%')";
        }
        if (tipotexto=="1") //Que contenga
        {
            sWhere = " AND (" + tabla + "_" + campo + " like '%" + sValor + "%')";
        }
        if (tipotexto=="2") //Que termine
        {
            sWhere = " AND (" + tabla + "_" + campo + " like '%" + sValor + "')";
        }
        if (tipotexto=="3") //Palabra exacta
        {
            sWhere = " AND (" + tabla + "_" + campo + " = '" + sValor + "')";
        }
        if (sValor=="")
        {
            sWhere="";
        }
    }
    if (tipo=="3") //Dependiente
    {
        TBox = document.getElementById("ctl00_MainContent_" + control);
        
        cant = TBox.length ;  
        for ( i=0; i<cant ; i++){  
            if (TBox.options[i].selected == true ) {  
                sWhere = sWhere + " OR " + tabla + "_" + campo + " = " + TBox.options[i].value;
            }  
        } 
    }
    if (tipo=="4") //Fechas
    {
        TBox = document.getElementById("ctl00_MainContent_CampoValorDesde_" + dtid);
        sDesde = TBox.value;

        TBox = document.getElementById("ctl00_MainContent_CampoValorHasta_" + dtid);
        sHasta = TBox.value;
        
        sWhere = " AND (" + tabla + "_" + campo + " >= '" + sDesde + "' AND " + tabla + "_" + campo + " <= '" + sHasta + "')";
        
        if (sDesde=="" || sHasta==""){
            sWhere="";
        }
        
    }
    callserver(sWhere+"¬"+dtid+"¬"+renglon+"¬"+tipo);
    
}

function ReceiveServerData(arg, context)
{
    if(arg != null);
    {
        var arr = arg.split('¬');
        var Tbox = document.getElementById(arr[0]);
        if(Tbox != null)
            Tbox.value = arr[1];
    }
}
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:Panel id="Panel1" runat="server" Width="100%">
            </asp:Panel> <CENTER><asp:ImageButton id="cmdSearch2" runat="server" __designer:dtid="4503616807239712" ImageUrl="~/App_Themes/SpanishLanguage/BUSCAR.gif" __designer:wfdid="w12" OnClick="cmdBuscar_Click1"></asp:ImageButton> <asp:ImageButton id="ImageButton1" onclick="cmdCerrar_Click" runat="server" __designer:dtid="4503616807239712" ImageUrl="~/App_Themes/SpanishLanguage/b_cancelar.gif" __designer:wfdid="w13"></asp:ImageButton> <asp:Button id="cmdBuscar" onclick="cmdBuscar_Click1" runat="server" Text="Buscar" Visible="False"></asp:Button>&nbsp; <asp:Button id="cmdCerrar" onclick="cmdCerrar_Click" runat="server" Text="Cerrar" Visible="False"></asp:Button></CENTER>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>









