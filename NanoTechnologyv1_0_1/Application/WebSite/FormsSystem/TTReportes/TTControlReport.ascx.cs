using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Reporting.Drawing;
using Telerik.Reporting.Charting;

public partial class TTControlReports : System.Web.UI.UserControl
{
    private enum TTControlReportsTypeReport
    {
        None = 0,
        Bar = 1,
        BarCross = 2,
        Pie = 3,
        Details = 4,
        DetailsCross = 5

    }
    public delegate void Explande_ChangedHandler(object sender, EventArgs e);
    //[Category("Action")]
    //[Description("Change Explande.")]
    public event Explande_ChangedHandler Explande_Changed;
    private TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
    private TTReportFunctions reportFunctions = new TTReportFunctions();

    private TTSecurity.GlobalData MyUserData
    {
        get { return Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
    }

    private TTReportes.objectBussinessTTReportes objRep
    {
        get
        {
            return (System.Web.HttpContext.Current.Session["objRep"] != null) ?
                System.Web.HttpContext.Current.Session["objRep"] as TTReportes.objectBussinessTTReportes :
                new TTReportes.objectBussinessTTReportes();
        }
    }

    protected virtual void OnExplande_Changed()
    {
        if (Explande_Changed != null)
            Explande_Changed(this, new EventArgs());  // Notify Subscribers
    }
    private TTControlReportsTypeReport TypeReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSkinList();
        }
    }

    private Boolean imExpanded = false;
    public Boolean Expanded
    {
        get { return imExpanded; }
        set { imExpanded = value; }
    }

    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private int idReport;
    private DataTable gdtQueryBar;
    private TTReportes.objectBussinessTTReportes gObjRep;
    public int IdReport
    {
        get { return idReport; }
    }
    private ArrayList myAlarmsMsj;

    private void TTControlReport_Load(object sender, EventArgs e)
    {
    }

    private void PrepareScreenOptionButtons()
    {
        if (objRep.FiltroId != null)
            if (objRep.FiltroId.Filtro_Detalle != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro_Detalle objDet in objRep.FiltroId.Filtro_Detalle)
                {
                    if (objDet.Question)
                    {
                        break;
                    }
                }
    }
    private delegate void DelegateShowReport(int IdReport, TTSecurity.GlobalData MyUserData);
    public void CallShowReport(int IdReport)
    {
        ShowReport(IdReport);
        String sQ = reportFunctions.Query(IdReport);
        txtQuery.Text = sQ;
    }

    private void ShowReport(int IdReport)
    {
        idReport = IdReport;
        LoadReport();
        PrepareScreenOptionButtons();
    }
    private void LoadReport()
    {
        lblReportName.Text = objRep.Nombre;
        if (objRep.SubtipoPresentacion == TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras)
        {
            CallRefreshReport();
        }
        else if (objRep.SubtipoPresentacion == TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines)
        {
            CallRefreshReport();
        }
        else
            CallRefreshReport();
    }
    private delegate void DelegateRefreshReport();
    public void CallRefreshReport()
    {
        RefreshReport();
    }
    private void RefreshReport()
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        DataSet dsField = new DataSet();
        //Checamos si la tabla va a ser llenada desde un store
        if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null)
            reportFunctions.CampoRelationXstore = myFunctions.FormatNumberNull(db.EjecutaInsert(new SqlCommand(objRep.StoreProcedure), MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", objRep.ProcesoId.Value))).Value;

        switch ((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion)
        {
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Detalle:
                {
                    try
                    {
                        int TotalItems = 0;
                        int PageSize = 0;

                        if (ViewState["NewPageSize"] != null)
                            PageSize = (int)ViewState["NewPageSize"];
                        else
                            PageSize = radGridReport.PageSize;
                        reportFunctions.PageSize = PageSize;

                        //------------------------------------------------------------------------------------------
                        reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                        string reportQueryPaging = reportFunctions.SetQueryDetails(objRep);
                        //-------------------------- Obtiene el total de items necesarios para paginacion-----------
                        string queryCount = Funcion.RegresaDato(reportFunctions.QueryCount);

                        try
                        {
                            TotalItems = int.Parse(queryCount);
                            // Si Total de Paginas del grid excede al de la consulta lo recalcula ....
                            if (TotalItems < radGridReport.MasterTableView.VirtualItemCount)
                            {
                                radGridReport.CurrentPageIndex = 0;
                                reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                                reportQueryPaging = reportFunctions.SetQueryDetails(objRep);
                            }
                        }
                        catch { }

                        if (queryCount == string.Empty)
                            radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = 0;
                        else
                            radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = TotalItems;
                        //------------------------------------------------------------------------------------------
                        dsField = Funcion.RegresaDataSet(reportQueryPaging);
                        //------------------------
                        GenerateReportDefinition(ref dsField, objRep);

                        toggleVisibilityReport(true);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Exception e = new Exception("El grid requiere que Defina Columnas" + ex.Message.ToString());
                        throw e;
                    }
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado:
                {
                    try
                    {
                        int TotalItems = 0;
                        int PageSize = 0;

                        if (ViewState["NewPageSize"] != null)
                            PageSize = (int)ViewState["NewPageSize"];
                        else
                            PageSize = radGridReport.PageSize;
                        reportFunctions.PageSize = PageSize;

                        DataTable dtRow = new DataTable();
                        DataTable dtCol; DataTable dtField, dtResult;

                        reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;

                        dsField = Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Col(objRep));
                        dtCol = dsField.Tables[0];

                        string reportQueryPaging = reportFunctions.SetQueryCross_Row(objRep);
                        //-------------------------- Obtiene el total de items necesarios para paginacion-----------
                        string queryCount = Funcion.RegresaDato(reportFunctions.QueryCount);

                        try
                        {
                            TotalItems = int.Parse(queryCount);
                            // Si Total de Paginas del grid excede al de la consulta lo recalcula ....
                            if (TotalItems < radGridReport.MasterTableView.VirtualItemCount)
                            {
                                radGridReport.CurrentPageIndex = 0;
                                reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                                reportQueryPaging = reportFunctions.SetQueryCross_Row(objRep);
                            }
                        }
                        catch { }

                        dsField = Funcion.RegresaDataSet(reportQueryPaging);
                        dtRow = dsField.Tables[0];

                        if (queryCount == string.Empty)
                            radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = 0;
                        else
                            radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = TotalItems;
                        //------------------------------------------------------------------------------------------
                        dsField = Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Fields(objRep));
                        dtField = dsField.Tables[0];

                        dtResult = reportFunctions.CreateReportCross(objRep, dtCol, dtRow, dtField);
                        dsField.Tables.Clear();
                        dsField.Tables.Add(dtResult);
                        GenerateReportDefinition(ref dsField, objRep);
                        //------------------------
                        toggleVisibilityReport(true);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Exception e = new Exception("El grid requiere que se definan: - Funciones -Renglones -Columnas" + ex.Message.ToString());
                        throw e;
                    }
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.PieChart:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras:
                {
                    try
                    {
                        //---------------------------------------- Si el Reporte Tiene Filas Y Funciones hace un Cross -----------------
                        if (objRep.FilasId.Length > 0 && objRep.FuncionesId.Length > 0 && objRep.ColumnasId.Length > 0)
                        {
                            reportFunctions.PageSize = 100;
                            reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                            dsField.Tables.Clear();
                            dsField.Tables.Add(Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Col(objRep)).Tables[0].Copy());
                            dsField.Tables[0].TableName = "DTCols";

                            string reportQueryPaging = reportFunctions.SetQueryCross_Row(objRep);
                            //-------------------------- Obtiene el total de items necesarios para paginacion-----------
                            string queryCount = Funcion.RegresaDato(reportFunctions.QueryCount);

                            dsField.Tables.Add(Funcion.RegresaDataSet(reportQueryPaging).Tables[0].Copy());
                            dsField.Tables[1].TableName = "DTRows";

                            radGridReport.VirtualItemCount = 0;
                            //------------------------------------------------------------------------------------------
                            dsField.Tables.Add(Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Fields(objRep)).Tables[0].Copy());
                            dsField.Tables[2].TableName = "DTFuncs";

                            dsField.Tables.Add(reportFunctions.CreateReportCross(objRep, dsField.Tables["DTCols"], dsField.Tables["DTRows"], dsField.Tables["DTFuncs"]).Copy());
                            dsField.Tables[3].TableName = "DTResult";

                        }
                        //---------------------------------------------------------------------------------------------------------------
                        else
                            dsField = Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Fields(objRep));
                        GenerateChart(ref dsField, objRep);
                        toggleVisibilityReport(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Exception e = new Exception("El grid requiere que se definan: - Funciones - Columnas " + ex.Message.ToString());
                        throw e;
                    }
                }
        }
        if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            db.EjecutaDelete(new SqlCommand("Delete From " + myFunctions.GenerateName(myData.NombreTabla) + " Where " + myFunctions.GenerateName(myData.Nombre) + " = " + reportFunctions.CampoRelationXstore.ToString() + ""), MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", objRep.ProcesoId.Value));
        }


    }
    #region Query y Refresca Control Para Grafica-Barras

    private void CreateReportBarChart(TTReportes.objectBussinessTTReportes objRep, DataTable dt)
    {
        gdtQueryBar = dt;
        gObjRep = objRep;
        TypeReport = TTControlReportsTypeReport.Bar;
    }
    private void CreateReportBarChartCross(TTReportes.objectBussinessTTReportes objRep, DataTable dt)
    {
        gdtQueryBar = dt;
        gObjRep = objRep;
        TypeReport = TTControlReportsTypeReport.BarCross;
    }

    #endregion
    #region Query y Refresca Control Para Grafica-Pie

    private void CreateReportPieChart(TTReportes.objectBussinessTTReportes objRep, DataTable dt)
    {
        gdtQueryBar = dt;
        gObjRep = objRep;
        TypeReport = TTControlReportsTypeReport.Pie;
    }

    #endregion

    private void cmdFilters_Click(object sender, EventArgs e)
    {
    }

    private void picAlarmsDetails_Click(object sender, EventArgs e)
    {
    }

    private void cmdExport_Click(object sender, EventArgs e)
    {
        Export();
    }

    public String Export(String fileName)
    {
        String sResult = "";
        return sResult;
    }
    public String Export()
    {
        String sResult = "";
        return sResult;
    }
    private void cboGraphicType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    private void toolStripcmdMore_Click(object sender, EventArgs e)
    {
    }

    protected void btnPopUp_Click(object sender, EventArgs e)
    {
        imExpanded = !imExpanded;
        if (imExpanded)
        {
            btnPopUp.Text = "[-]";
        }
        else
        {
            btnPopUp.Text = "[+]";
            contract();
        }
        OnExplande_Changed();
    }
    private void contract()
    {
    }

    void GenerateReportDefinition(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        radGridReport.Columns.Clear();
        radGridReport.AutoGenerateColumns = false;

        switch (objRep.SubtipoPresentacion)
        {
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado:
                {
                    foreach (DataColumn dc in dataSource.Tables[0].Columns)
                    {
                        Telerik.Web.UI.GridBoundColumn boundColumn;
                        boundColumn = new Telerik.Web.UI.GridBoundColumn();
                        boundColumn.DataField = dc.ColumnName;
                        boundColumn.HeaderText = dc.ColumnName;
                        boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                        boundColumn.HtmlEncode = false;

                        foreach (TTReportes.objectBussinessTTReportes_Filas fila in objRep.FilasId)
                        {
                            if (fila.Text == dc.ColumnName)
                            {
                                if (dc.DataType == typeof(decimal))
                                {
                                    boundColumn.DataFormatString = "{0:c}";
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                }
                                else if (dc.DataType == typeof(int))
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                else if (dc.DataType == typeof(string))
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                                else if (dc.DataType == typeof(double))
                                {
                                    boundColumn.DataFormatString = "{0:F2}";
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                }
                            }
                            else
                            {
                                boundColumn.DataFormatString = "{0:F2}";
                                boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            }
                        }
                        radGridReport.MasterTableView.Columns.Add(boundColumn);
                    }
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Detalle:
                {
                    foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
                    {
                        Telerik.Web.UI.GridBoundColumn boundColumn;
                        boundColumn = new Telerik.Web.UI.GridBoundColumn();
                        boundColumn.DataField = col.Text;
                        boundColumn.HeaderText = col.Text;
                        boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                        boundColumn.HtmlEncode = false;

                        if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(decimal))
                        {
                            boundColumn.DataFormatString = "{0:c}";
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                        }
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(int))
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(string))
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(double))
                        {
                            boundColumn.DataFormatString = "{0:F2}";
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                        }
                        radGridReport.MasterTableView.Columns.Add(boundColumn);
                    }
                    break;
                }
        }

        lblReportName.Text = objRep.Nombre;
        radGridReport.DataSource = dataSource.Tables[0];
        radGridReport.DataBind();
    }

    void GenerateCrossReportDefinition(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        lblReportName.Text = objRep.Nombre;
        radGridReport.DataSource = dataSource.Tables[0];
        radGridReport.DataBind();
    }

    private void GenerateChart(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        ReplaceDataTableColumnNames(ref dataSource, objRep);
        Telerik.Charting.ChartSeriesType tipoReporte;
        DataTable dt = dataSource.Tables[0];

        trchReport.Clear();
        trchReport.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;
        trchReport.ChartTitle.TextBlock.Text = objRep.Nombre;
        trchReport.ChartTitle.TextBlock.Appearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Center;
        trchReport.Series.Clear();
        trchReport.AutoLayout = true;

        switch ((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion)
        {
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines:
                {
                    if (((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion) == TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras)
                        tipoReporte = Telerik.Charting.ChartSeriesType.Bar;
                    else
                        tipoReporte = Telerik.Charting.ChartSeriesType.Line;

                    trchReport.PlotArea.XAxis.IsZeroBased = false;
                    trchReport.PlotArea.YAxis.AxisMode = Telerik.Charting.ChartYAxisMode.Extended;
                    trchReport.PlotArea.XAxis.DataLabelsColumn = objRep.ColumnasId[0].Text;
                    trchReport.PlotArea.XAxis.AutoScale = true;
                    trchReport.PlotArea.XAxis.AutoShrink = true;
                    trchReport.PlotArea.YAxis.AxisLabel.TextBlock.Text = objRep.FuncionesId[0].Text;
                    trchReport.PlotArea.YAxis.AxisLabel.Visible = true;
                    trchReport.PlotArea.XAxis.AxisLabel.TextBlock.Text = objRep.ColumnasId[0].Text;
                    trchReport.PlotArea.XAxis.AxisLabel.Visible = true;

                    if (objRep.FuncionesId.Length == 1)
                    {
                        for (int i = 0; i < dataSource.Tables[0].Rows.Count; i++)
                        {
                            Telerik.Charting.ChartSeries chartSeries;
                            Telerik.Charting.ChartSeriesItem chartItem;
                            decimal valueNull = myFunctions.FormatMoneyNull(dataSource.Tables[0].Rows[i][objRep.FuncionesId[0].Text].ToString());
                            double value = double.Parse(valueNull.ToString());
                            string seriesName = GetSeriesName(dataSource.Tables[0].Rows[i], objRep);

                            //chartSeries = new Telerik.Charting.ChartSeries(dataSource.Tables[0].Rows[i][objRep.ColumnasId[0].Text].ToString(), tipoReporte);
                            chartSeries = new Telerik.Charting.ChartSeries(seriesName, tipoReporte);
                            chartItem = new Telerik.Charting.ChartSeriesItem(value, value.ToString());
                            //chartItem.ActiveRegion.Tooltip = dataSource.Tables[0].Rows[i][objRep.ColumnasId[0].Text].ToString() + " - " + value.ToString();
                            chartItem.ActiveRegion.Tooltip = seriesName + " - " + value.ToString();
                            chartSeries.Items.Add(chartItem);
                            trchReport.Series.Add(chartSeries);

                        }
                        trchReport.PlotArea.XAxis.Step = 1;
                        trchReport.PlotArea.XAxis.Appearance.LabelAppearance.Visible = false;
                        trchReport.DataBind();
                    }
                    else
                    {
                        for (int i = 0; i < objRep.FuncionesId.Length; i++)
                        {
                            Telerik.Charting.ChartSeries chartSeries;
                            chartSeries = new Telerik.Charting.ChartSeries(objRep.FuncionesId[i].Text);
                            chartSeries.Type = tipoReporte;
                            chartSeries.ActiveRegionToolTip = "#SERIES: #Y";//objRep.FuncionesId[i].Text;

                            chartSeries.DataYColumn = objRep.FuncionesId[i].Text;
                            trchReport.Series.Add(chartSeries);
                        }
                        trchReport.DataSource = dataSource.Tables[0];
                        trchReport.DataBind();
                    }
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.PieChart:
                {
                    trchReport.PlotArea.XAxis.IsZeroBased = false;
                    trchReport.PlotArea.YAxis.AxisMode = Telerik.Charting.ChartYAxisMode.Extended;
                    trchReport.PlotArea.XAxis.DataLabelsColumn = objRep.ColumnasId[0].Text;
                    trchReport.PlotArea.XAxis.AutoScale = true;
                    trchReport.PlotArea.XAxis.AutoShrink = true;
                    trchReport.PlotArea.YAxis.AxisLabel.TextBlock.Text = objRep.FuncionesId[0].Text;
                    trchReport.PlotArea.YAxis.AxisLabel.Visible = true;
                    trchReport.PlotArea.XAxis.AxisLabel.TextBlock.Text = objRep.ColumnasId[0].Text;
                    trchReport.PlotArea.XAxis.AxisLabel.Visible = true;
                    decimal percentage, total = 0;
                    for (int i = 0; i < objRep.FuncionesId.Length; i++)
                    {
                        Telerik.Charting.ChartSeries chartSeries;
                        chartSeries = new Telerik.Charting.ChartSeries(objRep.FuncionesId[i].Text, Telerik.Charting.ChartSeriesType.Pie);
                        chartSeries.Appearance.LegendDisplayMode = Telerik.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries.DataYColumn = objRep.FuncionesId[i].Text;
                        chartSeries.DataLabelsColumn = objRep.ColumnasId[0].Text;
                        chartSeries.Name = objRep.ColumnasId[0].Text;
                        trchReport.Series.Add(chartSeries);
                    }
                    trchReport.DataSource = dataSource.Tables[0];
                    trchReport.DataBind();

                    try
                    {
                        for (int i = 0; i < dataSource.Tables[0].Rows.Count; i++)
                            total += decimal.Parse(trchReport.Series[0].Items[i].Label.TextBlock.Text = dataSource.Tables[0].Rows[i][objRep.FuncionesId[0].Text].ToString());
                    }

                    catch { total = 1; }

                    for (int i = 0; i < dataSource.Tables[0].Rows.Count; i++)
                    {
                        trchReport.Series[0].Items[i].Label.TextBlock.Text = dataSource.Tables[0].Rows[i][objRep.FuncionesId[0].Text].ToString();
                        try
                        {
                            percentage = decimal.Parse(trchReport.Series[0].Items[i].Label.TextBlock.Text) * 100 / total;
                            trchReport.Series[0].Items[i].ActiveRegion.Tooltip = trchReport.Series[0].Items[i].Name + " - " + percentage.ToString("N0") + " %";
                        }
                        catch { }
                    }
                    trchReport.DataBind();
                    break;
                }
            default:
                break;
        }
    }

    protected string GetSeriesName(DataRow row, TTReportes.objectBussinessTTReportes objRep)
    {
        string returnValue = string.Empty;

        if (objRep.FilasId.Length > 0)
            returnValue = row[objRep.ColumnasId[0].Text].ToString() + " - " + row[objRep.FilasId[0].Text].ToString();
        else
            returnValue = row[objRep.ColumnasId[0].Text].ToString();

        return returnValue;
    }

    void ReplaceDataTableColumnNames(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        try
        {
            for (int i = 0; i < objRep.ColumnasId.Length; i++)
            {
                DataColumn dc = dataSource.Tables[0].Columns[i];
                dc.ColumnName = objRep.ColumnasId[i].Text;
            }

            for (int i = 0; i < objRep.FuncionesId.Length; i++)
            {
                DataColumn dc = dataSource.Tables[0].Columns[objRep.ColumnasId.Length + i];
                dc.ColumnName = objRep.FuncionesId[i].Text;
            }
        }
        catch { }
    }

    private void LoadSkinList()
    {
        ArrayList skinsList = new ArrayList();
        skinsList.AddRange(new string[] { "Black", "Default", "Hay", "Inox", "Office2007", "Outlook", "Sunset", "Telerik", "Vista", "Web20", "WebBlue", "Marble", "Metal", "Wood", "BlueStripes", "DeepBlue", "DeepGray", "DeepGreen", "DeepRed", "GrayStripes", "GreenStripes", "LightBlue", "LightBrown", "LightGreen" });

        foreach (var item in skinsList)
            SkinList.Items.Add(new ListItem(item.ToString()));
    }


    private void toggleVisibilityReport(bool visible)
    {
        tblContainer.Visible = true;
        radGridReport.Visible = visible;
        divTituloReporte.Visible = visible;
        trchReport.Visible = !visible;
        chartOptionsPlaceholder.Visible = !visible;
        chartContainer.Visible = !visible;
    }

    protected void SkinList_SelectedIndexChanged(object sender, EventArgs e)
    {
        trchReport.ClearSkin();
        trchReport.Skin = SkinList.SelectedValue.ToString();
    }

    protected void OrientationList_SelectedIndexChanged(object sender, EventArgs e)
    {
        trchReport.SeriesOrientation = (Telerik.Charting.ChartSeriesOrientation)Enum.Parse(typeof(Telerik.Charting.ChartSeriesOrientation), OrientationList.SelectedValue);
    }

    protected void SubtypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (Telerik.Charting.ChartSeries chtSeries in trchReport.Series)
            chtSeries.Type = (Telerik.Charting.ChartSeriesType)Enum.Parse(typeof(Telerik.Charting.ChartSeriesType), SubtypeDropdown.SelectedValue);
    }

    protected void radGridReport_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        //RefreshReport();
    }

    protected void radGridReport_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        int currentIndex = e.NewPageIndex;
        radGridReport.CurrentPageIndex = currentIndex;
        RefreshReport();
    }

    protected void radGridReport_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        ViewState["NewPageSize"] = e.NewPageSize;
        RefreshReport();
    }

    private bool InsertAlarms(Decimal? ValueCel, TTReportes.objectBussinessTTReportes_Columnas objCol)
    {
        Boolean bResult = false;
        return bResult;
    }
    private bool InsertAlarms(Decimal? ValueCel, TTReportes.objectBussinessTTReportes_Funciones objCol)
    {
        Boolean bResult = false;
        return bResult;
    }

    void RefreshGrid()
    {
        RefreshReport();
    }
}










