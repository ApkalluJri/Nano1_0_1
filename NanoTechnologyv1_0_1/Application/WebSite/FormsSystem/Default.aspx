<%@ Page Language="C#" MasterPageFile="~/WebForms/DefaultMasterCatalogos.master"   AutoEventWireup="true" Inherits="FormsSystem._Default" CodeFile="Default.aspx.cs" %>
<asp:Content ID="Content1" runat=server ContentPlaceHolderID=MainContent>
<script type="text/javascript">
    $.ajax({
        type: 'POST',
        url: 'Default.aspx/GetReportesInicio',
        contentType: 'application/json; charset=utf-8',
        data: {},
        dataType: 'json',
        success: function(data) {
            var reportes = data.d;
            var frames = "";
            $.each(reportes, function(index, reporte) {
frames += "<iFrame id='hola' src='TTReportDefaultMenu.aspx?IdReporte=" + reporte.IdReporte + "' width='100%' height='500'/>";
            });

            $("#DivFrames").html(frames);

        },
        error: function(data) {
            alert(data);
        }
    }); 
</script>
 <div id="DivFrames">
 </div>
</asp:Content>









