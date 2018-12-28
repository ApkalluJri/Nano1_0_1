﻿/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Lista TTBitacoraSQL
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


public partial class TTBitacoraSQL_Lista : TTBasePage.TTBasePage
{
    public string sortExpression_;
    public string sortDirection_;
    private WSTTBitacoraSQL.objectBussinessTTBitacoraSQL myTTBitacoraSQL = new WSTTBitacoraSQL.objectBussinessTTBitacoraSQL();
    private TTBitacoraSQLCS.objectBussinessTTBitacoraSQL objTTBitacoraSQL = new TTBitacoraSQLCS.objectBussinessTTBitacoraSQL();
    private WSTTBitacoraSQL.GlobalData userData;
    private String sDNTNombre = "TTBitacoraSQL";
    private Int32 idProceso = 6402;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserGlobalInformation"] == null)
            Response.Redirect("~/FormsSystem/Default.aspx");
        
        if (!Page.IsPostBack)
        {
            FillGetData();
            Fill_Show();
        }
        //Funcion.SetSeguridadPorProcesos(Session["globalUsuarioClave"].ToString(), idProceso.ToString(), Page, grdMov);
        if (Request["MenuVisible"] == null)
            Page.ClientScript.RegisterStartupScript(typeof(Page), "CloseWindow", "<script language='javascript'>CloseWindow()</script>");
        rwExport.VisibleOnPageLoad = false;
        LoadFilterControl();
        
        Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
        lblTitulo.Text = "Lista de " + sDNTNombre.Replace("_", " ");
        lblTitulo.DataBind();
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
    
