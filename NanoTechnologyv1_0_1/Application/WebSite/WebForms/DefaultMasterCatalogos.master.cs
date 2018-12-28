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
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Web.Services;
using App_Code.TTBusinessRules;

public partial class DefaultMasterCatalogos : System.Web.UI.MasterPage
{
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    public TTSecurity.Security MySecurity = new TTSecurity.Security();
    private TTSecurity.GlobalData globalInformation;
    protected TTTraductor.Traductor MyTraductor;

    public int Language
    {
        get
        {
            return
                Session["Language"] == null ? 1 :
                myFunctions.FormatNumberNull(Session["Language"].ToString()).Value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

            Session["MinutesToTimeOut"] = "55";


            Session["MinutesToTimeOut"] = "55";


        if (!Page.IsPostBack)
        {
            lblcase.InnerText = "TotalCase " + System.Configuration.ConfigurationSettings.AppSettings["VersionTotalCase"].ToString();
            lblversion.InnerText = "V" + System.Configuration.ConfigurationSettings.AppSettings["VersionSistema"].ToString();
        }
        if (Session["Relogin"] == null)
        {


        }
        MyTraductor = new TTTraductor.Traductor(Language);
        if (Session["UserGlobalInformation"] != null)
        {
            globalInformation = (TTSecurity.GlobalData)Session["UserGlobalInformation"];

            if (!IsPostBack)
                GeneraMenuRad();
        }
        if (Request["MenuVisible"] != null)
        {
            RadMenu1.Visible = false;

        }
        SetLanguage();

    }

    private void SetLanguage()
    {        
    }

    #region MenuRad
    protected void GeneraMenuRad()
    {
        TTSecurity.ModulesData[] modules;
        modules = MySecurity.ModulesPermited(globalInformation);

        if (modules.Length > 0)
        {
            bool IsAdmin = Session["globalTipoUsuario"].ToString() == "1";

            string module_current = "Sistema";
            RadMenuItem child = new RadMenuItem(module_current, null);
            child.CssClass = "RadMenu";
            RadMenu1.Items.Add(child);

            RadMenuItem itemSistema = child;
            string texto = "";
            string url = "";
            string id = "";


            //RadMenuItem root3;
            //root3 = child;
            string texto3 = "Cambiar Contraseña";
            string url3 = "~/FormsSystem/CambiarContrasena.aspx";
            RadMenuItem menuItem = new RadMenuItem(texto3, url3);
            //RadMenu1.Items.Add(childX3);
            menuItem.CssClass = "RadMenu";
            child.Items.Add(menuItem);

            RadMenuItem itemReportes;
            texto = "Configuración de Reportes";
            itemReportes = new RadMenuItem(texto, null);

            RadMenuItem itemWorkFlow;
            texto = "TTWorkFlow";
            itemWorkFlow = new RadMenuItem(texto, null);

            RadMenuItem itemUsuarios;
            texto = "TTUsuarios";
            itemUsuarios = new RadMenuItem(texto, null);

            RadMenuItem itemLenguaje;
            texto = "TTLanguage";
            itemLenguaje = new RadMenuItem(texto, null);

            RadMenuItem itemFormatos;
            texto = "Configuración de Formatos";
            itemFormatos = new RadMenuItem(texto, null);

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();

            for (int i = 0; i < modules.Length; i++)
            {
                texto = "";
                id = "";
                url = "";

                #region module_current
                if (modules[i].Module != module_current)
                {
                    module_current = modules[i].Module;
                    child = PushMenuItem(modules[i].Module);
                }
                #endregion

                texto = modules[i].Description;
                texto = MyTraductor.getTextProcess(modules[i].ProcessId, modules[i].Description);

                switch (modules[i].ProcessId)
                {
                    #region Sistema
                    case 6398:
                        //texto = "Permisos por Proceso";
                        url = "~/FormsSystem/TTPermisos/TTPermisos_por_proceso_Lista.aspx";
                        id = "";
                        break;
                    case 6397:
                        //texto = "Permisos Por Módulo"; // 6397
                        url = "~/FormsSystem/TTPermisos/TTPermisos_por_modulo_Lista.aspx";
                        id = "";
                        break;
                    case 6392:
                        //texto = "Procesos del Módulo"; // 6392
                        url = "~/FormsSystem/TTPermisos/TTProceso_del_modulo_Lista.aspx";
                        //texto = ""; // 6392
                        //url = "";
                        id = "";
                        break;
                    case 6773:
                        //texto = "Reglas de Negocio"; // 6773
                        url = "~/FormsSystem/TTBusinessRules/TTBusinessRules_Lista.aspx";
                        id = "";
                        break;
                    case 6400:
                        //texto = "Bitacora LogIn LogOff"; // 6400
                        url = "~/FormsSystem/TTPermisos/TTBitacoraLogIn_LogOff_Lista.aspx";
                        id = "";
                        break;
                    #endregion

                    #region Reportes
                    case 6799:
                        //texto = "Reportes"; // 6799
                        url = "~/FormsSystem/TTReportes/TTReportes_Lista.aspx";
                        id = "";
                        break;
                    case 999:
                        //texto = "Grupo de Reportes"; // 999*
                        url = "~/FormsSystem/TTReportes/TTGrupo_Reporte_Lista.aspx";
                        id = "";
                        break;
                    case 998:
                        //texto = "Asignación de Permisos"; // 998*
                        url = "~/FormsSystem/TTReportes/TTReporte_Asignacion_de_Permisos.aspx";
                        id = "";
                        break;
                    case 995:
                        //texto = "TTConsultaSQL"; // 999*
                        url = "~/FormsSystem/TTConsultaSQL.aspx";
                        id = "";
                        break;
                    #endregion

                    #region TTWorkFlow
                    case 15799:
                        //texto = "WorkFlow"; // 15799
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Lista.aspx";
                        id = "";
                        break;

                    case 15805:
                        //texto = "Estatus de Fase"; // 15805
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Estatus_de_Fase_Lista.aspx";
                        id = "";
                        break;

                    case 15800:
                        //texto = "Estatus de WorkFlow"; // 15800
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Estatus_de_WorkFlow_Lista.aspx";
                        id = "";
                        break;

                    case 15808:
                        //texto = "Frecuencia de Meta"; // 15808
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Frecuencia_Lista.aspx";
                        id = "";
                        break;

                    case 15804:
                        //texto = "Tipo de Control de Flujo"; // 15804
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_Control_Flujo_Lista.aspx";
                        id = "";
                        break;

                    case 15803:
                        //texto = "Tipo de Distribución de Trabajo"; // 15803
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_Distribucion_Trabajo_Lista.aspx";
                        id = "";
                        break;

                    case 15802:
                        //texto = "Tipo de Fase"; // 15802
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_de_Fase_Lista.aspx";
                        id = "";
                        break;

                    case 15813:
                        //texto = "Transición de Fase"; // 15813
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Transicion_de_Fase_Lista.aspx";
                        id = "";
                        break;

                    case 15811:
                        //texto = "TTWorkFlow Respuesta"; // 15811
                        url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Respuesta_Lista.aspx";
                        id = "";
                        break;
                    #endregion

                    #region TTUsuarios
                    case 6395:
                        //texto = "TTUsuarios"; // 6395
                        url = "~/FormsSystem/TTUsuarios/TTUsuarios_Lista.aspx";
                        id = "";
                        break;

                    case 997:
                        //texto = "TTGrupo de Usuario"; // 997
                        url = "~/FormsSystem/TTUsuarios/TTGrupo_de_Usuario_Lista.aspx";
                        id = "";
                        break;

                    case 6396:
                        //texto = "TTUsuarios Por Grupo"; // 6396
                        url = "~/FormsSystem/TTUsuarios/TTUsuarios_Por_Grupo_Lista.aspx";
                        id = "";
                        break;
                    #endregion

                    #region TTLanguage
                    case 6834:
                        //texto = "TTLanguage"; // 6834
                        url = "~/FormsSystem/TTPermisos/TTLanguage_Lista.aspx";
                        id = "";
                        break;

                    case 6833:
                        //texto = "TTLanguageTraduction"; // 6833
                        url = "~/FormsSystem/TTPermisos/TTLanguageTraduction_Lista.aspx";
                        id = "";
                        break;
                    #endregion

                    #region TTFormatos
                    case 17499:
                        //texto = "Formatos"; // 17499
                        url = "~/FormsSystem/TTFormatos/TTFormatos_Lista.aspx";
                        id = "";
                        break;

                    case 996:
                        //texto = "Permisos de Formato"; // 6833
                        url = "~/FormsSystem/TTFormatos/TTFormato_Asignacion_de_Permisos.aspx";
                        id = "";
                        break;
                    #endregion

                    default:
                        texto = MyTraductor.getTextProcess(modules[i].ProcessId, modules[i].Description);
                        id = modules[i].ProcessId.ToString();
                        url = "~/WebForms/Limpia.aspx?Pagina=" + myFunctions.GenerateName(modules[i].Name) + "_Lista.aspx";
                        break;
                }
                //menuItem = new RadMenuItem(texto, url);
                //child.Items.Add(menuItem);

                //RadMenuItem root;
                //root = child;
                //texto = texto.Trim();
                url = url.Trim();

                if (texto.Length > 0 && url.Length > 0 && !MenuItemExists(texto, child))
                {
                    menuItem = new RadMenuItem(texto, url);
                    menuItem.CssClass = "RadMenu";
                    child.Items.Add(menuItem);

                    #region SubMenu

                    int Rol_de_Usuario = Int32.Parse(Session["globaltipousuario"].ToString());
                    string Process_TableName1, Process_CampoLlave;
                    string Process_TableName = Funcion.ValidaWorkFlow_GetTableName(modules[i].ProcessId, Rol_de_Usuario, out Process_TableName1, out Process_CampoLlave);

                    SqlCommand com = new SqlCommand("sp_SelMenu_Creacion");
                    com.Parameters.Add("@Proceso", SqlDbType.Int).Value = modules[i].ProcessId;
                    com.Parameters.Add("@UserId", SqlDbType.Int).Value = Rol_de_Usuario;
                    com.CommandType = CommandType.StoredProcedure;
                    DataSet ds = db.Consulta(com);
                    db.Disconnect();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (menuItem.NavigateUrl != "")
                            menuItem.NavigateUrl = string.Empty;


                        int conteo_fases_total = 0;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            int TipoFase = Convert.ToInt32(ds.Tables[0].Rows[j]["Tipo_de_Fase"].ToString());
                            int Fase = Convert.ToInt32(ds.Tables[0].Rows[j].ItemArray[1].ToString());
                            string Where = Funcion.ValidaWorkFlow_GetWhere(modules[i].ProcessId, Fase, Rol_de_Usuario);

                            SqlCommand comBr = new SqlCommand("spGetBusinessRuleFilterList");
                            comBr.Parameters.Add("@IdProceso", modules[i].ProcessId);
                            comBr.CommandType = CommandType.StoredProcedure;

                            DataTable br = db.Consulta(comBr).Tables[0];

                            if (br.Rows.Count > 0)
                            {
                                HttpContext.Current.Session["hasFilterList"] = "RadMenu";

                                TTSecurity.GlobalData myUserData = Session["UserGlobalInformation"] as TTSecurity.GlobalData;

                                BusinessOperations myBusinessRule = new BusinessOperations((TTBasePage.TTBasePage)(this.Page), myUserData, modules[i].ProcessId);
                                int idBusinessRule = br.Rows[0]["idBusinessRule"] == DBNull.Value ? 0 : (int)br.Rows[0]["idBusinessRule"];
                                bool brExecuted = myBusinessRule.ComparationIndividual(myUserData, idBusinessRule);

                                if (brExecuted)
                                {
                                    if (HttpContext.Current.Session["WhereFromBRRadMenu"] != null)
                                    {
                                        string WhereFromBR = HttpContext.Current.Session["WhereFromBRRadMenu"].ToString();

                                        Where += (WhereFromBR != "" ? (Where == "" ? " WHERE " : " AND (") + WhereFromBR + (Where == "" ? "" : ")") : "");
                                    }
                                }
								
								HttpContext.Current.Session["WhereFromBRRadMenu"] = null;
                                HttpContext.Current.Session["hasFilterList"] = null;
                            }
                            //TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                            SqlCommand com2 = new SqlCommand("SELECT COUNT(" + Process_CampoLlave + ") as Conteo     FROM " + Process_TableName + "    " + Where);
                            //com.CommandType = CommandType.TableDirect;
                            DataSet dsConteo = db.Consulta(com2);
                            string tmp_conteo = "";
                            if (dsConteo.Tables[0].Rows.Count > 0)
                            {
                                int cont = 0;
                                try { cont = Convert.ToInt32(dsConteo.Tables[0].Rows[0].ItemArray[0].ToString()); }
                                catch { }
                                tmp_conteo = " (" + cont + ")";
                                conteo_fases_total += cont;
                            }

                            RadMenuItem childF = new RadMenuItem(
                                ds.Tables[0].Rows[j].ItemArray[0].ToString() + (TipoFase == 1 ? "" : tmp_conteo),
                                url.Replace("Limpia.aspx", "LimpiaWF.aspx") + "&Fase=" + Fase.ToString() + (TipoFase == 1 ? "&pf=1" : ""));
                            childF.CssClass = "RadMenu";
                            menuItem.Items.Add(childF);
                        }

                        //if (conteo_fases_total > 0)
                        //    menuItem.Text += " (" + conteo_fases_total.ToString() + ")";

                        //int height = 0;
                        //root.GroupSettings.Height = (Unit)height;
                        //root.GroupSettings.Flow = ItemFlow.Vertical;
                        //root.GroupSettings.ExpandDirection = ExpandDirection.Auto; 
                    }
                    #endregion
                }
            }

            //-----------------------------------------------------------------
            #region Reportes, Estadísticas
            DataSet dataset = Funcion.GetReportListByUserGroup(Session["globalUsuarioClave"].ToString());
            RadMenuItem rootReporte, rootEstadistics, subMenu, itemMenu;
            DataRow[] drs;

            module_current = "Reportes";
            rootReporte = new RadMenuItem(module_current, null);
            rootReporte.CssClass = "RadMenu";
            //RadMenu1.Items.Add(rootReporte);

            module_current = "Estadísticas";
            rootEstadistics = new RadMenuItem(module_current, null);
            rootEstadistics.CssClass = "RadMenu";
            //RadMenu1.Items.Add(rootEstadistics);
            int numReportes = 0;
            int numEstadistics = 0;

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                subMenu = new RadMenuItem(dr["Nombre"].ToString(), null);
                subMenu.CssClass = "RadMenu";
                rootReporte.Items.Add(subMenu);
                drs = dataset.Tables[1].Select("IdGrupoReporte = " + dr["IdGrupoReporte"] + " and TipoPresentacion = 1");
                if (drs != null)
                    foreach (DataRow dtr in drs)
                    {
                        itemMenu = new RadMenuItem(dtr["Nombre"].ToString(), dtr["URL"].ToString());
                        itemMenu.CssClass = "RadMenu";
                        subMenu.Items.Add(itemMenu);
                        numReportes++;
                    }

                subMenu = new RadMenuItem(dr["Nombre"].ToString(), null);
                subMenu.CssClass = "RadMenu";
                rootEstadistics.Items.Add(subMenu);
                drs = dataset.Tables[1].Select("IdGrupoReporte = " + dr["IdGrupoReporte"] + " and TipoPresentacion = 2");
                if (drs != null)
                    foreach (DataRow dtr in drs)
                    {
                        itemMenu = new RadMenuItem(dtr["Nombre"].ToString(), dtr["URL"].ToString());
                        itemMenu.CssClass = "RadMenu";
                        subMenu.Items.Add(itemMenu);
                        numEstadistics++;
                    }
            }
            if (numReportes > 0)
                RadMenu1.Items.Add(rootReporte);

