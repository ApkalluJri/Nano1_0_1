/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Lista TTGrupo_de_Usuario
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
using App_Code.TTBusinessRules;
using TTBasePage;


public partial class TTGrupo_de_Usuario_Lista : TTBasePage.TTBasePage
{
    public string sortExpression_;
    public string sortDirection_;
    private WSTTGrupo_de_Usuario.objectBussinessTTGrupo_de_Usuario myTTGrupo_de_Usuario = new WSTTGrupo_de_Usuario.objectBussinessTTGrupo_de_Usuario();
    private TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario objTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
    private WSTTGrupo_de_Usuario.GlobalData userData;
    private String sDNTNombre = "TTGrupo_de_Usuario";
    private Int32 idProceso = 6394;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
        
        if (!Page.IsPostBack)
        {
            FillGetData();
            Fill_Show();
            SetLanguage();
        }
        //Funcion.SetSeguridadPorProcesos(Session["globalUsuarioClave"].ToString(), idProceso.ToString(), Page, grdMov);
        if (Request["MenuVisible"] == null)
            Page.ClientScript.RegisterStartupScript(typeof(Page), "CloseWindow", "<script language='javascript'>CloseWindow()</script>");
        rwExport.VisibleOnPageLoad = false;
        LoadFilterControl();
                 
