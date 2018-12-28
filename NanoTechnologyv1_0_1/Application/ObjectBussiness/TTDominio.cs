using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTDominioCS
{
    public class TTDominioFilters
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
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDominio_TipoCS.TTDominio_TipoFilters[] varTipo;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo{
            get { return varTipo; }
            set { varTipo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRelacionDT =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varRelacionDT;
        public TTClassSpecials.FiltersTypes.Dependientes RelacionDT{
            get { return varRelacionDT; }
            set { varRelacionDT = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRelacionDNT =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDNTCS.TTDNTFilters[] varRelacionDNT;
        public TTClassSpecials.FiltersTypes.Dependientes RelacionDNT{
            get { return varRelacionDNT; }
            set { varRelacionDNT = value; }
        }

    }
public class objectBussinessTTDominio{
    public int iProcess = 6835;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTDominioFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private String varDescripcion;
	private int? varTipo;
	private int? varRelacionDT;
	private int? varRelacionDNT;
		
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

    public TTDominioFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTDominioFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTDominioFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public int? Tipo{
        get { return varTipo;}
        set { varTipo = value;}
    }
    public int? RelacionDT{
        get { return varRelacionDT;}
        set { varRelacionDT = value;}
    }
    public int? RelacionDNT{
        get { return varRelacionDNT;}
        set { varRelacionDNT = value;}
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
            com.CommandText = "sp_SelAllComplete_TTDominio_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTDominio";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTDominioCS.TTDominioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDominio", fil);
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
                com.CommandText = "sp_SelAllComplete_TTDominio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDominio";
        else
            com.CommandText="sp_SelAllTTDominio";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTDominioCS.TTDominioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDominio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDominio", fil);
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
                  string from = " from ((( TTDominio WITH(NoLock) LEFT JOIN TTDominio_Tipo WITH(NoLock) ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata WITH(NoLock) ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT WITH(NoLock) ON TTDNT.DNTID=TTDominio.RelacionDNT)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTDominio_Folio": sortExpression = "TTDominio.Folio"; break;  case "TTDominio_Descripcion": sortExpression = "TTDominio.Descripcion"; break;  case "TTDominio_Tipo": sortExpression = "TTDominio.Tipo"; break;  case "TTDominio_Tipo_Descripcion": sortExpression = "TTDominio_Tipo.Descripcion"; break;  case "TTDominio_RelacionDT": sortExpression = "TTDominio.RelacionDT"; break;  case "TTMetadata_Nombre": sortExpression = "TTMetadata.Nombre"; break;  case "TTDominio_RelacionDNT": sortExpression = "TTDominio.RelacionDNT"; break;  case "TTDNT_Nombre_Tabla": sortExpression = "TTDNT.Nombre_Tabla"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTDominio.Folio, TTDominio.Descripcion, TTDominio.Tipo, TTDominio_Tipo.Descripcion, TTDominio.RelacionDT, TTMetadata.Nombre, TTDominio.RelacionDNT, TTDNT.Nombre_Tabla" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla ";             string fieldsForExport = " TTDominio.Folio As [Folio],        TTDominio.Descripcion As [Descripcion],        TTDominio.Tipo AS [Tipo],        TTDominio_Tipo.Descripcion AS [Descripcion],        TTDominio.RelacionDT AS [RelacionDT],        TTMetadata.Nombre AS [Nombre],        TTDominio.RelacionDNT AS [RelacionDNT],        TTDNT.Nombre_Tabla AS [Nombre Tabla] ";             string from = " from ((( TTDominio WITH(NoLock) LEFT JOIN TTDominio_Tipo WITH(NoLock) ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata WITH(NoLock) ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT WITH(NoLock) ON TTDNT.DNTID=TTDominio.RelacionDNT)        " + swhere; 

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
                com.CommandText = "sp_SelAllComplete_TTDominio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDominio";
        else
            com.CommandText="sp_SelAllTTDominio";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTDominioCS.TTDominioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDominio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDominio", fil);
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

        db.BeginTransaction("TTDominio");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTDominio";
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo",Conversion.FormatNull(varTipo));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionDNT",Conversion.FormatNull(varRelacionDNT));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTDominio");
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

        db.BeginTransaction("TTDominio");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTDominio";
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo",Conversion.FormatNull(varTipo));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionDNT",Conversion.FormatNull(varRelacionDNT));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTDominio");
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

        db.BeginTransaction("TTDominio");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTDominio";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo",Conversion.FormatNull(varTipo));
            com.Parameters.AddWithValue("@RelacionDT",Conversion.FormatNull(varRelacionDT));
            com.Parameters.AddWithValue("@RelacionDNT",Conversion.FormatNull(varRelacionDNT));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTDominio");
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
            db.BeginTransaction("TTDominio");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTDominio";
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
                    db.RollBackTransaction("TTDominio");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDominio_Folio"]);
            Descripcion = ds.Tables[0].Rows[0]["TTDominio_Descripcion"].ToString();
            Tipo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDominio_Tipo"]);
            RelacionDT = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDominio_RelacionDT"]);
            RelacionDNT = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDominio_RelacionDNT"]);



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
                com.CommandText="sp_GetComplete_TTDominio";
            else
                com.CommandText="sp_GetTTDominio";
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
            com.CommandText="Select         TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla   from ((( TTDominio       LEFT JOIN TTDominio_Tipo ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTDominio.RelacionDNT)           Where TTDominio.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDescripcion(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla   from ((( TTDominio       LEFT JOIN TTDominio_Tipo ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTDominio.RelacionDNT)           Where TTDominio.Descripcion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla   from ((( TTDominio       LEFT JOIN TTDominio_Tipo ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTDominio.RelacionDNT)           Where TTDominio.Tipo = '" + Key + "'";
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
            com.CommandText="Select         TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla   from ((( TTDominio       LEFT JOIN TTDominio_Tipo ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTDominio.RelacionDNT)           Where TTDominio.RelacionDT = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRelacionDNT(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTDominio.Folio As TTDominio_Folio,        TTDominio.Descripcion As TTDominio_Descripcion,        TTDominio.Tipo AS TTDominio_Tipo,        TTDominio_Tipo.Descripcion AS TTDominio_Tipo_Descripcion,        TTDominio.RelacionDT AS TTDominio_RelacionDT,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTDominio.RelacionDNT AS TTDominio_RelacionDNT,        TTDNT.Nombre_Tabla AS TTDNT_Nombre_Tabla   from ((( TTDominio       LEFT JOIN TTDominio_Tipo ON TTDominio_Tipo.Folio=TTDominio.Tipo)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTDominio.RelacionDT)       LEFT JOIN TTDNT ON TTDNT.DNTID=TTDominio.RelacionDNT)           Where TTDominio.RelacionDNT = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTDominio";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTDominioCS.TTDominioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDominio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTDominio_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTDominio";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataTipoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataTipo(Object ctr, String Filtro){
            public DataTable FillDataTipo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDominio_Relacion_TTDominio_Tipo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipoControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo(Object ctr){
            public DataTable FillDataTipo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDominio_Relacion_TTDominio_Tipo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipoControl(ctr, dt);
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
            com.CommandText = "sp_selTTDominio_Relacion_TTMetadata";
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
            com.CommandText = "sp_selTTDominio_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataRelacionDTControl(ctr, dt);
            return dt;
        }
/*            private void FillDataRelacionDNTControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataRelacionDNT(Object ctr, String Filtro){
            public DataTable FillDataRelacionDNT(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDominio_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRelacionDNTControl(ctr, dt);
                return dt;
            }
//            public void FillDataRelacionDNT(Object ctr){
            public DataTable FillDataRelacionDNT(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDominio_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRelacionDNTControl(ctr, dt);
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
        ev.Graphics.DrawString("TTDominio", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Folio: " + this.varFolio, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Descripcion: " + this.varDescripcion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varTipo != null)
        {
            /*TTDominio_TipoCS.objectBussinessTTDominio_Tipo myRelationWhitTTDominio_Tipo = new TTDominio_TipoCS.objectBussinessTTDominio_Tipo();
            myRelationWhitTTDominio_Tipo.GetByKeyFolio(this.varTipo);
            ev.Graphics.DrawString("Tipo: " + myRelationWhitTTDominio_Tipo.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Tipo: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
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

        if (this.varRelacionDNT != null)
        {
            /*TTDNTCS.objectBussinessTTDNT myRelationWhitTTDNT = new TTDNTCS.objectBussinessTTDNT();
            myRelationWhitTTDNT.GetByKeyDNTID(this.varRelacionDNT);
            ev.Graphics.DrawString("RelacionDNT: " + myRelationWhitTTDNT.Nombre_Tabla , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("RelacionDNT: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "30069")
            {
                this.Filters[indexFilter].Folio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30070")
            {
                this.Filters[indexFilter].Descripcion = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "30073")
            {
                this.Filters[indexFilter].Tipo = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDominio_TipoCS.TTDominio_TipoFilters[])filter;
            }
            if (sDTid == "30074")
            {
                this.Filters[indexFilter].RelacionDT = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTMetadataCS.TTMetadataFilters[])filter;
            }
            if (sDTid == "30075")
            {
                this.Filters[indexFilter].RelacionDNT = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDNTCS.TTDNTFilters[])filter;
            }

            */
        }
    }
}