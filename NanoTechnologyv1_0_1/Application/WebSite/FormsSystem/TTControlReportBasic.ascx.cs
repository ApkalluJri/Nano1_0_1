using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Reporting.Drawing;
using Telerik.Reporting.Charting;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using TTReportes;

public partial class FormsSystem_TTControlReportBasic : System.Web.UI.UserControl
{
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private int CampoRelationXstore;
    private DataSet dsField;
    protected int idReport;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSkinList();
        }

        radTabStrip.SelectedIndex = 0;
        radMultiPage.SelectedIndex = 0;
        trvwReport.Report = null;
        trvwReport.RefreshReport();
    }

    void RefreshGrid()
    {
        RefreshReport();
    }


    public void CallShowReport(int IdReport)
    {
        ShowReport(IdReport);
    }

    private void ShowReport(int IdReport)
    {
        this.idReport = IdReport;
        LoadReport();
        PrepareScreenOptionButtons();
    }

    private void LoadReport()
    {
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

        if (objRep.FiltroId.Filtro_Detalle != null)
        {
            btnFilters.Enabled = objRep.FiltroId.Filtro_Detalle.Length > 0;
            btn_filtros_report.Visible = objRep.FiltroId.Filtro_Detalle.Length > 0;
        }
    }

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
        {
            reportFunctions.CampoRelationXstore = myFunctions.FormatNumberNull(db.EjecutaInsert(new SqlCommand(objRep.StoreProcedure), MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", objRep.ProcesoId.Value))).Value;
            Session["CampoRelationXstore"] = reportFunctions.CampoRelationXstore;
        }
        switch ((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion)
        {
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Detalle:
                {
                    //------------------------------------------------------------------------------------------
                    int TotalItems = 0;
                    int PageSize = 0;

                    if (ViewState["NewPageSize"] != null)
                        PageSize = (int)ViewState["NewPageSize"];
                    else
                        PageSize = radGridReport.PageSize;
                    reportFunctions.PageSize = PageSize;

                    reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                    string reportQueryPaging = reportFunctions.SetQueryDetails(objRep);
                    //------------------------------------------------------------------------------------------
                    string queryCount = Funcion.RegresaDato(reportFunctions.QueryCount);

                    try
                    {
                        TotalItems = int.Parse(queryCount);
                        // Si Total de Paginas del grid excede al de la consulta lo recalcula ....
                        //if (((double)TotalItems / (double)PageSize) > radGridReport.CurrentPageIndex)
                        if (TotalItems < radGridReport.MasterTableView.VirtualItemCount)
                        {
                            radGridReport.CurrentPageIndex = 0;
                            reportFunctions.CurrentPageIndex = radGridReport.CurrentPageIndex;
                            reportQueryPaging = reportFunctions.SetQueryDetails(objRep);
                        }
                    }
                    catch { }
                    //-------------------------- Obtiene el total de items necesarios para paginacion-----------
                    if (queryCount == string.Empty)
                        radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = 0;
                    else
                        radGridReport.VirtualItemCount = radGridReport.MasterTableView.VirtualItemCount = TotalItems;
                    //------------------------------------------------------------------------------------------
                    dsField = Funcion.RegresaDataSet(reportQueryPaging);
                    //------------------------
                    string TotalesColumna = Funcion.RegresaDato("select isnull(TotalesColumna,0) from ttreportes where idreporte=" + objRep.idReporte.Value.ToString());
                    //TOTALES POR COLUMNA
                    double[] total = new double[dsField.Tables[0].Columns.Count];
                    if (bool.Parse(TotalesColumna))
                    {
                        for (int iCol = 0; iCol <= dsField.Tables[0].Columns.Count - 1; iCol++)
                        {
                            for (int iRow = 0; iRow <= dsField.Tables[0].Rows.Count - 1; iRow++)
                            {
                                DataRow dr = dsField.Tables[0].Rows[iRow];
                                if (IsNumeric(dr.ItemArray[iCol].ToString()))
                                {
                                    total[iCol] = total[iCol] + double.Parse(dr.ItemArray[iCol].ToString());
                                }
                            }
                        }

                        DataRow newRow = dsField.Tables[0].NewRow();
                        for (int iCol = 0; iCol <= dsField.Tables[0].Columns.Count - 1; iCol++)
                        {
                            if (total[iCol] != 0 && iCol > 0)
                            {
                                newRow[iCol] = total[iCol];
                            }
                            if (iCol == 0)
                            {
                                newRow[iCol] = "TOTALES";
                            }
                        }
                        dsField.Tables[0].Rows.Add(newRow);
                    }                    

                    GenerateReportDefinition(ref dsField, objRep);



                    toggleVisibilityReport(true);
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado:
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

                    //-------------------------- Obtiene el total de items necesarios para paginacion-----------
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

                    DataRow RTotales = Funcion.RegresaDataSet("select isnull(TotalesColumna,0) AS TotalesColumna, isnull(TotalesRenglon,0) AS TotalesRenglon, isnull(Contador,0) AS Contador  from ttreportes where idreporte=" + objRep.idReporte.Value.ToString()).Tables[0].Rows[0];

                    string TotalesColumna = RTotales["TotalesColumna"].ToString();
                    string TotalesRenglon = RTotales["TotalesRenglon"].ToString();
                    string Contador = RTotales["Contador"].ToString();
                    hfContador.Value = Contador;
                    if (TotalesColumna != "False")
                    {                  
                        //TOTALES POR COLUMNA
                        double[] total = new double[dtResult.Columns.Count];

                        for (int iCol = 0; iCol <= dtResult.Columns.Count - 1; iCol++)
                        {
                            for (int iRow = 0; iRow <= dtResult.Rows.Count - 1; iRow++)
                            {
                                DataRow dr = dtResult.Rows[iRow];
                                if (IsNumeric(dr.ItemArray[iCol].ToString()))
                                {
                                    total[iCol] = total[iCol] + double.Parse(dr.ItemArray[iCol].ToString());
                                }
                            }
                        }

                        DataRow newRow = dtResult.NewRow();
                        for (int iCol = 0; iCol <= dtResult.Columns.Count - 1; iCol++)
                        {
                            if (iCol == 0)
                            {
                                newRow[iCol] = "TOTALES";
                            }
                            else if (iCol >= objRep.FilasId.Count())
                            {
                                //if (total[iCol] != 0)
                                //{
                                    newRow[iCol] = total[iCol];
                                //}
                            }
                        }
                        dtResult.Rows.Add(newRow);
                    }
                    if (TotalesRenglon != "False")
                    {
                        //TOTALES POR RENGLON
                        double[] totalRen = new double[dtResult.Rows.Count];

                        for (int iRow = 0; iRow <= dtResult.Rows.Count - 1; iRow++)
                        {
                            totalRen[iRow] = 0;
                            for (int iCol = 1; iCol <= dtResult.Columns.Count - 1; iCol++)
                            {
                                DataRow dr = dtResult.Rows[iRow];
                                if (IsNumeric(dr.ItemArray[iCol].ToString()))
                                {
                                    totalRen[iRow] = totalRen[iRow] + double.Parse(dr.ItemArray[iCol].ToString());
                                }
                            }
                        }

                        dtResult.Columns.Add("TOTAL");


                        for (int iRow = 0; iRow <= dtResult.Rows.Count - 1; iRow++)
                        {
                            //if (totalRen[iRow] != 0)
                            //{
                                dtResult.Rows[iRow][dtResult.Columns.Count-1] = totalRen[iRow];
                            //}
                        }
                    }
                    radGridReport.DataSource = dtResult;
                    radGridReport.DataBind();
                    //------------------------
                    toggleVisibilityReport(true);
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.PieChart:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras:
                {
                    dsField = Funcion.RegresaDataSet(reportFunctions.ExtractQueryCross_Fields(objRep));
                    GenerateChart(ref dsField, objRep);
                    toggleVisibilityReport(false);
                    break;
                }
        }
        Session["dsField"] = dsField;
        if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            db.EjecutaDelete(new SqlCommand("Delete From " + myFunctions.GenerateName(myData.NombreTabla) + " Where " + myFunctions.GenerateName(myData.Nombre) + " = " + reportFunctions.CampoRelationXstore.ToString() + ""), MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", objRep.ProcesoId.Value));
        }

        //---------------- Guarda el String del Reporte para Exportación ---------------------------------
        reportFunctions.IsQueryMode = false;
        ViewState["ReportQuery"] = reportFunctions.Query(objRep.idReporte.Value);
    }


    public bool IsNumeric(object Expression)
    {
        bool isNum;
        double retNum;

        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    private void PrepareScreenOptionButtons()
    {
    }

    private Telerik.Reporting.TextBox CreateTxtHeader(string FieldName, int pos)//int pos)
    {
        Telerik.Reporting.Drawing.Unit x = Telerik.Reporting.Drawing.Unit.Inch(0);
        Telerik.Reporting.Drawing.Unit y = Telerik.Reporting.Drawing.Unit.Inch(0);

        x = Telerik.Reporting.Drawing.Unit.Inch(pos * 2.1);

        Telerik.Reporting.TextBox txtHead = new Telerik.Reporting.TextBox();
        txtHead.Value = FieldName;
        txtHead.StyleName = "Caption";
        txtHead.TextWrap = true;
        txtHead.Location = new Telerik.Reporting.Drawing.PointU(x, y);
        txtHead.CanShrink = true;
        //txtHead.Height = new Unit(75, UnitType.Pixel);
        //txtHead.Width = new Unit(200, UnitType.Pixel);
        txtHead.Size = new SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3), Telerik.Reporting.Drawing.Unit.Inch(1));
        //txtHead.Size = new SizeU(Telerik.Reporting.Drawing.Unit.Cm(FieldName.Length), Telerik.Reporting.Drawing.Unit.Inch(0.5));

        return txtHead;
    }

    private Telerik.Reporting.TextBox CreateTxtDetail(string FieldName, int pos)
    {
        Telerik.Reporting.Drawing.Unit x = Telerik.Reporting.Drawing.Unit.Inch(0);
        Telerik.Reporting.Drawing.Unit y = Telerik.Reporting.Drawing.Unit.Inch(0);
        x = Telerik.Reporting.Drawing.Unit.Inch(pos * 2.1);

        Telerik.Reporting.TextBox txtData = new Telerik.Reporting.TextBox();
        txtData.Value = "=[" + FieldName + "]";
        txtData.StyleName = "Data";
        txtData.Location = new Telerik.Reporting.Drawing.PointU(x, y);
        txtData.CanShrink = true;
        //txtData.TextWrap = true;
        txtData.Size = new SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3), Telerik.Reporting.Drawing.Unit.Inch(1));

        return txtData;
    }

    void GenerateReportDefinition(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        string TotalesColumna = Funcion.RegresaDato("select isnull(TotalesColumna,0) from ttreportes where idreporte=" + objRep.idReporte.Value.ToString() );
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
                                    TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
                                    TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(int.Parse(fila.FullPathDT.Split('.')[1]));
                                    if (myData.TipodeDato == TTFunctions.TypeData.Moneda)
                                        boundColumn.DataFormatString = "{0:c}";
                                    else
                                        boundColumn.DataFormatString = "{0:F2}";
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    if (TotalesColumna != "False")
                                    {
                                        boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                                        boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                                        if (myData.TipodeDato == TTFunctions.TypeData.Moneda)
                                            boundColumn.FooterAggregateFormatString = "{0:c}";
                                        else
                                            boundColumn.FooterAggregateFormatString = "{0:F2}";
                                        boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    }
                                }
                                else if (dc.DataType == typeof(int))
                                {
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    if (TotalesColumna != "False")
                                    {
                                        boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                                        boundColumn.FooterAggregateFormatString = "{0:F2}";
                                        boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    }
                                }
                                else if (dc.DataType == typeof(string))
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                                else if (dc.DataType == typeof(double))
                                {
                                    boundColumn.DataFormatString = "{0:F2}";
                                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    if (TotalesColumna != "False")
                                    {
                                        boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                                        boundColumn.FooterAggregateFormatString = "{0:F2}";
                                        boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                    }
                                }
                            }
                            else
                            {
                                boundColumn.DataFormatString = "{0:F2}";
                                boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                if (TotalesColumna != "False")
                                {
                                    boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                                    boundColumn.FooterAggregateFormatString = "{0:F2}";
                                    boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                                }
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
                            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
                            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(int.Parse(col.FullPathDT.Split('.')[1]));
                            if (myData.TipodeDato == TTFunctions.TypeData.Moneda)
                                boundColumn.DataFormatString = "{0:c}";
                            else
                                boundColumn.DataFormatString = "{0:F2}";
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //if (TotalesColumna != "False")
                            //{
                            //    boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                            //    boundColumn.FooterAggregateFormatString = "{0:c}";
                            //    boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //}
                        }
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(int))
                        {
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //if (TotalesColumna != "False")
                            //{
                            //    boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                            //    boundColumn.FooterAggregateFormatString = "{0:F2}";
                            //    boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //}
                        }
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(string))
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                        else if (dataSource.Tables[0].Columns[col.Text].DataType == typeof(double))
                        {
                            boundColumn.DataFormatString = "{0:F2}";
                            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //if (TotalesColumna != "False")
                            //{
                            //    boundColumn.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum;
                            //    boundColumn.FooterAggregateFormatString = "{0:F2}";
                            //    boundColumn.FooterStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                            //}
                        }
                        radGridReport.MasterTableView.Columns.Add(boundColumn);
                    }
                    break;
                }
        }

        lblTitulo.Text = objRep.Nombre;
        radGridReport.DataSource = dataSource.Tables[0];
        radGridReport.DataBind();
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

    void GenerateReportViewer(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        double locationHeader = 0;
        double location = 0;
        int maxWidth;
        GenericListReport report = new GenericListReport(objRep.GetHeader().AsEnumerable().Select(x =>
           new TTReportsHeaderFooter(x["Row"].ToString(), x["Cell"].ToString(), Convert.ToByte(x["Colspan"]), Convert.ToByte(x["Rowspan"])
               , x["Zone"].ToString(), Convert.ToDouble(x["CmHeight"]), Convert.ToDouble(x["CmWidth"]), Convert.ToByte(x["RowID"]))).ToList<TTReportsHeaderFooter>(),
               objRep.DocksHeader.Where(x => !x.Closed).ToList(), objRep.GetFooterr().AsEnumerable().Select(x =>
           new TTReportsHeaderFooter(x["Row"].ToString(), x["Cell"].ToString(), Convert.ToByte(x["Colspan"]), Convert.ToByte(x["Rowspan"])
               , x["Zone"].ToString(), Convert.ToDouble(x["CmHeight"]), Convert.ToDouble(x["CmWidth"]), Convert.ToByte(x["RowID"]))).ToList<TTReportsHeaderFooter>(),
               objRep.DocksFooter.Where(x => !x.Closed).ToList(), MyUserData.UserName);
        int count = objRep.FilasId.Length + objRep.ColumnasId.Length;
        report.DataSource = dataSource.Tables[0];
        report.ReportTitle = objRep.Nombre;
        report.PageSettings.Landscape = true;
        MarginsU m = new MarginsU(Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0));
        report.PageSettings.Margins = m;
        Telerik.Reporting.ReportItemBase[] headColumnList = new Telerik.Reporting.ReportItem[count];
        Telerik.Reporting.ReportItemBase[] detailColumnList = new Telerik.Reporting.ReportItem[count];
        if (objRep.SubtipoPresentacion == TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado)
        {
            count = dataSource.Tables[0].Columns.Count;

            headColumnList = new Telerik.Reporting.ReportItem[count];
            detailColumnList = new Telerik.Reporting.ReportItem[count];

            int column = 0;

            column = 0;
            foreach (DataColumn col in dataSource.Tables[0].Columns)
            {
                string columnName = col.ColumnName;
                maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
                if (!columnName.Contains(" "))
                    maxWidth = maxWidth + 3;

                Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
                //header.Style.BorderStyle.Default = BorderType.Solid;
                //header.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
                //header.Style.BorderStyle.Left = BorderType.Solid;
                //header.Style.BorderStyle.Right = BorderType.Solid;

                header.CanGrow = true;
                header.CanShrink = true;
                headColumnList[column] = header;
                Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);

                //textBox.Style.BorderStyle.Default = BorderType.Solid;
                //textBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);

                textBox.Size = header.Size;
                if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
                    textBox.Format = "{0:c}";
                detailColumnList[column] = textBox;
                locationHeader += header.Width.Value;//

                column++;
            }
        }
        else
        {

            int column = 0;
            foreach (TTReportes.objectBussinessTTReportes_Filas fila in objRep.FilasId)
            {
                string columnName = fila.Text;
                maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
                if (!columnName.Contains(" "))
                    maxWidth = maxWidth + 3;

                Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
                //header.Style.BorderStyle.Default = BorderType.Solid;
                //header.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
                //header.Style.BorderStyle.Left = BorderType.Solid;
                //header.Style.BorderStyle.Right = BorderType.Solid;

                header.CanGrow = true;
                header.CanShrink = true;

                headColumnList[column] = header;
                Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
                //textBox.Style.BorderStyle.Default = BorderType.Solid;
                //textBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);

                textBox.Size = header.Size;
                if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
                    textBox.Format = "{0:c}";
                detailColumnList[column] = textBox;
                locationHeader += header.Width.Value;//(header.Width.Value + .2);
                column++;
            }

            column = 0;
            foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
            {
                string columnName = col.Text;
                maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
                if (!columnName.Contains(" "))
                    maxWidth = maxWidth + 3;

                Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
                //header.Style.BorderStyle.Default = BorderType.Solid;
                //header.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
                //header.Style.BorderStyle.Left = BorderType.Solid;
                //header.Style.BorderStyle.Right = BorderType.Solid;
                header.CanGrow = true;
                header.CanShrink = true;

                headColumnList[column] = header;
                Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
                //textBox.Style.BorderStyle.Default = BorderType.Solid;
                //textBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);

                textBox.Size = header.Size;
                if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
                    textBox.Format = "{0:c}";
                detailColumnList[column] = textBox;
                locationHeader += header.Width.Value;//(header.Width.Value + .2);
                column++;
            }

        }

        report.LabelsGroupHeader.Items.AddRange(headColumnList);
        report.LabelsGroupHeader.Style.BackgroundColor = System.Drawing.Color.SteelBlue;
        report.Detail.Items.AddRange(detailColumnList);
        //----------------------- Binding report -------------------------
        //report.RowsCountTextBox.Visible = bool.Parse(hfContador.Value);
        trvwReport.Report = report;
        trvwReport.RefreshReport();
    }

    //void GenerateReportViewer(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    //{
    //    double locationHeader = 0;
    //    double location = 0;
    //    int maxWidth;
    //    GenericListReport report = new GenericListReport();
    //    //int count = dataSource.Tables[0].Columns.Count;
    //    int count = objRep.FilasId.Length + objRep.ColumnasId.Length;
    //    report.DataSource = dataSource.Tables[0];
    //    report.ReportTitle = objRep.Nombre;
    //    report.PageSettings.Landscape = true;
    //    MarginsU m = new MarginsU(Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0));
    //    report.PageSettings.Margins = m;
    //    Telerik.Reporting.ReportItemBase[] headColumnList = new Telerik.Reporting.ReportItem[count];
    //    Telerik.Reporting.ReportItemBase[] detailColumnList = new Telerik.Reporting.ReportItem[count];
    //    if (objRep.SubtipoPresentacion == TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado)
    //    {
    //        count = dataSource.Tables[0].Columns.Count;

    //        headColumnList = new Telerik.Reporting.ReportItem[count];
    //        detailColumnList = new Telerik.Reporting.ReportItem[count];

    //        int column = 0;
    //        //foreach (DataRow fila in dataSource.Tables[0].Rows)
    //        //{
    //        //    string columnName = fila.Table.Col;
    //        //    maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
    //        //    Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
    //        //    headColumnList[column] = header;
    //        //    Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
    //        //    textBox.Size = header.Size;
    //        //    if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
    //        //        textBox.Format = "{0:c}";
    //        //    detailColumnList[column] = textBox;
    //        //    locationHeader += header.Width.Value;//(header.Width.Value + .2);
    //        //    column++;
    //        //}

    //        column = 0;
    //        foreach (DataColumn col in dataSource.Tables[0].Columns)
    //        {
    //            string columnName = col.ColumnName;
    //            maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
    //            //if (column == dataSource.Tables[0].Columns.Count - 1)
    //            //{
    //            if (columnName.Contains(" "))
    //            {
    //                //maxWidth = maxWidth - 3;
    //            }
    //            else
    //            {
    //                maxWidth = maxWidth + 3;
    //            }

    //            //}
    //            //else
    //            //{
    //            //    maxWidth = maxWidth + 2;
    //            //}
    //            Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
    //            header.Style.BorderStyle.Default = BorderType.Solid;
    //            header.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
    //            header.CanGrow = true;
    //            header.CanShrink = true;
    //            //header.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2);
    //            headColumnList[column] = header;
    //            Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);

    //            textBox.Style.BorderStyle.Default = BorderType.Solid;
    //            textBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
    //            //textBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2);

    //            textBox.Size = header.Size;
    //            if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
    //                textBox.Format = "{0:c}";
    //            detailColumnList[column] = textBox;
    //            locationHeader += header.Width.Value;//

    //            column++;
    //        }
    //    }
    //    else
    //    {

    //        int column = 0;
    //        foreach (TTReportes.objectBussinessTTReportes_Filas fila in objRep.FilasId)
    //        {
    //            string columnName = fila.Text;
    //            maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
    //            Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
    //            headColumnList[column] = header;
    //            Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
    //            textBox.Size = header.Size;
    //            if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
    //                textBox.Format = "{0:c}";
    //            detailColumnList[column] = textBox;
    //            locationHeader += header.Width.Value;//(header.Width.Value + .2);
    //            column++;
    //        }

    //        column = 0;
    //        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
    //        {
    //            string columnName = col.Text;
    //            maxWidth = Funcion.MaxColumnLenght(dataSource.Tables[0], columnName);
    //            Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
    //            headColumnList[column] = header;
    //            Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
    //            textBox.Size = header.Size;
    //            if (dataSource.Tables[0].Columns[columnName].DataType == typeof(decimal))
    //                textBox.Format = "{0:c}";
    //            detailColumnList[column] = textBox;
    //            locationHeader += header.Width.Value;//(header.Width.Value + .2);
    //            column++;
    //        }

    //    }
    //    report.LabelsGroupHeader.Items.AddRange(headColumnList);
    //    report.LabelsGroupHeader.Style.BackgroundColor = System.Drawing.Color.SteelBlue;
    //    report.Detail.Items.AddRange(detailColumnList);
    //    //----------------------- Binding report -------------------------
    //    trvwReport.Report = report;
    //    trvwReport.RefreshReport();
    //}

    private Telerik.Reporting.TextBox AgregaHeader(string FieldName, int i)
    {
        Telerik.Reporting.TextBox txtHead = new Telerik.Reporting.TextBox();
        txtHead.Value = FieldName;
        return txtHead;
    }
    private Telerik.Reporting.TextBox AgregaDetalle(string FieldName, int i)
        {
        Telerik.Reporting.TextBox txtHead = new Telerik.Reporting.TextBox();
        txtHead.Value = "=[" + FieldName + "]";
        return txtHead;
        }


    //void GenerateReportViewerTEST(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    //{
    //    int count = (Convert.ToInt32(dataSource.Tables[0].Columns.Count));
    //    Telerik.Reporting.Drawing.Unit x = Telerik.Reporting.Drawing.Unit.Inch(0);
    //    Telerik.Reporting.Drawing.Unit y = Telerik.Reporting.Drawing.Unit.Inch(0);
    //    SizeU size = new SizeU(Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Inch(0.1));
    //    Telerik.Reporting.ReportItemBase[] headColumnList = new Telerik.Reporting.ReportItem[count];
    //    Telerik.Reporting.ReportItemBase[] detailColumnList = new Telerik.Reporting.ReportItem[count];
    //    GenericListReport report = new GenericListReport();

    //    report.DataSource = dataSource.Tables[0];
    //    report.ReportTitle = objRep.Nombre;
    //    report.PageSettings.Landscape = true;
    //    MarginsU m = new MarginsU(Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0));
    //    report.PageSettings.Margins = m;


    //    //string str = Convert.ToString(this.table1.ColumnGroups.Count);
    //    int cols = Convert.ToInt32(dataSource.Tables[0].Columns.Count);
    //    Telerik.Reporting.ReportItemBase[] columnHead = new Telerik.Reporting.ReportItemBase[dataSource.Tables[0].Columns.Count];

    //    for (int column = 0; column < cols; column++)
    //    {
    //        string columnName = dataSource.Tables[0].Columns[column].ColumnName;
    //        Telerik.Reporting.TextBox header = AgregaHeader(columnName, column);
    //        header.Style.BackgroundColor = System.Drawing.Color.LemonChiffon;
    //        header.Style.BorderStyle.Default = BorderType.Solid;
    //        //header.Style.Font.Name.
    //        header.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
    //        header.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2);
    //        header.Location = new Telerik.Reporting.Drawing.PointU(x, y);
    //        if (column == 0)
    //            size = new SizeU(Telerik.Reporting.Drawing.Unit.Cm(5), Telerik.Reporting.Drawing.Unit.Inch(0.1));

    //        if (column > 0)
    //        {
    //            size = new SizeU(Telerik.Reporting.Drawing.Unit.Cm(2), Telerik.Reporting.Drawing.Unit.Inch(0.1));
    //        }

    //        header.Size = size;
    //        headColumnList[column] = header;
    //        Telerik.Reporting.TextBox textBox = this.CreateTxtDetail(columnName, column);
    //        textBox.Style.BorderStyle.Default = BorderType.Solid;
    //        textBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
    //        textBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2);
    //        textBox.Location = new Telerik.Reporting.Drawing.PointU(x, y);
    //        textBox.Size = size;
    //        detailColumnList[column] = textBox;
    //        if (column > 0)
    //        {
    //            x += Telerik.Reporting.Drawing.Unit.Inch(0.1);
    //        }
    //            //table1.Body.SetCellContent(0, column, header);
    //            //table1.Body.SetCellContent(1, column, textBox);
            
    //    }
        
    //    report.LabelsGroupHeader.Items.AddRange(headColumnList);
    //    report.LabelsGroupHeader.Style.BackgroundColor = System.Drawing.Color.SteelBlue;
    //    report.Detail.Items.AddRange(detailColumnList);
    //    //----------------------- Binding report -------------------------
    //    trvwReport.Report = report;
    //    trvwReport.RefreshReport();
    //}
    private void GenerateChartViewer()
    {
        System.Web.UI.WebControls.Unit beforeWidth, beforeHeight;

        beforeWidth = trchReport.Width;
        beforeHeight = trchReport.Height;

        MemoryStream chartStream = new MemoryStream();
        trchReport.Width = 960;
        trchReport.Height = 580;
        trchReport.DataBind();
        trchReport.Save(chartStream, ImageFormat.Png);

        System.Drawing.Bitmap brush = new System.Drawing.Bitmap(chartStream);
        System.Drawing.Image img2 = brush.GetThumbnailImage(brush.Width, brush.Height, null, System.IntPtr.Zero);

        GenericImageReport report = new GenericImageReport(img2, Funcion.ConvertPixelsToCms(brush.Height) + 2, Funcion.ConvertPixelsToCms(brush.Width));
        //----------------------- Binding report -------------------------
        trvwReport.Report = report;
        trvwReport.RefreshReport();

        trchReport.Width = beforeWidth;
        trchReport.Height = beforeHeight;
        trchReport.DataBind();
    }


    private void GenerateChart(ref System.Data.DataSet dataSource, TTReportes.objectBussinessTTReportes objRep)
    {
        ReplaceDataTableColumnNames(ref dataSource, objRep);
        Telerik.Charting.ChartSeriesType tipoReporte;
        DataTable dt = dataSource.Tables[0];

        trchReport.Clear();
        //trchReport.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Image;
        //trchReport.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
        //trchReport.Appearance.FillStyle.FillSettings.BackgroundImage = "../Images/back_gnp.jpg"; //"../Images/GNPBackgroundPreview.jpg";
        //trchReport.Appearance.FillStyle.FillSettings.ImageDrawMode = Telerik.Charting.Styles.ImageDrawMode.Stretch;

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

    private bool TableColumnsExcedeWidth(DataTable dt)
    {
        string columnText = "";
        int totalSeries = dt.Rows.Count;
        bool res = false;

        foreach (DataRow dr in dt.Rows)
        {
            if (dr[0].ToString().Length > columnText.Length)
                columnText = dr[0].ToString();
        }

        if (columnText.Length <= 20 && totalSeries <= 5)
            res = false;
        else if (columnText.Length <= 6 && totalSeries > 5)
            res = false;
        else
            res = true;

        return res;
    }

    private void LoadSkinList()
    {
        SkinList.Items.Clear();
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
        divExport.Visible = visible;
        //tblChart.Visible = !visible;        
    }


    protected void SkinList_SelectedIndexChanged(object sender, EventArgs e)
    {
        trchReport.ClearSkin();
        trchReport.Skin = SkinList.SelectedValue.ToString();
        btnRefresh_Click(null, null);
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        if (objRep != null)
        {
            switch ((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion)
            {
                case TTReportes.TTReportsConfigurationsEnumSubPresentation.Detalle:
                case TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado:
                    {
                        dsField = (DataSet)Session["dsField"];
                        GenerateReportViewer(ref dsField, objRep);
                        break;
                    }
                case TTReportes.TTReportsConfigurationsEnumSubPresentation.PieChart:
                case TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines:
                case TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras:
                    {
                        GenerateChartViewer();
                        break;
                    }
            }
        }
        radTabStrip.SelectedIndex = 1;
        radMultiPage.SelectedIndex = 1;
    }
    protected void btnFilters_Click(object sender, EventArgs e)
    {
        windowPrint.VisibleOnPageLoad = true;

        if (objRep != null)
        {
            Session["Filter"] = objRep.FiltroId;
            windowPrint.NavigateUrl = "TTSearch.aspx?idReport=" + objRep.idReporte + "&ProcessId=" + objRep.ProcesoId;
        }
    }

    private void Save()
    {
        TTDataLayerCS.DataLayerFieldsBitacora DataReference = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        string res;
        try
        {
            res = objRep.Update(MyUserData, DataReference).ToString();
        }
        catch //Exception e
        {
            //MessageBox.Show(e.Message.ToString());
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        windowPrint.VisibleOnPageLoad = false;
        idReport = objRep.ProcesoId == null ? 0 : (int)objRep.ProcesoId;
        RefreshReport();
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

    protected void radTabStrip_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs args)
    {
        if (args.Tab.Index == 1)
            btnImprimir_Click(radTabStrip, new EventArgs());
        if (args.Tab.Index == 0)
        {
            windowPrint.VisibleOnPageLoad = false;
            idReport = objRep.ProcesoId == null ? 0 : (int)objRep.ProcesoId;
            RefreshReport();
            RefreshGrid();
        }
    }

    protected void radGridReport_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
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

    protected void btnExport_Click(object sender, ImageClickEventArgs e)
    {
        /*if (Request["GenerateApp"] != null)
        {
            if (Request["GenerateApp"].ToString() == "True")
            {
                if (Request["TypeReport"].ToString() != null)
                {
                    OpenExport(Request["TypeReport"].ToString() );                    
                }
            }
        }
        else*/ if (ViewState["ReportQuery"] != null)
        {
            string sQ = ViewState["ReportQuery"].ToString();
            string sPath = HttpContext.Current.Server.MapPath("..\\App_Data");
            string SID = Session.SessionID.ToString();
            string format = ddlFileFormat.SelectedValue.ToString();

            if (Session["CampoRelationXstore"] == null || Session["CampoRelationXstore"].ToString() == "0")
                Session["CampoRelationXstore"] = string.Empty;

            DataRow RTotales = Funcion.RegresaDataSet("select isnull(TotalesColumna,0) AS TotalesColumna, isnull(TotalesRenglon,0) AS TotalesRenglon, isnull(Contador,0) AS Contador  from ttreportes where idreporte=" + objRep.idReporte.Value.ToString()).Tables[0].Rows[0];
            string TotalesColumna = RTotales["TotalesColumna"].ToString();
            string TotalesRenglon = RTotales["TotalesRenglon"].ToString();
            string Contador = RTotales["Contador"].ToString();

            ExportWithConsoleApp(sPath, SID, format, sQ, objRep.idReporte.ToString(), Session["CampoRelationXstore"].ToString(),TotalesColumna,TotalesRenglon,Contador);


            SID = sPath + "\\" + SID;
            if (File.Exists(SID + "." + format))
            {
                hplnkExportedFile.NavigateUrl = "Download.aspx?FilePath=" + SID + "." + format + "&FileName=" + objRep.Nombre.Replace(" ", "_") + "." + format;
                hplnkExportedFile.Text = objRep.Nombre.Replace(" ", "_") + "." + format;
                hplnkExportedFile.Target = "_self";
                
            }
        }
        RefreshReport();
    }

    public static bool ExportWithConsoleApp(string filePath, string fileName, string format, string StringQuery, string idReport, string idFolio, string TotalColumnas, string TotalRenglones, string Contador)
    {
        try
        {
            if (!idFolio.Equals(""))
                StringQuery = StringQuery.Replace(idFolio, "@@CampoRelationXstore@@");

            string command = HttpContext.Current.Server.MapPath(@"..\\DLL") + "\\ExportToExcel.exe";
            string arguments = @"""{0}"" ""{1}"" ""{2}"" ""{3}"" ""{4}"" ""{5}"" ""{6}"" ""{7}""";
            arguments = String.Format(arguments, filePath, fileName, format, @StringQuery, idReport,TotalColumnas,TotalRenglones,Contador);

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true; 

            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            GC.Collect();
        }
    }
    /*private void OpenExport(string Type)
    {
        string sPath = @"C:\inetpub\wwwroot\ReclutamientoPreproduccion\Reportes";
        string idReporte = objRep.idReporte.ToString();
        string format = "xls";

        string sQ  = string.Empty;
        if (Type == "1")
            sQ = ViewState["ReportQuery"].ToString();
        else if (Type == "2")
            trchReport.Save(sPath + @"\grapics" + idReporte + ".jpg", ImageFormat.Jpeg);

        string command = @"C:\inetpub\wwwroot\ReclutamientoPreproduccion\ExportToExcel\ExportToExcel\bin\Release\CustomExportToExcel.exe"; //HttpContext.Current.Server.MapPath("../") + "WebForms\\TempFiles\\TTReporte_por_Correo\\CustomExportToExcel.exe";        
        string arguments = @"""{0}"" ""{1}"" ""{2}"" ""{3}""";
        arguments = String.Format(arguments, sPath, idReporte, format, sQ);

        Process process = new Process();
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;

        process.StartInfo.FileName = command;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.Start();
        process.WaitForExit();
        process.Close();
    }*/
}








