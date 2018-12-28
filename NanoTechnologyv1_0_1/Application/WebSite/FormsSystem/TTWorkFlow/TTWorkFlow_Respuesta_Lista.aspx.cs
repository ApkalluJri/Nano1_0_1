/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Lista TTWorkFlow_Respuesta
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
public partial class TTWorkFlow_Respuesta_Lista : TTBasePage.TTBasePage
{
    public string sortExpression_;
    public string sortDirection_;
    private WSTTWorkFlow_Respuesta.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new WSTTWorkFlow_Respuesta.objectBussinessTTWorkFlow_Respuesta();
    private TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta objTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
    private WSTTWorkFlow_Respuesta.GlobalData userData;
    const String sDNTNombre = "TTWorkFlow_Respuesta";
    const String sDNTDescripcion = "TTWorkFlow Respuesta";
    const Int32 idProceso = 15811;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
        
        if (!Page.IsPostBack)
        {
            FillGetData();
            SetLanguage();
        }
        Funcion.SetSeguridadPorProcesos(Session["globalUsuarioClave"].ToString(), idProceso.ToString(), Page, grdRadMov);
        if (Request["MenuVisible"] == null)
            Page.ClientScript.RegisterStartupScript(typeof(Page), "CloseWindow", "<script language='javascript'>CloseWindow()</script>");
        LoadFilterControl();
                 
