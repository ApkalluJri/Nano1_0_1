/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTBitacoraSQL
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

public partial class TTBitacoraSQL_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSTTBitacoraSQL.objectBussinessTTBitacoraSQL myTTBitacoraSQL = new WSTTBitacoraSQL.objectBussinessTTBitacoraSQL();
    private WSTTBitacoraSQL.GlobalData userData;
    public int iProcess = 6402;
    private String sDNTNombre = "TTBitacoraSQL";
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

        		//CEFechaHora.Format = System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString();


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
                txtFolio.Enabled=false;
        ddlIdUsuario.Enabled=false;
        TTbcIdUsuario.ImgButton.Visible = false;

        txtTipoSQL.Enabled=false;
//       txtFechaHora.Enabled=false;
        txtComputerName.Enabled=false;
        txtServerName.Enabled=false;
        txtDatabaseName.Enabled=false;
        txtSystemName.Enabled=false;
        txtSystemVersion.Enabled=false;
        txtWindowsVersion.Enabled=false;
        txtCommandSQL.Enabled=false;
        txtFolioSQL.Enabled=false;
        ddlProcesoID.Enabled=false;
        TTbcProcesoID.ImgButton.Visible = false;


        
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
        userData = new WSTTBitacoraSQL.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTBitacoraSQL.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------
        TTbcIdUsuario.WebControl = ddlIdUsuario;
        TTbcIdUsuario.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcIdUsuario.GetControlDataSetFunctionWithString = myTTBitacoraSQL.FillDataIdUsuario;
        TTbcIdUsuario.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcProcesoID.WebControl = ddlProcesoID;
        TTbcProcesoID.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcProcesoID.GetControlDataSetFunctionWithString = myTTBitacoraSQL.FillDataProcesoID;
        TTbcProcesoID.ParentWebControl = null;

        
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        refreshMultiRenglones();
        
    }
    
    private void FillDataControls()
    {
                MyFunctions.FillDataControl(ddlIdUsuario, myTTBitacoraSQL.FillDataIdUsuario(""));
        MyFunctions.FillDataControl(ddlProcesoID, myTTBitacoraSQL.FillDataProcesoID(""));

    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTBitacoraSQL.objectBussinessTTBitacoraSQL1 myDataTTBitacoraSQL = myTTBitacoraSQL.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()),true);
                if (myDataTTBitacoraSQL.Folio.HasValue)
            txtFolio.Text = myDataTTBitacoraSQL.Folio.ToString();
        if (myDataTTBitacoraSQL.IdUsuario.HasValue)
           ddlIdUsuario.SelectedValue = myDataTTBitacoraSQL.IdUsuario.Value.ToString().TrimEnd(' ');
        ddlIdUsuario_SelectedIndexChanged(ddlIdUsuario, new EventArgs());
        txtTipoSQL.Text = myDataTTBitacoraSQL.TipoSQL;
        if (myDataTTBitacoraSQL.FechaHora.HasValue)