            if (numEstadistics > 0)
                RadMenu1.Items.Add(rootEstadistics);
            #endregion

            if (IsAdmin)
            {
                if (RadMenu1.Items.Contains(itemFormatos)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemFormatos);
                if (!RadMenu1.Items.Contains(itemFormatos) && itemFormatos.Items.Count > 0)
                    RadMenu1.Items.Add(itemFormatos);

                if (RadMenu1.Items.Contains(itemReportes)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemReportes);
                if (!RadMenu1.Items.Contains(itemReportes) && itemReportes.Items.Count > 0)
                    RadMenu1.Items.Add(itemReportes);

                if (RadMenu1.Items.Contains(itemReportes)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemReportes);
                if (!RadMenu1.Items.Contains(itemReportes) && itemReportes.Items.Count > 0)
                    RadMenu1.Items.Add(itemReportes);

                if (RadMenu1.Items.Contains(itemWorkFlow)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemWorkFlow);
                if (!RadMenu1.Items.Contains(itemWorkFlow) && itemWorkFlow.Items.Count > 0)
                    RadMenu1.Items.Add(itemWorkFlow);

                if (RadMenu1.Items.Contains(itemUsuarios)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemUsuarios);
                if (!RadMenu1.Items.Contains(itemUsuarios) && itemUsuarios.Items.Count > 0)
                    RadMenu1.Items.Add(itemUsuarios);

                if (RadMenu1.Items.Contains(itemLenguaje)) // Borrar mezclas anteriores para re-ordenar
                    RadMenu1.Items.Remove(itemLenguaje);
                if (!RadMenu1.Items.Contains(itemLenguaje) && itemLenguaje.Items.Count > 0)
                    RadMenu1.Items.Add(itemLenguaje);

                //----------- Reportes (Configuración de Reportes) -----------
                #region Reportes OLD
                //texto = "Reportes"; // 6799
                //url = "~/FormsSystem/TTReportes/TTReportes_Lista.aspx";
                //RadMenuItem itemReports = new RadMenuItem(texto, url);
                //itemReportes.Items.Add(itemReports);

                //texto = "Grupo de Reportes"; // 999*
                //url = "~/FormsSystem/TTReportes/TTGrupo_Reporte_Lista.aspx";
                //RadMenuItem itemGrupoR = new RadMenuItem(texto, url);
                //itemReportes.Items.Add(itemGrupoR);

                //texto = "Asignación de Permisos"; // 998*
                //url = "~/FormsSystem/TTReportes/TTReporte_Asignacion_de_Permisos.aspx";
                //RadMenuItem itemPermisosReports = new RadMenuItem(texto, url);
                //itemReportes.Items.Add(itemPermisosReports); 
                #endregion

                #region TTWorkFlow
                //----------- TTWorkFlow -----------
                //texto = "Estatus de Fase"; // 15805
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Estatus_de_Fase_Lista.aspx";
                //RadMenuItem itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Estatus de WorkFlow"; // 15800
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Estatus_de_WorkFlow_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Frecuencia de Meta"; // 15808
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Frecuencia_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Tipo de Control de Flujo"; // 15804
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_Control_Flujo_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Tipo de Distribución de Trabajo"; // 15803
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_Distribucion_Trabajo_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Tipo de Fase"; // 15802
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_de_Fase_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Tipo de Meta"; // 15807
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Tipo_de_Meta_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "Transición de Fase"; // 15813
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Transicion_de_Fase_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "TTWorkFlow Respuesta"; // 15811
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Respuesta_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF);

