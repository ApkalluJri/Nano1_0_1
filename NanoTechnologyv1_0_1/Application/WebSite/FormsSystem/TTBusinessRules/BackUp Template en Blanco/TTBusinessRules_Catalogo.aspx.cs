using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Telerik.Web.UI;
using App_Code.TTBusinessRules;
using System.Text;

public partial class FormsSystem_TTBusinessRules_TTBusinessRules_Catalogo : TTBasePage.TTBasePage //System.Web.UI.Page
{
    #region variables globales
    private int iCurrentRecord = -1;
    //private Form frmCall;
    public int iProcess = 6773;
    private bool Terminate = false;
    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
    /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
    #region
    //private object Tipo_Accion = -1;
    TTBusinessRules.BusinessRulesFunctions brFunctions = new TTBusinessRules.BusinessRulesFunctions();
    #endregion
    //private frmPopUpMultiRenglon frmPopUpMultiRenglonCondiciones;
    //private frmPopUpMultiRenglon frmPopUpMultiRenglonAcciones_True;
    //private frmPopUpMultiRenglon frmPopUpMultiRenglonAcciones_False;

    private TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso MyDataTTPermisos_Por_Proceso = new TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso();
    private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
    private App_Code.TTBusinessRules.BusinessOperations myBusinessRule; // = new TTBusinessRules.BusinessOperations();
    private TTStyleFormat.FormatScreen MyStyleFormat = new TTStyleFormat.FormatScreen();
    private TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
    private TTFunctions.Conversiones MyConversions = new TTFunctions.Conversiones();
    private TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTMetadata.MetadataConfigurationProcess myConfiguration;
    public TTMetadata.MetadataConfigurationProcess MyConfiguration
    {
        get { return myConfiguration; }
        set { myConfiguration = value; }
    }
    private TTBusinessRulesCS.objectBussinessTTBusinessRules MyDataTTBusinessRules = new TTBusinessRulesCS.objectBussinessTTBusinessRules();
    private QUALITYproj.TTenumToScreensConfigurations.ScreenMode EntryMode;
    TTMetadata.MetadataDatos MyMetaData;
    public int? Result = -1;
    private int businessRuleId = 0;
    //---------------------------------------------------------------------------------------------------------
    List<TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions> Condiciones;
    TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions objCondiciones;
    List<TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue> Acciones_True;
    TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue objAcciones_True;
    List<TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse> Acciones_False;
    TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse objAcciones_False;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();
        myConfiguration = new TTMetadata.MetadataConfigurationProcess(myUserData);
        myConfiguration.FillConfiguration(iProcess);