    override protected void OnInit(EventArgs e)
    {
        LoadSecurityPage();
        //-------------------------------------------------------------------------------------------------------------
        userData = new WSTTBitacoraSQL.GlobalData();
        userData.AppToTempFiles = MyUserData.AppToTempFiles;
        userData.ComputerName = MyUserData.ComputerName;
        userData.DatabaseName = MyUserData.DatabaseName;
        userData.Folio = MyUserData.Folio;
        userData.Language = (WSTTBitacoraSQL.GlobalDataLanguages)MyUserData.Language;
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
        string msg; ;
        msg = "Registros";
        cmbShow.Items.Add("10 " + msg);
        cmbShow.Items.Add("15 " + msg);
        cmbShow.Items.Add("25 " + msg);
        cmbShow.Items.Add("35 " + msg);
        cmbShow.Items.Add("50 " + msg);
        cmbShow.Items.Add("100 " + msg);
        cmbShow.Items.Add("500 " + msg);
        SeleccionaRegistros();
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
                        grdMov.PageSize = 2000;
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

                BoundField colFolio = new BoundField();
        colFolio.HeaderText = "Folio";
        colFolio.HtmlEncode = false;
        colFolio.DataField = "TTBitacoraSQL_Folio";
        colFolio.SortExpression = "TTBitacoraSQL_Folio";
        colFolio.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        grdMov.Columns.Add(colFolio);        BoundField colIdUsuario = new BoundField();
        colIdUsuario.HeaderText = "IdUsuario";
        colIdUsuario.DataField = "TTBitacoraSQL_IdUsuario";
        colIdUsuario.DataFormatString = "";
        colIdUsuario.SortExpression = "TTBitacoraSQL_IdUsuario";
        colIdUsuario.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colIdUsuario);
        //grdMov.Columns[6+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[6+1].ItemStyle.CssClass = "Hide";
        colIdUsuario.HeaderStyle.CssClass = "Hide";
        colIdUsuario.ItemStyle.CssClass = "Hide";
        BoundField colIdUsuario_Desc = new BoundField();
        colIdUsuario_Desc.HeaderText = "IdUsuario";
        colIdUsuario_Desc.DataField = "TTUsuarios_Nombre";
        colIdUsuario_Desc.SortExpression = "TTUsuarios_Nombre";
        colIdUsuario_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Justify;
        grdMov.Columns.Add(colIdUsuario_Desc);
        BoundField colTipoSQL = new BoundField();
        colTipoSQL.HeaderText = "TipoSQL";
        colTipoSQL.DataField = "TTBitacoraSQL_TipoSQL";
        colTipoSQL.DataFormatString = "";
        colTipoSQL.SortExpression = "TTBitacoraSQL_TipoSQL";
        colTipoSQL.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colTipoSQL);
        BoundField colFechaHora = new BoundField();
        colFechaHora.HeaderText = "FechaHora";
        colFechaHora.DataField = "TTBitacoraSQL_FechaHora";
        colFechaHora.DataFormatString = "";
        colFechaHora.SortExpression = "TTBitacoraSQL_FechaHora";
        colFechaHora.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colFechaHora);
        BoundField colComputerName = new BoundField();
        colComputerName.HeaderText = "ComputerName";
        colComputerName.DataField = "TTBitacoraSQL_ComputerName";
        colComputerName.DataFormatString = "";
        colComputerName.SortExpression = "TTBitacoraSQL_ComputerName";
        colComputerName.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colComputerName);
        BoundField colServerName = new BoundField();
        colServerName.HeaderText = "Nombre del servidor";
        colServerName.DataField = "TTBitacoraSQL_ServerName";
        colServerName.DataFormatString = "";
        colServerName.SortExpression = "TTBitacoraSQL_ServerName";
        colServerName.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colServerName);
        BoundField colDatabaseName = new BoundField();
        colDatabaseName.HeaderText = "Base de datos";
        colDatabaseName.DataField = "TTBitacoraSQL_DatabaseName";
        colDatabaseName.DataFormatString = "";
        colDatabaseName.SortExpression = "TTBitacoraSQL_DatabaseName";
        colDatabaseName.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colDatabaseName);
        BoundField colSystemName = new BoundField();
        colSystemName.HeaderText = "Nombre del sistema";
        colSystemName.DataField = "TTBitacoraSQL_SystemName";
        colSystemName.DataFormatString = "";
        colSystemName.SortExpression = "TTBitacoraSQL_SystemName";
        colSystemName.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colSystemName);
        BoundField colSystemVersion = new BoundField();
        colSystemVersion.HeaderText = "Version del sistema";
        colSystemVersion.HtmlEncode = false;
        colSystemVersion.DataField = "TTBitacoraSQL_SystemVersion";
        colSystemVersion.SortExpression = "TTBitacoraSQL_SystemVersion";
        colSystemVersion.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        grdMov.Columns.Add(colSystemVersion);        BoundField colWindowsVersion = new BoundField();
        colWindowsVersion.HeaderText = "Version de Windows";
        colWindowsVersion.DataField = "TTBitacoraSQL_WindowsVersion";
        colWindowsVersion.DataFormatString = "";
        colWindowsVersion.SortExpression = "TTBitacoraSQL_WindowsVersion";
        colWindowsVersion.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colWindowsVersion);
        BoundField colCommandSQL = new BoundField();
        colCommandSQL.HeaderText = "CommandSQL";
        colCommandSQL.DataField = "TTBitacoraSQL_CommandSQL";
        colCommandSQL.DataFormatString = "";
        colCommandSQL.SortExpression = "TTBitacoraSQL_CommandSQL";
        colCommandSQL.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colCommandSQL);
        BoundField colFolioSQL = new BoundField();
        colFolioSQL.HeaderText = "FolioSQL";
        colFolioSQL.DataField = "TTBitacoraSQL_FolioSQL";
        colFolioSQL.DataFormatString = "";
        colFolioSQL.SortExpression = "TTBitacoraSQL_FolioSQL";
        colFolioSQL.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colFolioSQL);
        BoundField colProcesoID = new BoundField();
        colProcesoID.HeaderText = "ProcesoID";
        colProcesoID.DataField = "TTBitacoraSQL_ProcesoID";
        colProcesoID.DataFormatString = "";
        colProcesoID.SortExpression = "TTBitacoraSQL_ProcesoID";
        colProcesoID.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
        grdMov.Columns.Add(colProcesoID);
        //grdMov.Columns[18+1].HeaderStyle.CssClass = "Hide";
        //grdMov.Columns[18+1].ItemStyle.CssClass = "Hide";
        colProcesoID.HeaderStyle.CssClass = "Hide";
        colProcesoID.ItemStyle.CssClass = "Hide";
        BoundField colProcesoID_Desc = new BoundField();
        colProcesoID_Desc.HeaderText = "ProcesoID";
        colProcesoID_Desc.DataField = "TTProceso_Nombre";
        colProcesoID_Desc.SortExpression = "TTProceso_Nombre";
        colProcesoID_Desc.ItemStyle.HorizontalAlign = HorizontalAlign.Justify;
        grdMov.Columns.Add(colProcesoID_Desc);

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
        Session["Folio"]=data.Values["TTBitacoraSQL_Folio"];

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
        Session["ClaveLista"]=data.Values["TTBitacoraSQL_Folio"];


        grdMov.PageIndex = 0;
        Grid_Bind();

        Response.Redirect("TTBitacoraSQL_Lista.aspx");
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
                Session["Folio"]=data.Values["TTBitacoraSQL_Folio"];

                //---------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Delete, TTenumBusinessRules_ProcessEvent.BeforeSave, idProceso);
                //---------------------------------------------------------------------------------------------------------------
                try
                {
                    myTTBitacoraSQL.Delete(userData, MyFunctions.FormatNumberNull(Session["Folio"].ToString()));
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
            Session["Folio"]=data.Values["TTBitacoraSQL_Folio"];

            Session["Tipo_Transaccion"] = "Consult";
            Response.Redirect("TTBitacoraSQL_Catalogo.aspx");     
        }

        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataKey data = grdMov.DataKeys[rowIndex];
            Session["Folio"]=data.Values["TTBitacoraSQL_Folio"];

            Session["Tipo_Transaccion"] = "Update";
            Response.Redirect("TTBitacoraSQL_Catalogo.aspx");
        }

        if (e.CommandName == "Delete")
        {
        }
        if (e.CommandName == "Print")
        { 
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataKey data = grdMov.DataKeys[rowIndex];
            Session["Llave"]=data.Values["TTBitacoraSQL_Folio"];

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
            myTTBitacoraSQL.Delete(userData, MyFunctions.FormatNumberNull(Session["Folio"].ToString()));
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
        Session["Folio"]="";

        Session["Tipo_Transaccion"] = "New";
        
        if (Request["MenuVisible"] != null)
            Response.Redirect("TTBitacoraSQL_Catalogo.aspx?MenuVisible=false");
        else
            Response.Redirect("TTBitacoraSQL_Catalogo.aspx");
    }
    
    protected void cmdSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FormsSystem/TTBusquedaAvanzada.aspx?idProceso=" + idProceso.ToString());
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
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de TTBitacoraSQL&process="+idProceso.ToString()+"&brOperation=Export";
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
        rwExport.NavigateUrl = "../FormsSystem/TTExporta.aspx?Titulo=Lista de TTBitacoraSQL&PrintDialog=true&process=" + idProceso.ToString() + "&brOperation=Print";
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
                objTTBitacoraSQL.MyFilters = new ControlsLibrary.objectBussinessTTFiltro[1];
                objTTBitacoraSQL.MyFilters[0] = myFilter;
            }
            else
                Session["Filter"] = null;
        }
        if (Session["Where"] != null && Session["NombreDNT"] != null)
            if (Session["NombreDNT"].ToString() == sDNTNombre)
                objTTBitacoraSQL.sWhere = Session["Where"].ToString();                 
    }
    
    protected void ODSGrdMov_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        Bind();

        e.ObjectInstance = objTTBitacoraSQL;
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

                this.lblTotalRecords.Text = "Registros:<b>" + count.ToString() + "</b> / Del <b>" + start.ToString() + "</b> al <b>" + end.ToString() +"</b>";
            }
        }
        //else if ((e.ReturnValue.GetType() == typeof(DataSet))) 
        //{
        //}
        ViewState["FullQueryExport"] = objTTBitacoraSQL.FullQueryForExport;
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