//           txtFechaHora.Text = System.String.Format("{0:d}",myDataTTBitacoraSQL.FechaHora.Value);
        txtComputerName.Text = myDataTTBitacoraSQL.ComputerName;
        txtServerName.Text = myDataTTBitacoraSQL.ServerName;
        txtDatabaseName.Text = myDataTTBitacoraSQL.DatabaseName;
        txtSystemName.Text = myDataTTBitacoraSQL.SystemName;
        txtSystemVersion.Text = myDataTTBitacoraSQL.SystemVersion.ToString();
        txtWindowsVersion.Text = myDataTTBitacoraSQL.WindowsVersion;
        txtCommandSQL.Text = myDataTTBitacoraSQL.CommandSQL;
        txtFolioSQL.Text = myDataTTBitacoraSQL.FolioSQL;
        if (myDataTTBitacoraSQL.ProcesoID.HasValue)
           ddlProcesoID.SelectedValue = myDataTTBitacoraSQL.ProcesoID.Value.ToString().TrimEnd(' ');
        ddlProcesoID_SelectedIndexChanged(ddlProcesoID, new EventArgs());

        
        
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

                dv.RowFilter = "TTMetadata_DTID = " + 13115;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtFolio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFolio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtFolio.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtFolio.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtFolio.Text = "";
            }
        imgOblFolio.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVFolio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trFolio.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtFolio.Enabled == true)
        {
            GetFocus(txtFolio);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13116;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblIdUsuario.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblIdUsuario.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlIdUsuario.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlIdUsuario.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlIdUsuario.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlIdUsuario.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlIdUsuario.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlIdUsuario.SelectedValue = "";
	}
        trIdUsuario.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVIdUsuario.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblIdUsuario.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlIdUsuario.Enabled == true)
        {
            GetFocus(ddlIdUsuario);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13117;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblTipoSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblTipoSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtTipoSQL.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtTipoSQL.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtTipoSQL.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtTipoSQL.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtTipoSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtTipoSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtTipoSQL.Text = "";
            }
        imgOblTipoSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVTipoSQL.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trTipoSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtTipoSQL.Enabled == true)
        {
            GetFocus(txtTipoSQL);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13118;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFechaHora.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFechaHora.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //txtFechaHora.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //txtFechaHora.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //txtFechaHora.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        //{
        //txtFechaHora.Text = String.Format("{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString() + "}", DateTime.Now);
        //}
        //else
        //{
        //txtFechaHora.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //}
        //imgOblFechaHora.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //RFVFechaHora.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //trFechaHora.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //IBtnFechaHora.Enabled  = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //CEFechaHora.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //if (Foco == false && txtFechaHora.Enabled == true)
        //{
        //    GetFocus(txtFechaHora);
        //    Foco = true;
        //}
        dv.RowFilter = "TTMetadata_DTID = " + 13119;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblComputerName.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblComputerName.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtComputerName.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtComputerName.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtComputerName.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtComputerName.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtComputerName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtComputerName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtComputerName.Text = "";
            }
        imgOblComputerName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVComputerName.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trComputerName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtComputerName.Enabled == true)
        {
            GetFocus(txtComputerName);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13120;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblServerName.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblServerName.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtServerName.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtServerName.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtServerName.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtServerName.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtServerName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtServerName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtServerName.Text = "";
            }
        imgOblServerName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVServerName.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trServerName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtServerName.Enabled == true)
        {
            GetFocus(txtServerName);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13121;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblDatabaseName.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblDatabaseName.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtDatabaseName.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtDatabaseName.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtDatabaseName.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtDatabaseName.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtDatabaseName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtDatabaseName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtDatabaseName.Text = "";
            }
        imgOblDatabaseName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVDatabaseName.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trDatabaseName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtDatabaseName.Enabled == true)
        {
            GetFocus(txtDatabaseName);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13122;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblSystemName.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblSystemName.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtSystemName.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtSystemName.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtSystemName.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtSystemName.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtSystemName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtSystemName.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtSystemName.Text = "";
            }
        imgOblSystemName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVSystemName.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trSystemName.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtSystemName.Enabled == true)
        {
            GetFocus(txtSystemName);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13123;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblSystemVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblSystemVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtSystemVersion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtSystemVersion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtSystemVersion.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtSystemVersion.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtSystemVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtSystemVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtSystemVersion.Text = "";
            }
        imgOblSystemVersion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVSystemVersion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trSystemVersion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtSystemVersion.Enabled == true)
        {
            GetFocus(txtSystemVersion);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13124;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblWindowsVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblWindowsVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtWindowsVersion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtWindowsVersion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtWindowsVersion.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtWindowsVersion.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtWindowsVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtWindowsVersion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtWindowsVersion.Text = "";
            }
        imgOblWindowsVersion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVWindowsVersion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trWindowsVersion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtWindowsVersion.Enabled == true)
        {
            GetFocus(txtWindowsVersion);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13125;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblCommandSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblCommandSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtCommandSQL.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtCommandSQL.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtCommandSQL.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtCommandSQL.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtCommandSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtCommandSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtCommandSQL.Text = "";
            }
        imgOblCommandSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVCommandSQL.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trCommandSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtCommandSQL.Enabled == true)
        {
            GetFocus(txtCommandSQL);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13126;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolioSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolioSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        txtFolioSQL.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFolioSQL.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtFolioSQL.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtFolioSQL.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtFolioSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtFolioSQL.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtFolioSQL.Text = "";
            }
        imgOblFolioSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVFolioSQL.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trFolioSQL.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtFolioSQL.Enabled == true)
        {
            GetFocus(txtFolioSQL);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 13127;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblProcesoID.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblProcesoID.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        ddlProcesoID.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlProcesoID.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlProcesoID.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlProcesoID.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlProcesoID.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlProcesoID.SelectedValue = "";
	}
        trProcesoID.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVProcesoID.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblProcesoID.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlProcesoID.Enabled == true)
        {
            GetFocus(ddlProcesoID);
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
            //Session["KeyValueInserted"] = myTTBitacoraSQL.InsertWithReturnValue(userData,  MyFunctions.FormatNumberNull(ddlIdUsuario.SelectedValue), txtTipoSQL.Text, MyFunctions.FormatDateNull(txtFechaHora.Text), txtComputerName.Text, txtServerName.Text, txtDatabaseName.Text, txtSystemName.Text, MyFunctions.FormatMoneyNull(txtSystemVersion.Text), txtWindowsVersion.Text, txtCommandSQL.Text, txtFolioSQL.Text, MyFunctions.FormatNumberNull(ddlProcesoID.SelectedValue));
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
            //myTTBitacoraSQL.Update(userData,  MyFunctions.FormatNumberNull(txtFolio.Text), MyFunctions.FormatNumberNull(ddlIdUsuario.SelectedValue), txtTipoSQL.Text, MyFunctions.FormatDateNull(txtFechaHora.Text), txtComputerName.Text, txtServerName.Text, txtDatabaseName.Text, txtSystemName.Text, MyFunctions.FormatMoneyNull(txtSystemVersion.Text), txtWindowsVersion.Text, txtCommandSQL.Text, txtFolioSQL.Text, MyFunctions.FormatNumberNull(ddlProcesoID.SelectedValue));
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
            Response.Redirect("TTBitacoraSQL_Lista.aspx");
        }
    }
    protected void cmdClose_Click(object sender, ImageClickEventArgs e)
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Response.Redirect("TTBitacoraSQL_Lista.aspx");
    }
    protected void cmdClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_All();
        ConfigWithMetadata();
    }
    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }

    public void ddlIdUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    public void ddlProcesoID_SelectedIndexChanged(object sender, EventArgs e)
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





}









