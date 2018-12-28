/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTLanguageTraduction
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Subgurim.Controles;
using System.IO;
using App_Code.TTBusinessRules;

public partial class TTLanguageTraduction_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSTTLanguageTraduction.objectBussinessTTLanguageTraduction myTTLanguageTraduction = new WSTTLanguageTraduction.objectBussinessTTLanguageTraduction();
    private WSTTLanguageTraduction.GlobalData userData;
    public int iProcess = 6833;
    private String sDNTNombre = "TTLanguageTraduction";
    private String scallBackReturnVariable = null;

#region CallBackAsincrono
    public void RaiseCallbackEvent(String eventargument)
    {
        ArrayList arr = MyFunctions.ReturnInArray(eventargument, "@");
        String multiRenlgonName = arr[0].ToString();
        String columName = arr[1].ToString();
        int indexRow = MyFunctions.FormatNumberNull(arr[2].ToString()).Value;
        String ValueData;
        if (arr.Count > 3)
            ValueData = arr[3].ToString();
        else
            ValueData = "";
            
    }
    public String GetCallbackResult()
    {
        return "";
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);

        

        System.Web.UI.ScriptManager ajaxSM = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ScriptManager1");
        if (ajaxSM != null)
            ajaxSM.AsyncPostBackTimeout = 3600;

        
        
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");

        if (!Page.IsPostBack)
        {
        
            Session["CambiarArchivo"] = 0;
            RevisaLoadArchivo();
            ConfigWithMetadata();
            FillDataControls();
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                New();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }
            if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                Modification();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }
            if (Session["Tipo_Transaccion"].ToString() == "Consult")
            {
                Modification();
                DisableControls();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }

        }




        Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
        lblTitulo.Text = "Catálogo de " + sDNTNombre.Replace("_"," ");
        lblTitulo.DataBind();
    }

    protected override void OnUnload(EventArgs e)
    {
        //-----------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //-----------------------------------------------------------------------------------------------------------------------
    }

    protected void RevisaLoadArchivo()
    {
        if (Session["CambiarArchivo"]!=null)
        if (Session["CambiarArchivo"].ToString() == "0")
        {
            
            Session["CambiarArchivo"] = 0;
        }
    }

    protected void DisableControls()    
    {
                txtidTraduction.Enabled=false;
        txtTexto.Enabled=false;
        ddlIdioma.Enabled=false;
        TTbcIdioma.ImgButton.Visible = false;

        ddlRelacionProceso.Enabled=false;
        TTbcRelacionProceso.ImgButton.Visible = false;

        ddlRelacionDominio.Enabled=false;
        TTbcRelacionDominio.ImgButton.Visible = false;

        ddlRelacionDT.Enabled=false;
        TTbcRelacionDT.ImgButton.Visible = false;

        txtRelacionMessage.Enabled=false;

        
        cmdClear.Visible = false;
        btn_limpiar_catalog.Visible = false;
        cmdHelp.Visible = false;
        btn_ayuda_catalog.Visible = false;      
        cmdSave.Visible = false;
        btn_grabar_catalog.Visible = false;
        cmdSaveCopy.Visible = false;
        btn_grabar_copiar_catalog.Visible = false;
        cmdSaveNew.Visible = false;
        btn_grabar_nuevo_catalog.Visible = false;    
    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSTTLanguageTraduction.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTLanguageTraduction.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------
        TTbcIdioma.WebControl = ddlIdioma;
        TTbcIdioma.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcIdioma.GetControlDataSetFunctionWithString = myTTLanguageTraduction.FillDataIdioma;
        TTbcIdioma.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcRelacionProceso.WebControl = ddlRelacionProceso;
        TTbcRelacionProceso.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcRelacionProceso.GetControlDataSetFunctionWithString = myTTLanguageTraduction.FillDataRelacionProceso;
        TTbcRelacionProceso.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcRelacionDominio.WebControl = ddlRelacionDominio;
        TTbcRelacionDominio.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcRelacionDominio.GetControlDataSetFunctionWithString = myTTLanguageTraduction.FillDataRelacionDominio;
        TTbcRelacionDominio.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcRelacionDT.WebControl = ddlRelacionDT;
        TTbcRelacionDT.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcRelacionDT.GetControlDataSetFunctionWithInt = myTTLanguageTraduction.FillDataRelacionDTwithParent;
        TTbcRelacionDT.ParentWebControl = ddlRelacionDominio;

        
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        refreshMultiRenglones();
        
    }
    
    private void FillDataControls()
    {
                MyFunctions.FillDataControl(ddlIdioma, myTTLanguageTraduction.FillDataIdioma(""));
        MyFunctions.FillDataControl(ddlRelacionProceso, myTTLanguageTraduction.FillDataRelacionProceso(""));
        MyFunctions.FillDataControl(ddlRelacionDominio, myTTLanguageTraduction.FillDataRelacionDominio(""));
 //RelacionDT es hijo

    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTLanguageTraduction.objectBussinessTTLanguageTraduction1 myDataTTLanguageTraduction = myTTLanguageTraduction.GetByKey(MyFunctions.FormatNumberNull(Session["idTraduction"].ToString()),true);
                if (myDataTTLanguageTraduction.idTraduction.HasValue)
            txtidTraduction.Text = myDataTTLanguageTraduction.idTraduction.ToString();
        txtTexto.Text = myDataTTLanguageTraduction.Texto;
        if (myDataTTLanguageTraduction.Idioma.HasValue)
           ddlIdioma.SelectedValue = myDataTTLanguageTraduction.Idioma.Value.ToString().TrimEnd(' ');
        ddlIdioma_SelectedIndexChanged(ddlIdioma, new EventArgs());
        if (myDataTTLanguageTraduction.RelacionProceso.HasValue)
           ddlRelacionProceso.SelectedValue = myDataTTLanguageTraduction.RelacionProceso.Value.ToString().TrimEnd(' ');
        ddlRelacionProceso_SelectedIndexChanged(ddlRelacionProceso, new EventArgs());
        if (myDataTTLanguageTraduction.RelacionDominio.HasValue)
           ddlRelacionDominio.SelectedValue = myDataTTLanguageTraduction.RelacionDominio.Value.ToString().TrimEnd(' ');
        ddlRelacionDominio_SelectedIndexChanged(ddlRelacionDominio, new EventArgs());
        if (myDataTTLanguageTraduction.RelacionDT.HasValue)
           ddlRelacionDT.SelectedValue = myDataTTLanguageTraduction.RelacionDT.Value.ToString().TrimEnd(' ');
        ddlRelacionDT_SelectedIndexChanged(ddlRelacionDT, new EventArgs());
        if (myDataTTLanguageTraduction.RelacionMessage.HasValue)
            txtRelacionMessage.Text = myDataTTLanguageTraduction.RelacionMessage.ToString();

        
        
    }
    public void ConfigWithMetadata()
    {
        Boolean Foco = false;
        WSTTMetadata.objectBussinessTTMetadata myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        WSTTMetadata.TTMetadataFilters[] myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = iProcess.ToString();

        DataSet ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        DataView dv = new DataView(ds_controles.Tables[0]);

                dv.RowFilter = "TTMetadata_DTID = " + 30058;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblidTraduction.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblidTraduction.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtidTraduction.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtidTraduction.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtidTraduction.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtidTraduction.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtidTraduction.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtidTraduction.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtidTraduction.Text = "";
            }
        imgOblidTraduction.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVidTraduction.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        tridTraduction.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtidTraduction.Enabled == true)
        {
            GetFocus(txtidTraduction);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30059;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblTexto.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblTexto.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtTexto.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtTexto.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtTexto.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtTexto.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtTexto.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtTexto.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtTexto.Text = "";
            }
        imgOblTexto.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVTexto.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trTexto.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtTexto.Enabled == true)
        {
            GetFocus(txtTexto);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30064;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlIdioma.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlIdioma.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlIdioma.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlIdioma.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlIdioma.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlIdioma.SelectedValue = "";
	}
        trIdioma.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVIdioma.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblIdioma.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlIdioma.Enabled == true)
        {
            GetFocus(ddlIdioma);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30065;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblRelacionProceso.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblRelacionProceso.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlRelacionProceso.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlRelacionProceso.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlRelacionProceso.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlRelacionProceso.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlRelacionProceso.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
		ddlRelacionProceso.SelectedValue = "";
	}
        trRelacionProceso.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVRelacionProceso.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblRelacionProceso.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlRelacionProceso.Enabled == true)
        {
            GetFocus(ddlRelacionProceso);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30066;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblRelacionDominio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblRelacionDominio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlRelacionDominio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlRelacionDominio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlRelacionDominio.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlRelacionDominio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlRelacionDominio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
		ddlRelacionDominio.SelectedValue = "";
	}
        trRelacionDominio.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVRelacionDominio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblRelacionDominio.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlRelacionDominio.Enabled == true)
        {
            GetFocus(ddlRelacionDominio);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30067;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblRelacionDT.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblRelacionDT.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlRelacionDT.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlRelacionDT.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlRelacionDT.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlRelacionDT.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlRelacionDT.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
		ddlRelacionDT.SelectedValue = "";
	}
        trRelacionDT.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVRelacionDT.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblRelacionDT.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlRelacionDT.Enabled == true)
        {
            GetFocus(ddlRelacionDT);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30068;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblRelacionMessage.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblRelacionMessage.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtRelacionMessage.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtRelacionMessage.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtRelacionMessage.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtRelacionMessage.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtRelacionMessage.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtRelacionMessage.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtRelacionMessage.Text = "";
            }
        imgOblRelacionMessage.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVRelacionMessage.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trRelacionMessage.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtRelacionMessage.Enabled == true)
        {
            GetFocus(txtRelacionMessage);
            Foco = true;
        }

        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
        
        
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myTTLanguageTraduction.InsertWithReturnValue(userData,  txtTexto.Text, MyFunctions.FormatNumberNull(ddlIdioma.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionProceso.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionDominio.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionDT.SelectedValue), MyFunctions.FormatNumberNull(txtRelacionMessage.Text));
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------           
            return true;
        }
        catch (Exception exception)
        { 
            ShowAlert(exception.Message);
            return false;
        }
    }

    public Boolean Update_row()
    {
        
        
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTLanguageTraduction.Update(userData,  MyFunctions.FormatNumberNull(txtidTraduction.Text), txtTexto.Text, MyFunctions.FormatNumberNull(ddlIdioma.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionProceso.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionDominio.SelectedValue), MyFunctions.FormatNumberNull(ddlRelacionDT.SelectedValue), MyFunctions.FormatNumberNull(txtRelacionMessage.Text));
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            return true;
        }
        catch (Exception exception)
        { 
            ShowAlert(exception.Message);
            return false;
        }
    }



    public void Clear_All()
    {
        
    }
    
    protected bool IsValid3PointsRelations()
    {
        string sError = string.Empty;
        bool isValid = true;

        

        if (!isValid)
            ShowAlert(sError);

        return isValid;
    }
    
    protected void cmdSaveCopy_Click(object sender, ImageClickEventArgs e)
    {
        if (!IsValid3PointsRelations())
            return;
    
        
        
        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted=Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted=Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Session["Tipo_Transaccion"] = "New";
            Session["CambiarArchivo"] = 1;
        }
    }
    protected void cmdSaveNew_Click(object sender, ImageClickEventArgs e)
    {
        if (!IsValid3PointsRelations())
            return;
    
        
    
        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted=Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted=Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Clear_All();
            ConfigWithMetadata();
            Session["Tipo_Transaccion"] = "New";
        }
        Session["CambiarArchivo"] = 0;
    }
    protected void cmdSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!IsValid3PointsRelations())
            return;
    
        
    
        Boolean OperationCompleted = false;
        if (Session["Tipo_Transaccion"].ToString() == "New")
        {
            OperationCompleted=Insert_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Update")
        {
            OperationCompleted=Update_row();
        }
        else if (Session["Tipo_Transaccion"].ToString() == "Search")
        {
            //Search_row();
        }
        if (OperationCompleted)
        {
            Session["Tipo_Transaccion"]= "Update";
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Response.Redirect("TTLanguageTraduction_Lista.aspx");
        }
    }
    protected void cmdClose_Click(object sender, ImageClickEventArgs e)
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Response.Redirect("TTLanguageTraduction_Lista.aspx");
    }
    protected void cmdClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_All();
        ConfigWithMetadata();
    }
    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }

    public void ddlIdioma_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    public void ddlRelacionProceso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRelacionDT.Items.Clear();
        if (ddlRelacionProceso.SelectedValue != "")
        {
            MyFunctions.FillDataControl(ddlRelacionDT, myTTLanguageTraduction.FillDataRelacionDTwithParent(MyFunctions.FormatNumberNull(ddlRelacionProceso.SelectedValue).Value));
        }
     }
    public void ddlRelacionDominio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRelacionDT.Items.Clear();
        if (ddlRelacionDominio.SelectedValue != "")
        {
            MyFunctions.FillDataControl(ddlRelacionDT, myTTLanguageTraduction.FillDataRelacionDTwithParent(MyFunctions.FormatNumberNull(ddlRelacionDominio.SelectedValue).Value));
        }
     }
    public void ddlRelacionDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRelacionDT.Items.Clear();
        if (ddlRelacionDT.SelectedValue != "")
        {
            MyFunctions.FillDataControl(ddlRelacionDT, myTTLanguageTraduction.FillDataRelacionDTwithParent(MyFunctions.FormatNumberNull(ddlRelacionDT.SelectedValue).Value));
        }
     }

