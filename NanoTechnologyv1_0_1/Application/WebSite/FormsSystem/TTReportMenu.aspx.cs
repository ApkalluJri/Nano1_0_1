using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FormsSystem_TTReportMenu : TTBasePage.TTBasePage
{
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTVersion.VersionData MyVersionData = new TTVersion.VersionData(TTVersion.VersionDataModules.Produccion, 1.5M);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
        LoadSecurityPage();
        if (!IsPostBack)
            DrawReport();
    }

    protected void DrawReport()
    {
        string sidReport = Request["IdReporte"].ToString();

        int idReport = MyFunctions.FormatNumberNull(sidReport) == null ? 0 : (int)MyFunctions.FormatNumberNull(sidReport);
        try
        {
            //---------------------------------------------------------------------------------------
            myUserData = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
            TTReportes.objectBussinessTTReportes objRep = new TTReportes.objectBussinessTTReportes();
            objRep.GlobalInformation = myUserData;
            objRep.GetByKey(idReport, true);
            Session["objRep"] = objRep;
            //---------------------------------------------------------------------------------------
            ttControlReportB.Visible = true;
            ttControlReportB.CallShowReport(idReport);
        }
        catch (Exception ex)
        {
            ShowAlert(ex.Message.ToString());
        }
    }
}








