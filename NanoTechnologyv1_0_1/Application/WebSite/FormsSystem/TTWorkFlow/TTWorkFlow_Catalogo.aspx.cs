/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTWorkFlow
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
using WSTTWorkFlow;
using System.Linq;

namespace WebForms
{	
public partial class TTWorkFlow_Catalogo : TTBasePage.TTBasePage, ICallbackEventHandler 
{
    private WSTTWorkFlow.objectBussinessTTWorkFlow myTTWorkFlow = new WSTTWorkFlow.objectBussinessTTWorkFlow();
    private WSTTWorkFlow.GlobalData userData;
    public int iProcess = 15799;
    private string sDNTNombre = "TTWorkFlow";
    private string sDNTDescripcion = "WorkFlow";
    private string scallBackReturnVariable = null;
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Fases> myMultiFasesArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Fases>();
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Estados> myMultiEstadosArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Estados>();
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados> myMultiMatriz_de_EstadosArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados>();
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado> myMultiRoles_por_EstadoArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado>();
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado> myMultiInformacion_por_EstadoArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado>();
        private List<WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado> myMultiCondiciones_por_EstadoArray = new List<WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado>();


#region CallBackAsincrono
    public void RaiseCallbackEvent(string eventargument)
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
        
                    if (multiRenlgonName == "Fases")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Fases myDataFases = myMultiFasesArray.Find(p => p.Folio == key);
            if (myDataFases.Folio == null)
            {
                myDataFases.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFasesArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFasesArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowFases.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataFases = myMultiFasesArray.Find(p => p.Folio == key);
                    if (myDataFases != null)
                        myMultiFasesArray.Remove(myDataFases);
            }
            
            grdMultiFases.DataSource = myMultiFasesArray;
            grdMultiFases.DataBind();

