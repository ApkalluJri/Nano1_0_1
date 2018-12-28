using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormsSystem_TTSearch : System.Web.UI.Page
{
    private int? ProcesId;
    private int? idReport;
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private ControlsLibrary.objectBussinessTTFiltro myFilter;
    public ControlsLibrary.objectBussinessTTFiltro MyFilter
    {
        get { return myFilter; }
        set { myFilter = value; }
    }
    private bool IsQuestionable = false;
    private bool IsDetail = false;
    private bool IsModoConsulta = true;
    private int Index = 0;
    private int? ParentProcessId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["ProcessId"] != null)
            ProcesId = myFunctions.FormatNumberNull(this.Request["ProcessId"]);

        if (this.Request["IsDetail"] != null)
        {
            IsDetail = bool.TryParse(this.Request["IsDetail"], out IsDetail);
        }

        if (!IsDetail)
        {
            if (Session["Filter"] == null)
            {
                TTSearchControl1.MyFilter = new ControlsLibrary.objectBussinessTTFiltro();
                TTSearchControl1.MyFilter.GlobalInformation = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
            }
            else
                TTSearchControl1.MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];
        }
        else
        {
            ControlsLibrary.objectBussinessTTFiltro objRepDetalle, objRepParent;

            if (this.Request["ParentProcessId"] != null)
                ParentProcessId = myFunctions.FormatNumberNull(this.Request["ParentProcessId"]);

            Index = myFunctions.FormatNumberNull(this.Request["repIndex"]) == null ? 0 : (int)myFunctions.FormatNumberNull(this.Request["repIndex"]);

            if (Session["Filter" + ParentProcessId.ToString()] == null)
                objRepParent = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter"]); //.Filtro_Detalle[Index].Filtro_Detalle;
            else
                objRepParent = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ParentProcessId.ToString()]);

            if (Session["Filter" + ProcesId.ToString()] != null)
                objRepDetalle = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ProcesId.ToString()]);
            else
                objRepDetalle = objRepParent.Filtro_Detalle[Index].Filtro_Detalle;

            if (objRepDetalle != null)
                TTSearchControl1.MyFilter = objRepDetalle;
            else
                TTSearchControl1.MyFilter = new ControlsLibrary.objectBussinessTTFiltro();

            TTSearchControl1.MyFilter.GlobalInformation = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
        }

        if (this.Request["idReport"] != null)
            idReport = myFunctions.FormatNumberNull(this.Request["idReport"]);

        if (this.Request["IsQuestionable"] != null)
            IsQuestionable = bool.TryParse(this.Request["IsQuestionable"], out IsQuestionable);

        if (this.Request["IsModoConsulta"] != null)
            IsModoConsulta = bool.TryParse(this.Request["IsModoConsulta"], out IsModoConsulta);

        if (this.Request["QuickFilter"] != null)
            if (this.Request["QuickFilter"] == "1")
                TTSearchControl1.EntryType = ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter;                

        if (ProcesId.HasValue)
        {
            TTSearchControl1.IsQuestionable = IsQuestionable;
            TTSearchControl1.ModoConsulta = IsModoConsulta;
            TTSearchControl1.IsDetail = IsDetail;
            TTSearchControl1.New(ProcesId.Value);
        }
    }


    protected void btnAcept_Click(object sender, EventArgs e)
    {
        Index = myFunctions.FormatNumberNull(this.Request["repIndex"]) == null ? 0 : (int)myFunctions.FormatNumberNull(this.Request["repIndex"]);
        TTSearchControl1.SaveChanges();
        if (!IsDetail)
        {
            Session.Remove("Filter" + ProcesId.ToString());
            Session["Filter"] = TTSearchControl1.MyFilter;
        }
        else
        {
            if (this.Request["ParentProcessId"] != null)
                ParentProcessId = myFunctions.FormatNumberNull(this.Request["ParentProcessId"]);

            ControlsLibrary.objectBussinessTTFiltro objFiltroParent = Session["Filter" + ParentProcessId.ToString()] == null ?
                (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"] :
                (ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ParentProcessId.ToString()];

            if (objFiltroParent.Filtro_Detalle[Index] == null)
                objFiltroParent.Filtro_Detalle[Index] = new ControlsLibrary.objectBussinessTTFiltro_Detalle();
            objFiltroParent.Filtro_Detalle[Index].Filtro_Detalle = TTSearchControl1.MyFilter;

            Session["Filter" + ParentProcessId.ToString()] = objFiltroParent;
            Session.Remove("Filter" + ProcesId.ToString());
        }
        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener(" + IsDetail.ToString().ToLower() + ", '" + ProcesId.ToString() + "');</script>");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Session.Remove("Filter" + ProcesId.ToString());

        ClientScript.RegisterStartupScript(typeof(Page), "script", "<script language='javascript'>updateFromOpener(" + IsDetail.ToString().ToLower() + ", '" + ProcesId.ToString() + "');</script>");
    }
}








