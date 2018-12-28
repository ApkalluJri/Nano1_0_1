﻿/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD      h:m             
Descripción:      Pantalla Lista Registro_de_Contenido
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
using System.IO;
using Telerik.Web.UI;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using TTBasePage;
using App_Code.TTBusinessRules;
using System.Linq;
namespace WebForms
{
public partial class Registro_de_Contenido_Lista : TTBasePage.TTBasePage
{
    public string sortExpression_;
    public string sortDirection_;
    const String sDNTNombre = "Registro_de_Contenido";
    const String sDNTDescripcion = "Registro de Contenido";
    const Int32 idProceso = 29982;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
            

	if (Request["pf"] != null && Request["Fase"] != null)
            if(Request["pf"].ToString() == "1")
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("Select * from ttpermisos_por_proceso where idproceso=29982 and idoperacion=7");
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count>0)
                {
                    WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();
                    WSRegistro_de_Contenido.GlobalData userData = new WSRegistro_de_Contenido.GlobalData();
                    TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
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
                    Session["Folio"] = Funcion.RegresaDato("insert into Registro_de_Contenido(Usuario_que_Registra) values(null); select @@identity");
                    Session["Tipo_Transaccion"] = "Update";
                }
                else
                {
                    Session["Folio"] = "";
                    Session["Tipo_Transaccion"] = "New";
                }
                Response.Redirect("Registro_de_Contenido_Catalogo.aspx?pf=1&Fase=" + Request["Fase"].ToString());
            }        

        if (!Page.IsPostBack)
        {
            Session["WhereFromBR"] = null;
            Session["OrderFromBR"] = null; 
            FillGetData(Request["Fase"]);
            SetLanguage();
        }
        Funcion.SetSeguridadPorProcesos(Session["globalUsuarioClave"].ToString(), idProceso.ToString(), Page, grdRadMov);

        ttWorkFlowAsignaPermisos();


        if (Request["MenuVisible"] == null)
            Page.ClientScript.RegisterStartupScript(typeof(Page), "CloseWindow", "<script language='javascript'>CloseWindow()</script>");
        LoadFilterControl();
                 
        SetSelectColumnVisible();
        Session["Fase"] = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";
        hfFase.Value = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";
        ApplyBusinessRules(TTenumBusinessRules_Operacion.List, TTenumBusinessRules_ProcessEvent.OpenWindows, idProceso);
    }

    protected override void OnUnload(EventArgs e)
    {
        GC.Collect();
    }    
    private void SetSelectColumnVisible() 
    {
        if (Request["MenuVisible"] != null)
        {
            grdRadMov.Columns[0].HeaderStyle.CssClass = "Hide";
            grdRadMov.Columns[0].ItemStyle.CssClass = "Hide";
            grdRadMov.Columns[0].Visible = false;

            grdRadMov.Columns[1].HeaderStyle.CssClass = "Hide";
            grdRadMov.Columns[1].ItemStyle.CssClass = "Hide";
            grdRadMov.Columns[1].Visible = false;

            grdRadMov.Columns[3].HeaderStyle.CssClass = "Hide";
            grdRadMov.Columns[3].ItemStyle.CssClass = "Hide";
            grdRadMov.Columns[3].Visible = false;

            grdRadMov.Columns[4].HeaderStyle.CssClass = "Hide";
            grdRadMov.Columns[4].ItemStyle.CssClass = "Hide";
            grdRadMov.Columns[4].Visible = false;

            grdRadMov.Columns[5].HeaderStyle.CssClass = "Hide";
            grdRadMov.Columns[5].ItemStyle.CssClass = "Hide";
            grdRadMov.Columns[5].Visible = false;
        }
    }
    
    private void SetLanguage() 
    {
        try
        {
            string sTitle = string.Format(MyTraductor.getMessage(4, this.Title), MyTraductor.getTextProcess(idProceso, sDNTDescripcion));
            this.Title = sTitle;
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = sTitle;

            //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX INICIO SETLANGUAGE() LINEA 103 JZAMORA
            #region Session_TTWorkFlows_Fase
            string strFase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";
            
            int Fase = 0;
            try { Fase = Convert.ToInt32(strFase); }
            catch { }

            if (Fase > 0)
            {
                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                    SqlCommand com = new SqlCommand("spGetFaseNombreWorkFlow_TTProceso");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(Session["globalTipoUsuario"].ToString());
                    com.Parameters.Add("@Proceso", SqlDbType.Int).Value = idProceso;
                    com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
                    DataSet ds = db.Consulta(com);
                    if (ds.Tables[0].Rows.Count > 0)
                        lblTitulo.Text += " - " + ds.Tables[0].Rows[0]["Fase_Nombre"].ToString();
            }
            #endregion
            //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX END SetLanguage() LINEA 127 JZAMORA

            grdRadMov.PagerStyle.PagerTextFormat =
                "{4} <div id='row_info' ><div id='row_info_label_div' class='topgrid_info'> "
                + MyTraductor.getMessage(49, "Registros:<b>{0}</b> / Del <b>{1}</b> al <b>{2}</b>").Replace("{0}", "{5}").Replace("{2}", "{3}").Replace("{1}", "{2}")
                + "</div></div>";

            lblNuevo.Text = MyTraductor.getMessage(8, lblNuevo.Text);
            lblTodos.Text = MyTraductor.getMessage(9, lblTodos.Text);
            lblBuscar.Text = MyTraductor.getMessage(10, lblBuscar.Text);
            lblExportar.Text = MyTraductor.getMessage(11, lblExportar.Text);
            lblImprimir.Text = MyTraductor.getMessage(12, lblImprimir.Text);
            lblConfigurar.Text = MyTraductor.getMessage(14, lblConfigurar.Text);
            
        }
        catch 
        { }

    }
    
    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------

        WSRegistro_de_Contenido.GlobalData userData;
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
        base.OnInit(e);
    }
    
    // Llenar el Grid
    private void FillGetData(string fase)
    {
        CreateColumns(); this.cmdViews.Visible = false; this.cmdHelp.Visible = false;
       if (HttpContext.Current.Session["GridState"] != null)
        {
            GridState oGridSate = (GridState)HttpContext.Current.Session["GridState"];
            if (oGridSate.idProceso == idProceso && oGridSate.fase == fase)
            {
                if(oGridSate.maximumRows > 0)
                    grdRadMov.PageSize = oGridSate.maximumRows;
                else
                    grdRadMov.PageSize =10;

                hfCurrentPage.Value = oGridSate.CurrentPage.ToString();
                System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                hfFilters.Value = oSerializer.Serialize(oGridSate.filterExpression).Replace("[{","[{\"__type\":\"Telerik.Web.UI.GridFilterExpression\",");
                hfsort.Value = oSerializer.Serialize(oGridSate.sortExpression).Replace("[{","[{\"__type\":\"Telerik.Web.UI.GridSortExpression\",");
                foreach (GridFilterExpression filter in oGridSate.filterExpression)
                {
                    GridColumn column = grdRadMov.MasterTableView.GetColumn(filter.ColumnUniqueName);
                    column.CurrentFilterFunction = (GridKnownFunction)Enum.Parse(typeof(GridKnownFunction), filter.FilterFunction);
                    column.CurrentFilterValue = filter.FieldValue;
                }
            }
            else
            {
                HttpContext.Current.Session.Remove("GridState");
            }
        }
        else
            grdRadMov.PageSize = 10;
    }

    protected Int32 ObtenPageSize()
    {
        Int32 Size = 15;
        if (Session[idProceso.ToString() + "_Registros"] != null)
        {
            switch (Int32.Parse(Session[idProceso.ToString() + "_Registros"].ToString()))
            {
                case 0: { Size = 10; break; }
                case 1: { Size = 15; break; }
                case 2: { Size = 25; break; }
                case 3: { Size = 35; break; }
                case 4: { Size = 50; break; }
                case 5: { Size = 100; break; }
                case 6: { Size = 500; break; }
            }
        }
        return Size;
    }

    //Paginacion
    protected void Pagination(int indice)
    {        
    }

    //Ordenamiento
   
    private void CreateColumns()
    { 
        grdRadMov.AllowPaging = true;
        grdRadMov.AllowSorting = true;  
        GridClientSelectColumn im01 = new GridClientSelectColumn();
        im01.Visible = false;

        GridButtonColumn im02 = new GridButtonColumn();
        im02.ButtonType = GridButtonColumnType.ImageButton;
        im02.ImageUrl = "~/images/delete.png";
        im02.CommandName = "Delete"; im02.Text = "Borrar";     
        
        GridButtonColumn im03 = new GridButtonColumn();
        im03.ButtonType = GridButtonColumnType.ImageButton;
        im03.ImageUrl = "~/images/select.png";
        im03.CommandName = "Select";

        if (Request["MenuVisible"] == null)
        {
            im03.Visible = false;
        }

        grdRadMov.MasterTableView.Columns.Add(im01);
        grdRadMov.MasterTableView.Columns.Add(im02);
        grdRadMov.MasterTableView.Columns.Add(im03);
        GridButtonColumn im1 = new GridButtonColumn();
        im1.ButtonType = GridButtonColumnType.ImageButton;
        im1.ImageUrl = "~/images/look.png"; im1.Text = "Consultar";
        im1.CommandName = "Consult";

        GridButtonColumn im2 = new GridButtonColumn();
        im2.ButtonType = GridButtonColumnType.ImageButton;
        im2.ImageUrl = "~/images/edit.png"; im2.Text = "Modificar";
        im2.CommandName = "Edit";

        GridButtonColumn im4 = new GridButtonColumn();
        im4.ButtonType = GridButtonColumnType.ImageButton;
        im4.ImageUrl = "~/images/print.png"; im4.Text = "Imprimir";
        im4.CommandName = "Print";

        grdRadMov.MasterTableView.Columns.Add(im1);
        grdRadMov.MasterTableView.Columns.Add(im2);
        grdRadMov.MasterTableView.Columns.Add(im4);

                GridBoundColumn colFolio = new GridBoundColumn();
        colFolio.HeaderText = MyTraductor.getTextDTID(141045, "Folio");
        colFolio.HtmlEncode = false;
        colFolio.DataField = "Registro_de_Contenido_Folio";
        colFolio.SortExpression = "Registro_de_Contenido.Folio";
        colFolio.UniqueName = "Registro_de_Contenido.Folio";
        colFolio.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        colFolio.DataType = typeof(int);
        grdRadMov.MasterTableView.Columns.Add(colFolio);
        GridBoundColumn colUsuario_que_Registra = new GridBoundColumn();
        colUsuario_que_Registra.HeaderText = MyTraductor.getTextDTID(141046, "Usuario que Registra");
        colUsuario_que_Registra.DataField = "Registro_de_Contenido_Usuario_que_Registra";
        colUsuario_que_Registra.DataFormatString = "";
        colUsuario_que_Registra.SortExpression = "Registro_de_Contenido.Usuario_que_Registra";
        colUsuario_que_Registra.UniqueName = "Registro_de_Contenido.Usuario_que_Registra";
        colUsuario_que_Registra.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colUsuario_que_Registra.DataType = typeof(string);
        grdRadMov.Columns.Add(colUsuario_que_Registra);
        //grdMov.Columns[6+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[6+1].ItemStyle.CssClass = "Hide";
        colUsuario_que_Registra.HeaderStyle.CssClass = "Hide";
        colUsuario_que_Registra.ItemStyle.CssClass = "Hide";
        colUsuario_que_Registra.Visible = false;
        GridBoundColumn colUsuario_que_Registra_Desc = new GridBoundColumn();
        colUsuario_que_Registra_Desc.DataField = "Usuario_que_Registra_Nombre";
        colUsuario_que_Registra_Desc.HeaderText = MyTraductor.getTextDTID(141046, "Usuario que Registra");
        colUsuario_que_Registra_Desc.SortExpression = "Usuario_que_Registra.Nombre";
        colUsuario_que_Registra_Desc.UniqueName = "Usuario_que_Registra.Nombre";
        colUsuario_que_Registra_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colUsuario_que_Registra_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colUsuario_que_Registra_Desc);
        GridBoundColumn colFecha_de_Registro = new GridBoundColumn();
        colFecha_de_Registro.DataField = "Registro_de_Contenido_Fecha_de_Registro";
        colFecha_de_Registro.HeaderText = MyTraductor.getTextDTID(141047, "Fecha de Registro");
        colFecha_de_Registro.SortExpression = "Registro_de_Contenido.Fecha_de_Registro";
        colFecha_de_Registro.UniqueName = "Registro_de_Contenido.Fecha_de_Registro";
        colFecha_de_Registro.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Registro.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Registro.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Registro);
        GridBoundColumn colHora_de_Registro = new GridBoundColumn();
        colHora_de_Registro.HeaderText = MyTraductor.getTextDTID(141048, "Hora de Registro");
        colHora_de_Registro.DataField = "Registro_de_Contenido_Hora_de_Registro";
        colHora_de_Registro.DataFormatString = "";
        colHora_de_Registro.SortExpression = "Registro_de_Contenido.Hora_de_Registro";
        colHora_de_Registro.UniqueName = "Registro_de_Contenido.Hora_de_Registro";
        colHora_de_Registro.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colHora_de_Registro.DataType = typeof(string);
        grdRadMov.Columns.Add(colHora_de_Registro);
        GridBoundColumn colObservatorio = new GridBoundColumn();
        colObservatorio.HeaderText = MyTraductor.getTextDTID(143376, "Observatorio");
        colObservatorio.HtmlEncode = false;
        colObservatorio.DataField = "Registro_de_Contenido_Observatorio";
        colObservatorio.SortExpression = "Registro_de_Contenido.Observatorio";
        colObservatorio.UniqueName = "Registro_de_Contenido.Observatorio";
        colObservatorio.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        colObservatorio.DataType = typeof(int);
        grdRadMov.MasterTableView.Columns.Add(colObservatorio);
        GridBoundColumn colCategoria = new GridBoundColumn();
        colCategoria.HeaderText = MyTraductor.getTextDTID(141052, "Categoría");
        colCategoria.DataField = "Registro_de_Contenido_Categoria";
        colCategoria.DataFormatString = "";
        colCategoria.SortExpression = "Registro_de_Contenido.Categoria";
        colCategoria.UniqueName = "Registro_de_Contenido.Categoria";
        colCategoria.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colCategoria.DataType = typeof(string);
        grdRadMov.Columns.Add(colCategoria);
        //grdMov.Columns[11+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[11+1].ItemStyle.CssClass = "Hide";
        colCategoria.HeaderStyle.CssClass = "Hide";
        colCategoria.ItemStyle.CssClass = "Hide";
        colCategoria.Visible = false;
        GridBoundColumn colCategoria_Desc = new GridBoundColumn();
        colCategoria_Desc.DataField = "Categoria_Descripcion";
        colCategoria_Desc.HeaderText = MyTraductor.getTextDTID(141052, "Categoría");
        colCategoria_Desc.SortExpression = "Categoria.Descripcion";
        colCategoria_Desc.UniqueName = "Categoria.Descripcion";
        colCategoria_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colCategoria_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colCategoria_Desc);
        GridBoundColumn colDescripcion_de_Solicitud = new GridBoundColumn();
        colDescripcion_de_Solicitud.HeaderText = MyTraductor.getTextDTID(143396, "Descripción de Solicitud");
        colDescripcion_de_Solicitud.DataField = "Registro_de_Contenido_Descripcion_de_Solicitud";
        colDescripcion_de_Solicitud.DataFormatString = "";
        colDescripcion_de_Solicitud.SortExpression = "Registro_de_Contenido.Descripcion_de_Solicitud";
        colDescripcion_de_Solicitud.UniqueName = "Registro_de_Contenido.Descripcion_de_Solicitud";
        colDescripcion_de_Solicitud.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colDescripcion_de_Solicitud.DataType = typeof(string);
        grdRadMov.Columns.Add(colDescripcion_de_Solicitud);
        GridBoundColumn colReportero_Asignado = new GridBoundColumn();
        colReportero_Asignado.HeaderText = MyTraductor.getTextDTID(143392, "Reportero Asignado");
        colReportero_Asignado.DataField = "Registro_de_Contenido_Reportero_Asignado";
        colReportero_Asignado.DataFormatString = "";
        colReportero_Asignado.SortExpression = "Registro_de_Contenido.Reportero_Asignado";
        colReportero_Asignado.UniqueName = "Registro_de_Contenido.Reportero_Asignado";
        colReportero_Asignado.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colReportero_Asignado.DataType = typeof(string);
        grdRadMov.Columns.Add(colReportero_Asignado);
        //grdMov.Columns[14+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[14+1].ItemStyle.CssClass = "Hide";
        colReportero_Asignado.HeaderStyle.CssClass = "Hide";
        colReportero_Asignado.ItemStyle.CssClass = "Hide";
        colReportero_Asignado.Visible = false;
        GridBoundColumn colReportero_Asignado_Desc = new GridBoundColumn();
        colReportero_Asignado_Desc.DataField = "Reportero_Asignado_Nombre";
        colReportero_Asignado_Desc.HeaderText = MyTraductor.getTextDTID(143392, "Reportero Asignado");
        colReportero_Asignado_Desc.SortExpression = "Reportero_Asignado.Nombre";
        colReportero_Asignado_Desc.UniqueName = "Reportero_Asignado.Nombre";
        colReportero_Asignado_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colReportero_Asignado_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colReportero_Asignado_Desc);
        GridBoundColumn colFecha_de_Compromiso = new GridBoundColumn();
        colFecha_de_Compromiso.DataField = "Registro_de_Contenido_Fecha_de_Compromiso";
        colFecha_de_Compromiso.HeaderText = MyTraductor.getTextDTID(143397, "Fecha de Compromiso");
        colFecha_de_Compromiso.SortExpression = "Registro_de_Contenido.Fecha_de_Compromiso";
        colFecha_de_Compromiso.UniqueName = "Registro_de_Contenido.Fecha_de_Compromiso";
        colFecha_de_Compromiso.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Compromiso.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Compromiso.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Compromiso);
        GridBoundColumn colEstatus = new GridBoundColumn();
        colEstatus.HeaderText = MyTraductor.getTextDTID(141534, "Estatus");
        colEstatus.DataField = "Registro_de_Contenido_Estatus";
        colEstatus.DataFormatString = "";
        colEstatus.SortExpression = "Registro_de_Contenido.Estatus";
        colEstatus.UniqueName = "Registro_de_Contenido.Estatus";
        colEstatus.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colEstatus.DataType = typeof(string);
        grdRadMov.Columns.Add(colEstatus);
        //grdMov.Columns[17+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[17+1].ItemStyle.CssClass = "Hide";
        colEstatus.HeaderStyle.CssClass = "Hide";
        colEstatus.ItemStyle.CssClass = "Hide";
        colEstatus.Visible = false;
        GridBoundColumn colEstatus_Desc = new GridBoundColumn();
        colEstatus_Desc.DataField = "Estatus_Descripcion";
        colEstatus_Desc.HeaderText = MyTraductor.getTextDTID(141534, "Estatus");
        colEstatus_Desc.SortExpression = "Estatus.Descripcion";
        colEstatus_Desc.UniqueName = "Estatus.Descripcion";
        colEstatus_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colEstatus_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colEstatus_Desc);
        GridBoundColumn colAdministrador_de_Observatorio = new GridBoundColumn();
        colAdministrador_de_Observatorio.HeaderText = MyTraductor.getTextDTID(143609, "Administrador de Observatorio");
        colAdministrador_de_Observatorio.DataField = "Registro_de_Contenido_Administrador_de_Observatorio";
        colAdministrador_de_Observatorio.DataFormatString = "";
        colAdministrador_de_Observatorio.SortExpression = "Registro_de_Contenido.Administrador_de_Observatorio";
        colAdministrador_de_Observatorio.UniqueName = "Registro_de_Contenido.Administrador_de_Observatorio";
        colAdministrador_de_Observatorio.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAdministrador_de_Observatorio.DataType = typeof(string);
        grdRadMov.Columns.Add(colAdministrador_de_Observatorio);
        //grdMov.Columns[19+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[19+1].ItemStyle.CssClass = "Hide";
        colAdministrador_de_Observatorio.HeaderStyle.CssClass = "Hide";
        colAdministrador_de_Observatorio.ItemStyle.CssClass = "Hide";
        colAdministrador_de_Observatorio.Visible = false;
        GridBoundColumn colAdministrador_de_Observatorio_Desc = new GridBoundColumn();
        colAdministrador_de_Observatorio_Desc.DataField = "Administrador_de_Observatorio_Nombre";
        colAdministrador_de_Observatorio_Desc.HeaderText = MyTraductor.getTextDTID(143609, "Administrador de Observatorio");
        colAdministrador_de_Observatorio_Desc.SortExpression = "Administrador_de_Observatorio.Nombre";
        colAdministrador_de_Observatorio_Desc.UniqueName = "Administrador_de_Observatorio.Nombre";
        colAdministrador_de_Observatorio_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAdministrador_de_Observatorio_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colAdministrador_de_Observatorio_Desc);
        GridBoundColumn colReportero = new GridBoundColumn();
        colReportero.HeaderText = MyTraductor.getTextDTID(141530, "Reportero");
        colReportero.DataField = "Registro_de_Contenido_Reportero";
        colReportero.DataFormatString = "";
        colReportero.SortExpression = "Registro_de_Contenido.Reportero";
        colReportero.UniqueName = "Registro_de_Contenido.Reportero";
        colReportero.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colReportero.DataType = typeof(string);
        grdRadMov.Columns.Add(colReportero);
        //grdMov.Columns[21+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[21+1].ItemStyle.CssClass = "Hide";
        colReportero.HeaderStyle.CssClass = "Hide";
        colReportero.ItemStyle.CssClass = "Hide";
        colReportero.Visible = false;
        GridBoundColumn colReportero_Desc = new GridBoundColumn();
        colReportero_Desc.DataField = "Reportero_Nombre";
        colReportero_Desc.HeaderText = MyTraductor.getTextDTID(141530, "Reportero");
        colReportero_Desc.SortExpression = "Reportero.Nombre";
        colReportero_Desc.UniqueName = "Reportero.Nombre";
        colReportero_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colReportero_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colReportero_Desc);
        GridBoundColumn colTitulo = new GridBoundColumn();
        colTitulo.HeaderText = MyTraductor.getTextDTID(141049, "Título del Contenido");
        colTitulo.DataField = "Registro_de_Contenido_Titulo";
        colTitulo.DataFormatString = "";
        colTitulo.SortExpression = "Registro_de_Contenido.Titulo";
        colTitulo.UniqueName = "Registro_de_Contenido.Titulo";
        colTitulo.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colTitulo.DataType = typeof(string);
        grdRadMov.Columns.Add(colTitulo);
        GridBoundColumn colDescripcion = new GridBoundColumn();
        colDescripcion.HeaderText = MyTraductor.getTextDTID(141050, "Descripción Breve");
        colDescripcion.DataField = "Registro_de_Contenido_Descripcion";
        colDescripcion.DataFormatString = "";
        colDescripcion.SortExpression = "Registro_de_Contenido.Descripcion";
        colDescripcion.UniqueName = "Registro_de_Contenido.Descripcion";
        colDescripcion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colDescripcion.DataType = typeof(string);
        grdRadMov.Columns.Add(colDescripcion);
        GridBoundColumn colContenido = new GridBoundColumn();
        colContenido.HeaderText = MyTraductor.getTextDTID(141051, "Contenido");
        colContenido.DataField = "Registro_de_Contenido_Contenido";
        colContenido.DataFormatString = "";
        colContenido.SortExpression = "Registro_de_Contenido.Contenido";
        colContenido.UniqueName = "Registro_de_Contenido.Contenido";
        colContenido.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colContenido.DataType = typeof(string);
        grdRadMov.Columns.Add(colContenido);
        GridBoundColumn colImagen = new GridBoundColumn();
        colImagen.HeaderText = MyTraductor.getTextDTID(141133, "Imagen");
        colImagen.DataField = "Registro_de_Contenido_Imagen";
        colImagen.DataFormatString = "";
        colImagen.SortExpression = "Registro_de_Contenido.Imagen";
        colImagen.UniqueName = "Registro_de_Contenido.Imagen";
        colImagen.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colImagen.DataType = typeof(string);
        grdRadMov.Columns.Add(colImagen);
        //grdMov.Columns[26+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[26+1].ItemStyle.CssClass = "Hide";
        colImagen.HeaderStyle.CssClass = "Hide";
        colImagen.ItemStyle.CssClass = "Hide";
        colImagen.Visible = false;
	        //GridBoundColumn colImagen_Desc = new GridBoundColumn();
	        //colImagen_Desc.ButtonType = ButtonType.Link;
	        //colImagen_Desc.CommandName = "Registro_de_Contenido_Imagen";
	        //colImagen_Desc.HeaderText = "Imagen";
	        //colImagen_Desc.DataTextField = "TTArchivos_Nombre";
	        //colImagen_Desc.SortExpression = "TTArchivos.Nombre";
	       //colImagen.UniqueName = "TTArchivos.Nombre";
	       //colImagen.DataType = typeof(string);
	        //grdRadMov.Columns.Add(colImagen_Desc);
        GridBoundColumn colImagen_Miniatura = new GridBoundColumn();
        colImagen_Miniatura.HeaderText = MyTraductor.getTextDTID(141911, "Imagen Miniatura");
        colImagen_Miniatura.DataField = "Registro_de_Contenido_Imagen_Miniatura";
        colImagen_Miniatura.DataFormatString = "";
        colImagen_Miniatura.SortExpression = "Registro_de_Contenido.Imagen_Miniatura";
        colImagen_Miniatura.UniqueName = "Registro_de_Contenido.Imagen_Miniatura";
        colImagen_Miniatura.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colImagen_Miniatura.DataType = typeof(string);
        grdRadMov.Columns.Add(colImagen_Miniatura);
        //grdMov.Columns[28+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[28+1].ItemStyle.CssClass = "Hide";
        colImagen_Miniatura.HeaderStyle.CssClass = "Hide";
        colImagen_Miniatura.ItemStyle.CssClass = "Hide";
        colImagen_Miniatura.Visible = false;
	        //GridBoundColumn colImagen_Miniatura_Desc = new GridBoundColumn();
	        //colImagen_Miniatura_Desc.ButtonType = ButtonType.Link;
	        //colImagen_Miniatura_Desc.CommandName = "Registro_de_Contenido_Imagen_Miniatura";
	        //colImagen_Miniatura_Desc.HeaderText = "Imagen Miniatura";
	        //colImagen_Miniatura_Desc.DataTextField = "TTArchivos_Nombre";
	        //colImagen_Miniatura_Desc.SortExpression = "TTArchivos.Nombre";
	       //colImagen_Miniatura.UniqueName = "TTArchivos.Nombre";
	       //colImagen_Miniatura.DataType = typeof(string);
	        //grdRadMov.Columns.Add(colImagen_Miniatura_Desc);
        GridBoundColumn colEstilo = new GridBoundColumn();
        colEstilo.HeaderText = MyTraductor.getTextDTID(141070, "Estilo");
        colEstilo.DataField = "Registro_de_Contenido_Estilo";
        colEstilo.DataFormatString = "";
        colEstilo.SortExpression = "Registro_de_Contenido.Estilo";
        colEstilo.UniqueName = "Registro_de_Contenido.Estilo";
        colEstilo.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colEstilo.DataType = typeof(string);
        grdRadMov.Columns.Add(colEstilo);
        //grdMov.Columns[30+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[30+1].ItemStyle.CssClass = "Hide";
        colEstilo.HeaderStyle.CssClass = "Hide";
        colEstilo.ItemStyle.CssClass = "Hide";
        colEstilo.Visible = false;
        GridBoundColumn colEstilo_Desc = new GridBoundColumn();
        colEstilo_Desc.DataField = "Estilo_Descripcion";
        colEstilo_Desc.HeaderText = MyTraductor.getTextDTID(141070, "Estilo");
        colEstilo_Desc.SortExpression = "Estilo.Descripcion";
        colEstilo_Desc.UniqueName = "Estilo.Descripcion";
        colEstilo_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colEstilo_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colEstilo_Desc);
        GridBoundColumn colAdjuntar_PDF = new GridBoundColumn();
        colAdjuntar_PDF.HeaderText = MyTraductor.getTextDTID(143404, "Adjuntar PDF");
        colAdjuntar_PDF.DataField = "Registro_de_Contenido_Adjuntar_PDF";
        colAdjuntar_PDF.DataFormatString = "";
        colAdjuntar_PDF.SortExpression = "Registro_de_Contenido.Adjuntar_PDF";
        colAdjuntar_PDF.UniqueName = "Registro_de_Contenido.Adjuntar_PDF";
        colAdjuntar_PDF.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAdjuntar_PDF.DataType = typeof(string);
        grdRadMov.Columns.Add(colAdjuntar_PDF);
        //grdMov.Columns[32+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[32+1].ItemStyle.CssClass = "Hide";
        colAdjuntar_PDF.HeaderStyle.CssClass = "Hide";
        colAdjuntar_PDF.ItemStyle.CssClass = "Hide";
        colAdjuntar_PDF.Visible = false;
	        //GridBoundColumn colAdjuntar_PDF_Desc = new GridBoundColumn();
	        //colAdjuntar_PDF_Desc.ButtonType = ButtonType.Link;
	        //colAdjuntar_PDF_Desc.CommandName = "Registro_de_Contenido_Adjuntar_PDF";
	        //colAdjuntar_PDF_Desc.HeaderText = "Adjuntar PDF";
	        //colAdjuntar_PDF_Desc.DataTextField = "TTArchivos_Nombre";
	        //colAdjuntar_PDF_Desc.SortExpression = "TTArchivos.Nombre";
	       //colAdjuntar_PDF.UniqueName = "TTArchivos.Nombre";
	       //colAdjuntar_PDF.DataType = typeof(string);
	        //grdRadMov.Columns.Add(colAdjuntar_PDF_Desc);
        GridBoundColumn colCaptura_Terminada = new GridBoundColumn();
        colCaptura_Terminada.HeaderText = MyTraductor.getTextDTID(143568, "Captura Terminada");
        colCaptura_Terminada.DataField = "Registro_de_Contenido_Captura_Terminada";
        colCaptura_Terminada.DataFormatString = "";
        colCaptura_Terminada.SortExpression = "Registro_de_Contenido.Captura_Terminada";
        colCaptura_Terminada.UniqueName = "Registro_de_Contenido.Captura_Terminada";
        colCaptura_Terminada.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colCaptura_Terminada.DataType = typeof(string);
        grdRadMov.Columns.Add(colCaptura_Terminada);
        GridBoundColumn colAutorizado_por = new GridBoundColumn();
        colAutorizado_por.HeaderText = MyTraductor.getTextDTID(141729, "Autorizado por");
        colAutorizado_por.DataField = "Registro_de_Contenido_Autorizado_por";
        colAutorizado_por.DataFormatString = "";
        colAutorizado_por.SortExpression = "Registro_de_Contenido.Autorizado_por";
        colAutorizado_por.UniqueName = "Registro_de_Contenido.Autorizado_por";
        colAutorizado_por.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAutorizado_por.DataType = typeof(string);
        grdRadMov.Columns.Add(colAutorizado_por);
        //grdMov.Columns[35+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[35+1].ItemStyle.CssClass = "Hide";
        colAutorizado_por.HeaderStyle.CssClass = "Hide";
        colAutorizado_por.ItemStyle.CssClass = "Hide";
        colAutorizado_por.Visible = false;
        GridBoundColumn colAutorizado_por_Desc = new GridBoundColumn();
        colAutorizado_por_Desc.DataField = "Autorizado_por_Nombre";
        colAutorizado_por_Desc.HeaderText = MyTraductor.getTextDTID(141729, "Autorizado por");
        colAutorizado_por_Desc.SortExpression = "Autorizado_por.Nombre";
        colAutorizado_por_Desc.UniqueName = "Autorizado_por.Nombre";
        colAutorizado_por_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAutorizado_por_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colAutorizado_por_Desc);
        GridBoundColumn colFecha_de_Revision = new GridBoundColumn();
        colFecha_de_Revision.DataField = "Registro_de_Contenido_Fecha_de_Revision";
        colFecha_de_Revision.HeaderText = MyTraductor.getTextDTID(141730, "Fecha de Revisión");
        colFecha_de_Revision.SortExpression = "Registro_de_Contenido.Fecha_de_Revision";
        colFecha_de_Revision.UniqueName = "Registro_de_Contenido.Fecha_de_Revision";
        colFecha_de_Revision.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Revision.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Revision.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Revision);
        GridBoundColumn colHora_de_Revision = new GridBoundColumn();
        colHora_de_Revision.HeaderText = MyTraductor.getTextDTID(141731, "Hora de Revisión");
        colHora_de_Revision.DataField = "Registro_de_Contenido_Hora_de_Revision";
        colHora_de_Revision.DataFormatString = "";
        colHora_de_Revision.SortExpression = "Registro_de_Contenido.Hora_de_Revision";
        colHora_de_Revision.UniqueName = "Registro_de_Contenido.Hora_de_Revision";
        colHora_de_Revision.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colHora_de_Revision.DataType = typeof(string);
        grdRadMov.Columns.Add(colHora_de_Revision);
        GridBoundColumn colAutorizacion = new GridBoundColumn();
        colAutorizacion.HeaderText = MyTraductor.getTextDTID(141734, "Autorización");
        colAutorizacion.DataField = "Registro_de_Contenido_Autorizacion";
        colAutorizacion.DataFormatString = "";
        colAutorizacion.SortExpression = "Registro_de_Contenido.Autorizacion";
        colAutorizacion.UniqueName = "Registro_de_Contenido.Autorizacion";
        colAutorizacion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAutorizacion.DataType = typeof(string);
        grdRadMov.Columns.Add(colAutorizacion);
        //grdMov.Columns[39+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[39+1].ItemStyle.CssClass = "Hide";
        colAutorizacion.HeaderStyle.CssClass = "Hide";
        colAutorizacion.ItemStyle.CssClass = "Hide";
        colAutorizacion.Visible = false;
        GridBoundColumn colAutorizacion_Desc = new GridBoundColumn();
        colAutorizacion_Desc.DataField = "Autorizacion_Descripcion";
        colAutorizacion_Desc.HeaderText = MyTraductor.getTextDTID(141734, "Autorización");
        colAutorizacion_Desc.SortExpression = "Autorizacion.Descripcion";
        colAutorizacion_Desc.UniqueName = "Autorizacion.Descripcion";
        colAutorizacion_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colAutorizacion_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colAutorizacion_Desc);
        GridBoundColumn colMotivo_de_Rechazo = new GridBoundColumn();
        colMotivo_de_Rechazo.HeaderText = MyTraductor.getTextDTID(141901, "Motivo de Rechazo");
        colMotivo_de_Rechazo.DataField = "Registro_de_Contenido_Motivo_de_Rechazo";
        colMotivo_de_Rechazo.DataFormatString = "";
        colMotivo_de_Rechazo.SortExpression = "Registro_de_Contenido.Motivo_de_Rechazo";
        colMotivo_de_Rechazo.UniqueName = "Registro_de_Contenido.Motivo_de_Rechazo";
        colMotivo_de_Rechazo.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colMotivo_de_Rechazo.DataType = typeof(string);
        grdRadMov.Columns.Add(colMotivo_de_Rechazo);
        GridBoundColumn colFecha_de_Inicio_de_Publicacion = new GridBoundColumn();
        colFecha_de_Inicio_de_Publicacion.DataField = "Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion";
        colFecha_de_Inicio_de_Publicacion.HeaderText = MyTraductor.getTextDTID(143405, "Fecha de Inicio de Publicación");
        colFecha_de_Inicio_de_Publicacion.SortExpression = "Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion";
        colFecha_de_Inicio_de_Publicacion.UniqueName = "Registro_de_Contenido.Fecha_de_Inicio_de_Publicacion";
        colFecha_de_Inicio_de_Publicacion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Inicio_de_Publicacion.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Inicio_de_Publicacion.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Inicio_de_Publicacion);
        GridBoundColumn colFecha_de_Termino = new GridBoundColumn();
        colFecha_de_Termino.DataField = "Registro_de_Contenido_Fecha_de_Termino";
        colFecha_de_Termino.HeaderText = MyTraductor.getTextDTID(143406, "Fecha de Término");
        colFecha_de_Termino.SortExpression = "Registro_de_Contenido.Fecha_de_Termino";
        colFecha_de_Termino.UniqueName = "Registro_de_Contenido.Fecha_de_Termino";
        colFecha_de_Termino.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Termino.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Termino.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Termino);
        GridBoundColumn colSeleccionar_Todos_los_Observatorios = new GridBoundColumn();
        colSeleccionar_Todos_los_Observatorios.HeaderText = MyTraductor.getTextDTID(149684, "Seleccionar Todos los Observatorios");
        colSeleccionar_Todos_los_Observatorios.DataField = "Registro_de_Contenido_Seleccionar_Todos_los_Observatorios";
        colSeleccionar_Todos_los_Observatorios.DataFormatString = "";
        colSeleccionar_Todos_los_Observatorios.SortExpression = "Registro_de_Contenido.Seleccionar_Todos_los_Observatorios";
        colSeleccionar_Todos_los_Observatorios.UniqueName = "Registro_de_Contenido.Seleccionar_Todos_los_Observatorios";
        colSeleccionar_Todos_los_Observatorios.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colSeleccionar_Todos_los_Observatorios.DataType = typeof(string);
        grdRadMov.Columns.Add(colSeleccionar_Todos_los_Observatorios);
        GridBoundColumn colFiltrar_Usuarios_por_Observatorio = new GridBoundColumn();
        colFiltrar_Usuarios_por_Observatorio.HeaderText = MyTraductor.getTextDTID(159065, "Filtrar Usuarios por Observatorio");
        colFiltrar_Usuarios_por_Observatorio.DataField = "Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio";
        colFiltrar_Usuarios_por_Observatorio.DataFormatString = "";
        colFiltrar_Usuarios_por_Observatorio.SortExpression = "Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio";
        colFiltrar_Usuarios_por_Observatorio.UniqueName = "Registro_de_Contenido.Filtrar_Usuarios_por_Observatorio";
        colFiltrar_Usuarios_por_Observatorio.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFiltrar_Usuarios_por_Observatorio.DataType = typeof(string);
        grdRadMov.Columns.Add(colFiltrar_Usuarios_por_Observatorio);
        //grdMov.Columns[45+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[45+1].ItemStyle.CssClass = "Hide";
        colFiltrar_Usuarios_por_Observatorio.HeaderStyle.CssClass = "Hide";
        colFiltrar_Usuarios_por_Observatorio.ItemStyle.CssClass = "Hide";
        colFiltrar_Usuarios_por_Observatorio.Visible = false;
        GridBoundColumn colFiltrar_Usuarios_por_Observatorio_Desc = new GridBoundColumn();
        colFiltrar_Usuarios_por_Observatorio_Desc.DataField = "Filtrar_Usuarios_por_Observatorio_Nombre";
        colFiltrar_Usuarios_por_Observatorio_Desc.HeaderText = MyTraductor.getTextDTID(159065, "Filtrar Usuarios por Observatorio");
        colFiltrar_Usuarios_por_Observatorio_Desc.SortExpression = "Filtrar_Usuarios_por_Observatorio.Nombre";
        colFiltrar_Usuarios_por_Observatorio_Desc.UniqueName = "Filtrar_Usuarios_por_Observatorio.Nombre";
        colFiltrar_Usuarios_por_Observatorio_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFiltrar_Usuarios_por_Observatorio_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colFiltrar_Usuarios_por_Observatorio_Desc);

    }

    protected void BtnSelect_Click(object sender, EventArgs e)
    {
    }

    protected void IbtnBorrarSeleccion_Click(object sender, EventArgs e)
    {        
    }   
    
    protected void cmdAll_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void cmdNew_Click(object sender, ImageClickEventArgs e)
    {
        Session["Folio"]="";

        Session["Tipo_Transaccion"] = "New";

        string Fase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";
        
        if (Request["MenuVisible"] != null)
            Response.Redirect("Registro_de_Contenido_Catalogo.aspx?MenuVisible=false");
        else
            Response.Redirect("Registro_de_Contenido_Catalogo.aspx");
    }
    
    protected void cmdSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Fase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";

         if (Fase != string.Empty)
            Response.Redirect("~/FormsSystem/TTBusquedaAvanzada.aspx?idProceso=" + idProceso.ToString() + "&Fase=" + Fase);
         else
            Response.Redirect("~/FormsSystem/TTBusquedaAvanzada.aspx?idProceso=" + idProceso.ToString());
    }
    
    protected void cmdExport_Click(object sender, ImageClickEventArgs e)
    {
        //---------------------------------------------------------------------------------------------------------------
        if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso))
            return;
        //---------------------------------------------------------------------------------------------------------------        
        //----------------------------------- Exportación de una sola página --------------------------------------------
        /*GridView grid = new GridView();
        // Disable paging
        grdMov.AllowPaging = false;
        Grid_Bind();
        grid = grdMov;

        Session["dsGrid"] = grid;
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de Registro de Contenido&process="+idProceso.ToString()+"&brOperation=Export";
        rwExport.VisibleOnPageLoad = true;

        // Rebind with paging enabled
        grdMov.AllowPaging = true;
        Grid_Bind();*/        
        //----------------------------------- Exportación Completa ------------------------------------------------------
        WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();

        List<GridFilterExpression> filterExpression;
        List<GridSortExpression> sortExpression;
        if (HttpContext.Current.Session["GridState"] != null)
        {
            GridState oGridState = (GridState)HttpContext.Current.Session["GridState"];
            filterExpression = oGridState.filterExpression;
            sortExpression = oGridState.sortExpression;
        }
        else
        {
            filterExpression = new List<GridFilterExpression>();
            sortExpression = new List<GridSortExpression>();
        }
        string swhere = new GridGenericFilterer(filterExpression).GetWhere();

        if (HttpContext.Current.Session["Where"] != null && HttpContext.Current.Session["NombreDNT"] != null && HttpContext.Current.Session["Where"].ToString() != "")
        {
            if (HttpContext.Current.Session["NombreDNT"].ToString() == sDNTNombre)
                swhere += (swhere == "" ? " WHERE " : " AND (") + HttpContext.Current.Session["Where"].ToString() + (swhere == "" ? "" : ")");
            else
            {
                HttpContext.Current.Session.Remove("NombreDNT");
                HttpContext.Current.Session.Remove("Where");
            }
        }
        string wworkflow = "";
        string faseWorkflow = HttpContext.Current.Session["Fase"].ToString();
        if (HttpContext.Current.Session["WhereWorflow"] != null)
        {
            KeyValuePair<string, string> oWhereWorkfo = (KeyValuePair<string, string>)HttpContext.Current.Session["WhereWorflow"];
            if (oWhereWorkfo.Key == faseWorkflow)
            {
                swhere += (oWhereWorkfo.Value != "" ? (swhere == "" ? " WHERE " : " AND (") + oWhereWorkfo.Value + (swhere == "" ? "" : ")") : "");
            }
            else
            {
                HttpContext.Current.Session.Remove("WhereWorflow");
                wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
                swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
                HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
            }
        }
        else
        {
            wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
            swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
            HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
        }
        if (HttpContext.Current.Session["WhereFromBR"] != null)
        {
            string WhereFromBR = HttpContext.Current.Session["WhereFromBR"].ToString();

            swhere += (WhereFromBR != "" ? (swhere == "" ? " WHERE " : " AND (") + WhereFromBR + (swhere == "" ? "" : ")") : "");
        } 

        string sQ = myRegistro_de_Contenido.ListaGetFullQuery(swhere, new GridGenericSorter(sortExpression).GetOrder());
        string sPath = HttpContext.Current.Server.MapPath("..\\App_Data");
        string SID = Session.SessionID.ToString();

        ExportWithConsoleApp(sQ, sPath, SID, FileExportFormat.xls) ;

        if (File.Exists(sPath + "\\" + SID + "." + FileExportFormat.xls))
        {
            //---------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.OpenWindows, idProceso);
            //---------------------------------------------------------------------------------------------------------------
            SID = sPath + "\\" + SID;
            DownloadFile(SID + "." + FileExportFormat.xls, sDNTNombre.Replace(" ", "_") + "." + FileExportFormat.xls);
        }              
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
        //---------------------------------------------------------------------------------------------------------------
    }
    
    protected void cmdConfiguration_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FormsSystem/TTConfiguracion.aspx?idProceso=" + idProceso.ToString());
    }
    
    protected void cmdPrint_Click(object sender, ImageClickEventArgs e)
    {
      
    }
       
   
    
    protected void ODSGrdMov_OnSelected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        
    }
    
    protected void LoadFilterControl()
    {
    }
    
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
       
    }
    protected void grdRadMov_Init(object sender, System.EventArgs e)
    {
        GridFilterMenu menu = grdRadMov.FilterMenu;
        int i = 0;
        while (i < menu.Items.Count)
        {
            if (menu.Items[i].Text == "Between" || menu.Items[i].Text == "NotBetween")
            {
                menu.Items.RemoveAt(i);
            }
            else
            {
                switch (menu.Items[i].Text)
                {
                    case "NoFilter":
                        menu.Items[i].Text = "Sin Filtro";
                        break;
                    case "Contains":
                        menu.Items[i].Text = "Contiene";
                        break;
                    case "EqualTo":
                        menu.Items[i].Text = "Igual a";
                        break;
                    case "GreaterThan":
                        menu.Items[i].Text = "Mayor que";
                        break;
                    case "LessThan":
                        menu.Items[i].Text = "Menor que";
                        break;
                    case "DoesNotContain":
                        menu.Items[i].Text = "No contiene";
                        break;
                    case "StartsWith":
                        menu.Items[i].Text = "Inicia con";
                        break;
                    case "EndsWith":
                        menu.Items[i].Text = "Termina con";
                        break;
                    case "NotEqualTo":
                        menu.Items[i].Text = "Diferente de";
                        break;
                    case "GreaterThanOrEqualTo":
                        menu.Items[i].Text = "Mayor o igual que";
                        break;
                    case "LessThanOrEqualTo":
                        menu.Items[i].Text = "Menor o igual que";
                        break;
                    case "IsEmpty":
                        menu.Items[i].Text = "Esta vacio";
                        break;
                    case "NotIsEmpty":
                        menu.Items[i].Text = "No esta vacio";
                        break;
                    case "IsNull":
                        menu.Items[i].Text = "Es nulo";
                        break;
                    case "NotIsNull":
                        menu.Items[i].Text = "No es nulo";
                        break;
                };

                i++;
            }
        }
    }