            for (int i = 0; i < grdMultiFases.DataKeys.Count; i++)
                if ((int?)grdMultiFases.DataKeys[i]["Folio"] == key)
                {
                    grdMultiFases.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiFases.Rows[grdMultiFases.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Numero_de_Fase":
                            {
                                myDataFases.Numero_de_Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Nombre":
                            {
                                myDataFases.Nombre = ValueData;
                                break;
                            }
                        case "Tipo_de_Fase":
                            {
                                myDataFases.Tipo_de_Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Tipo_de_Distribucion_de_Trabajo":
                            {
                                myDataFases.Tipo_de_Distribucion_de_Trabajo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Tipo_de_Control_de_Flujo":
                            {
                                myDataFases.Tipo_de_Control_de_Flujo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Estatus_de_Fase":
                            {
                                myDataFases.Estatus_de_Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15801, grdMultiFases.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivFases.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
        if (multiRenlgonName == "Estados")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Estados myDataEstados = myMultiEstadosArray.Find(p => p.Folio == key);
            if (myDataEstados.Folio == null)
            {
                myDataEstados.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEstadosArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEstadosArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowEstados.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataEstados = myMultiEstadosArray.Find(p => p.Folio == key);
                    if (myDataEstados != null)
                        myMultiEstadosArray.Remove(myDataEstados);
            }
            
            grdMultiEstados.DataSource = myMultiEstadosArray;
            grdMultiEstados.DataBind();

            for (int i = 0; i < grdMultiEstados.DataKeys.Count; i++)
                if ((int?)grdMultiEstados.DataKeys[i]["Folio"] == key)
                {
                    grdMultiEstados.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiEstados.Rows[grdMultiEstados.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Fase":
                            {
                                myDataEstados.Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Proceso":
                            {
                                myDataEstados.Proceso = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Campo":
                            {
                                myDataEstados.Campo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Codigo_Estado":
                            {
                                myDataEstados.Codigo_Estado = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Nombre":
                            {
                                myDataEstados.Nombre = ValueData;
                                break;
                            }
                        case "Valor":
                            {
                                myDataEstados.Valor = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Texto":
                            {
                                myDataEstados.Texto = ValueData;
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15809, grdMultiEstados.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivEstados.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
        if (multiRenlgonName == "Matriz_de_Estados")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados myDataMatriz_de_Estados = myMultiMatriz_de_EstadosArray.Find(p => p.Folio == key);
            if (myDataMatriz_de_Estados.Folio == null)
            {
                myDataMatriz_de_Estados.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiMatriz_de_EstadosArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiMatriz_de_EstadosArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowMatriz_de_Estados.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataMatriz_de_Estados = myMultiMatriz_de_EstadosArray.Find(p => p.Folio == key);
                    if (myDataMatriz_de_Estados != null)
                        myMultiMatriz_de_EstadosArray.Remove(myDataMatriz_de_Estados);
            }
            
            grdMultiMatriz_de_Estados.DataSource = myMultiMatriz_de_EstadosArray;
            grdMultiMatriz_de_Estados.DataBind();

            for (int i = 0; i < grdMultiMatriz_de_Estados.DataKeys.Count; i++)
                if ((int?)grdMultiMatriz_de_Estados.DataKeys[i]["Folio"] == key)
                {
                    grdMultiMatriz_de_Estados.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiMatriz_de_Estados.Rows[grdMultiMatriz_de_Estados.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Fase":
                            {
                                myDataMatriz_de_Estados.Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Estado":
                            {
                                myDataMatriz_de_Estados.Estado = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Proceso":
                            {
                                myDataMatriz_de_Estados.Proceso = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Campo":
                            {
                                myDataMatriz_de_Estados.Campo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Visible":
                            {
                                myDataMatriz_de_Estados.Visible = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Obligatorio":
                            {
                                myDataMatriz_de_Estados.Obligatorio = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Solo_Lectura":
                            {
                                myDataMatriz_de_Estados.Solo_Lectura = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Etiqueta":
                            {
                                myDataMatriz_de_Estados.Etiqueta = ValueData;
                                break;
                            }
                        case "Valor_por_Defecto":
                            {
                                myDataMatriz_de_Estados.Valor_por_Defecto = ValueData;
                                break;
                            }
                        case "Texto_de_Ayuda":
                            {
                                myDataMatriz_de_Estados.Texto_de_Ayuda = ValueData;
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15810, grdMultiMatriz_de_Estados.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivMatriz_de_Estados.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
        if (multiRenlgonName == "Roles_por_Estado")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado myDataRoles_por_Estado = myMultiRoles_por_EstadoArray.Find(p => p.Folio == key);
            if (myDataRoles_por_Estado.Folio == null)
            {
                myDataRoles_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiRoles_por_EstadoArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiRoles_por_EstadoArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowRoles_por_Estado.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataRoles_por_Estado = myMultiRoles_por_EstadoArray.Find(p => p.Folio == key);
                    if (myDataRoles_por_Estado != null)
                        myMultiRoles_por_EstadoArray.Remove(myDataRoles_por_Estado);
            }
            
            grdMultiRoles_por_Estado.DataSource = myMultiRoles_por_EstadoArray;
            grdMultiRoles_por_Estado.DataBind();

            for (int i = 0; i < grdMultiRoles_por_Estado.DataKeys.Count; i++)
                if ((int?)grdMultiRoles_por_Estado.DataKeys[i]["Folio"] == key)
                {
                    grdMultiRoles_por_Estado.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiRoles_por_Estado.Rows[grdMultiRoles_por_Estado.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Fase":
                            {
                                myDataRoles_por_Estado.Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Estado":
                            {
                                myDataRoles_por_Estado.Estado = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Rol_de_Usuario":
                            {
                                myDataRoles_por_Estado.Rol_de_Usuario = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Transicion_de_Fase":
                            {
                                myDataRoles_por_Estado.Transicion_de_Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Consultar":
                            {
                                myDataRoles_por_Estado.Permiso_Consultar = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Nuevo":
                            {
                                myDataRoles_por_Estado.Permiso_Nuevo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Modificar":
                            {
                                myDataRoles_por_Estado.Permiso_Modificar = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Eliminar":
                            {
                                myDataRoles_por_Estado.Permiso_Eliminar = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Exportar":
                            {
                                myDataRoles_por_Estado.Permiso_Exportar = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Imprimir":
                            {
                                myDataRoles_por_Estado.Permiso_Imprimir = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Permiso_Configuracion":
                            {
                                myDataRoles_por_Estado.Permiso_Configuracion = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15812, grdMultiRoles_por_Estado.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivRoles_por_Estado.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
        if (multiRenlgonName == "Informacion_por_Estado")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado myDataInformacion_por_Estado = myMultiInformacion_por_EstadoArray.Find(p => p.Folio == key);
            if (myDataInformacion_por_Estado.Folio == null)
            {
                myDataInformacion_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiInformacion_por_EstadoArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiInformacion_por_EstadoArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowInformacion_por_Estado.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataInformacion_por_Estado = myMultiInformacion_por_EstadoArray.Find(p => p.Folio == key);
                    if (myDataInformacion_por_Estado != null)
                        myMultiInformacion_por_EstadoArray.Remove(myDataInformacion_por_Estado);
            }
            
            grdMultiInformacion_por_Estado.DataSource = myMultiInformacion_por_EstadoArray;
            grdMultiInformacion_por_Estado.DataBind();

            for (int i = 0; i < grdMultiInformacion_por_Estado.DataKeys.Count; i++)
                if ((int?)grdMultiInformacion_por_Estado.DataKeys[i]["Folio"] == key)
                {
                    grdMultiInformacion_por_Estado.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiInformacion_por_Estado.Rows[grdMultiInformacion_por_Estado.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Fase":
                            {
                                myDataInformacion_por_Estado.Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Estado":
                            {
                                myDataInformacion_por_Estado.Estado = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Proceso":
                            {
                                myDataInformacion_por_Estado.Proceso = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Carpeta":
                            {
                                myDataInformacion_por_Estado.Carpeta = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Visible":
                            {
                                myDataInformacion_por_Estado.Visible = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Solo_Lectura":
                            {
                                myDataInformacion_por_Estado.Solo_Lectura = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Obligatorios":
                            {
                                myDataInformacion_por_Estado.Obligatorios = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Etiqueta":
                            {
                                myDataInformacion_por_Estado.Etiqueta = ValueData;
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15814, grdMultiInformacion_por_Estado.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivInformacion_por_Estado.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
        if (multiRenlgonName == "Condiciones_por_Estado")
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado myDataCondiciones_por_Estado = myMultiCondiciones_por_EstadoArray.Find(p => p.Folio == key);
            if (myDataCondiciones_por_Estado.Folio == null)
            {
                myDataCondiciones_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiCondiciones_por_EstadoArray.Count);
                key = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiCondiciones_por_EstadoArray.Count);
                updateKey = string.Format("__doPostBack('{0}', '');", cmbShowCondiciones_por_Estado.ClientID);
            }
            if (commandName == "Delete")
            {
                myDataCondiciones_por_Estado = myMultiCondiciones_por_EstadoArray.Find(p => p.Folio == key);
                    if (myDataCondiciones_por_Estado != null)
                        myMultiCondiciones_por_EstadoArray.Remove(myDataCondiciones_por_Estado);
            }
            
            grdMultiCondiciones_por_Estado.DataSource = myMultiCondiciones_por_EstadoArray;
            grdMultiCondiciones_por_Estado.DataBind();

            for (int i = 0; i < grdMultiCondiciones_por_Estado.DataKeys.Count; i++)
                if ((int?)grdMultiCondiciones_por_Estado.DataKeys[i]["Folio"] == key)
                {
                    grdMultiCondiciones_por_Estado.SelectedIndex = i;
                    break;
                }
               
            if (commandName == "Modify")
            {
                GridViewRow grvRow = grdMultiCondiciones_por_Estado.Rows[grdMultiCondiciones_por_Estado.SelectedIndex];        
                switch (columName)
                {                    
        

                        case "Fase":
                            {
                                myDataCondiciones_por_Estado.Fase = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Estado":
                            {
                                myDataCondiciones_por_Estado.Estado = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Operador_de_Condicion":
                            {
                                myDataCondiciones_por_Estado.Operador_de_Condicion = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Proceso":
                            {
                                myDataCondiciones_por_Estado.Proceso = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Campo":
                            {
                                myDataCondiciones_por_Estado.Campo = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Condicion":
                            {
                                myDataCondiciones_por_Estado.Condicion = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Operador":
                            {
                                myDataCondiciones_por_Estado.Operador = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }
                        case "Valor_Operador":
                            {
                                myDataCondiciones_por_Estado.Valor_Operador = ValueData;
                                break;
                            }
                        case "Prioridad":
                            {
                                myDataCondiciones_por_Estado.Prioridad = MyFunctions.FormatNumberNull(ValueData);
                                break;
                            }

                }   
                grvControl = grvRow.FindControl(controlId);
                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, 15815, grdMultiCondiciones_por_Estado.SelectedIndex, grvControl);
            }       

            //ID del Div Asíncrono
            _Callback += "<#>" + asyncDivCondiciones_por_Estado.ClientID;
            //Concatena Mensajes de Reglas de Negocio
            _Callback += "<#>" + this.sPrerenderMessageBox + updateKey;
            //Agrega ID del Control que genero el evento
            //_Callback += "<#>" + grvControl.ClientID;
        }
            
        }
    }    
    private string _Callback;

    public string GetCallbackResult()
    {
        return _Callback;
    }
    #endregion

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        int folio = 0;
        try { folio = Convert.ToInt32(txtFolio.Text); }
        catch { }
        ddlTTWorkFlow_Folio.SelectedValue = folio.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        string cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        string callbackscript = "function callserver(arg,context) {" + cbRef + "}";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);

        

        System.Web.UI.ScriptManager ajaxSM = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ScriptManager1");
        if (ajaxSM != null)
            ajaxSM.AsyncPostBackTimeout = 3600;

        
        
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");

        if (!Page.IsPostBack)
        {
                    Session["myMultiFases"] = null;
            myMultiFasesArray = new List<objectBussinessTTWorkFlow_Fases>();
            Session["myMultiEstados"] = null;
            myMultiEstadosArray = new List<objectBussinessTTWorkFlow_Estados>();
            Session["myMultiMatriz_de_Estados"] = null;
            myMultiMatriz_de_EstadosArray = new List<objectBussinessTTWorkFlow_Matriz_de_Estados>();
            Session["myMultiRoles_por_Estado"] = null;
            myMultiRoles_por_EstadoArray = new List<objectBussinessTTWorkFlow_Roles_por_Estado>();
            Session["myMultiInformacion_por_Estado"] = null;
            myMultiInformacion_por_EstadoArray = new List<objectBussinessTTWorkFlow_Informacion_por_Estado>();
            Session["myMultiCondiciones_por_Estado"] = null;
            myMultiCondiciones_por_EstadoArray = new List<objectBussinessTTWorkFlow_Condiciones_por_Estado>();

	
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


        if (Session["myMultiFases"] != null)
                    myMultiFasesArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Fases>)Session["myMultiFases"];

        if (Session["myMultiEstados"] != null)
                    myMultiEstadosArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Estados>)Session["myMultiEstados"];

        if (Session["myMultiMatriz_de_Estados"] != null)
                    myMultiMatriz_de_EstadosArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados>)Session["myMultiMatriz_de_Estados"];

        if (Session["myMultiRoles_por_Estado"] != null)
                    myMultiRoles_por_EstadoArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado>)Session["myMultiRoles_por_Estado"];

        if (Session["myMultiInformacion_por_Estado"] != null)
                    myMultiInformacion_por_EstadoArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado>)Session["myMultiInformacion_por_Estado"];

        if (Session["myMultiCondiciones_por_Estado"] != null)
                    myMultiCondiciones_por_EstadoArray = (List<WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado>)Session["myMultiCondiciones_por_Estado"];



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
                txtFolio.Enabled=false;
        txtNombre.Enabled=false;
        txtDescripcion.Enabled=false;
        txtObjetivo.Enabled=false;
        ddlEstatus.Enabled=false;
        TTbcEstatus.ImgButton.Visible = false;

        grdMultiFases.Enabled=false;
        grdMultiEstados.Enabled=false;
        grdMultiMatriz_de_Estados.Enabled=false;
        grdMultiRoles_por_Estado.Enabled=false;
        grdMultiInformacion_por_Estado.Enabled=false;
        grdMultiCondiciones_por_Estado.Enabled=false;

        
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
        userData = new WSTTWorkFlow.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTWorkFlow.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
        //-------------------------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------
        TTbcEstatus.WebControl = ddlEstatus;
        TTbcEstatus.FillDataControlFunction = MyFunctions.FillDataControl;
        TTbcEstatus.GetControlDataSetFunctionWithString = myTTWorkFlow.FillDataEstatus;
        TTbcEstatus.ParentWebControl = null;

        
        //-------------------------------------------------------------------------------------------------------------
        grdPagerFases.DataGrid = grdMultiFases;
grdPagerEstados.DataGrid = grdMultiEstados;
grdPagerMatriz_de_Estados.DataGrid = grdMultiMatriz_de_Estados;
grdPagerRoles_por_Estado.DataGrid = grdMultiRoles_por_Estado;
grdPagerInformacion_por_Estado.DataGrid = grdMultiInformacion_por_Estado;
grdPagerCondiciones_por_Estado.DataGrid = grdMultiCondiciones_por_Estado;

        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
                    Session["myMultiFases"] = myMultiFasesArray;
            if (myMultiFasesArray.Count == 0)
                myMultiFasesArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Fases());

            grdMultiFases.DataSource = myMultiFasesArray;
            grdMultiFases.DataBind();

            Session["myMultiEstados"] = myMultiEstadosArray;
            if (myMultiEstadosArray.Count == 0)
                myMultiEstadosArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Estados());

            grdMultiEstados.DataSource = myMultiEstadosArray;
            grdMultiEstados.DataBind();

            Session["myMultiMatriz_de_Estados"] = myMultiMatriz_de_EstadosArray;
            if (myMultiMatriz_de_EstadosArray.Count == 0)
                myMultiMatriz_de_EstadosArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados());

            grdMultiMatriz_de_Estados.DataSource = myMultiMatriz_de_EstadosArray;
            grdMultiMatriz_de_Estados.DataBind();

            Session["myMultiRoles_por_Estado"] = myMultiRoles_por_EstadoArray;
            if (myMultiRoles_por_EstadoArray.Count == 0)
                myMultiRoles_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado());

            grdMultiRoles_por_Estado.DataSource = myMultiRoles_por_EstadoArray;
            grdMultiRoles_por_Estado.DataBind();

            Session["myMultiInformacion_por_Estado"] = myMultiInformacion_por_EstadoArray;
            if (myMultiInformacion_por_EstadoArray.Count == 0)
                myMultiInformacion_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado());

            grdMultiInformacion_por_Estado.DataSource = myMultiInformacion_por_EstadoArray;
            grdMultiInformacion_por_Estado.DataBind();

            Session["myMultiCondiciones_por_Estado"] = myMultiCondiciones_por_EstadoArray;
            if (myMultiCondiciones_por_EstadoArray.Count == 0)
                myMultiCondiciones_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado());

            grdMultiCondiciones_por_Estado.DataSource = myMultiCondiciones_por_EstadoArray;
            grdMultiCondiciones_por_Estado.DataBind();


    }
    
    private void FillDataControls()
    {
                MyFunctions.FillDataControl(ddlEstatus, myTTWorkFlow.FillDataEstatus(""));

    }
    private void New()
    {
    }
    private void Modification()
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow1 myDataTTWorkFlow = myTTWorkFlow.GetByKey(MyFunctions.FormatNumberNull(Session["Folio"].ToString()),true);
                if (myDataTTWorkFlow.Folio.HasValue)
            txtFolio.Text = myDataTTWorkFlow.Folio.ToString();
        txtNombre.Text = myDataTTWorkFlow.Nombre;
        txtDescripcion.Text = myDataTTWorkFlow.Descripcion;
        txtObjetivo.Text = myDataTTWorkFlow.Objetivo;
        if (myDataTTWorkFlow.Estatus.HasValue)
           ddlEstatus.SelectedValue = myDataTTWorkFlow.Estatus.Value.ToString().TrimEnd(' ');
        //ddlEstatus_SelectedIndexChanged(ddlEstatus, new EventArgs());

                myMultiFasesArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Fases itm in myDataTTWorkFlow.Fases)
            myMultiFasesArray.Add(itm);
        if (myDataTTWorkFlow.Fases.Length == 0)
            myMultiFasesArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Fases());
        myMultiEstadosArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Estados itm in myDataTTWorkFlow.Estados)
            myMultiEstadosArray.Add(itm);
        if (myDataTTWorkFlow.Estados.Length == 0)
            myMultiEstadosArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Estados());
        myMultiMatriz_de_EstadosArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados itm in myDataTTWorkFlow.Matriz_de_Estados)
            myMultiMatriz_de_EstadosArray.Add(itm);
        if (myDataTTWorkFlow.Matriz_de_Estados.Length == 0)
            myMultiMatriz_de_EstadosArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados());
        myMultiRoles_por_EstadoArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado itm in myDataTTWorkFlow.Roles_por_Estado)
            myMultiRoles_por_EstadoArray.Add(itm);
        if (myDataTTWorkFlow.Roles_por_Estado.Length == 0)
            myMultiRoles_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado());
        myMultiInformacion_por_EstadoArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado itm in myDataTTWorkFlow.Informacion_por_Estado)
            myMultiInformacion_por_EstadoArray.Add(itm);
        if (myDataTTWorkFlow.Informacion_por_Estado.Length == 0)
            myMultiInformacion_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado());
        myMultiCondiciones_por_EstadoArray.Clear();
        foreach (WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado itm in myDataTTWorkFlow.Condiciones_por_Estado)
            myMultiCondiciones_por_EstadoArray.Add(itm);
        if (myDataTTWorkFlow.Condiciones_por_Estado.Length == 0)
            myMultiCondiciones_por_EstadoArray.Add(new WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado());

        
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
                tabPagFases.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Fases");
                tabPagEstados.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Estados");
                tabPagMatriz_de_Estados.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Matriz de Estados");
                tabPagRoles_por_Estado.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Roles por Estado");
                tabPagInformacion_por_Estado.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Información por Estado");
                tabPagCondiciones_por_Estado.HeaderText = MyTraductor.getTextDomain(TTTraductor.Traductor.TraductorTypeDomain.Folder, iProcess, "Condiciones por Estado");
        
        DataSet ds_controles = new DataSet();
        ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        DataView dv = new DataView(ds_controles.Tables[0]);

                dv.RowFilter = "TTMetadata_DTID = " + 35827;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblFolio.Text = MyTraductor.getTextDTID(35827, lblFolio.Text);
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
        }        dv.RowFilter = "TTMetadata_DTID = " + 35828;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblNombre.Text = MyTraductor.getTextDTID(35828, lblNombre.Text);
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
        }        dv.RowFilter = "TTMetadata_DTID = " + 35829;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblDescripcion.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblDescripcion.Text = MyTraductor.getTextDTID(35829, lblDescripcion.Text);
        txtDescripcion.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtDescripcion.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtDescripcion.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
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
        imgOblDescripcion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVDescripcion.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trDescripcion.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtDescripcion.Enabled == true)
        {
            GetFocus(txtDescripcion);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 35830;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblObjetivo.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblObjetivo.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblObjetivo.Text = MyTraductor.getTextDTID(35830, lblObjetivo.Text);
        txtObjetivo.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        txtObjetivo.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        txtObjetivo.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
            {
                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
                {
                    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
                    {
                        txtObjetivo.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
                    }
                    else
                    {
                        txtObjetivo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                    }
                }
                else
                {
                    txtObjetivo.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
                }
            }else{
                txtObjetivo.Text = "";
            }
        imgOblObjetivo.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        RFVObjetivo.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        trObjetivo.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        if (Foco == false && txtObjetivo.Enabled == true)
        {
            GetFocus(txtObjetivo);
            Foco = true;
        }        dv.RowFilter = "TTMetadata_DTID = " + 35834;
        if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        else
            lblEstatus.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        lblEstatus.Text = MyTraductor.getTextDTID(35834, lblEstatus.Text);
        ddlEstatus.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        ddlEstatus.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
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
        trEstatus.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        RFVEstatus.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        imgOblEstatus.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        if (Foco == false && ddlEstatus.Enabled == true)
        {
            GetFocus(ddlEstatus);
            Foco = true;
        }

//        UpdatePanel1.Update();
    }       
    public Boolean Insert_row()
    {
                for(int i = 0; i < myMultiFasesArray.Count; i++)
            if (myMultiFasesArray[i].Folio == null)
                myMultiFasesArray.Remove(myMultiFasesArray[i]);

        Int32?[] Fases_WorkFlow = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Folio = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Numero_de_Fase = new Int32?[myMultiFasesArray.Count];
        string[] Fases_Nombre = new string[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Fase = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Distribucion_de_Trabajo = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Control_de_Flujo = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Estatus_de_Fase = new Int32?[myMultiFasesArray.Count];

        for (int i = 0; i < myMultiFasesArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Fases myMultiFases = (WSTTWorkFlow.objectBussinessTTWorkFlow_Fases)myMultiFasesArray[i];
            Fases_WorkFlow[i] = MyFunctions.FormatNumberNull(myMultiFases.WorkFlow);
            Fases_Folio[i] = MyFunctions.FormatNumberNull(myMultiFases.Folio);
            Fases_Numero_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Numero_de_Fase);
            if (myMultiFases.Nombre == null)
            {
                Fases_Nombre[i] = "";
            }
            else
            {
                Fases_Nombre[i] = myMultiFases.Nombre;
            }
            Fases_Tipo_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Fase);
            Fases_Tipo_de_Distribucion_de_Trabajo[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Distribucion_de_Trabajo);
            Fases_Tipo_de_Control_de_Flujo[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Control_de_Flujo);
            Fases_Estatus_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Estatus_de_Fase);
            
        }
        for(int i = 0; i < myMultiEstadosArray.Count; i++)
            if (myMultiEstadosArray[i].Folio == null)
                myMultiEstadosArray.Remove(myMultiEstadosArray[i]);

        Int32?[] Estados_TTWorkFlow = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Folio = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Fase = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Proceso = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Campo = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Codigo_Estado = new Int32?[myMultiEstadosArray.Count];
        string[] Estados_Nombre = new string[myMultiEstadosArray.Count];
        Int32?[] Estados_Valor = new Int32?[myMultiEstadosArray.Count];
        string[] Estados_Texto = new string[myMultiEstadosArray.Count];

        for (int i = 0; i < myMultiEstadosArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Estados myMultiEstados = (WSTTWorkFlow.objectBussinessTTWorkFlow_Estados)myMultiEstadosArray[i];
            Estados_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiEstados.TTWorkFlow);
            Estados_Folio[i] = MyFunctions.FormatNumberNull(myMultiEstados.Folio);
            Estados_Fase[i] = MyFunctions.FormatNumberNull(myMultiEstados.Fase);
            Estados_Proceso[i] = MyFunctions.FormatNumberNull(myMultiEstados.Proceso);
            Estados_Campo[i] = MyFunctions.FormatNumberNull(myMultiEstados.Campo);
            Estados_Codigo_Estado[i] = MyFunctions.FormatNumberNull(myMultiEstados.Codigo_Estado);
            if (myMultiEstados.Nombre == null)
            {
                Estados_Nombre[i] = "";
            }
            else
            {
                Estados_Nombre[i] = myMultiEstados.Nombre;
            }
            Estados_Valor[i] = MyFunctions.FormatNumberNull(myMultiEstados.Valor);
            if (myMultiEstados.Texto == null)
            {
                Estados_Texto[i] = "";
            }
            else
            {
                Estados_Texto[i] = myMultiEstados.Texto;
            }
            
        }
        for(int i = 0; i < myMultiMatriz_de_EstadosArray.Count; i++)
            if (myMultiMatriz_de_EstadosArray[i].Folio == null)
                myMultiMatriz_de_EstadosArray.Remove(myMultiMatriz_de_EstadosArray[i]);

        Int32?[] Matriz_de_Estados_TTWorkFlow = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Folio = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Fase = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Estado = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Proceso = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Campo = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Visible = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Obligatorio = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Solo_Lectura = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Etiqueta = new string[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Valor_por_Defecto = new string[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Texto_de_Ayuda = new string[myMultiMatriz_de_EstadosArray.Count];

        for (int i = 0; i < myMultiMatriz_de_EstadosArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados myMultiMatriz_de_Estados = (WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados)myMultiMatriz_de_EstadosArray[i];
            Matriz_de_Estados_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.TTWorkFlow);
            Matriz_de_Estados_Folio[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Folio);
            Matriz_de_Estados_Fase[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Fase);
            Matriz_de_Estados_Estado[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Estado);
            Matriz_de_Estados_Proceso[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Proceso);
            Matriz_de_Estados_Campo[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Campo);
            Matriz_de_Estados_Visible[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Visible);
            Matriz_de_Estados_Obligatorio[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Obligatorio);
            Matriz_de_Estados_Solo_Lectura[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Solo_Lectura);
            if (myMultiMatriz_de_Estados.Etiqueta == null)
            {
                Matriz_de_Estados_Etiqueta[i] = "";
            }
            else
            {
                Matriz_de_Estados_Etiqueta[i] = myMultiMatriz_de_Estados.Etiqueta;
            }
            if (myMultiMatriz_de_Estados.Valor_por_Defecto == null)
            {
                Matriz_de_Estados_Valor_por_Defecto[i] = "";
            }
            else
            {
                Matriz_de_Estados_Valor_por_Defecto[i] = myMultiMatriz_de_Estados.Valor_por_Defecto;
            }
            if (myMultiMatriz_de_Estados.Texto_de_Ayuda == null)
            {
                Matriz_de_Estados_Texto_de_Ayuda[i] = "";
            }
            else
            {
                Matriz_de_Estados_Texto_de_Ayuda[i] = myMultiMatriz_de_Estados.Texto_de_Ayuda;
            }
            
        }
        for(int i = 0; i < myMultiRoles_por_EstadoArray.Count; i++)
            if (myMultiRoles_por_EstadoArray[i].Folio == null)
                myMultiRoles_por_EstadoArray.Remove(myMultiRoles_por_EstadoArray[i]);

        Int32?[] Roles_por_Estado_TTWorkFlow = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Folio = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Fase = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Estado = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Rol_de_Usuario = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Transicion_de_Fase = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Consultar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Nuevo = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Modificar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Eliminar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Exportar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Imprimir = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Configuracion = new Int32?[myMultiRoles_por_EstadoArray.Count];

        for (int i = 0; i < myMultiRoles_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado myMultiRoles_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado)myMultiRoles_por_EstadoArray[i];
            Roles_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.TTWorkFlow);
            Roles_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Folio);
            Roles_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Fase);
            Roles_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Estado);
            Roles_por_Estado_Rol_de_Usuario[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Rol_de_Usuario);
            Roles_por_Estado_Transicion_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Transicion_de_Fase);
            Roles_por_Estado_Permiso_Consultar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Consultar);
            Roles_por_Estado_Permiso_Nuevo[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Nuevo);
            Roles_por_Estado_Permiso_Modificar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Modificar);
            Roles_por_Estado_Permiso_Eliminar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Eliminar);
            Roles_por_Estado_Permiso_Exportar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Exportar);
            Roles_por_Estado_Permiso_Imprimir[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Imprimir);
            Roles_por_Estado_Permiso_Configuracion[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Configuracion);
            
        }
        for(int i = 0; i < myMultiInformacion_por_EstadoArray.Count; i++)
            if (myMultiInformacion_por_EstadoArray[i].Folio == null)
                myMultiInformacion_por_EstadoArray.Remove(myMultiInformacion_por_EstadoArray[i]);

        Int32?[] Informacion_por_Estado_TTWorkFlow = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Folio = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Fase = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Estado = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Proceso = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Carpeta = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Visible = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Solo_Lectura = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Obligatorios = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        string[] Informacion_por_Estado_Etiqueta = new string[myMultiInformacion_por_EstadoArray.Count];

        for (int i = 0; i < myMultiInformacion_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado myMultiInformacion_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado)myMultiInformacion_por_EstadoArray[i];
            Informacion_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.TTWorkFlow);
            Informacion_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Folio);
            Informacion_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Fase);
            Informacion_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Estado);
            Informacion_por_Estado_Proceso[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Proceso);
            Informacion_por_Estado_Carpeta[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Carpeta);
            Informacion_por_Estado_Visible[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Visible);
            Informacion_por_Estado_Solo_Lectura[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Solo_Lectura);
            Informacion_por_Estado_Obligatorios[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Obligatorios);
            if (myMultiInformacion_por_Estado.Etiqueta == null)
            {
                Informacion_por_Estado_Etiqueta[i] = "";
            }
            else
            {
                Informacion_por_Estado_Etiqueta[i] = myMultiInformacion_por_Estado.Etiqueta;
            }
            
        }
        for(int i = 0; i < myMultiCondiciones_por_EstadoArray.Count; i++)
            if (myMultiCondiciones_por_EstadoArray[i].Folio == null)
                myMultiCondiciones_por_EstadoArray.Remove(myMultiCondiciones_por_EstadoArray[i]);

        Int32?[] Condiciones_por_Estado_TTWorkFlow = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Folio = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Fase = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Estado = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Operador_de_Condicion = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Proceso = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Campo = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Condicion = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Operador = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        string[] Condiciones_por_Estado_Valor_Operador = new string[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Prioridad = new Int32?[myMultiCondiciones_por_EstadoArray.Count];

        for (int i = 0; i < myMultiCondiciones_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado myMultiCondiciones_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado)myMultiCondiciones_por_EstadoArray[i];
            Condiciones_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.TTWorkFlow);
            Condiciones_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Folio);
            Condiciones_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Fase);
            Condiciones_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Estado);
            Condiciones_por_Estado_Operador_de_Condicion[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Operador_de_Condicion);
            Condiciones_por_Estado_Proceso[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Proceso);
            Condiciones_por_Estado_Campo[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Campo);
            Condiciones_por_Estado_Condicion[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Condicion);
            Condiciones_por_Estado_Operador[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Operador);
            if (myMultiCondiciones_por_Estado.Valor_Operador == null)
            {
                Condiciones_por_Estado_Valor_Operador[i] = "";
            }
            else
            {
                Condiciones_por_Estado_Valor_Operador[i] = myMultiCondiciones_por_Estado.Valor_Operador;
            }
            Condiciones_por_Estado_Prioridad[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Prioridad);
            
        }

        
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Session["KeyValueInserted"] = myTTWorkFlow.InsertWithReturnValue(userData,  txtNombre.Text, txtDescripcion.Text, txtObjetivo.Text, MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), Fases_Numero_de_Fase, Fases_Nombre, Fases_Tipo_de_Fase, Fases_Tipo_de_Distribucion_de_Trabajo, Fases_Tipo_de_Control_de_Flujo, Fases_Estatus_de_Fase, Estados_Fase, Estados_Proceso, Estados_Campo, Estados_Codigo_Estado, Estados_Nombre, Estados_Valor, Estados_Texto, Matriz_de_Estados_Fase, Matriz_de_Estados_Estado, Matriz_de_Estados_Proceso, Matriz_de_Estados_Campo, Matriz_de_Estados_Visible, Matriz_de_Estados_Obligatorio, Matriz_de_Estados_Solo_Lectura, Matriz_de_Estados_Etiqueta, Matriz_de_Estados_Valor_por_Defecto, Matriz_de_Estados_Texto_de_Ayuda, Roles_por_Estado_Fase, Roles_por_Estado_Estado, Roles_por_Estado_Rol_de_Usuario, Roles_por_Estado_Transicion_de_Fase, Roles_por_Estado_Permiso_Consultar, Roles_por_Estado_Permiso_Nuevo, Roles_por_Estado_Permiso_Modificar, Roles_por_Estado_Permiso_Eliminar, Roles_por_Estado_Permiso_Exportar, Roles_por_Estado_Permiso_Imprimir, Roles_por_Estado_Permiso_Configuracion, Informacion_por_Estado_Fase, Informacion_por_Estado_Estado, Informacion_por_Estado_Proceso, Informacion_por_Estado_Carpeta, Informacion_por_Estado_Visible, Informacion_por_Estado_Solo_Lectura, Informacion_por_Estado_Obligatorios, Informacion_por_Estado_Etiqueta, Condiciones_por_Estado_Fase, Condiciones_por_Estado_Estado, Condiciones_por_Estado_Operador_de_Condicion, Condiciones_por_Estado_Proceso, Condiciones_por_Estado_Campo, Condiciones_por_Estado_Condicion, Condiciones_por_Estado_Operador, Condiciones_por_Estado_Valor_Operador, Condiciones_por_Estado_Prioridad);
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
                for(int i = 0; i < myMultiFasesArray.Count; i++)
            if (myMultiFasesArray[i].Folio == null)
                myMultiFasesArray.Remove(myMultiFasesArray[i]);

        Int32?[] Fases_WorkFlow = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Folio = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Numero_de_Fase = new Int32?[myMultiFasesArray.Count];
        string[] Fases_Nombre = new string[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Fase = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Distribucion_de_Trabajo = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Tipo_de_Control_de_Flujo = new Int32?[myMultiFasesArray.Count];
        Int32?[] Fases_Estatus_de_Fase = new Int32?[myMultiFasesArray.Count];

        for (int i = 0; i < myMultiFasesArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Fases myMultiFases = (WSTTWorkFlow.objectBussinessTTWorkFlow_Fases)myMultiFasesArray[i];
            Fases_WorkFlow[i] = MyFunctions.FormatNumberNull(myMultiFases.WorkFlow);
            Fases_Folio[i] = MyFunctions.FormatNumberNull(myMultiFases.Folio);
            Fases_Numero_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Numero_de_Fase);
            if (myMultiFases.Nombre == null)
            {
                Fases_Nombre[i] = "";
            }
            else
            {
                Fases_Nombre[i] = myMultiFases.Nombre;
            }
            Fases_Tipo_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Fase);
            Fases_Tipo_de_Distribucion_de_Trabajo[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Distribucion_de_Trabajo);
            Fases_Tipo_de_Control_de_Flujo[i] = MyFunctions.FormatNumberNull(myMultiFases.Tipo_de_Control_de_Flujo);
            Fases_Estatus_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiFases.Estatus_de_Fase);
            
        }
        for(int i = 0; i < myMultiEstadosArray.Count; i++)
            if (myMultiEstadosArray[i].Folio == null)
                myMultiEstadosArray.Remove(myMultiEstadosArray[i]);

