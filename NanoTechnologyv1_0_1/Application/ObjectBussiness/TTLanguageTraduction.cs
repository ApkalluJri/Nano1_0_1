using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTLanguageTraductionCS
{
    public class TTLanguageTraductionFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varidTraduction =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idTraduction{
            get { return varidTraduction; }
            set { varidTraduction = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTexto = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Texto
        {
            get { return varTexto; }
            set { varTexto = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varIdioma =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTLanguageCS.TTLanguageFilters[] varIdioma;
        public TTClassSpecials.FiltersTypes.Dependientes Idioma{
            get { return varIdioma; }
            set { varIdioma = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRelacionProceso =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varRelacionProceso;
        public TTClassSpecials.FiltersTypes.Dependientes RelacionProceso{
            get { return varRelacionProceso; }
            set { varRelacionProceso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRelacionDominio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDNTCS.TTDNTFilters[] varRelacionDominio;
        public TTClassSpecials.FiltersTypes.Dependientes RelacionDominio{
            get { return varRelacionDominio; }
            set { varRelacionDominio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRelacionDT =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varRelacionDT;
        public TTClassSpecials.FiltersTypes.Dependientes RelacionDT{
            get { return varRelacionDT; }
            set { varRelacionDT = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varRelacionMessage =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric RelacionMessage{
            get { return varRelacionMessage; }
            set { varRelacionMessage = value; }
        }

    }
public class objectBussinessTTLanguageTraduction{
    public int iProcess = 6833;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTLanguageTraductionFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varidTraduction;
	private String varTexto;
	private int? varIdioma;
	private int? varRelacionProceso;
	private int? varRelacionDominio;
	private int? varRelacionDT;
	private int? varRelacionMessage;
		
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

    public TTLanguageTraductionFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTLanguageTraductionFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTLanguageTraductionFilters[1];
            filters[0] = value;
        }
    }

    public int? idTraduction{
        get { return varidTraduction;}
        set { varidTraduction = value;}
    }
    public String Texto{
        get { return varTexto;}
        set { varTexto = value;}
    }
    public int? Idioma{
        get { return varIdioma;}
        set { varIdioma = value;}
    }
    public int? RelacionProceso{
        get { return varRelacionProceso;}
        set { varRelacionProceso = value;}
    }
    public int? RelacionDominio{
        get { return varRelacionDominio;}
        set { varRelacionDominio = value;}
    }
    public int? RelacionDT{
        get { return varRelacionDT;}
        set { varRelacionDT = value;}
    }
    public int? RelacionMessage{
        get { return varRelacionMessage;}
        set { varRelacionMessage = value;}
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
            com.CommandText = "sp_SelAllComplete_TTLanguageTraduction_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTLanguageTraduction";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTLanguageTraductionCS.TTLanguageTraductionFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTLanguageTraduction", fil);
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
                com.CommandText = "sp_SelAllComplete_TTLanguageTraduction_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTLanguageTraduction";
        else
            com.CommandText="sp_SelAllTTLanguageTraduction";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTLanguageTraductionCS.TTLanguageTraductionFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTLanguageTraduction", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTLanguageTraduction", fil);
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
                  string from = " from (((( TTLanguageTraduction WITH(NoLock) LEFT JOIN TTLanguage WITH(NoLock) ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT WITH(NoLock) ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata WITH(NoLock) ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTLanguageTraduction_idTraduction": sortExpression = "TTLanguageTraduction.idTraduction"; break;  case "TTLanguageTraduction_Texto": sortExpression = "TTLanguageTraduction.Texto"; break;  case "TTLanguageTraduction_Idioma": sortExpression = "TTLanguageTraduction.Idioma"; break;  case "TTLanguage_Idioma": sortExpression = "TTLanguage.Idioma"; break;  case "TTLanguageTraduction_RelacionProceso": sortExpression = "TTLanguageTraduction.RelacionProceso"; break;  case "TTProceso_Nombre": sortExpression = "TTProceso.Nombre"; break;  case "TTLanguageTraduction_RelacionDominio": sortExpression = "TTLanguageTraduction.RelacionDominio"; break;  case "TTDNT_Nombre_Tabla": sortExpression = "TTDNT.Nombre_Tabla"; break;  case "TTLanguageTraduction_RelacionDT": sortExpression = "TTLanguageTraduction.RelacionDT"; break;  case "TTMetadata_Nombre": sortExpression = "TTMetadata.Nombre"; break;  case "TTLanguageTraduction_RelacionMessage": sortExpression = "TTLanguageTraduction.RelacionMessage"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTLanguageTraduction.idTraduction, TTLanguageTraduction.Texto, TTLanguageTraduction.Idioma, TTLanguage.Idioma, TTLanguageTraduction.RelacionProceso, TTProceso.Nombre, TTLanguageTraduction.RelacionDominio, TTDNT.Nombre_Tabla, TTLanguageTraduction.RelacionDT, TTMetadata.Nombre, TTLanguageTraduction.RelacionMessage" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage ";             string fieldsForExport = " TTLanguageTraduction.idTraduction As [idTraduction],        TTLanguageTraduction.Texto As [Texto],        TTLanguageTraduction.Idioma AS [Idioma],        TTLanguage.Idioma AS [Idioma],        TTLanguageTraduction.RelacionProceso AS [RelacionProceso],        TTProceso.Nombre AS [Nombre],        TTLanguageTraduction.RelacionDominio AS [RelacionDominio],        TTDNT.Nombre_Tabla AS [Nombre Tabla],        TTLanguageTraduction.RelacionDT AS [RelacionDT],        TTMetadata.Nombre AS [Nombre],        TTLanguageTraduction.RelacionMessage As [RelacionMessage] ";             string from = " from (((( TTLanguageTraduction WITH(NoLock) LEFT JOIN TTLanguage WITH(NoLock) ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT WITH(NoLock) ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata WITH(NoLock) ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)        " + swhere; 

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
                com.CommandText = "sp_SelAllComplete_TTLanguageTraduction_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTLanguageTraduction";
        else
            com.CommandText="sp_SelAllTTLanguageTraduction";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTLanguageTraductionCS.TTLanguageTraductionFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTLanguageTraduction", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTLanguageTraduction", fil);
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

        db.BeginTransaction("TTLanguageTraduction");
        int? sKeyidTraduction = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTLanguageTraduction";
            if (varTexto!=null)
                com.Parameters.AddWithValue("@Texto", Convierte(varTexto,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Texto", DBNull.Value);
            com.Parameters.AddWithValue("@Idioma",Conversion.FormatNull(varIdioma));
            com.Parameters.AddWithValue("@RelacionProceso",Conversion.FormatNull(varRelacionProceso));
            com.Parameters.AddWithValue("@RelacionDominio",Conversion.FormatNull(varRelacionDominio));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionMessage",Conversion.FormatNull(varRelacionMessage));

            com.CommandType =CommandType.StoredProcedure;
            sKeyidTraduction = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidTraduction = sKeyidTraduction;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTLanguageTraduction");
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

        db.BeginTransaction("TTLanguageTraduction");
        int? sKeyidTraduction = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTLanguageTraduction";
            if (varTexto!=null)
                com.Parameters.AddWithValue("@Texto", Convierte(varTexto,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Texto", DBNull.Value);
            com.Parameters.AddWithValue("@Idioma",Conversion.FormatNull(varIdioma));
            com.Parameters.AddWithValue("@RelacionProceso",Conversion.FormatNull(varRelacionProceso));
            com.Parameters.AddWithValue("@RelacionDominio",Conversion.FormatNull(varRelacionDominio));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionMessage",Conversion.FormatNull(varRelacionMessage));

            com.CommandType =CommandType.StoredProcedure;
            sKeyidTraduction = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidTraduction = sKeyidTraduction;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTLanguageTraduction");
            }
            catch{}
            throw ex; 
        }
        return sKeyidTraduction;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTLanguageTraduction");
        int? sKeyidTraduction = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTLanguageTraduction";
            com.Parameters.AddWithValue("@idTraduction",Conversion.FormatNull(varidTraduction));
            if (varTexto!=null)
                com.Parameters.AddWithValue("@Texto", Convierte(varTexto,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Texto", DBNull.Value);
            com.Parameters.AddWithValue("@Idioma",Conversion.FormatNull(varIdioma));
            com.Parameters.AddWithValue("@RelacionProceso",Conversion.FormatNull(varRelacionProceso));
            com.Parameters.AddWithValue("@RelacionDominio",Conversion.FormatNull(varRelacionDominio));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionMessage",Conversion.FormatNull(varRelacionMessage));

            com.CommandType =CommandType.StoredProcedure;
            sKeyidTraduction = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varidTraduction = sKeyidTraduction;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTLanguageTraduction");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyidTraduction, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyidTraduction.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTLanguageTraduction");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTLanguageTraduction";
com.Parameters.AddWithValue("@idTraduction",KeyidTraduction);
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
                    db.RollBackTransaction("TTLanguageTraduction");
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
            idTraduction = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_idTraduction"]);
            Texto = ds.Tables[0].Rows[0]["TTLanguageTraduction_Texto"].ToString();
            Idioma = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_Idioma"]);
            RelacionProceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_RelacionProceso"]);
            RelacionDominio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_RelacionDominio"]);
            RelacionDT = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_RelacionDT"]);
            RelacionMessage = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTLanguageTraduction_RelacionMessage"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyidTraduction, Boolean ConRelaciones){
        DataSet ds;
        if (KeyidTraduction == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTLanguageTraduction";
            else
                com.CommandText="sp_GetTTLanguageTraduction";
com.Parameters.AddWithValue("@idTraduction",KeyidTraduction);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyidTraduction(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.idTraduction = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTexto(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.Texto = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdioma(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.Idioma = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRelacionProceso(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.RelacionProceso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRelacionDominio(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.RelacionDominio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRelacionDT(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.RelacionDT = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRelacionMessage(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTLanguageTraduction.idTraduction As TTLanguageTraduction_idTraduction,        TTLanguageTraduction.Texto As TTLanguageTraduction_Texto,        TTLanguageTraduction.Idioma AS TTLanguageTraduction_Idioma,        TTLanguage.Idioma AS TTLanguage_Idioma,        TTLanguageTraduction.RelacionProceso AS TTLanguageTraduction_RelacionProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTLanguageTraduction.RelacionDominio AS TTLanguageTraduction_RelacionDominio,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla,        TTLanguageTraduction.RelacionDT AS TTLanguageTraduction_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTLanguageTraduction.RelacionMessage As TTLanguageTraduction_RelacionMessage   from (((( TTLanguageTraduction       LEFT JOIN TTLanguage ON TTLanguage.idLanguage=TTLanguageTraduction.Idioma)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTLanguageTraduction.RelacionProceso)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTLanguageTraduction.RelacionDominio)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTLanguageTraduction.RelacionDT)           Where TTLanguageTraduction.RelacionMessage = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyidTraduction)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTLanguageTraduction";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTLanguageTraductionCS.TTLanguageTraductionFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTLanguageTraduction", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTLanguageTraduction_idTraduction"]) == KeyidTraduction)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyidTraduction){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTLanguageTraduction";
com.Parameters.AddWithValue("@idTraduction",KeyidTraduction);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataIdiomaControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Idioma";
                        ((ComboBox)ctr).ValueMember = "idLanguage";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Idioma"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Idioma";
                        ((ListBox)ctr).ValueMember = "idLanguage";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Idioma";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idLanguage";
                }
            }
*///            public DataTable FillDataIdioma(Object ctr, String Filtro){
            public DataTable FillDataIdioma(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTLanguage";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataIdiomaControl(ctr, dt);
                return dt;
            }
//            public void FillDataIdioma(Object ctr){
            public DataTable FillDataIdioma(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTLanguage";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdiomaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRelacionProcesoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataRelacionProceso(Object ctr, String Filtro){
            public DataTable FillDataRelacionProceso(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRelacionProcesoControl(ctr, dt);
                return dt;
            }
//            public void FillDataRelacionProceso(Object ctr){
            public DataTable FillDataRelacionProceso(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRelacionProcesoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRelacionDominioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ComboBox)ctr).ValueMember = "DNTID";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre_Tabla"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ListBox)ctr).ValueMember = "DNTID";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre_Tabla";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "DNTID";
                }
            }
*///            public DataTable FillDataRelacionDominio(Object ctr, String Filtro){
            public DataTable FillDataRelacionDominio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRelacionDominioControl(ctr, dt);
                return dt;
            }
//            public void FillDataRelacionDominio(Object ctr){
            public DataTable FillDataRelacionDominio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRelacionDominioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRelacionDTControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "DTID";
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
                        ((ListBox)ctr).ValueMember = "DTID";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "DTID";
                }
            }
*///        public void FillDataRelacionDT(Object ctr){
        public DataTable FillDataRelacionDT(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataRelacionDTControl(ctr, dt);
            return dt;
        }
        //public void FillDataRelacionDT(Object ctr, int Key){
        public DataTable FillDataRelacionDT(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTLanguageTraduction_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataRelacionDTControl(ctr, dt);
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
        ev.Graphics.DrawString("TTLanguageTraduction", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Folio: " + this.varidTraduction, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Texto: " + this.varTexto, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varIdioma != null)
        {
            /*TTLanguageCS.objectBussinessTTLanguage myRelationWhitTTLanguage = new TTLanguageCS.objectBussinessTTLanguage();
            myRelationWhitTTLanguage.GetByKeyidLanguage(this.varIdioma);
            ev.Graphics.DrawString("Idioma: " + myRelationWhitTTLanguage.Idioma , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Idioma: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varRelacionProceso != null)
        {
            /*TTProcesoCS.objectBussinessTTProceso myRelationWhitTTProceso = new TTProcesoCS.objectBussinessTTProceso();
            myRelationWhitTTProceso.GetByKeyIdProceso(this.varRelacionProceso);
            ev.Graphics.DrawString("RelacionProceso: " + myRelationWhitTTProceso.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("RelacionProceso: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varRelacionDominio != null)
        {
            /*TTDNTCS.objectBussinessTTDNT myRelationWhitTTDNT = new TTDNTCS.objectBussinessTTDNT();
            myRelationWhitTTDNT.GetByKeyDNTID(this.varRelacionDominio);
            ev.Graphics.DrawString("RelacionDominio: " + myRelationWhitTTDNT.Nombre_Tabla , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("RelacionDominio: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varRelacionDT != null)
        {
            /*TTMetadataCS.objectBussinessTTMetadata myRelationWhitTTMetadata = new TTMetadataCS.objectBussinessTTMetadata();
            myRelationWhitTTMetadata.GetByKeyDTID(this.varRelacionDT);
            ev.Graphics.DrawString("RelacionDT: " + myRelationWhitTTMetadata.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("RelacionDT: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        ev.Graphics.DrawString("RelacionMessage: " + this.varRelacionMessage, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "30058")
            {
                this.Filters[indexFilter].idTraduction = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30059")
            {
                this.Filters[indexFilter].Texto = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "30064")
            {
                this.Filters[indexFilter].Idioma = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTLanguageCS.TTLanguageFilters[])filter;
            }
            if (sDTid == "30065")
            {
                this.Filters[indexFilter].RelacionProceso = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProcesoCS.TTProcesoFilters[])filter;
            }
            if (sDTid == "30066")
            {
                this.Filters[indexFilter].RelacionDominio = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDNTCS.TTDNTFilters[])filter;
            }
            if (sDTid == "30067")
            {
                this.Filters[indexFilter].RelacionDT = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTMetadataCS.TTMetadataFilters[])filter;
            }
            if (sDTid == "30068")
            {
                this.Filters[indexFilter].RelacionMessage = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }

            */
        }
    }
}