                //texto = "WorkFlow"; // 15799
                //url = "~/FormsSystem/TTWorkFlow/TTWorkFlow_Lista.aspx";
                //itemWF = new RadMenuItem(texto, url);
                //itemWorkFlow.Items.Add(itemWF); 
                #endregion

                #region TTUsuarios
                //----------- Usuarios -----------
                //texto = "TTUsuarios"; // 6395
                //url = "~/FormsSystem/TTUsuarios/TTUsuarios_Lista.aspx";
                //RadMenuItem itemUser = new RadMenuItem(texto, url);
                //itemUsuarios.Items.Add(itemUser);

                //texto = "TTGrupo de Usuario"; // 6395
                //url = "~/FormsSystem/TTUsuarios/TTGrupo_de_Usuario_Lista.aspx";
                //itemUser = new RadMenuItem(texto, url);
                //itemUsuarios.Items.Add(itemUser);

                //texto = "TTUsuarios Por Grupo"; // 6396
                //url = "~/FormsSystem/TTUsuarios/TTUsuarios_Por_Grupo_Lista.aspx";
                //itemUser = new RadMenuItem(texto, url);
                //itemUsuarios.Items.Add(itemUser); 
                #endregion

                #region TTLanguage
                //----------- Lenguaje -----------
                //texto = "TTLanguage"; // 6834
                //url = "~/FormsSystem/TTPermisos/TTLanguage_Lista.aspx";
                //RadMenuItem itemLen = new RadMenuItem(texto, url);
                //itemLenguaje.Items.Add(itemLen);