        Int32?[] Estados_TTWorkFlow = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Folio = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Fase = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Proceso = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Campo = new Int32?[myMultiEstadosArray.Count];
        Int32?[] Estados_Codigo_Estado = new Int32?[myMultiEstadosArray.Count];
        string[] Estados_Nombre = new string[myMultiEstadosArray.Count];
        Int32?[] Estados_Valor = new Int32?[myMultiEstadosArray.Count];
        string[] Estados_Texto = new string[myMultiEstadosArray.Count];

        for (int i = 0; i < myMultiEstadosArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Estados myMultiEstados = (WSTTWorkFlow.objectBussinessTTWorkFlow_Estados)myMultiEstadosArray[i];
            Estados_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiEstados.TTWorkFlow);
            Estados_Folio[i] = MyFunctions.FormatNumberNull(myMultiEstados.Folio);
            Estados_Fase[i] = MyFunctions.FormatNumberNull(myMultiEstados.Fase);
            Estados_Proceso[i] = MyFunctions.FormatNumberNull(myMultiEstados.Proceso);
            Estados_Campo[i] = MyFunctions.FormatNumberNull(myMultiEstados.Campo);
            Estados_Codigo_Estado[i] = MyFunctions.FormatNumberNull(myMultiEstados.Codigo_Estado);
            if (myMultiEstados.Nombre == null)
            {
                Estados_Nombre[i] = "";
            }
            else
            {
                Estados_Nombre[i] = myMultiEstados.Nombre;
            }
            Estados_Valor[i] = MyFunctions.FormatNumberNull(myMultiEstados.Valor);
            if (myMultiEstados.Texto == null)
            {
                Estados_Texto[i] = "";
            }
            else
            {
                Estados_Texto[i] = myMultiEstados.Texto;
            }
            
        }
        for(int i = 0; i < myMultiMatriz_de_EstadosArray.Count; i++)
            if (myMultiMatriz_de_EstadosArray[i].Folio == null)
                myMultiMatriz_de_EstadosArray.Remove(myMultiMatriz_de_EstadosArray[i]);

