/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo Registro_de_Contenido
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
using App_Code.Consumer;
using System.Web.Script.Serialization;

namespace WebForms
{	
public partial class Registro_de_Contenido_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();
    private WSRegistro_de_Contenido.GlobalData userData;
    public int iProcess = 29982;
    private String sDNTNombre = "Registro_de_Contenido";
    private String sDNTDescripcion = "Registro de Contenido";
    private String scallBackReturnVariable = null;
    public class ComboInfo
    {
        public string ComboId { get; set; }
        public string ComboName { get; set; }
    }
    public List<ComboInfo> ComboInformation { get; set; }
        private List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas> myMultiEtiquetasArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>();
        private List<WSRegistro_de_Contenido.objectBussinessFuentes> myMultiFuentesArray = new List<WSRegistro_de_Contenido.objectBussinessFuentes>();
        private List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio> myMultiNotificaciones_por_ObservatoriosArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>();
        private List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario> myMultiNotificaciones_por_UsuarioArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>();


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
        
                    if (multiRenlgonName == "Etiquetas")
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataEtiquetas = myMultiEtiquetasArray.Find(p => p.Clave == key);
             if (myDataEtiquetas == null)
            {
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count);
                myDataEtiquetas = myMultiEtiquetasArray.Find(p => p.Clave == key);
            }
            if (myDataEtiquetas.Clave == null)
            {
                myDataEtiquetas.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count);
            }
            if (commandName == "Delete")
            {
                myDataEtiquetas = myMultiEtiquetasArray.Find(p => p.Clave == key);
                    if (myDataEtiquetas != null)
                        myMultiEtiquetasArray.Remove(myDataEtiquetas);
            }
            if (commandName == "Edit")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "29989";
                Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "29989";
                Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                switch (columName)
                {                    
        

                        case "Etiqueta":
                            {
                                myDataEtiquetas.Etiqueta = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
            }       

        }

        if (multiRenlgonName == "Fuentes")
        {
            WSRegistro_de_Contenido.objectBussinessFuentes myDataFuentes = myMultiFuentesArray.Find(p => p.Clave == key);
             if (myDataFuentes == null)
            {
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count);
                myDataFuentes = myMultiFuentesArray.Find(p => p.Clave == key);
            }
            if (myDataFuentes.Clave == null)
            {
                myDataFuentes.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count);
            }
            if (commandName == "Delete")
            {
                myDataFuentes = myMultiFuentesArray.Find(p => p.Clave == key);
                    if (myDataFuentes != null)
                        myMultiFuentesArray.Remove(myDataFuentes);
            }
            if (commandName == "Edit")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "30048";
                Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "30048";
                Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                switch (columName)
                {                    
        

                        case "Fuente":
                            {
                                myDataFuentes.Fuente = ValueData;
                                break;
                            }

                }   
            }       

        }

        if (multiRenlgonName == "Notificaciones_por_Observatorios")
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray.Find(p => p.Clave == key);
             if (myDataNotificaciones_por_Observatorios == null)
            {
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count);
                myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray.Find(p => p.Clave == key);
            }
            if (myDataNotificaciones_por_Observatorios.Clave == null)
            {
                myDataNotificaciones_por_Observatorios.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count);
            }
            if (commandName == "Delete")
            {
                myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray.Find(p => p.Clave == key);
                    if (myDataNotificaciones_por_Observatorios != null)
                        myMultiNotificaciones_por_ObservatoriosArray.Remove(myDataNotificaciones_por_Observatorios);
            }
            if (commandName == "Edit")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "31010";
                Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "31010";
                Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                switch (columName)
                {                    
        

                        case "Notificar":
                            {
                                if (ValueData == "")
                                    ValueData = "0";
                                myDataNotificaciones_por_Observatorios.Notificar = bool.Parse(ValueData);
                                break;
                            }
                        case "Observatorio":
                            {
                                myDataNotificaciones_por_Observatorios.Observatorio = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
            }       

        }

        if (multiRenlgonName == "Notificaciones_por_Usuario")
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray.Find(p => p.Clave == key);
             if (myDataNotificaciones_por_Usuario == null)
            {
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count);
                myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray.Find(p => p.Clave == key);
            }
            if (myDataNotificaciones_por_Usuario.Clave == null)
            {
                myDataNotificaciones_por_Usuario.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count);
            }
            if (commandName == "Delete")
            {
                myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray.Find(p => p.Clave == key);
                    if (myDataNotificaciones_por_Usuario != null)
                        myMultiNotificaciones_por_UsuarioArray.Remove(myDataNotificaciones_por_Usuario);
            }
            if (commandName == "Edit")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "31011";
                Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                Session["LlavePopup"] = key;
                Session["idProcesoPopup"] = "31011";
                Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                switch (columName)
                {                    
        

                        case "Notificar":
                            {
                                if (ValueData == "")
                                    ValueData = "0";
                                myDataNotificaciones_por_Usuario.Notificar = bool.Parse(ValueData);
                                break;
                            }
                        case "Observatorio":
                            {
                                myDataNotificaciones_por_Usuario.Observatorio = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "ID_del_Cliente":
                            {
                                myDataNotificaciones_por_Usuario.ID_del_Cliente = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Nombre":
                            {
                                myDataNotificaciones_por_Usuario.Nombre = ValueData;
                                break;
                            }

                }   
            }       

        }

            
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

            ajaxSM.RegisterPostBackControl(buttonSubmitImagen);
    ajaxSM.RegisterPostBackControl(buttonSubmitImagen_Miniatura);
    ajaxSM.RegisterPostBackControl(buttonSubmitAdjuntar_PDF);

        
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
            txtFecha_de_Compromiso.Culture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureMX"].ToString(), true); 
            txtFecha_de_Compromiso.DateInput.DisplayDateFormat = System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString();
            txtFecha_de_Revision.Culture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureMX"].ToString(), true); 
            txtFecha_de_Revision.DateInput.DisplayDateFormat = System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString();
            txtFecha_de_Inicio_de_Publicacion.Culture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureMX"].ToString(), true); 
            txtFecha_de_Inicio_de_Publicacion.DateInput.DisplayDateFormat = System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString();
            txtFecha_de_Termino.Culture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureMX"].ToString(), true); 
            txtFecha_de_Termino.DateInput.DisplayDateFormat = System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaMostrar"].ToString();

                    Session["myMultiEtiquetas"] = null;
            myMultiEtiquetasArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>();
            Session["myMultiFuentes"] = null;
            myMultiFuentesArray = new List<WSRegistro_de_Contenido.objectBussinessFuentes>();
            Session["myMultiNotificaciones_por_Observatorios"] = null;
            myMultiNotificaciones_por_ObservatoriosArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>();
            Session["myMultiNotificaciones_por_Usuario"] = null;
            myMultiNotificaciones_por_UsuarioArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>();

	
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
            SetSeguridadPorProcesoEtiquetas();

            SetSeguridadPorProcesoFuentes();

            SetSeguridadPorProcesoNotificaciones_por_Observatorios();

            SetSeguridadPorProcesoNotificaciones_por_Usuario();


        }

            //if (fuaImagen.IsPosting)
            //this.managePostImagen();            //if (fuaImagen_Miniatura.IsPosting)
            //this.managePostImagen_Miniatura();            //if (fuaAdjuntar_PDF.IsPosting)
            //this.managePostAdjuntar_PDF();

        if (Session["myMultiEtiquetas"] != null)
                    myMultiEtiquetasArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>)Session["myMultiEtiquetas"];

        if (Session["myMultiFuentes"] != null)
                    myMultiFuentesArray = (List<WSRegistro_de_Contenido.objectBussinessFuentes>)Session["myMultiFuentes"];

        if (Session["myMultiNotificaciones_por_Observatorios"] != null)
                    myMultiNotificaciones_por_ObservatoriosArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>)Session["myMultiNotificaciones_por_Observatorios"];

        if (Session["myMultiNotificaciones_por_Usuario"] != null)
                    myMultiNotificaciones_por_UsuarioArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>)Session["myMultiNotificaciones_por_Usuario"];



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
                    case "29989":
                        if (Session["TipoAccionPopup"].ToString()=="1")
                            TTbcEditEtiquetas.Catalogo_Click(Llave);
                        else
                            TTbcConsultEtiquetas.Catalogo_Click(Llave);
                        break;
                    case "30048":
                        if (Session["TipoAccionPopup"].ToString()=="1")
                            TTbcEditFuentes.Catalogo_Click(Llave);
                        else
                            TTbcConsultFuentes.Catalogo_Click(Llave);
                        break;
                    case "31010":
                        if (Session["TipoAccionPopup"].ToString()=="1")
                            TTbcEditNotificaciones_por_Observatorios.Catalogo_Click(Llave);
                        else
                            TTbcConsultNotificaciones_por_Observatorios.Catalogo_Click(Llave);
                        break;
                    case "31011":
                        if (Session["TipoAccionPopup"].ToString()=="1")
                            TTbcEditNotificaciones_por_Usuario.Catalogo_Click(Llave);
                        else
                            TTbcConsultNotificaciones_por_Usuario.Catalogo_Click(Llave);
                        break;

                }
            }
        }
        GC.Collect();

    }

    protected void SetSeguridadPorProcesoEtiquetas()
    {
        bool SinPermisoNuevo = true;
        grdMultiEtiquetas.Columns[1].Visible = false; //icono editar
        grdMultiEtiquetas.Columns[0].Visible = false; //icono borrrar
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
        com.Parameters.AddWithValue("@IdUsuario", int.Parse(Session["globalUsuarioClave"].ToString()) );
        com.Parameters.AddWithValue("@IdProceso", 29989);
        DataSet ds = db.Consulta(com);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            switch (dr["IdOperacion"].ToString())
            {
                case "1": //NUEVO
                    SinPermisoNuevo = false;
                    break;
                case "2": //MODIFICAR
                    grdMultiEtiquetas.Columns[1].Visible = true; //icono editar
                    break;
                case "3": //BORRAR
                    grdMultiEtiquetas.Columns[0].Visible = true; //icono borrrar
                    break;
            }
        }
        if (SinPermisoNuevo)
        {
            cmdNewEtiquetas.Visible = false;
            TTbcNewEtiquetas.Visible = false;
        }
        db.Dispose();
        com.Dispose();
        ds.Dispose();
    }

    protected void SetSeguridadPorProcesoFuentes()
    {
        bool SinPermisoNuevo = true;
        grdMultiFuentes.Columns[1].Visible = false; //icono editar
        grdMultiFuentes.Columns[0].Visible = false; //icono borrrar
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
        com.Parameters.AddWithValue("@IdUsuario", int.Parse(Session["globalUsuarioClave"].ToString()) );
        com.Parameters.AddWithValue("@IdProceso", 30048);
        DataSet ds = db.Consulta(com);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            switch (dr["IdOperacion"].ToString())
            {
                case "1": //NUEVO
                    SinPermisoNuevo = false;
                    break;
                case "2": //MODIFICAR
                    grdMultiFuentes.Columns[1].Visible = true; //icono editar
                    break;
                case "3": //BORRAR
                    grdMultiFuentes.Columns[0].Visible = true; //icono borrrar
                    break;
            }
        }
        if (SinPermisoNuevo)
        {
            cmdNewFuentes.Visible = false;
            TTbcNewFuentes.Visible = false;
        }
        db.Dispose();
        com.Dispose();
        ds.Dispose();
    }

    protected void SetSeguridadPorProcesoNotificaciones_por_Observatorios()
    {
        bool SinPermisoNuevo = true;
        grdMultiNotificaciones_por_Observatorios.Columns[1].Visible = false; //icono editar
        grdMultiNotificaciones_por_Observatorios.Columns[0].Visible = false; //icono borrrar
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
        com.Parameters.AddWithValue("@IdUsuario", int.Parse(Session["globalUsuarioClave"].ToString()) );
        com.Parameters.AddWithValue("@IdProceso", 31010);
        DataSet ds = db.Consulta(com);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            switch (dr["IdOperacion"].ToString())
            {
                case "1": //NUEVO
                    SinPermisoNuevo = false;
                    break;
                case "2": //MODIFICAR
                    grdMultiNotificaciones_por_Observatorios.Columns[1].Visible = true; //icono editar
                    break;
                case "3": //BORRAR
                    grdMultiNotificaciones_por_Observatorios.Columns[0].Visible = true; //icono borrrar
                    break;
            }
        }
        if (SinPermisoNuevo)
        {
            cmdNewNotificaciones_por_Observatorios.Visible = false;
            TTbcNewNotificaciones_por_Observatorios.Visible = false;
        }
        db.Dispose();
        com.Dispose();
        ds.Dispose();
    }

    protected void SetSeguridadPorProcesoNotificaciones_por_Usuario()
    {
        bool SinPermisoNuevo = true;
        grdMultiNotificaciones_por_Usuario.Columns[1].Visible = false; //icono editar
        grdMultiNotificaciones_por_Usuario.Columns[0].Visible = false; //icono borrrar
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
        com.Parameters.AddWithValue("@IdUsuario", int.Parse(Session["globalUsuarioClave"].ToString()) );
        com.Parameters.AddWithValue("@IdProceso", 31011);
        DataSet ds = db.Consulta(com);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            switch (dr["IdOperacion"].ToString())
            {
                case "1": //NUEVO
                    SinPermisoNuevo = false;
                    break;
                case "2": //MODIFICAR
                    grdMultiNotificaciones_por_Usuario.Columns[1].Visible = true; //icono editar
                    break;
                case "3": //BORRAR
                    grdMultiNotificaciones_por_Usuario.Columns[0].Visible = true; //icono borrrar
                    break;
            }
        }
        if (SinPermisoNuevo)
        {
            cmdNewNotificaciones_por_Usuario.Visible = false;
            TTbcNewNotificaciones_por_Usuario.Visible = false;
        }
        db.Dispose();
        com.Dispose();
        ds.Dispose();
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
            //Multirenglon grdMultiEtiquetas
            

            grdMultiEtiquetas.Columns[1+2].HeaderText = MyTraductor.getTextDTID(141077, grdMultiEtiquetas.Columns[1+2].HeaderText); //Etiqueta
            lblShowMultiEtiquetas.Text = MensajeMostrar;

            //Multirenglon grdMultiFuentes
            

            grdMultiFuentes.Columns[1+2].HeaderText = MyTraductor.getTextDTID(141904, grdMultiFuentes.Columns[1+2].HeaderText); //Fuente
            lblShowMultiFuentes.Text = MensajeMostrar;

            //Multirenglon grdMultiNotificaciones_por_Observatorios
            

            grdMultiNotificaciones_por_Observatorios.Columns[1+2].HeaderText = MyTraductor.getTextDTID(149689, grdMultiNotificaciones_por_Observatorios.Columns[1+2].HeaderText); //Notificar
            lblShowMultiNotificaciones_por_Observatorios.Text = MensajeMostrar;
            grdMultiNotificaciones_por_Observatorios.Columns[2+2].HeaderText = MyTraductor.getTextDTID(149690, grdMultiNotificaciones_por_Observatorios.Columns[2+2].HeaderText); //Observatorio
            lblShowMultiNotificaciones_por_Observatorios.Text = MensajeMostrar;

            //Multirenglon grdMultiNotificaciones_por_Usuario
            

            grdMultiNotificaciones_por_Usuario.Columns[1+2].HeaderText = MyTraductor.getTextDTID(149693, grdMultiNotificaciones_por_Usuario.Columns[1+2].HeaderText); //Notificar
            lblShowMultiNotificaciones_por_Usuario.Text = MensajeMostrar;
            grdMultiNotificaciones_por_Usuario.Columns[2+2].HeaderText = MyTraductor.getTextDTID(149694, grdMultiNotificaciones_por_Usuario.Columns[2+2].HeaderText); //Observatorio
            lblShowMultiNotificaciones_por_Usuario.Text = MensajeMostrar;
            grdMultiNotificaciones_por_Usuario.Columns[3+2].HeaderText = MyTraductor.getTextDTID(149695, grdMultiNotificaciones_por_Usuario.Columns[3+2].HeaderText); //ID_del_Cliente
            lblShowMultiNotificaciones_por_Usuario.Text = MensajeMostrar;
            grdMultiNotificaciones_por_Usuario.Columns[4+2].HeaderText = MyTraductor.getTextDTID(149696, grdMultiNotificaciones_por_Usuario.Columns[4+2].HeaderText); //Nombre
            lblShowMultiNotificaciones_por_Usuario.Text = MensajeMostrar;


        }
        catch
        { }
    }

    protected void RevisaLoadArchivo()
    {
        if (Session["CambiarArchivo"]!=null)
        if (Session["CambiarArchivo"].ToString() == "0")
        {
                            fuaImagen.Visible = true;
                buttonSubmitImagen.Visible = true;
                labelNoResultsImagen.Visible = true;
                repeaterResultsImagen.Visible = true;
                //----------------------------------------------------
                lkbVerImagen.Visible = false;
                IbtnCambiarArchivoImagen.Visible = false;
                IbtnBorrarArchivoImagen.Visible = false;
                Session["ArchivoImagen"] = null;
                               fuaImagen_Miniatura.Visible = true;
                buttonSubmitImagen_Miniatura.Visible = true;
                labelNoResultsImagen_Miniatura.Visible = true;
                repeaterResultsImagen_Miniatura.Visible = true;
                //----------------------------------------------------
                lkbVerImagen_Miniatura.Visible = false;
                IbtnCambiarArchivoImagen_Miniatura.Visible = false;
                IbtnBorrarArchivoImagen_Miniatura.Visible = false;
                Session["ArchivoImagen_Miniatura"] = null;
                               fuaAdjuntar_PDF.Visible = true;
                buttonSubmitAdjuntar_PDF.Visible = true;
                labelNoResultsAdjuntar_PDF.Visible = true;
                repeaterResultsAdjuntar_PDF.Visible = true;
                //----------------------------------------------------
                lkbVerAdjuntar_PDF.Visible = false;
                IbtnCambiarArchivoAdjuntar_PDF.Visible = false;
                IbtnBorrarArchivoAdjuntar_PDF.Visible = false;
                Session["ArchivoAdjuntar_PDF"] = null;
               
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
        lstObservatorio.Enabled=false;
        ddlCategoria.Enabled=false;
        TTbcCategoria.ImgButton.Visible = false;

        txtDescripcion_de_Solicitud.Enabled=false;
        ddlReportero_Asignado.Enabled=false;
        TTbcReportero_Asignado.ImgButton.Visible = false;

        txtFecha_de_Compromiso.Enabled=false;
        ddlEstatus.Enabled=false;
        TTbcEstatus.ImgButton.Visible = false;

        ddlAdministrador_de_Observatorio.Enabled=false;
        TTbcAdministrador_de_Observatorio.ImgButton.Visible = false;

        ddlReportero.Enabled=false;
        TTbcReportero.ImgButton.Visible = false;

        txtTitulo.Enabled=false;
        txtDescripcion.Enabled=false;
        txtContenido.Enabled=false;
        ddlEstilo.Enabled=false;
        TTbcEstilo.ImgButton.Visible = false;

        grdMultiEtiquetas.Enabled = false; 
        cmdNewEtiquetas.Enabled = false;
        grdMultiFuentes.Enabled = false; 
        cmdNewFuentes.Enabled = false;
        ChCaptura_Terminada.Enabled=false;
        ddlAutorizado_por.Enabled=false;
        TTbcAutorizado_por.ImgButton.Visible = false;

        txtFecha_de_Revision.Enabled=false;
        txtHora_de_Revision.Enabled=false;
        ddlAutorizacion.Enabled=false;
        TTbcAutorizacion.ImgButton.Visible = false;

        txtMotivo_de_Rechazo.Enabled=false;
        txtFecha_de_Inicio_de_Publicacion.Enabled=false;
        txtFecha_de_Termino.Enabled=false;
        ChSeleccionar_Todos_los_Observatorios.Enabled=false;
        grdMultiNotificaciones_por_Observatorios.Enabled = false; 
        cmdNewNotificaciones_por_Observatorios.Enabled = false;
        ddlFiltrar_Usuarios_por_Observatorio.Enabled=false;
        TTbcFiltrar_Usuarios_por_Observatorio.ImgButton.Visible = false;

        grdMultiNotificaciones_por_Usuario.Enabled = false; 
        cmdNewNotificaciones_por_Usuario.Enabled = false;

                    if (lkbVerImagen.Visible)
            {
                IbtnBorrarArchivoImagen.Visible = false;
                IbtnCambiarArchivoImagen.Visible = false;
            }
            else
            {
                fuaImagen.Enabled = false;
            }

            labelNoResultsImagen.Visible = false;
            buttonSubmitImagen.Enabled = false;
            RFVImagen.Visible = false;
            if (lkbVerImagen_Miniatura.Visible)
            {
                IbtnBorrarArchivoImagen_Miniatura.Visible = false;
                IbtnCambiarArchivoImagen_Miniatura.Visible = false;
            }
            else
            {
                fuaImagen_Miniatura.Enabled = false;
            }

            labelNoResultsImagen_Miniatura.Visible = false;
            buttonSubmitImagen_Miniatura.Enabled = false;
            RFVImagen_Miniatura.Visible = false;
            if (lkbVerAdjuntar_PDF.Visible)
            {
                IbtnBorrarArchivoAdjuntar_PDF.Visible = false;
                IbtnCambiarArchivoAdjuntar_PDF.Visible = false;
            }
            else
            {
                fuaAdjuntar_PDF.Enabled = false;
            }

            labelNoResultsAdjuntar_PDF.Visible = false;
            buttonSubmitAdjuntar_PDF.Enabled = false;
            RFVAdjuntar_PDF.Visible = false;
    
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
        int iProcess = 29982;
        TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
        string updateKey;
	        List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas> myMultiEtiquetasArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>();
        List<WSRegistro_de_Contenido.objectBussinessFuentes> myMultiFuentesArray = new List<WSRegistro_de_Contenido.objectBussinessFuentes>();
        List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio> myMultiNotificaciones_por_ObservatoriosArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>();
        List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario> myMultiNotificaciones_por_UsuarioArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>();


	        if (HttpContext.Current.Session["myMultiEtiquetas"] != null)
                    myMultiEtiquetasArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>)HttpContext.Current.Session["myMultiEtiquetas"];

        if (HttpContext.Current.Session["myMultiFuentes"] != null)
                    myMultiFuentesArray = (List<WSRegistro_de_Contenido.objectBussinessFuentes>)HttpContext.Current.Session["myMultiFuentes"];

        if (HttpContext.Current.Session["myMultiNotificaciones_por_Observatorios"] != null)
                    myMultiNotificaciones_por_ObservatoriosArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>)HttpContext.Current.Session["myMultiNotificaciones_por_Observatorios"];

        if (HttpContext.Current.Session["myMultiNotificaciones_por_Usuario"] != null)
                    myMultiNotificaciones_por_UsuarioArray = (List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>)HttpContext.Current.Session["myMultiNotificaciones_por_Usuario"];



        int? key = MyFunctions.FormatNumberNull(Skey);
        Control grvControl = new Control();
        updateKey = string.Empty;
        int rowIndex = !string.IsNullOrEmpty(Skey) ? int.Parse(Skey) - 1 : -1;
        #endregion


	        if (multiRenlgonName == "Etiquetas")
        {
            if (commandName == "Add")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataEtiquetas = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas();
                myDataEtiquetas.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count + 1);
                myMultiEtiquetasArray.Add(myDataEtiquetas);
            }


            if (commandName == "Delete")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataEtiquetas;

                //if (myMultiEtiquetasArray.Count == 1)
                //{
                    //myDataEtiquetas = myMultiEtiquetasArray[rowIndex];
                    //myMultiEtiquetasArray.Remove(myDataEtiquetas);

                    //myDataEtiquetas = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas();
                    //myDataEtiquetas.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count + 1);
                    //myMultiEtiquetasArray.Add(myDataEtiquetas);
                //}
                //else
                //{
                    myDataEtiquetas = myMultiEtiquetasArray.Find(p => p.Clave == key); 
                    myMultiEtiquetasArray.Remove(myDataEtiquetas);
                    
                //}
            }

            if (commandName == "Edit")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "29989";
                HttpContext.Current.Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "29989";
                HttpContext.Current.Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataEtiquetas = myMultiEtiquetasArray.Find(p => p.Clave == key); 
                switch (columName)
                {                    
        

                        case "Etiqueta":
                            {
                                myDataEtiquetas.Etiqueta = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
            }       
        }

        if (multiRenlgonName == "Fuentes")
        {
            if (commandName == "Add")
            {
                WSRegistro_de_Contenido.objectBussinessFuentes myDataFuentes = new WSRegistro_de_Contenido.objectBussinessFuentes();
                myDataFuentes.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count + 1);
                myMultiFuentesArray.Add(myDataFuentes);
            }


            if (commandName == "Delete")
            {
                WSRegistro_de_Contenido.objectBussinessFuentes myDataFuentes;

                //if (myMultiFuentesArray.Count == 1)
                //{
                    //myDataFuentes = myMultiFuentesArray[rowIndex];
                    //myMultiFuentesArray.Remove(myDataFuentes);

                    //myDataFuentes = new WSRegistro_de_Contenido.objectBussinessFuentes();
                    //myDataFuentes.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count + 1);
                    //myMultiFuentesArray.Add(myDataFuentes);
                //}
                //else
                //{
                    myDataFuentes = myMultiFuentesArray.Find(p => p.Clave == key); 
                    myMultiFuentesArray.Remove(myDataFuentes);
                    
                //}
            }

            if (commandName == "Edit")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "30048";
                HttpContext.Current.Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "30048";
                HttpContext.Current.Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                WSRegistro_de_Contenido.objectBussinessFuentes myDataFuentes = myMultiFuentesArray.Find(p => p.Clave == key); 
                switch (columName)
                {                    
        

                        case "Fuente":
                            {
                                myDataFuentes.Fuente = ValueData;
                                break;
                            }

                }   
            }       
        }

        if (multiRenlgonName == "Notificaciones_por_Observatorios")
        {
            if (commandName == "Add")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataNotificaciones_por_Observatorios = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                myDataNotificaciones_por_Observatorios.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count + 1);
                myMultiNotificaciones_por_ObservatoriosArray.Add(myDataNotificaciones_por_Observatorios);
            }


            if (commandName == "Delete")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataNotificaciones_por_Observatorios;

                //if (myMultiNotificaciones_por_ObservatoriosArray.Count == 1)
                //{
                    //myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray[rowIndex];
                    //myMultiNotificaciones_por_ObservatoriosArray.Remove(myDataNotificaciones_por_Observatorios);

                    //myDataNotificaciones_por_Observatorios = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio();
                    //myDataNotificaciones_por_Observatorios.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count + 1);
                    //myMultiNotificaciones_por_ObservatoriosArray.Add(myDataNotificaciones_por_Observatorios);
                //}
                //else
                //{
                    myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray.Find(p => p.Clave == key); 
                    myMultiNotificaciones_por_ObservatoriosArray.Remove(myDataNotificaciones_por_Observatorios);
                    
                //}
            }

            if (commandName == "Edit")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "31010";
                HttpContext.Current.Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "31010";
                HttpContext.Current.Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataNotificaciones_por_Observatorios = myMultiNotificaciones_por_ObservatoriosArray.Find(p => p.Clave == key); 
                switch (columName)
                {                    
        

                        case "Notificar":
                            {
                                if (ValueData == "")
                                    ValueData = "0";
                                myDataNotificaciones_por_Observatorios.Notificar = bool.Parse(ValueData);
                                break;
                            }
                        case "Observatorio":
                            {
                                myDataNotificaciones_por_Observatorios.Observatorio = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
            }       
        }

        if (multiRenlgonName == "Notificaciones_por_Usuario")
        {
            if (commandName == "Add")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataNotificaciones_por_Usuario = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario();
                myDataNotificaciones_por_Usuario.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count + 1);
                myMultiNotificaciones_por_UsuarioArray.Add(myDataNotificaciones_por_Usuario);
            }


            if (commandName == "Delete")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataNotificaciones_por_Usuario;

                //if (myMultiNotificaciones_por_UsuarioArray.Count == 1)
                //{
                    //myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray[rowIndex];
                    //myMultiNotificaciones_por_UsuarioArray.Remove(myDataNotificaciones_por_Usuario);

                    //myDataNotificaciones_por_Usuario = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario();
                    //myDataNotificaciones_por_Usuario.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count + 1);
                    //myMultiNotificaciones_por_UsuarioArray.Add(myDataNotificaciones_por_Usuario);
                //}
                //else
                //{
                    myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray.Find(p => p.Clave == key); 
                    myMultiNotificaciones_por_UsuarioArray.Remove(myDataNotificaciones_por_Usuario);
                    
                //}
            }

            if (commandName == "Edit")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "31011";
                HttpContext.Current.Session["TipoAccionPopup"] = "1";
            }

            if (commandName == "Consult")
            {
                HttpContext.Current.Session["LlavePopup"] = key;
                HttpContext.Current.Session["idProcesoPopup"] = "31011";
                HttpContext.Current.Session["TipoAccionPopup"] = "2";
            }            

               
            if (commandName == "Modify")
            {
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataNotificaciones_por_Usuario = myMultiNotificaciones_por_UsuarioArray.Find(p => p.Clave == key); 
                switch (columName)
                {                    
        

                        case "Notificar":
                            {
                                if (ValueData == "")
                                    ValueData = "0";
                                myDataNotificaciones_por_Usuario.Notificar = bool.Parse(ValueData);
                                break;
                            }
                        case "Observatorio":
                            {
                                myDataNotificaciones_por_Usuario.Observatorio = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "ID_del_Cliente":
                            {
                                myDataNotificaciones_por_Usuario.ID_del_Cliente = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Nombre":
                            {
                                myDataNotificaciones_por_Usuario.Nombre = ValueData;
                                break;
                            }

                }   
            }       
        }




	        HttpContext.Current.Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
        HttpContext.Current.Session["myMultiFuentes"] = myMultiFuentesArray;
        HttpContext.Current.Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
        HttpContext.Current.Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
		

        GC.Collect();

    }

    protected void RefreshMultirenglones()
    {
        WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido1 myDataRegistro_de_Contenido = myRegistro_de_Contenido.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()), true);
        myMultiEtiquetasArray.Clear();
        foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas itm in myDataRegistro_de_Contenido.Etiquetas)
            myMultiEtiquetasArray.Add(itm);
        
        if (Session["RNmyMultiEtiquetas"] == null)
        {
            Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
            grdMultiEtiquetas.DataSource = myMultiEtiquetasArray;
            grdMultiEtiquetas.DataBind();
        }
        else
        {
            autoPopulateEtiquetas(Session["RNmyMultiEtiquetas"] as object[]);
        }
        myMultiFuentesArray.Clear();
        foreach (WSRegistro_de_Contenido.objectBussinessFuentes itm in myDataRegistro_de_Contenido.Fuentes)
            myMultiFuentesArray.Add(itm);
        
        if (Session["RNmyMultiFuentes"] == null)
        {
            Session["myMultiFuentes"] = myMultiFuentesArray;
            grdMultiFuentes.DataSource = myMultiFuentesArray;
            grdMultiFuentes.DataBind();
        }
        else
        {
            autoPopulateFuentes(Session["RNmyMultiFuentes"] as object[]);
        }
        myMultiNotificaciones_por_ObservatoriosArray.Clear();
        foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio itm in myDataRegistro_de_Contenido.Notificaciones_por_Observatorios)
            myMultiNotificaciones_por_ObservatoriosArray.Add(itm);
        
        if (Session["RNmyMultiNotificaciones_por_Observatorios"] == null)
        {
            Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
            grdMultiNotificaciones_por_Observatorios.DataSource = myMultiNotificaciones_por_ObservatoriosArray;
            grdMultiNotificaciones_por_Observatorios.DataBind();
        }
        else
        {
            autoPopulateNotificaciones_por_Observatorios(Session["RNmyMultiNotificaciones_por_Observatorios"] as object[]);
        }
        myMultiNotificaciones_por_UsuarioArray.Clear();
        foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario itm in myDataRegistro_de_Contenido.Notificaciones_por_Usuario)
            myMultiNotificaciones_por_UsuarioArray.Add(itm);
        
        if (Session["RNmyMultiNotificaciones_por_Usuario"] == null)
        {
            Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
            grdMultiNotificaciones_por_Usuario.DataSource = myMultiNotificaciones_por_UsuarioArray;
            grdMultiNotificaciones_por_Usuario.DataBind();
        }
        else
        {
            autoPopulateNotificaciones_por_Usuario(Session["RNmyMultiNotificaciones_por_Usuario"] as object[]);
        }


    }

    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSRegistro_de_Contenido.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSRegistro_de_Contenido.GlobalDataLanguages)MyUserData.Language;
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
        TTbcUsuario_que_Registra.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataUsuario_que_Registra;
        TTbcUsuario_que_Registra.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcCategoria.WebControl = ddlCategoria;
        TTbcCategoria.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcCategoria.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataCategoria;
        TTbcCategoria.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcReportero_Asignado.WebControl = ddlReportero_Asignado;
        TTbcReportero_Asignado.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcReportero_Asignado.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataReportero_Asignado;
        TTbcReportero_Asignado.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcEstatus.WebControl = ddlEstatus;
        TTbcEstatus.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcEstatus.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataEstatus;
        TTbcEstatus.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcAdministrador_de_Observatorio.WebControl = ddlAdministrador_de_Observatorio;
        TTbcAdministrador_de_Observatorio.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcAdministrador_de_Observatorio.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataAdministrador_de_Observatorio;
        TTbcAdministrador_de_Observatorio.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcReportero.WebControl = ddlReportero;
        TTbcReportero.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcReportero.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataReportero;
        TTbcReportero.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcEstilo.WebControl = ddlEstilo;
        TTbcEstilo.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcEstilo.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataEstilo;
        TTbcEstilo.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcNewEtiquetas.WebControl = grdMultiEtiquetas;
        TTbcNewEtiquetas.FillDataControlFunction = RefreshMultirenglones;
        TTbcNewEtiquetas.ParentWebControl = null;

        TTbcEditEtiquetas.WebControl = grdMultiEtiquetas;
        TTbcEditEtiquetas.FillDataControlFunction = RefreshMultirenglones;
        TTbcEditEtiquetas.ParentWebControl = null;

        TTbcConsultEtiquetas.WebControl = grdMultiEtiquetas;
        TTbcConsultEtiquetas.FillDataControlFunction = RefreshMultirenglones;
        TTbcConsultEtiquetas.ParentWebControl = null;        //------------------------------------------------------------------------------------
        TTbcNewFuentes.WebControl = grdMultiFuentes;
        TTbcNewFuentes.FillDataControlFunction = RefreshMultirenglones;
        TTbcNewFuentes.ParentWebControl = null;

        TTbcEditFuentes.WebControl = grdMultiFuentes;
        TTbcEditFuentes.FillDataControlFunction = RefreshMultirenglones;
        TTbcEditFuentes.ParentWebControl = null;

        TTbcConsultFuentes.WebControl = grdMultiFuentes;
        TTbcConsultFuentes.FillDataControlFunction = RefreshMultirenglones;
        TTbcConsultFuentes.ParentWebControl = null;        //------------------------------------------------------------------------------------
        TTbcAutorizado_por.WebControl = ddlAutorizado_por;
        TTbcAutorizado_por.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcAutorizado_por.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataAutorizado_por;
        TTbcAutorizado_por.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcAutorizacion.WebControl = ddlAutorizacion;
        TTbcAutorizacion.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcAutorizacion.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataAutorizacion;
        TTbcAutorizacion.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcNewNotificaciones_por_Observatorios.WebControl = grdMultiNotificaciones_por_Observatorios;
        TTbcNewNotificaciones_por_Observatorios.FillDataControlFunction = RefreshMultirenglones;
        TTbcNewNotificaciones_por_Observatorios.ParentWebControl = null;

        TTbcEditNotificaciones_por_Observatorios.WebControl = grdMultiNotificaciones_por_Observatorios;
        TTbcEditNotificaciones_por_Observatorios.FillDataControlFunction = RefreshMultirenglones;
        TTbcEditNotificaciones_por_Observatorios.ParentWebControl = null;

        TTbcConsultNotificaciones_por_Observatorios.WebControl = grdMultiNotificaciones_por_Observatorios;
        TTbcConsultNotificaciones_por_Observatorios.FillDataControlFunction = RefreshMultirenglones;
        TTbcConsultNotificaciones_por_Observatorios.ParentWebControl = null;        //------------------------------------------------------------------------------------
        TTbcFiltrar_Usuarios_por_Observatorio.WebControl = ddlFiltrar_Usuarios_por_Observatorio;
        TTbcFiltrar_Usuarios_por_Observatorio.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcFiltrar_Usuarios_por_Observatorio.GetControlDataSetFunctionWithString = myRegistro_de_Contenido.FillDataFiltrar_Usuarios_por_Observatorio;
        TTbcFiltrar_Usuarios_por_Observatorio.ParentWebControl = null;
        //------------------------------------------------------------------------------------
        TTbcNewNotificaciones_por_Usuario.WebControl = grdMultiNotificaciones_por_Usuario;
        TTbcNewNotificaciones_por_Usuario.FillDataControlFunction = RefreshMultirenglones;
        TTbcNewNotificaciones_por_Usuario.ParentWebControl = null;

        TTbcEditNotificaciones_por_Usuario.WebControl = grdMultiNotificaciones_por_Usuario;
        TTbcEditNotificaciones_por_Usuario.FillDataControlFunction = RefreshMultirenglones;
        TTbcEditNotificaciones_por_Usuario.ParentWebControl = null;

        TTbcConsultNotificaciones_por_Usuario.WebControl = grdMultiNotificaciones_por_Usuario;
        TTbcConsultNotificaciones_por_Usuario.FillDataControlFunction = RefreshMultirenglones;
        TTbcConsultNotificaciones_por_Usuario.ParentWebControl = null;
        
        //-------------------------------------------------------------------------------------------------------------
        grdPagerEtiquetas.DataGrid = grdMultiEtiquetas;
