using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TTSearchAdvanced : System.Web.UI.Page
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
                TTSearchAdvancedControl1.MyFilter = new ControlsLibrary.objectBussinessTTFiltro();
                TTSearchAdvancedControl1.MyFilter.GlobalInformation = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
            }
            else
                TTSearchAdvancedControl1.MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];
            TTSearchAdvancedControl1.MyFilter.ProcesoID = ProcesId;
        }
        else
        {
            ControlsLibrary.objectBussinessTTFiltro objRepDetalle, objRepParent;

            if (this.Request["ParentProcessId"] != null)
                ParentProcessId = myFunctions.FormatNumberNull(this.Request["ParentProcessId"]);

            Index = myFunctions.FormatNumberNull(this.Request["repIndex"]) == null ? 0 : (int)myFunctions.FormatNumberNull(this.Request["repIndex"]);

            if (Session["Filter" + ParentProcessId.ToString()] == null)
                objRepParent = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter"]);
            else
                objRepParent = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ParentProcessId.ToString()]);

            if (Session["Filter" + ProcesId.ToString()] != null)
                objRepDetalle = ((ControlsLibrary.objectBussinessTTFiltro)Session["Filter" + ProcesId.ToString()]);
            else
                objRepDetalle = objRepParent.Filtro_Detalle[Index].Filtro_Detalle;

            if (objRepDetalle != null)
                TTSearchAdvancedControl1.MyFilter = objRepDetalle;
            else
                TTSearchAdvancedControl1.MyFilter = new ControlsLibrary.objectBussinessTTFiltro();

            TTSearchAdvancedControl1.MyFilter.GlobalInformation = (TTSecurity.GlobalData)Session["UserGlobalInformation"];
        }

        if (this.Request["idReport"] != null)
            idReport = myFunctions.FormatNumberNull(this.Request["idReport"]);

        if (this.Request["IsQuestionable"] != null)
            IsQuestionable = bool.TryParse(this.Request["IsQuestionable"], out IsQuestionable);

        if (this.Request["IsModoConsulta"] != null)
            IsModoConsulta = bool.TryParse(this.Request["IsModoConsulta"], out IsModoConsulta);

        if (Session["Store"] != null)
        {
            TTSearchAdvancedControl1.EntryType = TTSearchAdvancedControl.TTFiltersAdvancedEntryType.QuickFilter;
            TTSearchAdvancedControl1.MyFilter.EntryType = ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter;
        }

        if (ProcesId.HasValue)
        {
            TTSearchAdvancedControl1.IsQuestionable = IsQuestionable;
            TTSearchAdvancedControl1.ModoConsulta = IsModoConsulta;
            TTSearchAdvancedControl1.IsDetail = IsDetail;
            TTSearchAdvancedControl1.New(ProcesId.Value);
        }

    }
    protected void btnAcept_Click(object sender, EventArgs e)
    {
        Index = myFunctions.FormatNumberNull(this.Request["repIndex"]) == null ? 0 : (int)myFunctions.FormatNumberNull(this.Request["repIndex"]);
        TTSearchAdvancedControl1.SaveChanges();
        if (!IsDetail)
        {
            Session.Remove("Filter" + ProcesId.ToString());
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(TTSearchAdvancedControl1.MyFilter.GlobalInformation);
            TTMetadata.MetadataDatos myMetaDatos = myMeta.GetDatosDT(TTSearchAdvancedControl1.MyFilter.Filtro_Detalle[0].Dt_Filtro.Value);

            Session["Filter"] = TTSearchAdvancedControl1.MyFilter;
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
            objFiltroParent.Filtro_Detalle[Index].Filtro_Detalle = TTSearchAdvancedControl1.MyFilter;

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








