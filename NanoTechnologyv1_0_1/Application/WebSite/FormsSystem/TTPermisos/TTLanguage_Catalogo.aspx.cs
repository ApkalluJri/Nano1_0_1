/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTLanguage
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

public partial class TTLanguage_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSTTLanguage.objectBussinessTTLanguage myTTLanguage = new WSTTLanguage.objectBussinessTTLanguage();
    private WSTTLanguage.GlobalData userData;
    public int iProcess = 6834;
    private String sDNTNombre = "TTLanguage";
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

            ajaxSM.RegisterPostBackControl(buttonSubmitBandera);

        
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
            //if (fuaBandera.IsPosting)
            //this.managePostBandera();



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
                            fuaBandera.Visible = true;
                buttonSubmitBandera.Visible = true;
                labelNoResultsBandera.Visible = true;
                repeaterResultsBandera.Visible = true;
                //----------------------------------------------------
                lkbVerBandera.Visible = false;
                IbtnCambiarArchivoBandera.Visible = false;
                IbtnBorrarArchivoBandera.Visible = false;
                Session["ArchivoBandera"] = null;
               
            Session["CambiarArchivo"] = 0;
        }
    }

    protected void DisableControls()    
    {
                txtidLanguage.Enabled=false;
        txtIdioma.Enabled=false;
        txtAbreviatura.Enabled=false;

                    if (lkbVerBandera.Visible)
            {
                IbtnBorrarArchivoBandera.Visible = false;
                IbtnCambiarArchivoBandera.Visible = false;
            }
            else
            {
                fuaBandera.Enabled = false;
            }

            labelNoResultsBandera.Visible = false;
            buttonSubmitBandera.Enabled = false;
            RFVBandera.Visible = false;

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
        userData = new WSTTLanguage.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTLanguage.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------
        
        
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        refreshMultiRenglones();
        
    }
    
    private void FillDataControls()
    {
        
    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTLanguage.objectBussinessTTLanguage1 myDataTTLanguage = myTTLanguage.GetByKey(MyFunctions.FormatNumberNull(Session["idLanguage"].ToString()),true);
                if (myDataTTLanguage.idLanguage.HasValue)
            txtidLanguage.Text = myDataTTLanguage.idLanguage.ToString();
        txtIdioma.Text = myDataTTLanguage.Idioma;
               if (myDataTTLanguage.Bandera.HasValue){
            txtBandera.Text = myDataTTLanguage.Bandera.Value.ToString();

            if (Session["CambiarArchivo"] == null)
                Session["CambiarArchivo"] = "0";

            if ((Session["CambiarArchivo"].ToString() == "0"))
            {
                if (txtBandera.Text != ""){
                  TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                  SqlCommand com = new SqlCommand("Select Nombre From TTArchivos where Folio=" + txtBandera.Text);
                  com.CommandType = CommandType.Text;

                  DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0){
                      fuaBandera.Visible = false;

                      lkbVerBandera.Visible = true;
                      IbtnBorrarArchivoBandera.Visible = true;
                      IbtnCambiarArchivoBandera.Visible = true;

                      lkbVerBandera.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();	
                    }
                }
            }
        }        txtAbreviatura.Text = myDataTTLanguage.Abreviatura;

        
                    cvRadUploadBandera.Enabled = false;
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

                dv.RowFilter = "TTMetadata_DTID = " + 30060;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblidLanguage.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblidLanguage.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtidLanguage.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtidLanguage.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtidLanguage.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtidLanguage.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtidLanguage.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtidLanguage.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtidLanguage.Text = "";
            }
        imgOblidLanguage.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVidLanguage.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        tridLanguage.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtidLanguage.Enabled == true)
        {
            GetFocus(txtidLanguage);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30061;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtIdioma.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtIdioma.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtIdioma.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtIdioma.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtIdioma.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtIdioma.Text = "";
            }
        imgOblIdioma.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVIdioma.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trIdioma.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtIdioma.Enabled == true)
        {
            GetFocus(txtIdioma);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 30062;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblBandera.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblBandera.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtBandera.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtBandera.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtBandera.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        txtBandera.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        imgOblBandera.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVBandera.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trBandera.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtBandera.Enabled == true)
        {
            GetFocus(txtBandera);
            Foco = true;
        }

        dv.RowFilter = "TTMetadata_DTID = " + 30063;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAbreviatura.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAbreviatura.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtAbreviatura.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtAbreviatura.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtAbreviatura.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtAbreviatura.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtAbreviatura.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtAbreviatura.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtAbreviatura.Text = "";
            }
        imgOblAbreviatura.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVAbreviatura.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trAbreviatura.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtAbreviatura.Enabled == true)
        {
            GetFocus(txtAbreviatura);
            Foco = true;
        }

        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
        
        
        try
        {
            		GuardaArchivoBandera();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myTTLanguage.InsertWithReturnValue(userData,  txtIdioma.Text, MyFunctions.FormatNumberNull(txtBandera.Text), txtAbreviatura.Text);
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
            		GuardaArchivoBandera();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTLanguage.Update(userData,  MyFunctions.FormatNumberNull(txtidLanguage.Text), txtIdioma.Text, MyFunctions.FormatNumberNull(txtBandera.Text), txtAbreviatura.Text);
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

	private void GuardaArchivoBandera()
	{
		String NombreArchivo = "";
		if (Session["ArchivoBandera"] != null)
                                      NombreArchivo = Session["ArchivoBandera"].ToString();

		if (NombreArchivo == "" && lkbVerBandera.Text != "")
		{
			if (lkbVerBandera.Text.Trim().Length > 4)
			{
				NombreArchivo = lkbVerBandera.Text;
			}
			else
			{
				NombreArchivo = "";
			}
		}
			
		//se guarda sin archivo
		if (NombreArchivo == "" && lkbVerBandera.Text == "")
		{
			NombreArchivo = "";
		}
		
		if (File.Exists(Server.MapPath("TempFiles/") + NombreArchivo) == true)
		{
			int Folio = 0;
			if (txtBandera.Text != "")
				Folio = int.Parse(txtBandera.Text);
			else
				Folio = 0;
			//Leer archivo y guardarlo como arreglo de bytes
			byte[] Archivo = ReadFile(Server.MapPath("TempFiles/") + NombreArchivo);
			
			//Guardar o Actualiza registro en tabla TTArchivos
			TTDataLayerCS.BD db = new TTDataLayerCS.BD();			
			SqlCommand com = new SqlCommand("spInsTTArchivo");
			com.CommandType = CommandType.StoredProcedure;
			com.Parameters.Add("@Nombre", SqlDbType.NVarChar, 300).Value = NombreArchivo;
			com.Parameters.Add("@Tamano", SqlDbType.Decimal).Value = Decimal.Parse(Archivo.Length.ToString());
			com.Parameters.Add("@Pc", SqlDbType.NVarChar, 300).Value = Page.Request.UserHostAddress.ToString();
			com.Parameters.Add("@Ruta", SqlDbType.NVarChar, 1000).Value = Server.MapPath("TempFiles/");
			com.Parameters.Add("@Usuario", SqlDbType.Int).Value = Int32.Parse(Session["globalUsuarioClave"].ToString());
			com.Parameters.Add("@Proceso", SqlDbType.Int).Value = iProcess;
			com.Parameters.Add("@Operacion", SqlDbType.SmallInt).Value = 0;;
			com.Parameters.Add("@FolioProceso", SqlDbType.NVarChar, 200).Value = "";;
			com.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Parse(DateTime.Now.ToShortDateString());
			com.Parameters.Add("@Archivo", SqlDbType.Image).Value = Archivo;
			com.Parameters.Add("@Accion",SqlDbType.NVarChar,10).Value=Session["Tipo_Transaccion"].ToString();
			com.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
					 

			DataSet ds = db.Consulta(com);
			if (Session["Tipo_Transaccion"].ToString() != "Update" || Folio==0)
			{
				if (ds.Tables[0].Rows.Count > 0)
					txtBandera.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				else					
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "alert('Error al guardar el archivo en B.D');", true);				
			}
			
			File.Delete(Server.MapPath("TempFiles/") + NombreArchivo);
			
		}
	}

    public void Clear_All()
    {
                        fuaBandera.Visible = true;
                buttonSubmitBandera.Visible = true;
                labelNoResultsBandera.Visible = true;
                repeaterResultsBandera.Visible = true;
                //----------------------------------------------------
                lkbVerBandera.Visible = false;
                IbtnCambiarArchivoBandera.Visible = false;
                IbtnBorrarArchivoBandera.Visible = false;
                Session["ArchivoBandera"] = null;
               
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
    
                if (Session["Tipo_Transaccion"].ToString() == "New" && Session["ArchivoBandera"] == null)
        {
            ShowAlert("No se ha especificado el Archivo Bandera");
            return;
        }              

        
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
    
                if (Session["Tipo_Transaccion"].ToString() == "New" && Session["ArchivoBandera"] == null)
        {
            ShowAlert("No se ha especificado el Archivo Bandera");
            return;
        }              

    
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
    
                if (Session["Tipo_Transaccion"].ToString() == "New" && Session["ArchivoBandera"] == null)
        {
            ShowAlert("No se ha especificado el Archivo Bandera");
            return;
        }              

    
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
            Response.Redirect("TTLanguage_Lista.aspx");
        }
    }
    protected void cmdClose_Click(object sender, ImageClickEventArgs e)
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Response.Redirect("TTLanguage_Lista.aspx");
    }
    protected void cmdClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_All();
        ConfigWithMetadata();
    }
    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

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

   private void managePostBandera()
    {
    }


     protected void lkbVerBandera_Click(object sender, EventArgs e)
	{
		int posIni = 0;
		int posFin = 0;
		string Extencion = "";
		Session["verClick"] = 1;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + txtBandera.Text);
		com.CommandType = CommandType.Text;
		string NombreArchivo = "";
		DataSet ds = db.Consulta(com);
		if (ds.Tables[0].Rows.Count > 0)
		{
			//Crear y guardar archivo 					
			FileStream fs = File.Create(Server.MapPath("TempFiles/" + ds.Tables[0].Rows[0].ItemArray[1].ToString()));
			Byte[] Bytes = (Byte[])ds.Tables[0].Rows[0].ItemArray[0];
			NombreArchivo = ds.Tables[0].Rows[0].ItemArray[1].ToString();
			foreach (byte b in Bytes)
			{
				fs.WriteByte(b);
			}

			fs.Flush();//liberando recursos				
			fs.Close();			
		}


		posIni = lkbVerBandera.Text.IndexOf(".", 0);
		posFin = lkbVerBandera.Text.Length - 1 - (posIni - 1);
		Extencion = lkbVerBandera.Text.Substring(posIni, posFin);
		if (Extencion.ToUpper() == ".JPG" || Extencion.ToUpper() == ".GIF" || Extencion.ToUpper() == ".BMP"){
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "OpenImage('TempFiles/" + NombreArchivo + "')", true);
		}else{
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "window.open('TempFiles/" + NombreArchivo + "',null,'scrollbars=0,resizable=1,toolbar=0,menubar=0,top=0,left=0');", true);
		}
			
	}

	protected void IbtnCambiarArchivoBandera_Click(object sender, ImageClickEventArgs e)
	{
                                fuaBandera.Visible = true;
                                buttonSubmitBandera.Visible = true;
                                labelNoResultsBandera.Visible = true;
                                repeaterResultsBandera.Visible = true;
                                //-------------------------------------------------
		lkbVerBandera.Visible = false;
		Session["CambiarArchivo"] = 1;
		IbtnCambiarArchivoBandera.Visible = false;
		IbtnBorrarArchivoBandera.Visible = false;
		//Borrar archivo temporal
		File.Delete(Server.MapPath("TempFiles/" + lkbVerBandera.Text));
		//-------------------------
		cvRadUploadBandera.Enabled = true;
	}
	protected void IbtnBorrarArchivoBandera_Click(object sender, ImageClickEventArgs e)
	{
		txtBandera.Text = "";
		fuaBandera.Visible = true;
                                buttonSubmitBandera.Visible = true;
                                labelNoResultsBandera.Visible = true;
                                repeaterResultsBandera.Visible = true;
                                //-------------------------------------------------
		Session["CambiarArchivo"] = 0;
		lkbVerBandera.Visible = false;
		lkbVerBandera.Text = "";
		IbtnCambiarArchivoBandera.Visible = false;
		IbtnBorrarArchivoBandera.Visible = false;
		//-------------------------
		cvRadUploadBandera.Enabled = true;
	}
	protected void buttonSubmitBandera_Click(object sender, System.EventArgs e)
  {
      if (fuaBandera.UploadedFiles.Count > 0)
      {
          repeaterResultsBandera.DataSource = fuaBandera.UploadedFiles;
          repeaterResultsBandera.DataBind();
          labelNoResultsBandera.Visible = false;
          repeaterResultsBandera.Visible = true;

          foreach (Telerik.Web.UI.UploadedFile validFile in fuaBandera.UploadedFiles)
          {
              Session["ArchivoBandera"] = validFile.GetName();
              RFVBandera.Enabled = false;
          }
      }
      else
      {
          labelNoResultsBandera.Visible = true;
          repeaterResultsBandera.Visible = false;
      }

  }
  protected void fuaBandera_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
  {
      int counter = 1;

      Telerik.Web.UI.UploadedFile file = e.UploadedFile;

      string targetFolder = Server.MapPath(fuaBandera.TargetFolder);

      string targetFileName = Path.Combine(targetFolder,
          file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

      while (System.IO.File.Exists(targetFileName))
      {
          counter++;
          targetFileName = Path.Combine(targetFolder,
              file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
      }

      file.SaveAs(targetFileName);
  }

}