grdPagerFuentes.DataGrid = grdMultiFuentes;
grdPagerNotificaciones_por_Observatorios.DataGrid = grdMultiNotificaciones_por_Observatorios;
grdPagerNotificaciones_por_Usuario.DataGrid = grdMultiNotificaciones_por_Usuario;

        //-------------------------------------------------------------------------------------------------------------
	Botones();
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
                    //Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
            //grdMultiEtiquetas.DataSource = myMultiEtiquetasArray;
            //grdMultiEtiquetas.DataBind();


            if (Session["RNmyMultiEtiquetas"] == null)
            {
            	Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
            	grdMultiEtiquetas.DataSource = myMultiEtiquetasArray;
            	grdMultiEtiquetas.DataBind();
            }
            else
            {
            	autoPopulateEtiquetas(Session["RNmyMultiEtiquetas"] as object[]);
            }
            //Session["myMultiFuentes"] = myMultiFuentesArray;
            //grdMultiFuentes.DataSource = myMultiFuentesArray;
            //grdMultiFuentes.DataBind();


            if (Session["RNmyMultiFuentes"] == null)
            {
            	Session["myMultiFuentes"] = myMultiFuentesArray;
            	grdMultiFuentes.DataSource = myMultiFuentesArray;
            	grdMultiFuentes.DataBind();
            }
            else
            {
            	autoPopulateFuentes(Session["RNmyMultiFuentes"] as object[]);
            }
            //Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
            //grdMultiNotificaciones_por_Observatorios.DataSource = myMultiNotificaciones_por_ObservatoriosArray;
            //grdMultiNotificaciones_por_Observatorios.DataBind();


            if (Session["RNmyMultiNotificaciones_por_Observatorios"] == null)
            {
            	Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
            	grdMultiNotificaciones_por_Observatorios.DataSource = myMultiNotificaciones_por_ObservatoriosArray;
            	grdMultiNotificaciones_por_Observatorios.DataBind();
            }
            else
            {
            	autoPopulateNotificaciones_por_Observatorios(Session["RNmyMultiNotificaciones_por_Observatorios"] as object[]);
            }
            //Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
            //grdMultiNotificaciones_por_Usuario.DataSource = myMultiNotificaciones_por_UsuarioArray;
            //grdMultiNotificaciones_por_Usuario.DataBind();


            if (Session["RNmyMultiNotificaciones_por_Usuario"] == null)
            {
            	Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
            	grdMultiNotificaciones_por_Usuario.DataSource = myMultiNotificaciones_por_UsuarioArray;
            	grdMultiNotificaciones_por_Usuario.DataBind();
            }
            else
            {
            	autoPopulateNotificaciones_por_Usuario(Session["RNmyMultiNotificaciones_por_Usuario"] as object[]);
            }

	
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
                MyFunctions.FillDataControl(ddlUsuario_que_Registra, myRegistro_de_Contenido.FillDataUsuario_que_Registra(""));
        MyFunctions.FillDataControl(lstObservatorio, myRegistro_de_Contenido.FillDataObservatorio());
        MyFunctions.FillDataControl(ddlCategoria, myRegistro_de_Contenido.FillDataCategoria(""));
        MyFunctions.FillDataControl(ddlReportero_Asignado, myRegistro_de_Contenido.FillDataReportero_Asignado(""));
        MyFunctions.FillDataControl(ddlEstatus, myRegistro_de_Contenido.FillDataEstatus(""));
        MyFunctions.FillDataControl(ddlAdministrador_de_Observatorio, myRegistro_de_Contenido.FillDataAdministrador_de_Observatorio(""));
        MyFunctions.FillDataControl(ddlReportero, myRegistro_de_Contenido.FillDataReportero(""));
        MyFunctions.FillDataControl(ddlEstilo, myRegistro_de_Contenido.FillDataEstilo(""));
        MyFunctions.FillDataControl(ddlAutorizado_por, myRegistro_de_Contenido.FillDataAutorizado_por(""));
        MyFunctions.FillDataControl(ddlAutorizacion, myRegistro_de_Contenido.FillDataAutorizacion(""));
        MyFunctions.FillDataControl(ddlFiltrar_Usuarios_por_Observatorio, myRegistro_de_Contenido.FillDataFiltrar_Usuarios_por_Observatorio(""));

    }
    private void New()
    {
                    //myMultiEtiquetasArray.Add(new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas());
            //myMultiFuentesArray.Add(new WSRegistro_de_Contenido.objectBussinessFuentes());
            //myMultiNotificaciones_por_ObservatoriosArray.Add(new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio());
            //myMultiNotificaciones_por_UsuarioArray.Add(new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario());

    }
    private void Modification()
    {
        WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido1 myDataRegistro_de_Contenido = myRegistro_de_Contenido.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()),true);
                if (myDataRegistro_de_Contenido.Folio.HasValue)
            txtFolio.Text = myDataRegistro_de_Contenido.Folio.ToString();
        if (myDataRegistro_de_Contenido.Usuario_que_Registra.HasValue)
           ddlUsuario_que_Registra.SelectedValue = myDataRegistro_de_Contenido.Usuario_que_Registra.Value.ToString().TrimEnd(' ');
        //ddlUsuario_que_Registra_SelectedIndexChanged(ddlUsuario_que_Registra, new EventArgs());
        if (myDataRegistro_de_Contenido.Fecha_de_Registro.HasValue)
            txtFecha_de_Registro.SelectedDate = myDataRegistro_de_Contenido.Fecha_de_Registro.Value;
        txtHora_de_Registro.SelectedDate = Funcion.FormatDateFromTextTime(myDataRegistro_de_Contenido.Hora_de_Registro);        if (myDataRegistro_de_Contenido.Observatorio != null)
        {
            for (int i = 0; i < myDataRegistro_de_Contenido.Observatorio.Length; i++)
                foreach(ListItem itm in lstObservatorio.Items)
                if (myDataRegistro_de_Contenido.Observatorio[i].Observatorio.ToString() == itm.Value)
                    itm.Selected = true;
        }
        if (myDataRegistro_de_Contenido.Categoria.HasValue)
           ddlCategoria.SelectedValue = myDataRegistro_de_Contenido.Categoria.Value.ToString().TrimEnd(' ');
        //ddlCategoria_SelectedIndexChanged(ddlCategoria, new EventArgs());
        txtDescripcion_de_Solicitud.Text = myDataRegistro_de_Contenido.Descripcion_de_Solicitud;
        if (myDataRegistro_de_Contenido.Reportero_Asignado.HasValue)
           ddlReportero_Asignado.SelectedValue = myDataRegistro_de_Contenido.Reportero_Asignado.Value.ToString().TrimEnd(' ');
        //ddlReportero_Asignado_SelectedIndexChanged(ddlReportero_Asignado, new EventArgs());
        if (myDataRegistro_de_Contenido.Fecha_de_Compromiso.HasValue)
            txtFecha_de_Compromiso.SelectedDate = myDataRegistro_de_Contenido.Fecha_de_Compromiso.Value;
        if (myDataRegistro_de_Contenido.Estatus.HasValue)
           ddlEstatus.SelectedValue = myDataRegistro_de_Contenido.Estatus.Value.ToString().TrimEnd(' ');
        //ddlEstatus_SelectedIndexChanged(ddlEstatus, new EventArgs());
        if (myDataRegistro_de_Contenido.Administrador_de_Observatorio.HasValue)
           ddlAdministrador_de_Observatorio.SelectedValue = myDataRegistro_de_Contenido.Administrador_de_Observatorio.Value.ToString().TrimEnd(' ');
        //ddlAdministrador_de_Observatorio_SelectedIndexChanged(ddlAdministrador_de_Observatorio, new EventArgs());
        if (myDataRegistro_de_Contenido.Reportero.HasValue)
           ddlReportero.SelectedValue = myDataRegistro_de_Contenido.Reportero.Value.ToString().TrimEnd(' ');
        //ddlReportero_SelectedIndexChanged(ddlReportero, new EventArgs());
        txtTitulo.Text = myDataRegistro_de_Contenido.Titulo;
        txtDescripcion.Text = myDataRegistro_de_Contenido.Descripcion;
        txtContenido.Text = myDataRegistro_de_Contenido.Contenido;
               if (myDataRegistro_de_Contenido.Imagen.HasValue){
            txtImagen.Text = myDataRegistro_de_Contenido.Imagen.Value.ToString();

            if (Session["CambiarArchivo"] == null)
                Session["CambiarArchivo"] = "0";

            if ((Session["CambiarArchivo"].ToString() == "0"))
            {
                if (txtImagen.Text != ""){
                  TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                  SqlCommand com = new SqlCommand("Select Nombre From TTArchivos where Folio=" + txtImagen.Text);
                  com.CommandType = CommandType.Text;

                  DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0){
                      fuaImagen.Visible = false;

                      lkbVerImagen.Visible = true;
                      IbtnBorrarArchivoImagen.Visible = true;
                      IbtnCambiarArchivoImagen.Visible = true;

                      lkbVerImagen.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();	
                        buttonSubmitImagen.Visible = false;
                        cvRadUploadImagen.Visible = false;
                        labelNoResultsImagen.Visible = false;
                        RFVImagen.Enabled = false; 
                    }
                }
            }
        }               if (myDataRegistro_de_Contenido.Imagen_Miniatura.HasValue){
            txtImagen_Miniatura.Text = myDataRegistro_de_Contenido.Imagen_Miniatura.Value.ToString();

            if (Session["CambiarArchivo"] == null)
                Session["CambiarArchivo"] = "0";

            if ((Session["CambiarArchivo"].ToString() == "0"))
            {
                if (txtImagen_Miniatura.Text != ""){
                  TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                  SqlCommand com = new SqlCommand("Select Nombre From TTArchivos where Folio=" + txtImagen_Miniatura.Text);
                  com.CommandType = CommandType.Text;

                  DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0){
                      fuaImagen_Miniatura.Visible = false;

                      lkbVerImagen_Miniatura.Visible = true;
                      IbtnBorrarArchivoImagen_Miniatura.Visible = true;
                      IbtnCambiarArchivoImagen_Miniatura.Visible = true;

                      lkbVerImagen_Miniatura.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();	
                        buttonSubmitImagen_Miniatura.Visible = false;
                        cvRadUploadImagen_Miniatura.Visible = false;
                        labelNoResultsImagen_Miniatura.Visible = false;
                        RFVImagen_Miniatura.Enabled = false; 
                    }
                }
            }
        }        if (myDataRegistro_de_Contenido.Estilo.HasValue)
           ddlEstilo.SelectedValue = myDataRegistro_de_Contenido.Estilo.Value.ToString().TrimEnd(' ');
        //ddlEstilo_SelectedIndexChanged(ddlEstilo, new EventArgs());
               if (myDataRegistro_de_Contenido.Adjuntar_PDF.HasValue){
            txtAdjuntar_PDF.Text = myDataRegistro_de_Contenido.Adjuntar_PDF.Value.ToString();

            if (Session["CambiarArchivo"] == null)
                Session["CambiarArchivo"] = "0";

            if ((Session["CambiarArchivo"].ToString() == "0"))
            {
                if (txtAdjuntar_PDF.Text != ""){
                  TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                  SqlCommand com = new SqlCommand("Select Nombre From TTArchivos where Folio=" + txtAdjuntar_PDF.Text);
                  com.CommandType = CommandType.Text;

                  DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0){
                      fuaAdjuntar_PDF.Visible = false;

                      lkbVerAdjuntar_PDF.Visible = true;
                      IbtnBorrarArchivoAdjuntar_PDF.Visible = true;
                      IbtnCambiarArchivoAdjuntar_PDF.Visible = true;

                      lkbVerAdjuntar_PDF.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();	
                        buttonSubmitAdjuntar_PDF.Visible = false;
                        cvRadUploadAdjuntar_PDF.Visible = false;
                        labelNoResultsAdjuntar_PDF.Visible = false;
                        RFVAdjuntar_PDF.Enabled = false; 
                    }
                }
            }
        }       ChCaptura_Terminada.Checked  = myDataRegistro_de_Contenido.Captura_Terminada;
        if (myDataRegistro_de_Contenido.Autorizado_por.HasValue)
           ddlAutorizado_por.SelectedValue = myDataRegistro_de_Contenido.Autorizado_por.Value.ToString().TrimEnd(' ');
        //ddlAutorizado_por_SelectedIndexChanged(ddlAutorizado_por, new EventArgs());
        if (myDataRegistro_de_Contenido.Fecha_de_Revision.HasValue)
            txtFecha_de_Revision.SelectedDate = myDataRegistro_de_Contenido.Fecha_de_Revision.Value;
        txtHora_de_Revision.SelectedDate = Funcion.FormatDateFromTextTime(myDataRegistro_de_Contenido.Hora_de_Revision);        if (myDataRegistro_de_Contenido.Autorizacion.HasValue)
           ddlAutorizacion.SelectedValue = myDataRegistro_de_Contenido.Autorizacion.Value.ToString().TrimEnd(' ');
        //ddlAutorizacion_SelectedIndexChanged(ddlAutorizacion, new EventArgs());
        txtMotivo_de_Rechazo.Text = myDataRegistro_de_Contenido.Motivo_de_Rechazo;
        if (myDataRegistro_de_Contenido.Fecha_de_Inicio_de_Publicacion.HasValue)
            txtFecha_de_Inicio_de_Publicacion.SelectedDate = myDataRegistro_de_Contenido.Fecha_de_Inicio_de_Publicacion.Value;
        if (myDataRegistro_de_Contenido.Fecha_de_Termino.HasValue)
            txtFecha_de_Termino.SelectedDate = myDataRegistro_de_Contenido.Fecha_de_Termino.Value;
       ChSeleccionar_Todos_los_Observatorios.Checked  = myDataRegistro_de_Contenido.Seleccionar_Todos_los_Observatorios;
        if (myDataRegistro_de_Contenido.Filtrar_Usuarios_por_Observatorio.HasValue)
           ddlFiltrar_Usuarios_por_Observatorio.SelectedValue = myDataRegistro_de_Contenido.Filtrar_Usuarios_por_Observatorio.Value.ToString().TrimEnd(' ');
        //ddlFiltrar_Usuarios_por_Observatorio_SelectedIndexChanged(ddlFiltrar_Usuarios_por_Observatorio, new EventArgs());

                myMultiEtiquetasArray.Clear();
        if (myDataRegistro_de_Contenido.Etiquetas != null)
        {
            foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas itm in myDataRegistro_de_Contenido.Etiquetas)
            	myMultiEtiquetasArray.Add(itm);
        }

        myMultiFuentesArray.Clear();
        if (myDataRegistro_de_Contenido.Fuentes != null)
        {
            foreach (WSRegistro_de_Contenido.objectBussinessFuentes itm in myDataRegistro_de_Contenido.Fuentes)
            	myMultiFuentesArray.Add(itm);
        }

        myMultiNotificaciones_por_ObservatoriosArray.Clear();
        if (myDataRegistro_de_Contenido.Notificaciones_por_Observatorios != null)
        {
            foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio itm in myDataRegistro_de_Contenido.Notificaciones_por_Observatorios)
            	myMultiNotificaciones_por_ObservatoriosArray.Add(itm);
        }

        myMultiNotificaciones_por_UsuarioArray.Clear();
        if (myDataRegistro_de_Contenido.Notificaciones_por_Usuario != null)
        {
            foreach (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario itm in myDataRegistro_de_Contenido.Notificaciones_por_Usuario)
            	myMultiNotificaciones_por_UsuarioArray.Add(itm);
        }


                    cvRadUploadImagen.Enabled = false;            cvRadUploadImagen_Miniatura.Enabled = false;            cvRadUploadAdjuntar_PDF.Enabled = false;
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
        
                (Aux.Tabs.FindTabByValue("tabPagSolicitud") as RadTab).Text = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Solicitud");
                (Aux.Tabs.FindTabByValue("tabPagRegistro") as RadTab).Text = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Registro");
                (Aux.Tabs.FindTabByValue("tabPagAutorizacion") as RadTab).Text = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Autorización");
                (Aux.Tabs.FindTabByValue("tabPagNotificaciones") as RadTab).Text = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Notificaciones");
        
        DataSet ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        DataView dv = new DataView(ds_controles.Tables[0]);

                dv.RowFilter = "TTMetadata_DTID = " + 141045;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFolio.Text = MyTraductor.getTextDTID(141045, lblFolio.Text);
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
            trFolio.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141046;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblUsuario_que_Registra.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblUsuario_que_Registra.Text = MyTraductor.getTextDTID(141046, lblUsuario_que_Registra.Text);
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
            trUsuario_que_Registra.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141047;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Registro.Text = MyTraductor.getTextDTID(141047, lblFecha_de_Registro.Text);
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
        dv.RowFilter = "TTMetadata_DTID = " + 141048;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblHora_de_Registro.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblHora_de_Registro.Text = MyTraductor.getTextDTID(141048, lblHora_de_Registro.Text);
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
            trHora_de_Registro.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143376;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblObservatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblObservatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblObservatorio.Text = MyTraductor.getTextDTID(143376, lblObservatorio.Text);
        lstObservatorio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        lstObservatorio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblObservatorio.Style["display"] = "auto";
        else
            imgOblObservatorio.Style["display"] = "none";
        RFVObservatorio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trObservatorio.Style["display"] = "auto";
        else
            trObservatorio.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 141052;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblCategoria.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblCategoria.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblCategoria.Text = MyTraductor.getTextDTID(141052, lblCategoria.Text);
        ddlCategoria.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlCategoria.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcCategoria.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlCategoria.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlCategoria.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlCategoria.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlCategoria.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblCategoria.Style["display"] = "auto";
        else
            imgOblCategoria.Style["display"] = "none";
        RFVCategoria.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trCategoria.Style["display"] = "auto";
        else
            trCategoria.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143396;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblDescripcion_de_Solicitud.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblDescripcion_de_Solicitud.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblDescripcion_de_Solicitud.Text = MyTraductor.getTextDTID(143396, lblDescripcion_de_Solicitud.Text);
        txtDescripcion_de_Solicitud.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtDescripcion_de_Solicitud.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtDescripcion_de_Solicitud.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
	txtDescripcion_de_Solicitud.Attributes.Add("MaxLength", dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtDescripcion_de_Solicitud.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtDescripcion_de_Solicitud.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtDescripcion_de_Solicitud.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtDescripcion_de_Solicitud.Text = "";
            }

        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblDescripcion_de_Solicitud.Style["display"] = "auto";
        else
            imgOblDescripcion_de_Solicitud.Style["display"] = "none";
        RFVDescripcion_de_Solicitud.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trDescripcion_de_Solicitud.Style["display"] = "auto";
        else
            trDescripcion_de_Solicitud.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143392;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblReportero_Asignado.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblReportero_Asignado.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblReportero_Asignado.Text = MyTraductor.getTextDTID(143392, lblReportero_Asignado.Text);
        ddlReportero_Asignado.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlReportero_Asignado.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcReportero_Asignado.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlReportero_Asignado.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlReportero_Asignado.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlReportero_Asignado.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlReportero_Asignado.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblReportero_Asignado.Style["display"] = "auto";
        else
            imgOblReportero_Asignado.Style["display"] = "none";
        RFVReportero_Asignado.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trReportero_Asignado.Style["display"] = "auto";
        else
            trReportero_Asignado.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143397;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Compromiso.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Compromiso.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Compromiso.Text = MyTraductor.getTextDTID(143397, lblFecha_de_Compromiso.Text);
        txtFecha_de_Compromiso.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFecha_de_Compromiso.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        {
            txtFecha_de_Compromiso.SelectedDate = DateTime.Now;
        }
        else
        {
            txtFecha_de_Compromiso.SelectedDate = MyFunctions.FormatDateNull(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFecha_de_Compromiso.Style["display"] = "auto";
        else
            imgOblFecha_de_Compromiso.Style["display"] = "none";
        RFVFecha_de_Compromiso.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFecha_de_Compromiso.Style["display"] = "auto";
        else
            trFecha_de_Compromiso.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 141534;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblEstatus.Text = MyTraductor.getTextDTID(141534, lblEstatus.Text);
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
            trEstatus.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143609;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAdministrador_de_Observatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAdministrador_de_Observatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblAdministrador_de_Observatorio.Text = MyTraductor.getTextDTID(143609, lblAdministrador_de_Observatorio.Text);
        ddlAdministrador_de_Observatorio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlAdministrador_de_Observatorio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcAdministrador_de_Observatorio.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlAdministrador_de_Observatorio.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlAdministrador_de_Observatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlAdministrador_de_Observatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlAdministrador_de_Observatorio.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblAdministrador_de_Observatorio.Style["display"] = "auto";
        else
            imgOblAdministrador_de_Observatorio.Style["display"] = "none";
        RFVAdministrador_de_Observatorio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trAdministrador_de_Observatorio.Style["display"] = "auto";
        else
            trAdministrador_de_Observatorio.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141530;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblReportero.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblReportero.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblReportero.Text = MyTraductor.getTextDTID(141530, lblReportero.Text);
        ddlReportero.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlReportero.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcReportero.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlReportero.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlReportero.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlReportero.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlReportero.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblReportero.Style["display"] = "auto";
        else
            imgOblReportero.Style["display"] = "none";
        RFVReportero.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trReportero.Style["display"] = "auto";
        else
            trReportero.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141049;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblTitulo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblTitulo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblTitulo.Text = MyTraductor.getTextDTID(141049, lblTitulo.Text);
        txtTitulo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtTitulo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtTitulo.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtTitulo.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtTitulo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtTitulo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtTitulo.Text = "";
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblTitulo.Style["display"] = "auto";
        else
            imgOblTitulo.Style["display"] = "none";
        RFVTitulo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trTitulo.Style["display"] = "auto";
        else
            trTitulo.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141050;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblDescripcion.Text = MyTraductor.getTextDTID(141050, lblDescripcion.Text);
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
            trDescripcion.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141051;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblContenido.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblContenido.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblContenido.Text = MyTraductor.getTextDTID(141051, lblContenido.Text);
        txtContenido.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtContenido.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtContenido.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
	txtContenido.Attributes.Add("MaxLength", dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtContenido.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtContenido.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtContenido.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtContenido.Text = "";
            }

        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblContenido.Style["display"] = "auto";
        else
            imgOblContenido.Style["display"] = "none";
        RFVContenido.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trContenido.Style["display"] = "auto";
        else
            trContenido.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141133;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblImagen.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblImagen.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblImagen.Text = MyTraductor.getTextDTID(141133, lblImagen.Text);
        txtImagen.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtImagen.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtImagen.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        txtImagen.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        labelNoResultsImagen.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblImagen.Style["display"] = "auto";
        else
            imgOblImagen.Style["display"] = "none";
        RFVImagen.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trImagen.Style["display"] = "auto";
        else
            trImagen.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141911;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblImagen_Miniatura.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblImagen_Miniatura.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblImagen_Miniatura.Text = MyTraductor.getTextDTID(141911, lblImagen_Miniatura.Text);
        txtImagen_Miniatura.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtImagen_Miniatura.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtImagen_Miniatura.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        txtImagen_Miniatura.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        labelNoResultsImagen_Miniatura.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblImagen_Miniatura.Style["display"] = "auto";
        else
            imgOblImagen_Miniatura.Style["display"] = "none";
        RFVImagen_Miniatura.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trImagen_Miniatura.Style["display"] = "auto";
        else
            trImagen_Miniatura.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141070;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblEstilo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblEstilo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblEstilo.Text = MyTraductor.getTextDTID(141070, lblEstilo.Text);
        ddlEstilo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlEstilo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcEstilo.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlEstilo.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlEstilo.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlEstilo.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlEstilo.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblEstilo.Style["display"] = "auto";
        else
            imgOblEstilo.Style["display"] = "none";
        RFVEstilo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trEstilo.Style["display"] = "auto";
        else
            trEstilo.Style["display"] = "none";        
        dv.RowFilter = "TTMetadata_DTID = " + 141078;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            panMultiEtiquetas.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            panMultiEtiquetas.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        panMultiEtiquetas.GroupingText = MyTraductor.getTextDTID(141078, panMultiEtiquetas.GroupingText);
        grdMultiEtiquetas.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        cmdNewEtiquetas.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        panMultiEtiquetas.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (TTbcNewEtiquetas.Visible)
            cmdNewEtiquetas.Visible = false;

        myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = "29989";
        ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        dvMulti = new DataView(ds_controles.Tables[0]);
        Session["MultiMetadataEtiquetas"] = dvMulti;        
        dv.RowFilter = "TTMetadata_DTID = " + 141907;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            panMultiFuentes.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            panMultiFuentes.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        panMultiFuentes.GroupingText = MyTraductor.getTextDTID(141907, panMultiFuentes.GroupingText);
        grdMultiFuentes.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        cmdNewFuentes.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        panMultiFuentes.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (TTbcNewFuentes.Visible)
            cmdNewFuentes.Visible = false;

        myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = "30048";
        ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        dvMulti = new DataView(ds_controles.Tables[0]);
        Session["MultiMetadataFuentes"] = dvMulti;        dv.RowFilter = "TTMetadata_DTID = " + 143404;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAdjuntar_PDF.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAdjuntar_PDF.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblAdjuntar_PDF.Text = MyTraductor.getTextDTID(143404, lblAdjuntar_PDF.Text);
        txtAdjuntar_PDF.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtAdjuntar_PDF.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        txtAdjuntar_PDF.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        txtAdjuntar_PDF.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        labelNoResultsAdjuntar_PDF.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblAdjuntar_PDF.Style["display"] = "auto";
        else
            imgOblAdjuntar_PDF.Style["display"] = "none";
        RFVAdjuntar_PDF.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trAdjuntar_PDF.Style["display"] = "auto";
        else
            trAdjuntar_PDF.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143568;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblCaptura_Terminada.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblCaptura_Terminada.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblCaptura_Terminada.Text = MyTraductor.getTextDTID(143568, lblCaptura_Terminada.Text);
        ChCaptura_Terminada.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ChCaptura_Terminada.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "1"){
            	ChCaptura_Terminada.Checked = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
            }else{
                ChCaptura_Terminada.Checked = false;
            }
        }else{
            ChCaptura_Terminada.Checked = false;
        }
        imgOblCaptura_Terminada.Style["display"] = "none";
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trCaptura_Terminada.Style["display"] = "auto";
        else
            trCaptura_Terminada.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141729;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAutorizado_por.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAutorizado_por.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblAutorizado_por.Text = MyTraductor.getTextDTID(141729, lblAutorizado_por.Text);
        ddlAutorizado_por.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlAutorizado_por.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcAutorizado_por.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlAutorizado_por.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlAutorizado_por.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlAutorizado_por.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlAutorizado_por.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblAutorizado_por.Style["display"] = "auto";
        else
            imgOblAutorizado_por.Style["display"] = "none";
        RFVAutorizado_por.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trAutorizado_por.Style["display"] = "auto";
        else
            trAutorizado_por.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141730;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Revision.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Revision.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Revision.Text = MyTraductor.getTextDTID(141730, lblFecha_de_Revision.Text);
        txtFecha_de_Revision.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFecha_de_Revision.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        {
            txtFecha_de_Revision.SelectedDate = DateTime.Now;
        }
        else
        {
            txtFecha_de_Revision.SelectedDate = MyFunctions.FormatDateNull(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFecha_de_Revision.Style["display"] = "auto";
        else
            imgOblFecha_de_Revision.Style["display"] = "none";
        RFVFecha_de_Revision.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFecha_de_Revision.Style["display"] = "auto";
        else
            trFecha_de_Revision.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 141731;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblHora_de_Revision.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblHora_de_Revision.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblHora_de_Revision.Text = MyTraductor.getTextDTID(141731, lblHora_de_Revision.Text);
        txtHora_de_Revision.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtHora_de_Revision.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtHora_de_Revision.SelectedDate = Funcion.FormatDateFromTextTime(Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString());
                    }
                    else
                    {
                        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#HORAACTUAL")
                        {
                            txtHora_de_Revision.SelectedDate = DateTime.Now;
                        }else{		
                            txtHora_de_Revision.SelectedDate = Funcion.FormatDateFromTextTime(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
                        }
                    }
                }
                else
                {
                    txtHora_de_Revision.SelectedDate = Funcion.FormatDateFromTextTime(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
                }
            }else{
                txtHora_de_Revision.SelectedDate = null;
            }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblHora_de_Revision.Style["display"] = "auto";
        else
            imgOblHora_de_Revision.Style["display"] = "none";
        RFVHora_de_Revision.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trHora_de_Revision.Style["display"] = "auto";
        else
            trHora_de_Revision.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141734;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblAutorizacion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblAutorizacion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblAutorizacion.Text = MyTraductor.getTextDTID(141734, lblAutorizacion.Text);
        ddlAutorizacion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlAutorizacion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcAutorizacion.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlAutorizacion.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlAutorizacion.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlAutorizacion.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlAutorizacion.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblAutorizacion.Style["display"] = "auto";
        else
            imgOblAutorizacion.Style["display"] = "none";
        RFVAutorizacion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trAutorizacion.Style["display"] = "auto";
        else
            trAutorizacion.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 141901;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblMotivo_de_Rechazo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblMotivo_de_Rechazo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblMotivo_de_Rechazo.Text = MyTraductor.getTextDTID(141901, lblMotivo_de_Rechazo.Text);
        txtMotivo_de_Rechazo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtMotivo_de_Rechazo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtMotivo_de_Rechazo.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
	txtMotivo_de_Rechazo.Attributes.Add("MaxLength", dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtMotivo_de_Rechazo.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtMotivo_de_Rechazo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtMotivo_de_Rechazo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtMotivo_de_Rechazo.Text = "";
            }

        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblMotivo_de_Rechazo.Style["display"] = "auto";
        else
            imgOblMotivo_de_Rechazo.Style["display"] = "none";
        RFVMotivo_de_Rechazo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trMotivo_de_Rechazo.Style["display"] = "auto";
        else
            trMotivo_de_Rechazo.Style["display"] = "none";        dv.RowFilter = "TTMetadata_DTID = " + 143405;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Inicio_de_Publicacion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Inicio_de_Publicacion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Inicio_de_Publicacion.Text = MyTraductor.getTextDTID(143405, lblFecha_de_Inicio_de_Publicacion.Text);
        txtFecha_de_Inicio_de_Publicacion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFecha_de_Inicio_de_Publicacion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        {
            txtFecha_de_Inicio_de_Publicacion.SelectedDate = DateTime.Now;
        }
        else
        {
            txtFecha_de_Inicio_de_Publicacion.SelectedDate = MyFunctions.FormatDateNull(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFecha_de_Inicio_de_Publicacion.Style["display"] = "auto";
        else
            imgOblFecha_de_Inicio_de_Publicacion.Style["display"] = "none";
        RFVFecha_de_Inicio_de_Publicacion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFecha_de_Inicio_de_Publicacion.Style["display"] = "auto";
        else
            trFecha_de_Inicio_de_Publicacion.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 143406;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFecha_de_Termino.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFecha_de_Termino.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFecha_de_Termino.Text = MyTraductor.getTextDTID(143406, lblFecha_de_Termino.Text);
        txtFecha_de_Termino.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtFecha_de_Termino.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "#FECHAACTUAL")
        {
            txtFecha_de_Termino.SelectedDate = DateTime.Now;
        }
        else
        {
            txtFecha_de_Termino.SelectedDate = MyFunctions.FormatDateNull(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFecha_de_Termino.Style["display"] = "auto";
        else
            imgOblFecha_de_Termino.Style["display"] = "none";
        RFVFecha_de_Termino.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFecha_de_Termino.Style["display"] = "auto";
        else
            trFecha_de_Termino.Style["display"] = "none";
        dv.RowFilter = "TTMetadata_DTID = " + 149684;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblSeleccionar_Todos_los_Observatorios.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblSeleccionar_Todos_los_Observatorios.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblSeleccionar_Todos_los_Observatorios.Text = MyTraductor.getTextDTID(149684, lblSeleccionar_Todos_los_Observatorios.Text);
        ChSeleccionar_Todos_los_Observatorios.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ChSeleccionar_Todos_los_Observatorios.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() == "1"){
            	ChSeleccionar_Todos_los_Observatorios.Checked = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString());
            }else{
                ChSeleccionar_Todos_los_Observatorios.Checked = false;
            }
        }else{
            ChSeleccionar_Todos_los_Observatorios.Checked = false;
        }
        imgOblSeleccionar_Todos_los_Observatorios.Style["display"] = "none";
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trSeleccionar_Todos_los_Observatorios.Style["display"] = "auto";
        else
            trSeleccionar_Todos_los_Observatorios.Style["display"] = "none";        
        dv.RowFilter = "TTMetadata_DTID = " + 149685;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            panMultiNotificaciones_por_Observatorios.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            panMultiNotificaciones_por_Observatorios.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        panMultiNotificaciones_por_Observatorios.GroupingText = MyTraductor.getTextDTID(149685, panMultiNotificaciones_por_Observatorios.GroupingText);
        grdMultiNotificaciones_por_Observatorios.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        cmdNewNotificaciones_por_Observatorios.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        panMultiNotificaciones_por_Observatorios.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (TTbcNewNotificaciones_por_Observatorios.Visible)
            cmdNewNotificaciones_por_Observatorios.Visible = false;

        myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = "31010";
        ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        dvMulti = new DataView(ds_controles.Tables[0]);
        Session["MultiMetadataNotificaciones_por_Observatorios"] = dvMulti;        dv.RowFilter = "TTMetadata_DTID = " + 159065;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFiltrar_Usuarios_por_Observatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFiltrar_Usuarios_por_Observatorio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFiltrar_Usuarios_por_Observatorio.Text = MyTraductor.getTextDTID(159065, lblFiltrar_Usuarios_por_Observatorio.Text);
        ddlFiltrar_Usuarios_por_Observatorio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlFiltrar_Usuarios_por_Observatorio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        TTbcFiltrar_Usuarios_por_Observatorio.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        {
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                {
                    ddlFiltrar_Usuarios_por_Observatorio.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                }
                else
                {
                    ddlFiltrar_Usuarios_por_Observatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }
            else
            {
                ddlFiltrar_Usuarios_por_Observatorio.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
            }
        }else{
                ddlFiltrar_Usuarios_por_Observatorio.SelectedValue = "";
        }
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString()))
            imgOblFiltrar_Usuarios_por_Observatorio.Style["display"] = "auto";
        else
            imgOblFiltrar_Usuarios_por_Observatorio.Style["display"] = "none";
        RFVFiltrar_Usuarios_por_Observatorio.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString()))
            trFiltrar_Usuarios_por_Observatorio.Style["display"] = "auto";
        else
            trFiltrar_Usuarios_por_Observatorio.Style["display"] = "none";        
        dv.RowFilter = "TTMetadata_DTID = " + 149686;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            panMultiNotificaciones_por_Usuario.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            panMultiNotificaciones_por_Usuario.GroupingText = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        panMultiNotificaciones_por_Usuario.GroupingText = MyTraductor.getTextDTID(149686, panMultiNotificaciones_por_Usuario.GroupingText);
        grdMultiNotificaciones_por_Usuario.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        cmdNewNotificaciones_por_Usuario.Visible = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        panMultiNotificaciones_por_Usuario.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (TTbcNewNotificaciones_por_Usuario.Visible)
            cmdNewNotificaciones_por_Usuario.Visible = false;

        myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        myFiltro[0].ProcesoId.List = new string[1];
        myFiltro[0].ProcesoId.List[0] = "31011";
        ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        dvMulti = new DataView(ds_controles.Tables[0]);
        Session["MultiMetadataNotificaciones_por_Usuario"] = dvMulti;

        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
        DataView dv;
        string MultiRenglonesObligatorios="";
                Int32?[] Etiquetas_Clave = new Int32?[myMultiEtiquetasArray.Count];
        Int32?[] Etiquetas_Articulo = new Int32?[myMultiEtiquetasArray.Count];
        Int32?[] Etiquetas_Etiqueta = new Int32?[myMultiEtiquetasArray.Count];

        dv = (DataView)Session["MultiMetadataEtiquetas"];
        for (int i = 0; i < myMultiEtiquetasArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myMultiEtiquetas = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas)myMultiEtiquetasArray[i];
            Etiquetas_Clave[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Clave);
            Etiquetas_Articulo[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Articulo);
            Etiquetas_Etiqueta[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Etiqueta);
            dv.RowFilter = "TTMetadata_DTID = " + 141077;
            if (Etiquetas_Etiqueta[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trEtiquetas.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Etiqueta del renglón " + (i + 1).ToString() + " de la tabla Etiquetas <br />";

            
        }
        Int32?[] Fuentes_Clave = new Int32?[myMultiFuentesArray.Count];
        Int32?[] Fuentes_Articulo = new Int32?[myMultiFuentesArray.Count];
        String[] Fuentes_Fuente = new String[myMultiFuentesArray.Count];

        dv = (DataView)Session["MultiMetadataFuentes"];
        for (int i = 0; i < myMultiFuentesArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessFuentes myMultiFuentes = (WSRegistro_de_Contenido.objectBussinessFuentes)myMultiFuentesArray[i];
            Fuentes_Clave[i] = MyFunctions.FormatNumberNull(myMultiFuentes.Clave);
            Fuentes_Articulo[i] = MyFunctions.FormatNumberNull(myMultiFuentes.Articulo);
            if (myMultiFuentes.Fuente == null)
            {
                Fuentes_Fuente[i] = "";
            }
            else
            {
                Fuentes_Fuente[i] = myMultiFuentes.Fuente;
            }
            dv.RowFilter = "TTMetadata_DTID = " + 141904;
            if (Fuentes_Fuente[i] == "" && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trFuentes.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Fuente del renglón " + (i + 1).ToString() + " de la tabla Fuentes <br />";

            
        }
        Int32?[] Notificaciones_por_Observatorios_Clave = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Int32?[] Notificaciones_por_Observatorios_Contenido = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Boolean[] Notificaciones_por_Observatorios_Notificar = new Boolean[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Int32?[] Notificaciones_por_Observatorios_Observatorio = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];

        dv = (DataView)Session["MultiMetadataNotificaciones_por_Observatorios"];
        for (int i = 0; i < myMultiNotificaciones_por_ObservatoriosArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myMultiNotificaciones_por_Observatorios = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio)myMultiNotificaciones_por_ObservatoriosArray[i];
            Notificaciones_por_Observatorios_Clave[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Clave);
            Notificaciones_por_Observatorios_Contenido[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Contenido);
            Notificaciones_por_Observatorios_Notificar[i] = myMultiNotificaciones_por_Observatorios.Notificar;
            Notificaciones_por_Observatorios_Observatorio[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Observatorio);
            dv.RowFilter = "TTMetadata_DTID = " + 149690;
            if (Notificaciones_por_Observatorios_Observatorio[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Observatorios.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Observatorio del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Observatorios <br />";

            
        }
        Int32?[] Notificaciones_por_Usuario_Clave = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_Contenido = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Boolean[] Notificaciones_por_Usuario_Notificar = new Boolean[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_Observatorio = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_ID_del_Cliente = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        String[] Notificaciones_por_Usuario_Nombre = new String[myMultiNotificaciones_por_UsuarioArray.Count];

        dv = (DataView)Session["MultiMetadataNotificaciones_por_Usuario"];
        for (int i = 0; i < myMultiNotificaciones_por_UsuarioArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myMultiNotificaciones_por_Usuario = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario)myMultiNotificaciones_por_UsuarioArray[i];
            Notificaciones_por_Usuario_Clave[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Clave);
            Notificaciones_por_Usuario_Contenido[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Contenido);
            Notificaciones_por_Usuario_Notificar[i] = myMultiNotificaciones_por_Usuario.Notificar;
            Notificaciones_por_Usuario_Observatorio[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Observatorio);
            dv.RowFilter = "TTMetadata_DTID = " + 149694;
            if (Notificaciones_por_Usuario_Observatorio[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Observatorio del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            Notificaciones_por_Usuario_ID_del_Cliente[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.ID_del_Cliente);
            dv.RowFilter = "TTMetadata_DTID = " + 149695;
            if (Notificaciones_por_Usuario_ID_del_Cliente[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo ID del Cliente del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            if (myMultiNotificaciones_por_Usuario.Nombre == null)
            {
                Notificaciones_por_Usuario_Nombre[i] = "";
            }
            else
            {
                Notificaciones_por_Usuario_Nombre[i] = myMultiNotificaciones_por_Usuario.Nombre;
            }
            dv.RowFilter = "TTMetadata_DTID = " + 149696;
            if (Notificaciones_por_Usuario_Nombre[i] == "" && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Nombre del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            
        }

                ArrayList varArrLstObservatorio = new ArrayList();
        foreach (ListItem dItem in lstObservatorio.Items)
            if (dItem.Selected)
               varArrLstObservatorio.Add(MyFunctions.FormatNumberNull(dItem.Value));
        int?[] varLstObservatorio = (int?[])varArrLstObservatorio.ToArray(typeof(int?));

        if (MultiRenglonesObligatorios != "")
        {
            MultiRenglonesObligatorios = "Los siguientes datos son obligatorios: <br />" + MultiRenglonesObligatorios;
            ShowAlert(MultiRenglonesObligatorios,600);
            return false;
        }
        try
        {
            		GuardaArchivoImagen();		GuardaArchivoImagen_Miniatura();		GuardaArchivoAdjuntar_PDF();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myRegistro_de_Contenido.InsertWithReturnValue(userData,  MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), varLstObservatorio, MyFunctions.FormatNumberNull(ddlCategoria.SelectedValue), txtDescripcion_de_Solicitud.Text, MyFunctions.FormatNumberNull(ddlReportero_Asignado.SelectedValue), txtFecha_de_Compromiso.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Compromiso.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), MyFunctions.FormatNumberNull(ddlAdministrador_de_Observatorio.SelectedValue), MyFunctions.FormatNumberNull(ddlReportero.SelectedValue), txtTitulo.Text, txtDescripcion.Text, txtContenido.Text, MyFunctions.FormatNumberNull(txtImagen.Text), MyFunctions.FormatNumberNull(txtImagen_Miniatura.Text), MyFunctions.FormatNumberNull(ddlEstilo.SelectedValue), Etiquetas_Etiqueta, Fuentes_Fuente, MyFunctions.FormatNumberNull(txtAdjuntar_PDF.Text), ChCaptura_Terminada.Checked, MyFunctions.FormatNumberNull(ddlAutorizado_por.SelectedValue), txtFecha_de_Revision.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Revision.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Revision.SelectedDate != null ? txtHora_de_Revision.SelectedDate.Value.ToString("HH:mm:ss") :  null ), MyFunctions.FormatNumberNull(ddlAutorizacion.SelectedValue), txtMotivo_de_Rechazo.Text, txtFecha_de_Inicio_de_Publicacion.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Inicio_de_Publicacion.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), txtFecha_de_Termino.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Termino.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ChSeleccionar_Todos_los_Observatorios.Checked, Notificaciones_por_Observatorios_Notificar, Notificaciones_por_Observatorios_Observatorio, MyFunctions.FormatNumberNull(ddlFiltrar_Usuarios_por_Observatorio.SelectedValue), Notificaciones_por_Usuario_Notificar, Notificaciones_por_Usuario_Observatorio, Notificaciones_por_Usuario_ID_del_Cliente, Notificaciones_por_Usuario_Nombre);
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
                for(int i = 0; i < myMultiEtiquetasArray.Count; i++)
            if (myMultiEtiquetasArray[i].Clave == null)
                myMultiEtiquetasArray.Remove(myMultiEtiquetasArray[i]);

        Int32?[] Etiquetas_Clave = new Int32?[myMultiEtiquetasArray.Count];
        Int32?[] Etiquetas_Articulo = new Int32?[myMultiEtiquetasArray.Count];
        Int32?[] Etiquetas_Etiqueta = new Int32?[myMultiEtiquetasArray.Count];

        dv = (DataView)Session["MultiMetadataEtiquetas"];
        for (int i = 0; i < myMultiEtiquetasArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myMultiEtiquetas = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas)myMultiEtiquetasArray[i];
            Etiquetas_Clave[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Clave);
            Etiquetas_Articulo[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Articulo);
            Etiquetas_Etiqueta[i] = MyFunctions.FormatNumberNull(myMultiEtiquetas.Etiqueta);
            dv.RowFilter = "TTMetadata_DTID = " + 141077;
            if (Etiquetas_Etiqueta[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trEtiquetas.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Etiqueta del renglón " + (i + 1).ToString() + " de la tabla Etiquetas <br />";

            
        }
        for(int i = 0; i < myMultiFuentesArray.Count; i++)
            if (myMultiFuentesArray[i].Clave == null)
                myMultiFuentesArray.Remove(myMultiFuentesArray[i]);

        Int32?[] Fuentes_Clave = new Int32?[myMultiFuentesArray.Count];
        Int32?[] Fuentes_Articulo = new Int32?[myMultiFuentesArray.Count];
        String[] Fuentes_Fuente = new String[myMultiFuentesArray.Count];

        dv = (DataView)Session["MultiMetadataFuentes"];
        for (int i = 0; i < myMultiFuentesArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessFuentes myMultiFuentes = (WSRegistro_de_Contenido.objectBussinessFuentes)myMultiFuentesArray[i];
            Fuentes_Clave[i] = MyFunctions.FormatNumberNull(myMultiFuentes.Clave);
            Fuentes_Articulo[i] = MyFunctions.FormatNumberNull(myMultiFuentes.Articulo);
            if (myMultiFuentes.Fuente == null)
            {
                Fuentes_Fuente[i] = "";
            }
            else
            {
                Fuentes_Fuente[i] = myMultiFuentes.Fuente;
            }
            dv.RowFilter = "TTMetadata_DTID = " + 141904;
            if (Fuentes_Fuente[i] == "" && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trFuentes.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Fuente del renglón " + (i + 1).ToString() + " de la tabla Fuentes <br />";

            
        }
        for(int i = 0; i < myMultiNotificaciones_por_ObservatoriosArray.Count; i++)
            if (myMultiNotificaciones_por_ObservatoriosArray[i].Clave == null)
                myMultiNotificaciones_por_ObservatoriosArray.Remove(myMultiNotificaciones_por_ObservatoriosArray[i]);

        Int32?[] Notificaciones_por_Observatorios_Clave = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Int32?[] Notificaciones_por_Observatorios_Contenido = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Boolean[] Notificaciones_por_Observatorios_Notificar = new Boolean[myMultiNotificaciones_por_ObservatoriosArray.Count];
        Int32?[] Notificaciones_por_Observatorios_Observatorio = new Int32?[myMultiNotificaciones_por_ObservatoriosArray.Count];

        dv = (DataView)Session["MultiMetadataNotificaciones_por_Observatorios"];
        for (int i = 0; i < myMultiNotificaciones_por_ObservatoriosArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myMultiNotificaciones_por_Observatorios = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio)myMultiNotificaciones_por_ObservatoriosArray[i];
            Notificaciones_por_Observatorios_Clave[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Clave);
            Notificaciones_por_Observatorios_Contenido[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Contenido);
            Notificaciones_por_Observatorios_Notificar[i] = myMultiNotificaciones_por_Observatorios.Notificar;
            Notificaciones_por_Observatorios_Observatorio[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Observatorios.Observatorio);
            dv.RowFilter = "TTMetadata_DTID = " + 149690;
            if (Notificaciones_por_Observatorios_Observatorio[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Observatorios.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Observatorio del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Observatorios <br />";

            
        }
        for(int i = 0; i < myMultiNotificaciones_por_UsuarioArray.Count; i++)
            if (myMultiNotificaciones_por_UsuarioArray[i].Clave == null)
                myMultiNotificaciones_por_UsuarioArray.Remove(myMultiNotificaciones_por_UsuarioArray[i]);

        Int32?[] Notificaciones_por_Usuario_Clave = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_Contenido = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Boolean[] Notificaciones_por_Usuario_Notificar = new Boolean[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_Observatorio = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        Int32?[] Notificaciones_por_Usuario_ID_del_Cliente = new Int32?[myMultiNotificaciones_por_UsuarioArray.Count];
        String[] Notificaciones_por_Usuario_Nombre = new String[myMultiNotificaciones_por_UsuarioArray.Count];

        dv = (DataView)Session["MultiMetadataNotificaciones_por_Usuario"];
        for (int i = 0; i < myMultiNotificaciones_por_UsuarioArray.Count; i++)
        {
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myMultiNotificaciones_por_Usuario = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario)myMultiNotificaciones_por_UsuarioArray[i];
            Notificaciones_por_Usuario_Clave[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Clave);
            Notificaciones_por_Usuario_Contenido[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Contenido);
            Notificaciones_por_Usuario_Notificar[i] = myMultiNotificaciones_por_Usuario.Notificar;
            Notificaciones_por_Usuario_Observatorio[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.Observatorio);
            dv.RowFilter = "TTMetadata_DTID = " + 149694;
            if (Notificaciones_por_Usuario_Observatorio[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Observatorio del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            Notificaciones_por_Usuario_ID_del_Cliente[i] = MyFunctions.FormatNumberNull(myMultiNotificaciones_por_Usuario.ID_del_Cliente);
            dv.RowFilter = "TTMetadata_DTID = " + 149695;
            if (Notificaciones_por_Usuario_ID_del_Cliente[i] == null && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo ID del Cliente del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            if (myMultiNotificaciones_por_Usuario.Nombre == null)
            {
                Notificaciones_por_Usuario_Nombre[i] = "";
            }
            else
            {
                Notificaciones_por_Usuario_Nombre[i] = myMultiNotificaciones_por_Usuario.Nombre;
            }
            dv.RowFilter = "TTMetadata_DTID = " + 149696;
            if (Notificaciones_por_Usuario_Nombre[i] == "" && Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString())  && trNotificaciones_por_Usuario.Attributes["style"] != "display: none;")
                MultiRenglonesObligatorios = MultiRenglonesObligatorios + "- Campo Nombre del renglón " + (i + 1).ToString() + " de la tabla Notificaciones por Usuario <br />";

            
        }

                ArrayList varArrLstObservatorio = new ArrayList();
        foreach (ListItem dItem in lstObservatorio.Items)
            if (dItem.Selected)
               varArrLstObservatorio.Add(MyFunctions.FormatNumberNull(dItem.Value));
        int?[] varLstObservatorio = (int?[])varArrLstObservatorio.ToArray(typeof(int?));

        if (MultiRenglonesObligatorios != "")
        {
            MultiRenglonesObligatorios = "Los siguientes datos son obligatorios: <br />" + MultiRenglonesObligatorios;
            ShowAlert(MultiRenglonesObligatorios,600);
            return false;
        }
        try
        {
            		GuardaArchivoImagen();		GuardaArchivoImagen_Miniatura();		GuardaArchivoAdjuntar_PDF();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            var autorizar = ddlAutorizacion.SelectedValue.ToString();
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myRegistro_de_Contenido.Update(userData,  MyFunctions.FormatNumberNull(txtFolio.Text), MyFunctions.FormatNumberNull(ddlUsuario_que_Registra.SelectedValue), txtFecha_de_Registro.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Registro.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Registro.SelectedDate != null ? txtHora_de_Registro.SelectedDate.Value.ToString("HH:mm:ss") :  null ), varLstObservatorio, MyFunctions.FormatNumberNull(ddlCategoria.SelectedValue), txtDescripcion_de_Solicitud.Text, MyFunctions.FormatNumberNull(ddlReportero_Asignado.SelectedValue), txtFecha_de_Compromiso.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Compromiso.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), MyFunctions.FormatNumberNull(ddlAdministrador_de_Observatorio.SelectedValue), MyFunctions.FormatNumberNull(ddlReportero.SelectedValue), txtTitulo.Text, txtDescripcion.Text, txtContenido.Text, MyFunctions.FormatNumberNull(txtImagen.Text), MyFunctions.FormatNumberNull(txtImagen_Miniatura.Text), MyFunctions.FormatNumberNull(ddlEstilo.SelectedValue), Etiquetas_Clave, Etiquetas_Articulo, Etiquetas_Etiqueta, Fuentes_Clave, Fuentes_Articulo, Fuentes_Fuente, MyFunctions.FormatNumberNull(txtAdjuntar_PDF.Text), ChCaptura_Terminada.Checked, MyFunctions.FormatNumberNull(ddlAutorizado_por.SelectedValue), txtFecha_de_Revision.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Revision.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ( txtHora_de_Revision.SelectedDate != null ? txtHora_de_Revision.SelectedDate.Value.ToString("HH:mm:ss") :  null ), MyFunctions.FormatNumberNull(ddlAutorizacion.SelectedValue), txtMotivo_de_Rechazo.Text, txtFecha_de_Inicio_de_Publicacion.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Inicio_de_Publicacion.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), txtFecha_de_Termino.SelectedDate.HasValue == false ? null : (DateTime?)Convert.ToDateTime(txtFecha_de_Termino.SelectedDate, new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["CultureUS"].ToString(), true)), ChSeleccionar_Todos_los_Observatorios.Checked, Notificaciones_por_Observatorios_Clave, Notificaciones_por_Observatorios_Contenido, Notificaciones_por_Observatorios_Notificar, Notificaciones_por_Observatorios_Observatorio, MyFunctions.FormatNumberNull(ddlFiltrar_Usuarios_por_Observatorio.SelectedValue), Notificaciones_por_Usuario_Clave, Notificaciones_por_Usuario_Contenido, Notificaciones_por_Usuario_Notificar, Notificaciones_por_Usuario_Observatorio, Notificaciones_por_Usuario_ID_del_Cliente, Notificaciones_por_Usuario_Nombre);

            //Begin Manual
            if (autorizar == "1")//Enviar Notificaciones Push
            {
                WSUsuarios_Registrados_en_Observatorios.objectBussinessUsuarios_Registrados_en_Observatorios myUsuarios_Registrados_en_Observatorios = new WSUsuarios_Registrados_en_Observatorios.objectBussinessUsuarios_Registrados_en_Observatorios();
                DataSet dat = myUsuarios_Registrados_en_Observatorios.ListaSelAll(0, 100000, "", "");

                for (int i = 0; i < myMultiNotificaciones_por_ObservatoriosArray.Count; i++)
                {
                    WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myMultiNotificaciones_por_Observatorios = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio)myMultiNotificaciones_por_ObservatoriosArray[i];
                    if (myMultiNotificaciones_por_Observatorios.Notificar)
                    {
                        foreach (DataRow dr in dat.Tables[0].Rows)
                        {
                            if (dr["Usuarios_Registrados_en_Observatorios_Observatorio"].ToString() == myMultiNotificaciones_por_Observatorios.Observatorio.ToString())
                            {
                                if (dr["Usuarios_Registrados_en_Observatorios_Token"] != null && dr["Usuarios_Registrados_en_Observatorios_Token"].ToString() != string.Empty)
                                    Push(dr["Usuarios_Registrados_en_Observatorios_Token"].ToString(), "Tiene una notificación pendiente por leer", dr["Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo"].ToString());
                            }
                        }                                              
                    }

                }

                for (int j = 0; j < myMultiNotificaciones_por_UsuarioArray.Count; j++)
                {
                    WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myMultiNotificaciones_por_Usuario = (WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario)myMultiNotificaciones_por_UsuarioArray[j];
                    if (myMultiNotificaciones_por_Usuario.Notificar)
                    {
                        foreach (DataRow dr in dat.Tables[0].Rows)
                        {
                            if (dr["Usuarios_Registrados_en_Observatorios_Usuario"].ToString() == myMultiNotificaciones_por_Usuario.ID_del_Cliente.ToString())
                            {
                                if (dr["Usuarios_Registrados_en_Observatorios_Token"] != null && dr["Usuarios_Registrados_en_Observatorios_Token"].ToString()!= string.Empty)
                                    Push(dr["Usuarios_Registrados_en_Observatorios_Token"].ToString(), "Tiene una notificación pendiente por leer", dr["Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo"].ToString());
                            }
                        }                         
                    }
                }
            }
            //End Manual

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

    private string Push(string TokenDispositivo, string Mensaje, string tipoDispositivo)
    {
        var baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
        var ApiControllerUrl = ConfigurationManager.AppSettings["ApiControllerUrl"].ToString();

        var client = new System.Net.WebClient();
        client.Headers = TokenManager.GetAuthenticationHeader("admin", "admin");
        var result = client.DownloadString(baseApi + ApiControllerUrl + "/Push?TokenDispositivo=" + TokenDispositivo + "&Mensaje=" + Mensaje + "&TipoDispositivo=" + tipoDispositivo);
        var MessageResult = new JavaScriptSerializer().Deserialize<string>(result);
        return MessageResult;
    }

	private void GuardaArchivoImagen()
	{
		String NombreArchivo = "";
		if (Session["ArchivoImagen"] != null)
                                      NombreArchivo = Session["ArchivoImagen"].ToString();

		if (NombreArchivo == "" && lkbVerImagen.Text != "")
		{
			if (lkbVerImagen.Text.Trim().Length > 4)
			{
				NombreArchivo = lkbVerImagen.Text;
			}
			else
			{
				NombreArchivo = "";
			}
		}
			
		//se guarda sin archivo
		if (NombreArchivo == "" && lkbVerImagen.Text == "")
		{
			NombreArchivo = "";
		}
		
		if (File.Exists(Server.MapPath("TempFiles/") + NombreArchivo) == true)
		{
			int Folio = 0;
			if (txtImagen.Text != "")
				Folio = int.Parse(txtImagen.Text);
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
					txtImagen.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				else					
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "alert('Error al guardar el archivo en B.D');", true);				
			}
			
			File.Delete(Server.MapPath("TempFiles/") + NombreArchivo);
			
		}
	}	private void GuardaArchivoImagen_Miniatura()
	{
		String NombreArchivo = "";
		if (Session["ArchivoImagen_Miniatura"] != null)
                                      NombreArchivo = Session["ArchivoImagen_Miniatura"].ToString();

		if (NombreArchivo == "" && lkbVerImagen_Miniatura.Text != "")
		{
			if (lkbVerImagen_Miniatura.Text.Trim().Length > 4)
			{
				NombreArchivo = lkbVerImagen_Miniatura.Text;
			}
			else
			{
				NombreArchivo = "";
			}
		}
			
		//se guarda sin archivo
		if (NombreArchivo == "" && lkbVerImagen_Miniatura.Text == "")
		{
			NombreArchivo = "";
		}
		
		if (File.Exists(Server.MapPath("TempFiles/") + NombreArchivo) == true)
		{
			int Folio = 0;
			if (txtImagen_Miniatura.Text != "")
				Folio = int.Parse(txtImagen_Miniatura.Text);
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
					txtImagen_Miniatura.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				else					
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "alert('Error al guardar el archivo en B.D');", true);				
			}
			
			File.Delete(Server.MapPath("TempFiles/") + NombreArchivo);
			
		}
	}	private void GuardaArchivoAdjuntar_PDF()
	{
		String NombreArchivo = "";
		if (Session["ArchivoAdjuntar_PDF"] != null)
                                      NombreArchivo = Session["ArchivoAdjuntar_PDF"].ToString();

		if (NombreArchivo == "" && lkbVerAdjuntar_PDF.Text != "")
		{
			if (lkbVerAdjuntar_PDF.Text.Trim().Length > 4)
			{
				NombreArchivo = lkbVerAdjuntar_PDF.Text;
			}
			else
			{
				NombreArchivo = "";
			}
		}
			
		//se guarda sin archivo
		if (NombreArchivo == "" && lkbVerAdjuntar_PDF.Text == "")
		{
			NombreArchivo = "";
		}
		
		if (File.Exists(Server.MapPath("TempFiles/") + NombreArchivo) == true)
		{
			int Folio = 0;
			if (txtAdjuntar_PDF.Text != "")
				Folio = int.Parse(txtAdjuntar_PDF.Text);
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
					txtAdjuntar_PDF.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
				else					
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "alert('Error al guardar el archivo en B.D');", true);				
			}
			
			File.Delete(Server.MapPath("TempFiles/") + NombreArchivo);
			
		}
	}


    public void Clear_All()
    {
	            Session["myMultiEtiquetas"] = null;
            myMultiEtiquetasArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>();
            Session["myMultiFuentes"] = null;
            myMultiFuentesArray = new List<WSRegistro_de_Contenido.objectBussinessFuentes>();
            Session["myMultiNotificaciones_por_Observatorios"] = null;
            myMultiNotificaciones_por_ObservatoriosArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>();
            Session["myMultiNotificaciones_por_Usuario"] = null;
            myMultiNotificaciones_por_UsuarioArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>();

                        fuaImagen.Visible = true;
                buttonSubmitImagen.Visible = true;
                labelNoResultsImagen.Visible = true;
                repeaterResultsImagen.Visible = true;
                //----------------------------------------------------
                lkbVerImagen.Visible = false;
                IbtnCambiarArchivoImagen.Visible = false;
                IbtnBorrarArchivoImagen.Visible = false;
                Session["ArchivoImagen"] = null;
                               fuaImagen_Miniatura.Visible = true;
                buttonSubmitImagen_Miniatura.Visible = true;
                labelNoResultsImagen_Miniatura.Visible = true;
                repeaterResultsImagen_Miniatura.Visible = true;
                //----------------------------------------------------
                lkbVerImagen_Miniatura.Visible = false;
                IbtnCambiarArchivoImagen_Miniatura.Visible = false;
                IbtnBorrarArchivoImagen_Miniatura.Visible = false;
                Session["ArchivoImagen_Miniatura"] = null;
                               fuaAdjuntar_PDF.Visible = true;
                buttonSubmitAdjuntar_PDF.Visible = true;
                labelNoResultsAdjuntar_PDF.Visible = true;
                repeaterResultsAdjuntar_PDF.Visible = true;
                //----------------------------------------------------
                lkbVerAdjuntar_PDF.Visible = false;
                IbtnCambiarArchivoAdjuntar_PDF.Visible = false;
                IbtnBorrarArchivoAdjuntar_PDF.Visible = false;
                Session["ArchivoAdjuntar_PDF"] = null;
               
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
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen"] == null  && RFVImagen.Enabled && RFVImagen.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen_Miniatura"] == null  && RFVImagen_Miniatura.Enabled && RFVImagen_Miniatura.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen_Miniatura");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoAdjuntar_PDF"] == null  && RFVAdjuntar_PDF.Enabled && RFVAdjuntar_PDF.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Adjuntar_PDF");
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
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen"] == null  && RFVImagen.Enabled && RFVImagen.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen_Miniatura"] == null  && RFVImagen_Miniatura.Enabled && RFVImagen_Miniatura.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen_Miniatura");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoAdjuntar_PDF"] == null  && RFVAdjuntar_PDF.Enabled && RFVAdjuntar_PDF.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Adjuntar_PDF");
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
    
                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen"] == null  && RFVImagen.Enabled && RFVImagen.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoImagen_Miniatura"] == null  && RFVImagen_Miniatura.Enabled && RFVImagen_Miniatura.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Imagen_Miniatura");
            return;
        }                if ((Session["Tipo_Transaccion"].ToString() == "New" || Session["Tipo_Transaccion"].ToString() == "Update") && Session["ArchivoAdjuntar_PDF"] == null  && RFVAdjuntar_PDF.Enabled && RFVAdjuntar_PDF.Visible)
        {
            ShowAlert("No se ha especificado el Archivo Adjuntar_PDF");
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
                Session["Tipo_Transaccion"] = "Update";
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
               	Response.Redirect("Registro_de_Contenido_Lista.aspx?Fase=" + Request["Fase"]);
               else
               	Response.Redirect("Registro_de_Contenido_Lista.aspx");
            }
            else if (Request["Fase"] != null)
               Response.Redirect("Registro_de_Contenido_Lista.aspx?Fase=" + Request["Fase"]);
            else
               Response.Redirect("Registro_de_Contenido_Lista.aspx");
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
                return new JsonResult("Registro_de_Contenido_Lista.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Registro_de_Contenido_Lista.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Registro_de_Contenido_Lista.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Registro_de_Contenido_Lista.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Registro_de_Contenido_Lista.aspx", true, null);
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
                return new JsonResult("Registro_de_Contenido_Catalogo.aspx?MenuVisible=false", true, null);
            else if (pf != null)
            {
                if (pf)
                        return new JsonResult("../FormsSystem/Default.aspx", true, null);
                else if (Fase != null)
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx", true, null);
            }
            else if (Fase != null)
                return new JsonResult("Registro_de_Contenido_Catalogo.aspx?Fase=" + Fase, true, null);
            else
                return new JsonResult("Registro_de_Contenido_Catalogo.aspx", true, null);
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
    /*public void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlReportero_Asignado_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlAdministrador_de_Observatorio_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlReportero_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlEstilo_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlAutorizado_por_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/
    /*public void ddlFiltrar_Usuarios_por_Observatorio_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/

    
    protected void grdMultiEtiquetas_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiEtiquetas.PageIndex = e.NewPageIndex;
        grdMultiEtiquetas.DataBind();
    }

    protected void cmbShowEtiquetas_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiEtiquetas.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiEtiquetas.DataBind();
    }

    protected void grdMultiEtiquetas_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}
    }

    protected void grdMultiEtiquetas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          



          ApplyBusinessRulesMulti(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, 29989, e.Row); 
      }
    }
    

    protected void autoPopulateEtiquetas(object[] parameters)
    {
        Session["RNmyMultiEtiquetas"] = null;
        string[,] x = (string[,])parameters[0];
        string querySQL = (string)parameters[1];
        myMultiEtiquetasArray.Clear();
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(querySQL);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        DataTable source = crearTabla(x);
        DataTable destination = llenarTabla(x, source, ds);
        int iColumnaQuery = 0;
        for (int i = 0; i <= destination.Rows.Count - 1; i++)
        {
	    iColumnaQuery = 0;
            DataRow dr = destination.Rows[i];
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Articulo = MyFunctions.FormatNumberNull(myDataDetalle.Articulo);
            else
                myDataDetalle.Articulo = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            myDataDetalle.Etiqueta = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;

            myMultiEtiquetasArray.Add(myDataDetalle);
        }
        grdMultiEtiquetas.DataSource = myMultiEtiquetasArray;
        grdMultiEtiquetas.DataBind();
        Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
        db.Dispose();
        com.Dispose();
        ds.Dispose();
        source.Dispose();
        destination.Dispose();
    }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult autoPopulateEtiquetasWM(string querySQL)
        {
            int iProcess = 29982;
            HttpContext.Current.Session["RNmyMultiEtiquetas"] = null;
            List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas> myMultiEtiquetasArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas>();
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
            myMultiEtiquetasArray.Clear();
            string[] separators = { "@LB@" };
            string[] split = querySQL.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                sb.AppendLine(s);
            }
            querySQL = sb.ToString();

            string[] separators2 = { "@LB" };
            string[] split2 = querySQL.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb2 = new StringBuilder();
            foreach (string s2 in split2)
            {
                sb2.AppendLine(s2);
            }
            querySQL = sb2.ToString();

            querySQL = querySQL.Replace("@LB@", " ");
            querySQL = querySQL.Replace("@LB", " ");
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(querySQL);
            com.CommandType = CommandType.Text;
            DataSet ds = db.Consulta(com);
            int iColumnaQuery = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                iColumnaQuery = 0;
                DataRow dr = ds.Tables[0].Rows[i];
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Articulo = MyFunctions.FormatNumberNull(myDataDetalle.Articulo);
            else
                myDataDetalle.Articulo = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            myDataDetalle.Etiqueta = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;

                myMultiEtiquetasArray.Add(myDataDetalle);
            }
            HttpContext.Current.Session["myMultiEtiquetas"] = myMultiEtiquetasArray;
            db.Dispose();
            com.Dispose();
            ds.Dispose();
            return new JsonResult("PostBack", true, null);
        }
    protected void grdMultiFuentes_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiFuentes.PageIndex = e.NewPageIndex;
        grdMultiFuentes.DataBind();
    }

    protected void cmbShowFuentes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiFuentes.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiFuentes.DataBind();
    }

    protected void grdMultiFuentes_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}
    }

    protected void grdMultiFuentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          



          ApplyBusinessRulesMulti(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, 30048, e.Row); 
      }
    }
    

    protected void autoPopulateFuentes(object[] parameters)
    {
        Session["RNmyMultiFuentes"] = null;
        string[,] x = (string[,])parameters[0];
        string querySQL = (string)parameters[1];
        myMultiFuentesArray.Clear();
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(querySQL);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        DataTable source = crearTabla(x);
        DataTable destination = llenarTabla(x, source, ds);
        int iColumnaQuery = 0;
        for (int i = 0; i <= destination.Rows.Count - 1; i++)
        {
	    iColumnaQuery = 0;
            DataRow dr = destination.Rows[i];
            WSRegistro_de_Contenido.objectBussinessFuentes myDataDetalle = new WSRegistro_de_Contenido.objectBussinessFuentes();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Articulo = MyFunctions.FormatNumberNull(myDataDetalle.Articulo);
            else
                myDataDetalle.Articulo = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            myDataDetalle.Fuente = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : dr[iColumnaQuery].ToString());iColumnaQuery++;

            myMultiFuentesArray.Add(myDataDetalle);
        }
        grdMultiFuentes.DataSource = myMultiFuentesArray;
        grdMultiFuentes.DataBind();
        Session["myMultiFuentes"] = myMultiFuentesArray;
        db.Dispose();
        com.Dispose();
        ds.Dispose();
        source.Dispose();
        destination.Dispose();
    }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult autoPopulateFuentesWM(string querySQL)
        {
            int iProcess = 29982;
            HttpContext.Current.Session["RNmyMultiFuentes"] = null;
            List<WSRegistro_de_Contenido.objectBussinessFuentes> myMultiFuentesArray = new List<WSRegistro_de_Contenido.objectBussinessFuentes>();
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
            myMultiFuentesArray.Clear();
            string[] separators = { "@LB@" };
            string[] split = querySQL.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                sb.AppendLine(s);
            }
            querySQL = sb.ToString();

            string[] separators2 = { "@LB" };
            string[] split2 = querySQL.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb2 = new StringBuilder();
            foreach (string s2 in split2)
            {
                sb2.AppendLine(s2);
            }
            querySQL = sb2.ToString();

            querySQL = querySQL.Replace("@LB@", " ");
            querySQL = querySQL.Replace("@LB", " ");
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(querySQL);
            com.CommandType = CommandType.Text;
            DataSet ds = db.Consulta(com);
            int iColumnaQuery = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                iColumnaQuery = 0;
                DataRow dr = ds.Tables[0].Rows[i];
                WSRegistro_de_Contenido.objectBussinessFuentes myDataDetalle = new WSRegistro_de_Contenido.objectBussinessFuentes();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Articulo = MyFunctions.FormatNumberNull(myDataDetalle.Articulo);
            else
                myDataDetalle.Articulo = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            myDataDetalle.Fuente = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : dr[iColumnaQuery].ToString());iColumnaQuery++;

                myMultiFuentesArray.Add(myDataDetalle);
            }
            HttpContext.Current.Session["myMultiFuentes"] = myMultiFuentesArray;
            db.Dispose();
            com.Dispose();
            ds.Dispose();
            return new JsonResult("PostBack", true, null);
        }
    protected void grdMultiNotificaciones_por_Observatorios_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiNotificaciones_por_Observatorios.PageIndex = e.NewPageIndex;
        grdMultiNotificaciones_por_Observatorios.DataBind();
    }

    protected void cmbShowNotificaciones_por_Observatorios_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiNotificaciones_por_Observatorios.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiNotificaciones_por_Observatorios.DataBind();
    }

    protected void grdMultiNotificaciones_por_Observatorios_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}
    }

    protected void grdMultiNotificaciones_por_Observatorios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          




          ApplyBusinessRulesMulti(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, 31010, e.Row); 
      }
    }
    

    protected void autoPopulateNotificaciones_por_Observatorios(object[] parameters)
    {
        Session["RNmyMultiNotificaciones_por_Observatorios"] = null;
        string[,] x = (string[,])parameters[0];
        string querySQL = (string)parameters[1];
        myMultiNotificaciones_por_ObservatoriosArray.Clear();
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(querySQL);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        DataTable source = crearTabla(x);
        DataTable destination = llenarTabla(x, source, ds);
        int iColumnaQuery = 0;
        for (int i = 0; i <= destination.Rows.Count - 1; i++)
        {
	    iColumnaQuery = 0;
            DataRow dr = destination.Rows[i];
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Contenido = MyFunctions.FormatNumberNull(myDataDetalle.Contenido);
            else
                myDataDetalle.Contenido = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            if (dr[iColumnaQuery].ToString() == "")
            {
                    myDataDetalle.Notificar = false; iColumnaQuery++;
            }
            else
            {
                    myDataDetalle.Notificar = (Convert.IsDBNull(dr[iColumnaQuery]) ? false : bool.Parse(dr[iColumnaQuery].ToString())); iColumnaQuery++;
            }
            myDataDetalle.Observatorio = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;

            myMultiNotificaciones_por_ObservatoriosArray.Add(myDataDetalle);
        }
        grdMultiNotificaciones_por_Observatorios.DataSource = myMultiNotificaciones_por_ObservatoriosArray;
        grdMultiNotificaciones_por_Observatorios.DataBind();
        Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
        db.Dispose();
        com.Dispose();
        ds.Dispose();
        source.Dispose();
        destination.Dispose();
    }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult autoPopulateNotificaciones_por_ObservatoriosWM(string querySQL)
        {
            int iProcess = 29982;
            HttpContext.Current.Session["RNmyMultiNotificaciones_por_Observatorios"] = null;
            List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio> myMultiNotificaciones_por_ObservatoriosArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio>();
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
            myMultiNotificaciones_por_ObservatoriosArray.Clear();
            string[] separators = { "@LB@" };
            string[] split = querySQL.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                sb.AppendLine(s);
            }
            querySQL = sb.ToString();

            string[] separators2 = { "@LB" };
            string[] split2 = querySQL.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb2 = new StringBuilder();
            foreach (string s2 in split2)
            {
                sb2.AppendLine(s2);
            }
            querySQL = sb2.ToString();

            querySQL = querySQL.Replace("@LB@", " ");
            querySQL = querySQL.Replace("@LB", " ");
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(querySQL);
            com.CommandType = CommandType.Text;
            DataSet ds = db.Consulta(com);
            int iColumnaQuery = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                iColumnaQuery = 0;
                DataRow dr = ds.Tables[0].Rows[i];
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Contenido = MyFunctions.FormatNumberNull(myDataDetalle.Contenido);
            else
                myDataDetalle.Contenido = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            if (dr[iColumnaQuery].ToString() == "")
            {
                    myDataDetalle.Notificar = false; iColumnaQuery++;
            }
            else
            {
                myDataDetalle.Notificar = true;// (Convert.IsDBNull(dr[iColumnaQuery]) ? false : bool.Parse(dr[iColumnaQuery].ToString())); iColumnaQuery++;
            }
            myDataDetalle.Observatorio = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;

                myMultiNotificaciones_por_ObservatoriosArray.Add(myDataDetalle);
            }
            HttpContext.Current.Session["myMultiNotificaciones_por_Observatorios"] = myMultiNotificaciones_por_ObservatoriosArray;
            db.Dispose();
            com.Dispose();
            ds.Dispose();
            return new JsonResult("PostBack", true, null);
        }
    protected void grdMultiNotificaciones_por_Usuario_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiNotificaciones_por_Usuario.PageIndex = e.NewPageIndex;
        grdMultiNotificaciones_por_Usuario.DataBind();
    }

    protected void cmbShowNotificaciones_por_Usuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        grdMultiNotificaciones_por_Usuario.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiNotificaciones_por_Usuario.DataBind();
    }

    protected void grdMultiNotificaciones_por_Usuario_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //@@RowCreatedMultiRenglon@@
        //}
    }

    protected void grdMultiNotificaciones_por_Usuario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          






          ApplyBusinessRulesMulti(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, 31011, e.Row); 
      }
    }
    

    protected void autoPopulateNotificaciones_por_Usuario(object[] parameters)
    {
        Session["RNmyMultiNotificaciones_por_Usuario"] = null;
        string[,] x = (string[,])parameters[0];
        string querySQL = (string)parameters[1];
        myMultiNotificaciones_por_UsuarioArray.Clear();
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(querySQL);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        DataTable source = crearTabla(x);
        DataTable destination = llenarTabla(x, source, ds);
        int iColumnaQuery = 0;
        for (int i = 0; i <= destination.Rows.Count - 1; i++)
        {
	    iColumnaQuery = 0;
            DataRow dr = destination.Rows[i];
            WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Contenido = MyFunctions.FormatNumberNull(myDataDetalle.Contenido);
            else
                myDataDetalle.Contenido = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            if (dr[iColumnaQuery].ToString() == "")
            {
                    myDataDetalle.Notificar = false; iColumnaQuery++;
            }
            else
            {
                    myDataDetalle.Notificar = (Convert.IsDBNull(dr[iColumnaQuery]) ? false : bool.Parse(dr[iColumnaQuery].ToString())); iColumnaQuery++;
            }
            myDataDetalle.Observatorio = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;
            myDataDetalle.ID_del_Cliente = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;
            myDataDetalle.Nombre = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : dr[iColumnaQuery].ToString());iColumnaQuery++;

            myMultiNotificaciones_por_UsuarioArray.Add(myDataDetalle);
        }
        grdMultiNotificaciones_por_Usuario.DataSource = myMultiNotificaciones_por_UsuarioArray;
        grdMultiNotificaciones_por_Usuario.DataBind();
        Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
        db.Dispose();
        com.Dispose();
        ds.Dispose();
        source.Dispose();
        destination.Dispose();
    }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult autoPopulateNotificaciones_por_UsuarioWM(string querySQL)
        {
            int iProcess = 29982;
            HttpContext.Current.Session["RNmyMultiNotificaciones_por_Usuario"] = null;
            List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario> myMultiNotificaciones_por_UsuarioArray = new List<WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario>();
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
            myMultiNotificaciones_por_UsuarioArray.Clear();
            string[] separators = { "@LB@" };
            string[] split = querySQL.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                sb.AppendLine(s);
            }
            querySQL = sb.ToString();

            string[] separators2 = { "@LB" };
            string[] split2 = querySQL.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb2 = new StringBuilder();
            foreach (string s2 in split2)
            {
                sb2.AppendLine(s2);
            }
            querySQL = sb2.ToString();

            querySQL = querySQL.Replace("@LB@", " ");
            querySQL = querySQL.Replace("@LB", " ");
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(querySQL);
            com.CommandType = CommandType.Text;
            DataSet ds = db.Consulta(com);
            int iColumnaQuery = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                iColumnaQuery = 0;
                DataRow dr = ds.Tables[0].Rows[i];
                WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataDetalle = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario();
            myDataDetalle.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count + 1);iColumnaQuery++;
            if (HttpContext.Current.Session["Tipo_Transaccion"].ToString() == "New")
                myDataDetalle.Contenido = MyFunctions.FormatNumberNull(myDataDetalle.Contenido);
            else
                myDataDetalle.Contenido = int.Parse(HttpContext.Current.Session["Folio"].ToString());
            iColumnaQuery++;
            if (dr[iColumnaQuery].ToString() == "")
            {
                    myDataDetalle.Notificar = false; iColumnaQuery++;
            }
            else
            {
                var x = dr[iColumnaQuery].ToString();
                var z = 0;
                myDataDetalle.Notificar = false;// (Convert.IsDBNull(dr[iColumnaQuery]) ? false : bool.Parse(dr[iColumnaQuery].ToString())); iColumnaQuery++;
            }
            myDataDetalle.Observatorio = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;
            myDataDetalle.ID_del_Cliente = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : (int?)int.Parse(dr[iColumnaQuery].ToString()));iColumnaQuery++;
            myDataDetalle.Nombre = (Convert.IsDBNull(dr[iColumnaQuery]) ? null : dr[iColumnaQuery].ToString());iColumnaQuery++;

                myMultiNotificaciones_por_UsuarioArray.Add(myDataDetalle);
            }
            HttpContext.Current.Session["myMultiNotificaciones_por_Usuario"] = myMultiNotificaciones_por_UsuarioArray;
            db.Dispose();
            com.Dispose();
            ds.Dispose();
            return new JsonResult("PostBack", true, null);
        }

    
    protected void cmdEtiquetasAdd_Click(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas myDataEtiquetas = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Etiquetas();
        myDataEtiquetas.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEtiquetasArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 29989);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiEtiquetasArray.Add(myDataEtiquetas);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 29989);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiEtiquetas.PageIndex = grdMultiEtiquetas.PageCount;
        grdMultiEtiquetas.DataSource = myMultiEtiquetasArray;
        grdMultiEtiquetas.DataBind();
        Session["ShowPageEtiquetas"] = "1";
    }

    protected void grdPagerEtiquetas_PageNumberChanged(object sender, TTPagers.PageNumberChangedEventArgs e)
    {
        Session["PageLoad"] = "1";
    }

    protected void cmdFuentesAdd_Click(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        WSRegistro_de_Contenido.objectBussinessFuentes myDataFuentes = new WSRegistro_de_Contenido.objectBussinessFuentes();
        myDataFuentes.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFuentesArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 30048);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiFuentesArray.Add(myDataFuentes);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 30048);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiFuentes.PageIndex = grdMultiFuentes.PageCount;
        grdMultiFuentes.DataSource = myMultiFuentesArray;
        grdMultiFuentes.DataBind();
        Session["ShowPageFuentes"] = "1";
    }

    protected void grdPagerFuentes_PageNumberChanged(object sender, TTPagers.PageNumberChangedEventArgs e)
    {
        Session["PageLoad"] = "1";
    }

    protected void cmdNotificaciones_por_ObservatoriosAdd_Click(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio myDataNotificaciones_por_Observatorios = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Observatorio();
        myDataNotificaciones_por_Observatorios.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_ObservatoriosArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 31010);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiNotificaciones_por_ObservatoriosArray.Add(myDataNotificaciones_por_Observatorios);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 31010);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiNotificaciones_por_Observatorios.PageIndex = grdMultiNotificaciones_por_Observatorios.PageCount;
        grdMultiNotificaciones_por_Observatorios.DataSource = myMultiNotificaciones_por_ObservatoriosArray;
        grdMultiNotificaciones_por_Observatorios.DataBind();
        Session["ShowPageNotificaciones_por_Observatorios"] = "1";
    }

    protected void grdPagerNotificaciones_por_Observatorios_PageNumberChanged(object sender, TTPagers.PageNumberChangedEventArgs e)
    {
        Session["PageLoad"] = "1";
    }

    protected void cmdNotificaciones_por_UsuarioAdd_Click(object sender, EventArgs e)
    {
        Session["PageLoad"] = "1";
        WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario myDataNotificaciones_por_Usuario = new WSRegistro_de_Contenido.objectBussinessDetalle_de_Notificacion_por_Usuario();
        myDataNotificaciones_por_Usuario.Clave = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiNotificaciones_por_UsuarioArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 31011);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiNotificaciones_por_UsuarioArray.Add(myDataNotificaciones_por_Usuario);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 31011);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiNotificaciones_por_Usuario.PageIndex = grdMultiNotificaciones_por_Usuario.PageCount;
        grdMultiNotificaciones_por_Usuario.DataSource = myMultiNotificaciones_por_UsuarioArray;
        grdMultiNotificaciones_por_Usuario.DataBind();
        Session["ShowPageNotificaciones_por_Usuario"] = "1";
    }

    protected void grdPagerNotificaciones_por_Usuario_PageNumberChanged(object sender, TTPagers.PageNumberChangedEventArgs e)
    {
        Session["PageLoad"] = "1";
    }



   private void managePostImagen()
    {
    }   private void managePostImagen_Miniatura()
    {
    }   private void managePostAdjuntar_PDF()
    {
    }

     protected void lkbVerImagen_Click(object sender, EventArgs e)
	{
		int posIni = 0;
		int posFin = 0;
		string Extencion = "";
		Session["verClick"] = 1;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + txtImagen.Text);
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


		posIni = lkbVerImagen.Text.IndexOf(".", 0);
		posFin = lkbVerImagen.Text.Length - 1 - (posIni - 1);
		Extencion = lkbVerImagen.Text.Substring(posIni, posFin);
		if (Extencion.ToUpper() == ".JPG" || Extencion.ToUpper() == ".GIF" || Extencion.ToUpper() == ".BMP"){
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "OpenImage('TempFiles/" + NombreArchivo + "')", true);
		}else{
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "var myWindow = window.open('TempFiles/" + NombreArchivo + "','archivo'); myWindow.focus();", true);
		}
			
	}

	protected void IbtnCambiarArchivoImagen_Click(object sender, ImageClickEventArgs e)
	{
                                fuaImagen.Visible = true;
                                buttonSubmitImagen.Visible = true;
                                labelNoResultsImagen.Visible = true;
                                repeaterResultsImagen.Visible = true;
                                //-------------------------------------------------
		lkbVerImagen.Visible = false;
		Session["CambiarArchivo"] = 1;
		IbtnCambiarArchivoImagen.Visible = false;
		IbtnBorrarArchivoImagen.Visible = false;
		//Borrar archivo temporal
		File.Delete(Server.MapPath("TempFiles/" + lkbVerImagen.Text));
		//-------------------------
		cvRadUploadImagen.Enabled = true;
        cvRadUploadImagen.Visible = true;
        if (imgOblImagen.Visible)
            RFVImagen.Enabled = true; 
	}
	protected void IbtnBorrarArchivoImagen_Click(object sender, ImageClickEventArgs e)
	{
		txtImagen.Text = "";
		fuaImagen.Visible = true;
                                buttonSubmitImagen.Visible = true;
                                labelNoResultsImagen.Visible = true;
                                repeaterResultsImagen.Visible = true;
                                //-------------------------------------------------
		Session["CambiarArchivo"] = 0;
		lkbVerImagen.Visible = false;
		lkbVerImagen.Text = "";
		IbtnCambiarArchivoImagen.Visible = false;
		IbtnBorrarArchivoImagen.Visible = false;
		//-------------------------
		cvRadUploadImagen.Enabled = true;
        cvRadUploadImagen.Visible = true;
        if (imgOblImagen.Visible)
            RFVImagen.Enabled = true; 
	}
	protected void buttonSubmitImagen_Click(object sender, System.EventArgs e)
  {
      if (fuaImagen.UploadedFiles.Count > 0)
      {
          repeaterResultsImagen.DataSource = fuaImagen.UploadedFiles;
          repeaterResultsImagen.DataBind();
          labelNoResultsImagen.Visible = false;
          repeaterResultsImagen.Visible = true;

          foreach (Telerik.Web.UI.UploadedFile validFile in fuaImagen.UploadedFiles)
          {
              Session["ArchivoImagen"] = validFile.GetName();
              RFVImagen.Enabled = false;
          }
      }
      else
      {
          labelNoResultsImagen.Visible = true;
          repeaterResultsImagen.Visible = false;
      }
      Session["PageLoad"] = "1";
  }
  protected void fuaImagen_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
  {
      int counter = 1;

      Telerik.Web.UI.UploadedFile file = e.UploadedFile;

      string targetFolder = Server.MapPath(fuaImagen.TargetFolder);

      string targetFileName = Path.Combine(targetFolder,
          file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

      while (System.IO.File.Exists(targetFileName))
      {
          counter++;
          targetFileName = Path.Combine(targetFolder,
              file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
      }

      file.SaveAs(targetFileName);
  }     protected void lkbVerImagen_Miniatura_Click(object sender, EventArgs e)
	{
		int posIni = 0;
		int posFin = 0;
		string Extencion = "";
		Session["verClick"] = 1;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + txtImagen_Miniatura.Text);
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


		posIni = lkbVerImagen_Miniatura.Text.IndexOf(".", 0);
		posFin = lkbVerImagen_Miniatura.Text.Length - 1 - (posIni - 1);
		Extencion = lkbVerImagen_Miniatura.Text.Substring(posIni, posFin);
		if (Extencion.ToUpper() == ".JPG" || Extencion.ToUpper() == ".GIF" || Extencion.ToUpper() == ".BMP"){
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "OpenImage('TempFiles/" + NombreArchivo + "')", true);
		}else{
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "var myWindow = window.open('TempFiles/" + NombreArchivo + "','archivo'); myWindow.focus();", true);
		}
			
	}

	protected void IbtnCambiarArchivoImagen_Miniatura_Click(object sender, ImageClickEventArgs e)
	{
                                fuaImagen_Miniatura.Visible = true;
                                buttonSubmitImagen_Miniatura.Visible = true;
                                labelNoResultsImagen_Miniatura.Visible = true;
                                repeaterResultsImagen_Miniatura.Visible = true;
                                //-------------------------------------------------
		lkbVerImagen_Miniatura.Visible = false;
		Session["CambiarArchivo"] = 1;
		IbtnCambiarArchivoImagen_Miniatura.Visible = false;
		IbtnBorrarArchivoImagen_Miniatura.Visible = false;
		//Borrar archivo temporal
		File.Delete(Server.MapPath("TempFiles/" + lkbVerImagen_Miniatura.Text));
		//-------------------------
		cvRadUploadImagen_Miniatura.Enabled = true;
        cvRadUploadImagen_Miniatura.Visible = true;
        if (imgOblImagen_Miniatura.Visible)
            RFVImagen_Miniatura.Enabled = true; 
	}
	protected void IbtnBorrarArchivoImagen_Miniatura_Click(object sender, ImageClickEventArgs e)
	{
		txtImagen_Miniatura.Text = "";
		fuaImagen_Miniatura.Visible = true;
                                buttonSubmitImagen_Miniatura.Visible = true;
                                labelNoResultsImagen_Miniatura.Visible = true;
                                repeaterResultsImagen_Miniatura.Visible = true;
                                //-------------------------------------------------
		Session["CambiarArchivo"] = 0;
		lkbVerImagen_Miniatura.Visible = false;
		lkbVerImagen_Miniatura.Text = "";
		IbtnCambiarArchivoImagen_Miniatura.Visible = false;
		IbtnBorrarArchivoImagen_Miniatura.Visible = false;
		//-------------------------
		cvRadUploadImagen_Miniatura.Enabled = true;
        cvRadUploadImagen_Miniatura.Visible = true;
        if (imgOblImagen_Miniatura.Visible)
            RFVImagen_Miniatura.Enabled = true; 
	}
	protected void buttonSubmitImagen_Miniatura_Click(object sender, System.EventArgs e)
  {
      if (fuaImagen_Miniatura.UploadedFiles.Count > 0)
      {
          repeaterResultsImagen_Miniatura.DataSource = fuaImagen_Miniatura.UploadedFiles;
          repeaterResultsImagen_Miniatura.DataBind();
          labelNoResultsImagen_Miniatura.Visible = false;
          repeaterResultsImagen_Miniatura.Visible = true;

          foreach (Telerik.Web.UI.UploadedFile validFile in fuaImagen_Miniatura.UploadedFiles)
          {
              Session["ArchivoImagen_Miniatura"] = validFile.GetName();
              RFVImagen_Miniatura.Enabled = false;
          }
      }
      else
      {
          labelNoResultsImagen_Miniatura.Visible = true;
          repeaterResultsImagen_Miniatura.Visible = false;
      }
      Session["PageLoad"] = "1";
  }
  protected void fuaImagen_Miniatura_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
  {
      int counter = 1;

      Telerik.Web.UI.UploadedFile file = e.UploadedFile;

      string targetFolder = Server.MapPath(fuaImagen_Miniatura.TargetFolder);

      string targetFileName = Path.Combine(targetFolder,
          file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

      while (System.IO.File.Exists(targetFileName))
      {
          counter++;
          targetFileName = Path.Combine(targetFolder,
              file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
      }

      file.SaveAs(targetFileName);
  }     protected void lkbVerAdjuntar_PDF_Click(object sender, EventArgs e)
	{
		int posIni = 0;
		int posFin = 0;
		string Extencion = "";
		Session["verClick"] = 1;
		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
		SqlCommand com = new SqlCommand("Select Archivo,Nombre from TTArchivos where Folio=" + txtAdjuntar_PDF.Text);
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


		posIni = lkbVerAdjuntar_PDF.Text.IndexOf(".", 0);
		posFin = lkbVerAdjuntar_PDF.Text.Length - 1 - (posIni - 1);
		Extencion = lkbVerAdjuntar_PDF.Text.Substring(posIni, posFin);
		if (Extencion.ToUpper() == ".JPG" || Extencion.ToUpper() == ".GIF" || Extencion.ToUpper() == ".BMP"){
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "OpenImage('TempFiles/" + NombreArchivo + "')", true);
		}else{
			ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "abrir", "var myWindow = window.open('TempFiles/" + NombreArchivo + "','archivo'); myWindow.focus();", true);
		}
			
	}

	protected void IbtnCambiarArchivoAdjuntar_PDF_Click(object sender, ImageClickEventArgs e)
	{
                                fuaAdjuntar_PDF.Visible = true;
                                buttonSubmitAdjuntar_PDF.Visible = true;
                                labelNoResultsAdjuntar_PDF.Visible = true;
                                repeaterResultsAdjuntar_PDF.Visible = true;
                                //-------------------------------------------------
		lkbVerAdjuntar_PDF.Visible = false;
		Session["CambiarArchivo"] = 1;
		IbtnCambiarArchivoAdjuntar_PDF.Visible = false;
		IbtnBorrarArchivoAdjuntar_PDF.Visible = false;
		//Borrar archivo temporal
		File.Delete(Server.MapPath("TempFiles/" + lkbVerAdjuntar_PDF.Text));
		//-------------------------
		cvRadUploadAdjuntar_PDF.Enabled = true;
        cvRadUploadAdjuntar_PDF.Visible = true;
        if (imgOblAdjuntar_PDF.Visible)
            RFVAdjuntar_PDF.Enabled = true; 
	}
	protected void IbtnBorrarArchivoAdjuntar_PDF_Click(object sender, ImageClickEventArgs e)
	{
		txtAdjuntar_PDF.Text = "";
		fuaAdjuntar_PDF.Visible = true;
                                buttonSubmitAdjuntar_PDF.Visible = true;
                                labelNoResultsAdjuntar_PDF.Visible = true;
                                repeaterResultsAdjuntar_PDF.Visible = true;
                                //-------------------------------------------------
		Session["CambiarArchivo"] = 0;
		lkbVerAdjuntar_PDF.Visible = false;
		lkbVerAdjuntar_PDF.Text = "";
		IbtnCambiarArchivoAdjuntar_PDF.Visible = false;
		IbtnBorrarArchivoAdjuntar_PDF.Visible = false;
		//-------------------------
		cvRadUploadAdjuntar_PDF.Enabled = true;
        cvRadUploadAdjuntar_PDF.Visible = true;
        if (imgOblAdjuntar_PDF.Visible)
            RFVAdjuntar_PDF.Enabled = true; 
	}
	protected void buttonSubmitAdjuntar_PDF_Click(object sender, System.EventArgs e)
  {
      if (fuaAdjuntar_PDF.UploadedFiles.Count > 0)
      {
          repeaterResultsAdjuntar_PDF.DataSource = fuaAdjuntar_PDF.UploadedFiles;
          repeaterResultsAdjuntar_PDF.DataBind();
          labelNoResultsAdjuntar_PDF.Visible = false;
          repeaterResultsAdjuntar_PDF.Visible = true;

          foreach (Telerik.Web.UI.UploadedFile validFile in fuaAdjuntar_PDF.UploadedFiles)
          {
              Session["ArchivoAdjuntar_PDF"] = validFile.GetName();
              RFVAdjuntar_PDF.Enabled = false;
          }
      }
      else
      {
          labelNoResultsAdjuntar_PDF.Visible = true;
          repeaterResultsAdjuntar_PDF.Visible = false;
      }
      Session["PageLoad"] = "1";
  }
  protected void fuaAdjuntar_PDF_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
  {
      int counter = 1;

      Telerik.Web.UI.UploadedFile file = e.UploadedFile;

      string targetFolder = Server.MapPath(fuaAdjuntar_PDF.TargetFolder);

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

