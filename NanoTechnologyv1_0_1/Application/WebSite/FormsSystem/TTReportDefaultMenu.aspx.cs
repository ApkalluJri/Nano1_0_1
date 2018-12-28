using System;
using TTReportes;

public partial class FormsSystem_TTReportDefaultMenu : TTBasePage.TTBasePage
{
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
        string sidReport = Request["IdReporte"];

        int idReport = MyFunctions.FormatNumberNull(sidReport) == null ? 0 : (int)MyFunctions.FormatNumberNull(sidReport);
        try
        {
            //---------------------------------------------------------------------------------------
            myUserData = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
            objectBussinessTTReportes objRep = new objectBussinessTTReportes();
            objRep.GlobalInformation = myUserData;
            objRep.GetByKey(idReport, true);
            Session["objRep"] = objRep;
            //---------------------------------------------------------------------------------------
            ttControlReportB.Visible = true;
            ttControlReportB.CallShowReport(idReport);
        }
        catch (Exception ex)
        {
            ShowAlert(ex.Message);
        }
    }
}








