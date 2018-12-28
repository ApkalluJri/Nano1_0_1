using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace ttusuarios_tokenCS
{
    public class ttusuarios_tokenFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varUsuario_Token_Campo =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Usuario_Token_Campo{
            get { return varUsuario_Token_Campo; }
            set { varUsuario_Token_Campo = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varId_Usuario =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Id_Usuario{
            get { return varId_Usuario; }
            set { varId_Usuario = value; }
        }
        private TTClassSpecials.FiltersTypes.String varToken = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Token
        {
            get { return varToken; }
            set { varToken = value; }
        }
        private TTClassSpecials.FiltersTypes.String varIdentificador = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Identificador
        {
            get { return varIdentificador; }
            set { varIdentificador = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varEstado_Logico = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Estado_Logico
        {
            get { return varEstado_Logico; }
            set { varEstado_Logico = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varTipoDispositivo =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric TipoDispositivo{
            get { return varTipoDispositivo; }
            set { varTipoDispositivo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varId_Usuario_TTUsuarios =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varId_Usuario_TTUsuarios;
        public TTClassSpecials.FiltersTypes.Dependientes Id_Usuario_TTUsuarios{
            get { return varId_Usuario_TTUsuarios; }
            set { varId_Usuario_TTUsuarios = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varId =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Id{
            get { return varId; }
            set { varId = value; }
        }

    }
public class objectBussinessttusuarios_token : IDisposable
{
    public int iProcess = 34793;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private ttusuarios_tokenFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varUsuario_Token_Campo;
	private int? varId_Usuario;
	private String varToken;
	private String varIdentificador;
	private Boolean varEstado_Logico;
	private int? varTipoDispositivo;
	private int? varId_Usuario_TTUsuarios;
	private int? varId;


    bool disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed ressources
            }
        }
        //dispose unmanaged ressources
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }		
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

    public ttusuarios_tokenFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public ttusuarios_tokenFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new ttusuarios_tokenFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Usuario_Token_Campo{
        get { return varUsuario_Token_Campo;}
        set { varUsuario_Token_Campo = value;}
    }
    public int? Id_Usuario{
        get { return varId_Usuario;}
        set { varId_Usuario = value;}
    }
    public String Token{
        get { return varToken;}
        set { varToken = value;}
    }
    public String Identificador{
        get { return varIdentificador;}
        set { varIdentificador = value;}
    }
    public Boolean Estado_Logico{
        get { return varEstado_Logico;}
        set { varEstado_Logico = value;}
    }
    public int? TipoDispositivo{
        get { return varTipoDispositivo;}
        set { varTipoDispositivo = value;}
    }
    public int? Id_Usuario_TTUsuarios{
        get { return varId_Usuario_TTUsuarios;}
        set { varId_Usuario_TTUsuarios = value;}
    }
    public int? Id{
        get { return varId;}
        set { varId = value;}
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
            com.CommandText = "sp_SelAllComplete_ttusuarios_token_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_ttusuarios_token";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (ttusuarios_tokenCS.ttusuarios_tokenFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("ttusuarios_token", fil);
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
                com.CommandText = "sp_SelAllComplete_ttusuarios_token_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_ttusuarios_token";
        else
            com.CommandText="sp_SelAllttusuarios_token";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (ttusuarios_tokenCS.ttusuarios_tokenFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("ttusuarios_token", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("ttusuarios_token", fil);
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
                  string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere; 

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

                    switch (sortExpression)             {                 case "ttusuarios_token_Folio": sortExpression = "ttusuarios_token.Folio"; break;  case "ttusuarios_token_Usuario_Token_Campo": sortExpression = "ttusuarios_token.Usuario_Token_Campo"; break;  case "ttusuarios_token_Id_Usuario": sortExpression = "ttusuarios_token.Id_Usuario"; break;  case "ttusuarios_token_Token": sortExpression = "ttusuarios_token.Token"; break;  case "ttusuarios_token_Identificador": sortExpression = "ttusuarios_token.Identificador"; break;  case "ttusuarios_token_Estado_Logico": sortExpression = "ttusuarios_token.Estado_Logico"; break;  case "ttusuarios_token_TipoDispositivo": sortExpression = "ttusuarios_token.TipoDispositivo"; break;  case "ttusuarios_token_Id_Usuario_TTUsuarios": sortExpression = "ttusuarios_token.Id_Usuario_TTUsuarios"; break;  case "Id_Usuario_TTUsuarios_Nombre": sortExpression = "Id_Usuario_TTUsuarios.Nombre"; break;  case "ttusuarios_token_Id": sortExpression = "ttusuarios_token.Id"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "ttusuarios_token.Folio, ttusuarios_token.Usuario_Token_Campo, ttusuarios_token.Id_Usuario, ttusuarios_token.Token, ttusuarios_token.Identificador, ttusuarios_token.Estado_Logico, ttusuarios_token.TipoDispositivo, ttusuarios_token.Id_Usuario_TTUsuarios, Id_Usuario_TTUsuarios.Nombre, ttusuarios_token.Id" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        Id_Usuario_TTUsuarios.Nombre AS Id_Usuario_TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id ";             string fieldsForExport = " ttusuarios_token.Folio As [Folio],        ttusuarios_token.Usuario_Token_Campo As [Usuario Token Campo],        ttusuarios_token.Id_Usuario As [Id Usuario],        ttusuarios_token.Token As [Token],        ttusuarios_token.Identificador As [Identificador],        ttusuarios_token.Estado_Logico As [Estado Logico],        ttusuarios_token.TipoDispositivo As [TipoDispositivo],        ttusuarios_token.Id_Usuario_TTUsuarios AS [Id Usuario TTUsuarios],        Id_Usuario_TTUsuarios.Nombre AS [Id Usuario TTUsuarios Nombre],        ttusuarios_token.Id As [Id] ";             string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere; 

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
    

    //-----------------------------------------------------------Métodos para rad Grid----------------------------------------------------------------
    public string GetFullQuery(string where, string Order)
    {
        	swhere = where; 	string fieldsWithAlias = " ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        Id_Usuario_TTUsuarios.Nombre AS Id_Usuario_TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id ";         Order = (Order == string.Empty || Order == null ? "ttusuarios_token.Folio, ttusuarios_token.Usuario_Token_Campo, ttusuarios_token.Id_Usuario, ttusuarios_token.Token, ttusuarios_token.Identificador, ttusuarios_token.Estado_Logico, ttusuarios_token.TipoDispositivo, ttusuarios_token.Id_Usuario_TTUsuarios, Id_Usuario_TTUsuarios.Nombre, ttusuarios_token.Id" : Order);         string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere;
        return string.Format(this.fullQueryForExport,  fieldsWithAlias + " " + from,Order);
    }

    public DataSet SelAll(int startRowIndex, int maximumRows, string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";

       	swhere = where; 	string fieldsWithAlias = " ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        Id_Usuario_TTUsuarios.Nombre AS Id_Usuario_TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id ";         Order = (Order == string.Empty || Order == null ? "ttusuarios_token.Folio, ttusuarios_token.Usuario_Token_Campo, ttusuarios_token.Id_Usuario, ttusuarios_token.Token, ttusuarios_token.Identificador, ttusuarios_token.Estado_Logico, ttusuarios_token.TipoDispositivo, ttusuarios_token.Id_Usuario_TTUsuarios, Id_Usuario_TTUsuarios.Nombre, ttusuarios_token.Id" : Order);         string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public DataSet SelAll(string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            ";

        	swhere = where; 	string fieldsWithAlias = " ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        Id_Usuario_TTUsuarios.Nombre AS Id_Usuario_TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id ";         Order = (Order == string.Empty || Order == null ? "ttusuarios_token.Folio, ttusuarios_token.Usuario_Token_Campo, ttusuarios_token.Id_Usuario, ttusuarios_token.Token, ttusuarios_token.Identificador, ttusuarios_token.Estado_Logico, ttusuarios_token.TipoDispositivo, ttusuarios_token.Id_Usuario_TTUsuarios, Id_Usuario_TTUsuarios.Nombre, ttusuarios_token.Id" : Order);         string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public int SelCount(string where)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"SELECT COUNT(*) {0}" ;
        string Order="";
        	swhere = where; 	string fieldsWithAlias = " ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        Id_Usuario_TTUsuarios.Nombre AS Id_Usuario_TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id ";         Order = (Order == string.Empty || Order == null ? "ttusuarios_token.Folio, ttusuarios_token.Usuario_Token_Campo, ttusuarios_token.Id_Usuario, ttusuarios_token.Token, ttusuarios_token.Identificador, ttusuarios_token.Estado_Logico, ttusuarios_token.TipoDispositivo, ttusuarios_token.Id_Usuario_TTUsuarios, Id_Usuario_TTUsuarios.Nombre, ttusuarios_token.Id" : Order);         string from = " from ( ttusuarios_token WITH(NoLock) LEFT JOIN TTUsuarios as Id_Usuario_TTUsuarios WITH(NoLock) ON Id_Usuario_TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, from);

        com.CommandText = sPagingTemplate;

        return (int)db.ExecuteScalar(com);
   }
    //------------------------------------------------------------------------------------------------------------------------------------------------
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
                com.CommandText = "sp_SelAllComplete_ttusuarios_token_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_ttusuarios_token";
        else
            com.CommandText="sp_SelAllttusuarios_token";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (ttusuarios_tokenCS.ttusuarios_tokenFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("ttusuarios_token", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("ttusuarios_token", fil);
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

        db.BeginTransaction("ttusuarios_token");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_Insttusuarios_token";
            com.Parameters.AddWithValue("@Usuario_Token_Campo",Conversion.FormatNull(varUsuario_Token_Campo));
            com.Parameters.AddWithValue("@Id_Usuario",Conversion.FormatNull(varId_Usuario));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador!=null)
            {
                if (varIdentificador != "")
                    com.Parameters.AddWithValue("@Identificador", Convierte(varIdentificador, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estado_Logico", varEstado_Logico);
            com.Parameters.AddWithValue("@TipoDispositivo",Conversion.FormatNull(varTipoDispositivo));
            com.Parameters.AddWithValue("@Id_Usuario_TTUsuarios",Conversion.FormatNull(varId_Usuario_TTUsuarios));
            com.Parameters.AddWithValue("@Id",Conversion.FormatNull(varId));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("ttusuarios_token");
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

        db.BeginTransaction("ttusuarios_token");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_Insttusuarios_token";
            com.Parameters.AddWithValue("@Usuario_Token_Campo",Conversion.FormatNull(varUsuario_Token_Campo));
            com.Parameters.AddWithValue("@Id_Usuario",Conversion.FormatNull(varId_Usuario));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador!=null)
            {
                if (varIdentificador != "")
                    com.Parameters.AddWithValue("@Identificador", Convierte(varIdentificador, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estado_Logico", varEstado_Logico);
            com.Parameters.AddWithValue("@TipoDispositivo",Conversion.FormatNull(varTipoDispositivo));
            com.Parameters.AddWithValue("@Id_Usuario_TTUsuarios",Conversion.FormatNull(varId_Usuario_TTUsuarios));
            com.Parameters.AddWithValue("@Id",Conversion.FormatNull(varId));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("ttusuarios_token");
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

        db.BeginTransaction("ttusuarios_token");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_Updttusuarios_token";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Usuario_Token_Campo",Conversion.FormatNull(varUsuario_Token_Campo));
            com.Parameters.AddWithValue("@Id_Usuario",Conversion.FormatNull(varId_Usuario));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador!=null)
            {
                if (varIdentificador != "")
                    com.Parameters.AddWithValue("@Identificador", Convierte(varIdentificador, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estado_Logico", varEstado_Logico);
            com.Parameters.AddWithValue("@TipoDispositivo",Conversion.FormatNull(varTipoDispositivo));
            com.Parameters.AddWithValue("@Id_Usuario_TTUsuarios",Conversion.FormatNull(varId_Usuario_TTUsuarios));
            com.Parameters.AddWithValue("@Id",Conversion.FormatNull(varId));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("ttusuarios_token");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("ttusuarios_token");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_Delttusuarios_token";
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
                    db.RollBackTransaction("ttusuarios_token");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_Folio"]);
            Usuario_Token_Campo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_Usuario_Token_Campo"]);
            Id_Usuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_Id_Usuario"]);
            Token = ds.Tables[0].Rows[0]["ttusuarios_token_Token"].ToString();
            Identificador = ds.Tables[0].Rows[0]["ttusuarios_token_Identificador"].ToString();
            if (ds.Tables[0].Rows[0]["ttusuarios_token_Estado_Logico"] != DBNull.Value)
                Estado_Logico = Convert.ToBoolean(ds.Tables[0].Rows[0]["ttusuarios_token_Estado_Logico"]);
            TipoDispositivo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_TipoDispositivo"]);
            Id_Usuario_TTUsuarios = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_Id_Usuario_TTUsuarios"]);
            Id = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["ttusuarios_token_Id"]);



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
                com.CommandText="sp_GetComplete_ttusuarios_token";
            else
                com.CommandText="sp_Getttusuarios_token";
com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_Token_Campo(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Usuario_Token_Campo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyId_Usuario(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Id_Usuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyToken(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Token = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdentificador(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Identificador = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstado_Logico(Boolean Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Estado_Logico = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipoDispositivo(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.TipoDispositivo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyId_Usuario_TTUsuarios(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Id_Usuario_TTUsuarios = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyId(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         ttusuarios_token.Folio As ttusuarios_token_Folio,        ttusuarios_token.Usuario_Token_Campo As ttusuarios_token_Usuario_Token_Campo,        ttusuarios_token.Id_Usuario As ttusuarios_token_Id_Usuario,        ttusuarios_token.Token As ttusuarios_token_Token,        ttusuarios_token.Identificador As ttusuarios_token_Identificador,        ttusuarios_token.Estado_Logico As ttusuarios_token_Estado_Logico,        ttusuarios_token.TipoDispositivo As ttusuarios_token_TipoDispositivo,        ttusuarios_token.Id_Usuario_TTUsuarios AS ttusuarios_token_Id_Usuario_TTUsuarios,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        ttusuarios_token.Id As ttusuarios_token_Id   from ( ttusuarios_token       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=ttusuarios_token.Id_Usuario_TTUsuarios)           Where ttusuarios_token.Id = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_ttusuarios_token";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (ttusuarios_tokenCS.ttusuarios_tokenFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("ttusuarios_token", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["ttusuarios_token_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_Getttusuarios_token";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataId_Usuario_TTUsuariosControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataId_Usuario_TTUsuarios(Object ctr, String Filtro){
            public DataTable FillDataId_Usuario_TTUsuarios(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selttusuarios_token_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataId_Usuario_TTUsuariosControl(ctr, dt);
                return dt;
            }
//            public void FillDataId_Usuario_TTUsuarios(Object ctr){
            public DataTable FillDataId_Usuario_TTUsuarios(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selttusuarios_token_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataId_Usuario_TTUsuariosControl(ctr, dt);
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
                //Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                //Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                //MyFiltersObligatories[iViews] = MySearch.Filter;
                //MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
    }
}
