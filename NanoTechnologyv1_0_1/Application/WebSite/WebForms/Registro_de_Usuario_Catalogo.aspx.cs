/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo Registro_de_Usuario
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
public partial class Registro_de_Usuario_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSRegistro_de_Usuario.objectBussinessRegistro_de_Usuario myRegistro_de_Usuario = new WSRegistro_de_Usuario.objectBussinessRegistro_de_Usuario();
    private WSRegistro_de_Usuario.GlobalData userData;
    public int iProcess = 29981;
    private String sDNTNombre = "Registro_de_Usuario";
    private String sDNTDescripcion = "Registro de Usuario";
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

            ajaxSM.RegisterPostBackControl(buttonSubmitFoto_de_Perfil);

        
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

            //if (fuaFoto_de_Perfil.IsPosting)
            //this.managePostFoto_de_Perfil();



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
                            fuaFoto_de_Perfil.Visible = true;
                buttonSubmitFoto_de_Perfil.Visible = true;
                labelNoResultsFoto_de_Perfil.Visible = true;
                repeaterResultsFoto_de_Perfil.Visible = true;
                //----------------------------------------------------
                lkbVerFoto_de_Perfil.Visible = false;
                IbtnCambiarArchivoFoto_de_Perfil.Visible = false;
                IbtnBorrarArchivoFoto_de_Perfil.Visible = false;
                Session["ArchivoFoto_de_Perfil"] = null;
               
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
        txtApellido.Enabled=false;
        txtNombre_Completo.Enabled=false;
        txtCorreo.Enabled=false;
        txtContrasena.Enabled=false;
        txtConfirmar_Contrasena.Enabled=false;
        ChAcepta_Terminos.Enabled=false;
        ddlUsuario_del_Sistema.Enabled=false;
        TTbcUsuario_del_Sistema.ImgButton.Visible = false;


                    if (lkbVerFoto_de_Perfil.Visible)
            {
                IbtnBorrarArchivoFoto_de_Perfil.Visible = false;
                IbtnCambiarArchivoFoto_de_Perfil.Visible = false;
            }
            else
            {
                fuaFoto_de_Perfil.Enabled = false;
            }

            labelNoResultsFoto_de_Perfil.Visible = false;
            buttonSubmitFoto_de_Perfil.Enabled = false;
            RFVFoto_de_Perfil.Visible = false;
    
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
        int iProcess = 29981;
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
        WSRegistro_de_Usuario.objectBussinessRegistro_de_Usuario1 myDataRegistro_de_Usuario = myRegistro_de_Usuario.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()), true);


    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSRegistro_de_Usuario.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSRegistro_de_Usuario.GlobalDataLanguages)MyUserData.Language;
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
        TTbcUsuario_que_Registra.GetControlDataSetFunctionWithString = myRegistro_de_Usuario.FillDataUsuario_que_Registra;
        TTbcUsuario_que_Registra.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcUsuario_del_Sistema.WebControl = ddlUsuario_del_Sistema;
        TTbcUsuario_del_Sistema.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcUsuario_del_Sistema.GetControlDataSetFunctionWithString = myRegistro_de_Usuario.FillDataUsuario_del_Sistema;
        TTbcUsuario_del_Sistema.ParentWebControl = null;

        
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
                MyFunctions.FillDataControl(ddlUsuario_que_Registra, myRegistro_de_Usuario.FillDataUsuario_que_Registra(""));
        MyFunctions.FillDataControl(ddlUsuario_del_Sistema, myRegistro_de_Usuario.FillDataUsuario_del_Sistema(""));

    }
    private void New()
    {
        
    }
    private void Modification()
    {
        WSRegistro_de_Usuario.objectBussinessRegistro_de_Usuario1 myDataRegistro_de_Usuario = myRegistro_de_Usuario.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()),true);
                if (myDataRegistro_de_Usuario.Folio.HasValue)
            txtFolio.Text = myDataRegistro_de_Usuario.Folio.ToString();
        if (myDataRegistro_de_Usuario.Usuario_que_Registra.HasValue)
           ddlUsuario_que_Registra.SelectedValue = myDataRegistro_de_Usuario.Usuario_que_Registra.Value.ToString().TrimEnd(' ');
        //ddlUsuario_que_Registra_SelectedIndexChanged(ddlUsuario_que_Registra, new EventArgs());
        if (myDataRegistro_de_Usuario.Fecha_de_Registro.HasValue)
            txtFecha_de_Registro.SelectedDate = myDataRegistro_de_Usuario.Fecha_de_Registro.Value;
        txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(myDataRegistro_de_Usuario.Hora_de_Registro);        txtNombre.Text = myDataRegistro_de_Usuario.Nombre;
        txtApellido.Text = myDataRegistro_de_Usuario.Apellido;
        txtNombre_Completo.Text = myDataRegistro_de_Usuario.Nombre_Completo;
        txtCorreo.Text = myDataRegistro_de_Usuario.Correo;
        txtContrasena.Text = myDataRegistro_de_Usuario.Contrasena;
        txtConfirmar_Contrasena.Text = myDataRegistro_de_Usuario.Confirmar_Contrasena;
       ChAcepta_Terminos.Checked  = myDataRegistro_de_Usuario.Acepta_Terminos;
               if (myDataRegistro_de_Usuario.Foto_de_Perfil.HasValue){
            txtFoto_de_Perfil.Text = myDataRegistro_de_Usuario.Foto_de_Perfil.Value.ToString();

            if (Session["CambiarArchivo"] == null)
                Session["CambiarArchivo"] = "0";

            if ((Session["CambiarArchivo"].ToString() == "0"))
            {
                if (txtFoto_de_Perfil.Text != ""){
                  TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                  SqlCommand com = new SqlCommand("Select Nombre From TTArchivos where Folio=" + txtFoto_de_Perfil.Text);
                  com.CommandType = CommandType.Text;

                  DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0){
                      fuaFoto_de_Perfil.Visible = false;

                      lkbVerFoto_de_Perfil.Visible = true;
                      IbtnBorrarArchivoFoto_de_Perfil.Visible = true;
                      IbtnCambiarArchivoFoto_de_Perfil.Visible = true;

                      lkbVerFoto_de_Perfil.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();	
                        buttonSubmitFoto_de_Perfil.Visible = false;
                        cvRadUploadFoto_de_Perfil.Visible = false;
                        labelNoResultsFoto_de_Perfil.Visible = false;
                        RFVFoto_de_Perfil.Enabled = false; 
                    }
                }
            }
        }        if (myDataRegistro_de_Usuario.Usuario_del_Sistema.HasValue)
           ddlUsuario_del_Sistema.SelectedValue = myDataRegistro_de_Usuario.Usuario_del_Sistema.Value.ToString().TrimEnd(' ');
        //ddlUsuario_del_Sistema_SelectedIndexChanged(ddlUsuario_del_Sistema, new EventArgs());

        
                    cvRadUploadFoto_de_Perfil.Enabled = false;
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

                dv.RowFilter = "TTMetadata_DTID = " + 141033;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFolio.Text = MyTraductor.getTextDTID(141033, lblFolio.Text);
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
            trFolio.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141034;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblUsuario_que_Registra.Text = MyTraductor.getTextDTID(141034, lblUsuario_que_Registra.Text);
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
            trUsuario_que_Registra.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141035;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Registro.Text = MyTraductor.getTextDTID(141035, lblFecha_de_Registro.Text);
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
        dv.RowFilter = "TTMetadata_DTID = " + 141036;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblHora_de_Registro.Text = MyTraductor.getTextDTID(141036, lblHora_de_Registro.Text);
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
            trHora_de_Registro.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141037;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblNombre.Text = MyTraductor.getTextDTID(141037, lblNombre.Text);
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
            trNombre.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141038;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblApellido.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblApellido.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblApellido.Text = MyTraductor.getTextDTID(141038, lblApellido.Text);
        txtApellido.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtApellido.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtApellido.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtApellido.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtApellido.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtApellido.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtApellido.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblApellido.Style["display"] = "auto";
        else
            imgOblApellido.Style["display"] = "none";
        RFVApellido.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trApellido.Style["display"] = "auto";
        else
            trApellido.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141039;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblNombre_Completo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblNombre_Completo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblNombre_Completo.Text = MyTraductor.getTextDTID(141039, lblNombre_Completo.Text);
        txtNombre_Completo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtNombre_Completo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtNombre_Completo.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
	txtNombre_Completo.Attributes.Add("MaxLength", dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtNombre_Completo.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtNombre_Completo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtNombre_Completo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtNombre_Completo.Text = "";
            }

        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblNombre_Completo.Style["display"] = "auto";
        else
            imgOblNombre_Completo.Style["display"] = "none";
        RFVNombre_Completo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trNombre_Completo.Style["display"] = "auto";
        else
            trNombre_Completo.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141040;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblCorreo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblCorreo.Text = MyTraductor.getTextDTID(141040, lblCorreo.Text);
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
            trCorreo.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141041;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblContrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblContrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblContrasena.Text = MyTraductor.getTextDTID(141041, lblContrasena.Text);
        txtContrasena.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtContrasena.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtContrasena.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtContrasena.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtContrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtContrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtContrasena.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblContrasena.Style["display"] = "auto";
        else
            imgOblContrasena.Style["display"] = "none";
        RFVContrasena.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trContrasena.Style["display"] = "auto";
        else
            trContrasena.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141042;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblConfirmar_Contrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblConfirmar_Contrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblConfirmar_Contrasena.Text = MyTraductor.getTextDTID(141042, lblConfirmar_Contrasena.Text);
        txtConfirmar_Contrasena.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtConfirmar_Contrasena.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtConfirmar_Contrasena.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtConfirmar_Contrasena.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtConfirmar_Contrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtConfirmar_Contrasena.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtConfirmar_Contrasena.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblConfirmar_Contrasena.Style["display"] = "auto";
        else
            imgOblConfirmar_Contrasena.Style["display"] = "none";
        RFVConfirmar_Contrasena.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trConfirmar_Contrasena.Style["display"] = "auto";
        else
            trConfirmar_Contrasena.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141043;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAcepta_Terminos.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAcepta_Terminos.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblAcepta_Terminos.Text = MyTraductor.getTextDTID(141043, lblAcepta_Terminos.Text);
        ChAcepta_Terminos.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ChAcepta_Terminos.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "1"){
            	ChAcepta_Terminos.Checked = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
            }else{
                ChAcepta_Terminos.Checked = false;
            }
        }else{
            ChAcepta_Terminos.Checked = false;
        }
        imgOblAcepta_Terminos.Style["display"] = "none";
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trAcepta_Terminos.Style["display"] = "auto";
        else
            trAcepta_Terminos.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141044;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFoto_de_Perfil.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFoto_de_Perfil.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFoto_de_Perfil.Text = MyTraductor.getTextDTID(141044, lblFoto_de_Perfil.Text);
        txtFoto_de_Perfil.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFoto_de_Perfil.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtFoto_de_Perfil.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        txtFoto_de_Perfil.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        labelNoResultsFoto_de_Perfil.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFoto_de_Perfil.Style["display"] = "auto";
        else
            imgOblFoto_de_Perfil.Style["display"] = "none";
        RFVFoto_de_Perfil.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFoto_de_Perfil.Style["display"] = "auto";
        else
            trFoto_de_Perfil.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141104;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblUsuario_del_Sistema.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblUsuario_del_Sistema.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblUsuario_del_Sistema.Text = MyTraductor.getTextDTID(141104, lblUsuario_del_Sistema.Text);
        ddlUsuario_del_Sistema.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlUsuario_del_Sistema.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcUsuario_del_Sistema.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlUsuario_del_Sistema.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlUsuario_del_Sistema.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlUsuario_del_Sistema.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlUsuario_del_Sistema.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblUsuario_del_Sistema.Style["display"] = "auto";
        else
            imgOblUsuario_del_Sistema.Style["display"] = "none";
        RFVUsuario_del_Sistema.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trUsuario_del_Sistema.Style["display"] = "auto";
        else
            trUsuario_del_Sistema.Style["display"] = "none";

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
            		GuardaArchivoFoto_de_Perfil();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myRegistro_de_Usuario.InsertWithReturnValue(userData,  MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), txtNombre.Text, txtApellido.Text, txtNombre_Completo.Text, txtCorreo.Text, txtContrasena.Text, txtConfirmar_Contrasena.Text, ChAcepta_Terminos.Checked, MyFunctions.FormatNumberNull(txtFoto_de_Perfil.Text), MyFunctions.FormatNumberNull(ddlUsuario_del_Sistema.SelectedValue));
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
            		GuardaArchivoFoto_de_Perfil();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myRegistro_de_Usuario.Update(userData,  MyFunctions.FormatNumberNull(txtFolio.Text), MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), txtNombre.Text, txtApellido.Text, txtNombre_Completo.Text, txtCorreo.Text, txtContrasena.Text, txtConfirmar_Contrasena.Text, ChAcepta_Terminos.Checked, MyFunctions.FormatNumberNull(txtFoto_de_Perfil.Text), MyFunctions.FormatNumberNull(ddlUsuario_del_Sistema.SelectedValue));
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

	private void GuardaArchivoFoto_de_Perfil()
	{
		String NombreArchivo = "";
		if (Session["ArchivoFoto_de_Perfil"] != null)
                                      NombreArchivo = Session["ArchivoFoto_de_Perfil"].ToString();

		if (NombreArchivo == "" && lkbVerFoto_de_Perfil.Text != "")
		{
			if (lkbVerFoto_de_Perfil.Text.Trim().Length > 4)
			{
				NombreArchivo = lkbVerFoto_de_Perfil.Text;
			}
			else
			{
				NombreArchivo = "";
			}
		}
			
		//se guarda sin archivo
		if (NombreArchivo == "" && lkbVerFoto_de_Perfil.Text == "")
		{
			NombreArchivo = "";
		}
		
		if (File.Exists(Server.MapPath("TempFiles/") + NombreArchivo) == true)
		{
			int Folio = 0;
			if (txtFoto_de_Perfil.Text != "")
				Folio = int.Parse(txtFoto_de_Perfil.Text);
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
					txtFoto_de_Perfil.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				else					
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "alert('Error al guardar el archivo en B.D');", true);				
			}
			
			File.Delete(Server.MapPath("TempFiles/") + NombreArchivo);
			
		}
	}


    public void Clear_All()
    {
	
                        fuaFoto_de_Perfil.Visible = true;
                buttonSubmitFoto_de_Perfil.Visible = true;
                labelNoResultsFoto_de_Perfil.Visible = true;
                repeaterResultsFoto_de_Perfil.Visible = true;
                //----------------------------------------------------
                lkbVerFoto_de_Perfil.Visible = false;
                IbtnCambiarArchivoFoto_de_Perfil.Visible = false;
                IbtnBorrarArchivoFoto_de_Perfil.Visible = false;
                Session["ArchivoFoto_de_Perfil"] = null;
               
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
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoFoto_de_Perfil"] == null  && RFVFoto_de_Perfil.Enabled && RFVFoto_de_Perfil.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Foto_de_Perfil");
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
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
        }
    }
    protected void cmdSaveNew_Click(object sender, ImageClickEventArgs e)
    {
        if (Funcion.RegresaDato("select procesoid from ttmetadata with(nolock) where identificador=1 and procesoid=" + iProcess.ToString() + " group by procesoid having count(dtid)=2") == iProcess.ToString())
            Session["PageLoad"] = "1"; 

        if (!IsValid3PointsRelations())
            return;
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoFoto_de_Perfil"] == null  && RFVFoto_de_Perfil.Enabled && RFVFoto_de_Perfil.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Foto_de_Perfil");
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
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoFoto_de_Perfil"] == null  && RFVFoto_de_Perfil.Enabled && RFVFoto_de_Perfil.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Foto_de_Perfil");
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
            
			var redirect = "";
            if (Request["pf"] != null)
            {
               if (Request["pf"].ToString() == "1")
               	      redirect="../FormsSystem/Default.aspx";
               else if (Request["Fase"] != null)
					redirect="Registro_de_Usuario_Lista.aspx?Fase=" + Request["Fase"];
               else
                    redirect="Registro_de_Usuario_Lista.aspx";
            }
            else if (Request["Fase"] != null)
				redirect="Registro_de_Usuario_Lista.aspx?Fase=" + Request["Fase"];
            else
				redirect="Registro_de_Usuario_Lista.aspx";
				
			ScriptManager.RegisterStartupScript(this, typeof(Page), "redirect", "javascript:window.location.href='" + redirect + "';", true);
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
                return new JsonResult("Registro_de_Usuario_Lista.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Registro_de_Usuario_Lista.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Registro_de_Usuario_Lista.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Registro_de_Usuario_Lista.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Registro_de_Usuario_Lista.aspx", true, null);
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
                return new JsonResult("Registro_de_Usuario_Catalogo.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Registro_de_Usuario_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Registro_de_Usuario_Catalogo.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Registro_de_Usuario_Catalogo.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Registro_de_Usuario_Catalogo.aspx", true, null);
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
    /*public void ddlUsuario_del_Sistema_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/

    

    


   private void managePostFoto_de_Perfil()
    {
    }

     protected void lkbVerFoto_de_Perfil_Click(object sender, EventArgs e)
	{
		int posIni = 0;
		int posFin = 0;
		string Extencion = "";
		Session["verClick"] = 1;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + txtFoto_de_Perfil.Text);
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


		posIni = lkbVerFoto_de_Perfil.Text.IndexOf(".", 0);
		posFin = lkbVerFoto_de_Perfil.Text.Length - 1 - (posIni - 1);
		Extencion = lkbVerFoto_de_Perfil.Text.Substring(posIni, posFin);
		if (Extencion.ToUpper() == ".JPG" || Extencion.ToUpper() == ".GIF" || Extencion.ToUpper() == ".BMP"){
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "OpenImage('TempFiles/" + NombreArchivo + "')", true);
		}else{
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "var myWindow = window.open('TempFiles/" + NombreArchivo + "','archivo'); myWindow.focus();", true);
		}
			
	}

	protected void IbtnCambiarArchivoFoto_de_Perfil_Click(object sender, ImageClickEventArgs e)
	{
                                fuaFoto_de_Perfil.Visible = true;
                                buttonSubmitFoto_de_Perfil.Visible = true;
                                labelNoResultsFoto_de_Perfil.Visible = true;
                                repeaterResultsFoto_de_Perfil.Visible = true;
                                //-------------------------------------------------
		lkbVerFoto_de_Perfil.Visible = false;
		Session["CambiarArchivo"] = 1;
		IbtnCambiarArchivoFoto_de_Perfil.Visible = false;
		IbtnBorrarArchivoFoto_de_Perfil.Visible = false;
		//Borrar archivo temporal
		File.Delete(Server.MapPath("TempFiles/" + lkbVerFoto_de_Perfil.Text));
		//-------------------------
		cvRadUploadFoto_de_Perfil.Enabled = true;
        cvRadUploadFoto_de_Perfil.Visible = true;
        if (imgOblFoto_de_Perfil.Visible)
            RFVFoto_de_Perfil.Enabled = true; 
	}
	protected void IbtnBorrarArchivoFoto_de_Perfil_Click(object sender, ImageClickEventArgs e)
	{
		txtFoto_de_Perfil.Text = "";
		fuaFoto_de_Perfil.Visible = true;
                                buttonSubmitFoto_de_Perfil.Visible = true;
                                labelNoResultsFoto_de_Perfil.Visible = true;
                                repeaterResultsFoto_de_Perfil.Visible = true;
                                //-------------------------------------------------
		Session["CambiarArchivo"] = 0;
		lkbVerFoto_de_Perfil.Visible = false;
		lkbVerFoto_de_Perfil.Text = "";
		IbtnCambiarArchivoFoto_de_Perfil.Visible = false;
		IbtnBorrarArchivoFoto_de_Perfil.Visible = false;
		//-------------------------
		cvRadUploadFoto_de_Perfil.Enabled = true;
        cvRadUploadFoto_de_Perfil.Visible = true;
        if (imgOblFoto_de_Perfil.Visible)
            RFVFoto_de_Perfil.Enabled = true; 
	}
	protected void buttonSubmitFoto_de_Perfil_Click(object sender, System.EventArgs e)
  {
      if (fuaFoto_de_Perfil.UploadedFiles.Count > 0)
      {
          repeaterResultsFoto_de_Perfil.DataSource = fuaFoto_de_Perfil.UploadedFiles;
          repeaterResultsFoto_de_Perfil.DataBind();
          labelNoResultsFoto_de_Perfil.Visible = false;
          repeaterResultsFoto_de_Perfil.Visible = true;

          foreach (Telerik.Web.UI.UploadedFile validFile in fuaFoto_de_Perfil.UploadedFiles)
          {
              Session["ArchivoFoto_de_Perfil"] = validFile.GetName();
              RFVFoto_de_Perfil.Enabled = false;
          }
      }
      else
      {
          labelNoResultsFoto_de_Perfil.Visible = true;
          repeaterResultsFoto_de_Perfil.Visible = false;
      }
      Session["PageLoad"] = "1";
  }
  protected void fuaFoto_de_Perfil_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
  {
      int counter = 1;

      Telerik.Web.UI.UploadedFile file = e.UploadedFile;

      string targetFolder = Server.MapPath(fuaFoto_de_Perfil.TargetFolder);

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

