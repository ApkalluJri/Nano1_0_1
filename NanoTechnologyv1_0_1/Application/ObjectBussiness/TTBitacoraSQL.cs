using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTBitacoraSQLCS
{
    public class TTBitacoraSQLFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varIdUsuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varIdUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes IdUsuario{
            get { return varIdUsuario; }
            set { varIdUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTipoSQL = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String TipoSQL
        {
            get { return varTipoSQL; }
            set { varTipoSQL = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFechaHora =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate FechaHora{
            get { return varFechaHora; }
            set { varFechaHora = value; }
        }
        private TTClassSpecials.FiltersTypes.String varComputerName = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String ComputerName
        {
            get { return varComputerName; }
            set { varComputerName = value; }
        }
        private TTClassSpecials.FiltersTypes.String varServerName = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String ServerName
        {
            get { return varServerName; }
            set { varServerName = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDatabaseName = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String DatabaseName
        {
            get { return varDatabaseName; }
            set { varDatabaseName = value; }
        }
        private TTClassSpecials.FiltersTypes.String varSystemName = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String SystemName
        {
            get { return varSystemName; }
            set { varSystemName = value; }
        }
        private TTClassSpecials.FiltersTypes.filDecimal varSystemVersion = new TTClassSpecials.FiltersTypes.filDecimal();
        public TTClassSpecials.FiltersTypes.filDecimal SystemVersion
        {
            get { return varSystemVersion; }
            set { varSystemVersion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varWindowsVersion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String WindowsVersion
        {
            get { return varWindowsVersion; }
            set { varWindowsVersion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCommandSQL = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String CommandSQL
        {
            get { return varCommandSQL; }
            set { varCommandSQL = value; }
        }
        private TTClassSpecials.FiltersTypes.String varFolioSQL = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String FolioSQL
        {
            get { return varFolioSQL; }
            set { varFolioSQL = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProcesoID =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varProcesoID;
        public TTClassSpecials.FiltersTypes.Dependientes ProcesoID{
            get { return varProcesoID; }
            set { varProcesoID = value; }
        }

    }
public class objectBussinessTTBitacoraSQL{
    public int iProcess = 6402;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTBitacoraSQLFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varIdUsuario;
	private String varTipoSQL;
	private DateTime? varFechaHora;
	private String varComputerName;
	private String varServerName;
	private String varDatabaseName;
	private String varSystemName;
	private Decimal? varSystemVersion;
	private String varWindowsVersion;
	private String varCommandSQL;
	private String varFolioSQL;
	private int? varProcesoID;
		
    private String varOrderClickHeaderCellType="";
    private String varOrderClickHeaderCell="";
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
        get { return myFilters;} 
        set { myFilters = value;}
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

    public TTBitacoraSQLFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTBitacoraSQLFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTBitacoraSQLFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? IdUsuario{
        get { return varIdUsuario;}
        set { varIdUsuario = value;}
    }
    public String TipoSQL{
        get { return varTipoSQL;}
        set { varTipoSQL = value;}
    }
    public DateTime? FechaHora{
        get { return varFechaHora;}
        set { varFechaHora = value;}
    }
    public String ComputerName{
        get { return varComputerName;}
        set { varComputerName = value;}
    }
    public String ServerName{
        get { return varServerName;}
        set { varServerName = value;}
    }
    public String DatabaseName{
        get { return varDatabaseName;}
        set { varDatabaseName = value;}
    }
    public String SystemName{
        get { return varSystemName;}
        set { varSystemName = value;}
    }
    public Decimal? SystemVersion{
        get { return varSystemVersion;}
        set { varSystemVersion = value;}
    }
    public String WindowsVersion{
        get { return varWindowsVersion;}
        set { varWindowsVersion = value;}
    }
    public String CommandSQL{
        get { return varCommandSQL;}
        set { varCommandSQL = value;}
    }
    public String FolioSQL{
        get { return varFolioSQL;}
        set { varFolioSQL = value;}
    }
    public int? ProcesoID{
        get { return varProcesoID;}
        set { varProcesoID = value;}
    }


    private String swhere = String.Empty;
    public String sWhere
    {
        get { return swhere; }
        set { swhere = value; }
    }
    private String fullQuery = @"SELECT {0} ORDER BY {1} ";
    public String FullQuery
    {
        get { return fullQuery; }            
    }
    private String fullQueryForExport = @"SELECT {0} ORDER BY {1} ";
    public String FullQueryForExport
    {
        get { return fullQueryForExport; }            
    }
    private int fullQueryCount = 0;
    public int FullQueryCount
    {
        get { return fullQueryCount; }
    }

    public Int32 SelCount()
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            string swhere = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (swhere != "")
        {
            com.Parameters.AddWithValue("@Filter"," where " + swhere);
            com.CommandText = "sp_SelAllComplete_TTBitacoraSQL_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTBitacoraSQL";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTBitacoraSQLCS.TTBitacoraSQLFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraSQL", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, ""));
            return ds2.Tables[0].Rows.Count;
    }

    public DataSet SelAll(Boolean ConRelaciones)
    {
                DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.StoredProcedure;

        String swhere="";
        String sOrderBy = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
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
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_TTBitacoraSQL_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTBitacoraSQL";
        else
            com.CommandText="sp_SelAllTTBitacoraSQL";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTBitacoraSQLCS.TTBitacoraSQLFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraSQL", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBitacoraSQL", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
                sOrderBy = varOrderClickHeaderCell + " Asc";
            else
                sOrderBy = varOrderClickHeaderCell + " Desc";
        }



            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy));
            return ds2;
    }

    //-----------------------------------------------------------Métodos para paginación--------------------------------------------------------------
    public int SelCount(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        
        if (swhere != string.Empty)
                swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

        string sPagingCountTemplate = @"SELECT COUNT(*) {0}";
                  string from = " from (( TTBitacoraSQL WITH(NoLock) LEFT JOIN TTUsuarios WITH(NoLock) ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)        " + swhere; 

        sPagingCountTemplate = string.Format(sPagingCountTemplate, from);

        com.CommandText = sPagingCountTemplate;

        ds = db.Consulta(com);
        fullQueryCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        return fullQueryCount;
    }

    public DataSet SelAll(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
        DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.Text;
        
        String sOrderBy = "";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
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
        //-------------------------------------------------------
        if (this.myFiltersObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
        //-------------------------------------------------------
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (swhere != string.Empty)
            swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

                    switch (sortExpression)             {                 case "TTBitacoraSQL_Folio": sortExpression = "TTBitacoraSQL.Folio"; break;  case "TTBitacoraSQL_IdUsuario": sortExpression = "TTBitacoraSQL.IdUsuario"; break;  case "TTUsuarios_Nombre": sortExpression = "TTUsuarios.Nombre"; break;  case "TTBitacoraSQL_TipoSQL": sortExpression = "TTBitacoraSQL.TipoSQL"; break;  case "TTBitacoraSQL_FechaHora": sortExpression = "TTBitacoraSQL.FechaHora"; break;  case "TTBitacoraSQL_ComputerName": sortExpression = "TTBitacoraSQL.ComputerName"; break;  case "TTBitacoraSQL_ServerName": sortExpression = "TTBitacoraSQL.ServerName"; break;  case "TTBitacoraSQL_DatabaseName": sortExpression = "TTBitacoraSQL.DatabaseName"; break;  case "TTBitacoraSQL_SystemName": sortExpression = "TTBitacoraSQL.SystemName"; break;  case "TTBitacoraSQL_SystemVersion": sortExpression = "TTBitacoraSQL.SystemVersion"; break;  case "TTBitacoraSQL_WindowsVersion": sortExpression = "TTBitacoraSQL.WindowsVersion"; break;  case "TTBitacoraSQL_CommandSQL": sortExpression = "TTBitacoraSQL.CommandSQL"; break;  case "TTBitacoraSQL_FolioSQL": sortExpression = "TTBitacoraSQL.FolioSQL"; break;  case "TTBitacoraSQL_ProcesoID": sortExpression = "TTBitacoraSQL.ProcesoID"; break;  case "TTProceso_Nombre": sortExpression = "TTProceso.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTBitacoraSQL.Folio, TTBitacoraSQL.IdUsuario, TTUsuarios.Nombre, TTBitacoraSQL.TipoSQL, TTBitacoraSQL.FechaHora, TTBitacoraSQL.ComputerName, TTBitacoraSQL.ServerName, TTBitacoraSQL.DatabaseName, TTBitacoraSQL.SystemName, TTBitacoraSQL.SystemVersion, TTBitacoraSQL.WindowsVersion, TTBitacoraSQL.CommandSQL, TTBitacoraSQL.FolioSQL, TTBitacoraSQL.ProcesoID, TTProceso.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre ";             string fieldsForExport = " TTBitacoraSQL.Folio As [Folio],        TTBitacoraSQL.IdUsuario AS [IdUsuario],        TTUsuarios.Nombre AS [Nombre],        TTBitacoraSQL.TipoSQL As [TipoSQL],        TTBitacoraSQL.FechaHora As [FechaHora],        TTBitacoraSQL.ComputerName As [ComputerName],        TTBitacoraSQL.ServerName As [ServerName],        TTBitacoraSQL.DatabaseName As [DatabaseName],        TTBitacoraSQL.SystemName As [SystemName],        TTBitacoraSQL.SystemVersion As [SystemVersion],        TTBitacoraSQL.WindowsVersion As [WindowsVersion],        TTBitacoraSQL.CommandSQL As [CommandSQL],        TTBitacoraSQL.FolioSQL As [FolioSQL],        TTBitacoraSQL.ProcesoID AS [ProcesoID],        TTProceso.Nombre AS [Nombre] ";             string from = " from (( TTBitacoraSQL WITH(NoLock) LEFT JOIN TTUsuarios WITH(NoLock) ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)        " + swhere; 

        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";


        sPagingTemplate = string.Format(sPagingTemplate, sortExpression + " " + sortDirection, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

        fullQuery = string.Format(fullQuery, fieldsWithAlias + " " + from, sortExpression + " " + sortDirection);
        fullQueryForExport = string.Format(fullQueryForExport, fieldsForExport + " " + from, sortExpression + " " + sortDirection);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        

        return ds;
    }
    
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public DataTable SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        String sOrderBy = "";
        String swhere="";
        if (this.myFilters!=null)
            foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
            {
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
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
                String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                if (sWhereT != "")
                    if (swhere == "")
                        swhere = sWhereT;
                    else
                        swhere += " and " + sWhereT;
            }
        if (this.myConfigurationColumnsObligatories != null)
            foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);



        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_TTBitacoraSQL_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTBitacoraSQL";
        else
            com.CommandText="sp_SelAllTTBitacoraSQL";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTBitacoraSQLCS.TTBitacoraSQLFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraSQL", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBitacoraSQL", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
                sOrderBy = varOrderClickHeaderCell + " Asc";
            else
                sOrderBy = varOrderClickHeaderCell + " Desc";
        }
        return Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy, CurrentRecordInt32, RecordsDisplayedInt32);
    }

    private String Convierte(String Valor,Int32 Convierte){
        String ValorConvertido = "";
        if (Convierte == 1)
        {
                ValorConvertido = Valor.ToUpper();
        }else{
                ValorConvertido = Valor;
        }
        return ValorConvertido;
    }

    public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTBitacoraSQL");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTBitacoraSQL";
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            if (varTipoSQL!=null)
                com.Parameters.AddWithValue("@TipoSQL", Convierte(varTipoSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@TipoSQL", DBNull.Value);
            com.Parameters.AddWithValue("@FechaHora",Conversion.FormatNull(varFechaHora));
            if (varComputerName!=null)
                com.Parameters.AddWithValue("@ComputerName", Convierte(varComputerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ComputerName", DBNull.Value);
            if (varServerName!=null)
                com.Parameters.AddWithValue("@ServerName", Convierte(varServerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ServerName", DBNull.Value);
            if (varDatabaseName!=null)
                com.Parameters.AddWithValue("@DatabaseName", Convierte(varDatabaseName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@DatabaseName", DBNull.Value);
            if (varSystemName!=null)
                com.Parameters.AddWithValue("@SystemName", Convierte(varSystemName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@SystemName", DBNull.Value);
            com.Parameters.AddWithValue("@SystemVersion",Conversion.FormatNull(varSystemVersion));
            if (varWindowsVersion!=null)
                com.Parameters.AddWithValue("@WindowsVersion", Convierte(varWindowsVersion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@WindowsVersion", DBNull.Value);
            if (varCommandSQL!=null)
                com.Parameters.AddWithValue("@CommandSQL", Convierte(varCommandSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@CommandSQL", DBNull.Value);
            if (varFolioSQL!=null)
                com.Parameters.AddWithValue("@FolioSQL", Convierte(varFolioSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@FolioSQL", DBNull.Value);
            com.Parameters.AddWithValue("@ProcesoID",Conversion.FormatNull(varProcesoID));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraSQL");
            }
            catch{}
            throw ex; 
        }
        //return sKey;
    }
    
    public object InsertWithReturnValue(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTBitacoraSQL");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTBitacoraSQL";
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            if (varTipoSQL!=null)
                com.Parameters.AddWithValue("@TipoSQL", Convierte(varTipoSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@TipoSQL", DBNull.Value);
            com.Parameters.AddWithValue("@FechaHora",Conversion.FormatNull(varFechaHora));
            if (varComputerName!=null)
                com.Parameters.AddWithValue("@ComputerName", Convierte(varComputerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ComputerName", DBNull.Value);
            if (varServerName!=null)
                com.Parameters.AddWithValue("@ServerName", Convierte(varServerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ServerName", DBNull.Value);
            if (varDatabaseName!=null)
                com.Parameters.AddWithValue("@DatabaseName", Convierte(varDatabaseName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@DatabaseName", DBNull.Value);
            if (varSystemName!=null)
                com.Parameters.AddWithValue("@SystemName", Convierte(varSystemName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@SystemName", DBNull.Value);
            com.Parameters.AddWithValue("@SystemVersion",Conversion.FormatNull(varSystemVersion));
            if (varWindowsVersion!=null)
                com.Parameters.AddWithValue("@WindowsVersion", Convierte(varWindowsVersion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@WindowsVersion", DBNull.Value);
            if (varCommandSQL!=null)
                com.Parameters.AddWithValue("@CommandSQL", Convierte(varCommandSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@CommandSQL", DBNull.Value);
            if (varFolioSQL!=null)
                com.Parameters.AddWithValue("@FolioSQL", Convierte(varFolioSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@FolioSQL", DBNull.Value);
            com.Parameters.AddWithValue("@ProcesoID",Conversion.FormatNull(varProcesoID));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraSQL");
            }
            catch{}
            throw ex; 
        }
        return sKeyFolio;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTBitacoraSQL");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTBitacoraSQL";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            if (varTipoSQL!=null)
                com.Parameters.AddWithValue("@TipoSQL", Convierte(varTipoSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@TipoSQL", DBNull.Value);
            com.Parameters.AddWithValue("@FechaHora",Conversion.FormatNull(varFechaHora));
            if (varComputerName!=null)
                com.Parameters.AddWithValue("@ComputerName", Convierte(varComputerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ComputerName", DBNull.Value);
            if (varServerName!=null)
                com.Parameters.AddWithValue("@ServerName", Convierte(varServerName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@ServerName", DBNull.Value);
            if (varDatabaseName!=null)
                com.Parameters.AddWithValue("@DatabaseName", Convierte(varDatabaseName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@DatabaseName", DBNull.Value);
            if (varSystemName!=null)
                com.Parameters.AddWithValue("@SystemName", Convierte(varSystemName,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@SystemName", DBNull.Value);
            com.Parameters.AddWithValue("@SystemVersion",Conversion.FormatNull(varSystemVersion));
            if (varWindowsVersion!=null)
                com.Parameters.AddWithValue("@WindowsVersion", Convierte(varWindowsVersion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@WindowsVersion", DBNull.Value);
            if (varCommandSQL!=null)
                com.Parameters.AddWithValue("@CommandSQL", Convierte(varCommandSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@CommandSQL", DBNull.Value);
            if (varFolioSQL!=null)
                com.Parameters.AddWithValue("@FolioSQL", Convierte(varFolioSQL,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@FolioSQL", DBNull.Value);
            com.Parameters.AddWithValue("@ProcesoID",Conversion.FormatNull(varProcesoID));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraSQL");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTBitacoraSQL");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTBitacoraSQL";
com.Parameters.AddWithValue("@Folio",KeyFolio);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                try
                {
                    db.RollBackTransaction("TTBitacoraSQL");
                }
                catch{}
                throw ex; 
            }
            return result;
        //}
    }
    private DataSet GetByKey(DataSet ds)
    {
            if (ds.Tables[0].Rows.Count > 0)
            {
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBitacoraSQL_Folio"]);
            IdUsuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBitacoraSQL_IdUsuario"]);
            TipoSQL = ds.Tables[0].Rows[0]["TTBitacoraSQL_TipoSQL"].ToString();
            FechaHora = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["TTBitacoraSQL_FechaHora"]);
            ComputerName = ds.Tables[0].Rows[0]["TTBitacoraSQL_ComputerName"].ToString();
            ServerName = ds.Tables[0].Rows[0]["TTBitacoraSQL_ServerName"].ToString();
            DatabaseName = ds.Tables[0].Rows[0]["TTBitacoraSQL_DatabaseName"].ToString();
            SystemName = ds.Tables[0].Rows[0]["TTBitacoraSQL_SystemName"].ToString();
            SystemVersion = Conversion.CambiaToDecimal(ds.Tables[0].Rows[0]["TTBitacoraSQL_SystemVersion"]);
            WindowsVersion = ds.Tables[0].Rows[0]["TTBitacoraSQL_WindowsVersion"].ToString();
            CommandSQL = ds.Tables[0].Rows[0]["TTBitacoraSQL_CommandSQL"].ToString();
            FolioSQL = ds.Tables[0].Rows[0]["TTBitacoraSQL_FolioSQL"].ToString();
            ProcesoID = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBitacoraSQL_ProcesoID"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyFolio, Boolean ConRelaciones){
        DataSet ds;
        if (KeyFolio == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTBitacoraSQL";
            else
                com.CommandText="sp_GetTTBitacoraSQL";
com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolio(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdUsuario(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.IdUsuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipoSQL(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.TipoSQL = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFechaHora(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.FechaHora = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyComputerName(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.ComputerName = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyServerName(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.ServerName = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDatabaseName(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.DatabaseName = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeySystemName(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.SystemName = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeySystemVersion(Decimal Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.SystemVersion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyWindowsVersion(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.WindowsVersion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCommandSQL(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.CommandSQL = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolioSQL(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.FolioSQL = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyProcesoID(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraSQL.Folio As TTBitacoraSQL_Folio,        TTBitacoraSQL.IdUsuario AS TTBitacoraSQL_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraSQL.TipoSQL As TTBitacoraSQL_TipoSQL,        TTBitacoraSQL.FechaHora As TTBitacoraSQL_FechaHora,        TTBitacoraSQL.ComputerName As TTBitacoraSQL_ComputerName,        TTBitacoraSQL.ServerName As TTBitacoraSQL_ServerName,        TTBitacoraSQL.DatabaseName As TTBitacoraSQL_DatabaseName,        TTBitacoraSQL.SystemName As TTBitacoraSQL_SystemName,        TTBitacoraSQL.SystemVersion As TTBitacoraSQL_SystemVersion,        TTBitacoraSQL.WindowsVersion As TTBitacoraSQL_WindowsVersion,        TTBitacoraSQL.CommandSQL As TTBitacoraSQL_CommandSQL,        TTBitacoraSQL.FolioSQL As TTBitacoraSQL_FolioSQL,        TTBitacoraSQL.ProcesoID AS TTBitacoraSQL_ProcesoID,        TTProceso.Nombre AS TTProceso_Nombre   from (( TTBitacoraSQL       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraSQL.IdUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTBitacoraSQL.ProcesoID)           Where TTBitacoraSQL.ProcesoID = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTBitacoraSQL";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTBitacoraSQLCS.TTBitacoraSQLFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraSQL", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTBitacoraSQL_Folio"]) == KeyFolio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyFolio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTBitacoraSQL";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataIdUsuarioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataIdUsuario(Object ctr, String Filtro){
            public DataTable FillDataIdUsuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTBitacoraSQL_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataIdUsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataIdUsuario(Object ctr){
            public DataTable FillDataIdUsuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTBitacoraSQL_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdUsuarioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataProcesoIDControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdProceso";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdProceso";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdProceso";
                }
            }
*///            public DataTable FillDataProcesoID(Object ctr, String Filtro){
            public DataTable FillDataProcesoID(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTBitacoraSQL_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataProcesoIDControl(ctr, dt);
                return dt;
            }
//            public void FillDataProcesoID(Object ctr){
            public DataTable FillDataProcesoID(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTBitacoraSQL_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataProcesoIDControl(ctr, dt);
                return dt;
            }


        public void applyFilterToObject(Prismaproj.TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter)
        {
            switch (tTSearchAdvancedDataDetails.ControlScreenSearchAdvanced)
            {
                case ControlsLibrary.TypeControlSearchAdvanced.Text:
                    {
                        #region Variable Filter del Bussiness Object para Textos
                        TTClassSpecials.FiltersTypes.String filter = new TTClassSpecials.FiltersTypes.String();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                        {
                            if (tTSearchAdvancedDataDetails.From != "" && tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                            {
                                switch (tTSearchAdvancedDataDetails.ConditionText)
                                {
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Igual:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Igual;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Termine:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Termine;
                                            break;
                                        }
                                }
                                filter.Text = tTSearchAdvancedDataDetails.From;
                            }
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Numeric:
                    {
                        #region Variable Filter del Bussiness Object para Numericos
                        TTClassSpecials.FiltersTypes.Numeric filter = new TTClassSpecials.FiltersTypes.Numeric();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if ((tTSearchAdvancedDataDetails.ConditionText == TTClassSpecials.FiltersTypes.TypesTextFilter.None) && (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != ""))
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Logic:
                    {
                        #region Variable Filter del Bussiness Object para Logicos
                        TTClassSpecials.FiltersTypes.Logic filter = new TTClassSpecials.FiltersTypes.Logic();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.Yes_Not != null)
                            filter.Active = tTSearchAdvancedDataDetails.Yes_Not;
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Money:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Hour:
                    {
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Dependiente:
                    {
                        #region Variable Filter del Bussiness Object para Dependientes
                        TTClassSpecials.FiltersTypes.Dependientes filter = new TTClassSpecials.FiltersTypes.Dependientes();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ListaDependientes.Length >0)
                        {
                            filter.List = new String[tTSearchAdvancedDataDetails.ListaDependientes.Length];
                            for (int i = 0; i < tTSearchAdvancedDataDetails.ListaDependientes.Length; i++)
                                filter.List[i] = tTSearchAdvancedDataDetails.ListaDependientes[i];
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Decimal:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Date:
                    {
                        #region Variable Filter del Bussiness Object para Dates
                        TTClassSpecials.FiltersTypes.filDate filter = new TTClassSpecials.FiltersTypes.filDate();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.FromDate != null || tTSearchAdvancedDataDetails.ToDate != null)
                        {
                            if (tTSearchAdvancedDataDetails.FromDate != null)
                                filter.From = tTSearchAdvancedDataDetails.FromDate;
                            if (tTSearchAdvancedDataDetails.ToDate != null)
                                filter.To = (tTSearchAdvancedDataDetails.ToDate);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Color:
                    {
                        break;
                    }
            }
        }
        public void FiltersObligatories(TTSecurity.GlobalData GlobalInformation)
        {
            DataTable dt;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTtVistasObligatories_X_ProcessAndUser";
            com.Parameters.AddWithValue("@ProcessId", iProcess);
            com.Parameters.AddWithValue("@UserID", GlobalInformation.UserID);
            com.CommandType = CommandType.StoredProcedure;
            dt = db.Consulta(com).Tables[0];
            MyFiltersObligatories = new ControlsLibrary.objectBussinessTTFiltro[dt.Rows.Count];
            MyConfigurationColumnsObligatories = new ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[dt.Rows.Count];
            for (int iViews = 0; iViews < dt.Rows.Count; iViews++)
            {
                int iVistaID = Conversion.CambiaToShort(dt.Rows[iViews]["VistaID"]).Value;
                Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                MyFiltersObligatories[iViews] = MySearch.Filter;
                MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
        public void Print(TTSecurity.GlobalData GlobalInformation)
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }
    private void pd_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs ev)
    {
        float yPos = 0;
        float xWidth = ev.PageSettings.PrintableArea.Width;
        Font printFont = new Font("Arial", 13, FontStyle.Underline);
        Pen pHight = new Pen(Color.Black, 3);
        Pen pLight = new Pen(Color.Black, 1);
        ev.Graphics.DrawString("TTBitacoraSQL", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Folio: " + this.varFolio, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varIdUsuario != null)
        {
            /*TTUsuariosCS.objectBussinessTTUsuarios myRelationWhitTTUsuarios = new TTUsuariosCS.objectBussinessTTUsuarios();
            myRelationWhitTTUsuarios.GetByKeyIdUsuario(this.varIdUsuario);
            ev.Graphics.DrawString("IdUsuario: " + myRelationWhitTTUsuarios.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("IdUsuario: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        ev.Graphics.DrawString("TipoSQL: " + this.varTipoSQL, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("FechaHora: " + this.varFechaHora, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("ComputerName: " + this.varComputerName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre del servidor: " + this.varServerName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Base de datos: " + this.varDatabaseName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre del sistema: " + this.varSystemName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Version del sistema: " + this.varSystemVersion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Version de Windows: " + this.varWindowsVersion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("CommandSQL: " + this.varCommandSQL, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("FolioSQL: " + this.varFolioSQL, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varProcesoID != null)
        {
            /*TTProcesoCS.objectBussinessTTProceso myRelationWhitTTProceso = new TTProcesoCS.objectBussinessTTProceso();
            myRelationWhitTTProceso.GetByKeyIdProceso(this.varProcesoID);
            ev.Graphics.DrawString("ProcesoID: " + myRelationWhitTTProceso.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("ProcesoID: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "13115")
            {
                this.Filters[indexFilter].Folio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13116")
            {
                this.Filters[indexFilter].IdUsuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTUsuariosCS.TTUsuariosFilters[])filter;
            }
            if (sDTid == "13117")
            {
                this.Filters[indexFilter].TipoSQL = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13118")
            {
                this.Filters[indexFilter].FechaHora = (TTClassSpecials.FiltersTypes.filDate)filter;
            }
            if (sDTid == "13119")
            {
                this.Filters[indexFilter].ComputerName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13120")
            {
                this.Filters[indexFilter].ServerName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13121")
            {
                this.Filters[indexFilter].DatabaseName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13122")
            {
                this.Filters[indexFilter].SystemName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13123")
            {
                this.Filters[indexFilter].SystemVersion = (TTClassSpecials.FiltersTypes.filDecimal)filter;
            }
            if (sDTid == "13124")
            {
                this.Filters[indexFilter].WindowsVersion = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13125")
            {
                this.Filters[indexFilter].CommandSQL = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13126")
            {
                this.Filters[indexFilter].FolioSQL = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13127")
            {
                this.Filters[indexFilter].ProcesoID = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProcesoCS.TTProcesoFilters[])filter;
            }

            */
        }
    }
}