[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static Dictionary<string, object> GetDataAndCount(int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression, bool saveState, string RemoveSort,string faseWorkflow)



        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            try
            {
                if (saveState)

                {
                    var oGridSate = (GridState)HttpContext.Current.Session["GridState"];
                    if (oGridSate != null)
                    {
                        if (oGridSate.idProceso == idProceso && oGridSate.fase == faseWorkflow)
                        {
                            sortExpression.AddRange(oGridSate.sortExpression.Where(x => !sortExpression.Select(y => y.FieldName).Contains(x.FieldName) && x.FieldName != RemoveSort));
                            HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseWorkflow);
                        }
                        else
                        {
                            HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseWorkflow);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseWorkflow);
                    }
                }

        WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();


                string swhere = new GridGenericFilterer(filterExpression).GetWhere();

                if (HttpContext.Current.Session["Where"] != null && HttpContext.Current.Session["NombreDNT"] != null && HttpContext.Current.Session["Where"].ToString() != "")
                {
                    if (HttpContext.Current.Session["NombreDNT"].ToString() == sDNTNombre)
                        swhere += (swhere == "" ? " WHERE " : " AND (") + HttpContext.Current.Session["Where"].ToString() + (swhere == "" ? "" : ")");
                    else
                    {
                        HttpContext.Current.Session.Remove("NombreDNT");
                        HttpContext.Current.Session.Remove("Where");
                    }
                }

                string wworkflow = "";
                if (HttpContext.Current.Session["WhereWorflow"] != null)
                {
                    KeyValuePair<string, string> oWhereWorkfo = (KeyValuePair<string, string>)HttpContext.Current.Session["WhereWorflow"];
                    if (oWhereWorkfo.Key == faseWorkflow)
                    {
                        swhere += (oWhereWorkfo.Value != "" ? (swhere == "" ? " WHERE " : " AND (") + oWhereWorkfo.Value + (swhere == "" ? "" : ")") : "");
                    }
                    else
                    {
                        HttpContext.Current.Session.Remove("WhereWorflow");
                        wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
                        swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
                        HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
                    }
                }
                else
                {
                    wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
                    swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
                    HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
                }
                if (HttpContext.Current.Session["WhereFromBR"] != null)
                {
                    string WhereFromBR = HttpContext.Current.Session["WhereFromBR"].ToString();

                    swhere += (WhereFromBR != "" ? (swhere == "" ? " WHERE " : " AND (") + WhereFromBR + (swhere == "" ? "" : ")") : "");
                } 
        if (HttpContext.Current.Session["OrderFromBR"] != null)
        {
            List<GridSortExpression> OrderFromBR = (List<GridSortExpression>)HttpContext.Current.Session["OrderFromBR"];

            foreach (GridSortExpression item in OrderFromBR)
            {
                sortExpression.Add(item);
            }

        } 


                DataSet dat = myRegistro_de_Contenido.ListaSelAll(startRowIndex, maximumRows, swhere, new GridGenericSorter(sortExpression).GetOrder());

                data.Add("Data", JsonMethods.RowsToDictionary(dat.Tables[0]));
                data.Add("Count", myRegistro_de_Contenido.ListaSelCount(swhere));
                return data;
            }
            catch (Exception ex)
            {
                if (data.ContainsKey("Data"))
                    data["Data"] = JsonMethods.RowsToDictionary(new DataTable());
                else
                    data.Add("Data", JsonMethods.RowsToDictionary(new DataTable()));
                if (data.ContainsKey("Count"))
                    data["Count"] = 0;
                else
                    data.Add("Count", 0);
                return data;
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static Dictionary<string, object> GetAllDataAndCount(int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression, string faseworkflow)
        {
            HttpContext.Current.Session.Remove("NombreDNT");
            HttpContext.Current.Session.Remove("Where");
            var oGridSate = (GridState)HttpContext.Current.Session["GridState"];
            if (oGridSate != null)
            {
                if (oGridSate.idProceso == idProceso && oGridSate.fase == faseworkflow)
                {
                    sortExpression.AddRange(oGridSate.sortExpression.Where(x => !sortExpression.Select(y => y.FieldName).Contains(x.FieldName) && x.FieldName != ""));
                    HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseworkflow);
                }
                else
                {
                    HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseworkflow);
                }
            }
            else
            {
                HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso, faseworkflow);
            }
            return GetDataAndCount(startRowIndex, maximumRows, sortExpression, filterExpression, false, "",faseworkflow);


        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult Delete_Row(string Folio, int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression, string faseworkflow)
        {
            try
            {
                ////------------------------------------------------------------------------------------------------------------------------------------
                //if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso))
                //    return;
                ////------------------------------------------------------------------------------------------------------------------------------------
                WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();

                TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
                WSRegistro_de_Contenido.GlobalData userData = new WSRegistro_de_Contenido.GlobalData();
                TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
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
                myRegistro_de_Contenido.Delete(userData, MyFunctions.FormatNumberNull(Folio));
                Dictionary<string, object> data = GetDataAndCount(startRowIndex, maximumRows, sortExpression, filterExpression, true, "",faseworkflow);
                ////------------------------------------------------------------------------------------------------------------------------------------
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
                ////------------------------------------------------------------------------------------------------------------------------------------        
                return new JsonResult(data, true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString().Replace("\r\n","<br />"));
            }

        }



        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult Print(string Folio)


        {
            try
            {
                HttpContext.Current.Session["Llave"] = Folio;
                //---------------------------------------------------------------------------------------------------------------
                //if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso))
                //    return;
                //---------------------------------------------------------------------------------------------------------------

                //---------------------------------------------------------------------------------------------------------------
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
                //---------------------------------------------------------------------------------------------------------------           
                DataTable Tformatos = TTFormatosCS.objectBussinessTTFormatos.getFormatos(int.Parse(HttpContext.Current.Session["globalTipoUsuario"].ToString()), idProceso);
                if(Tformatos.Rows.Count > 0)
                    return new JsonResult("Impresion_Formatos.aspx?idProceso=" + idProceso.ToString() + "&IDM=" + Folio, true, null);
                else
                return new JsonResult("Reporte_por_Renglon.aspx?idProceso=" + idProceso.ToString(), true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult Consult(string Folio, string Fase)
        {
            try
            {
                HttpContext.Current.Session["Folio"] = Folio;
                HttpContext.Current.Session["Tipo_Transaccion"] = "Consult";
                if (Fase != null && Fase != string.Empty)
                    return new JsonResult("Registro_de_Contenido_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                    return new JsonResult("Registro_de_Contenido_Catalogo.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult Edit(string Folio, string Fase)


        {
            try
            {
                HttpContext.Current.Session["Folio"] = Folio;
                HttpContext.Current.Session["Tipo_Transaccion"] = "Update";
                
                if (Fase != null && Fase != string.Empty)
                    return new JsonResult("Registro_de_Contenido_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                    return new JsonResult("Registro_de_Contenido_Catalogo.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }

        //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX.CS INICIO New() LINEA 1446 JZAMORA
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult New(bool MenuVisible, string Fase)
        {
            try
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("Select * from ttpermisos_por_proceso where idproceso=29982 and idoperacion=7");
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count>0)
                {
                    WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();
                    WSRegistro_de_Contenido.GlobalData userData = new WSRegistro_de_Contenido.GlobalData();
                    TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
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
                    HttpContext.Current.Session["Folio"] = Funcion.RegresaDato("insert into Registro_de_Contenido(Usuario_que_Registra) values(null); select @@identity");
                    HttpContext.Current.Session["Tipo_Transaccion"] = "Update";
                }
                else
                {
                    HttpContext.Current.Session["Folio"] = "";
                    HttpContext.Current.Session["Tipo_Transaccion"] = "New";
                }
                if (MenuVisible)
                {
                    if (Fase != null && Fase != string.Empty)
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx?MenuVisible=false&Fase=" + Fase, true, null);
                    else
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx?MenuVisible=false", true, null);
                }
                else
                {
                    if (Fase != null && Fase != string.Empty)
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx?Fase=" + Fase, true, null);
                    else
                        return new JsonResult("Registro_de_Contenido_Catalogo.aspx", true, null);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }
        //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX.CS FIN New() LINEA 1476 JZAMORA

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult PrintAll(string[] Columns)


        {
            try
            {
                //---------------------------------------------------------------------------------------------------------------
                //if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso))
                //    return;
                //---------------------------------------------------------------------------------------------------------------        
                GridState oGridState = (GridState)HttpContext.Current.Session["GridState"];
                List<GridSortExpression> sortExpression;
                List<GridFilterExpression> filterExpression;
                if (oGridState == null)
                {
                    sortExpression = new List<GridSortExpression>();
                    filterExpression = new List<GridFilterExpression>();
                }
                else
                {
                    sortExpression = oGridState.sortExpression;
                    filterExpression = oGridState.filterExpression;
                }
                WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido myRegistro_de_Contenido = new WSRegistro_de_Contenido.objectBussinessRegistro_de_Contenido();

                string swhere = new GridGenericFilterer(filterExpression).GetWhere();

                if (HttpContext.Current.Session["Where"] != null && HttpContext.Current.Session["NombreDNT"] != null && HttpContext.Current.Session["Where"].ToString() != "")
                {
                    if (HttpContext.Current.Session["NombreDNT"].ToString() == sDNTNombre)
                	swhere += (swhere == "" ? " WHERE " : " AND (") + HttpContext.Current.Session["Where"].ToString() + (swhere == "" ? "" : ")");
                    else
                    {
                	HttpContext.Current.Session.Remove("NombreDNT");
                	HttpContext.Current.Session.Remove("Where");
                    }
                }
                string wworkflow = "";
                string faseWorkflow = HttpContext.Current.Session["Fase"].ToString();
                if (HttpContext.Current.Session["WhereWorflow"] != null)
                {
                    KeyValuePair<string, string> oWhereWorkfo = (KeyValuePair<string, string>)HttpContext.Current.Session["WhereWorflow"];
                    if (oWhereWorkfo.Key == faseWorkflow)
                    {
                        swhere += (oWhereWorkfo.Value != "" ? (swhere == "" ? " WHERE " : " AND (") + oWhereWorkfo.Value + (swhere == "" ? "" : ")") : "");
                    }
                    else
                    {
                        HttpContext.Current.Session.Remove("WhereWorflow");
                        wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
                        swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
                        HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
                    }
                }
                else
                {
                    wworkflow = ttWorkFlowAplicaCondiciones(faseWorkflow);
                    swhere += (wworkflow != "" ? (swhere == "" ? " WHERE " : " AND (") + wworkflow + (swhere == "" ? "" : ")") : "");
                    HttpContext.Current.Session["WhereWorflow"] = new KeyValuePair<string, string>(faseWorkflow, wworkflow);
                }
                if (HttpContext.Current.Session["WhereFromBR"] != null)
                {
                    string WhereFromBR = HttpContext.Current.Session["WhereFromBR"].ToString();

                    swhere += (WhereFromBR != "" ? (swhere == "" ? " WHERE " : " AND (") + WhereFromBR + (swhere == "" ? "" : ")") : "");
                } 

                DataTable dat = myRegistro_de_Contenido.ImpresionSelAll(swhere, new GridGenericSorter(sortExpression).GetOrder()).Tables[0];
            Again:
                foreach (DataColumn column in dat.Columns)
                {
                    bool found = false;
                    foreach (string columnName in Columns)
                    {
                        if (columnName == column.ColumnName)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        dat.Columns.Remove(column);
                        goto Again;
                    }
                }

                HttpContext.Current.Session["dsGrid"] = dat;

                //---------------------------------------------------------------------------------------------------------------
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
                //---------------------------------------------------------------------------------------------------------------           
                return new JsonResult("../FormsSystem/TTExportaRad.aspx?Titulo=Lista de Registro_de_Contenido&PrintDialog=true&process=" + idProceso.ToString() + "&brOperation=Print", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }

        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult Select(string Id)
        {
            try
            {
                HttpContext.Current.Session["ClaveLista"] = Id;
                return new JsonResult("Registro_de_Contenido_Lista.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());

            }

        }

        //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX.CS INICIO #region WorkFlows LINEA 1525 JZAMORA
        #region WorkFlows

        #region ttWorkFlowAsignaPermisos()
        protected void ttWorkFlowAsignaPermisos()
        {
            string strFase = (Request["Fase"] != null) ? Request["Fase"].ToString() : "";

            Int32 Fase = 0;
            if (strFase!="")
                Fase = Int32.Parse(strFase);

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spGetPermisosWorkFlow2");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(Session["globalTipoUsuario"].ToString());
            com.Parameters.Add("@Proceso", SqlDbType.Int).Value = idProceso;
            com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HtmlGenericControl btn_nuevo = ((HtmlGenericControl)Funcion.FindControlRecursive(Page, "btn_nuevo"));
                HtmlGenericControl btn_exportar = ((HtmlGenericControl)Funcion.FindControlRecursive(Page, "btn_exportar"));
                HtmlGenericControl btn_imprimir = ((HtmlGenericControl)Funcion.FindControlRecursive(Page, "btn_imprimir"));
                HtmlGenericControl btn_configuracion = ((HtmlGenericControl)Funcion.FindControlRecursive(Page, "btn_configurar"));

                if (grdRadMov.Columns.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["consultar"].ToString() == "0")
                    {
                        grdRadMov.Columns[3].HeaderStyle.CssClass = "Hide";
                        grdRadMov.Columns[3].ItemStyle.CssClass = "Hide";
                        grdRadMov.Columns[3].Visible = false;
                    }
                    else
                        grdRadMov.Columns[3].Visible = true;

                    if (btn_nuevo != null)
                        btn_nuevo.Visible = (ds.Tables[0].Rows[0]["nuevo"].ToString() == "1");

                    if (ds.Tables[0].Rows[0]["modificar"].ToString() == "0")
                    {
                        grdRadMov.Columns[4].Visible = false; //icono editar
                    }
                    else
                        grdRadMov.Columns[4].Visible = true;

                    if (ds.Tables[0].Rows[0]["eliminar"].ToString() == "0")
                    {
                        grdRadMov.Columns[0].Visible = false; //checkbox borrar
                        grdRadMov.Columns[1].Visible = false; //icono borrar
                    }
                    else
                    {
                        grdRadMov.Columns[0].Visible = true; //checkbox borrar
                        grdRadMov.Columns[1].Visible = true; //icono borrar
                    }
                }
                if (btn_exportar != null)
                    btn_exportar.Visible = (ds.Tables[0].Rows[0]["exportar"].ToString() == "1");


                if (btn_imprimir != null)
                {
                    btn_imprimir.Visible = (ds.Tables[0].Rows[0]["imprimir"].ToString() == "1");
                    if (grdRadMov.Columns.Count > 0)
                        grdRadMov.Columns[5].Visible = (ds.Tables[0].Rows[0]["imprimir"].ToString() == "1"); //icono imprimir
                }

                if (btn_configuracion != null)
                    btn_configuracion.Visible = (ds.Tables[0].Rows[0]["configurar"].ToString() == "1");
            }

            ttWorkFlowVisibilidadColumnas();


        }
        #endregion

        #region ttWorkFlowAplicaCondiciones()
        public static string ttWorkFlowAplicaCondiciones(string strFase)
      {
            int Fase = 0;

            if(strFase!="")
                Fase = Convert.ToInt32(strFase);

            #region Old_Code
            //TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            //SqlCommand com = new SqlCommand("spGetCondicionesEstadoWorkFlow");
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(HttpContext.Current.Session["globalTipoUsuario"].ToString());
            //com.Parameters.Add("@Proceso", SqlDbType.Int).Value = idProceso;
            //com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
            //DataSet ds = db.Consulta(com);
            ////for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string operador = ds.Tables[0].Rows[i]["operador"].ToString();
            //    Where = Where + " "+ operador +" (" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Tabla"].ToString()) + "." + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Campo"].ToString()) + " " + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Condicion"].ToString()) + " " + ds.Tables[0].Rows[i]["valor"].ToString() + ") ";
            //    if (ds.Tables[0].Rows[i]["valor"].ToString() == "7")
            //    {
            //        Where = Where + " OR (" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Tabla"].ToString()) + "." + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Campo"].ToString()) + " " + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Condicion"].ToString()) + " 9) ";
            //    }
            //}

            //HttpContext.Current.Session["NombreDNT"] = sDNTNombre;

            //if (Where != "")
            //{
            //    if (HttpContext.Current.Session["Where"].ToString().Trim() == "")
            //        HttpContext.Current.Session["Where"] = Where.Substring(5);
            //    else
            //    {
            //        HttpContext.Current.Session["Where"] = HttpContext.Current.Session["Where"] + Where;
            //    }
            //} 
            #endregion

            //HttpContext.Current.Session["NombreDNT"] = sDNTNombre;

            return Funcion.ValidaWorkFlow_GetWhere(idProceso, Fase, Int32.Parse(HttpContext.Current.Session["globalTipoUsuario"].ToString()), true);
            // La función incluye este código que ya fue aplicado:
            //HttpContext.Current.Session["Where"] = HttpContext.Current.Session["Where"] + Where;
        }
        #endregion

        #region ttWorkFlowVisibilidadColumnas()

        private void ttWorkFlowVisibilidadColumnas()
        {
            int Fase = 0;
            string strFase="";
            if (Request["Fase"] != null)
                strFase = Request["Fase"].ToString();
            if (strFase != "")
                Fase = Convert.ToInt32(strFase);
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spGetColumnsWorkFlow");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Int32.Parse(HttpContext.Current.Session["globalTipoUsuario"].ToString());
            com.Parameters.Add("@Proceso", SqlDbType.Int).Value = idProceso;
            com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
            DataSet ds = db.Consulta(com);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (GridColumn col in grdRadMov.Columns)
                {
                    DataRow[] ren = ds.Tables[0].Select("nombre = '" + col.UniqueName + "'");
                    if (ren.Count() > 0)
                    {
                        if (ren.Count() > 1)
                            col.Visible = false;
                        else if (ren[0]["Visible"].ToString() == "0")
                            col.Visible = false;
                    }
                }
            }
        }

        #endregion

        #endregion
        //TODO:WEBFORMS/Registro_de_Contenido_LISTA.ASPX.CS FIN #region WorkFlows LINEA 1626 JZAMORA
    }

}
