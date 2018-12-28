using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;

namespace TTReportes
{
    public class TTReportesFilters
    {
        private Boolean obligatory;
        private Boolean defaultview;
        private Boolean vacia;
        public Boolean Obligatory
        {
            get { return obligatory; }
            set { obligatory = value; }
        }
        public Boolean Defaultview
        {
            get { return defaultview; }
            set { defaultview = value; }
        }
        public Boolean Vacia
        {
            get { return vacia; }
            set { vacia = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varidReporte = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idReporte
        {
            get { return varidReporte; }
            set { varidReporte = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProcesoId = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTProcesoCS.TTProcesoFilters[] varProcesoId;
        public TTClassSpecials.FiltersTypes.Dependientes ProcesoId
        {
            get { return varProcesoId; }
            set { varProcesoId = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varFiltroId = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric FiltroId
        {
            get { return varFiltroId; }
            set { varFiltroId = value; }
        }
        private TTReportes_ColumnasFilters varColumnasId = new TTReportes_ColumnasFilters();
        public TTReportes_ColumnasFilters ColumnasId
        {
            get { return varColumnasId; }
            set { varColumnasId = value; }
        }
        private TTReportes_FilasFilters varFilasId = new TTReportes_FilasFilters();
        public TTReportes_FilasFilters FilasId
        {
            get { return varFilasId; }
            set { varFilasId = value; }
        }
        private TTReportes_FuncionesFilters varFuncionesId = new TTReportes_FuncionesFilters();
        public TTReportes_FuncionesFilters FuncionesId
        {
            get { return varFuncionesId; }
            set { varFuncionesId = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipoPresentacion = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTReportes_TipoPresentacionCS.TTReportes_TipoPresentacionFilters[] varTipoPresentacion;
        public TTClassSpecials.FiltersTypes.Dependientes TipoPresentacion
        {
            get { return varTipoPresentacion; }
            set { varTipoPresentacion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varSubtipoPresentacion = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTReportes_SubTipoPresentacionCS.TTReportes_SubTipoPresentacionFilters[] varSubtipoPresentacion;
        public TTClassSpecials.FiltersTypes.Dependientes SubtipoPresentacion
        {
            get { return varSubtipoPresentacion; }
            set { varSubtipoPresentacion = value; }
        }


    }
    public class objectBussinessTTReportes
    {
        public int iProcess = 6799;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTReportesFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidReporte;
        private String varNombre;
        private int? varProcesoId;
        private ControlsLibrary.objectBussinessTTFiltro varFiltroId;
        private objectBussinessTTReportes_Columnas[] varColumnasId;
        private objectBussinessTTReportes_Filas[] varFilasId;
        private objectBussinessTTReportes_Funciones[] varFuncionesId;
        private int? varTipoPresentacion;
        private TTReportsConfigurationsEnumSubPresentation varSubtipoPresentacion;
        private Boolean varDistinct;
        private int? varTopList;
        private String varStoreProcedure;
        private int? varStoreRelationDT;
        private int? varIdGrupoReporte;

        private bool? varTotalesColumna;
        private bool? varTotalesRenglon;
        private bool? varContador;

        private String varOrderClickHeaderCellType = "";
        private String varOrderClickHeaderCell = "";
        public String OrderClickHeaderCell
        {
            get { return varOrderClickHeaderCell; }
            set { varOrderClickHeaderCell = value; }
        }
        public String OrderClickHeaderCellType
        {
            get { return varOrderClickHeaderCellType; }
            set { varOrderClickHeaderCellType = value; }
        }
        public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumns
        {
            get { return myConfigurationColumns; }
            set { myConfigurationColumns = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro[] MyFilters
        {
            get { return myFilters; }
            set { myFilters = value; }
        }
        public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumnsObligatories
        {
            get { return myConfigurationColumnsObligatories; }
            set { myConfigurationColumnsObligatories = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro[] MyFiltersObligatories
        {
            get { return myFiltersObligatories; }
            set { myFiltersObligatories = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro MyFiltersQuick
        {
            get { return myFiltersQuick; }
            set { myFiltersQuick = value; }
        }

        public TTReportesFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTReportesFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTReportesFilters[1];
                filters[0] = value;
            }
        }

        public int? idReporte
        {
            get { return varidReporte; }
            set { varidReporte = value; }
        }
        public String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        public int? ProcesoId
        {
            get { return varProcesoId; }
            set { varProcesoId = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro FiltroId
        {
            get { return varFiltroId; }
            set { varFiltroId = value; }
        }
        public objectBussinessTTReportes_Columnas[] ColumnasId
        {
            get { return varColumnasId; }
            set { varColumnasId = value; }
        }
        public objectBussinessTTReportes_Filas[] FilasId
        {
            get { return varFilasId; }
            set { varFilasId = value; }
        }
        public objectBussinessTTReportes_Funciones[] FuncionesId
        {
            get { return varFuncionesId; }
            set { varFuncionesId = value; }
        }
        public List<KeyValuePair<string,TTReportsConfigurationscells>> FilasHeader { get; set; }
        public List<KeyValuePair<string, TTReportsConfigurationscells>> ColumnasHeader { get; set; }
        
        public List<string> MatrizHeader { get; set; }
        public List<CeldaHtml> CeldasHeader { get; set; }
        public List<KeyValuePair<string, string>> ZonesHeader { get; set; }
        public List<DockStateWithTemplate> DocksHeader { get; set; }

        public List<KeyValuePair<string, TTReportsConfigurationscells>> FilasFooter { get; set; }
        public List<KeyValuePair<string, TTReportsConfigurationscells>> ColumnasFooter { get; set; }

        public List<string> MatrizFooter { get; set; }
        public List<CeldaHtml> CeldasFooter { get; set; }
        public List<KeyValuePair<string, string>> ZonesFooter { get; set; }
        public List<DockStateWithTemplate> DocksFooter { get; set; }

        public int? TipoPresentacion
        {
            get { return varTipoPresentacion; }
            set { varTipoPresentacion = value; }
        }
        public TTReportsConfigurationsEnumSubPresentation SubtipoPresentacion
        {
            get { return varSubtipoPresentacion; }
            set { varSubtipoPresentacion = value; }
        }
        public Boolean Distinct
        {
            get { return varDistinct; }
            set { varDistinct = value; }
        }
        public int? TopList
        {
            get { return varTopList; }
            set { varTopList = value; }
        }
        public String StoreProcedure
        {
            get { return varStoreProcedure; }
            set { varStoreProcedure = value; }
        }
        public int? StoreRelationDT
        {
            get { return varStoreRelationDT; }
            set { varStoreRelationDT = value; }
        }
        public int? IdGrupoReporte
        {
            get { return varIdGrupoReporte; }
            set { varIdGrupoReporte = value; }
        }
        private TTSecurity.GlobalData myUserData;
        public TTSecurity.GlobalData GlobalInformation
        {
            get { return myUserData; }
            set
            {
                myUserData = value;
                FiltroId = new ControlsLibrary.objectBussinessTTFiltro();
                FiltroId.GlobalInformation = myUserData;
            }
        }

        public bool? TotalesColumna
        {
            get { return varTotalesColumna; }
            set { varTotalesColumna = value; }
        }
        public bool? TotalesRenglon
        {
            get { return varTotalesRenglon; }
            set { varTotalesRenglon = value; }
        }
        public bool? Contador
        {
            get { return varContador; }
            set { varContador = value; }
        }

        public objectBussinessTTReportes()
        {
            //myUserData = userGlobalInformation;
        }

        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTReportesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, ""));
            return ds2.Tables[0].Rows.Count;
        }

        public DataSet SelAll(Boolean ConRelaciones)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones == true)
                com.CommandText = "sp_SelAllComplete_TTReportes";
            else
                com.CommandText = "sp_SelAllTTReportes";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTReportesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTReportes", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumns != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += "," + fil.GenerateOrderBy();
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumnsObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += ","+fil.GenerateOrderBy();
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);
            if (varOrderClickHeaderCell != "")
            {
                if (varOrderClickHeaderCellType != " Desc")
                    sOrderBy = varOrderClickHeaderCell + " Asc";
                else
                    sOrderBy = varOrderClickHeaderCell + " Desc";
            }

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy));
            return ds2;
        }

        public DataTable SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones == true)
                com.CommandText = "sp_SelAllComplete_TTReportes";
            else
                com.CommandText = "sp_SelAllTTReportes";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTReportesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTReportes", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumns != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += "," + fil.GenerateOrderBy();
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumnsObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += ","+fil.GenerateOrderBy();
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);
            if (varOrderClickHeaderCell != "")
            {
                if (varOrderClickHeaderCellType != " Desc")
                    sOrderBy = varOrderClickHeaderCell + " Asc";
                else
                    sOrderBy = varOrderClickHeaderCell + " Desc";
            }
            return Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy, CurrentRecordInt32, RecordsDisplayedInt32);
        }
        public Int32 CurrentPosicion(int? Key)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTReportesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTReportes_idReporte"]) == Key)
                    return i;
            }
            return -1;
        }
        public DataSet GetByKey(int? Key, Boolean ConRelaciones)
        {
            DataSet ds;
            if (Key == null)
            {
                //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            else
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                if (ConRelaciones == true)
                    com.CommandText = "sp_GetComplete_TTReportes";
                else
                    com.CommandText = "sp_GetTTReportes";
                com.Parameters.AddWithValue("@idReporte", Key);

                com.CommandType = CommandType.StoredProcedure;
                ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idReporte = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_idReporte"]);
                    Nombre = ds.Tables[0].Rows[0]["TTReportes_Nombre"].ToString().TrimEnd(' ');
                    ProcesoId = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_ProcesoId"]);
                    if (ds.Tables[0].Rows[0]["TTReportes_FiltroId"] != DBNull.Value)
                        FiltroId.GetByKey(Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_FiltroId"]), true);
                    TipoPresentacion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_TipoPresentacion"]);
                    if (ds.Tables[0].Rows[0]["TTReportes_SubtipoPresentacion"] != DBNull.Value)
                        SubtipoPresentacion = (TTReportsConfigurationsEnumSubPresentation)Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_SubtipoPresentacion"]).Value;
                    else
                        SubtipoPresentacion = TTReportsConfigurationsEnumSubPresentation.None;
                    if (ds.Tables[0].Rows[0]["TTReportes_Distinto"].ToString() != "")
                        Distinct = Boolean.Parse(ds.Tables[0].Rows[0]["TTReportes_Distinto"].ToString());
                    TopList = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_TopList"]);
                    StoreProcedure = ds.Tables[0].Rows[0]["TTReportes_StoreProcedure"].ToString().TrimEnd(' ');
                    StoreRelationDT = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_StoreRelationDT"]);
                    IdGrupoReporte = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_IdGrupoReporte"]);

                    if (ds.Tables[0].Rows[0]["TTReportes_TotalesColumna"].ToString() != "")
                        TotalesColumna = Boolean.Parse(ds.Tables[0].Rows[0]["TTReportes_TotalesColumna"].ToString());
                    if (ds.Tables[0].Rows[0]["TTReportes_TotalesRenglon"].ToString() != "")
                        TotalesRenglon = Boolean.Parse(ds.Tables[0].Rows[0]["TTReportes_TotalesRenglon"].ToString());
                    if (ds.Tables[0].Rows[0]["TTReportes_Contador"].ToString() != "")
                        Contador = Boolean.Parse(ds.Tables[0].Rows[0]["TTReportes_Contador"].ToString());
                   

                    {
                        objectBussinessTTReportes_Columnas MyDataColumnasId = new objectBussinessTTReportes_Columnas();
                        TTReportes_ColumnasFilters MyDataFilterColumnasId = new TTReportes_ColumnasFilters();
                        MyDataFilterColumnasId.idReporte.List = new String[1];
                        MyDataFilterColumnasId.idReporte.List[0] = Key.Value.ToString();
                        MyDataColumnasId.Filters = new TTReportes_ColumnasFilters[1];
                        MyDataColumnasId.Filters[0] = MyDataFilterColumnasId;
                        DataSet dsMulti = MyDataColumnasId.SelAll(true);
                        ColumnasId = new objectBussinessTTReportes_Columnas[dsMulti.Tables[0].Rows.Count];
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            ColumnasId[i] = new objectBussinessTTReportes_Columnas();
                            ColumnasId[i].Text = dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Text"].ToString().TrimEnd(' ');
                            ColumnasId[i].FullPath = dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_FullPath"].ToString().TrimEnd(' ');
                            ColumnasId[i].FullPathDT = dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_FullPathDT"].ToString().TrimEnd(' ');
                            ColumnasId[i].Funciones = (TTReportsConfigurationsEnumfunctions)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Funciones"]).Value;
                            ColumnasId[i].Subtotal = Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Subtotal"]);
                            ColumnasId[i].Total = Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Total"]);
                            ColumnasId[i].Minimo_Alerta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Minimo_Alerta"]);
                            ColumnasId[i].Maximo_Alerta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Maximo_Alerta"]);
                            ColumnasId[i].Mostrar_Vacios = Boolean.Parse(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Mostrar_Vacios"].ToString());
                            ColumnasId[i].Format = (TTReportsConfigurationsEnumFormatDate)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Format"]);
                            ColumnasId[i].OrderBy = (TTReportsConfigurationsEnumOrderBy)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_OrderBy"]);
                            ColumnasId[i].Rango = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Columnas_Rango"]);
                        }
                    }
                    {
                        objectBussinessTTReportes_Filas MyDataFilasId = new objectBussinessTTReportes_Filas();
                        TTReportes_FilasFilters MyDataFilterFilasId = new TTReportes_FilasFilters();
                        MyDataFilterFilasId.idReporte.List = new String[1];
                        MyDataFilterFilasId.idReporte.List[0] = Key.Value.ToString();
                        MyDataFilasId.Filters = new TTReportes_FilasFilters[1];
                        MyDataFilasId.Filters[0] = MyDataFilterFilasId;
                        DataSet dsMulti = MyDataFilasId.SelAll(true);
                        FilasId = new objectBussinessTTReportes_Filas[dsMulti.Tables[0].Rows.Count];
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            FilasId[i] = new objectBussinessTTReportes_Filas();
                            FilasId[i].Text = dsMulti.Tables[0].Rows[i]["TTReportes_Filas_Text"].ToString().TrimEnd(' ');
                            FilasId[i].FullPath = dsMulti.Tables[0].Rows[i]["TTReportes_Filas_FullPath"].ToString().TrimEnd(' ');
                            FilasId[i].FullPathDT = dsMulti.Tables[0].Rows[i]["TTReportes_Filas_FullPathDT"].ToString().TrimEnd(' ');
                            FilasId[i].Format = (TTReportsConfigurationsEnumFormatDate)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Filas_format"]);
                            FilasId[i].OrderBy = (TTReportsConfigurationsEnumOrderBy)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Filas_OrderBy"]);
                            FilasId[i].Rango = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Filas_Rango"]);
                        }
                    }
                    {
                        objectBussinessTTReportes_Funciones MyDataFuncionesId = new objectBussinessTTReportes_Funciones();
                        TTReportes_FuncionesFilters MyDataFilterFuncionesId = new TTReportes_FuncionesFilters();
                        MyDataFilterFuncionesId.idReporte.List = new String[1];
                        MyDataFilterFuncionesId.idReporte.List[0] = Key.Value.ToString();
                        MyDataFuncionesId.Filters = new TTReportes_FuncionesFilters[1];
                        MyDataFuncionesId.Filters[0] = MyDataFilterFuncionesId;
                        DataSet dsMulti = MyDataFuncionesId.SelAll(true);
                        FuncionesId = new objectBussinessTTReportes_Funciones[dsMulti.Tables[0].Rows.Count];
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            FuncionesId[i] = new objectBussinessTTReportes_Funciones();
                            FuncionesId[i].Text = dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Text"].ToString().TrimEnd(' ');
                            FuncionesId[i].FullPath = dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_FullPath"].ToString().TrimEnd(' ');
                            FuncionesId[i].FullPathDT = dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_FullPathDT"].ToString().TrimEnd(' ');
                            FuncionesId[i].Funcion = (TTReportsConfigurationsEnumfunctions)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Funcion"]);
                            FuncionesId[i].Minimo_Alerta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Minimo_Alerta"]);
                            FuncionesId[i].Maximo_Alerta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Maximo_Alerta"]);
                            FuncionesId[i].Mostrar_Vacios = Boolean.Parse(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Mostrar_Vacios"].ToString());
                            FuncionesId[i].Format = (TTReportsConfigurationsEnumFormatDate)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_Format"]);
                            FuncionesId[i].OrderBy = (TTReportsConfigurationsEnumOrderBy)Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTReportes_Funciones_OrderBy"]);
                        }
                    }


                    {
                        TTReportsConfigurationscells MyDataFilasHeaderId = new TTReportsConfigurationscells();
                        DataSet dsMulti = MyDataFilasHeaderId.SeeAll(Key.Value, "F");
                        FilasHeader = new List<KeyValuePair<string,TTReportsConfigurationscells>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            TTReportsConfigurationscells ob = new TTReportsConfigurationscells();
                            ob.CM = Convert.ToDouble(dsMulti.Tables[0].Rows[i]["TTReportes_Header_CM"]);
                            FilasHeader.Add(new KeyValuePair<string, TTReportsConfigurationscells>(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Indice"].ToString(), ob));
                        }
                    }

                    {
                        TTReportsConfigurationscells MyDataColumnasHeaderId = new TTReportsConfigurationscells();
                        DataSet dsMulti = MyDataColumnasHeaderId.SeeAll(Key.Value, "C");
                        ColumnasHeader = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            TTReportsConfigurationscells ob = new TTReportsConfigurationscells();
                            ob.CM = Convert.ToDouble(dsMulti.Tables[0].Rows[i]["TTReportes_Header_CM"]);
                            ColumnasHeader.Add(new KeyValuePair<string, TTReportsConfigurationscells>(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Indice"].ToString(), ob));
                        }
                    }

                    {
                        DataSet dsMulti = TTReportsConfigurationsMatriz.SeeAll(Key.Value);
                        MatrizHeader = new List<string>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)                   
                            MatrizHeader.Add(dsMulti.Tables[0].Rows[i]["valor"].ToString());
                    }

                    {
                        DataSet dsMulti = CeldaHtml.SeeAll(Key.Value);
                        CeldasHeader = new List<CeldaHtml>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            CeldaHtml ob = new CeldaHtml(Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Celdas_idReporte"])
                                , dsMulti.Tables[0].Rows[i]["TTReportes_Header_Celdas_Key"].ToString()
                                , Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Celdas_Colspan"])
                                , Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Celdas_Rowspan"])
                                , dsMulti.Tables[0].Rows[i]["TTReportes_Header_Celdas_Row"].ToString());
                            CeldasHeader.Add(ob);
                        }
                    }

                    {
                        TTReportsConfigurationsZones MyDataZonesHeaderId = new TTReportsConfigurationsZones();
                        DataSet dsMulti = MyDataZonesHeaderId.SeeAll(Key.Value);
                        ZonesHeader = new List<KeyValuePair<string, string>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            ZonesHeader.Add(new KeyValuePair<string, string>(
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Zones_Key"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Zones_Colspan"].ToString())
                                );
                        }
                    }

                    {
                        DataSet dsMulti = DockStateWithTemplate.SeeAll(Key.Value);
                        DocksHeader = new List<DockStateWithTemplate>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            DockStateWithTemplate ob = new DockStateWithTemplate(Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Zones_idReporte"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Closed"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Collapsed"]),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_DockZoneID"].ToString(),
                                Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_ExpandedHeight"]),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Height"].ToString()),
                                Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Index"]),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Left"].ToString()),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Pinned"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Resizable"]),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Tag"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Text"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Title"].ToString(),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Top"].ToString()),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_UniqueName"].ToString(),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_Width"].ToString()),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_WithTemplate"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Header_Docks_esTexto"]));
                            DocksHeader.Add(ob);
                        }
                    }


                    {
                        TTReportsConfigurationscells MyDataFilasFooterId = new TTReportsConfigurationscells();
                        DataSet dsMulti = MyDataFilasFooterId.SeeAllFooter(Key.Value, "F");
                        FilasFooter = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            TTReportsConfigurationscells ob = new TTReportsConfigurationscells();
                            ob.CM = Convert.ToDouble(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_CM"]);
                            FilasFooter.Add(new KeyValuePair<string, TTReportsConfigurationscells>(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Indice"].ToString(), ob));
                        }
                    }

                    {
                        TTReportsConfigurationscells MyDataColumnasFooterId = new TTReportsConfigurationscells();
                        DataSet dsMulti = MyDataColumnasFooterId.SeeAllFooter(Key.Value, "C");
                        ColumnasFooter = new List<KeyValuePair<string, TTReportsConfigurationscells>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            TTReportsConfigurationscells ob = new TTReportsConfigurationscells();
                            ob.CM = Convert.ToDouble(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_CM"]);
                            ColumnasFooter.Add(new KeyValuePair<string, TTReportsConfigurationscells>(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Indice"].ToString(), ob));
                        }
                    }

                    {
                        DataSet dsMulti = TTReportsConfigurationsMatriz.SeeAllFooter(Key.Value);
                        MatrizFooter = new List<string>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                            MatrizFooter.Add(dsMulti.Tables[0].Rows[i]["valor"].ToString());
                    }

                    {
                        DataSet dsMulti = CeldaHtml.SeeAllFooter(Key.Value);
                        CeldasFooter = new List<CeldaHtml>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            CeldaHtml ob = new CeldaHtml(Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Celdas_idReporte"])
                                , dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Celdas_Key"].ToString()
                                , Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Celdas_Colspan"])
                                , Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Celdas_Rowspan"])
                                , dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Celdas_Row"].ToString());
                            CeldasFooter.Add(ob);
                        }
                    }

                    {
                        TTReportsConfigurationsZones MyDataZonesFooterId = new TTReportsConfigurationsZones();
                        DataSet dsMulti = MyDataZonesFooterId.SeeAllFooter(Key.Value);
                        ZonesFooter = new List<KeyValuePair<string, string>>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            ZonesFooter.Add(new KeyValuePair<string, string>(
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Zones_Key"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Zones_Colspan"].ToString())
                                );
                        }
                    }

                    {
                        DataSet dsMulti = DockStateWithTemplate.SeeAllFooter(Key.Value);
                        DocksFooter = new List<DockStateWithTemplate>();
                        for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                        {
                            DockStateWithTemplate ob = new DockStateWithTemplate(Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Zones_idReporte"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Closed"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Collapsed"]),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_DockZoneID"].ToString(),
                                Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_ExpandedHeight"]),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Height"].ToString()),
                                Convert.ToInt32(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Index"]),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Left"].ToString()),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Pinned"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Resizable"]),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Tag"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Text"].ToString(),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Title"].ToString(),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Top"].ToString()),
                                dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_UniqueName"].ToString(),
                                new System.Web.UI.WebControls.Unit(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_Width"].ToString()),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_WithTemplate"]),
                                Convert.ToBoolean(dsMulti.Tables[0].Rows[i]["TTReportes_Footer_Docks_esTexto"]));
                            DocksFooter.Add(ob);
                        }
                    }

                }
                return ds;
            }
        }

        public bool Delete(int? Key, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            if (Key == null)
            {
                //MessageBox.Show("Para poder borrar el registro debe proporcionar la llave", "Borrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Boolean result;
                DataReference.Folio = Key.ToString();
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                db.BeginTransaction("TTReportes");
                try
                {
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Columnas Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Filas Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Funciones Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Matriz Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Celdas Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Zones Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Docks Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Matriz Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Celdas Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Zones Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    DataReference.Folio = Key.ToString();
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Docks Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);
                    db.EjecutaDelete(new SqlCommand("Delete from TTReportes_por_Grupo_de_Usuario Where idReporte = '" + Key.ToString() + "'"), UserInformation, DataReference);


                    SqlCommand com = new SqlCommand();
                    com.CommandText = "sp_DelTTReportes";
                    com.Parameters.AddWithValue("@idReporte", Key);

                    com.CommandType = CommandType.StoredProcedure;
                    Boolean bDelete = db.EjecutaDelete(com, UserInformation, DataReference);
                    db.CommitTransaction();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    db.RollBackTransaction("TTReportes");
                    throw ex;
                }
                return result;
            }
        }

        public Int32 Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTReportes");
            Int32 sKey = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTReportes";
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@ProcesoId", Conversion.FormatNull(varProcesoId));
                com.Parameters.AddWithValue("@FiltroId", varFiltroId.Insert(UserInformation, DataReference));
                com.Parameters.AddWithValue("@TipoPresentacion", Conversion.FormatNull(varTipoPresentacion));
                com.Parameters.AddWithValue("@SubtipoPresentacion", Conversion.FormatNull(varSubtipoPresentacion.GetHashCode()));
                com.Parameters.AddWithValue("@Distinto", varDistinct);
                com.Parameters.AddWithValue("@TopList", Conversion.FormatNull(varTopList));
                if (varStoreProcedure != null)
                    com.Parameters.AddWithValue("@StoreProcedure", varStoreProcedure);
                else
                    com.Parameters.AddWithValue("@StoreProcedure", DBNull.Value);
                com.Parameters.AddWithValue("@StoreRelationDT", Conversion.FormatNull(varStoreRelationDT));
                com.Parameters.AddWithValue("@IdGrupoReporte", Conversion.FormatNull(varIdGrupoReporte));

                com.Parameters.AddWithValue("@TotalesColumna", varTotalesColumna);
                com.Parameters.AddWithValue("@TotalesRenglon", varTotalesRenglon);
                com.Parameters.AddWithValue("@Contador", varContador);

                com.CommandType = CommandType.StoredProcedure;
                sKey = Convert.ToInt32(db.EjecutaInsert(com, UserInformation, DataReference));
                for (int i = 0; i < varColumnasId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Columnas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Text", varColumnasId[i].Text);
                    com.Parameters.AddWithValue("@FullPath", varColumnasId[i].FullPath);
                    com.Parameters.AddWithValue("@FullPathDT", varColumnasId[i].FullPathDT);
                    com.Parameters.AddWithValue("@Funciones", varColumnasId[i].Funciones.GetHashCode());
                    com.Parameters.AddWithValue("@Subtotal", varColumnasId[i].Subtotal);
                    com.Parameters.AddWithValue("@Total", varColumnasId[i].Total);
                    com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varColumnasId[i].Minimo_Alerta));
                    com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varColumnasId[i].Maximo_Alerta));
                    com.Parameters.AddWithValue("@Mostrar_Vacios", varColumnasId[i].Mostrar_Vacios);
                    com.Parameters.AddWithValue("@Format", varColumnasId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varColumnasId[i].OrderBy.GetHashCode());
                    com.Parameters.AddWithValue("@Rango", Conversion.FormatNull(varColumnasId[i].Rango));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                for (int i = 0; i < varFilasId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Filas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Text", varFilasId[i].Text);
                    com.Parameters.AddWithValue("@FullPath", varFilasId[i].FullPath);
                    com.Parameters.AddWithValue("@FullPathDT", varFilasId[i].FullPathDT);
                    com.Parameters.AddWithValue("@Format", varFilasId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varFilasId[i].OrderBy.GetHashCode());
                    com.Parameters.AddWithValue("@Rango", Conversion.FormatNull(varFilasId[i].Rango));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                for (int i = 0; i < varFuncionesId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Funciones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Text", varFuncionesId[i].Text);
                    com.Parameters.AddWithValue("@FullPath", varFuncionesId[i].FullPath);
                    com.Parameters.AddWithValue("@FullPathDT", varFuncionesId[i].FullPathDT);
                    com.Parameters.AddWithValue("@Funcion", varFuncionesId[i].Funcion.GetHashCode());
                    com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varFuncionesId[i].Minimo_Alerta));
                    com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varFuncionesId[i].Maximo_Alerta));
                    com.Parameters.AddWithValue("@Mostrar_Vacios", varFuncionesId[i].Mostrar_Vacios);
                    com.Parameters.AddWithValue("@Format", varFuncionesId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varFuncionesId[i].OrderBy.GetHashCode());

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < FilasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", FilasHeader[i].Value.CM);                   
                    com.Parameters.AddWithValue("@Tipo", "F");

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < ColumnasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", ColumnasHeader[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "C");

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < MatrizHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Matriz";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@valor", MatrizHeader[i]);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < CeldasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Celdas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", CeldasHeader[i].Key);
                    com.Parameters.AddWithValue("@colspan", CeldasHeader[i].colspan);
                    com.Parameters.AddWithValue("@rowspan", CeldasHeader[i].rowspan);
                    com.Parameters.AddWithValue("@Row", CeldasHeader[i].Row);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < ZonesHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Zones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", ZonesHeader[i].Key);
                    com.Parameters.AddWithValue("@Celda", ZonesHeader[i].Value);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < DocksHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Docks";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Closed", DocksHeader[i].Closed);
                    com.Parameters.AddWithValue("@Collapsed", DocksHeader[i].Collapsed);
                    com.Parameters.AddWithValue("@DockZoneID", DocksHeader[i].DockZoneID);
                    com.Parameters.AddWithValue("@ExpandedHeight", DocksHeader[i].ExpandedHeight);
                    com.Parameters.AddWithValue("@Height", DocksHeader[i].Height.Value);
                    com.Parameters.AddWithValue("@Index", DocksHeader[i].Index);
                    com.Parameters.AddWithValue("@Left", DocksHeader[i].Left.Value);
                    com.Parameters.AddWithValue("@Pinned", DocksHeader[i].Pinned);
                    com.Parameters.AddWithValue("@Resizable", DocksHeader[i].Resizable);
                    com.Parameters.AddWithValue("@Tag", DocksHeader[i].Tag == null ? "" : DocksHeader[i].Tag);
                    com.Parameters.AddWithValue("@Text", DocksHeader[i].Text);
                    com.Parameters.AddWithValue("@Title", DocksHeader[i].Title);
                    com.Parameters.AddWithValue("@Top", DocksHeader[i].Top.Value);
                    com.Parameters.AddWithValue("@UniqueName", DocksHeader[i].UniqueName);
                    com.Parameters.AddWithValue("@Width", DocksHeader[i].Width.Value);
                    com.Parameters.AddWithValue("@WithTemplate", DocksHeader[i].WithTemplate);
                    com.Parameters.AddWithValue("@esTexto", DocksHeader[i].esTexto);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < FilasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", FilasFooter[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "F");

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < ColumnasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", ColumnasFooter[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "C");

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < MatrizFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Matriz";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@valor", MatrizFooter[i]);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < CeldasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Celdas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", CeldasFooter[i].Key);
                    com.Parameters.AddWithValue("@colspan", CeldasFooter[i].colspan);
                    com.Parameters.AddWithValue("@rowspan", CeldasFooter[i].rowspan);
                    com.Parameters.AddWithValue("@Row", CeldasFooter[i].Row);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < ZonesFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Zones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", ZonesFooter[i].Key);
                    com.Parameters.AddWithValue("@Celda", ZonesFooter[i].Value);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                for (int i = 0; i < DocksFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Docks";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Closed", DocksFooter[i].Closed);
                    com.Parameters.AddWithValue("@Collapsed", DocksFooter[i].Collapsed);
                    com.Parameters.AddWithValue("@DockZoneID", DocksFooter[i].DockZoneID);
                    com.Parameters.AddWithValue("@ExpandedHeight", DocksFooter[i].ExpandedHeight);
                    com.Parameters.AddWithValue("@Height", DocksFooter[i].Height.Value);
                    com.Parameters.AddWithValue("@Index", DocksFooter[i].Index);
                    com.Parameters.AddWithValue("@Left", DocksFooter[i].Left.Value);
                    com.Parameters.AddWithValue("@Pinned", DocksFooter[i].Pinned);
                    com.Parameters.AddWithValue("@Resizable", DocksFooter[i].Resizable);
                    com.Parameters.AddWithValue("@Tag", DocksFooter[i].Tag == null ? "" : DocksFooter[i].Tag);
                    com.Parameters.AddWithValue("@Text", DocksFooter[i].Text);
                    com.Parameters.AddWithValue("@Title", DocksFooter[i].Title);
                    com.Parameters.AddWithValue("@Top", DocksFooter[i].Top.Value);
                    com.Parameters.AddWithValue("@UniqueName", DocksFooter[i].UniqueName);
                    com.Parameters.AddWithValue("@Width", DocksFooter[i].Width.Value);
                    com.Parameters.AddWithValue("@WithTemplate", DocksFooter[i].WithTemplate);
                    com.Parameters.AddWithValue("@esTexto", DocksFooter[i].esTexto);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTReportes");
                throw ex;
            }
            return sKey;
        }
        public Int32 Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTReportes");
            Int32 sKey = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTReportes";
                com.Parameters.AddWithValue("@idReporte", Conversion.FormatNull(varidReporte));
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@ProcesoId", Conversion.FormatNull(varProcesoId));
                com.Parameters.AddWithValue("@FiltroId", varFiltroId.Insert(UserInformation, DataReference));
                com.Parameters.AddWithValue("@TipoPresentacion", Conversion.FormatNull(varTipoPresentacion));
                com.Parameters.AddWithValue("@SubtipoPresentacion", Conversion.FormatNull(varSubtipoPresentacion.GetHashCode()));
                com.Parameters.AddWithValue("@Distinto", varDistinct);
                com.Parameters.AddWithValue("@TopList", Conversion.FormatNull(varTopList));
                if (varStoreProcedure != null)
                    com.Parameters.AddWithValue("@StoreProcedure", varStoreProcedure);
                else
                    com.Parameters.AddWithValue("@StoreProcedure", DBNull.Value);
                com.Parameters.AddWithValue("@StoreRelationDT", Conversion.FormatNull(varStoreRelationDT));
                com.Parameters.AddWithValue("@IdGrupoReporte", Conversion.FormatNull(varIdGrupoReporte));

                com.Parameters.AddWithValue("@TotalesColumna", varTotalesColumna);
                com.Parameters.AddWithValue("@TotalesRenglon", varTotalesRenglon);
                com.Parameters.AddWithValue("@Contador", varContador);

                com.CommandType = CommandType.StoredProcedure;
                sKey = Convert.ToInt32(db.EjecutaUpdate(com, UserInformation, DataReference));
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Columnas Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varColumnasId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Columnas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    if (varColumnasId[i].Text != null)
                        com.Parameters.AddWithValue("@Text", varColumnasId[i].Text);
                    else
                        com.Parameters.AddWithValue("@Text", DBNull.Value);
                    if (varColumnasId[i].FullPath != null)
                        com.Parameters.AddWithValue("@FullPath", varColumnasId[i].FullPath);
                    else
                        com.Parameters.AddWithValue("@FullPath", DBNull.Value);
                    if (varColumnasId[i].FullPathDT != null)
                        com.Parameters.AddWithValue("@FullPathDT", varColumnasId[i].FullPathDT);
                    else
                        com.Parameters.AddWithValue("@FullPathDT", DBNull.Value);
                    com.Parameters.AddWithValue("@Funciones", varColumnasId[i].Funciones.GetHashCode());
                    com.Parameters.AddWithValue("@Subtotal", varColumnasId[i].Subtotal);
                    com.Parameters.AddWithValue("@Total", varColumnasId[i].Total);
                    com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varColumnasId[i].Minimo_Alerta));
                    com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varColumnasId[i].Maximo_Alerta));
                    com.Parameters.AddWithValue("@Mostrar_Vacios", varColumnasId[i].Mostrar_Vacios);
                    com.Parameters.AddWithValue("@Format", varColumnasId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varColumnasId[i].OrderBy.GetHashCode());
                    com.Parameters.AddWithValue("@Rango", Conversion.FormatNull(varColumnasId[i].Rango));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Filas Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varFilasId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Filas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    if (varFilasId[i].Text != null)
                        com.Parameters.AddWithValue("@Text", varFilasId[i].Text);
                    else
                        com.Parameters.AddWithValue("@Text", DBNull.Value);
                    if (varFilasId[i].FullPath != null)
                        com.Parameters.AddWithValue("@FullPath", varFilasId[i].FullPath);
                    else
                        com.Parameters.AddWithValue("@FullPath", DBNull.Value);
                    if (varFilasId[i].FullPathDT != null)
                        com.Parameters.AddWithValue("@FullPathDT", varFilasId[i].FullPathDT);
                    else
                        com.Parameters.AddWithValue("@FullPathDT", DBNull.Value);
                    com.Parameters.AddWithValue("@Format", varFilasId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varFilasId[i].OrderBy.GetHashCode());
                    com.Parameters.AddWithValue("@Rango", Conversion.FormatNull(varFilasId[i].Rango));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Funciones Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varFuncionesId.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Funciones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    if (varFuncionesId[i].Text != null)
                        com.Parameters.AddWithValue("@Text", varFuncionesId[i].Text);
                    else
                        com.Parameters.AddWithValue("@Text", DBNull.Value);
                    if (varFuncionesId[i].FullPath != null)
                        com.Parameters.AddWithValue("@FullPath", varFuncionesId[i].FullPath);
                    else
                        com.Parameters.AddWithValue("@FullPath", DBNull.Value);
                    if (varFuncionesId[i].FullPathDT != null)
                        com.Parameters.AddWithValue("@FullPathDT", varFuncionesId[i].FullPathDT);
                    else
                        com.Parameters.AddWithValue("@FullPathDT", DBNull.Value);
                    com.Parameters.AddWithValue("@Funcion", varFuncionesId[i].Funcion.GetHashCode());
                    com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varFuncionesId[i].Minimo_Alerta));
                    com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varFuncionesId[i].Maximo_Alerta));
                    com.Parameters.AddWithValue("@Mostrar_Vacios", varFuncionesId[i].Mostrar_Vacios);
                    com.Parameters.AddWithValue("@Format", varFuncionesId[i].Format.GetHashCode());
                    com.Parameters.AddWithValue("@OrderBy", varFuncionesId[i].OrderBy.GetHashCode());

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < FilasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", FilasHeader[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "F");
                    com.Parameters.AddWithValue("@indice", FilasHeader[i].Key);
                    
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                for (int i = 0; i < ColumnasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", ColumnasHeader[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "C");
                    com.Parameters.AddWithValue("@indice", ColumnasHeader[i].Key);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Matriz Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < MatrizHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Matriz";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@valor", MatrizHeader[i]);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Celdas Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < CeldasHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Celdas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", CeldasHeader[i].Key);
                    com.Parameters.AddWithValue("@colspan", CeldasHeader[i].colspan);
                    com.Parameters.AddWithValue("@rowspan", CeldasHeader[i].rowspan);
                    com.Parameters.AddWithValue("@Row", CeldasHeader[i].Row);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Zones Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < ZonesHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Zones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", ZonesHeader[i].Key);
                    com.Parameters.AddWithValue("@Celda", ZonesHeader[i].Value);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Header_Docks Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < DocksHeader.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Header_Docks";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Closed", DocksHeader[i].Closed);
                    com.Parameters.AddWithValue("@Collapsed", DocksHeader[i].Collapsed);
                    com.Parameters.AddWithValue("@DockZoneID", DocksHeader[i].DockZoneID);
                    com.Parameters.AddWithValue("@ExpandedHeight", DocksHeader[i].ExpandedHeight);
                    com.Parameters.AddWithValue("@Height", DocksHeader[i].Height.Value);
                    com.Parameters.AddWithValue("@Index", DocksHeader[i].Index);
                    com.Parameters.AddWithValue("@Left", DocksHeader[i].Left.Value);
                    com.Parameters.AddWithValue("@Pinned", DocksHeader[i].Pinned);
                    com.Parameters.AddWithValue("@Resizable", DocksHeader[i].Resizable);
                    com.Parameters.AddWithValue("@Tag", DocksHeader[i].Tag == null ? "" : DocksHeader[i].Tag);
                    com.Parameters.AddWithValue("@Text", DocksHeader[i].Text);
                    com.Parameters.AddWithValue("@Title", DocksHeader[i].Title);
                    com.Parameters.AddWithValue("@Top", DocksHeader[i].Top.Value);
                    com.Parameters.AddWithValue("@UniqueName", DocksHeader[i].UniqueName);
                    com.Parameters.AddWithValue("@Width", DocksHeader[i].Width.Value);
                    com.Parameters.AddWithValue("@WithTemplate", DocksHeader[i].WithTemplate);
                    com.Parameters.AddWithValue("@esTexto", DocksHeader[i].esTexto);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < FilasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", FilasFooter[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "F");
                    com.Parameters.AddWithValue("@indice", FilasFooter[i].Key);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey.ToString();
                for (int i = 0; i < ColumnasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@CM", ColumnasFooter[i].Value.CM);
                    com.Parameters.AddWithValue("@Tipo", "C");
                    com.Parameters.AddWithValue("@indice", ColumnasFooter[i].Key);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Matriz Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < MatrizFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Matriz";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@valor", MatrizFooter[i]);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Celdas Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < CeldasFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Celdas";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", CeldasFooter[i].Key);
                    com.Parameters.AddWithValue("@colspan", CeldasFooter[i].colspan);
                    com.Parameters.AddWithValue("@rowspan", CeldasFooter[i].rowspan);
                    com.Parameters.AddWithValue("@Row", CeldasFooter[i].Row);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Zones Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < ZonesFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Zones";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Key", ZonesFooter[i].Key);
                    com.Parameters.AddWithValue("@Celda", ZonesFooter[i].Value);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                DataReference.Folio = sKey.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTReportes_Footer_Docks Where idReporte = '" + sKey.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < DocksFooter.Count; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTReportes_Footer_Docks";
                    com.Parameters.AddWithValue("@idReporte", sKey);
                    com.Parameters.AddWithValue("@Closed", DocksFooter[i].Closed);
                    com.Parameters.AddWithValue("@Collapsed", DocksFooter[i].Collapsed);
                    com.Parameters.AddWithValue("@DockZoneID", DocksFooter[i].DockZoneID);
                    com.Parameters.AddWithValue("@ExpandedHeight", DocksFooter[i].ExpandedHeight);
                    com.Parameters.AddWithValue("@Height", DocksFooter[i].Height.Value);
                    com.Parameters.AddWithValue("@Index", DocksFooter[i].Index);
                    com.Parameters.AddWithValue("@Left", DocksFooter[i].Left.Value);
                    com.Parameters.AddWithValue("@Pinned", DocksFooter[i].Pinned);
                    com.Parameters.AddWithValue("@Resizable", DocksFooter[i].Resizable);
                    com.Parameters.AddWithValue("@Tag", DocksFooter[i].Tag == null ? "" : DocksFooter[i].Tag);
                    com.Parameters.AddWithValue("@Text", DocksFooter[i].Text);
                    com.Parameters.AddWithValue("@Title", DocksFooter[i].Title);
                    com.Parameters.AddWithValue("@Top", DocksFooter[i].Top.Value);
                    com.Parameters.AddWithValue("@UniqueName", DocksFooter[i].UniqueName);
                    com.Parameters.AddWithValue("@Width", DocksFooter[i].Width.Value);
                    com.Parameters.AddWithValue("@WithTemplate", DocksFooter[i].WithTemplate);
                    com.Parameters.AddWithValue("@esTexto", DocksFooter[i].esTexto);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTReportes");
                throw ex;
            }
            return sKey;
        }

        public Boolean ValidaExistencia(int? Key)
        {
            Boolean result;
            DataSet ds;
            if (Key == null)
            {
                //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTReportes";
            com.Parameters.AddWithValue("@idReporte", Key);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }

        public DataTable FillDataProcesoId(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTProceso";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataProcesoId()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTProceso";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataProcesoIdDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTProceso";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataColumnasId(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Columnas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataColumnasId()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Columnas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataColumnasIdDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Columnas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataFilasId(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Filas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataFilasId()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Filas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataFilasIdDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Filas";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataFuncionesId(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataFuncionesId()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataFuncionesIdDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataTipoPresentacion(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_TipoPresentacion";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataTipoPresentacion()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_TipoPresentacion";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataTipoPresentacionDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_TipoPresentacion";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataSubtipoPresentacion()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_SubTipoPresentacion";
            com.Parameters.AddWithValue("@idTipoPresentacion", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataSubtipoPresentacionDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_SubTipoPresentacion";
            com.Parameters.AddWithValue("@idTipoPresentacion", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataSubtipoPresentacion(int Key)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_SubTipoPresentacion";
            com.Parameters.AddWithValue("@idTipoPresentacion", Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataSubtipoPresentacionDS(int Key)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTReportes_SubTipoPresentacion";
            com.Parameters.AddWithValue("@idTipoPresentacion", Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        public DataTable FillDataStoreRelationDT(String Filtro, int DNTID)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelTTReportes_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID", DNTID);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;
        }
        public DataTable FillDataStoreRelationDT(int DNTID)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelTTReportes_Relacion_TTMetadata";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DNTID", DNTID);
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }
        public DataSet FillDataStoreRelationDTDS(int DNTID)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelTTReportes_Relacion_TTMetadata";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DNTID", DNTID);
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }
        //            public DataTable FillDataIdGrupoReporte(Object ctr, String Filtro)
        public DataTable FillDataIdGrupoReporte(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTGrupo_Reporte";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //FillDataIdGrupoReporteControl(ctr, dt);
            return dt;
        }
        //            public void FillDataIdGrupoReporte(Object ctr){
        public DataTable FillDataIdGrupoReporte()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Relacion_TTGrupo_Reporte";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataIdGrupoReporteControl(ctr, dt);
            return dt;
        }

        public DataTable GetHeader()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTReportes_Header";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idReporte", this.idReporte);
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }

        public DataTable GetFooterr()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTReportes_Footer";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idReporte", this.idReporte);
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }

    }
}