        SetSelectColumnVisible();
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
        userData = new WSTTWorkFlow_Respuesta.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTWorkFlow_Respuesta.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        base.OnInit(e);
    }
    
    // Llenar el Grid
    private void FillGetData()
    {
        CreateColumns(); this.cmdViews.Visible = false; this.cmdHelp.Visible = false;
       if (HttpContext.Current.Session["GridState"] != null)
        {
            GridState oGridSate = (GridState)HttpContext.Current.Session["GridState"];
            if (oGridSate.idProceso == idProceso)
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
        im02.CommandName = "Delete";        
        
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
        im1.ImageUrl = "~/images/look.png";
        im1.CommandName = "Consult";

        GridButtonColumn im2 = new GridButtonColumn();
        im2.ButtonType = GridButtonColumnType.ImageButton;
        im2.ImageUrl = "~/images/edit.png";
        im2.CommandName = "Edit";

        GridButtonColumn im4 = new GridButtonColumn();
        im4.ButtonType = GridButtonColumnType.ImageButton;
        im4.ImageUrl = "~/images/print.png";
        im4.CommandName = "Print";

        grdRadMov.MasterTableView.Columns.Add(im1);
        grdRadMov.MasterTableView.Columns.Add(im2);
        grdRadMov.MasterTableView.Columns.Add(im4);

                GridBoundColumn colClave = new GridBoundColumn();
        colClave.HeaderText = MyTraductor.getTextDTID(35884, "Clave");
        colClave.HtmlEncode = false;
        colClave.DataField = "TTWorkFlow_Respuesta_Clave";
        colClave.SortExpression = "TTWorkFlow_Respuesta.Clave";
	colClave.UniqueName = "TTWorkFlow_Respuesta.Clave";
        colClave.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        grdRadMov.MasterTableView.Columns.Add(colClave);        GridBoundColumn colDescripcion = new GridBoundColumn();
        colDescripcion.HeaderText = MyTraductor.getTextDTID(35885, "Descripción");
        colDescripcion.DataField = "TTWorkFlow_Respuesta_Descripcion";
        colDescripcion.DataFormatString = "";
        colDescripcion.SortExpression = "TTWorkFlow_Respuesta.Descripcion";
        colDescripcion.UniqueName = "TTWorkFlow_Respuesta.Descripcion";
        colDescripcion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdRadMov.Columns.Add(colDescripcion);
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
        Session["Clave"]="";

        Session["Tipo_Transaccion"] = "New";
        
        if (Request["MenuVisible"] != null)
            Response.Redirect("TTWorkFlow_Respuesta_Catalogo.aspx?MenuVisible=false");
        else
            Response.Redirect("TTWorkFlow_Respuesta_Catalogo.aspx");
    }
    
    protected void cmdSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("TTBusquedaAvanzada.aspx?idProceso=" + idProceso.ToString());
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
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de TTWorkFlow Respuesta&process="+idProceso.ToString()+"&brOperation=Export";
        rwExport.VisibleOnPageLoad = true;

        // Rebind with paging enabled
        grdMov.AllowPaging = true;
        Grid_Bind();*/        
        //----------------------------------- Exportación Completa ------------------------------------------------------
        	TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
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
        string sQ = myTTWorkFlow_Respuesta.GetFullQuery(swhere, new GridGenericSorter(sortExpression).GetOrder());
        string sPath = HttpContext.Current.Server.MapPath("~\\App_Data");
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
    public static Dictionary<string, object> GetDataAndCount(int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression,bool saveState)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        try
        {
            if (saveState)
            {
                var oGridSate = (GridState)HttpContext.Current.Session["GridState"];
                if (oGridSate != null)
                {
                    if (oGridSate.idProceso == idProceso)
                    {
                        sortExpression.AddRange(oGridSate.sortExpression.Where(x => !sortExpression.Select(y => y.FieldName).Contains(x.FieldName)));
                        filterExpression.AddRange(oGridSate.filterExpression.Where(x => !filterExpression.Select(y => y.FieldName).Contains(x.FieldName)));
                        HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso,"");
                    }
                    else
                    {
                        HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso,"");
                    }
                }
                else
                {
                    HttpContext.Current.Session["GridState"] = new GridState(startRowIndex, maximumRows, sortExpression, filterExpression, idProceso,"");
                }
            }
            TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
            
            string swhere = new GridGenericFilterer(filterExpression).GetWhere();
            if (HttpContext.Current.Session["Where"] != null && HttpContext.Current.Session["NombreDNT"] != null && HttpContext.Current.Session["Where"].ToString() != "")
                if (HttpContext.Current.Session["NombreDNT"].ToString() == sDNTNombre)
                    swhere += (swhere == "" ? " WHERE " : " AND ") + HttpContext.Current.Session["Where"].ToString();
                else
                {
                    HttpContext.Current.Session.Remove("NombreDNT");
                    HttpContext.Current.Session.Remove("Where");
                }
            DataSet dat = myTTWorkFlow_Respuesta.SelAll(startRowIndex, maximumRows, swhere, new GridGenericSorter(sortExpression).GetOrder());

            data.Add("Data", JsonMethods.RowsToDictionary(dat.Tables[0]));
            data.Add("Count", myTTWorkFlow_Respuesta.SelCount(swhere));
            
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
    public static Dictionary<string, object> GetAllDataAndCount(int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression)
    {
        HttpContext.Current.Session.Remove("NombreDNT");
        HttpContext.Current.Session.Remove("Where");
        return GetDataAndCount(startRowIndex, maximumRows, sortExpression, filterExpression,true);
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public static JsonResult Delete_Row(string Folio,int startRowIndex, int maximumRows, List<GridSortExpression> sortExpression, List<GridFilterExpression> filterExpression)
    {
        try
        {
            ////------------------------------------------------------------------------------------------------------------------------------------
            //if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso))
            //    return;
            ////------------------------------------------------------------------------------------------------------------------------------------
            TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();
            TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
            TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
            myTTWorkFlow_Respuesta.Delete(MyFunctions.FormatNumberNull(Folio),HttpContext.Current.Session["UserGlobalInformation"] as TTSecurity.GlobalData, dr);
            Dictionary<string, object> data =  GetDataAndCount(startRowIndex, maximumRows, sortExpression, filterExpression,true);
            ////------------------------------------------------------------------------------------------------------------------------------------
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
            ////------------------------------------------------------------------------------------------------------------------------------------        
            return new JsonResult(data, true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
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
            //DataTable Tformatos = TTFormatosCS.objectBussinessTTFormatos.getFormatos(int.Parse(HttpContext.Current.Session["globalTipoUsuario"].ToString()), idProceso);
            //if(Tformatos.Rows.Count > 0)
            //    return new JsonResult("Impresion_Formatos.aspx?idProceso=" + idProceso.ToString() + "&IDM=" + Folio, true, null);
            //else
                return new JsonResult("Reporte_por_Renglon.aspx?idProceso=" + idProceso.ToString(), true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public static JsonResult Consult(string Folio)
    {
        try
        {
            HttpContext.Current.Session["Clave"] = Folio;
            HttpContext.Current.Session["Tipo_Transaccion"] = "Consult";
            return new JsonResult("TTWorkFlow_Respuesta_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public static JsonResult Edit(string Folio)
    {
        try
        {
            HttpContext.Current.Session["Clave"] = Folio;
            HttpContext.Current.Session["Tipo_Transaccion"] = "Update";
            return new JsonResult("TTWorkFlow_Respuesta_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public static JsonResult New(bool MenuVisible)
    {
        try
        {
            HttpContext.Current.Session["Clave"] = "";
            HttpContext.Current.Session["Tipo_Transaccion"] = "New";
            if (MenuVisible)
                return new JsonResult("TTWorkFlow_Respuesta_Catalogo.aspx?MenuVisible=false", true, null);
            else
                return new JsonResult("TTWorkFlow_Respuesta_Catalogo.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }

    }

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
            TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta myTTWorkFlow_Respuesta = new TTWorkFlow_RespuestaCS.objectBussinessTTWorkFlow_Respuesta();

            string swhere = new GridGenericFilterer(filterExpression).GetWhere();
            DataTable dat = myTTWorkFlow_Respuesta.SelAll( swhere, new GridGenericSorter(sortExpression).GetOrder()).Tables[0];
            Again:
            foreach(DataColumn column in dat.Columns)
            {
                bool found = false;
                foreach(string columnName in Columns)
                {
                    if(columnName == column.ColumnName)
                    {
                        found =true;
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
            return new JsonResult("../FormsSystem/TTExportaRad.aspx?Titulo=Lista de TTWorkFlow_Respuesta&PrintDialog=true&process=" + idProceso.ToString() + "&brOperation=Print", true, null);
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
            return new JsonResult("TTWorkFlow_Respuesta_Lista.aspx", true, null);
        }
        catch (Exception ex)
        {
            return new JsonResult(null, false, ex.Message.ToString());
        }

    }
}
}