        if (Request["IdBusinesRule"] != null)
            businessRuleId = int.Parse(Request["IdBusinesRule"].ToString());
        if (!IsPostBack)
        {
            if (businessRuleId == 0)
                New();
            else
                Modification(businessRuleId);
        }
        if (Session["Tipo_Transaccion"] == "Consult")
        {
            Panel1.Enabled = false;
            PanelActions.Enabled = false;
            PanelAlcance.Enabled = false;
            PanelConditions.Enabled = false;
            PanelDatosGenerales.Enabled = false;
            PanelEventoDelProceso.Enabled = false;
            PanelOperacion.Enabled = false;
            cmdEvento_ProcesoAlls.Enabled = false;
            cmdEvento_ProcesoNone.Enabled = false;
            cmdEvento_CampoAlls.Enabled = false;
            cmdEvento_CampoNone.Enabled = false;
            cmdSaveNew.Enabled = false;
            cmdSaveCopy.Enabled = false;
            cmdSave.Enabled = false;
            cmdNew.Enabled = false;
            cmdHelp.Enabled = false;

        }
    }

    public void New()
    {
        MyDataTTBusinessRules = new TTBusinessRulesCS.objectBussinessTTBusinessRules();
        MyDataTTBusinessRules.Condiciones = new List<TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions>();
        MyDataTTBusinessRules.Acciones_True = new List<TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue>();
        MyDataTTBusinessRules.Acciones_False = new List<TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse>();
        MyDataTTBusinessRules.DBOperation = TTEnums.TTenumDBOperation.Insert;

        ConfigWithMetadata();
        this.txtidBusinessRule.Text = "AUTO";
        cbAlcance.DataBind();
        cbAlcance_SelectedIndexChanged(cbAlcance, new EventArgs());
        //if (tabControls.TabPages.Contains(tabPagRelationsProcess))
        //    tabControls.TabPages.RemoveByKey("tabPagRelationsProcess");
        //if (tabControls.TabPages.Contains(tabPagReports))
        //    tabControls.TabPages.RemoveByKey("tabPagReports");
        TTenumBusinessRules_ActionResultType[] mybusResult;
        //mybusResult = myBusinessRule.Comparation(iProcess, TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows);
        //if (mybusResult != null)
        //    foreach (TTenumBusinessRules_ActionResultType myRes in mybusResult)
        //        if (myRes == TTenumBusinessRules_ActionResultType.Break)
        //        {
        //            //this.Close();
        //            Response.Redirect("../Default.aspx");
        //            return;
        //        }
        Session["TTBusinessRules"] = MyDataTTBusinessRules;
        BindGridsWithSessionData();
    }


    protected void cmdNew_Click(object sender, EventArgs e)
    {
        New();
    }

    protected void BindGridsWithSessionData()
    {
        MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;

        Condiciones = MyDataTTBusinessRules.Condiciones;
        if (Condiciones != null)
            grvCondiciones.DataSource = Condiciones.Where(_objCondicion => _objCondicion.DBOperation != TTEnums.TTenumDBOperation.Delete);
        grvCondiciones.DataBind();

        Acciones_True = MyDataTTBusinessRules.Acciones_True;
        if (Acciones_True != null)
            grvAcciones_True.DataSource = Acciones_True.Where(_objAcciones => _objAcciones.DBOperation != TTEnums.TTenumDBOperation.Delete);
        grvAcciones_True.DataBind();

        Acciones_False = MyDataTTBusinessRules.Acciones_False;
        if (Acciones_False != null)
            grvAcciones_False.DataSource = Acciones_False.Where(_objAcciones => _objAcciones.DBOperation != TTEnums.TTenumDBOperation.Delete);
        grvAcciones_False.DataBind();
    }

    public void Modification(int? Key1)
    {
        Boolean isConsult = false;

        ConfigWithMetadata();
        MyDataTTBusinessRules.GetByKey(Key1, true);
        MyDataTTBusinessRules.DBOperation = TTEnums.TTenumDBOperation.Update;

        if (MyDataTTBusinessRules.idBusinessRule != null)
            txtidBusinessRule.Text = MyDataTTBusinessRules.idBusinessRule.ToString();
        if (MyDataTTBusinessRules.IdProceso != null)
        {
            ddlProceso.SelectedValue = MyDataTTBusinessRules.IdProceso.ToString();
            ddlProceso.Text = MyDataTTBusinessRules.IdProceso.ToString();
        }
        if (MyDataTTBusinessRules.Nombre != null)
            txtNombre.Text = MyDataTTBusinessRules.Nombre;
        if (MyDataTTBusinessRules.Fecha_de_Alta != null)
            dtFecha_de_Alta.SelectedDate = MyDataTTBusinessRules.Fecha_de_Alta;
        if (MyDataTTBusinessRules.Alcance != null)
            cbAlcance.SelectedValue = MyDataTTBusinessRules.Alcance.ToString();

        switch ((TTenumBusinessRules_Alcance)MyDataTTBusinessRules.Alcance)
        {
            case TTenumBusinessRules_Alcance.None:
                {
                    PanelOperacion.Visible = false;
                    PanelEventoDelProceso.Visible = false;
                    PanelEventoDelCampo.Visible = false;
                    break;
                }
            case TTenumBusinessRules_Alcance.Process:
                {
                    PanelOperacion.Visible = true;
                    PanelEventoDelProceso.Visible = true;
                    PanelEventoDelCampo.Visible = false;
                    break;
                }
            case TTenumBusinessRules_Alcance.Field:
                {
                    PanelOperacion.Visible = false;
                    PanelEventoDelProceso.Visible = false;
                    PanelEventoDelCampo.Visible = true;
                    break;
                }
        }


        if (MyDataTTBusinessRules.Operacion != null)
        {
            lstOperacion.DataBind();
            for (int i = 0; i < MyDataTTBusinessRules.Operacion.Length; i++)
                lstOperacion.Items.FindByValue(MyDataTTBusinessRules.Operacion[i].idOperacion.ToString()).Selected = true;
        }
        if (MyDataTTBusinessRules.Evento_Proceso != null)
        {
            lstEvento_Proceso.DataBind();
            for (int i = 0; i < MyDataTTBusinessRules.Evento_Proceso.Length; i++)
                lstEvento_Proceso.Items.FindByValue(MyDataTTBusinessRules.Evento_Proceso[i].idEvent.ToString()).Selected = true;
        }
        if (MyDataTTBusinessRules.Evento_Campo != null)
        {
            lstEvento_Campo.DataBind();
            for (int i = 0; i < MyDataTTBusinessRules.Evento_Campo.Length; i++)
                lstEvento_Campo.Items.FindByValue(MyDataTTBusinessRules.Evento_Campo[i].idEvent.ToString()).Selected = true;
        }

        Session["TTBusinessRules"] = MyDataTTBusinessRules;
        BindGridsWithSessionData();

        /*if (MyDataTTBusinessRules.Condiciones != null)
            MyDataTTBusinessRules.Condiciones[i].idBusinessRules;
            MyDataTTBusinessRules.Condiciones[i].idFolio;
            MyDataTTBusinessRules.Condiciones[i].CondicionOperador;
            MyDataTTBusinessRules.Condiciones[i].Tipo_Operador1                 
            MyDataTTBusinessRules.Condiciones[i].Valor_Operador1;
            MyDataTTBusinessRules.Condiciones[i].Condicion;
            MyDataTTBusinessRules.Condiciones[i].Tipo_Operador2 
            MyDataTTBusinessRules.Condiciones[i].Valor_Operador2;
         * 
         * idBusinessRules, idFolio, CondicionOperador, Tipo_Operador1, Valor_Operador1, Condicion, Tipo_Operador2, Valor_Operador2
            */
        /*if (MyDataTTBusinessRules.Acciones_True != null)
            MyDataTTBusinessRules.Acciones_True[i].idBusinessRules;
            MyDataTTBusinessRules.Acciones_True[i].idFolio;
            MyDataTTBusinessRules.Acciones_True[i].Tipo_Accion;
            MyDataTTBusinessRules.Acciones_True[i].Tipo_Accion_Resultado;
            MyDataTTBusinessRules.Acciones_True[i].Parametro1;
            MyDataTTBusinessRules.Acciones_True[i].Parametro2;
            MyDataTTBusinessRules.Acciones_True[i].Parametro3;
            MyDataTTBusinessRules.Acciones_True[i].Parametro4;
            MyDataTTBusinessRules.Acciones_True[i].Parametro5;
            */
        /*if (MyDataTTBusinessRules.Acciones_False != null)
            MyDataTTBusinessRules.Acciones_False[i].idBusinessRules;
            MyDataTTBusinessRules.Acciones_False[i].idFolio;
            MyDataTTBusinessRules.Acciones_False[i].Tipo_Accion;
            MyDataTTBusinessRules.Acciones_False[i].Tipo_Accion_Resultado;
            MyDataTTBusinessRules.Acciones_False[i].Parametro1;
            MyDataTTBusinessRules.Acciones_False[i].Parametro2;
            MyDataTTBusinessRules.Acciones_False[i].Parametro3;
            MyDataTTBusinessRules.Acciones_False[i].Parametro4;
            MyDataTTBusinessRules.Acciones_False[i].Parametro5;
            */

        this.txtidBusinessRule.Enabled = false;

        RefreshRelations();
        RefreshReports();
        //MyDataTTBusinessRules.FiltersObligatories(((frmPrincipal)this.Tag).GlobalInformation);
        iCurrentRecord = MyDataTTBusinessRules.CurrentPosicion(Key1);
        int iTotalRecord = MyDataTTBusinessRules.SelCount();
        int iCurrentTemp = iCurrentRecord + 1;
        //toolStripNavigatorDescription.Text = MyTraductor.getMessage(80).Replace("%Current%", iCurrentTemp.ToString()).Replace("%Total%", iTotalRecord.ToString());   // "Registro " + (iCurrentRecord + 1) + " de " + iTotalRecord.ToString();
        //toolStripNavigatorDescription.Text = "Registro " + (iCurrentRecord + 1) + " de " + iTotalRecord.ToString();

        /*if (!isConsult)
        {
            TTenumBusinessRules_ActionResultType[] mybusResult;
            mybusResult = myBusinessRule.Comparation(this, iProcess, TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.OpenWindows);
            if (mybusResult != null)
                foreach (TTenumBusinessRules_ActionResultType myRes in mybusResult)
                    if (myRes == TTenumBusinessRules_ActionResultType.Break)
                    {
                        this.Close();
                        return;
                    }
        }*/
    }

    private void ConfigWithMetadata()
    {
        MyMetaData = myConfiguration.RowGet(14975);
        //PanelDatosGenerales.Visible = MyMetaData.Visible;
        //PanelDatosGenerales.Enabled = !MyMetaData.SoloLectura;
        //PanelDatosGenerales.ToolTip = MyMetaData.TextoAyuda;
        txtidBusinessRule.Visible = MyMetaData.Visible;
        txtidBusinessRule.Enabled = !MyMetaData.SoloLectura;
        txtidBusinessRule.ToolTip = MyMetaData.TextoAyuda;
        txtidBusinessRule.Text = MyMetaData.ValorPorDefecto;
        if (MyMetaData.Obligatorio)
            lblidBusinessRule.Text = MyMetaData.Descripcion + " º:";
        else
            lblidBusinessRule.Text = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(15007);
        ddlProceso.ToolTip = MyMetaData.TextoAyuda;
        lblIdProceso.ToolTip = MyMetaData.TextoAyuda;
        ddlProceso.Text = MyMetaData.ValorPorDefecto;
        //valTxtIdProceso.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valTxtIdProceso.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valTxtIdProceso.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14976);
        txtNombre.ToolTip = MyMetaData.TextoAyuda;
        lblNombre.ToolTip = MyMetaData.TextoAyuda;
        txtNombre.Text = MyMetaData.ValorPorDefecto;
        //valTxtNombre.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valTxtNombre.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valTxtNombre.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14977);
        dtFecha_de_Alta.ToolTip = MyMetaData.TextoAyuda;
        lblFechaAlta.ToolTip = MyMetaData.TextoAyuda;
        if (MyMetaData.ValorPorDefecto != "")
        {
            dtFecha_de_Alta.SelectedDate = Convert.ToDateTime(MyMetaData.ValorPorDefecto);
        }
        else
        {
            dtFecha_de_Alta.SelectedDate = DateTime.Today;
        }
        //valDtFecha_de_Alta.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valDtFecha_de_Alta.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valDtFecha_de_Alta.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14980);
        PanelAlcance.Visible = MyMetaData.Visible;
        PanelAlcance.Enabled = !MyMetaData.SoloLectura;
        PanelAlcance.ToolTip = MyMetaData.TextoAyuda;
        cbAlcance.ToolTip = MyMetaData.TextoAyuda;
        if (MyMetaData.ValorPorDefecto == String.Empty)
        { } //cbAlcance.SelectedValue = String.Empty;
        else
            cbAlcance.SelectedValue = MyMetaData.ValorPorDefecto;
        //valCbAlcance.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valCbAlcance.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valCbAlcance.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14981);
        PanelOperacion.Visible = MyMetaData.Visible;
        PanelOperacion.Enabled = !MyMetaData.SoloLectura;
        PanelOperacion.ToolTip = MyMetaData.TextoAyuda;
        lstOperacion.ToolTip = MyMetaData.TextoAyuda;
        //valLstOperacion.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valLstOperacion.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valLstOperacion.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14984);
        PanelEventoDelProceso.Visible = MyMetaData.Visible;
        PanelEventoDelProceso.Enabled = !MyMetaData.SoloLectura;
        PanelEventoDelProceso.ToolTip = MyMetaData.TextoAyuda;
        lstEvento_Proceso.ToolTip = MyMetaData.TextoAyuda;
        //valLstEvento_Proceso.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valLstEvento_Proceso.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valLstEvento_Proceso.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14987);
        PanelEventoDelCampo.Visible = MyMetaData.Visible;
        PanelEventoDelCampo.Enabled = !MyMetaData.SoloLectura;
        PanelEventoDelCampo.ToolTip = MyMetaData.TextoAyuda;
        lstEvento_Campo.ToolTip = MyMetaData.TextoAyuda;
        //valLstEvento_Campo.Enabled = MyMetaData.Obligatorio;
        //if (MyMetaData.Obligatorio)
        //    valLstEvento_Campo.ErrorMessage = MyMetaData.Descripcion + " º:";
        //else
        //    valLstEvento_Campo.ErrorMessage = MyMetaData.Descripcion + " :";

        MyMetaData = myConfiguration.RowGet(14996);
        PanelConditions.Visible = MyMetaData.Visible;
        PanelConditions.ToolTip = MyMetaData.TextoAyuda;

        //-----------------------------------------Configurar Grids------------------------------------------
        /*Control gridControl;
        MyMetaData = myConfiguration.RowGet(14988);
        gridControl = grvCondiciones.FindControl("ddlOperadorDeCondicion");

        (gridControl as DropDownList).Visible = MyMetaData.Visible;
        (gridControl as DropDownList).Enabled = !MyMetaData.SoloLectura;
        (gridControl as DropDownList).ToolTip = MyMetaData.TextoAyuda;
        
        MyMetaData = myConfiguration.RowGet();
        grvcolCondicionesTipo_Operador1.Visible = MyMetaData.Visible;
        grvcolCondicionesTipo_Operador1.ReadOnly = MyMetaData.SoloLectura;
        grvcolCondicionesTipo_Operador1.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolCondicionesTipo_Operador1.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolCondicionesTipo_Operador1.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblCondicionesDTValor_Operador1.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblCondicionesDTValor_Operador1.Text));
        grvcolCondicionesValor_Operador1.Visible = MyMetaData.Visible;
        grvcolCondicionesValor_Operador1.ReadOnly = MyMetaData.SoloLectura;
        grvcolCondicionesValor_Operador1.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolCondicionesValor_Operador1.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolCondicionesValor_Operador1.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblCondicionesDTCondicion.Text));
        
         * 
         * Acciones True
         * 
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblCondicionesDTCondicion.Text));
        grvcolCondicionesCondicion.Visible = MyMetaData.Visible;
        grvcolCondicionesCondicion.ReadOnly = MyMetaData.SoloLectura;
        grvcolCondicionesCondicion.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolCondicionesCondicion.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolCondicionesCondicion.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblCondicionesDTTipo_Operador2.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblCondicionesDTTipo_Operador2.Text));
        grvcolCondicionesTipo_Operador2.Visible = MyMetaData.Visible;
        grvcolCondicionesTipo_Operador2.ReadOnly = MyMetaData.SoloLectura;
        grvcolCondicionesTipo_Operador2.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolCondicionesTipo_Operador2.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolCondicionesTipo_Operador2.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblCondicionesDTValor_Operador2.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblCondicionesDTValor_Operador2.Text));
        grvcolCondicionesValor_Operador2.Visible = MyMetaData.Visible;
        grvcolCondicionesValor_Operador2.ReadOnly = MyMetaData.SoloLectura;
        grvcolCondicionesValor_Operador2.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolCondicionesValor_Operador2.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolCondicionesValor_Operador2.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(picRowAcciones_True.Tag));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(picRowAcciones_True.Tag));
        picRowAcciones_True.Visible = MyMetaData.Visible;
        //            if (!MyMetaData.Visible)
        //                MyFunctions.SlideFields(picRowAcciones_True, picRowAcciones_True.Visible);
        ToolTipText.SetToolTip(picRowAcciones_True, MyMetaData.TextoAyuda);
        ToolTipText.SetToolTip(lblAcciones_True, MyMetaData.TextoAyuda);
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTTipo_Accion.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTTipo_Accion.Text));
        grvcolAcciones_TrueTipo_Accion.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueTipo_Accion.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueTipo_Accion.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueTipo_Accion.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueTipo_Accion.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTTipo_Accion_Resultado.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTTipo_Accion_Resultado.Text));
        grvcolAcciones_TrueTipo_Accion_Resultado.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueTipo_Accion_Resultado.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueTipo_Accion_Resultado.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueTipo_Accion_Resultado.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueTipo_Accion_Resultado.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTParametro1.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTParametro1.Text));
        grvcolAcciones_TrueParametro1.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueParametro1.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueParametro1.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueParametro1.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueParametro1.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTParametro2.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTParametro2.Text));
        grvcolAcciones_TrueParametro2.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueParametro2.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueParametro2.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueParametro2.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueParametro2.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTParametro3.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTParametro3.Text));
        grvcolAcciones_TrueParametro3.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueParametro3.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueParametro3.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueParametro3.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueParametro3.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTParametro4.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTParametro4.Text));
        grvcolAcciones_TrueParametro4.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueParametro4.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueParametro4.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueParametro4.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueParametro4.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_TrueDTParametro5.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_TrueDTParametro5.Text));
        grvcolAcciones_TrueParametro5.Visible = MyMetaData.Visible;
        grvcolAcciones_TrueParametro5.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_TrueParametro5.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_TrueParametro5.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_TrueParametro5.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(picRowAcciones_False.Tag));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(picRowAcciones_False.Tag));
        picRowAcciones_False.Visible = MyMetaData.Visible;
        //            if (!MyMetaData.Visible)
        //                MyFunctions.SlideFields(picRowAcciones_False, picRowAcciones_False.Visible);
        ToolTipText.SetToolTip(picRowAcciones_False, MyMetaData.TextoAyuda);
        ToolTipText.SetToolTip(lblAcciones_False, MyMetaData.TextoAyuda);
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTTipo_Accion.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTTipo_Accion.Text));
        grvcolAcciones_FalseTipo_Accion.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseTipo_Accion.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseTipo_Accion.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseTipo_Accion.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseTipo_Accion.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTTipo_Accion_Resultado.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTTipo_Accion_Resultado.Text));
        grvcolAcciones_FalseTipo_Accion_Resultado.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseTipo_Accion_Resultado.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseTipo_Accion_Resultado.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseTipo_Accion_Resultado.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseTipo_Accion_Resultado.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTParametro1.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTParametro1.Text));
        grvcolAcciones_FalseParametro1.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseParametro1.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseParametro1.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseParametro1.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseParametro1.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTParametro2.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTParametro2.Text));
        grvcolAcciones_FalseParametro2.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseParametro2.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseParametro2.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseParametro2.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseParametro2.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTParametro3.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTParametro3.Text));
        grvcolAcciones_FalseParametro3.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseParametro3.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseParametro3.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseParametro3.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseParametro3.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTParametro4.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTParametro4.Text));
        grvcolAcciones_FalseParametro4.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseParametro4.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseParametro4.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseParametro4.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseParametro4.HeaderText = MyMetaData.Descripcion + " :";
        //            MyMetaData = MyMeta.GetDatosDT(Convert.ToInt32(lblAcciones_FalseDTParametro5.Text));
        MyMetaData = myConfiguration.RowGet(Convert.ToInt32(lblAcciones_FalseDTParametro5.Text));
        grvcolAcciones_FalseParametro5.Visible = MyMetaData.Visible;
        grvcolAcciones_FalseParametro5.ReadOnly = MyMetaData.SoloLectura;
        grvcolAcciones_FalseParametro5.ToolTipText = MyMetaData.TextoAyuda;
        if (MyMetaData.Obligatorio)
            grvcolAcciones_FalseParametro5.HeaderText = MyMetaData.Descripcion + " º:";
        else
            grvcolAcciones_FalseParametro5.HeaderText = MyMetaData.Descripcion + " :";
        */
    }

    private void RefreshRelations()
    {
        DataTable dt;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTTRelations_X_Process";
        com.Parameters.AddWithValue("@ProcessID", iProcess);
        com.CommandType = CommandType.StoredProcedure;
        dt = db.Consulta(com).Tables[0];


        foreach (DataRow dr in dt.Rows)
        {
            try
            {
                Type T = Type.GetType("QUALITYproj.frm" + MyFunctions.GenerateName(dr["Dato_No_Terminal_Nombre"].ToString()) + "_Lista", false);
                //Definimos el filtro por la llave de esta pantalla
                {
                    DataTable dtFilter;
                    if (dr["TipoDeRelacion"].ToString() == "Directo")
                    {
                        com = new SqlCommand();
                        com.CommandText = "spTTRelations_X_DNTID";
                        com.Parameters.AddWithValue("@DNTID", dr["Dato_No_Terminal_DNTID"]);
                        com.Parameters.AddWithValue("@DTID", 14975);
                        com.CommandType = CommandType.StoredProcedure;
                        dtFilter = db.Consulta(com).Tables[0];

                        string sClass = MyFunctions.GenerateName(dtFilter.Rows[0]["Dato_No_Terminal_Nombre"].ToString().TrimEnd(' ') + "CS.objectBussiness" + dtFilter.Rows[0]["Dato_No_Terminal_Nombre"].ToString());
                        Type theMathType = Type.GetType(sClass);
                        Object theObj = Activator.CreateInstance(theMathType);

                        string sClassFilter = MyFunctions.GenerateName(dtFilter.Rows[0]["Dato_No_Terminal_Nombre"].ToString().TrimEnd(' ') + "CS." + dtFilter.Rows[0]["Dato_No_Terminal_Nombre"].ToString().TrimEnd(' ') + "Filters");
                        Type theFilterType = Type.GetType(sClassFilter);
                        Object theObjFilter = Activator.CreateInstance(theFilterType);
                        MethodInfo MethodFilterRelation = theFilterType.GetMethod("get_" + MyFunctions.GenerateName(dtFilter.Rows[0]["Dato_Terminal_Nombre"].ToString()));
                        TTClassSpecials.FiltersTypes.Dependientes FilterRelationKey = (TTClassSpecials.FiltersTypes.Dependientes)MethodFilterRelation.Invoke(theObjFilter, null);
                        FilterRelationKey.List = new String[1];
                        FilterRelationKey.List[0] = txtidBusinessRule.Text;

                        //Dar el valor a los filtros
                        Type[] paramTypesFilter = new Type[1];
                        paramTypesFilter[0] = theFilterType;
                        MethodInfo MethodSetFilter = theMathType.GetMethod("set_Filter", paramTypesFilter);
                        Object[] parametersFilters = new Object[1];
                        parametersFilters[0] = theObjFilter;
                        MethodSetFilter.Invoke(theObj, parametersFilters);

                        Type[] paramTypesValues = new Type[1];
                        paramTypesValues[0] = theMathType.GetMethod("set_" + MyFunctions.GenerateName(dtFilter.Rows[0]["Dato_Terminal_Nombre"].ToString())).GetParameters()[0].ParameterType;
                        MethodInfo MethodSetValues = theMathType.GetMethod("set_" + MyFunctions.GenerateName(dtFilter.Rows[0]["Dato_Terminal_Nombre"].ToString()), paramTypesValues);
                        Object[] parametersValues = new Object[1];
                        if (paramTypesValues[0] == typeof(System.String))
                            parametersValues[0] = txtidBusinessRule.Text;
                        else
                            parametersValues[0] = MyFunctions.FormatNumberNull(txtidBusinessRule.Text);
                        MethodSetValues.Invoke(theObj, parametersValues);

                        paramTypesFilter[0] = theMathType;
                        //MethodSetFilter = frm.GetType().GetMethod("FromCatalago", paramTypesFilter);
                        parametersFilters[0] = theObj;
                        //MethodSetFilter.Invoke(frm, parametersFilters);
                    }
                }
                //tabControlRelations.TabPages.Add(frm);
            }
            catch { }
        }
    }

    private void RefreshReports()
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTTTemplatePrintExcel_RegistrosPorProceso";
        com.Parameters.AddWithValue("@ProcesoId", iProcess);
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
        /*toolStripReports.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            ToolStripButton tool = (ToolStripButton)toolStripReports.Items.Add("");
            tool.Text = dr["Descripcion"].ToString().TrimEnd(' ');
            tool.TextImageRelation = TextImageRelation.TextBeforeImage;
            tool.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tool.Tag = dr["IdTemplate"].ToString().TrimEnd(' ');
        }
        if (toolStripReports.Items.Count == 0)
        {
            if (tabControls.Contains(tabPagReports))
                tabControls.TabPages.Remove(tabPagReports);
        }
        else
        {
            if (!tabControls.Contains(tabPagReports))
                tabControls.TabPages.Add(tabPagReports);
        }*/
    }
    protected void cbAlcance_SelectedIndexChanged(object sender, EventArgs e)
    {
        //myBusinessRule.Comparation(this, iProcess, TTenumBusinessRules_Alcance.Field, TTenumBusinessRules_FieldEvent.LostFocus);
        int? valueData;
        if ((sender as DropDownList).SelectedValue != null)
            if ((sender as DropDownList).SelectedValue.GetType() == typeof(DataRowView))
                valueData = MyFunctions.FormatNumberNull((((sender as DropDownList).SelectedValue)[0].ToString()));
            else
                valueData = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue.ToString());
        else
            valueData = 0;
        switch ((TTenumBusinessRules_Alcance)valueData.Value)
        {
            case TTenumBusinessRules_Alcance.None:
                {
                    PanelOperacion.Visible = false;
                    valLstOperacion.Enabled = false;
                    PanelEventoDelProceso.Visible = false;
                    valLstEvento_Proceso.Enabled = false;
                    PanelEventoDelCampo.Visible = false;
                    valLstEvento_Campo.Enabled = false;
                    break;
                }
            case TTenumBusinessRules_Alcance.Process:
                {
                    PanelOperacion.Visible = true;
                    valLstOperacion.Enabled = true;
                    PanelEventoDelProceso.Visible = true;
                    valLstEvento_Proceso.Enabled = true;
                    PanelEventoDelCampo.Visible = false;
                    valLstEvento_Campo.Enabled = false;
                    break;
                }
            case TTenumBusinessRules_Alcance.Field:
                {
                    PanelOperacion.Visible = false;
                    valLstOperacion.Enabled = false;
                    PanelEventoDelProceso.Visible = false;
                    valLstEvento_Proceso.Enabled = false;
                    PanelEventoDelCampo.Visible = true;
                    valLstEvento_Campo.Enabled = true;
                    break;
                }
        }
    }

    protected void grvCondiciones_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        /** idBusinessRules, idFolio, CondicionOperador, Tipo_Operador1, Valor_Operador1, Condicion, Tipo_Operador2, Valor_Operador2 **/
        object CondicionOperador, Tipo_Operador1, Valor_Operador1, Condicion, Tipo_Operador2, Valor_Operador2;

        if (e.Item is Telerik.Web.UI.GridDataItem && !e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridDataItem item = (Telerik.Web.UI.GridDataItem)e.Item;

            CondicionOperador = item.GetDataKeyValue("CondicionOperador");
            Tipo_Operador1 = item.GetDataKeyValue("Tipo_Operador1") as int?;
            Valor_Operador1 = item.GetDataKeyValue("Valor_Operador1");
            Condicion = item.GetDataKeyValue("Condicion").ToString();
            Tipo_Operador2 = item.GetDataKeyValue("Tipo_Operador2") as int?;
            Valor_Operador2 = item.GetDataKeyValue("Valor_Operador2");

            DropDownList ddlOperadorDeCondicion = (item.FindControl("ddlOperadorDeCondicion") as DropDownList);
            DropDownList ddlTipoDeOperador1 = (item.FindControl("ddlTipoDeOperador1") as DropDownList);
            Button cmdValorDelOperador1 = (item.FindControl("cmdValorDelOperador1") as Button);
            DropDownList ddlCondicion = (item.FindControl("ddlCondicion") as DropDownList);
            DropDownList ddlTipoDeOperador2 = (item.FindControl("ddlTipoDeOperador2") as DropDownList);
            Button cmdValorDelOperador2 = (item.FindControl("cmdValorDelOperador2") as Button);

            ddlOperadorDeCondicion.SelectedValue = CondicionOperador.ToString();
            ddlTipoDeOperador1.SelectedValue = Tipo_Operador1.ToString();
            ddlCondicion.SelectedValue = Condicion.ToString();
            ddlTipoDeOperador2.SelectedValue = Tipo_Operador2.ToString();

            switch ((TTenumBusinessRules_ConditionTypeOperator1)Tipo_Operador1)
            {
                case TTenumBusinessRules_ConditionTypeOperator1.Field:
                    TTMetadata.Metadata mymeta = new TTMetadata.Metadata(myUserData);
                    TTMetadata.MetadataDatos myData = mymeta.GetDatosDT(MyFunctions.FormatNumberNull(Valor_Operador1.ToString().Substring(Valor_Operador1.ToString().LastIndexOf(".") + 1)).Value);
                    cmdValorDelOperador1.Text = myData.NombreTabla + "." + myData.Nombre;
                    break;
                case TTenumBusinessRules_ConditionTypeOperator1.Global:
                default:
                    cmdValorDelOperador1.Text = Valor_Operador1.ToString();
                    break;
            }

            switch ((TTenumBusinessRules_ConditionTypeOperator2)(Tipo_Operador2 as int?))
            {
                case TTenumBusinessRules_ConditionTypeOperator2.Field:
                    TTMetadata.Metadata mymeta = new TTMetadata.Metadata(myUserData);
                    TTMetadata.MetadataDatos myData = mymeta.GetDatosDT(MyFunctions.FormatNumberNull(Valor_Operador2.ToString().Substring(Valor_Operador2.ToString().LastIndexOf(".") + 1)).Value);
                    cmdValorDelOperador2.Text = myData.NombreTabla + "." + myData.Nombre;
                    break;
                case TTenumBusinessRules_ConditionTypeOperator2.Global:
                default:
                    cmdValorDelOperador2.Text = Valor_Operador2.ToString();
                    break;
            }
        }
        else if (e.Item is Telerik.Web.UI.GridDataInsertItem && e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridDataInsertItem insertItem = e.Item as Telerik.Web.UI.GridDataInsertItem;
            insertItem.Selected = true;

            DropDownList ddlTipoDeOperador1F = (insertItem.FindControl("ddlTipoDeOperador1F") as DropDownList);
            DropDownList ddlTipoDeOperador2F = (insertItem.FindControl("ddlTipoDeOperador2F") as DropDownList);

            ddlTipoDeOperador1F_SelectedIndexChanged(ddlTipoDeOperador1F, new EventArgs());
            ddlTipoDeOperador2F_SelectedIndexChanged(ddlTipoDeOperador2F, new EventArgs());
        }
        else if (e.Item is Telerik.Web.UI.GridEditableItem && e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridEditableItem editedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = editedItem.EditManager;
            e.Item.Selected = true;

            //object idBusinessRules = item.GetDataKeyValue("idBusinessRules");
            //object idFolio = item.GetDataKeyValue("idFolio").ToString();
            CondicionOperador = editedItem.GetDataKeyValue("CondicionOperador");
            Tipo_Operador1 = editedItem.GetDataKeyValue("Tipo_Operador1") as int?;
            Valor_Operador1 = editedItem.GetDataKeyValue("Valor_Operador1");
            Condicion = editedItem.GetDataKeyValue("Condicion").ToString();
            Tipo_Operador2 = editedItem.GetDataKeyValue("Tipo_Operador2") as int?;
            Valor_Operador2 = editedItem.GetDataKeyValue("Valor_Operador2");

            DropDownList ddlOperadorDeCondicionF = (editedItem.FindControl("ddlOperadorDeCondicionF") as DropDownList);
            ddlOperadorDeCondicionF.SelectedValue = CondicionOperador.ToString();
            DropDownList ddlTipoDeOperador1F = (editedItem.FindControl("ddlTipoDeOperador1F") as DropDownList);
            ddlTipoDeOperador1F.SelectedValue = Tipo_Operador1.ToString();
            //---------------------------------------------------------------------------------------
            Label lblValorDelOperador2 = (editedItem.FindControl("lblValorDelOperador2") as Label);
            RadComboBox ddlValorDelOperador2 = (editedItem.FindControl("ddlValorDelOperador2") as RadComboBox);
            RadTextBox txtValorDelOperador2 = (editedItem.FindControl("txtValorDelOperador2") as RadTextBox);
            //----------------------------------------------------------------------------------------
            DropDownList ddlCondicionF = (editedItem.FindControl("ddlCondicionF") as DropDownList);
            ddlCondicionF.SelectedValue = Condicion.ToString();
            DropDownList ddlTipoDeOperador2F = (editedItem.FindControl("ddlTipoDeOperador2F") as DropDownList);
            ddlTipoDeOperador2F.SelectedValue = Tipo_Operador2.ToString();
            //---------------------------------------------------------------------------------------
            Label lblValorDelOperador1 = (editedItem.FindControl("lblValorDelOperador1") as Label);
            RadComboBox ddlValorDelOperador1 = (editedItem.FindControl("ddlValorDelOperador1") as RadComboBox);
            RadTextBox txtValorDelOperador1 = (editedItem.FindControl("txtValorDelOperador1") as RadTextBox);
            //----------------------------------------------------------------------------------------
            ddlTipoDeOperador1F_SelectedIndexChanged(ddlTipoDeOperador1F, new EventArgs());
            ddlTipoDeOperador2F_SelectedIndexChanged(ddlTipoDeOperador2F, new EventArgs());

            if (ddlValorDelOperador2.Items.Count > 0)
                ddlValorDelOperador2.SelectedValue = Valor_Operador2.ToString();
            if (ddlValorDelOperador1.Items.Count > 0)
                ddlValorDelOperador1.SelectedValue = Valor_Operador1.ToString();

            txtValorDelOperador2.Text = Valor_Operador2.ToString();
            txtValorDelOperador1.Text = Valor_Operador1.ToString();
        }
    }

    protected void grvCondiciones_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        object idBusinessRules, idFolio;

        if (e.CommandName == "Update")
        {
            Telerik.Web.UI.GridEditableItem editedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = editedItem.EditManager;

            idBusinessRules = editedItem.GetDataKeyValue("idBusinessRules");
            idFolio = editedItem.GetDataKeyValue("idFolio");

            DropDownList ddlOperadorDeCondicionF = (editedItem.FindControl("ddlOperadorDeCondicionF") as DropDownList);
            DropDownList ddlTipoDeOperador1F = (editedItem.FindControl("ddlTipoDeOperador1F") as DropDownList);
            //---------------------------------------------------------------------------------------
            RadComboBox ddlValorDelOperador2 = (editedItem.FindControl("ddlValorDelOperador2") as RadComboBox);
            RadTextBox txtValorDelOperador2 = (editedItem.FindControl("txtValorDelOperador2") as RadTextBox);
            //----------------------------------------------------------------------------------------
            DropDownList ddlCondicionF = (editedItem.FindControl("ddlCondicionF") as DropDownList);
            DropDownList ddlTipoDeOperador2F = (editedItem.FindControl("ddlTipoDeOperador2F") as DropDownList);
            //---------------------------------------------------------------------------------------
            RadComboBox ddlValorDelOperador1 = (editedItem.FindControl("ddlValorDelOperador1") as RadComboBox);
            RadTextBox txtValorDelOperador1 = (editedItem.FindControl("txtValorDelOperador1") as RadTextBox);
            //----------------------------------------------------------------------------------------
            editedItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Condiciones = MyDataTTBusinessRules.Condiciones;
            objCondiciones = Condiciones.Find(_objCondiciones => _objCondiciones.idFolio == (idFolio as int?) && _objCondiciones.idBusinessRules == (idBusinessRules as int?));

            GetValuesFromControlsOperaciones(int.Parse(ddlTipoDeOperador1F.SelectedValue), int.Parse(ddlTipoDeOperador2F.SelectedValue),
                ddlValorDelOperador1, txtValorDelOperador1, ddlValorDelOperador2, txtValorDelOperador2,
                int.Parse(ddlCondicionF.SelectedValue), int.Parse(ddlOperadorDeCondicionF.SelectedValue),
                ref objCondiciones);
            objCondiciones.DBOperation = TTEnums.TTenumDBOperation.Update;
            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        else if (e.CommandName == "Delete")
        {
            Telerik.Web.UI.GridDataItem deletedItem = e.Item as Telerik.Web.UI.GridDataItem;

            idBusinessRules = deletedItem.GetDataKeyValue("idBusinessRules");
            idFolio = deletedItem.GetDataKeyValue("idFolio");

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Condiciones = MyDataTTBusinessRules.Condiciones;

            objCondiciones = Condiciones.Find(_objCondiciones => _objCondiciones.idFolio == (idFolio as int?) && _objCondiciones.idBusinessRules == (idBusinessRules as int?));
            /* Si la Regla de Negocio es nueva entonces entonces borra la condicion del arreglo*/
            if (idBusinessRules == null)
                Condiciones.Remove(objCondiciones);
            /* Sino marca el registro para que se borre en base de datos*/
            else
                objCondiciones.DBOperation = TTEnums.TTenumDBOperation.Delete;

            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        else if (e.CommandName == "PerformInsert")
        {
            Telerik.Web.UI.GridEditableItem insertItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = insertItem.EditManager;

            DropDownList ddlOperadorDeCondicionF = (insertItem.FindControl("ddlOperadorDeCondicionF") as DropDownList);
            DropDownList ddlTipoDeOperador1F = (insertItem.FindControl("ddlTipoDeOperador1F") as DropDownList);
            //---------------------------------------------------------------------------------------
            RadComboBox ddlValorDelOperador2 = (insertItem.FindControl("ddlValorDelOperador2") as RadComboBox);
            RadTextBox txtValorDelOperador2 = (insertItem.FindControl("txtValorDelOperador2") as RadTextBox);
            //----------------------------------------------------------------------------------------
            DropDownList ddlCondicionF = (insertItem.FindControl("ddlCondicionF") as DropDownList);
            DropDownList ddlTipoDeOperador2F = (insertItem.FindControl("ddlTipoDeOperador2F") as DropDownList);
            //---------------------------------------------------------------------------------------
            RadComboBox ddlValorDelOperador1 = (insertItem.FindControl("ddlValorDelOperador1") as RadComboBox);
            RadTextBox txtValorDelOperador1 = (insertItem.FindControl("txtValorDelOperador1") as RadTextBox);
            //----------------------------------------------------------------------------------------
            insertItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Condiciones = MyDataTTBusinessRules.Condiciones;
            objCondiciones = new TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions();

            GetValuesFromControlsOperaciones(int.Parse(ddlTipoDeOperador1F.SelectedValue), int.Parse(ddlTipoDeOperador2F.SelectedValue),
                ddlValorDelOperador1, txtValorDelOperador1, ddlValorDelOperador2, txtValorDelOperador2,
                int.Parse(ddlCondicionF.SelectedValue), int.Parse(ddlOperadorDeCondicionF.SelectedValue),
                ref objCondiciones);
            objCondiciones.DBOperation = TTEnums.TTenumDBOperation.Insert;
            objCondiciones.idFolio = Condiciones.Count;
            Condiciones.Add(objCondiciones);
            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }

        BindGridsWithSessionData();
    }

    protected void GetValuesFromControlsOperaciones(int value1, int value2,
            RadComboBox comboBox1, RadTextBox textBox1,
            RadComboBox comboBox2, RadTextBox textBox2,
            int? condicion, int condicionOperador,
            ref TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions objCondiciones)
    {
        objCondiciones.Condicion = condicion;
        objCondiciones.CondicionOperador = condicionOperador;

        objCondiciones.Tipo_Operador1 = value1;
        switch ((TTenumBusinessRules_ConditionTypeOperator1)value1)
        {
            case TTenumBusinessRules_ConditionTypeOperator1.Field:
            case TTenumBusinessRules_ConditionTypeOperator1.Global:
                objCondiciones.Valor_Operador1 = comboBox1.SelectedValue;
                break;
            case TTenumBusinessRules_ConditionTypeOperator1.QuerySQL:
                objCondiciones.Valor_Operador1 = textBox1.Text;
                break;
            case TTenumBusinessRules_ConditionTypeOperator1.Temporal:
            case TTenumBusinessRules_ConditionTypeOperator1.None:
            default:
                objCondiciones.Valor_Operador1 = String.Empty;
                break;
        }
        //--------------------------------------------------------------------------------------        
        objCondiciones.Tipo_Operador2 = value2;
        switch ((TTenumBusinessRules_ConditionTypeOperator2)value2)
        {
            case TTenumBusinessRules_ConditionTypeOperator2.Field:
            case TTenumBusinessRules_ConditionTypeOperator2.Global:
                objCondiciones.Valor_Operador2 = comboBox2.SelectedValue;
                break;
            case TTenumBusinessRules_ConditionTypeOperator2.Method:
            case TTenumBusinessRules_ConditionTypeOperator2.QuerySQL:
            case TTenumBusinessRules_ConditionTypeOperator2.Value:
                objCondiciones.Valor_Operador2 = textBox2.Text;
                break;
            case TTenumBusinessRules_ConditionTypeOperator2.Temporal:
            case TTenumBusinessRules_ConditionTypeOperator2.JavaScript:
            case TTenumBusinessRules_ConditionTypeOperator2.None:
            default:
                objCondiciones.Valor_Operador2 = String.Empty;
                break;
        }
    }

    protected void ddlTipoDeOperador1F_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlTipoDeOperador1F = sender as DropDownList;
        Control ddlParent = ddlTipoDeOperador1F.Parent.Parent;

        Label lblValorDelOperador1 = (ddlParent.FindControl("lblValorDelOperador1") as Label);
        RadComboBox ddlValorDelOperador1 = (ddlParent.FindControl("ddlValorDelOperador1") as RadComboBox);
        RadTextBox txtValorDelOperador1 = (ddlParent.FindControl("txtValorDelOperador1") as RadTextBox);

        SetControlsValorOperador1(int.Parse(ddlTipoDeOperador1F.SelectedValue), ref ddlValorDelOperador1, ref txtValorDelOperador1, ref lblValorDelOperador1);
    }

    protected void ddlTipoDeOperador2F_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlTipoDeOperador2F = sender as DropDownList;
        Control ddlParent = ddlTipoDeOperador2F.Parent.Parent;

        Label lblValorDelOperador2 = (ddlParent.FindControl("lblValorDelOperador2") as Label);
        RadComboBox ddlValorDelOperador2 = (ddlParent.FindControl("ddlValorDelOperador2") as RadComboBox);
        RadTextBox txtValorDelOperador2 = (ddlParent.FindControl("txtValorDelOperador2") as RadTextBox);

        SetControlsValorOperador2(int.Parse(ddlTipoDeOperador2F.SelectedValue), ref ddlValorDelOperador2, ref txtValorDelOperador2, ref lblValorDelOperador2);
    }

    protected void SetControlsValorOperador1(int value, ref RadComboBox comboBox, ref RadTextBox textBox, ref Label label)
    {
        comboBox.Items.Clear();
        textBox.Text = String.Empty;
        label.Text = String.Empty;

        switch ((TTenumBusinessRules_ConditionTypeOperator1)value)
        {
            case TTenumBusinessRules_ConditionTypeOperator1.Field:
                ToggleVisibilityComboText(ref comboBox, true, ref textBox);
                label.Text = "Select the Field:";

                DataTable dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

                break;
            case TTenumBusinessRules_ConditionTypeOperator1.Global:
                ToggleVisibilityComboText(ref comboBox, true, ref textBox);

                label.Text = "Select Global Variable:";
                comboBox.DataValueField = "";
                comboBox.DataTextField = "";
                comboBox.DataSource = Session.Keys;
                comboBox.DataBind();

                break;
            case TTenumBusinessRules_ConditionTypeOperator1.QuerySQL:
                ToggleVisibilityComboText(ref comboBox, false, ref textBox);
                label.Text = "Set Field Value:";
                break;
            case TTenumBusinessRules_ConditionTypeOperator1.Temporal:
            case TTenumBusinessRules_ConditionTypeOperator1.None:
            default:
                comboBox.Visible = false;
                textBox.Visible = false;
                label.Text = "N/A";
                break;
        }
    }

    protected void SetControlsValorOperador2(int value, ref RadComboBox comboBox, ref RadTextBox textBox, ref Label label)
    {
        comboBox.Items.Clear();
        textBox.Text = String.Empty;
        label.Text = String.Empty;

        switch ((TTenumBusinessRules_ConditionTypeOperator2)value)
        {
            case TTenumBusinessRules_ConditionTypeOperator2.Field:
                ToggleVisibilityComboText(ref comboBox, true, ref textBox);

                label.Text = "Select the Field:";
                DataTable dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                break;
            case TTenumBusinessRules_ConditionTypeOperator2.Global:
                ToggleVisibilityComboText(ref comboBox, true, ref textBox);
                label.Text = "Select Global Variable:";

                comboBox.DataValueField = "";
                comboBox.DataTextField = "";
                comboBox.DataSource = Session.Keys;
                comboBox.DataBind();

                break;
            case TTenumBusinessRules_ConditionTypeOperator2.Method:
            case TTenumBusinessRules_ConditionTypeOperator2.QuerySQL:
            case TTenumBusinessRules_ConditionTypeOperator2.Value:
                ToggleVisibilityComboText(ref comboBox, false, ref textBox);
                label.Text = "Set Field Value:";
                break;
            case TTenumBusinessRules_ConditionTypeOperator2.Temporal:
            case TTenumBusinessRules_ConditionTypeOperator2.JavaScript:
            case TTenumBusinessRules_ConditionTypeOperator2.None:
            default:
                comboBox.Visible = false;
                textBox.Visible = false;
                label.Text = "N/A";
                break;
        }
    }

    protected void ToggleVisibilityComboText(ref RadComboBox comboBox, bool isComboBoxVisible, ref RadTextBox textBox)
    {
        comboBox.Visible = isComboBoxVisible;
        textBox.Visible = !isComboBoxVisible;
    }

    protected void grvAcciones_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        /** idBusinessRules, idFolio, Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5 **/
        object Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5;

        if (e.Item is Telerik.Web.UI.GridDataItem && !e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridDataItem item = (Telerik.Web.UI.GridDataItem)e.Item;

            //object idBusinessRules = item.GetDataKeyValue("Tipo_Operador1");
            //object idFolio = item.GetDataKeyValue("Valor_Operador1").ToString();
            Tipo_Accion = item.GetDataKeyValue("Tipo_Accion") as int?;
            Tipo_Accion_Resultado = item.GetDataKeyValue("Tipo_Accion_Resultado");
            Parametro1 = item.GetDataKeyValue("Parametro1");
            Parametro2 = item.GetDataKeyValue("Parametro2");
            Parametro3 = item.GetDataKeyValue("Parametro3");
            Parametro4 = item.GetDataKeyValue("Parametro4");
            Parametro5 = item.GetDataKeyValue("Parametro5");

            DropDownList ddlTipoDeAccion = (item.FindControl("ddlTipoDeAccion") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (item.FindControl("ddlTipoDeAccionDeResultado") as DropDownList);
            Button cmdParametro1 = (item.FindControl("cmdParametro1") as Button);
            Button cmdParametro2 = (item.FindControl("cmdParametro2") as Button);
            Button cmdParametro3 = (item.FindControl("cmdParametro3") as Button);
            Button cmdParametro4 = (item.FindControl("cmdParametro4") as Button);
            Button cmdParametro5 = (item.FindControl("cmdParametro5") as Button);

            ddlTipoDeAccion.SelectedValue = Tipo_Accion.ToString();
            ddlTipoDeAccionDeResultado.SelectedValue = Tipo_Accion_Resultado.ToString();

            TTBusinessRules_ActionTypeCS.objectBussinessTTBusinessRules_ActionType objAction = new TTBusinessRules_ActionTypeCS.objectBussinessTTBusinessRules_ActionType();
            objAction.GetByKey((int?)Tipo_Accion, true);

            ConfigActionParameter(ref cmdParametro1, Parametro1, objAction, 0);

            if (objAction.Parametros.Length > 1)
                ConfigActionParameter(ref cmdParametro2, Parametro2, objAction, 1);

            if (objAction.Parametros.Length > 2)
                ConfigActionParameter(ref cmdParametro3, Parametro3, objAction, 2);

            if (objAction.Parametros.Length > 3)
                ConfigActionParameter(ref cmdParametro4, Parametro4, objAction, 3);

            if (objAction.Parametros.Length > 4)
                ConfigActionParameter(ref cmdParametro5, Parametro5, objAction, 4);
            //-------------------------------------------------------------------------------------------            
        }
        else if (e.Item is Telerik.Web.UI.GridDataInsertItem && e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridDataInsertItem editedItem = (Telerik.Web.UI.GridDataInsertItem)e.Item;

            DropDownList ddlTipoDeAccion = (editedItem.FindControl("ddlTipoDeAccionF") as DropDownList);

            ddlTipoDeAccionF_SelectedIndexChanged(ddlTipoDeAccion, new EventArgs());
        }
        else if (e.Item is Telerik.Web.UI.GridEditableItem && e.Item.IsInEditMode)
        {
            Telerik.Web.UI.GridEditableItem editedItem = (Telerik.Web.UI.GridEditableItem)e.Item;

            //object idBusinessRules = item.GetDataKeyValue("Tipo_Operador1");
            //object idFolio = item.GetDataKeyValue("Valor_Operador1").ToString();
            Tipo_Accion = editedItem.GetDataKeyValue("Tipo_Accion") as int?;
            Tipo_Accion_Resultado = editedItem.GetDataKeyValue("Tipo_Accion_Resultado");
            Parametro1 = editedItem.GetDataKeyValue("Parametro1");
            Parametro2 = editedItem.GetDataKeyValue("Parametro2");
            Parametro3 = editedItem.GetDataKeyValue("Parametro3");
            Parametro4 = editedItem.GetDataKeyValue("Parametro4");
            Parametro5 = editedItem.GetDataKeyValue("Parametro5");

            DropDownList ddlTipoDeAccion = (editedItem.FindControl("ddlTipoDeAccionF") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (editedItem.FindControl("ddlTipoDeAccionDeResultadoF") as DropDownList);
            //-----------------------------------------------------------------------------------
            Label lblParametro1 = (editedItem.FindControl("lblParametro1") as Label);
            RadComboBox ddlParametro1 = (editedItem.FindControl("ddlParametro1") as RadComboBox);
            RadTextBox txtParametro1 = (editedItem.FindControl("txtParametro1") as RadTextBox);
            //-----------------------------------------------------------------------------------
            Label lblParametro2 = (editedItem.FindControl("lblParametro2") as Label);
            RadComboBox ddlParametro2 = (editedItem.FindControl("ddlParametro2") as RadComboBox);
            RadTextBox txtParametro2 = (editedItem.FindControl("txtParametro2") as RadTextBox);
            //-----------------------------------------------------------------------------------
            Label lblParametro3 = (editedItem.FindControl("lblParametro3") as Label);
            RadComboBox ddlParametro3 = (editedItem.FindControl("ddlParametro3") as RadComboBox);
            RadTextBox txtParametro3 = (editedItem.FindControl("txtParametro3") as RadTextBox);
            //-----------------------------------------------------------------------------------
            Label lblParametro4 = (editedItem.FindControl("lblParametro4") as Label);
            RadComboBox ddlParametro4 = (editedItem.FindControl("ddlParametro4") as RadComboBox);
            RadTextBox txtParametro4 = (editedItem.FindControl("txtParametro4") as RadTextBox);
            //-----------------------------------------------------------------------------------
            Label lblParametro5 = (editedItem.FindControl("lblParametro5") as Label);
            RadComboBox ddlParametro5 = (editedItem.FindControl("ddlParametro5") as RadComboBox);
            RadTextBox txtParametro5 = (editedItem.FindControl("txtParametro5") as RadTextBox);

            ddlTipoDeAccion.SelectedValue = Tipo_Accion.ToString();
            ddlTipoDeAccionDeResultado.SelectedValue = Tipo_Accion_Resultado.ToString();

            ddlTipoDeAccionF_SelectedIndexChanged(ddlTipoDeAccion, new EventArgs());

            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 10/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL
            switch ((int)Tipo_Accion)
            {
                case 26:

                    if (ddlParametro1.Items.Count > 0)
                    {
                        ddlParametro1.SelectedValue = Parametro1.ToString();
                        ddlParametro1_SelectedIndexChanged(ddlParametro1, new EventArgs());
                    }
                    if (ddlParametro2.Items.Count > 0)
                    {
                        ddlParametro2.SelectedValue = Parametro2.ToString();
                    }
                    if (ddlParametro3.Items.Count > 0)
                    {
                        int position = Convert.ToInt32(Parametro3.ToString().Substring(Parametro3.ToString().LastIndexOf(" ") + 1));
                        ddlParametro3.SelectedValue = position.ToString();
                    }
                    if (ddlParametro4.Items.Count > 0)
                    {
                        if (Parametro4.ToString() == "Before")
                            ddlParametro4.SelectedValue = "0";
                        else ddlParametro4.SelectedValue = "1";
                    }
                    if (ddlParametro5.Items.Count > 0)
                    {
                        ddlParametro5.SelectedValue = Parametro5.ToString();
                    }

                    txtParametro1.Text = Parametro1.ToString();
                    txtParametro2.Text = Parametro2.ToString();
                    txtParametro3.Text = Parametro3.ToString();
                    txtParametro4.Text = Parametro4.ToString();
                    txtParametro5.Text = Parametro5.ToString();

                    break;
                /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
                /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
                #region
                //case 28:
                //    if (ddlParametro1.Items.Count > 0)
                //    {
                //        ddlParametro1.SelectedValue = Parametro1.ToString();
                //        ddlParametro1_SelectedIndexChanged(ddlParametro1, new EventArgs());
                //    }
                //    if (ddlParametro2.Items.Count > 0)
                //    {
                //        ddlParametro2.SelectedValue = Parametro2.ToString();
                //    }
                //    if (ddlParametro3.Items.Count > 0)
                //    {
                //        ddlParametro3.SelectedValue = Parametro3.ToString();
                //    }
                //    if (ddlParametro4.Items.Count > 0)
                //    {
                //        ddlParametro4.SelectedValue = Parametro4.ToString();
                //    }
                //    if (ddlParametro5.Items.Count > 0)
                //    {
                //        ddlParametro5.SelectedValue = Parametro5.ToString();
                //    }

                //    txtParametro1.Text = Parametro1.ToString();
                //    txtParametro2.Text = Parametro2.ToString();
                //    txtParametro3.Text = Parametro3.ToString();
                //    txtParametro4.Text = Parametro4.ToString();
                //    txtParametro5.Text = Parametro5.ToString();

                //    break;
                #endregion
                default:
                    if (ddlParametro1.Items.Count > 0)
                        ddlParametro1.SelectedValue = Parametro1.ToString();
                    if (ddlParametro2.Items.Count > 0)
                        ddlParametro2.SelectedValue = Parametro2.ToString();
                    if (ddlParametro3.Items.Count > 0)
                        ddlParametro3.SelectedValue = Parametro3.ToString();
                    if (ddlParametro4.Items.Count > 0)
                        ddlParametro4.SelectedValue = Parametro4.ToString();
                    if (ddlParametro5.Items.Count > 0)
                        ddlParametro5.SelectedValue = Parametro5.ToString();

                    txtParametro1.Text = Parametro1.ToString();
                    txtParametro2.Text = Parametro2.ToString();
                    txtParametro3.Text = Parametro3.ToString();
                    txtParametro4.Text = Parametro4.ToString();
                    txtParametro5.Text = Parametro5.ToString();
                    break;
            }
            #endregion


        }
    }

    protected void grvAcciones_True_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        /** idBusinessRules, idFolio, Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5 **/
        object idBusinessRules, idFolio;
        
        if (e.CommandName == "Update")
        {
            Telerik.Web.UI.GridEditableItem editedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = editedItem.EditManager;

            idBusinessRules = editedItem.GetDataKeyValue("idBusinessRules");
            idFolio = editedItem.GetDataKeyValue("idFolio");

            DropDownList ddlTipoDeAccion = (editedItem.FindControl("ddlTipoDeAccionF") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (editedItem.FindControl("ddlTipoDeAccionDeResultadoF") as DropDownList);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro1 = (editedItem.FindControl("ddlParametro1") as RadComboBox);
            RadTextBox txtParametro1 = (editedItem.FindControl("txtParametro1") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro2 = (editedItem.FindControl("ddlParametro2") as RadComboBox);
            RadTextBox txtParametro2 = (editedItem.FindControl("txtParametro2") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro3 = (editedItem.FindControl("ddlParametro3") as RadComboBox);
            RadTextBox txtParametro3 = (editedItem.FindControl("txtParametro3") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro4 = (editedItem.FindControl("ddlParametro4") as RadComboBox);
            RadTextBox txtParametro4 = (editedItem.FindControl("txtParametro4") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro5 = (editedItem.FindControl("ddlParametro5") as RadComboBox);
            RadTextBox txtParametro5 = (editedItem.FindControl("txtParametro5") as RadTextBox);
            //-----------------------------------------------------------------------------------
            editedItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_True = MyDataTTBusinessRules.Acciones_True;
            objAcciones_True = Acciones_True.Find(_objAcciones => _objAcciones.idFolio == (idFolio as int?) && _objAcciones.idBusinessRules == (idBusinessRules as int?));

            GatValuesFromParametersControls(int.Parse(ddlTipoDeAccion.SelectedValue), int.Parse(ddlTipoDeAccionDeResultado.SelectedValue),
                ddlParametro1, txtParametro1, ddlParametro2, txtParametro2, ddlParametro3, txtParametro3,
                ddlParametro4, txtParametro4, ddlParametro5, txtParametro5,
                ref objAcciones_True);
            objAcciones_True.DBOperation = TTEnums.TTenumDBOperation.Update;
            Session["TTBusinessRules"] = MyDataTTBusinessRules;


        }
        else if (e.CommandName == "Delete")
        {
            Telerik.Web.UI.GridDataItem deletedItem = e.Item as Telerik.Web.UI.GridDataItem;

            idBusinessRules = deletedItem.GetDataKeyValue("idBusinessRules");
            idFolio = deletedItem.GetDataKeyValue("idFolio");
            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_True = MyDataTTBusinessRules.Acciones_True;

            objAcciones_True = Acciones_True.Find(_objAcciones => _objAcciones.idFolio == (idFolio as int?) && _objAcciones.idBusinessRules == (idBusinessRules as int?));
            /* Si la Regla de Negocio es nueva entonces borra la accion del arreglo*/
            if (idBusinessRules == null)
                Acciones_True.Remove(objAcciones_True);
            /* Sino marca el registro para que se borre en base de datos*/
            else
                objAcciones_True.DBOperation = TTEnums.TTenumDBOperation.Delete;

            Session["TTBusinessRules"] = MyDataTTBusinessRules;

        }
        else if (e.CommandName == "PerformInsert")
        {
            Telerik.Web.UI.GridEditableItem insertedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = insertedItem.EditManager;

            DropDownList ddlTipoDeAccion = (insertedItem.FindControl("ddlTipoDeAccionF") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (insertedItem.FindControl("ddlTipoDeAccionDeResultadoF") as DropDownList);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro1 = (insertedItem.FindControl("ddlParametro1") as RadComboBox);
            RadTextBox txtParametro1 = (insertedItem.FindControl("txtParametro1") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro2 = (insertedItem.FindControl("ddlParametro2") as RadComboBox);
            RadTextBox txtParametro2 = (insertedItem.FindControl("txtParametro2") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro3 = (insertedItem.FindControl("ddlParametro3") as RadComboBox);
            RadTextBox txtParametro3 = (insertedItem.FindControl("txtParametro3") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro4 = (insertedItem.FindControl("ddlParametro4") as RadComboBox);
            RadTextBox txtParametro4 = (insertedItem.FindControl("txtParametro4") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro5 = (insertedItem.FindControl("ddlParametro5") as RadComboBox);
            RadTextBox txtParametro5 = (insertedItem.FindControl("txtParametro5") as RadTextBox);
            //-----------------------------------------------------------------------------------
            insertedItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_True = MyDataTTBusinessRules.Acciones_True;
            objAcciones_True = new TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue();

            GatValuesFromParametersControls(int.Parse(ddlTipoDeAccion.SelectedValue), int.Parse(ddlTipoDeAccionDeResultado.SelectedValue),
                ddlParametro1, txtParametro1, ddlParametro2, txtParametro2, ddlParametro3, txtParametro3,
                ddlParametro4, txtParametro4, ddlParametro5, txtParametro5,
                ref objAcciones_True);
            objAcciones_True.DBOperation = TTEnums.TTenumDBOperation.Insert;
            objAcciones_True.idFolio = Acciones_True.Count;
            Acciones_True.Add(objAcciones_True);
            Session["TTBusinessRules"] = MyDataTTBusinessRules;

        }
        BindGridsWithSessionData();
    }

    protected void grvAcciones_False_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        /** idBusinessRules, idFolio, Tipo_Accion, Tipo_Accion_Resultado, Parametro1, Parametro2, Parametro3, Parametro4, Parametro5 **/
        object idBusinessRules, idFolio;

        if (e.CommandName == "Update")
        {
            Telerik.Web.UI.GridEditableItem editedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = editedItem.EditManager;

            idBusinessRules = editedItem.GetDataKeyValue("idBusinessRules");
            idFolio = editedItem.GetDataKeyValue("idFolio");

            DropDownList ddlTipoDeAccion = (editedItem.FindControl("ddlTipoDeAccionF") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (editedItem.FindControl("ddlTipoDeAccionDeResultadoF") as DropDownList);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro1 = (editedItem.FindControl("ddlParametro1") as RadComboBox);
            RadTextBox txtParametro1 = (editedItem.FindControl("txtParametro1") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro2 = (editedItem.FindControl("ddlParametro2") as RadComboBox);
            RadTextBox txtParametro2 = (editedItem.FindControl("txtParametro2") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro3 = (editedItem.FindControl("ddlParametro3") as RadComboBox);
            RadTextBox txtParametro3 = (editedItem.FindControl("txtParametro3") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro4 = (editedItem.FindControl("ddlParametro4") as RadComboBox);
            RadTextBox txtParametro4 = (editedItem.FindControl("txtParametro4") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro5 = (editedItem.FindControl("ddlParametro5") as RadComboBox);
            RadTextBox txtParametro5 = (editedItem.FindControl("txtParametro5") as RadTextBox);
            //-----------------------------------------------------------------------------------
            editedItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_False = MyDataTTBusinessRules.Acciones_False;
            objAcciones_False = Acciones_False.Find(_objAcciones => _objAcciones.idFolio == (idFolio as int?) && _objAcciones.idBusinessRules == (idBusinessRules as int?));

            GatValuesFromParametersControlsFalse(int.Parse(ddlTipoDeAccion.SelectedValue), int.Parse(ddlTipoDeAccionDeResultado.SelectedValue),
                ddlParametro1, txtParametro1, ddlParametro2, txtParametro2, ddlParametro3, txtParametro3,
                ddlParametro4, txtParametro4, ddlParametro5, txtParametro5,
                ref objAcciones_False);
            objAcciones_False.DBOperation = TTEnums.TTenumDBOperation.Update;
            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        else if (e.CommandName == "Delete")
        {
            Telerik.Web.UI.GridDataItem deletedItem = e.Item as Telerik.Web.UI.GridDataItem;

            idBusinessRules = deletedItem.GetDataKeyValue("idBusinessRules");
            idFolio = deletedItem.GetDataKeyValue("idFolio");

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_False = MyDataTTBusinessRules.Acciones_False;

            objAcciones_False = Acciones_False.Find(_objAcciones => _objAcciones.idFolio == (idFolio as int?) && _objAcciones.idBusinessRules == (idBusinessRules as int?));
            /* Si la Regla de Negocio es nueva entonces borra la accion del arreglo*/
            if (idBusinessRules == null)
                Acciones_False.Remove(objAcciones_False);
            /* Sino marca el registro para que se borre en base de datos*/
            else
                objAcciones_False.DBOperation = TTEnums.TTenumDBOperation.Delete;

            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        else if (e.CommandName == "PerformInsert")
        {
            Telerik.Web.UI.GridEditableItem insertedItem = e.Item as Telerik.Web.UI.GridEditableItem;
            Telerik.Web.UI.GridEditManager editMan = insertedItem.EditManager;

            DropDownList ddlTipoDeAccion = (insertedItem.FindControl("ddlTipoDeAccionF") as DropDownList);
            DropDownList ddlTipoDeAccionDeResultado = (insertedItem.FindControl("ddlTipoDeAccionDeResultadoF") as DropDownList);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro1 = (insertedItem.FindControl("ddlParametro1") as RadComboBox);
            RadTextBox txtParametro1 = (insertedItem.FindControl("txtParametro1") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro2 = (insertedItem.FindControl("ddlParametro2") as RadComboBox);
            RadTextBox txtParametro2 = (insertedItem.FindControl("txtParametro2") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro3 = (insertedItem.FindControl("ddlParametro3") as RadComboBox);
            RadTextBox txtParametro3 = (insertedItem.FindControl("txtParametro3") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro4 = (insertedItem.FindControl("ddlParametro4") as RadComboBox);
            RadTextBox txtParametro4 = (insertedItem.FindControl("txtParametro4") as RadTextBox);
            //-----------------------------------------------------------------------------------
            RadComboBox ddlParametro5 = (insertedItem.FindControl("ddlParametro5") as RadComboBox);
            RadTextBox txtParametro5 = (insertedItem.FindControl("txtParametro5") as RadTextBox);
            //-----------------------------------------------------------------------------------
            insertedItem.Edit = false;

            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            Acciones_False = MyDataTTBusinessRules.Acciones_False;
            objAcciones_False = new TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse();

            GatValuesFromParametersControlsFalse(int.Parse(ddlTipoDeAccion.SelectedValue), int.Parse(ddlTipoDeAccionDeResultado.SelectedValue),
                ddlParametro1, txtParametro1, ddlParametro2, txtParametro2, ddlParametro3, txtParametro3,
                ddlParametro4, txtParametro4, ddlParametro5, txtParametro5,
                ref objAcciones_False);
            objAcciones_False.DBOperation = TTEnums.TTenumDBOperation.Insert;
            objAcciones_False.idFolio = Acciones_False.Count;
            Acciones_False.Add(objAcciones_False);
            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        BindGridsWithSessionData();
    }

    protected void GatValuesFromParametersControls(
        int tipoDeAccion, int tipoDeAccionDeResultado,
        RadComboBox comboBox1, RadTextBox textBox1,
        RadComboBox comboBox2, RadTextBox textBox2,
        RadComboBox comboBox3, RadTextBox textBox3,
        RadComboBox comboBox4, RadTextBox textBox4,
        RadComboBox comboBox5, RadTextBox textBox5,
        ref TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue objAcciones)
    {
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        object Tipo_Accion = tipoDeAccion;
        objAcciones.Tipo_Accion = tipoDeAccion;
        objAcciones.Tipo_Accion_Resultado = tipoDeAccionDeResultado;
        objAcciones.Parametro1 = objAcciones.Parametro2 = objAcciones.Parametro3 = objAcciones.Parametro4 = objAcciones.Parametro5 = String.Empty;
        //------------------ Fill Controls -----------------------------------------------
        switch ((TTenumBusinessRules_ActionType)tipoDeAccion)
        {
            case TTenumBusinessRules_ActionType.Disabled:
            case TTenumBusinessRules_ActionType.Enabled:
            case TTenumBusinessRules_ActionType.NotObligatory:
            case TTenumBusinessRules_ActionType.Invisible:
            case TTenumBusinessRules_ActionType.Obligatory:
            case TTenumBusinessRules_ActionType.Visible:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            case TTenumBusinessRules_ActionType.DisabledCarpet:
            case TTenumBusinessRules_ActionType.EnabledCarpet:
            case TTenumBusinessRules_ActionType.EjecutaQuery:
            case TTenumBusinessRules_ActionType.ShowMsj:
                objAcciones.Parametro1 = textBox1.Text;
                break;
            case TTenumBusinessRules_ActionType.FiltrarCombo:
            case TTenumBusinessRules_ActionType.SetValueFromQuery:
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
            case TTenumBusinessRules_ActionType.SwitchLabel:
            case TTenumBusinessRules_ActionType.AsignarValor:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                break;
            #endregion
            case TTenumBusinessRules_ActionType.SendMailtoField:
            case TTenumBusinessRules_ActionType.SendMailtoGroup:
            case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                objAcciones.Parametro4 = textBox4.Text;
                objAcciones.Parametro5 = textBox5.Text;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                objAcciones.Parametro4 = textBox4.Text;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoAccount:
            case TTenumBusinessRules_ActionType.SendMailtoList:
            case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoQueryList:
            case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                objAcciones.Parametro4 = textBox4.Text;
                objAcciones.Parametro5 = textBox5.Text;
                break;
            case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = comboBox2.SelectedValue;
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
            /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
            /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterComboInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
            /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                objAcciones.Parametro4 = textBox4.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
            /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
            /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = comboBox2.SelectedValue;
                objAcciones.Parametro3 = textBox3.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterListFromQuery:
                objAcciones.Parametro1 = textBox1.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Ocultar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.HideColumnInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Mostrar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer ReadOnly un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeReadOnly:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Writable un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeWritable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Visible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion

        }
    }

    protected void GatValuesFromParametersControlsFalse(
        int tipoDeAccion, int tipoDeAccionDeResultado,
        RadComboBox comboBox1, RadTextBox textBox1,
        RadComboBox comboBox2, RadTextBox textBox2,
        RadComboBox comboBox3, RadTextBox textBox3,
        RadComboBox comboBox4, RadTextBox textBox4,
        RadComboBox comboBox5, RadTextBox textBox5,
        ref TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse objAcciones)
    {
        objAcciones.Tipo_Accion = tipoDeAccion;
        objAcciones.Tipo_Accion_Resultado = tipoDeAccionDeResultado;
        objAcciones.Parametro1 = objAcciones.Parametro2 = objAcciones.Parametro3 = objAcciones.Parametro4 = objAcciones.Parametro5 = String.Empty;
        //------------------ Fill Controls -----------------------------------------------
        switch ((TTenumBusinessRules_ActionType)tipoDeAccion)
        {
            case TTenumBusinessRules_ActionType.Disabled:
            case TTenumBusinessRules_ActionType.Enabled:
            case TTenumBusinessRules_ActionType.NotObligatory:
            case TTenumBusinessRules_ActionType.Invisible:
            case TTenumBusinessRules_ActionType.Obligatory:
            case TTenumBusinessRules_ActionType.Visible:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            case TTenumBusinessRules_ActionType.DisabledCarpet:
            case TTenumBusinessRules_ActionType.EnabledCarpet:
            case TTenumBusinessRules_ActionType.EjecutaQuery:
            case TTenumBusinessRules_ActionType.ShowMsj:
                objAcciones.Parametro1 = textBox1.Text;
                break;
            case TTenumBusinessRules_ActionType.FiltrarCombo:
            case TTenumBusinessRules_ActionType.SetValueFromQuery:
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
            case TTenumBusinessRules_ActionType.SwitchLabel: 
            case TTenumBusinessRules_ActionType.AsignarValor:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                break;
            #endregion
            case TTenumBusinessRules_ActionType.SendMailtoField:
            case TTenumBusinessRules_ActionType.SendMailtoGroup:
            case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                objAcciones.Parametro4 = textBox4.Text;
                objAcciones.Parametro5 = textBox5.Text;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                objAcciones.Parametro4 = textBox4.Text;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoAccount:
            case TTenumBusinessRules_ActionType.SendMailtoList:
            case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoQueryList:
            case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                objAcciones.Parametro4 = textBox4.Text;
                objAcciones.Parametro5 = textBox5.Text;
                break;
            case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = comboBox2.SelectedValue;
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
            /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
            /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterComboInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
            /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = textBox3.Text;
                objAcciones.Parametro4 = textBox4.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
            /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                objAcciones.Parametro2 = textBox2.Text;
                objAcciones.Parametro3 = comboBox3.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
            /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:
                objAcciones.Parametro1 = textBox1.Text;
                objAcciones.Parametro2 = comboBox2.SelectedValue;
                objAcciones.Parametro3 = textBox3.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterListFromQuery:
                objAcciones.Parametro1 = textBox1.Text;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Ocultar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.HideColumnInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Mostrar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer ReadOnly un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeReadOnly:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Writable un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeWritable:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Visible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:
                objAcciones.Parametro1 = comboBox1.SelectedValue;
                break;
            #endregion
        }
    }

    private void ConfigActionParameter(ref Button cmdParametro, object Parametro, TTBusinessRules_ActionTypeCS.objectBussinessTTBusinessRules_ActionType objAction, int objActionIndex)
    {
        switch (((TTenumBusinessRules_ActionParameterType)objAction.Parametros[objActionIndex].Tipo_Parametro.Value))
        {
            case TTenumBusinessRules_ActionParameterType.DatoID:
                TTMetadata.Metadata mymeta = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myData = mymeta.GetDatosDT(MyFunctions.FormatNumberNull(Parametro.ToString().Substring(Parametro.ToString().LastIndexOf(".") + 1)).Value);
                cmdParametro.Text = myData.NombreTabla + "." + myData.Nombre;
                break;
            case TTenumBusinessRules_ActionParameterType.GrupoFuncional:
                TTGrupoFuncionalCS.objectBussinessTTGrupoFuncional objGroup = new TTGrupoFuncionalCS.objectBussinessTTGrupoFuncional();
                objGroup.GetByKey((Parametro as int?), true);
                cmdParametro.Text = objGroup.Nombre;
                break;
            case TTenumBusinessRules_ActionParameterType.SQLQuery:
            case TTenumBusinessRules_ActionParameterType.SQLStore:
            case TTenumBusinessRules_ActionParameterType.Carpeta:
            case TTenumBusinessRules_ActionParameterType.Grupo:
            case TTenumBusinessRules_ActionParameterType.Texto:
            case TTenumBusinessRules_ActionParameterType.TextNoDecoding:
                cmdParametro.Text = Parametro.ToString();
                break;
        }
    }

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
    /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
    #region IDCODMANUAL:
    protected void ddlParametro1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TTDataLayerCS.BD db = null;
        String DtRoot = null;
        SqlCommand com = null;
        DataTable dt = null;
        String sValue = null;

        RadComboBox comboBox1 = (RadComboBox)sender;

        GridTableCell t = (GridTableCell)comboBox1.Parent;

        DropDownList ddlTipoDeAccion = null;

        if (comboBox1.NamingContainer is GridDataInsertItem)
        {
            GridDataInsertItem x = ((GridDataInsertItem)comboBox1.NamingContainer);
            ddlTipoDeAccion = (DropDownList)x.FindControl("ddlTipoDeAccionF");
        }
        else if (comboBox1.NamingContainer is GridDataItem)
        {
            GridDataItem x = ((GridDataItem)comboBox1.NamingContainer);
            ddlTipoDeAccion = (DropDownList)x.FindControl("ddlTipoDeAccionF");
        }

        object Tipo_Accion = int.Parse(ddlTipoDeAccion.SelectedValue);

        switch ((int)Tipo_Accion)
        {
            case 26:

                RadComboBox comboBox3 = null;

                if (comboBox1.NamingContainer is GridDataInsertItem)
                {
                    GridDataInsertItem x = ((GridDataInsertItem)comboBox1.NamingContainer);
                    comboBox3 = (RadComboBox)x.FindControl("ddlParametro3");
                }
                else if (comboBox1.NamingContainer is GridDataItem)
                {
                    GridDataItem x = ((GridDataItem)comboBox1.NamingContainer);
                    comboBox3 = (RadComboBox)x.FindControl("ddlParametro3");
                }

                db = new TTDataLayerCS.BD();

                DtRoot = comboBox1.SelectedValue.Substring(comboBox1.SelectedValue.LastIndexOf(".") + 1);

                com = new SqlCommand("SELECT * FROM TTMetadata WHERE DTID = " + DtRoot);

                dt = db.Consulta(com).Tables[0];

                sValue = "";

                if (dt.Rows.Count > 0) sValue = dt.Rows[0][3].ToString();

                if (comboBox3 != null)
                {
                    comboBox3.Items.Clear();

                    for (int i = 0; i < sValue.Length; i++)
                    {
                        comboBox3.Items.Add(new RadComboBoxItem("Character " + i, i.ToString()));
                    }
                }
                
                break;
            //case 28:

            //    RadComboBox comboBox2 = null;

            //    if (comboBox1.NamingContainer is GridDataInsertItem)
            //    {
            //        GridDataInsertItem x = ((GridDataInsertItem)comboBox1.NamingContainer);
            //        comboBox2 = (RadComboBox)x.FindControl("ddlParametro2");
            //    }
            //    else if (comboBox1.NamingContainer is GridDataItem)
            //    {
            //        GridDataItem x = ((GridDataItem)comboBox1.NamingContainer);
            //        comboBox2 = (RadComboBox)x.FindControl("ddlParametro2");
            //    }

            //    DtRoot = comboBox1.SelectedValue.Substring(comboBox1.SelectedValue.LastIndexOf(".") + 1);

            //    if (brFunctions.isMultiRow(DtRoot) && comboBox2 != null)
            //    {
            //        db = new TTDataLayerCS.BD();

            //        com = new SqlCommand("SELECT O.* FROM TTMetadata AS O INNER JOIN TTMetadata AS P ON P.DTID = " + DtRoot + " AND O.DNTID = P.DependienteTabla");

            //        dt = db.Consulta(com).Tables[0];

            //        sValue = "";

            //        if (dt.Rows.Count > 0) sValue = dt.Rows[0][3].ToString();

            //        comboBox2.Items.Clear();

            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            comboBox2.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
            //        }
            //    }
            //    else
            //    {
            //        comboBox2.Items.Clear();
            //    }

            //    break;

            default:
                break;
        }
        

    }
    #endregion

    protected void ddlTipoDeAccionF_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlTipoDeAccionF = sender as DropDownList;
        Control ddlParent = ddlTipoDeAccionF.Parent.Parent;

        //-----------------------------------------------------------------------------------
        Label lblParametro1 = (ddlParent.FindControl("lblParametro1") as Label);
        RadComboBox ddlParametro1 = (ddlParent.FindControl("ddlParametro1") as RadComboBox);
        RadTextBox txtParametro1 = (ddlParent.FindControl("txtParametro1") as RadTextBox);
        //-----------------------------------------------------------------------------------
        Label lblParametro2 = (ddlParent.FindControl("lblParametro2") as Label);
        RadComboBox ddlParametro2 = (ddlParent.FindControl("ddlParametro2") as RadComboBox);
        RadTextBox txtParametro2 = (ddlParent.FindControl("txtParametro2") as RadTextBox);
        //-----------------------------------------------------------------------------------
        Label lblParametro3 = (ddlParent.FindControl("lblParametro3") as Label);
        RadComboBox ddlParametro3 = (ddlParent.FindControl("ddlParametro3") as RadComboBox);
        RadTextBox txtParametro3 = (ddlParent.FindControl("txtParametro3") as RadTextBox);
        //-----------------------------------------------------------------------------------
        Label lblParametro4 = (ddlParent.FindControl("lblParametro4") as Label);
        RadComboBox ddlParametro4 = (ddlParent.FindControl("ddlParametro4") as RadComboBox);
        RadTextBox txtParametro4 = (ddlParent.FindControl("txtParametro4") as RadTextBox);
        //-----------------------------------------------------------------------------------
        Label lblParametro5 = (ddlParent.FindControl("lblParametro5") as Label);
        RadComboBox ddlParametro5 = (ddlParent.FindControl("ddlParametro5") as RadComboBox);
        RadTextBox txtParametro5 = (ddlParent.FindControl("txtParametro5") as RadTextBox);

        SetParameterControlsByTipoDeAccion(int.Parse(ddlTipoDeAccionF.SelectedValue),
            ref ddlParametro1, ref txtParametro1, ref lblParametro1,
            ref ddlParametro2, ref txtParametro2, ref lblParametro2,
            ref ddlParametro3, ref txtParametro3, ref lblParametro3,
            ref ddlParametro4, ref txtParametro4, ref lblParametro4,
            ref ddlParametro5, ref txtParametro5, ref lblParametro5);

        //SetControlsValorOperador1(int.Parse(ddlTipoDeOperador1F.SelectedValue), ref ddlValorDelOperador1, ref txtValorDelOperador1, ref lblValorDelOperador1);
    }

    protected void SetParameterControlsByTipoDeAccion(int value,
        ref RadComboBox comboBox1, ref RadTextBox textBox1, ref Label label1,
        ref RadComboBox comboBox2, ref RadTextBox textBox2, ref Label label2,
        ref RadComboBox comboBox3, ref RadTextBox textBox3, ref Label label3,
        ref RadComboBox comboBox4, ref RadTextBox textBox4, ref Label label4,
        ref RadComboBox comboBox5, ref RadTextBox textBox5, ref Label label5)
    {
        DataTable dt;
        TTDataLayerCS.BD db;
        String DtRoot;
        SqlCommand com;
        String sValue;
        StringBuilder sqlQuery;
        DataSet folders;
        
        comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear();
        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = String.Empty;
        label1.Text = label2.Text = label3.Text = label4.Text = label5.Text = String.Empty;

        //------------------ Set Controls Visibility ---------------------------------------
        switch ((TTenumBusinessRules_ActionType)value)
        {
            case TTenumBusinessRules_ActionType.Disabled:
            case TTenumBusinessRules_ActionType.Enabled:
            case TTenumBusinessRules_ActionType.NotObligatory:
            case TTenumBusinessRules_ActionType.Invisible:
            case TTenumBusinessRules_ActionType.Obligatory:
            case TTenumBusinessRules_ActionType.Visible:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;

                break;
            case TTenumBusinessRules_ActionType.DisabledCarpet:
            case TTenumBusinessRules_ActionType.EnabledCarpet:
            case TTenumBusinessRules_ActionType.EjecutaQuery:
            case TTenumBusinessRules_ActionType.ShowMsj:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;

                break;
            case TTenumBusinessRules_ActionType.FiltrarCombo:
            case TTenumBusinessRules_ActionType.SetValueFromQuery:
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano, FECHA: 25/Noviembre/2013*/
            case TTenumBusinessRules_ActionType.SwitchLabel: 
            case TTenumBusinessRules_ActionType.AsignarValor:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = false; label4.Visible = false; label5.Visible = false;

                break;
            case TTenumBusinessRules_ActionType.SendMailtoField:
            case TTenumBusinessRules_ActionType.SendMailtoGroup:
            case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = true; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = true; textBox5.Visible = true;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = true; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = true; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = false;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccount:
            case TTenumBusinessRules_ActionType.SendMailtoList:
            case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoQueryList:
            case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = false;
                break;
            case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = false; label5.Visible = false;

                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
            /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
            /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterComboInMultiRow:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
            /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
            /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = true; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = true; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
            /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:
                comboBox1.Visible = false; comboBox2.Visible = true; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = false; textBox3.Visible = true; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.FilterListFromQuery:
                comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = true; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Ocultar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.HideColumnInMultiRow:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Mostrar una columna de un multirenglón.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer ReadOnly un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeReadOnly:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Writable un Control.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeWritable:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Visible una Pestaña.*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:
                comboBox1.Visible = true; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false; comboBox5.Visible = false;
                textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
                label1.Visible = true; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                break;
            #endregion
        }

        //------------------ Fill Controls -----------------------------------------------
        switch ((TTenumBusinessRules_ActionType)value)
        {
            case TTenumBusinessRules_ActionType.Disabled:
            case TTenumBusinessRules_ActionType.Enabled:
            case TTenumBusinessRules_ActionType.NotObligatory:
            case TTenumBusinessRules_ActionType.Invisible:
            case TTenumBusinessRules_ActionType.Obligatory:
            case TTenumBusinessRules_ActionType.Visible:
                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                break;
            case TTenumBusinessRules_ActionType.FiltrarCombo:
                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                break;
            case TTenumBusinessRules_ActionType.SetValueFromQuery:
            case TTenumBusinessRules_ActionType.AsignarValor:
            /*TODO: Llena el control correspondiente al Parametro 1 IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013 */
            case TTenumBusinessRules_ActionType.SwitchLabel:
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
            /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
            case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                break;
            case TTenumBusinessRules_ActionType.SendMailtoField:
            case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox3.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                break;
            case TTenumBusinessRules_ActionType.SendMailtoGroup:
            case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                db = new TTDataLayerCS.BD();
                com = new SqlCommand("sp_selallTTGrupoFuncional");
                com.CommandType = CommandType.StoredProcedure;
                dt = db.Consulta(com).Tables[0];
                foreach (DataRow dr in dt.Rows)
                    comboBox3.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["idGrupo"].ToString()));
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccount:
            case TTenumBusinessRules_ActionType.SendMailtoList:
            case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoQueryList:
            case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
            case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
            case TTenumBusinessRules_ActionType.DisabledCarpet:
            case TTenumBusinessRules_ActionType.EnabledCarpet:
            case TTenumBusinessRules_ActionType.EjecutaQuery:
            case TTenumBusinessRules_ActionType.ShowMsj:
                break;
            case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                //------------------------------ Controles--------------------------------
                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                //------------------------------ Variables de session -------------------
                comboBox2.DataValueField = "";
                comboBox2.DataTextField = "";
                comboBox2.DataSource = Session.Keys;
                comboBox2.DataBind();
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel: /*TODO:Concatenar un Valor en una Etiqueta, IDCODEMANUAL:, RESPONSABLE: Salvador García Serrano, FECHA: 04/Diciembre/2013 */

                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

                //db = new TTDataLayerCS.BD();

                //DtRoot = comboBox1.SelectedValue.Substring(comboBox1.SelectedValue.LastIndexOf(".") + 1);

                //com = new SqlCommand("SELECT * FROM TTMetadata WHERE DTID = " + DtRoot);

                //dt = db.Consulta(com).Tables[0];

                //sValue = "";

                //if (dt.Rows.Count > 0) sValue = dt.Rows[0][3].ToString();

                //for (int i = 0; i < sValue.Length; i++)
                //{
                //    comboBox3.Items.Add(new RadComboBoxItem("Character " + i, i.ToString()));
                //}

                //comboBox4.Items.Clear();

                //comboBox4.Items.Add(new RadComboBoxItem("Before", "0"));

                //comboBox4.Items.Add(new RadComboBoxItem("After", "1"));

                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
            /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
            #region
            case TTenumBusinessRules_ActionType.FilterComboInMultiRow:

                dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

                foreach (DataRow dr in dt.Rows)
                    comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                
                //DtRoot = comboBox1.SelectedValue.Substring(comboBox1.SelectedValue.LastIndexOf(".") + 1);

                //if (brFunctions.isMultiRow(DtRoot))
                //{
                //    db = new TTDataLayerCS.BD();

                //    com = new SqlCommand("SELECT O.* FROM TTMetadata AS O INNER JOIN TTMetadata AS P ON P.DTID = " + DtRoot + " AND O.DNTID = P.DependienteTabla");

                //    dt = db.Consulta(com).Tables[0];

                //    sValue = "";

                //    if (dt.Rows.Count > 0) sValue = dt.Rows[0][3].ToString();

                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        comboBox2.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));
                //    }
                //}

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
            /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
            #region
            case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
            /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               comboBox3.Items.Add(new RadComboBoxItem("Sum", "0"));
               comboBox3.Items.Add(new RadComboBoxItem("Avg", "1"));
               comboBox3.Items.Add(new RadComboBoxItem("Max", "2"));
               comboBox3.Items.Add(new RadComboBoxItem("Min", "3"));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
            /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
            #region
            case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:

               comboBox2.Items.Add(new RadComboBoxItem("SQL Query", "0"));
               comboBox2.Items.Add(new RadComboBoxItem("Value", "1"));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            #region
            case TTenumBusinessRules_ActionType.FilterListFromQuery:

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Ocultar una columna de un multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.HideColumnInMultiRow:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Mostrar una columna de un multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer ReadOnly un Control.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeReadOnly:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Writable un Control.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeWritable:

               dt = TTBusinessRulesCS.objectBussinessTTBusinessRules.FillBusinessRulesDTs_x_Process(int.Parse(ddlProceso.SelectedValue));

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Nombre"].ToString(), dr["DNTID"].ToString() + "." + dr["DTID"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
               sqlQuery = new StringBuilder();
               sqlQuery.Append("SELECT DISTINCT A.Descripcion AS Folder ");
               sqlQuery.Append("FROM TTDominio A INNER JOIN TTMetadata B ON B.DNTID = A.RelacionDNT ");
               sqlQuery.Append("WHERE B.ProcesoId = ");
               sqlQuery.Append(ddlProceso.SelectedValue);

               folders = Funcion.RegresaDataSet(sqlQuery.ToString());

               dt = folders.Tables[0];

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Folder"].ToString(), dr["Folder"].ToString()));

               break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:

               sqlQuery = new StringBuilder();
               sqlQuery.Append("SELECT DISTINCT A.Descripcion AS Folder ");
               sqlQuery.Append("FROM TTDominio A INNER JOIN TTMetadata B ON B.DNTID = A.RelacionDNT ");
               sqlQuery.Append("WHERE B.ProcesoId = ");
               sqlQuery.Append(ddlProceso.SelectedValue);

               folders = Funcion.RegresaDataSet(sqlQuery.ToString());

               dt = folders.Tables[0];

               foreach (DataRow dr in dt.Rows)
                   comboBox1.Items.Add(new RadComboBoxItem(dr["Folder"].ToString(), dr["Folder"].ToString()));

               break;
            #endregion
        }
        // --------------------- Set Labels ------------------------------------------
        switch ((TTenumBusinessRules_ActionType)value)
        {
            case TTenumBusinessRules_ActionType.Disabled:
            case TTenumBusinessRules_ActionType.Enabled:
            case TTenumBusinessRules_ActionType.NotObligatory:
            case TTenumBusinessRules_ActionType.Invisible:
            case TTenumBusinessRules_ActionType.Obligatory:
            case TTenumBusinessRules_ActionType.Visible:
                label1.Text = "Fields";
                break;
            case TTenumBusinessRules_ActionType.DisabledCarpet:
            case TTenumBusinessRules_ActionType.EnabledCarpet:
                label1.Text = "Folder Name";
                break;
            case TTenumBusinessRules_ActionType.EjecutaQuery:
                label1.Text = "Query";
                break;
            case TTenumBusinessRules_ActionType.ShowMsj:
                label1.Text = "Message";
                break;
            case TTenumBusinessRules_ActionType.FiltrarCombo:
                label1.Text = "Fields";
                label2.Text = "Condition";
                break;
            case TTenumBusinessRules_ActionType.SetValueFromQuery:
                label1.Text = "Fields";
                label2.Text = "Query";
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
            /*OBJETIVO: Asigna el valor a los Labels de los Parámetros*/
            #region
            case TTenumBusinessRules_ActionType.SwitchLabel:
                label1.Text = "Fields";
                label2.Text = "Query";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
            /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
            #region IDCODMANUAL:
            case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel:
                label1.Text = "Field";
                label2.Text = "Command";
                label3.Text = "Position";
                break;
            #endregion
            case TTenumBusinessRules_ActionType.AsignarValor:
                label1.Text = "Fields";
                label2.Text = "Value";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoField:
                label1.Text = "Configurations";
                label2.Text = "From (Email)";
                label3.Text = "Fields";
                label4.Text = "Subject";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "Fields";
                label4.Text = "Number of Template";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoGroup:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "Functional Groups";
                label4.Text = "Subject";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "Functional Groups";
                label4.Text = "Number of Template";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccount:
            case TTenumBusinessRules_ActionType.SendMailtoList:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "To (Email)";
                label4.Text = "Subject";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "To (Email)";
                label4.Text = "Number of Template";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "To (Email)";
                label4.Text = "Subject";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoQueryList:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "To (Query)";
                label4.Text = "Subject";
                label5.Text = "Body";
                break;
            case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
                label1.Text = "Number of Configuration Servers";
                label2.Text = "From (Email)";
                label3.Text = "To (Emails Query)";
                label4.Text = "Subject";
                label5.Text = "Number of Template";
                break;
            case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                label1.Text = "Fields";
                label2.Text = "Global Variable";
                break;
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
            /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
            #region
            case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                label1.Text = "Fields";
                label2.Text = "Variable Name";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
            /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
            #region
            case TTenumBusinessRules_ActionType.FilterComboInMultiRow:
                label1.Text = "Field";
                label2.Text = "Command";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
            /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
            #region
            case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:
                label1.Text = "MultiRow Field";
                label2.Text = "SELECT";
                label3.Text = "WHERE";
                label4.Text = "ORDER";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
            /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:
                label1.Text = "MultiRow Column";
                label2.Text = "Destination Field";
                label3.Text = "Function";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
            /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
            #region
            case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:
                label1.Text = "Variable Name";
                label2.Text = "Source";
                label3.Text = "Command";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
            /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
            #region
            case TTenumBusinessRules_ActionType.FilterListFromQuery:
                label1.Text = "Query (WHERE)";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Ocultar una columna de un multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.HideColumnInMultiRow:
                label1.Text = "Column";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
            /*OBJETIVO: Mostrar una columna de un multirenglón.*/
            #region
            case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:
                label1.Text = "Column";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer ReadOnly un Control.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeReadOnly:
                label1.Text = "Field";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Writable un Control.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeWritable:
                label1.Text = "Field";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Invisible una Pestaña.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
                label1.Text = "Folder";
                break;
            #endregion
            /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
            /*OBJETIVO: Hacer Visible una Pestaña.*/
            #region
            case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:
                label1.Text = "Folder";
                break;
            #endregion
        }
    }

    private Boolean Save()
    {
        TTenumBusinessRules_ActionResultType[] mybusResult = null;
        MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;

        switch (MyDataTTBusinessRules.DBOperation)
        {
            case TTEnums.TTenumDBOperation.Update:
                //mybusResult = myBusinessRule.Comparation(iProcess, TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave);
                break;
            case TTEnums.TTenumDBOperation.Insert:
                //mybusResult = myBusinessRule.Comparation(iProcess, TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave);
                break;
        }
        if (mybusResult != null)
            foreach (TTenumBusinessRules_ActionResultType myRes in mybusResult)
                if (myRes == TTenumBusinessRules_ActionResultType.Break)
                    return false;

        //----------------------------------------- Validaciones -----------------------------------------------
        if (ddlProceso.SelectedValue != "")
            MyDataTTBusinessRules.IdProceso = MyFunctions.FormatNumberNull(ddlProceso.SelectedValue);
        else
            MyDataTTBusinessRules.IdProceso = null;
        MyDataTTBusinessRules.Nombre = txtNombre.Text;
        MyDataTTBusinessRules.Fecha_de_Alta = MyFunctions.FormatDateNull(dtFecha_de_Alta.SelectedDate);
        MyDataTTBusinessRules.Alcance = MyFunctions.FormatNumberNull(cbAlcance.SelectedValue);

        //---------------------------------------Evento Operacion --------------------------------------------
        int itemCount = 0;
        foreach (ListItem objLst in lstOperacion.Items)
            if (objLst.Selected)
                itemCount++;
        MyDataTTBusinessRules.Operacion = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion[itemCount];
        itemCount = 0;
        foreach (ListItem objLst in lstOperacion.Items)
            if (objLst.Selected)
            {
                MyDataTTBusinessRules.Operacion[itemCount] = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion();
                MyDataTTBusinessRules.Operacion[itemCount].idOperacion = MyFunctions.FormatNumberNull(objLst.Value);
                itemCount++;
            }

        //---------------------------------------Evento Proceso --------------------------------------------
        itemCount = 0;
        foreach (ListItem objLst in lstEvento_Proceso.Items)
            if (objLst.Selected)
                itemCount++;
        MyDataTTBusinessRules.Evento_Proceso = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent[itemCount];
        itemCount = 0;
        foreach (ListItem objLst in lstEvento_Proceso.Items)
            if (objLst.Selected)
            {
                MyDataTTBusinessRules.Evento_Proceso[itemCount] = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent();
                MyDataTTBusinessRules.Evento_Proceso[itemCount].idEvent = MyFunctions.FormatNumberNull(objLst.Value);
                itemCount++;
            }
        //---------------------------------------Evento Campo --------------------------------------------
        itemCount = 0;
        foreach (ListItem objLst in lstEvento_Campo.Items)
            if (objLst.Selected)
                itemCount++;
        MyDataTTBusinessRules.Evento_Campo = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent[itemCount];
        itemCount = 0;
        foreach (ListItem objLst in lstEvento_Campo.Items)
            if (objLst.Selected)
            {
                MyDataTTBusinessRules.Evento_Campo[itemCount] = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent();
                MyDataTTBusinessRules.Evento_Campo[itemCount].idEvent = MyFunctions.FormatNumberNull(objLst.Value);
                itemCount++;
            }
        /* --------------------------------------- Condiciones -------------------------------------------- */
        /* -------------------------Las condiciones y Acciones se guardan en los eventos del grid --------- */
        /* ------------------------------------------------------------------------------------------------ */

        if (!ValidaDataToSave())
            return false;
        if (MyDataTTBusinessRules.DBOperation == TTEnums.TTenumDBOperation.Insert)
            if (!ValidaDataDuplication())
                return false;
        if (!ValidaDataObligatorios())
            return false;


        if (MyDataTTBusinessRules.DBOperation == TTEnums.TTenumDBOperation.Insert)
            MyDataTTBusinessRules.Insert(MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
        else if (MyDataTTBusinessRules.DBOperation == TTEnums.TTenumDBOperation.Update)
            MyDataTTBusinessRules.Update(MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));

        txtidBusinessRule.Text = MyDataTTBusinessRules.idBusinessRule.ToString().TrimEnd(' ');
        Result = MyDataTTBusinessRules.idBusinessRule;
        if (cmdClose.Text.ToUpper() != "CANCELAR")
        { }// MessageBox.Show(MyTraductor.getMessage(13), MyTraductor.getMessage(14), MessageBoxButtons.OK, MessageBoxIcon.Information);

        MyDataTTBusinessRules.DBOperation = TTEnums.TTenumDBOperation.Update;
        Session["TTBusinessRules"] = MyDataTTBusinessRules;
        return true;
    }

    private bool ValidaDataToSave()
    {
        //Validaciones
        string sMsg = "";
        if (MyDataTTBusinessRules.IdProceso != null)
        {
            TTProcesoCS.objectBussinessTTProceso MyDataTTProcesoTemp = new TTProcesoCS.objectBussinessTTProceso();
            if (!MyDataTTProcesoTemp.ValidaExistencia(MyDataTTBusinessRules.IdProceso))
            {
                sMsg = sMsg + "El Campo Proceso no existe\n";
            }
        }
        if (sMsg != "")
        {
            //MessageBox.Show(MyTraductor.getMessage(15) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7), MyTraductor.getMessage(8), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ShowAlert(MyTraductor.getMessage(15) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7));
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool ValidaDataObligatorios()
    {
        string sMsg = "";
        TTMetadata.MetadataDatos MyMetaData;

        if (sMsg != "")
        {
            //MessageBox.Show(MyTraductor.getMessage(16) + ":\n " + sMsg + "\n" + MyTraductor.getMessage(7), MyTraductor.getMessage(8), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ShowAlert(MyTraductor.getMessage(16) + ":\n " + sMsg + "\n" + MyTraductor.getMessage(7));
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool ValidaDataDuplication()
    {
        //Validaciones
        string sMsg = "";
        if (MyDataTTBusinessRules.idBusinessRule == -1)
        {
            if (MyDataTTBusinessRules.ValidaExistencia(MyDataTTBusinessRules.idBusinessRule))
            {
                sMsg = sMsg + MyTraductor.getMessage(84) + "\n";
            }
        }

        if (sMsg != "")
        {
            //MessageBox.Show(MyTraductor.getMessage(6) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7), MyTraductor.getMessage(8), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ShowAlert(MyTraductor.getMessage(6) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7));
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            ShowAlert("Datos Guardados Correctamente.");
            Response.Redirect("TTBusinessRules_Lista.aspx");
        }
        else
        {
            ShowAlert("Se genero un error al guardar");
        }
    }
    protected void cmdSaveCopy_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            ShowAlert("Datos Guardados Correctamente.");
            MyDataTTBusinessRules = Session["TTBusinessRules"] as TTBusinessRulesCS.objectBussinessTTBusinessRules;
            MyDataTTBusinessRules.idBusinessRule = null;
            MyDataTTBusinessRules.DBOperation = TTEnums.TTenumDBOperation.Insert;
            this.txtidBusinessRule.Text = "AUTO";
            Session["TTBusinessRules"] = MyDataTTBusinessRules;
        }
        else
        {
            ShowAlert("Se genero un error al guardar");
        }
    }

    protected void cmdSaveNew_Click(object sender, EventArgs e)
    {
        if (Save())
        {
            ShowAlert("Datos Guardados Correctamente.");
            New();
        }
        else
        {
            ShowAlert("Se genero un error al guardar");
        }
    }

    protected void rtsBusinessRules_TabClick(object sender, RadTabStripEventArgs e)
    {
        //TTProcesoCS.objectBussinessTTProceso MyDataTTProcesoTemp = new TTProcesoCS.objectBussinessTTProceso();
        //int? localIdProceso = ddlProceso.SelectedValue == String.Empty ? 0 : int.Parse(ddlProceso.SelectedValue);
        //if (!MyDataTTProcesoTemp.ValidaExistencia(localIdProceso) && e.Tab.Index > 0)
        //{
        //    lblMessage.Text = "Para continuar debe especificar el Proceso.";
        //    rtsBusinessRules.SelectedIndex = 0;
        //    RadMultiPage1.SelectedIndex = 0;
        //}
        if (ddlProceso.SelectedValue == string.Empty)
        {
            ShowAlert("Para continuar debe especificar el Proceso.");
            rtsBusinessRules.SelectedIndex = 0;
            RadMultiPage1.SelectedIndex = 0;
        }
    }
    protected void cmdOperacion_Click(object sender, EventArgs e)
    {
        Button cmdButton = (sender as Button);
        switch (cmdButton.CommandArgument)
        {
            case "SelectAll":
                foreach (ListItem lstObj in lstOperacion.Items)
                    lstObj.Selected = true;
                break;
            case "ClearAll":
            default:
                foreach (ListItem lstObj in lstOperacion.Items)
                    lstObj.Selected = false;
                break;
        }
    }
    protected void cmdEvento_Proceso_Click(object sender, EventArgs e)
    {
        Button cmdButton = (sender as Button);
        switch (cmdButton.CommandArgument)
        {
            case "SelectAll":
                foreach (ListItem lstObj in lstEvento_Proceso.Items)
                    lstObj.Selected = true;
                break;
            case "ClearAll":
            default:
                foreach (ListItem lstObj in lstEvento_Proceso.Items)
                    lstObj.Selected = false;
                break;
        }
    }
    protected void cmdEvento_Campo_Click(object sender, EventArgs e)
    {
        Button cmdButton = (sender as Button);
        switch (cmdButton.CommandArgument)
        {
            case "SelectAll":
                foreach (ListItem lstObj in lstEvento_Campo.Items)
                    lstObj.Selected = true;
                break;
            case "ClearAll":
            default:
                foreach (ListItem lstObj in lstEvento_Campo.Items)
                    lstObj.Selected = false;
                break;
        }
    }
    protected void cmdClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("TTBusinessRules_Lista.aspx");
    }

    protected void ddlProceso_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        string sqlQuery = @"Select Top 50         
		                        TTProceso.IdProceso As TTProceso_IdProceso,        
		                        TTProceso.Nombre As TTProceso_Nombre,        
		                        TTProceso.Pantalla As TTProceso_Pantalla   
	                        From  TTProceso          	
	                        Where TTProceso.Nombre like '%{0}%'
	                        Or TTProceso.IdProceso like '{0}%'
	                        Order by TTProceso.Nombre";

        sqlQuery = string.Format(sqlQuery, e.Text.Replace("\'", string.Empty));
        DataSet ds = Funcion.RegresaDataSet(sqlQuery);

        RadComboBox comboBox = (RadComboBox)sender;
        //comboBox.DataSource = ds;
        //comboBox.DataBind();
        comboBox.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            //item.Text = row["TTProceso_Nombre"].ToString();
            //item.Value = row["TTProceso_IdProceso"].ToString();
            //comboBox.Items.Add(item);

            item.Text = row["TTProceso_IdProceso"].ToString();
            item.Value = row["TTProceso_IdProceso"].ToString();

            item.Attributes.Add("TTProceso_Nombre", row["TTProceso_Nombre"].ToString());
            item.Attributes.Add("TTProceso_IdProceso", row["TTProceso_IdProceso"].ToString());

            comboBox.Items.Add(item);
            item.DataBind();
        }
    }

}