private void refreshMultiRenglones()
    {

    }

    void AgregaCeldaTextBox(HtmlTableRow trRenglon,String sID,String sTexto,Int32 iRenglon,String sCarpeta,String MultiRenglon,Boolean Multilinea )
    {
        HtmlTableCell td = new HtmlTableCell();
        TextBox txt = new TextBox();
        if (Multilinea == true)
        {
	txt.TextMode = TextBoxMode.MultiLine;
	txt.Columns = 40;
	txt.Rows = 5;
        }
        else
        {
	txt.Width = 100;
        }
        txt.ID = sID + iRenglon;
        txt.Text = sTexto;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        txt.EnableViewState = false;
        
        td.Controls.Add(txt);
        trRenglon.Cells.Add(td);
    }

    void AgregaCeldaComboBox(HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, DataSet dsFill, String sCarpeta, String MultiRenglon)
    {
        HtmlTableCell td = new HtmlTableCell();
        DropDownList ddl = new DropDownList();
        ddl.ID = sID + iRenglon;
        MyFunctions.FillDataControl(ddl, dsFill);
        if (sTexto != "")
            ddl.SelectedValue = sTexto;

        ddl.Attributes.Add("runat", "Server");
        ddl.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        ddl.EnableViewState = false;
        ddl.Width = 150;
        td.Controls.Add(ddl);
        trRenglon.Cells.Add(td);

    }
    void AgregaCeldaAjaxCalendar(HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, String sCarpeta, String MultiRenglon)
    {
        //Agregamos el TexBox
        HtmlTableCell td = new HtmlTableCell();
        TextBox txt = new TextBox();
        txt.ID = sID + iRenglon;
        if (sTexto != "")
        {
	DateTime fecha = DateTime.Parse(sTexto);
	txt.Text = String.Format("{0:MM/dd/yyyy}", fecha);
        }
        else
        {
	txt.Text = sTexto;
        }
        txt.Enabled = true;
        txt.Attributes.Add("runat", "Server");
        txt.Attributes.Add("onchange", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
        txt.EnableViewState = false;
        txt.Width = 100;	

        //Agregamos la imagen del calendario
        Image ImgCalendar = new Image();
        ImgCalendar.ID = "ImgCalendar" + sID + iRenglon;
        ImgCalendar.ImageUrl = "~/Images/greyscale_38.gif";
        ImgCalendar.Height = 20;
        ImgCalendar.Width = 22;
        ImgCalendar.Visible = true;
        ImgCalendar.Attributes.Add("runat", "Server");

        //Agregamos el objeto Calendar Ajax
        AjaxControlToolkit.CalendarExtender calendario = new AjaxControlToolkit.CalendarExtender();
        calendario.ID = "Calendario" + sID + iRenglon;
        calendario.Animated = true;
        //calendario.BehaviorID = "crl14_CalendarExtender" + sID + iRenglon;
        calendario.Enabled = true;
        calendario.EnabledOnClient = true;
        calendario.EnableViewState = true;
	calendario.Format = System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString();
        calendario.PopupButtonID = "ImgCalendar" + sID + iRenglon;
        calendario.TargetControlID = sID + iRenglon; //nombe del txt

        //Agregamos los controles a la celda
        td.Controls.Add(txt);
        td.Controls.Add(ImgCalendar);
        td.Controls.Add(calendario);

        //agregamos la celda  al renglon
        trRenglon.Cells.Add(td);
    }

    public static void GetFocus(Control control)
    {
    }

    protected byte[] ReadFile(string filePath)
    {
        byte[] buffer;
        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        try
        {
            int length = (int)fileStream.Length;  // get file length
            buffer = new byte[length];            // create buffer
            int count;                            // actual number of bytes read
            int sum = 0;                          // total number of bytes read

            // read until Read method returns 0 (end of the stream has been reached)
            while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
            	sum += count;  // sum is a buffer offset for next reading
        }
        finally
        {
            fileStream.Close();
        }
        return buffer;
    }





}