        Int32?[] Matriz_de_Estados_TTWorkFlow = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Folio = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Fase = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Estado = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Proceso = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Campo = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Visible = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Obligatorio = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        Int32?[] Matriz_de_Estados_Solo_Lectura = new Int32?[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Etiqueta = new string[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Valor_por_Defecto = new string[myMultiMatriz_de_EstadosArray.Count];
        string[] Matriz_de_Estados_Texto_de_Ayuda = new string[myMultiMatriz_de_EstadosArray.Count];

        for (int i = 0; i < myMultiMatriz_de_EstadosArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados myMultiMatriz_de_Estados = (WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados)myMultiMatriz_de_EstadosArray[i];
            Matriz_de_Estados_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.TTWorkFlow);
            Matriz_de_Estados_Folio[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Folio);
            Matriz_de_Estados_Fase[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Fase);
            Matriz_de_Estados_Estado[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Estado);
            Matriz_de_Estados_Proceso[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Proceso);
            Matriz_de_Estados_Campo[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Campo);
            Matriz_de_Estados_Visible[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Visible);
            Matriz_de_Estados_Obligatorio[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Obligatorio);
            Matriz_de_Estados_Solo_Lectura[i] = MyFunctions.FormatNumberNull(myMultiMatriz_de_Estados.Solo_Lectura);
            if (myMultiMatriz_de_Estados.Etiqueta == null)
            {
                Matriz_de_Estados_Etiqueta[i] = "";
            }
            else
            {
                Matriz_de_Estados_Etiqueta[i] = myMultiMatriz_de_Estados.Etiqueta;
            }
            if (myMultiMatriz_de_Estados.Valor_por_Defecto == null)
            {
                Matriz_de_Estados_Valor_por_Defecto[i] = "";
            }
            else
            {
                Matriz_de_Estados_Valor_por_Defecto[i] = myMultiMatriz_de_Estados.Valor_por_Defecto;
            }
            if (myMultiMatriz_de_Estados.Texto_de_Ayuda == null)
            {
                Matriz_de_Estados_Texto_de_Ayuda[i] = "";
            }
            else
            {
                Matriz_de_Estados_Texto_de_Ayuda[i] = myMultiMatriz_de_Estados.Texto_de_Ayuda;
            }
            
        }
        for(int i = 0; i < myMultiRoles_por_EstadoArray.Count; i++)
            if (myMultiRoles_por_EstadoArray[i].Folio == null)
                myMultiRoles_por_EstadoArray.Remove(myMultiRoles_por_EstadoArray[i]);

        Int32?[] Roles_por_Estado_TTWorkFlow = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Folio = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Fase = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Estado = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Rol_de_Usuario = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Transicion_de_Fase = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Consultar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Nuevo = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Modificar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Eliminar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Exportar = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Imprimir = new Int32?[myMultiRoles_por_EstadoArray.Count];
        Int32?[] Roles_por_Estado_Permiso_Configuracion = new Int32?[myMultiRoles_por_EstadoArray.Count];

        for (int i = 0; i < myMultiRoles_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado myMultiRoles_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado)myMultiRoles_por_EstadoArray[i];
            Roles_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.TTWorkFlow);
            Roles_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Folio);
            Roles_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Fase);
            Roles_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Estado);
            Roles_por_Estado_Rol_de_Usuario[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Rol_de_Usuario);
            Roles_por_Estado_Transicion_de_Fase[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Transicion_de_Fase);
            Roles_por_Estado_Permiso_Consultar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Consultar);
            Roles_por_Estado_Permiso_Nuevo[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Nuevo);
            Roles_por_Estado_Permiso_Modificar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Modificar);
            Roles_por_Estado_Permiso_Eliminar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Eliminar);
            Roles_por_Estado_Permiso_Exportar[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Exportar);
            Roles_por_Estado_Permiso_Imprimir[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Imprimir);
            Roles_por_Estado_Permiso_Configuracion[i] = MyFunctions.FormatNumberNull(myMultiRoles_por_Estado.Permiso_Configuracion);
            
        }
        for(int i = 0; i < myMultiInformacion_por_EstadoArray.Count; i++)
            if (myMultiInformacion_por_EstadoArray[i].Folio == null)
                myMultiInformacion_por_EstadoArray.Remove(myMultiInformacion_por_EstadoArray[i]);

        Int32?[] Informacion_por_Estado_TTWorkFlow = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Folio = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Fase = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Estado = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Proceso = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Carpeta = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Visible = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Solo_Lectura = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        Int32?[] Informacion_por_Estado_Obligatorios = new Int32?[myMultiInformacion_por_EstadoArray.Count];
        string[] Informacion_por_Estado_Etiqueta = new string[myMultiInformacion_por_EstadoArray.Count];

        for (int i = 0; i < myMultiInformacion_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado myMultiInformacion_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado)myMultiInformacion_por_EstadoArray[i];
            Informacion_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.TTWorkFlow);
            Informacion_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Folio);
            Informacion_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Fase);
            Informacion_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Estado);
            Informacion_por_Estado_Proceso[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Proceso);
            Informacion_por_Estado_Carpeta[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Carpeta);
            Informacion_por_Estado_Visible[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Visible);
            Informacion_por_Estado_Solo_Lectura[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Solo_Lectura);
            Informacion_por_Estado_Obligatorios[i] = MyFunctions.FormatNumberNull(myMultiInformacion_por_Estado.Obligatorios);
            if (myMultiInformacion_por_Estado.Etiqueta == null)
            {
                Informacion_por_Estado_Etiqueta[i] = "";
            }
            else
            {
                Informacion_por_Estado_Etiqueta[i] = myMultiInformacion_por_Estado.Etiqueta;
            }
            
        }
        for(int i = 0; i < myMultiCondiciones_por_EstadoArray.Count; i++)
            if (myMultiCondiciones_por_EstadoArray[i].Folio == null)
                myMultiCondiciones_por_EstadoArray.Remove(myMultiCondiciones_por_EstadoArray[i]);

        Int32?[] Condiciones_por_Estado_TTWorkFlow = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Folio = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Fase = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Estado = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Operador_de_Condicion = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Proceso = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Campo = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Condicion = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Operador = new Int32?[myMultiCondiciones_por_EstadoArray.Count];
        string[] Condiciones_por_Estado_Valor_Operador = new string[myMultiCondiciones_por_EstadoArray.Count];
        Int32?[] Condiciones_por_Estado_Prioridad = new Int32?[myMultiCondiciones_por_EstadoArray.Count];

        for (int i = 0; i < myMultiCondiciones_por_EstadoArray.Count; i++)
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado myMultiCondiciones_por_Estado = (WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado)myMultiCondiciones_por_EstadoArray[i];
            Condiciones_por_Estado_TTWorkFlow[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.TTWorkFlow);
            Condiciones_por_Estado_Folio[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Folio);
            Condiciones_por_Estado_Fase[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Fase);
            Condiciones_por_Estado_Estado[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Estado);
            Condiciones_por_Estado_Operador_de_Condicion[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Operador_de_Condicion);
            Condiciones_por_Estado_Proceso[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Proceso);
            Condiciones_por_Estado_Campo[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Campo);
            Condiciones_por_Estado_Condicion[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Condicion);
            Condiciones_por_Estado_Operador[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Operador);
            if (myMultiCondiciones_por_Estado.Valor_Operador == null)
            {
                Condiciones_por_Estado_Valor_Operador[i] = "";
            }
            else
            {
                Condiciones_por_Estado_Valor_Operador[i] = myMultiCondiciones_por_Estado.Valor_Operador;
            }
            Condiciones_por_Estado_Prioridad[i] = MyFunctions.FormatNumberNull(myMultiCondiciones_por_Estado.Prioridad);
            
        }

        
        try
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                return false;
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
            myTTWorkFlow.Update(userData,  MyFunctions.FormatNumberNull(txtFolio.Text), txtNombre.Text, txtDescripcion.Text, txtObjetivo.Text, MyFunctions.FormatNumberNull(ddlEstatus.SelectedValue), Fases_WorkFlow, Fases_Folio, Fases_Numero_de_Fase, Fases_Nombre, Fases_Tipo_de_Fase, Fases_Tipo_de_Distribucion_de_Trabajo, Fases_Tipo_de_Control_de_Flujo, Fases_Estatus_de_Fase, Estados_TTWorkFlow, Estados_Folio, Estados_Fase, Estados_Proceso, Estados_Campo, Estados_Codigo_Estado, Estados_Nombre, Estados_Valor, Estados_Texto, Matriz_de_Estados_TTWorkFlow, Matriz_de_Estados_Folio, Matriz_de_Estados_Fase, Matriz_de_Estados_Estado, Matriz_de_Estados_Proceso, Matriz_de_Estados_Campo, Matriz_de_Estados_Visible, Matriz_de_Estados_Obligatorio, Matriz_de_Estados_Solo_Lectura, Matriz_de_Estados_Etiqueta, Matriz_de_Estados_Valor_por_Defecto, Matriz_de_Estados_Texto_de_Ayuda, Roles_por_Estado_TTWorkFlow, Roles_por_Estado_Folio, Roles_por_Estado_Fase, Roles_por_Estado_Estado, Roles_por_Estado_Rol_de_Usuario, Roles_por_Estado_Transicion_de_Fase, Roles_por_Estado_Permiso_Consultar, Roles_por_Estado_Permiso_Nuevo, Roles_por_Estado_Permiso_Modificar, Roles_por_Estado_Permiso_Eliminar, Roles_por_Estado_Permiso_Exportar, Roles_por_Estado_Permiso_Imprimir, Roles_por_Estado_Permiso_Configuracion, Informacion_por_Estado_TTWorkFlow, Informacion_por_Estado_Folio, Informacion_por_Estado_Fase, Informacion_por_Estado_Estado, Informacion_por_Estado_Proceso, Informacion_por_Estado_Carpeta, Informacion_por_Estado_Visible, Informacion_por_Estado_Solo_Lectura, Informacion_por_Estado_Obligatorios, Informacion_por_Estado_Etiqueta, Condiciones_por_Estado_TTWorkFlow, Condiciones_por_Estado_Folio, Condiciones_por_Estado_Fase, Condiciones_por_Estado_Estado, Condiciones_por_Estado_Operador_de_Condicion, Condiciones_por_Estado_Proceso, Condiciones_por_Estado_Campo, Condiciones_por_Estado_Condicion, Condiciones_por_Estado_Operador, Condiciones_por_Estado_Valor_Operador, Condiciones_por_Estado_Prioridad);
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
	            Session["myMultiFases"] = null;
            myMultiFasesArray = new List<objectBussinessTTWorkFlow_Fases>();
            Session["myMultiEstados"] = null;
            myMultiEstadosArray = new List<objectBussinessTTWorkFlow_Estados>();
            Session["myMultiMatriz_de_Estados"] = null;
            myMultiMatriz_de_EstadosArray = new List<objectBussinessTTWorkFlow_Matriz_de_Estados>();
            Session["myMultiRoles_por_Estado"] = null;
            myMultiRoles_por_EstadoArray = new List<objectBussinessTTWorkFlow_Roles_por_Estado>();
            Session["myMultiInformacion_por_Estado"] = null;
            myMultiInformacion_por_EstadoArray = new List<objectBussinessTTWorkFlow_Informacion_por_Estado>();
            Session["myMultiCondiciones_por_Estado"] = null;
            myMultiCondiciones_por_EstadoArray = new List<objectBussinessTTWorkFlow_Condiciones_por_Estado>();

        
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
            Response.Redirect("TTWorkFlow_Lista.aspx");
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
                return new JsonResult("TTWorkFlow_Lista.aspx?MenuVisible=false", true, null);
            else
                return new JsonResult("TTWorkFlow_Lista.aspx", true, null);
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
                return new JsonResult("TTWorkFlow_Catalogo.aspx?MenuVisible=false", true, null);
            else
                return new JsonResult("TTWorkFlow_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
    {

    }

    /*public void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
    }*/

    
    protected void grdMultiFases_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiFases.PageIndex = e.NewPageIndex;
        grdMultiFases.DataBind();
    }

    protected void cmbShowFases_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiFases.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiFases.DataBind();
    }

    protected void grdMultiFases_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiFases_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          








      }
    }
    
    protected void grdMultiEstados_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiEstados.PageIndex = e.NewPageIndex;
        grdMultiEstados.DataBind();
    }

    protected void cmbShowEstados_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiEstados.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiEstados.DataBind();
    }

    protected void grdMultiEstados_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiEstados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          









      }
    }
    
    protected void grdMultiMatriz_de_Estados_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiMatriz_de_Estados.PageIndex = e.NewPageIndex;
        grdMultiMatriz_de_Estados.DataBind();
    }

    protected void cmbShowMatriz_de_Estados_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiMatriz_de_Estados.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiMatriz_de_Estados.DataBind();
    }

    protected void grdMultiMatriz_de_Estados_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiMatriz_de_Estados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          












      }
    }
    
    protected void grdMultiRoles_por_Estado_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiRoles_por_Estado.PageIndex = e.NewPageIndex;
        grdMultiRoles_por_Estado.DataBind();
    }

    protected void cmbShowRoles_por_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiRoles_por_Estado.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiRoles_por_Estado.DataBind();
    }

    protected void grdMultiRoles_por_Estado_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiRoles_por_Estado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          













      }
    }
    
    protected void grdMultiInformacion_por_Estado_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiInformacion_por_Estado.PageIndex = e.NewPageIndex;
        grdMultiInformacion_por_Estado.DataBind();
    }

    protected void cmbShowInformacion_por_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiInformacion_por_Estado.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiInformacion_por_Estado.DataBind();
    }

    protected void grdMultiInformacion_por_Estado_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiInformacion_por_Estado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          










      }
    }
    
    protected void grdMultiCondiciones_por_Estado_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        grdMultiCondiciones_por_Estado.PageIndex = e.NewPageIndex;
        grdMultiCondiciones_por_Estado.DataBind();
    }

    protected void cmbShowCondiciones_por_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdMultiCondiciones_por_Estado.PageSize = MyFunctions.FormatNumberNull((sender as DropDownList).SelectedValue).Value;
        grdMultiCondiciones_por_Estado.DataBind();
    }

    protected void grdMultiCondiciones_por_Estado_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
    
    protected void grdMultiCondiciones_por_Estado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          











      }
    }
    

    
    protected void cmdFasesAdd_Click(object sender, EventArgs e)
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow_Fases myDataFases = new WSTTWorkFlow.objectBussinessTTWorkFlow_Fases();
        myDataFases.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiFasesArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15801);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiFasesArray.Add(myDataFases);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15801);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiFases.PageIndex = grdMultiFases.PageCount;
        grdMultiFases.DataSource = myMultiFasesArray;
        grdMultiFases.DataBind();
    }

    protected void cmdEstadosAdd_Click(object sender, EventArgs e)
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow_Estados myDataEstados = new WSTTWorkFlow.objectBussinessTTWorkFlow_Estados();
        myDataEstados.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiEstadosArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15809);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiEstadosArray.Add(myDataEstados);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15809);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiEstados.PageIndex = grdMultiEstados.PageCount;
        grdMultiEstados.DataSource = myMultiEstadosArray;
        grdMultiEstados.DataBind();
    }

    protected void cmdMatriz_de_EstadosAdd_Click(object sender, EventArgs e)
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados myDataMatriz_de_Estados = new WSTTWorkFlow.objectBussinessTTWorkFlow_Matriz_de_Estados();
        myDataMatriz_de_Estados.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiMatriz_de_EstadosArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15810);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiMatriz_de_EstadosArray.Add(myDataMatriz_de_Estados);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15810);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiMatriz_de_Estados.PageIndex = grdMultiMatriz_de_Estados.PageCount;
        grdMultiMatriz_de_Estados.DataSource = myMultiMatriz_de_EstadosArray;
        grdMultiMatriz_de_Estados.DataBind();
    }

    protected void cmdRoles_por_EstadoAdd_Click(object sender, EventArgs e)
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado myDataRoles_por_Estado = new WSTTWorkFlow.objectBussinessTTWorkFlow_Roles_por_Estado();
        myDataRoles_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiRoles_por_EstadoArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15812);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiRoles_por_EstadoArray.Add(myDataRoles_por_Estado);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15812);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiRoles_por_Estado.PageIndex = grdMultiRoles_por_Estado.PageCount;
        grdMultiRoles_por_Estado.DataSource = myMultiRoles_por_EstadoArray;
        grdMultiRoles_por_Estado.DataBind();
    }

    protected void cmdInformacion_por_EstadoAdd_Click(object sender, EventArgs e)
    {
        




        WSTTWorkFlow_Condiciones_por_Estado.objectBussinessTTWorkFlow_Condiciones_por_Estado wsc = new WSTTWorkFlow_Condiciones_por_Estado.objectBussinessTTWorkFlow_Condiciones_por_Estado();
        WSTTWorkFlow_Condiciones_por_Estado.CascadingDropDownNameValue[] estados = wsc.FillDataEstadowithParentCDD2("TTWorkFlow:" + txtFolio.Text + ";Fase:" + cddFaseMultiInformacion_por_Estado.SelectedValue + ";", "Fase", txtFolio.Text);
        
        WSTTWorkFlow_Informacion_por_Estado.objectBussinessTTWorkFlow_Informacion_por_Estado wsi = new WSTTWorkFlow_Informacion_por_Estado.objectBussinessTTWorkFlow_Informacion_por_Estado();
        WSTTWorkFlow_Informacion_por_Estado.CascadingDropDownNameValue[] Carpetas =  wsi.FillDataCarpetawithParentCDD("Proceso:" + cddProcesoMultiInformacion_por_Estado.SelectedValue + ";", "Proceso");

        var co = (from est in estados
                  from c in Carpetas orderby c.value
                  select new Add_TTWorkFlow_Informacion_Por_Estado()
                  {
                      nombreCarpeta=c.name,
                      nombreEstado = est.name,
                      valorCarpeta=c.value,
                      valorEstado=est.value
                  });

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15814);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        foreach (Add_TTWorkFlow_Informacion_Por_Estado ni in co.ToList<Add_TTWorkFlow_Informacion_Por_Estado>())
        {
            WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado myDataInformacion_por_Estado = new WSTTWorkFlow.objectBussinessTTWorkFlow_Informacion_por_Estado();
            myDataInformacion_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiInformacion_por_EstadoArray.Count + 1);
            myDataInformacion_por_Estado.Carpeta = int.Parse(ni.valorCarpeta);
            myDataInformacion_por_Estado.Estado = int.Parse(ni.valorEstado);
            myDataInformacion_por_Estado.Fase = int.Parse(cddFaseMultiInformacion_por_Estado.SelectedValue);
            myDataInformacion_por_Estado.Proceso = int.Parse(cddProcesoMultiInformacion_por_Estado.SelectedValue);
            myMultiInformacion_por_EstadoArray.Add(myDataInformacion_por_Estado);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15814);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiInformacion_por_Estado.PageIndex = grdMultiInformacion_por_Estado.PageCount;
        grdMultiInformacion_por_Estado.DataSource = myMultiInformacion_por_EstadoArray;
        grdMultiInformacion_por_Estado.DataBind();
    }

    protected void cmdCondiciones_por_EstadoAdd_Click(object sender, EventArgs e)
    {
        WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado myDataCondiciones_por_Estado = new WSTTWorkFlow.objectBussinessTTWorkFlow_Condiciones_por_Estado();
        myDataCondiciones_por_Estado.Folio = MyFunctions.FormatNumberNull(iProcess.ToString() + myMultiCondiciones_por_EstadoArray.Count + 1);

        //GridViewRow grvRow = (GridViewRow)(sender as ImageButton).Parent.Parent; 
        //@@BindControlsMultirenglon@@
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, 15815);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        myMultiCondiciones_por_EstadoArray.Add(myDataCondiciones_por_Estado);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, 15815);
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        grdMultiCondiciones_por_Estado.PageIndex = grdMultiCondiciones_por_Estado.PageCount;
        grdMultiCondiciones_por_Estado.DataSource = myMultiCondiciones_por_EstadoArray;
        grdMultiCondiciones_por_Estado.DataBind();
    }






}


public class Add_TTWorkFlow_Informacion_Por_Estado
{
    public string valorEstado { get; set; }
    public string nombreEstado { get; set; }
    public string valorCarpeta { get; set; }
    public string nombreCarpeta { get; set; }
}
}









