﻿/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD      h:m             
Descripción:      Pantalla Lista Codigos_por_Cliente
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
public partial class Codigos_por_Cliente_Lista : TTBasePage.TTBasePage
{
    public string sortExpression_;
    public string sortDirection_;
    const String sDNTNombre = "Codigos_por_Cliente";
    const String sDNTDescripcion = "Códigos por Cliente";
    const Int32 idProceso = 30071;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
            

	if (Request["pf"] != null && Request["Fase"] != null)
            if(Request["pf"].ToString() == "1")
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("Select * from ttpermisos_por_proceso where idproceso=30071 and idoperacion=7");
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count>0)
                {
                    WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();
                    WSCodigos_por_Cliente.GlobalData userData = new WSCodigos_por_Cliente.GlobalData();
                    TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
                    userData.AppToTempFiles = MyUserData.AppToTempFiles;
                    userData.ComputerName = MyUserData.ComputerName;
                    userData.DatabaseName = MyUserData.DatabaseName;
                    userData.Folio = MyUserData.Folio;
                    userData.Language = (WSCodigos_por_Cliente.GlobalDataLanguages)MyUserData.Language;
                    userData.ServidorName = MyUserData.ServidorName;
                    userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
                    userData.UserID = MyUserData.UserID;
                    userData.UserName = MyUserData.UserName;
                    userData.WindowsVersion = MyUserData.WindowsVersion;
                    Session["Folio"] = Funcion.RegresaDato("insert into Codigos_por_Cliente(Usuario_que_Registra) values(null); select @@identity");
                    Session["Tipo_Transaccion"] = "Update";
                }
                else
                {
                    Session["Folio"] = "";
                    Session["Tipo_Transaccion"] = "New";
                }
                Response.Redirect("Codigos_por_Cliente_Catalogo.aspx?pf=1&Fase=" + Request["Fase"].ToString());
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

            //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX INICIO SETLANGUAGE() LINEA 103 JZAMORA
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
            //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX END SetLanguage() LINEA 127 JZAMORA

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

        WSCodigos_por_Cliente.GlobalData userData;
        userData = new WSCodigos_por_Cliente.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSCodigos_por_Cliente.GlobalDataLanguages)MyUserData.Language;
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
        colFolio.HeaderText = MyTraductor.getTextDTID(141690, "Folio");
        colFolio.HtmlEncode = false;
        colFolio.DataField = "Codigos_por_Cliente_Folio";
        colFolio.SortExpression = "Codigos_por_Cliente.Folio";
        colFolio.UniqueName = "Codigos_por_Cliente.Folio";
        colFolio.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        colFolio.DataType = typeof(int);
        grdRadMov.MasterTableView.Columns.Add(colFolio);
        GridBoundColumn colUsuario_que_Registra = new GridBoundColumn();
        colUsuario_que_Registra.HeaderText = MyTraductor.getTextDTID(141693, "Usuario que Registra");
        colUsuario_que_Registra.DataField = "Codigos_por_Cliente_Usuario_que_Registra";
        colUsuario_que_Registra.DataFormatString = "";
        colUsuario_que_Registra.SortExpression = "Codigos_por_Cliente.Usuario_que_Registra";
        colUsuario_que_Registra.UniqueName = "Codigos_por_Cliente.Usuario_que_Registra";
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
        colUsuario_que_Registra_Desc.HeaderText = MyTraductor.getTextDTID(141693, "Usuario que Registra");
        colUsuario_que_Registra_Desc.SortExpression = "Usuario_que_Registra.Nombre";
        colUsuario_que_Registra_Desc.UniqueName = "Usuario_que_Registra.Nombre";
        colUsuario_que_Registra_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colUsuario_que_Registra_Desc.DataType = typeof(string);
        grdRadMov.Columns.Add(colUsuario_que_Registra_Desc);
        GridBoundColumn colFecha_de_Registro = new GridBoundColumn();
        colFecha_de_Registro.DataField = "Codigos_por_Cliente_Fecha_de_Registro";
        colFecha_de_Registro.HeaderText = MyTraductor.getTextDTID(141694, "Fecha de Registro");
        colFecha_de_Registro.SortExpression = "Codigos_por_Cliente.Fecha_de_Registro";
        colFecha_de_Registro.UniqueName = "Codigos_por_Cliente.Fecha_de_Registro";
        colFecha_de_Registro.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colFecha_de_Registro.DataFormatString = "{0:" + System.Configuration.ConfigurationSettings.AppSettings["FormatoFechaGrid"].ToString() + "}";
        colFecha_de_Registro.DataType = typeof(DateTime);
        grdRadMov.Columns.Add(colFecha_de_Registro);
        GridBoundColumn colHora_de_Registro = new GridBoundColumn();
        colHora_de_Registro.HeaderText = MyTraductor.getTextDTID(141696, "Hora de Registro");
        colHora_de_Registro.DataField = "Codigos_por_Cliente_Hora_de_Registro";
        colHora_de_Registro.DataFormatString = "";
        colHora_de_Registro.SortExpression = "Codigos_por_Cliente.Hora_de_Registro";
        colHora_de_Registro.UniqueName = "Codigos_por_Cliente.Hora_de_Registro";
        colHora_de_Registro.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colHora_de_Registro.DataType = typeof(string);
        grdRadMov.Columns.Add(colHora_de_Registro);
        GridBoundColumn colCliente = new GridBoundColumn();
        colCliente.HeaderText = MyTraductor.getTextDTID(143407, "Cliente");
        colCliente.DataField = "Codigos_por_Cliente_Cliente";
        colCliente.DataFormatString = "";
        colCliente.SortExpression = "Codigos_por_Cliente.Cliente";
        colCliente.UniqueName = "Codigos_por_Cliente.Cliente";
        colCliente.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colCliente.DataType = typeof(string);
        grdRadMov.Columns.Add(colCliente);
        GridBoundColumn colContacto = new GridBoundColumn();
        colContacto.HeaderText = MyTraductor.getTextDTID(143408, "Contacto");
        colContacto.DataField = "Codigos_por_Cliente_Contacto";
        colContacto.DataFormatString = "";
        colContacto.SortExpression = "Codigos_por_Cliente.Contacto";
        colContacto.UniqueName = "Codigos_por_Cliente.Contacto";
        colContacto.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colContacto.DataType = typeof(string);
        grdRadMov.Columns.Add(colContacto);
        GridBoundColumn colCorreo = new GridBoundColumn();
        colCorreo.HeaderText = MyTraductor.getTextDTID(143409, "Correo");
        colCorreo.DataField = "Codigos_por_Cliente_Correo";
        colCorreo.DataFormatString = "";
        colCorreo.SortExpression = "Codigos_por_Cliente.Correo";
        colCorreo.UniqueName = "Codigos_por_Cliente.Correo";
        colCorreo.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        colCorreo.DataType = typeof(string);
        grdRadMov.Columns.Add(colCorreo);

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
            Response.Redirect("Codigos_por_Cliente_Catalogo.aspx?MenuVisible=false");
        else
            Response.Redirect("Codigos_por_Cliente_Catalogo.aspx");
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
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de Códigos por Cliente&process="+idProceso.ToString()+"&brOperation=Export";
        rwExport.VisibleOnPageLoad = true;

        // Rebind with paging enabled
        grdMov.AllowPaging = true;
        Grid_Bind();*/        
        //----------------------------------- Exportación Completa ------------------------------------------------------
        WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();

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

        string sQ = myCodigos_por_Cliente.ListaGetFullQuery(swhere, new GridGenericSorter(sortExpression).GetOrder());
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

        WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();


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


                DataSet dat = myCodigos_por_Cliente.ListaSelAll(startRowIndex, maximumRows, swhere, new GridGenericSorter(sortExpression).GetOrder());

                data.Add("Data", JsonMethods.RowsToDictionary(dat.Tables[0]));
                data.Add("Count", myCodigos_por_Cliente.ListaSelCount(swhere));
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
                WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();

                TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
                WSCodigos_por_Cliente.GlobalData userData = new WSCodigos_por_Cliente.GlobalData();
                TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
                userData.AppToTempFiles = MyUserData.AppToTempFiles;
                userData.ComputerName = MyUserData.ComputerName;
                userData.DatabaseName = MyUserData.DatabaseName;
                userData.Folio = MyUserData.Folio;
                userData.Language = (WSCodigos_por_Cliente.GlobalDataLanguages)MyUserData.Language;
                userData.ServidorName = MyUserData.ServidorName;
                userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
                userData.UserID = MyUserData.UserID;
                userData.UserName = MyUserData.UserName;
                userData.WindowsVersion = MyUserData.WindowsVersion;
                myCodigos_por_Cliente.Delete(userData, MyFunctions.FormatNumberNull(Folio));
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
                    return new JsonResult("Codigos_por_Cliente_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                    return new JsonResult("Codigos_por_Cliente_Catalogo.aspx", true, null);
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
                    return new JsonResult("Codigos_por_Cliente_Catalogo.aspx?Fase=" + Fase, true, null);
                else
                    return new JsonResult("Codigos_por_Cliente_Catalogo.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }

        //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX.CS INICIO New() LINEA 1446 JZAMORA
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public static JsonResult New(bool MenuVisible, string Fase)
        {
            try
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("Select * from ttpermisos_por_proceso where idproceso=30071 and idoperacion=7");
                com.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count>0)
                {
                    WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();
                    WSCodigos_por_Cliente.GlobalData userData = new WSCodigos_por_Cliente.GlobalData();
                    TTSecurity.GlobalData  MyUserData=(TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"];
                    userData.AppToTempFiles = MyUserData.AppToTempFiles;
                    userData.ComputerName = MyUserData.ComputerName;
                    userData.DatabaseName = MyUserData.DatabaseName;
                    userData.Folio = MyUserData.Folio;
                    userData.Language = (WSCodigos_por_Cliente.GlobalDataLanguages)MyUserData.Language;
                    userData.ServidorName = MyUserData.ServidorName;
                    userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
                    userData.UserID = MyUserData.UserID;
                    userData.UserName = MyUserData.UserName;
                    userData.WindowsVersion = MyUserData.WindowsVersion;
                    HttpContext.Current.Session["Folio"] = Funcion.RegresaDato("insert into Codigos_por_Cliente(Usuario_que_Registra) values(null); select @@identity");
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
                        return new JsonResult("Codigos_por_Cliente_Catalogo.aspx?MenuVisible=false&Fase=" + Fase, true, null);
                    else
                        return new JsonResult("Codigos_por_Cliente_Catalogo.aspx?MenuVisible=false", true, null);
                }
                else
                {
                    if (Fase != null && Fase != string.Empty)
                        return new JsonResult("Codigos_por_Cliente_Catalogo.aspx?Fase=" + Fase, true, null);
                    else
                        return new JsonResult("Codigos_por_Cliente_Catalogo.aspx", true, null);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }
        //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX.CS FIN New() LINEA 1476 JZAMORA

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
                WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente myCodigos_por_Cliente = new WSCodigos_por_Cliente.objectBussinessCodigos_por_Cliente();

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

                DataTable dat = myCodigos_por_Cliente.ImpresionSelAll(swhere, new GridGenericSorter(sortExpression).GetOrder()).Tables[0];
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
                return new JsonResult("../FormsSystem/TTExportaRad.aspx?Titulo=Lista de Codigos_por_Cliente&PrintDialog=true&process=" + idProceso.ToString() + "&brOperation=Print", true, null);
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
                return new JsonResult("Codigos_por_Cliente_Lista.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());

            }

        }

        //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX.CS INICIO #region WorkFlows LINEA 1525 JZAMORA
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
        //TODO:WEBFORMS/Codigos_por_Cliente_LISTA.ASPX.CS FIN #region WorkFlows LINEA 1626 JZAMORA
    }

}