                //texto = "TTLanguageTraduction"; // 6833
                //url = "~/FormsSystem/TTPermisos/TTLanguageTraduction_Lista.aspx";
                //itemLen = new RadMenuItem(texto, url);
                //itemLenguaje.Items.Add(itemLen); 
                #endregion
            }

            //---------------------------------------------------

            //RadMenuItem root2;
            //root2 = child;
            string texto2 = "Salir";
            //string url2 = "~/FormsSystem/Login.aspx";
            string url2 = "~/Default.aspx";
            menuItem = new RadMenuItem(texto2, url2);
            menuItem.CssClass = "RadMenu";
            child = itemSistema;
            module_current = "Sistema";
            child.Items.Add(menuItem);
            child.Dispose();
            itemSistema.Dispose();
            menuItem.Dispose();
            itemReportes.Dispose();
            itemWorkFlow.Dispose();
            itemUsuarios.Dispose();
            itemLenguaje.Dispose();
            itemFormatos.Dispose();
            db.Dispose();

        }
        GC.Collect();
    }

    #region MenuItemExists(string texto, RadMenuItem child)
    private bool MenuItemExists(string texto, RadMenuItem child)
    {
        bool exists = false;
        for (int i = 0; i < child.Items.Count; i++)
        {
            if (child.Items[i].Text == texto)
            {
                exists = true;
                break;
            }
        }
        return exists;
    }
    #endregion

    #region PushMenuItem(string module_current)
    private RadMenuItem PushMenuItem(string module_current)
    {
        bool exists = false;
        RadMenuItem select = null;
        for (int i = 0; i < RadMenu1.Items.Count; i++)
        {
            if (RadMenu1.Items[i].Text == module_current)
            {
                select = RadMenu1.Items[i];
                exists = true;
                break;
            }
        }
        if (!exists)
        {
            RadMenuItem menuItem = new RadMenuItem(module_current, null);
            menuItem.CssClass = "RadMenu";
            RadMenu1.Items.Add(menuItem);
            return menuItem;
        }
        else
            return select;
    }
    #endregion

    private object Content(string p)
    {
        throw new NotImplementedException();
    }
    # endregion
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/FormsSystem/Login.aspx");
    }

    public void OnTimerEvent(object source, EventArgs e)
    {
        if (1==2)
        {
            if (int.Parse(Session["MinutesToTimeOut"].ToString()) <= 3)
            {
                if (Session["Relogin"] == null || (bool)Session["Relogin"] == false)
                {
                    if (Session["Reconnect"] == null || (bool)Session["Reconnect"] == false)
                    {
                        Session["Reconnect"] = true;

                    }
                }
                else
                {
                    Session["Reconnect"] = false;
                    Session["Reconnect"] = true;
                }


            }
            else
            {
                if (Session["MinutesToTimeOut"].ToString() != "")
                    Session["MinutesToTimeOut"] = int.Parse(Session["MinutesToTimeOut"].ToString()) - 1;
            }
        }
        else
        {
            Session["Reconnect"] = false;
            Session["Reconnect"] = true;
        }

    }
}


















