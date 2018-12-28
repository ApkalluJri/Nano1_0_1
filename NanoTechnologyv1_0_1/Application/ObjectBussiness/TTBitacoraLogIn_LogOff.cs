using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTBitacoraLogIn_LogOffCS
{
    public class TTBitacoraLogIn_LogOffFilters
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
        private TTClassSpecials.FiltersTypes.filDate  varFechaHora_Entrada =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate FechaHora_Entrada{
            get { return varFechaHora_Entrada; }
            set { varFechaHora_Entrada = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFechaHora_Salida =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate FechaHora_Salida{
            get { return varFechaHora_Salida; }
            set { varFechaHora_Salida = value; }
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

    }
public class objectBussinessTTBitacoraLogIn_LogOff{
    public int iProcess = 6400;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTBitacoraLogIn_LogOffFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varIdUsuario;
	private DateTime? varFechaHora_Entrada;
	private DateTime? varFechaHora_Salida;
	private String varComputerName;
	private String varServerName;
	private String varDatabaseName;
	private String varSystemName;
	private Decimal? varSystemVersion;
	private String varWindowsVersion;
		
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

    public TTBitacoraLogIn_LogOffFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTBitacoraLogIn_LogOffFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTBitacoraLogIn_LogOffFilters[1];
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
    public DateTime? FechaHora_Entrada{
        get { return varFechaHora_Entrada;}
        set { varFechaHora_Entrada = value;}
    }
    public DateTime? FechaHora_Salida{
        get { return varFechaHora_Salida;}
        set { varFechaHora_Salida = value;}
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
            com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTBitacoraLogIn_LogOffCS.TTBitacoraLogIn_LogOffFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraLogIn_LogOff", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff";
        else
            com.CommandText="sp_SelAllTTBitacoraLogIn_LogOff";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTBitacoraLogIn_LogOffCS.TTBitacoraLogIn_LogOffFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraLogIn_LogOff", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBitacoraLogIn_LogOff", fil);
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
                  string from = " from ( TTBitacoraLogIn_LogOff WITH(NoLock) LEFT JOIN TTUsuarios WITH(NoLock) ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTBitacoraLogIn_LogOff_Folio": sortExpression = "TTBitacoraLogIn_LogOff.Folio"; break;  case "TTBitacoraLogIn_LogOff_IdUsuario": sortExpression = "TTBitacoraLogIn_LogOff.IdUsuario"; break;  case "TTUsuarios_Nombre": sortExpression = "TTUsuarios.Nombre"; break;  case "TTBitacoraLogIn_LogOff_FechaHora_Entrada": sortExpression = "TTBitacoraLogIn_LogOff.FechaHora_Entrada"; break;  case "TTBitacoraLogIn_LogOff_FechaHora_Salida": sortExpression = "TTBitacoraLogIn_LogOff.FechaHora_Salida"; break;  case "TTBitacoraLogIn_LogOff_ComputerName": sortExpression = "TTBitacoraLogIn_LogOff.ComputerName"; break;  case "TTBitacoraLogIn_LogOff_ServerName": sortExpression = "TTBitacoraLogIn_LogOff.ServerName"; break;  case "TTBitacoraLogIn_LogOff_DatabaseName": sortExpression = "TTBitacoraLogIn_LogOff.DatabaseName"; break;  case "TTBitacoraLogIn_LogOff_SystemName": sortExpression = "TTBitacoraLogIn_LogOff.SystemName"; break;  case "TTBitacoraLogIn_LogOff_SystemVersion": sortExpression = "TTBitacoraLogIn_LogOff.SystemVersion"; break;  case "TTBitacoraLogIn_LogOff_WindowsVersion": sortExpression = "TTBitacoraLogIn_LogOff.WindowsVersion"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTBitacoraLogIn_LogOff.Folio, TTBitacoraLogIn_LogOff.IdUsuario, TTUsuarios.Nombre, TTBitacoraLogIn_LogOff.FechaHora_Entrada, TTBitacoraLogIn_LogOff.FechaHora_Salida, TTBitacoraLogIn_LogOff.ComputerName, TTBitacoraLogIn_LogOff.ServerName, TTBitacoraLogIn_LogOff.DatabaseName, TTBitacoraLogIn_LogOff.SystemName, TTBitacoraLogIn_LogOff.SystemVersion, TTBitacoraLogIn_LogOff.WindowsVersion" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion ";             string fieldsForExport = " TTBitacoraLogIn_LogOff.Folio As [Folio],        TTBitacoraLogIn_LogOff.IdUsuario AS [IdUsuario],        TTUsuarios.Nombre AS [Nombre],        TTBitacoraLogIn_LogOff.FechaHora_Entrada As [FechaHora Entrada],        TTBitacoraLogIn_LogOff.FechaHora_Salida As [FechaHora Salida],        TTBitacoraLogIn_LogOff.ComputerName As [ComputerName],        TTBitacoraLogIn_LogOff.ServerName As [ServerName],        TTBitacoraLogIn_LogOff.DatabaseName As [DatabaseName],        TTBitacoraLogIn_LogOff.SystemName As [SystemName],        TTBitacoraLogIn_LogOff.SystemVersion As [SystemVersion],        TTBitacoraLogIn_LogOff.WindowsVersion As [WindowsVersion] ";             string from = " from ( TTBitacoraLogIn_LogOff WITH(NoLock) LEFT JOIN TTUsuarios WITH(NoLock) ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)        " + swhere; 

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
                com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff";
        else
            com.CommandText="sp_SelAllTTBitacoraLogIn_LogOff";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTBitacoraLogIn_LogOffCS.TTBitacoraLogIn_LogOffFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraLogIn_LogOff", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBitacoraLogIn_LogOff", fil);
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

        db.BeginTransaction("TTBitacoraLogIn_LogOff");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTBitacoraLogIn_LogOff";
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            com.Parameters.AddWithValue("@FechaHora_Entrada",Conversion.FormatNull(varFechaHora_Entrada));
            com.Parameters.AddWithValue("@FechaHora_Salida",Conversion.FormatNull(varFechaHora_Salida));
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

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraLogIn_LogOff");
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

        db.BeginTransaction("TTBitacoraLogIn_LogOff");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTBitacoraLogIn_LogOff";
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            com.Parameters.AddWithValue("@FechaHora_Entrada",Conversion.FormatNull(varFechaHora_Entrada));
            com.Parameters.AddWithValue("@FechaHora_Salida",Conversion.FormatNull(varFechaHora_Salida));
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

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraLogIn_LogOff");
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

        db.BeginTransaction("TTBitacoraLogIn_LogOff");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTBitacoraLogIn_LogOff";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            com.Parameters.AddWithValue("@FechaHora_Entrada",Conversion.FormatNull(varFechaHora_Entrada));
            com.Parameters.AddWithValue("@FechaHora_Salida",Conversion.FormatNull(varFechaHora_Salida));
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

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTBitacoraLogIn_LogOff");
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
            db.BeginTransaction("TTBitacoraLogIn_LogOff");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTBitacoraLogIn_LogOff";
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
                    db.RollBackTransaction("TTBitacoraLogIn_LogOff");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_Folio"]);
            IdUsuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_IdUsuario"]);
            FechaHora_Entrada = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_FechaHora_Entrada"]);
            FechaHora_Salida = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_FechaHora_Salida"]);
            ComputerName = ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_ComputerName"].ToString();
            ServerName = ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_ServerName"].ToString();
            DatabaseName = ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_DatabaseName"].ToString();
            SystemName = ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_SystemName"].ToString();
            SystemVersion = Conversion.CambiaToDecimal(ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_SystemVersion"]);
            WindowsVersion = ds.Tables[0].Rows[0]["TTBitacoraLogIn_LogOff_WindowsVersion"].ToString();



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
                com.CommandText="sp_GetComplete_TTBitacoraLogIn_LogOff";
            else
                com.CommandText="sp_GetTTBitacoraLogIn_LogOff";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.Folio = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.IdUsuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFechaHora_Entrada(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.FechaHora_Entrada = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFechaHora_Salida(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.FechaHora_Salida = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.ComputerName = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.ServerName = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.DatabaseName = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.SystemName = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.SystemVersion = '" + Key + "'";
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
            com.CommandText="Select         TTBitacoraLogIn_LogOff.Folio As TTBitacoraLogIn_LogOff_Folio,        TTBitacoraLogIn_LogOff.IdUsuario AS TTBitacoraLogIn_LogOff_IdUsuario,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        TTBitacoraLogIn_LogOff.FechaHora_Entrada As TTBitacoraLogIn_LogOff_FechaHora_Entrada,        TTBitacoraLogIn_LogOff.FechaHora_Salida As TTBitacoraLogIn_LogOff_FechaHora_Salida,        TTBitacoraLogIn_LogOff.ComputerName As TTBitacoraLogIn_LogOff_ComputerName,        TTBitacoraLogIn_LogOff.ServerName As TTBitacoraLogIn_LogOff_ServerName,        TTBitacoraLogIn_LogOff.DatabaseName As TTBitacoraLogIn_LogOff_DatabaseName,        TTBitacoraLogIn_LogOff.SystemName As TTBitacoraLogIn_LogOff_SystemName,        TTBitacoraLogIn_LogOff.SystemVersion As TTBitacoraLogIn_LogOff_SystemVersion,        TTBitacoraLogIn_LogOff.WindowsVersion As TTBitacoraLogIn_LogOff_WindowsVersion   from ( TTBitacoraLogIn_LogOff       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=TTBitacoraLogIn_LogOff.IdUsuario)           Where TTBitacoraLogIn_LogOff.WindowsVersion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTBitacoraLogIn_LogOff";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTBitacoraLogIn_LogOffCS.TTBitacoraLogIn_LogOffFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBitacoraLogIn_LogOff", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTBitacoraLogIn_LogOff_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTBitacoraLogIn_LogOff";
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
                com.CommandText = "sp_selTTBitacoraLogIn_LogOff_Relacion_TTUsuarios";
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
                com.CommandText = "sp_selTTBitacoraLogIn_LogOff_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdUsuarioControl(ctr, dt);
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
        ev.Graphics.DrawString("TTBitacoraLogIn_LogOff", printFont, Brushes.Black, 80, yPos, new StringFormat());
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

        ev.Graphics.DrawString("Fecha de Entrada: " + this.varFechaHora_Entrada, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Fecha de Salida: " + this.varFechaHora_Salida, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("ComputerName: " + this.varComputerName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre del servidor: " + this.varServerName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Base de datos: " + this.varDatabaseName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre del sistema: " + this.varSystemName, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Version: " + this.varSystemVersion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Version de Windows: " + this.varWindowsVersion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "13103")
            {
                this.Filters[indexFilter].Folio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13104")
            {
                this.Filters[indexFilter].IdUsuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTUsuariosCS.TTUsuariosFilters[])filter;
            }
            if (sDTid == "13105")
            {
                this.Filters[indexFilter].FechaHora_Entrada = (TTClassSpecials.FiltersTypes.filDate)filter;
            }
            if (sDTid == "13106")
            {
                this.Filters[indexFilter].FechaHora_Salida = (TTClassSpecials.FiltersTypes.filDate)filter;
            }
            if (sDTid == "13107")
            {
                this.Filters[indexFilter].ComputerName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13108")
            {
                this.Filters[indexFilter].ServerName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13109")
            {
                this.Filters[indexFilter].DatabaseName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13110")
            {
                this.Filters[indexFilter].SystemName = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13111")
            {
                this.Filters[indexFilter].SystemVersion = (TTClassSpecials.FiltersTypes.filDecimal)filter;
            }
            if (sDTid == "13112")
            {
                this.Filters[indexFilter].WindowsVersion = (TTClassSpecials.FiltersTypes.String)filter;
            }

            */
        }
    }
}