        SetSelectColumnVisible();
    }
    
    private void SetSelectColumnVisible() 
    {
        if (Request["MenuVisible"] != null)
        {
            grdMov.Columns[0].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[0].ItemStyle.CssClass = "Hide";
            grdMov.Columns[0].Visible = false;

            grdMov.Columns[1].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[1].ItemStyle.CssClass = "Hide";
            grdMov.Columns[1].Visible = false;

            grdMov.Columns[3].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[3].ItemStyle.CssClass = "Hide";
            grdMov.Columns[3].Visible = false;

            grdMov.Columns[4].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[4].ItemStyle.CssClass = "Hide";
            grdMov.Columns[4].Visible = false;

            grdMov.Columns[5].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[5].ItemStyle.CssClass = "Hide";
            grdMov.Columns[5].Visible = false;
        }
    }
    
    private void SetLanguage() 
    {
        try
        {
            string sTitle = string.Format(MyTraductor.getMessage(4, this.Title), MyTraductor.getTextProcess(idProceso, MyFunctions.GenerateName(sDNTNombre)));
            this.Title = sTitle;
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = sTitle;
            lblshow.Text = MyTraductor.getMessage(5, lblshow.Text);
            lblDeleteMessage.Text = MyTraductor.getMessage(7, lblDeleteMessage.Text);

            lblNuevo.Text = MyTraductor.getMessage(8, lblNuevo.Text);
            lblTodos.Text = MyTraductor.getMessage(9, lblTodos.Text);
            lblBuscar.Text = MyTraductor.getMessage(10, lblBuscar.Text);
            lblExportar.Text = MyTraductor.getMessage(11, lblExportar.Text);
            lblImprimir.Text = MyTraductor.getMessage(12, lblImprimir.Text);
            lblFiltrar.Text = MyTraductor.getMessage(13, lblFiltrar.Text);
            lblConfigurar.Text = MyTraductor.getMessage(14, lblConfigurar.Text);
            
            (Funcion.FindControlRecursive(Page, "btnFilter") as ImageButton).ToolTip = MyTraductor.getMessage(24, lblConfigurar.Text);
            (Funcion.FindControlRecursive(Page, "btnClearFilter") as ImageButton).ToolTip = MyTraductor.getMessage(25, lblConfigurar.Text);
        }
        catch 
        { }

    }
    
    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSTTGrupo_de_Usuario.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTGrupo_de_Usuario.GlobalDataLanguages)MyUserData.Language;
        userData.ServidorName = MyUserData.ServidorName;
        userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
        userData.UserID = MyUserData.UserID;
        userData.UserName = MyUserData.UserName;
        userData.WindowsVersion = MyUserData.WindowsVersion;
        //-------------------------------------------------------------------------------------------------------------
        TTPageSlide.GrdMov = grdMov;
        base.OnInit(e);
    }
    
    // Llenar el Grid
    private void FillGetData()
    {
        ReSize();
        CreateColumns(); this.cmdViews.Visible = false; this.cmdHelp.Visible = false;
        //this.cmdExtraService2.Visible = false; this.cmdViews2.Visible = false; this.cmdHelp2.Visible = false;
        Grid_Bind();
    }

    //Llenar dropdownList
    private void Fill_Show()
    {
        try
        {
            string msg = MyTraductor.getMessage(6, "Mostrar");            
            cmbShow.Items.Add(string.Format(msg, 10)); 
            cmbShow.Items.Add(string.Format(msg, 15)); 
            cmbShow.Items.Add(string.Format(msg, 25)); 
            cmbShow.Items.Add(string.Format(msg, 35)); 
            cmbShow.Items.Add(string.Format(msg, 50)); 
            cmbShow.Items.Add(string.Format(msg, 100));
            cmbShow.Items.Add(string.Format(msg, 500)); 
        }
        catch
        {
            string msg; ;
            msg = "Registros";
            cmbShow.Items.Add("10 " + msg);
            cmbShow.Items.Add("15 " + msg);
            cmbShow.Items.Add("25 " + msg);
            cmbShow.Items.Add("35 " + msg);
            cmbShow.Items.Add("50 " + msg);
            cmbShow.Items.Add("100 " + msg);
            cmbShow.Items.Add("500 " + msg);
            
        }
        finally 
        {
            SeleccionaRegistros();
        }
    }

    protected void SeleccionaRegistros()
    {
        if (Session[idProceso.ToString() + "_Registros"] != null)
        {
            cmbShow.SelectedIndex = Int32.Parse(Session[idProceso.ToString() + "_Registros"].ToString());
        }
        else
        {
            cmbShow.SelectedIndex = 1;
        }
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
    protected void grdMov_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMov.PageIndex = e.NewPageIndex;
        Pagination(e.NewPageIndex);
    }

    protected void Pagination(int indice)
    {        
    }

    //Ordenamiento
    protected void grdMov_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortDirection"] = e.SortDirection.ToString();
        ViewState["SortExpression"] = e.SortExpression.ToString();
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
    }

    private void ReSize()
    {
        if (cmbShow.SelectedIndex != -1)
        {
            switch (cmbShow.SelectedIndex)
            {
                case 0:
                    {
                        grdMov.PageSize = 10;
                        break;
                    }
                case 1:
                    {
                        grdMov.PageSize = 15;
                        break;
                    }
                case 2:
                    {
                        grdMov.PageSize = 25;
                        break;
                    }
                case 3:
                    {
                        grdMov.PageSize = 35;
                        break;
                    }
                case 4:
                    {
                        grdMov.PageSize = 50;
                        break;
                    }
                case 5:
                    {
                        grdMov.PageSize = 100;
                        break;
                    }
                case 6:
                    {
                        grdMov.PageSize = 500;
                        break;
                    }
            }
        }
        else
        {
            grdMov.PageSize = ObtenPageSize();
        }
    }
    private void CreateColumns()
    { 
        grdMov.AllowPaging = true;
        grdMov.AllowSorting = true;  
        //----------------------------------        
        if (Request["MenuVisible"] == null)
        {
            grdMov.Columns[2].HeaderStyle.CssClass = "Hide";
            grdMov.Columns[2].ItemStyle.CssClass = "Hide";
            grdMov.Columns[2].Visible = false;
        }
        //-----------------------------------  
        ButtonField im1 = new ButtonField();
        im1.ButtonType = ButtonType.Image;
        im1.ImageUrl = "~/images/look.png";
        im1.CommandName = "Consult";

        ButtonField im2 = new ButtonField();
        im2.ButtonType = ButtonType.Image;
        im2.ImageUrl = "~/images/edit.png";
        im2.CommandName = "Edit";
       
        ButtonField im4 = new ButtonField();
        im4.ButtonType = ButtonType.Image;
        im4.ImageUrl = "~/images/print.png";
        im4.CommandName = "Print";

        grdMov.Columns.Add(im1);
        grdMov.Columns.Add(im2);
        grdMov.Columns.Add(im4);

                BoundField colIdGrupoUsuario = new BoundField();
        colIdGrupoUsuario.HeaderText = MyTraductor.getTextDTID(13084, "Clave");
        colIdGrupoUsuario.HtmlEncode = false;
        colIdGrupoUsuario.DataField = "TTGrupo_de_Usuario_IdGrupoUsuario";
        colIdGrupoUsuario.SortExpression = "TTGrupo_de_Usuario_IdGrupoUsuario";
        colIdGrupoUsuario.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        grdMov.Columns.Add(colIdGrupoUsuario);        BoundField colDescripcion = new BoundField();
        colDescripcion.HeaderText = MyTraductor.getTextDTID(13085, "Descripcion");
        colDescripcion.DataField = "TTGrupo_de_Usuario_Descripcion";
        colDescripcion.DataFormatString = "";
        colDescripcion.SortExpression = "TTGrupo_de_Usuario_Descripcion";
        colDescripcion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colDescripcion);
        BoundField colActivo = new BoundField();
        colActivo.HeaderText = MyTraductor.getTextDTID(13086, "Activo");
        colActivo.DataField = "TTGrupo_de_Usuario_Activo";
        colActivo.DataFormatString = "";
        colActivo.SortExpression = "TTGrupo_de_Usuario_Activo";
        colActivo.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colActivo);

    }

    private void Grid_Bind()
    {
        grdMov.DataBind();       
    }


    protected void cmbShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session[idProceso.ToString() + "_Registros"] = cmbShow.SelectedIndex.ToString();
        grdMov.PageIndex = 0;
        Session["PAGENUM"] = 0;
        ReSize();
        Grid_Bind();
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
     }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //  get the gridviewrow from the sender so we can get the datakey we need
        ImageButton btnDelete = sender as ImageButton;
        GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
        DataKey data = grdMov.DataKeys[row.RowIndex];
        Session["IdGrupoUsuario"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];

        Delete_Row();  
        
        grdMov.PageIndex = 0;
        Grid_Bind(); 
        
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();      
    }

    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        ImageButton btnSelect = sender as ImageButton;
        GridViewRow row = (GridViewRow)btnSelect.NamingContainer;
        DataKey data = grdMov.DataKeys[row.RowIndex];
        Session["ClaveLista"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];


        grdMov.PageIndex = 0;
        Grid_Bind();

        Response.Redirect("TTGrupo_de_Usuario_Lista.aspx");
    }

    protected void IbtnBorrarSeleccion_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdMov.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("chkSelect");
            if (cb != null && cb.Checked)
            {
                DataKey data = grdMov.DataKeys[row.RowIndex];
                Session["IdGrupoUsuario"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];

                //---------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
                //---------------------------------------------------------------------------------------------------------------
                try
                {
                    myTTGrupo_de_Usuario.Delete(userData, MyFunctions.FormatNumberNull(Session["IdGrupoUsuario"].ToString()));
                }
                catch (Exception ex) 
                {
                    ShowAlert(ex.Message.ToString());
                }
                //---------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
                //---------------------------------------------------------------------------------------------------------------
            }
        }
        //independiente de la ordenacion y del tamaño de page        
        grdMov.PageIndex = 0;
        Grid_Bind(); 
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
    }   
    protected void GrdMov_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
             
        if (e.CommandName=="Consult")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataKey data = grdMov.DataKeys[rowIndex];
            Session["IdGrupoUsuario"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];

            Session["Tipo_Transaccion"] = "Consult";
            Response.Redirect("TTGrupo_de_Usuario_Catalogo.aspx");     
        }

        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataKey data = grdMov.DataKeys[rowIndex];
            Session["IdGrupoUsuario"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];

            Session["Tipo_Transaccion"] = "Update";
            Response.Redirect("TTGrupo_de_Usuario_Catalogo.aspx");
        }

        if (e.CommandName == "Delete")
        {
        }
        if (e.CommandName == "Print")
        { 
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataKey data = grdMov.DataKeys[rowIndex];
            Session["Llave"]=data.Values["TTGrupo_de_Usuario_IdGrupoUsuario"];

            //---------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
            //---------------------------------------------------------------------------------------------------------------
            rwExport.NavigateUrl = "Reporte_por_Renglon.aspx?idProceso=" + idProceso.ToString();
            rwExport.VisibleOnPageLoad = true;
            //---------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
            //---------------------------------------------------------------------------------------------------------------           
        }
    }

    protected void Delete_Row()
    {
        //------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
        //------------------------------------------------------------------------------------------------------------------------------------
        try
        {
            myTTGrupo_de_Usuario.Delete(userData, MyFunctions.FormatNumberNull(Session["IdGrupoUsuario"].ToString()));
        }
        catch (Exception ex)
        {
            ShowAlert(ex.Message.ToString());
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
        //------------------------------------------------------------------------------------------------------------------------------------        
    }

    protected void grdMov_OnRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ViewState["SortDirection"] != null && ViewState["SortExpression"] != null)
            {
                int columna;
                foreach (DataControlField field in grdMov.Columns)
                {
                    Image sortImage = new Image();

                    sortDirection_ = ViewState["SortDirection"].ToString();
                    sortExpression_ = ViewState["SortExpression"].ToString();

                    if (sortDirection_ == "Ascending")
                        sortImage.ImageUrl = "~/images/sortascending.gif";
                    else
                        sortImage.ImageUrl = "~/images/sortdescending.gif";

                    if (field.SortExpression == sortExpression_)
                    {
                        columna = grdMov.Columns.IndexOf(field);
                        e.Row.Cells[columna].Controls.Add(sortImage);
                        break;
                    }
                }
            }
        }
    }

    protected void GrdMov_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void cmdAll_Click(object sender, ImageClickEventArgs e)
    {
        Session["Filter"] = null;
        Session["Where"] = null;
        Session["NombreDNT"] = null;
        Grid_Bind();
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
    }
    protected void cmdNew_Click(object sender, ImageClickEventArgs e)
    {
        Session["IdGrupoUsuario"]="";

        Session["Tipo_Transaccion"] = "New";
        
        if (Request["MenuVisible"] != null)
            Response.Redirect("TTGrupo_de_Usuario_Catalogo.aspx?MenuVisible=false");
        else
            Response.Redirect("TTGrupo_de_Usuario_Catalogo.aspx");
    }
    
    protected void cmdSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("TTBusquedaAvanzada.aspx?idProceso=" + idProceso.ToString());
    }
    
    protected void cmdExport_Click(object sender, ImageClickEventArgs e)
    {
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
        //---------------------------------------------------------------------------------------------------------------        
        //----------------------------------- Exportación de una sola página --------------------------------------------
        /*GridView grid = new GridView();
        // Disable paging
        grdMov.AllowPaging = false;
        Grid_Bind();
        grid = grdMov;

        Session["dsGrid"] = grid;
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de TTGrupo de Usuario&process="+idProceso.ToString()+"&brOperation=Export";
        rwExport.VisibleOnPageLoad = true;

        // Rebind with paging enabled
        grdMov.AllowPaging = true;
        Grid_Bind();*/        
        //----------------------------------- Exportación Completa ------------------------------------------------------
        string sQ = ViewState["FullQueryExport"].ToString();
        string sPath = HttpContext.Current.Server.MapPath("..\\..\\App_Data");
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
        Response.Redirect("TTConfiguracion.aspx?idProceso=" + idProceso.ToString());
    }
    
    protected void cmdPrint_Click(object sender, ImageClickEventArgs e)
    {
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
        //---------------------------------------------------------------------------------------------------------------        
        GridView grid = new GridView();
        // Disable paging
        grdMov.AllowPaging = false;
        Grid_Bind();
        grid = grdMov;

        Session["dsGrid"] = grid;
        rwExport.NavigateUrl = "../TTExporta.aspx?Titulo=Lista de TTGrupo de Usuario&PrintDialog=true&process=" + idProceso.ToString() + "&brOperation=Print";
        rwExport.VisibleOnPageLoad = true;

        // Rebind with paging enabled
        grdMov.AllowPaging = true;
        Grid_Bind();
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterSave, idProceso);
        //---------------------------------------------------------------------------------------------------------------           
    }
       
    protected void cmdFilters_Click(object sender, EventArgs e)
    {
        rpbFiltros.Items[0].Expanded = !rpbFiltros.Items[0].Expanded;        
    }
    
    public void Bind()
    {
        myFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];
        if (Session["Filter"] != null)
        {
            if (idProceso == myFilter.ProcesoID)
            {
                objTTGrupo_de_Usuario.MyFilters = new ControlsLibrary.objectBussinessTTFiltro[1];
                objTTGrupo_de_Usuario.MyFilters[0] = myFilter;
            }
            else
                Session["Filter"] = null;
        }
        if (Session["Where"] != null && Session["NombreDNT"] != null)
            if (Session["NombreDNT"].ToString() == sDNTNombre)
                objTTGrupo_de_Usuario.sWhere = Session["Where"].ToString();                 
    }
    
    protected void ODSGrdMov_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        Bind();

        e.ObjectInstance = objTTGrupo_de_Usuario;
    }
    
    protected void ODSGrdMov_OnSelected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            ShowAlert(e.Exception.InnerException.ToString());
            e.ExceptionHandled = true;
            return;
        }
        if (e.ReturnValue.GetType() == typeof(Int32))
        {
            int count;
            if (int.TryParse(e.ReturnValue.ToString(), out count))
            {
                int start = grdMov.PageIndex * grdMov.PageSize + 1;
                int end = grdMov.PageIndex * grdMov.PageSize + grdMov.PageSize;

                try 
                {
                    string sTotalRecords = MyTraductor.getMessage(49, "Registros:<b>{0}</b> / Del <b>{1}</b> al <b>{2}</b>");
                    this.lblTotalRecords.Text = string.Format(sTotalRecords, count.ToString(), start.ToString(), end.ToString());
                }
                catch { }  
            }
        }
        //else if ((e.ReturnValue.GetType() == typeof(DataSet))) 
        //{
        //}
        ViewState["FullQueryExport"] = objTTGrupo_de_Usuario.FullQueryForExport;
    }
    
    protected void LoadFilterControl()
    {
        FormsSystem_TTQuickFilterControl TTSearchControl1 = (FormsSystem_TTQuickFilterControl)Funcion.FindControlRecursive(Page, "TTSearchControl1");

        if (Session["Filter"] == null)
        {
            TTSearchControl1.MyFilter = new ControlsLibrary.objectBussinessTTFiltro();
            TTSearchControl1.MyFilter.GlobalInformation = myUserData;
        }
        else
            TTSearchControl1.MyFilter = (ControlsLibrary.objectBussinessTTFiltro)Session["Filter"];

        TTSearchControl1.EntryType = ControlsLibrary.objectBussinessTTFiltro.TTFiltersAdvancedEntryType.QuickFilter;

        TTSearchControl1.IsQuestionable = false;
        TTSearchControl1.ModoConsulta = true;
        TTSearchControl1.IsDetail = false;
        TTSearchControl1.New(idProceso);
    }
    
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        FormsSystem_TTQuickFilterControl TTSearchControl1 = (FormsSystem_TTQuickFilterControl)Funcion.FindControlRecursive(Page, "TTSearchControl1");
        TTSearchControl1.SaveChanges();

        Session.Remove("Filter" + idProceso.ToString());
        Session["Filter"] = TTSearchControl1.MyFilter;

        rpbFiltros.Items[0].Expanded = false;
        grdMov.PageIndex = 0;
        Grid_Bind();
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
    }
    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        Session["Filter"] = null;
        LoadFilterControl();

        FormsSystem_TTQuickFilterControl TTSearchControl1 = (FormsSystem_TTQuickFilterControl)Funcion.FindControlRecursive(Page, "TTSearchControl1");
        TTSearchControl1.ShowQuickControls(idProceso, myUserData);

        rpbFiltros.Items[0].Expanded = false;
        grdMov.PageIndex = 0;

        Grid_Bind();
        FormsSystem_TTPageSlider pageslide = (FormsSystem_TTPageSlider)Funcion.FindControlRecursive(Page, "TTPageSlide");
        pageslide.sliderFilter();
    }
}







