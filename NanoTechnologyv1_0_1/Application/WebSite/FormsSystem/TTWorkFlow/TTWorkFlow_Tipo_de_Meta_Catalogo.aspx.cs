/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTWorkFlow_Tipo_de_Meta
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
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using App_Code.TTBusinessRules;

namespace WebForms
{	
public partial class TTWorkFlow_Tipo_de_Meta_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSTTWorkFlow_Tipo_de_Meta.objectBussinessTTWorkFlow_Tipo_de_Meta myTTWorkFlow_Tipo_de_Meta = new WSTTWorkFlow_Tipo_de_Meta.objectBussinessTTWorkFlow_Tipo_de_Meta();
    private WSTTWorkFlow_Tipo_de_Meta.GlobalData userData;
    public int iProcess = 15807;
    private String sDNTNombre = "TTWorkFlow_Tipo_de_Meta";
    private String sDNTDescripcion = "Tipo de Meta";
    private String scallBackReturnVariable = null;


#region CallBackAsincrono
    public void RaiseCallbackEvent(String eventargument)
    {
        ArrayList arr = MyFunctions.ReturnInArray(eventargument, "¬");
        string multiRenlgonName, controlId, ValueData, columName, commandName, updateKey;
        commandName = arr[0].ToString();
        if (commandName == "ShowList")
        {
            int? dtid = MyFunctions.FormatNumberNull(arr[1].ToString());
            int? process = MyFunctions.FormatNumberNull(arr[2].ToString());
            string txtBoxId = arr[3].ToString();
            string txtBoxText = arr[4].ToString();
            string codeOutput = arr[6].ToString();
            string labelText = string.Empty;
            string windowCode = string.Empty;

            if (DisplayWindow(ref txtBoxText, ref labelText, dtid.Value))
                windowCode = string.Format("ShowWindow('{0}');", GetURLByProcess(process.Value, txtBoxId));

            _Callback = labelText;
            _Callback += "<#>" + arr[5].ToString();
            _Callback += "<#>" + windowCode;
        }
        else
        {   
            multiRenlgonName = arr[1].ToString();
            controlId = arr[2].ToString();
            int? key = MyFunctions.FormatNumberNull(arr[3].ToString());
            ValueData = arr[4].ToString();
            columName = arr[5].ToString();
            Control grvControl = new Control();
            updateKey = string.Empty;
        
                        
        }
    }    
    private string _Callback;

    public String GetCallbackResult()
    {
        return _Callback;
    }
    #endregion

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
	
    }

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
            SetLanguage();
        }




        Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
        lblTitulo.Text = "Catálogo de " + sDNTNombre.Replace("_"," ");
        lblTitulo.DataBind();
    }

    protected override void OnUnload(EventArgs e)
    {
        //-----------------------------------------------------------------------------------------------------------------------
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //-----------------------------------------------------------------------------------------------------------------------
    }

    private void SetLanguage()
    {
        try
        {
            string sTitle = string.Format(MyTraductor.getMessage(41, this.Title), MyTraductor.getTextProcess(iProcess, sDNTDescripcion));
            this.Title = sTitle;
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = sTitle;

            lblGrabar.Text = MyTraductor.getMessage(42, lblGrabar.Text);
            lblGrabaryNuevo.Text = MyTraductor.getMessage(43, lblGrabaryNuevo.Text);
            lblGrabaryCopiar.Text = MyTraductor.getMessage(44, lblGrabaryCopiar.Text);
            lblLimpiar.Text = MyTraductor.getMessage(45, lblLimpiar.Text);
            lblCancelar.Text = MyTraductor.getMessage(46, lblCancelar.Text);
            lblAyuda.Text = MyTraductor.getMessage(47, lblAyuda.Text);            
        }
        catch
        { }
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
                txtClave.Enabled=false;
        txtNombre.Enabled=false;

        
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
        userData = new WSTTWorkFlow_Tipo_de_Meta.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTWorkFlow_Tipo_de_Meta.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------
        
        
        //-------------------------------------------------------------------------------------------------------------
        
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        
    }
    
    private void FillDataControls()
    {
        
    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTWorkFlow_Tipo_de_Meta.objectBussinessTTWorkFlow_Tipo_de_Meta1 myDataTTWorkFlow_Tipo_de_Meta = myTTWorkFlow_Tipo_de_Meta.GetByKey(MyFunctions.FormatNumberNull(Session["Clave"].ToString()),true);
                if (myDataTTWorkFlow_Tipo_de_Meta.Clave.HasValue)
            txtClave.Text = myDataTTWorkFlow_Tipo_de_Meta.Clave.ToString();
        txtNombre.Text = myDataTTWorkFlow_Tipo_de_Meta.Nombre;

        
        
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

        
                tabPagDatos_Generales.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Datos Generales");
        
        DataSet ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        DataView dv = new DataView(ds_controles.Tables[0]);

                dv.RowFilter = "TTMetadata_DTID = " + 35855;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblClave.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblClave.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblClave.Text = MyTraductor.getTextDTID(35855, lblClave.Text);
        txtClave.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtClave.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtClave.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtClave.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtClave.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtClave.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtClave.Text = "";
            }
        imgOblClave.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVClave.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trClave.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtClave.Enabled == true)
        {
            GetFocus(txtClave);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 35856;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblNombre.Text = MyTraductor.getTextDTID(35856, lblNombre.Text);
        txtNombre.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtNombre.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtNombre.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtNombre.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtNombre.Text = "";
            }
        imgOblNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVNombre.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtNombre.Enabled == true)
        {
            GetFocus(txtNombre);
            Foco = true;
        }

        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
        
        
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myTTWorkFlow_Tipo_de_Meta.InsertWithReturnValue(userData,  txtNombre.Text);
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
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTWorkFlow_Tipo_de_Meta.Update(userData,  MyFunctions.FormatNumberNull(txtClave.Text), txtNombre.Text);
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
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
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
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
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
            Response.Redirect("TTWorkFlow_Tipo_de_Meta_Lista.aspx");
        }
    }

  [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public static JsonResult Cancel(bool MenuVisible)
    {
        try
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (MenuVisible)
                return new JsonResult("TTWorkFlow_Tipo_de_Meta_Lista.aspx?MenuVisible=false", true, null);
            else
                return new JsonResult("TTWorkFlow_Tipo_de_Meta_Lista.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public static JsonResult Clear(bool MenuVisible)
    {
        try
        {
            HttpContext.Current.Session["Tipo_Transaccion"] = "New";
            if (MenuVisible)
                return new JsonResult("TTWorkFlow_Tipo_de_Meta_Catalogo.aspx?MenuVisible=false", true, null);
            else
                return new JsonResult("TTWorkFlow_Tipo_de_Meta_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }


    

    





}
}









