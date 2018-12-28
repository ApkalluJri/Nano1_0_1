using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections.Generic;
namespace FormsSystem
{
public partial class _Default : TTBasePage.TTBasePage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Login.aspx"); 
        Session["carga"] = "";

        LoadSecurityPage();
        //--------------------------------------------
        this.Title = MyTraductor.getMessage(52, this.Title);
    }
    [WebMethod]
    public static List<ReportResponse> GetReportesInicio()
    {
        string qry = "select idReporte from TTReportes_por_Grupo_de_Usuario where Inicio = 1 and idUsuario = " + HttpContext.Current.Session["globalTipoUsuario"];
        DataSet Reportes = Funcion.RegresaDataSet(qry);

        var rpt = new List<ReportResponse>();

        foreach (DataRow row in Reportes.Tables[0].Rows)
        {
            rpt.Add(new ReportResponse { IdReporte = int.Parse(row[0].ToString()) });
        }
        return rpt;
    }
}
}








