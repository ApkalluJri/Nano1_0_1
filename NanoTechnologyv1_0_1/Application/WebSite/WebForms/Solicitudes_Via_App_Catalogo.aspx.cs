/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo Solicitudes_Via_App
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
using System.Reflection;
using Telerik.Web.UI;
using System.Linq;

namespace WebForms
{	
public partial class Solicitudes_Via_App_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSSolicitudes_Via_App.objectBussinessSolicitudes_Via_App mySolicitudes_Via_App = new WSSolicitudes_Via_App.objectBussinessSolicitudes_Via_App();
    private WSSolicitudes_Via_App.GlobalData userData;
    public int iProcess = 29990;
    private String sDNTNombre = "Solicitudes_Via_App";
    private String sDNTDescripcion = "Solicitudes Vía App";
    private String scallBackReturnVariable = null;
    public class ComboInfo
    {
        public string ComboId { get; set; }
        public string ComboName { get; set; }
    }
    public List<ComboInfo> ComboInformation { get; set; }


    public Control TabControlsAux; 

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
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", @" setHeightTabs(); ", true); 
        ClientScriptManager cm = Page.ClientScript;
        String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context", "ReceiveErrorData", true); 
        String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);
        //Session.Remove("dsGrid");
        //Session.Remove("GridState");

        System.Web.UI.ScriptManager ajaxSM = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ScriptManager1");
        if (ajaxSM != null)
            ajaxSM.AsyncPostBackTimeout = 3600;

        
        
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");

        if (Page.Request["add"] != null)
        {
            if (Page.Request["add"].ToString() == "1")
            {
                Session["Tipo_Transaccion"] = "New";
            }
        }

        TabControlsAux = Funcion.FindControlRecursive(this, "TabControls"); 
        if (!Page.IsPostBack)
        {
                    txtFecha_de_Registro.Culture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureMX"].ToString(), true); 
            txtFecha_de_Registro.DateInput.DisplayDateFormat = System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString();

        
	
            Session["CambiarArchivo"] = 0;
            RevisaLoadArchivo();
            ConfigWithMetadata();
            FillDataControls();
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                New();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
                CargaInformacionPorEstado();
            }
            if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                Modification();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
                CargaInformacionPorEstado();
            }
            if (Session["Tipo_Transaccion"].ToString() == "Consult")
            {
                Modification();
                DisableControls();
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            }
            CargaInformacionCampos();
            SetLanguage();

        }





        if (!string.IsNullOrEmpty(Request["__EVENTTARGET"]) && Request["__EVENTTARGET"].Contains("RadDate") && !string.IsNullOrEmpty(Request["__EVENTARGUMENT"]))
        {
            string controlRoot = Request["__EVENTTARGET"].Replace("RadDate$", string.Empty);
            Control control = null;

            controlRoot.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(delegate(string item)
            {
                if (control != null)
                    control = control.FindControl(item);
                else
                    control = FindControl(item);
            });

                string Fecha = "";
                if (System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString().ToUpper() == "MM/DD/YYYY")
                    Fecha = Request["__EVENTARGUMENT"].ToString().Substring(3, 2) + "/" + Request["__EVENTARGUMENT"].ToString().Substring(0, 2) + "/" + Request["__EVENTARGUMENT"].ToString().Substring(6, 4);


            ((RadDatePicker)control).SelectedDate = DateTime.Parse(Fecha);
            UpdatePanel1.Update();
        }

        if (Session["idProcesoPopup"] != null)
        {
            if (Session["idProcesoPopup"].ToString() != "")
            {
                string Llave = Session["LlavePopup"].ToString();
                string idProcesoPopup = Session["idProcesoPopup"].ToString();
                Session["idProcesoPopup"] = "";
                Session["LlavePopup"] = "";
                Session.Remove("idProcesoPopup");
                Session.Remove("LlavePopup");
                switch (idProcesoPopup)
                {

                }
            }
        }
        GC.Collect();

    }



    protected override void OnUnload(EventArgs e)
    {
        //-----------------------------------------------------------------------------------------------------------------------
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
        //-----------------------------------------------------------------------------------------------------------------------
        GC.Collect();
    }

    private void SetLanguage()
    {
        try
        {
            string sTitle = MyTraductor.getTextProcess(iProcess, Funcion.RegresaDato("select nombre from ttproceso where idproceso=" + iProcess.ToString()));
            this.Title = sTitle;
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = sTitle;
            string MensajeMostrar = MyTraductor.getMessage(203, "Mostrar");

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
                txtFolio.Enabled=false;
        ddlUsuario_que_Registra.Enabled=false;
        TTbcUsuario_que_Registra.ImgButton.Visible = false;

        txtFecha_de_Registro.Enabled=false;
        txtHora_de_Registro.Enabled=false;
        txtNombre.Enabled=false;
        txtCorreo.Enabled=false;
        ddlOpcion.Enabled=false;
        TTbcOpcion.ImgButton.Visible = false;

        txtDescripcion.Enabled=false;
        txtLada.Enabled=false;
        txtTelefono.Enabled=false;
        ddlEstatus.Enabled=false;
        TTbcEstatus.ImgButton.Visible = false;

        ddlObservatorio.Enabled=false;
        TTbcObservatorio.ImgButton.Visible = false;


            
    }

    [WebMethod]
    public static void SetSession(string value)
    {
        HttpContext.Current.Session["VerArchivo"] = value;
    }

    [WebMethod]
    public static void EnviaDato(string commandName,string multiRenlgonName, string controlId, string Skey, string ValueData, string columName)
    {
        #region Declaraciones Iniciales
        int iProcess = 29990;
        TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
        string updateKey;
	

	

        int? key = MyFunctions.FormatNumberNull(Skey);
        Control grvControl = new Control();
        updateKey = string.Empty;
        int rowIndex = !string.IsNullOrEmpty(Skey) ? int.Parse(Skey) - 1 : -1;
        #endregion


	


			

        GC.Collect();

    }

    protected void RefreshMultirenglones()
    {
        WSSolicitudes_Via_App.objectBussinessSolicitudes_Via_App1 myDataSolicitudes_Via_App = mySolicitudes_Via_App.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()), true);


    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSSolicitudes_Via_App.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSSolicitudes_Via_App.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        //if (Session["VerArchivo"] == null)
        //{
        //    if (!IsCallback)
        //    {
        //        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //    }
        //}
        //else
        //{
        //    if (Session["VerArchivo"].ToString() == "")
        //    {
        //        if (!IsCallback)
        //        {
        //            ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //        }
        //    }
        //    else
        //    {
        //        Session["VerArchivo"] = "";
        //    }
        //} 
        //-------------------------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------
        TTbcUsuario_que_Registra.WebControl = ddlUsuario_que_Registra;
        TTbcUsuario_que_Registra.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcUsuario_que_Registra.GetControlDataSetFunctionWithString = mySolicitudes_Via_App.FillDataUsuario_que_Registra;
        TTbcUsuario_que_Registra.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcOpcion.WebControl = ddlOpcion;
        TTbcOpcion.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcOpcion.GetControlDataSetFunctionWithString = mySolicitudes_Via_App.FillDataOpcion;
        TTbcOpcion.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcEstatus.WebControl = ddlEstatus;
        TTbcEstatus.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcEstatus.GetControlDataSetFunctionWithString = mySolicitudes_Via_App.FillDataEstatus;
        TTbcEstatus.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcObservatorio.WebControl = ddlObservatorio;
        TTbcObservatorio.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcObservatorio.GetControlDataSetFunctionWithString = mySolicitudes_Via_App.FillDataObservatorio;
        TTbcObservatorio.ParentWebControl = null;

        
        //-------------------------------------------------------------------------------------------------------------
        
        //-------------------------------------------------------------------------------------------------------------
	Botones();
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        
	
        //ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess,true);
    }

    private bool RegistroVisible(GridView Grid, string Key, string CampoClave)
    {
        foreach (System.Web.UI.WebControls.DataKey dk in Grid.DataKeys)
        {
            if (dk[CampoClave].ToString() == Key)
                return true;
        }
        return false;
    }
    
    private void FillDataControls()
    {
                MyFunctions.FillDataControl(ddlUsuario_que_Registra, mySolicitudes_Via_App.FillDataUsuario_que_Registra(""));
        MyFunctions.FillDataControl(ddlOpcion, mySolicitudes_Via_App.FillDataOpcion(""));
        MyFunctions.FillDataControl(ddlEstatus, mySolicitudes_Via_App.FillDataEstatus(""));
        MyFunctions.FillDataControl(ddlObservatorio, mySolicitudes_Via_App.FillDataObservatorio(""));

    }
    private void New()
    {
        
    }
    private void Modification()
    {
        WSSolicitudes_Via_App.objectBussinessSolicitudes_Via_App1 myDataSolicitudes_Via_App = mySolicitudes_Via_App.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()),true);
                if (myDataSolicitudes_Via_App.Folio.HasValue)
            txtFolio.Text = myDataSolicitudes_Via_App.Folio.ToString();
        if (myDataSolicitudes_Via_App.Usuario_que_Registra.HasValue)
           ddlUsuario_que_Registra.SelectedValue = myDataSolicitudes_Via_App.Usuario_que_Registra.Value.ToString().TrimEnd(' ');
        //ddlUsuario_que_Registra_SelectedIndexChanged(ddlUsuario_que_Registra, new EventArgs());
        if (myDataSolicitudes_Via_App.Fecha_de_Registro.HasValue)
            txtFecha_de_Registro.SelectedDate = myDataSolicitudes_Via_App.Fecha_de_Registro.Value;
        txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(myDataSolicitudes_Via_App.Hora_de_Registro);        txtNombre.Text = myDataSolicitudes_Via_App.Nombre;
        txtCorreo.Text = myDataSolicitudes_Via_App.Correo;
        if (myDataSolicitudes_Via_App.Opcion.HasValue)
           ddlOpcion.SelectedValue = myDataSolicitudes_Via_App.Opcion.Value.ToString().TrimEnd(' ');
        //ddlOpcion_SelectedIndexChanged(ddlOpcion, new EventArgs());
        txtDescripcion.Text = myDataSolicitudes_Via_App.Descripcion;
        txtLada.Text = myDataSolicitudes_Via_App.Lada;
        txtTelefono.Text = myDataSolicitudes_Via_App.Telefono;
        if (myDataSolicitudes_Via_App.Estatus.HasValue)
           ddlEstatus.SelectedValue = myDataSolicitudes_Via_App.Estatus.Value.ToString().TrimEnd(' ');
        //ddlEstatus_SelectedIndexChanged(ddlEstatus, new EventArgs());
        if (myDataSolicitudes_Via_App.Observatorio.HasValue)
           ddlObservatorio.SelectedValue = myDataSolicitudes_Via_App.Observatorio.Value.ToString().TrimEnd(' ');
        //ddlObservatorio_SelectedIndexChanged(ddlObservatorio, new EventArgs());

        
        
    }
    public void ConfigWithMetadata()
    {
        Boolean Foco = false;
        DataView dvMulti;
        WSTTMetadata.objectBussinessTTMetadata myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        WSTTMetadata.TTMetadataFilters[] myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = iProcess.ToString();

        RadTabStrip Aux = (RadTabStrip)TabControlsAux;
        
                (Aux.Tabs.FindTabByValue("tabPagDatos_Generales") as RadTab).Text = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Datos Generales");
        
        DataSet ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        DataView dv = new DataView(ds_controles.Tables[0]);

                dv.RowFilter = "TTMetadata_DTID = " + 141079;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFolio.Text = MyTraductor.getTextDTID(141079, lblFolio.Text);
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
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFolio.Style["display"] = "auto";
        else
            imgOblFolio.Style["display"] = "none";
        RFVFolio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFolio.Style["display"] = "auto";
        else
            trFolio.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141080;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblUsuario_que_Registra.Text = MyTraductor.getTextDTID(141080, lblUsuario_que_Registra.Text);
        ddlUsuario_que_Registra.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlUsuario_que_Registra.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcUsuario_que_Registra.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlUsuario_que_Registra.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlUsuario_que_Registra.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlUsuario_que_Registra.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlUsuario_que_Registra.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblUsuario_que_Registra.Style["display"] = "auto";
        else
            imgOblUsuario_que_Registra.Style["display"] = "none";
        RFVUsuario_que_Registra.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trUsuario_que_Registra.Style["display"] = "auto";
        else
            trUsuario_que_Registra.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141081;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Registro.Text = MyTraductor.getTextDTID(141081, lblFecha_de_Registro.Text);
        txtFecha_de_Registro.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFecha_de_Registro.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        {
            txtFecha_de_Registro.SelectedDate = DateTime.Now;
        }
        else
        {
            txtFecha_de_Registro.SelectedDate = MyFunctions.FormatDateNull(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFecha_de_Registro.Style["display"] = "auto";
        else
            imgOblFecha_de_Registro.Style["display"] = "none";
        RFVFecha_de_Registro.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFecha_de_Registro.Style["display"] = "auto";
        else
            trFecha_de_Registro.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 141082;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblHora_de_Registro.Text = MyTraductor.getTextDTID(141082, lblHora_de_Registro.Text);
        txtHora_de_Registro.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtHora_de_Registro.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString());
                    }
                    else
                    {
                        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#HORAACTUAL")
                        {
                            txtHora_de_Registro.SelectedDate = DateTime.Now;
                        }else{		
                            txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
                        }
                    }
                }
                else
                {
                    txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
                }
            }else{
                txtHora_de_Registro.SelectedDate = null;
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblHora_de_Registro.Style["display"] = "auto";
        else
            imgOblHora_de_Registro.Style["display"] = "none";
        RFVHora_de_Registro.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trHora_de_Registro.Style["display"] = "auto";
        else
            trHora_de_Registro.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 146128;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblNombre.Text = MyTraductor.getTextDTID(146128, lblNombre.Text);
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
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblNombre.Style["display"] = "auto";
        else
            imgOblNombre.Style["display"] = "none";
        RFVNombre.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trNombre.Style["display"] = "auto";
        else
            trNombre.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 146129;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblCorreo.Text = MyTraductor.getTextDTID(146129, lblCorreo.Text);
        txtCorreo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtCorreo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtCorreo.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtCorreo.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtCorreo.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblCorreo.Style["display"] = "auto";
        else
            imgOblCorreo.Style["display"] = "none";
        RFVCorreo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trCorreo.Style["display"] = "auto";
        else
            trCorreo.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141085;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblOpcion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblOpcion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblOpcion.Text = MyTraductor.getTextDTID(141085, lblOpcion.Text);
        ddlOpcion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlOpcion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcOpcion.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlOpcion.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlOpcion.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlOpcion.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlOpcion.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblOpcion.Style["display"] = "auto";
        else
            imgOblOpcion.Style["display"] = "none";
        RFVOpcion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trOpcion.Style["display"] = "auto";
        else
            trOpcion.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141086;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblDescripcion.Text = MyTraductor.getTextDTID(141086, lblDescripcion.Text);
        txtDescripcion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtDescripcion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtDescripcion.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
	txtDescripcion.Attributes.Add("MaxLength", dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtDescripcion.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtDescripcion.Text = "";
            }

        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblDescripcion.Style["display"] = "auto";
        else
            imgOblDescripcion.Style["display"] = "none";
        RFVDescripcion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trDescripcion.Style["display"] = "auto";
        else
            trDescripcion.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141087;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblLada.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblLada.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblLada.Text = MyTraductor.getTextDTID(141087, lblLada.Text);
        txtLada.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtLada.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtLada.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtLada.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtLada.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtLada.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtLada.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblLada.Style["display"] = "auto";
        else
            imgOblLada.Style["display"] = "none";
        RFVLada.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trLada.Style["display"] = "auto";
        else
            trLada.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141088;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblTelefono.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblTelefono.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblTelefono.Text = MyTraductor.getTextDTID(141088, lblTelefono.Text);
        txtTelefono.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtTelefono.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtTelefono.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtTelefono.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtTelefono.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtTelefono.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtTelefono.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblTelefono.Style["display"] = "auto";
        else
            imgOblTelefono.Style["display"] = "none";
        RFVTelefono.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trTelefono.Style["display"] = "auto";
        else
            trTelefono.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143367;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblEstatus.Text = MyTraductor.getTextDTID(143367, lblEstatus.Text);
        ddlEstatus.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlEstatus.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcEstatus.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlEstatus.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlEstatus.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlEstatus.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlEstatus.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblEstatus.Style["display"] = "auto";
        else
            imgOblEstatus.Style["display"] = "none";
        RFVEstatus.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trEstatus.Style["display"] = "auto";
        else
            trEstatus.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143754;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblObservatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblObservatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblObservatorio.Text = MyTraductor.getTextDTID(143754, lblObservatorio.Text);
        ddlObservatorio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlObservatorio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcObservatorio.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlObservatorio.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlObservatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlObservatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlObservatorio.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblObservatorio.Style["display"] = "auto";
        else
            imgOblObservatorio.Style["display"] = "none";
        RFVObservatorio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trObservatorio.Style["display"] = "auto";
        else
            trObservatorio.Style["display"] = "none";

        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
        DataView dv;
        string MultiRenglonesObligatorios="";
        
        
        if (MultiRenglonesObligatorios != "")
        {
            MultiRenglonesObligatorios = "Los siguientes datos son obligatorios: <br />" + MultiRenglonesObligatorios;
            ShowAlert(MultiRenglonesObligatorios,600);
            return false;
        }
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = mySolicitudes_Via_App.InsertWithReturnValue(userData,  MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), txtNombre.Text, txtCorreo.Text, MyFunctions.FormatNumberNull(ddlOpcion.SelectedValue), txtDescripcion.Text, txtLada.Text, txtTelefono.Text, MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), MyFunctions.FormatNumberNull(ddlObservatorio.SelectedValue));
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
        DataView dv;
        string MultiRenglonesObligatorios="";
        
        
        if (MultiRenglonesObligatorios != "")
        {
            MultiRenglonesObligatorios = "Los siguientes datos son obligatorios: <br />" + MultiRenglonesObligatorios;
            ShowAlert(MultiRenglonesObligatorios,600);
            return false;
        }
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            mySolicitudes_Via_App.Update(userData,  MyFunctions.FormatNumberNull(txtFolio.Text), MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), txtNombre.Text, txtCorreo.Text, MyFunctions.FormatNumberNull(ddlOpcion.SelectedValue), txtDescripcion.Text, txtLada.Text, txtTelefono.Text, MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), MyFunctions.FormatNumberNull(ddlObservatorio.SelectedValue));
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
        if (Funcion.RegresaDato("select procesoid from ttmetadata with(nolock) where identificador=1 and procesoid=" + iProcess.ToString() + " group by procesoid having count(dtid)=2") == iProcess.ToString())
            Session["PageLoad"] = "1"; 

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
        if (Funcion.RegresaDato("select procesoid from ttmetadata with(nolock) where identificador=1 and procesoid=" + iProcess.ToString() + " group by procesoid having count(dtid)=2") == iProcess.ToString())
            Session["PageLoad"] = "1"; 

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
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
            CargaInformacionPorEstado();
            Session["Tipo_Transaccion"] = "New";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
        }
        Session["CambiarArchivo"] = 0;
    }
    protected void cmdSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Funcion.RegresaDato("select procesoid from ttmetadata with(nolock) where identificador=1 and procesoid=" + iProcess.ToString() + " group by procesoid having count(dtid)=2") == iProcess.ToString())
            Session["PageLoad"] = "1"; 

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
            if (Page.Request["add"] != null)
            {
                if (Page.Request["add"].ToString() == "1")
                {
                    Session["Tipo_Transaccion"] = "New";
                }
            }
            else
            {
                //Session["Tipo_Transaccion"] = "Update";
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            if (Request["pf"] != null)
            {
               if (Request["pf"].ToString() == "1")
               	Response.Redirect("../FormsSystem/Default.aspx");
               else if (Request["Fase"] != null)
               	Response.Redirect("Solicitudes_Via_App_Lista.aspx?Fase=" + Request["Fase"]);
               else
               	Response.Redirect("Solicitudes_Via_App_Lista.aspx");
            }
            else if (Request["Fase"] != null)
               Response.Redirect("Solicitudes_Via_App_Lista.aspx?Fase=" + Request["Fase"]);
            else
               Response.Redirect("Solicitudes_Via_App_Lista.aspx");
        }
    }

  [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public static JsonResult Cancel(bool MenuVisible, bool pf, string Fase)
    {
        try
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            if (MenuVisible)
                return new JsonResult("Solicitudes_Via_App_Lista.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Solicitudes_Via_App_Lista.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Solicitudes_Via_App_Lista.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Solicitudes_Via_App_Lista.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Solicitudes_Via_App_Lista.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public static JsonResult Clear(bool MenuVisible, bool pf, string Fase)
    {
        try
        {
            HttpContext.Current.Session["Tipo_Transaccion"] = "New";

            if (MenuVisible)
                return new JsonResult("Solicitudes_Via_App_Catalogo.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Solicitudes_Via_App_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Solicitudes_Via_App_Catalogo.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Solicitudes_Via_App_Catalogo.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Solicitudes_Via_App_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }



    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }

    /*public void ddlUsuario_que_Registra_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlOpcion_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlObservatorio_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/

    

    






    private string buscarValorString(string name, DataRow row, DataSet ds)
    {
        string rta = "";
        foreach (DataColumn col in ds.Tables[0].Columns)
        {
            if (col.ColumnName.ToUpper() == name.ToUpper())
            {
                try
                {
                    rta = row[col].ToString();
                }
                catch
                {
                    rta = "";
                }
            }
        }
        return rta;
    }

    private DataTable llenarTabla(string[,] arr, DataTable table, DataSet ds)
    {
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            DataRow rowTable = table.NewRow();

            for (int i = 0; i < arr.Length / arr.Rank; i++)
            {
                switch (arr[i, 1])
                {
                    case "string":
                        try
                        {
                            rowTable[arr[i, 0]] = buscarValorString(arr[i, 0], row, ds);
                        }
                        catch
                        {
                            rowTable[arr[i, 0]] = "";
                        }
                        break;
                    case "int":
                        try
                        {
                            rowTable[arr[i, 0]] = Int32.Parse(buscarValorString(arr[i, 0], row, ds));
                        }
                        catch
                        {
                            rowTable[arr[i, 0]] = DBNull.Value;
                        }
                        break;
                    case "decimal":
                        try
                        {
                            rowTable[arr[i, 0]] = Decimal.Parse(buscarValorString(arr[i, 0], row, ds));
                        }
                        catch
                        {
                            rowTable[arr[i, 0]] = DBNull.Value;
                        }
                        break;
                    case "datetime":
                        try
                        {
                            rowTable[arr[i, 0]] = DateTime.Parse(buscarValorString(arr[i, 0], row, ds));
                        }
                        catch
                        {
                            rowTable[arr[i, 0]] = DBNull.Value;
                        }
                        break;
                    case "bool":
                        try
                        {
                            rowTable[arr[i, 0]] = Boolean.Parse(buscarValorString(arr[i, 0], row, ds));
                        }
                        catch
                        {
                            rowTable[arr[i, 0]] = false;
                        }
                        break;
                }
            }
            table.Rows.Add(rowTable);
            table.AcceptChanges();
        }
        return table;
    }

    public DataTable crearTabla(string[,] arr)
    {
        DataTable table = new DataTable("prueba");

        for (int i = 0; i < arr.Length / arr.Rank; i++)
        {
            switch (arr[i, 1])
            {
                case "string":
                    table.Columns.Add(new DataColumn(arr[i, 0], Type.GetType("System.String"), "", MappingType.Attribute));
                    break;
                case "int":
                    table.Columns.Add(new DataColumn(arr[i, 0], Type.GetType("System.Int32"), "", MappingType.Attribute));
                    break;
                case "decimal":
                    table.Columns.Add(new DataColumn(arr[i, 0], Type.GetType("System.Decimal"), "", MappingType.Attribute));
                    break;
                case "datetime":
                    table.Columns.Add(new DataColumn(arr[i, 0], typeof(DateTime), "", MappingType.Attribute));
                    break;
                case "bool":
                    table.Columns.Add(new DataColumn(arr[i, 0], typeof(bool), "", MappingType.Attribute));
                    break;
            }
        }

        return table;
    }


        #region WorkFlows

        #region ObtenControl(String NombreControl)
        protected Control ObtenControl(String NombreControl)
        {
            int Cont = Master.Controls.Count;
            Control busq = null;
            for (int x = 0; x < Cont; x++)
            {
                if (Master.Controls[x].ID != null)
                {
                    Control ctrl = Master.FindControl(Master.Controls[x].ID.ToString());

                    busq = ControlsMethod(ctrl, NombreControl);
                    if (busq != null)
                    {
                        if (busq.UniqueID != null)
                        {
                            x = 99999;
                        }
                    }
                }
            }
            return busq;
        } 
        #endregion

        #region ControlsMethod(Control obj, String Control)
        protected Control ControlsMethod(Control obj, String Control)
        {
            int CountMaster = obj.Controls.Count;
            Control busqe = null;
            if (obj != null)
            {
                for (int a = 0; a < CountMaster; a++)
                {
                    if (obj.Controls[a].UniqueID != null)
                    {
                        if (obj.Controls[a].ID == Control) 
                        {
                            busqe = obj.Controls[a];   //.Visible = false;
                            a = 99999;
                        }
                        if (a != 99999)
                        {
                            if (obj.Controls[a].Controls.Count > 0)
                            {
                                busqe = ControlsMethod(obj.Controls[a], Control);
                                if (busqe != null)
                                {
                                    if (busqe.UniqueID != null)
                                    {
                                        a = 99999;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return busqe;
        } 
        #endregion

        #region QuitaObligatorios(Control obj)
        protected void QuitaObligatorios(Control obj)
        {
            if (obj != null)
            {
                int CountMaster = obj.Controls.Count;
                Control busqe = null;
                if (obj != null)
                {
                    for (int a = 0; a < CountMaster; a++)
                    {
                        if (obj.Controls[a].UniqueID != null)
                        {
                            busqe = obj.Controls[a];
                            if (busqe.GetType() == typeof(RequiredFieldValidator))
                            {
                                RequiredFieldValidator req = (RequiredFieldValidator)busqe;
                                req.Enabled = false;
                            }
                            if (busqe.GetType() == typeof(Image))
                            {
                                Image im = (Image)busqe;
                                if (im.ID.Contains("imgObl"))
                                {
                                    //im.Visible = false;
                                    im.Attributes["style"] = "display: none;";
                                }
                            }

                            if (busqe.Controls.Count > 0)
                            {
                                QuitaObligatorios(busqe);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region DeshabilitaControles(Control obj, Int32 SoloLectura)
        protected void DeshabilitaControles(Control obj, Int32 SoloLectura)
        {
            if (obj != null)
            {
                int CountMaster = obj.Controls.Count;
                Control busqe = null;
                if (obj != null)
                {
                    for (int a = 0; a < CountMaster; a++)
                    {
                        if (obj.Controls[a].UniqueID != null)
                        {
                            busqe = obj.Controls[a];
                            if (busqe.GetType() == typeof(TextBox))
                            {
                                TextBox txt = (TextBox)busqe;
                                if (SoloLectura == 1)
                                {
                                    txt.Enabled = false;
                                }
                                else
                                {
                                    txt.Enabled = true;
                                }
                            }
                            if (busqe.GetType() == typeof(ImageButton))
                            {
                                ImageButton img = (ImageButton)busqe;
                                if (SoloLectura == 1)
                                {
                                    img.Enabled = false;
                                }
                                else
                                {
                                    img.Enabled = true;
                                }
                            }
                            if (busqe.GetType() == typeof(DropDownList))
                            {
                                DropDownList ddl = (DropDownList)busqe;
                                if (SoloLectura == 1)
                                {
                                    ddl.Enabled = false;
                                }
                                else
                                {
                                    ddl.Enabled = true;
                                }
                            }
                            if (busqe.GetType() == typeof(ListBox))
                            {
                                ListBox lst = (ListBox)busqe;
                                if (SoloLectura == 1)
                                {
                                    lst.Enabled = false;
                                }
                                else
                                {
                                    lst.Enabled = true;
                                }
                            }
                            if (busqe.Controls.Count > 0)
                            {
                                DeshabilitaControles(busqe, SoloLectura);
                            }
                        }
                    }
                }
            }
        } 
        #endregion

        #region CargaInformacionPorEstado()
        protected void CargaInformacionPorEstado()
        {
                string Process_TableName = Funcion.ValidaWorkFlow_GetTableName(iProcess, Int32.Parse(Session["globalTipoUsuario"].ToString()));
                if (Process_TableName.Length > 0) // Si no valida devuelve Empty
                {
                    string strFase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";

                    int Fase = 0;
                    if (strFase != "")
                        Fase = Int32.Parse(strFase);

                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                    SqlCommand com = new SqlCommand("spGetInformacionPorEstadoWorkFlow");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(Session["globalTipoUsuario"].ToString());
                    com.Parameters.Add("@Proceso", SqlDbType.Int).Value = iProcess;

                    if (Fase > 0)
                        com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
                    else
                        com.Parameters.Add("@Fase", SqlDbType.Int).Value = DBNull.Value;

                    DataSet ds = db.Consulta(com);
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                            string tabName = "tabPag" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Carpeta"].ToString());
                            RadTab radTab = (RadTab)TabControls.Tabs.FindTabByValue(tabName);
                            RadPageView pageView = (RadPageView)RadMultiPage1.FindControl(tabName);

                             if (Int32.Parse(ds.Tables[0].Rows[i]["Visible"].ToString()) == 0)
                            {
                                radTab.Attributes["style"] = "display: none;";
                                pageView.Attributes["style"] = "display: none;";
                            }




                            if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                            {

                                System.Web.UI.HtmlControls.HtmlTable ctt = (System.Web.UI.HtmlControls.HtmlTable)Funcion.FindControlRecursive(this, "tb" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Carpeta"].ToString()));
                                ctt.Disabled = true;
                                string sJavaScript = string.Format("$get('{0}').disabled = {1};", ctt.ClientID, (true).ToString().ToLower());
                                BusinessOperations.DisableControlRecursive(ctt, ref sJavaScript);
                                //DeshabilitaControles((Control)tab, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                            }

                            if (Int32.Parse(ds.Tables[0].Rows[i]["Obligatorios"].ToString()) == 0)
                            {

                                QuitaObligatorios((Control)pageView);
                            }

                            if (ds.Tables[0].Rows[i]["Etiqueta"].ToString() != "")
                            {

                                radTab.Text = ds.Tables[0].Rows[i]["Etiqueta"].ToString();
                            }

                    }
                    //Check the first visible Tab in order to select it.
                    RadTabCollection tabs = (RadTabCollection)TabControls.Tabs;
                    for (int i = 0; i < tabs.Count; i++)
                    {
                        RadTab tab = (RadTab)tabs[i];

                        if (tab.Visible == true)
                        {
                            TabControls.SelectedIndex = i;
                            RadMultiPage1.SelectedIndex = i;
                            i = tabs.Count;
                        }
                    } 
                    UpdatePanel1.Update();
                }
        } 
        #endregion


        #region CargaInformacionCampos()
        protected void CargaInformacionCampos()
        {         
            
            string Process_TableName = Funcion.ValidaWorkFlow_GetTableName(iProcess, Int32.Parse(Session["globalTipoUsuario"].ToString()));
            if (Process_TableName.Length > 0) // Si no valida devuelve Empty
            {
                string strFase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";
                int Fase = 0;
                if (strFase!="")
                    Fase = Int32.Parse(strFase);


                if (Fase > 0)
                {
                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                    SqlCommand com = new SqlCommand("spGetInformacionControlesWorkFlow");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(Session["globalTipoUsuario"].ToString());
                    com.Parameters.Add("@Proceso", SqlDbType.Int).Value = iProcess;

                    if (Fase > 0)
                        com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
                    else
                        com.Parameters.Add("@Fase", SqlDbType.Int).Value = DBNull.Value;

                    DataSet ds = db.Consulta(com);
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        String Control = Funcion.NombreControl(ds.Tables[0].Rows[i]["Campo"].ToString(), Int32.Parse(ds.Tables[0].Rows[i]["Tipo_de_Control"].ToString()));
                        String Campo = Funcion.FormateaDato(ds.Tables[0].Rows[i]["Campo"].ToString());
                        Control ctrl = ObtenControl(Control);

                        if (ds.Tables[0].Rows[i]["Etiqueta"].ToString() != "")
                        {
                            Label lbl = (Label)ObtenControl("lbl" + Campo);
                            lbl.Text = ds.Tables[0].Rows[i]["Etiqueta"].ToString();
                        }

                        if (Int32.Parse(ds.Tables[0].Rows[i]["Obligatorios"].ToString()) == 0)
                        {
                            RequiredFieldValidator val = (RequiredFieldValidator)ObtenControl("RFV" + Campo);
                            val.Enabled = false;
                            Image im = (Image)ObtenControl("imgObl" + Campo);
                            im.Visible = false;
                        }
                        else
                        {
                            RequiredFieldValidator val = (RequiredFieldValidator)ObtenControl("RFV" + Campo);
                            val.Enabled = true;
                            Image im = (Image)ObtenControl("imgObl" + Campo);
                            im.Visible = true;
                        }

                        if (Int32.Parse(ds.Tables[0].Rows[i]["Visible"].ToString()) == 0)
                        {
                            HtmlTableRow row = (HtmlTableRow)ObtenControl("tr" + Campo);
                            row.Attributes["style"] = "display: none;";
                            //((HtmlTableRow)row.Parent.FindControl("tr" + Campo)).Attributes.Remove("class");
                            //((HtmlTableRow)row.Parent.FindControl("tr" + Campo)).Attributes.Add("class", "Hide");
                        }
                        else
                        {
                            HtmlTableRow row = (HtmlTableRow)ObtenControl("tr" + Campo);
                            row.Attributes["style"] = "display: auto;";
                            //((HtmlTableRow)row.Parent.FindControl("tr" + Campo)).Attributes.Remove("class");
                            //((HtmlTableRow)row.Parent.FindControl("tr" + Campo)).Attributes.Add("class", "");
                        }

                        switch (Int32.Parse(ds.Tables[0].Rows[i]["Tipo_de_Control"].ToString()))
                        {
                            case 1: //TextBox
                                TextBox txt = (TextBox)ctrl;
                                //if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                                DeshabilitaControles((Control)txt.Parent, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                                if (ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString() != "")
                                    txt.Text = ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString();
                                if (ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString() != "")
                                    txt.ToolTip = ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString();
                                break;
                            case 2: //DropDown
                                DropDownList ddl = (DropDownList)ctrl;
                                //if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                                DeshabilitaControles((Control)ddl.Parent, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                                if (ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString() != "")
                                    ddl.Text = ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString();
                                if (ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString() != "")
                                    ddl.ToolTip = ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString();
                                break;
                            case 3: //List
                                ListBox lst = (ListBox)ctrl;
                                //if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                                DeshabilitaControles((Control)lst.Parent, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                                if (ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString() != "")
                                    lst.Text = ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString();
                                if (ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString() != "")
                                    lst.ToolTip = ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString();
                                break;
                            case 5: //CheckBox
                                CheckBox chk = (CheckBox)ctrl;
                                //if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                                DeshabilitaControles((Control)chk.Parent, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                                if (ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString() == "1")
                                    chk.Checked = true;
                                if (ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString() != "")
                                    chk.ToolTip = ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString();
                                break;
                            case 13: //Archivo
                                TextBox arch = (TextBox)ctrl;
                                //if (Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()) == 1)
                                DeshabilitaControles((Control)arch.Parent, Int32.Parse(ds.Tables[0].Rows[i]["Solo_Lectura"].ToString()));
                                if (ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString() != "")
                                    arch.Text = ds.Tables[0].Rows[i]["Valor_por_Defecto"].ToString();
                                if (ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString() != "")
                                    arch.ToolTip = ds.Tables[0].Rows[i]["texto_de_ayuda"].ToString();
                                break;
                        }

                    }
                }
            }
            
        }
        #endregion

        private void Botones()
        {
            #region Configuración del botón Checkout
            List<TTBasePage.GenericImageButton> botones = new List<TTBasePage.GenericImageButton>();
            string strFase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";

            int Fase = 0;
            if (strFase != "")
                Fase = Int32.Parse(strFase);


            if (Fase > 0 && Session["Tipo_Transaccion"].ToString() != "Consult" )
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com2 = new SqlCommand("spGetFasesByProcesoTTWorkFlow");
                com2.CommandType = CommandType.StoredProcedure;
                //com2.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(Session["globalTipoUsuario"].ToString());
                com2.Parameters.Add("@idProceso", SqlDbType.Int).Value = iProcess;
                com2.Parameters.Add("@fase", SqlDbType.Int).Value = Fase;
                DataSet ds0 = db.Consulta(com2);

                string strNext_FaseNum = string.Empty;
                string strNext_Fase = string.Empty;

                if (ds0.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds0.Tables[0].Rows.Count; k++)
                    {

                        botones.Add(new TTBasePage.GenericImageButton(ds0.Tables[0].Rows[k]["Nombre"].ToString(), "../Images/Design/btns/btn_catalog/btn_01_Generic.png", ds0.Tables[0].Rows[k]["Campo"].ToString(), ds0.Tables[0].Rows[k]["Valor"].ToString(), "cmdSave_Click", ""));
                    }
                }
            }
            else if (Session["Tipo_Transaccion"].ToString() != "Consult")
            {
                DataSet dsBotones = Funcion.RegresaDataSet("select * from ttConfiguracionProcesoBotonesCatalogo with(nolock) where idproceso=" + iProcess);
                if (dsBotones.Tables[0].Rows.Count > 0)
                {
                    if (dsBotones.Tables[0].Rows[0]["OcultarGuardar"].ToString() == "" || dsBotones.Tables[0].Rows[0]["OcultarGuardar"].ToString().ToUpper() == "FALSE")
                        botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(42, "Grabar"), "../Images/Design/btns/btn_catalog/btn_01_Generic.png", "", "", "cmdSave_Click", ""));

                    if (dsBotones.Tables[0].Rows[0]["OcultarGuardaryNuevo"].ToString() == "" || dsBotones.Tables[0].Rows[0]["OcultarGuardaryNuevo"].ToString().ToUpper() == "FALSE")
                        botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(43, "Grabar y Nuevo"), "../Images/Design/btns/btn_catalog/btn_02_Generic.png", "", "", "cmdSaveNew_Click", ""));

                    if (dsBotones.Tables[0].Rows[0]["OcultarGuardaryCopiar"].ToString() == "" || dsBotones.Tables[0].Rows[0]["OcultarGuardaryCopiar"].ToString().ToUpper() == "FALSE")
                        botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(44, "Grabar y Copiar"), "../Images/Design/btns/btn_catalog/btn_03_Generic.png", "", "", "cmdSaveCopy_Click", ""));

                    if (dsBotones.Tables[0].Rows[0]["OcultarLimpiar"].ToString() == "" || dsBotones.Tables[0].Rows[0]["OcultarLimpiar"].ToString().ToUpper() == "FALSE")
                        botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(45, "Limpiar"), "../Images/Design/btns/btn_catalog/btn_04_Generic.png", "", "", "", "btn_cmdClearClick();"));
                }
                else
                {
                    botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(42, "Grabar"), "../Images/Design/btns/btn_catalog/btn_01_Generic.png", "", "", "cmdSave_Click", ""));
                    botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(43, "Grabar y Nuevo"), "../Images/Design/btns/btn_catalog/btn_02_Generic.png", "", "", "cmdSaveNew_Click", ""));
                    botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(44, "Grabar y Copiar"), "../Images/Design/btns/btn_catalog/btn_03_Generic.png", "", "", "cmdSaveCopy_Click", ""));
                    botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(45, "Limpiar"), "../Images/Design/btns/btn_catalog/btn_04_Generic.png", "", "", "", "btn_cmdClearClick();"));
                }
            }

            botones.Add(new TTBasePage.GenericImageButton(MyTraductor.getMessage(46, "Cancelar"), "../Images/Design/btns/btn_catalog/btn_05_Generic.png", "", "", "", "btn_cmdCloseClick();"));

            myRepeaterImage.DataSource = botones;
            myRepeaterImage.DataBind();

            #endregion
        }

        protected void myRepeaterImage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string click = ((HiddenField)e.Item.FindControl("hfNombreMetodo")).Value;
            if (click != string.Empty)
            {
                //get click event
                EventInfo clickEvent = typeof(ImageButton).GetEvent("Click");
                ImageButton btn = ((ImageButton)e.Item.FindControl("cmd"));

                //add handler passing in button instance and a delegate to an event handler
                //I used an anonymous method in this case, but you don't have to.
                ImageClickEventHandler handler = delegate { Response.Write("Do Something"); };

                //you'll want to do something more like this:
                handler
                    = (ImageClickEventHandler)Delegate.CreateDelegate(
                        typeof(ImageClickEventHandler),
                    //"this" is a System.Web.UI.Page in my case
                        this,
                    //myButton_Click is the name of an EventHandler delegate
                        ((HiddenField)e.Item.FindControl("hfNombreMetodo")).Value);
                clickEvent.AddEventHandler(btn, handler);

                ((HtmlGenericControl)e.Item.FindControl("btn_grabar_catalog")).Attributes.Add("onclick", "document.getElementById('" + btn.ClientID + "').click();");
            }
        }

        #endregion

        #region Ejecución de Reglas de Negocio (Modify Control)


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult EvaluaRN(string DTid, string idProceso, string indexRow)
        {
            string stringBusinessRule = "";
            //bool Boton = false;
            //DataSet dsBoton;
            //dsBoton=Funcion.RegresaDataSet("Select tipo_de_control,dbo.fngeneranombre(nombre) as Nombre from ttmetadata with(nolock) where dtid=" + DTid);

            //if (dsBoton.Tables[0].Rows[0]["tipo_de_control"].ToString() == "6")
            //    Boton = true;

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spGetBusinessRuleExecute");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idProceso", SqlDbType.Int).Value = int.Parse(idProceso);
            com.Parameters.Add("@DTId", SqlDbType.NVarChar).Value = DTid;
            DataSet ds = db.Consulta(com);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string concatenar = ds.Tables[0].Rows[i]["instruccion"].ToString();
                //if (Boton)
                //    concatenar = concatenar.Replace("FLD['ctl00_MainContent_" + dsBoton.Tables[0].Rows[0]["Nombre"].ToString(), "1'");
                //else
                //{
                //    if (concatenar.IndexOf("('1' == '1')") != 0)
                //        concatenar = "";
                //}

                stringBusinessRule = stringBusinessRule + concatenar + "@@SEPARADOR@@";

                /*Si el EvaluaRN viene desde un control MR en PopUp, se modifica el clienteID para que se pueda obtener.*/
                int startIndex, endIndex;
                while (stringBusinessRule.Contains("_ctl@i@_") && (indexRow == "0" || indexRow == ""))
                {
                    startIndex = stringBusinessRule.IndexOf("_grdMulti");
                    endIndex = stringBusinessRule.IndexOf("_ctl@i@_");
                    if (endIndex > startIndex)
                        stringBusinessRule = stringBusinessRule.Remove(startIndex + 1, endIndex + "_ctl@i@_".Length - startIndex - 1);

                    /*Si existe un Combo, cambiar ClientId*/
                    stringBusinessRule = stringBusinessRule.Replace("_cdd", "_ddl");
                } 
            }

            //reemplazar index de multirenglon
            if (indexRow != "" && indexRow != "0")
                stringBusinessRule = stringBusinessRule.Replace("@i@", indexRow.Substring(indexRow.IndexOf("_ctl") + 4, indexRow.IndexOf("_", indexRow.IndexOf("_ctl") + 4) - (indexRow.IndexOf("_ctl") + 4)));

            ////reemplazar variables globales
            while (stringBusinessRule.IndexOf("GLOBAL[") > -1)
            {
                int xStart2 = stringBusinessRule.IndexOf("GLOBAL[");
                int xEnd2 = stringBusinessRule.IndexOf("]", xStart2);
                String textGlobal = stringBusinessRule.Substring(xStart2 + 7, xEnd2 - xStart2 - 7);
                stringBusinessRule = stringBusinessRule.Replace("GLOBAL[" + textGlobal + "]", HttpContext.Current.Session[textGlobal] == null ? "" : HttpContext.Current.Session[textGlobal].ToString());
            }
            db.Dispose();
            ds.Dispose();
            com.Dispose();
            return new JsonResult(stringBusinessRule, true, null);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult EjecutaQuery(string Query)
        {
            string Result = "";
            string[] separators = { "@LB@" };
            string[] split = Query.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                sb.AppendLine(s);
            }
            Query = sb.ToString();
            Query = Query.Replace("@LB@", " ");
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(Query);
            com.CommandType = CommandType.Text;
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
                Result = ds.Tables[0].Rows[0][0].ToString();

            db.Dispose();
            ds.Dispose();
            com.Dispose();
            return new JsonResult(Result, true, null);
        }

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<ComboInfo> FiltraCombo(string Query)
        {
            ComboInfo ci = new ComboInfo();
            List<ComboInfo> ComboInformation = new List<ComboInfo>();
            try
            {
                string[] separators = { "@LB@" };
                string[] split = Query.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string s in split)
                {
                sb.AppendLine(s);
                }
                Query = sb.ToString();
                Query = Query.Replace("@LB@", " ");
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand(Query);
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ComboInformation.Add(new ComboInfo()
                            {
                                ComboId = "",
                                ComboName = ""
                            });
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                ComboInformation.Add(new ComboInfo()
                                {
                                    ComboId = dr[0].ToString(),
                                    ComboName = dr[1].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ComboInformation;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult AsignaVariableGlobal(string NombreVariable, string Valor)
        {
            string Result = "";
            HttpContext.Current.Session[NombreVariable] = Valor;
            return new JsonResult(Result, true, null);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult setValueToRadComboBox(string DTid, string Proceso, string Value)
        {
            string Result = "";
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();

            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTid));
            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

            string Clave = MyFunctions.GenerateName(datoClave.Nombre);
            string Descripcion = MyFunctions.GenerateName(datoDescripcion.Nombre);
            string NombreTabla = MyFunctions.GenerateName(datoDescripcion.NombreTabla);
            string sqlQuery = string.Empty;

            sqlQuery = @"SELECT  rtrim({1}) FROM {2} with(nolock) WHERE ( {0} = '{3}' )";

            sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, Value);
            DataSet ds = Funcion.RegresaDataSet(sqlQuery);


            if (ds.Tables[0].Rows.Count > 0)
                Result = ds.Tables[0].Rows[0][0].ToString();

            return new JsonResult(Result, true, null);
        } 
        

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult ObtenVariableGlobal(string NombreVariable)
        {
            string Valor="";
            if (HttpContext.Current.Session[NombreVariable] != null)
                Valor = HttpContext.Current.Session[NombreVariable].ToString(); 
            return new JsonResult(Valor, true, null);
        }

        #endregion

}
}

