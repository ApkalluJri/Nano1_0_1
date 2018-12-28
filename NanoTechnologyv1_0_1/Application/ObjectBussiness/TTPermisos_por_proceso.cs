using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTPermisos_por_procesoCS
{
    public class TTPermisos_por_procesoFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varIdGrupoUsuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTGrupo_de_UsuarioCS.TTGrupo_de_UsuarioFilters[] varIdGrupoUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes IdGrupoUsuario{
            get { return varIdGrupoUsuario; }
            set { varIdGrupoUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varIdProceso =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varIdProceso;
        public TTClassSpecials.FiltersTypes.Dependientes IdProceso{
            get { return varIdProceso; }
            set { varIdProceso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varIdOperacion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTOperacionCS.TTOperacionFilters[] varIdOperacion;
        public TTClassSpecials.FiltersTypes.Dependientes IdOperacion{
            get { return varIdOperacion; }
            set { varIdOperacion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varidModulo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTModuloCS.TTModuloFilters[] varidModulo;
        public TTClassSpecials.FiltersTypes.Dependientes idModulo{
            get { return varidModulo; }
            set { varidModulo = value; }
        }

    }
public class objectBussinessTTPermisos_por_proceso{
    public int iProcess = 6398;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTPermisos_por_procesoFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varIdGrupoUsuario;
	private int? varIdProceso;
	private int? varIdOperacion;
	private int? varidModulo;
		
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

    public TTPermisos_por_procesoFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTPermisos_por_procesoFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTPermisos_por_procesoFilters[1];
            filters[0] = value;
        }
    }

    public int? IdGrupoUsuario{
        get { return varIdGrupoUsuario;}
        set { varIdGrupoUsuario = value;}
    }
    public int? IdProceso{
        get { return varIdProceso;}
        set { varIdProceso = value;}
    }
    public int? IdOperacion{
        get { return varIdOperacion;}
        set { varIdOperacion = value;}
    }
    public int? idModulo{
        get { return varidModulo;}
        set { varidModulo = value;}
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
            com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTPermisos_por_proceso", fil);
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
                com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso";
        else
            com.CommandText="sp_SelAllTTPermisos_por_proceso";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTPermisos_por_proceso", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTPermisos_por_proceso", fil);
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

    //-----------------------------------------------------------M�todos para paginaci�n--------------------------------------------------------------
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
                  string from = " from (((( TTPermisos_por_proceso WITH(NoLock) LEFT JOIN TTGrupo_de_Usuario WITH(NoLock) ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion WITH(NoLock) ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo WITH(NoLock) ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTPermisos_por_proceso_IdGrupoUsuario": sortExpression = "TTPermisos_por_proceso.IdGrupoUsuario"; break;  case "TTGrupo_de_Usuario_Descripcion": sortExpression = "TTGrupo_de_Usuario.Descripcion"; break;  case "TTPermisos_por_proceso_IdProceso": sortExpression = "TTPermisos_por_proceso.IdProceso"; break;  case "TTProceso_Nombre": sortExpression = "TTProceso.Nombre"; break;  case "TTPermisos_por_proceso_IdOperacion": sortExpression = "TTPermisos_por_proceso.IdOperacion"; break;  case "TTOperacion_Descripcion": sortExpression = "TTOperacion.Descripcion"; break;  case "TTPermisos_por_proceso_idModulo": sortExpression = "TTPermisos_por_proceso.idModulo"; break;  case "TTModulo_Nombre": sortExpression = "TTModulo.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTPermisos_por_proceso.IdGrupoUsuario, TTGrupo_de_Usuario.Descripcion, TTPermisos_por_proceso.IdProceso, TTProceso.Nombre, TTPermisos_por_proceso.IdOperacion, TTOperacion.Descripcion, TTPermisos_por_proceso.idModulo, TTModulo.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTPermisos_por_proceso.IdGrupoUsuario AS TTPermisos_por_proceso_IdGrupoUsuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTPermisos_por_proceso.IdProceso AS TTPermisos_por_proceso_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTPermisos_por_proceso.IdOperacion AS TTPermisos_por_proceso_IdOperacion,        TTOperacion.Descripcion AS TTOperacion_Descripcion,        TTPermisos_por_proceso.idModulo AS TTPermisos_por_proceso_idModulo,        TTModulo.Nombre AS TTModulo_Nombre ";             string fieldsForExport = " TTPermisos_por_proceso.IdGrupoUsuario AS [IdGrupoUsuario],        TTGrupo_de_Usuario.Descripcion AS [Descripcion],        TTPermisos_por_proceso.IdProceso AS [IdProceso],        TTProceso.Nombre AS [Nombre],        TTPermisos_por_proceso.IdOperacion AS [IdOperacion],        TTOperacion.Descripcion AS [Descripcion],        TTPermisos_por_proceso.idModulo AS [idModulo],        TTModulo.Nombre AS [Nombre] ";             string from = " from (((( TTPermisos_por_proceso WITH(NoLock) LEFT JOIN TTGrupo_de_Usuario WITH(NoLock) ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion WITH(NoLock) ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo WITH(NoLock) ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)        " + swhere; 

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
                com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso";
        else
            com.CommandText="sp_SelAllTTPermisos_por_proceso";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTPermisos_por_proceso", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTPermisos_por_proceso", fil);
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

        db.BeginTransaction("TTPermisos_por_proceso");
        int? sKeyIdGrupoUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTPermisos_por_proceso";
            com.Parameters.AddWithValue("@IdGrupoUsuario",Conversion.FormatNull(varIdGrupoUsuario));
            com.Parameters.AddWithValue("@IdProceso",Conversion.FormatNull(varIdProceso));
            com.Parameters.AddWithValue("@IdOperacion",Conversion.FormatNull(varIdOperacion));
            com.Parameters.AddWithValue("@idModulo",Conversion.FormatNull(varidModulo));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdGrupoUsuario = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
            
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTPermisos_por_proceso");
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

        db.BeginTransaction("TTPermisos_por_proceso");
        int? sKeyIdGrupoUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTPermisos_por_proceso";
            com.Parameters.AddWithValue("@IdGrupoUsuario",Conversion.FormatNull(varIdGrupoUsuario));
            com.Parameters.AddWithValue("@IdProceso",Conversion.FormatNull(varIdProceso));
            com.Parameters.AddWithValue("@IdOperacion",Conversion.FormatNull(varIdOperacion));
            com.Parameters.AddWithValue("@idModulo",Conversion.FormatNull(varidModulo));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdGrupoUsuario = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
            
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTPermisos_por_proceso");
            }
            catch{}
            throw ex; 
        }
        return sKeyIdGrupoUsuario;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTPermisos_por_proceso");
        int? sKeyIdGrupoUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTPermisos_por_proceso";
            com.Parameters.AddWithValue("@IdGrupoUsuario",Conversion.FormatNull(varIdGrupoUsuario));
            com.Parameters.AddWithValue("@IdProceso",Conversion.FormatNull(varIdProceso));
            com.Parameters.AddWithValue("@IdOperacion",Conversion.FormatNull(varIdOperacion));
            com.Parameters.AddWithValue("@idModulo",Conversion.FormatNull(varidModulo));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdGrupoUsuario = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varidModulo = sKeyidModulo;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTPermisos_por_proceso");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyIdGrupoUsuario.ToString()+ ","+ KeyIdProceso.ToString()+ ","+ KeyIdOperacion.ToString()+ ","+ KeyidModulo.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTPermisos_por_proceso");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTPermisos_por_proceso";
com.Parameters.AddWithValue("@IdGrupoUsuario",KeyIdGrupoUsuario);com.Parameters.AddWithValue("@IdProceso",KeyIdProceso);com.Parameters.AddWithValue("@IdOperacion",KeyIdOperacion);com.Parameters.AddWithValue("@idModulo",KeyidModulo);
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
                    db.RollBackTransaction("TTPermisos_por_proceso");
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
            IdGrupoUsuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTPermisos_por_proceso_IdGrupoUsuario"]);
            IdProceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTPermisos_por_proceso_IdProceso"]);
            IdOperacion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTPermisos_por_proceso_IdOperacion"]);
            idModulo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTPermisos_por_proceso_idModulo"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo, Boolean ConRelaciones){
        DataSet ds;
        if (KeyidModulo == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTPermisos_por_proceso";
            else
                com.CommandText="sp_GetTTPermisos_por_proceso";
com.Parameters.AddWithValue("@IdGrupoUsuario",KeyIdGrupoUsuario);com.Parameters.AddWithValue("@IdProceso",KeyIdProceso);com.Parameters.AddWithValue("@IdOperacion",KeyIdOperacion);com.Parameters.AddWithValue("@idModulo",KeyidModulo);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdGrupoUsuario(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTPermisos_por_proceso.IdGrupoUsuario AS TTPermisos_por_proceso_IdGrupoUsuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTPermisos_por_proceso.IdProceso AS TTPermisos_por_proceso_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTPermisos_por_proceso.IdOperacion AS TTPermisos_por_proceso_IdOperacion,        TTOperacion.Descripcion AS TTOperacion_Descripcion,        TTPermisos_por_proceso.idModulo AS TTPermisos_por_proceso_idModulo,        TTModulo.Nombre AS TTModulo_Nombre   from (((( TTPermisos_por_proceso       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)           Where TTPermisos_por_proceso.IdGrupoUsuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdProceso(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTPermisos_por_proceso.IdGrupoUsuario AS TTPermisos_por_proceso_IdGrupoUsuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTPermisos_por_proceso.IdProceso AS TTPermisos_por_proceso_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTPermisos_por_proceso.IdOperacion AS TTPermisos_por_proceso_IdOperacion,        TTOperacion.Descripcion AS TTOperacion_Descripcion,        TTPermisos_por_proceso.idModulo AS TTPermisos_por_proceso_idModulo,        TTModulo.Nombre AS TTModulo_Nombre   from (((( TTPermisos_por_proceso       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)           Where TTPermisos_por_proceso.IdProceso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdOperacion(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTPermisos_por_proceso.IdGrupoUsuario AS TTPermisos_por_proceso_IdGrupoUsuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTPermisos_por_proceso.IdProceso AS TTPermisos_por_proceso_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTPermisos_por_proceso.IdOperacion AS TTPermisos_por_proceso_IdOperacion,        TTOperacion.Descripcion AS TTOperacion_Descripcion,        TTPermisos_por_proceso.idModulo AS TTPermisos_por_proceso_idModulo,        TTModulo.Nombre AS TTModulo_Nombre   from (((( TTPermisos_por_proceso       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)           Where TTPermisos_por_proceso.IdOperacion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyidModulo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTPermisos_por_proceso.IdGrupoUsuario AS TTPermisos_por_proceso_IdGrupoUsuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTPermisos_por_proceso.IdProceso AS TTPermisos_por_proceso_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTPermisos_por_proceso.IdOperacion AS TTPermisos_por_proceso_IdOperacion,        TTOperacion.Descripcion AS TTOperacion_Descripcion,        TTPermisos_por_proceso.idModulo AS TTPermisos_por_proceso_idModulo,        TTModulo.Nombre AS TTModulo_Nombre   from (((( TTPermisos_por_proceso       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTPermisos_por_proceso.IdGrupoUsuario)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTPermisos_por_proceso.IdProceso)       LEFT JOIN TTOperacion ON TTOperacion.IdOperacion=TTPermisos_por_proceso.IdOperacion)       LEFT JOIN TTModulo ON TTModulo.IdModulo=TTPermisos_por_proceso.idModulo)           Where TTPermisos_por_proceso.idModulo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTPermisos_por_proceso";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTPermisos_por_proceso", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTPermisos_por_proceso_IdGrupoUsuario"]) == KeyIdGrupoUsuario&& Function.FormatNumberNull(dt.Rows[i]["TTPermisos_por_proceso_IdProceso"]) == KeyIdProceso&& Function.FormatNumberNull(dt.Rows[i]["TTPermisos_por_proceso_IdOperacion"]) == KeyIdOperacion&& Function.FormatNumberNull(dt.Rows[i]["TTPermisos_por_proceso_idModulo"]) == KeyidModulo)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyIdGrupoUsuario, int? KeyIdProceso, int? KeyIdOperacion, int? KeyidModulo){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTPermisos_por_proceso";
com.Parameters.AddWithValue("@IdGrupoUsuario",KeyIdGrupoUsuario);com.Parameters.AddWithValue("@IdProceso",KeyIdProceso);com.Parameters.AddWithValue("@IdOperacion",KeyIdOperacion);com.Parameters.AddWithValue("@idModulo",KeyidModulo);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataIdGrupoUsuarioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "IdGrupoUsuario";
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
                        ((ListBox)ctr).ValueMember = "IdGrupoUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdGrupoUsuario";
                }
            }
*///            public DataTable FillDataIdGrupoUsuario(Object ctr, String Filtro){
            public DataTable FillDataIdGrupoUsuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTGrupo_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataIdGrupoUsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataIdGrupoUsuario(Object ctr){
            public DataTable FillDataIdGrupoUsuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTGrupo_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdGrupoUsuarioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataIdProcesoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataIdProceso(Object ctr, String Filtro){
            public DataTable FillDataIdProceso(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataIdProcesoControl(ctr, dt);
                return dt;
            }
//            public void FillDataIdProceso(Object ctr){
            public DataTable FillDataIdProceso(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdProcesoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataIdOperacionControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "IdOperacion";
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
                        ((ListBox)ctr).ValueMember = "IdOperacion";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdOperacion";
                }
            }
*///            public DataTable FillDataIdOperacion(Object ctr, String Filtro){
            public DataTable FillDataIdOperacion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTOperacion";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataIdOperacionControl(ctr, dt);
                return dt;
            }
//            public void FillDataIdOperacion(Object ctr){
            public DataTable FillDataIdOperacion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTOperacion";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataIdOperacionControl(ctr, dt);
                return dt;
            }
/*            private void FillDataidModuloControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdModulo";
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
                        ((ListBox)ctr).ValueMember = "IdModulo";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdModulo";
                }
            }
*///            public DataTable FillDataidModulo(Object ctr, String Filtro){
            public DataTable FillDataidModulo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTModulo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataidModuloControl(ctr, dt);
                return dt;
            }
//            public void FillDataidModulo(Object ctr){
            public DataTable FillDataidModulo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTPermisos_por_proceso_Relacion_TTModulo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataidModuloControl(ctr, dt);
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
        ev.Graphics.DrawString("TTPermisos por proceso", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        if (this.varIdGrupoUsuario != null)
        {
            /*TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario myRelationWhitTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
            myRelationWhitTTGrupo_de_Usuario.GetByKeyIdGrupoUsuario(this.varIdGrupoUsuario);
            ev.Graphics.DrawString("Clave de Grupo de usuario: " + myRelationWhitTTGrupo_de_Usuario.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Clave de Grupo de usuario: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varIdProceso != null)
        {
            /*TTProcesoCS.objectBussinessTTProceso myRelationWhitTTProceso = new TTProcesoCS.objectBussinessTTProceso();
            myRelationWhitTTProceso.GetByKeyIdProceso(this.varIdProceso);
            ev.Graphics.DrawString("Clave de Proceso: " + myRelationWhitTTProceso.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Clave de Proceso: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varIdOperacion != null)
        {
            /*TTOperacionCS.objectBussinessTTOperacion myRelationWhitTTOperacion = new TTOperacionCS.objectBussinessTTOperacion();
            myRelationWhitTTOperacion.GetByKeyIdOperacion(this.varIdOperacion);
            ev.Graphics.DrawString("Clave de Operacion: " + myRelationWhitTTOperacion.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Clave de Operacion: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }

        if (this.varidModulo != null)
        {
            /*TTModuloCS.objectBussinessTTModulo myRelationWhitTTModulo = new TTModuloCS.objectBussinessTTModulo();
            myRelationWhitTTModulo.GetByKeyIdModulo(this.varidModulo);
            ev.Graphics.DrawString("Clave del Modulo: " + myRelationWhitTTModulo.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Clave del Modulo: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "13097")
            {
                this.Filters[indexFilter].IdGrupoUsuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTGrupo_de_UsuarioCS.TTGrupo_de_UsuarioFilters[])filter;
            }
            if (sDTid == "13098")
            {
                this.Filters[indexFilter].IdProceso = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProcesoCS.TTProcesoFilters[])filter;
            }
            if (sDTid == "13099")
            {
                this.Filters[indexFilter].IdOperacion = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTOperacionCS.TTOperacionFilters[])filter;
            }
            if (sDTid == "13100")
            {
                this.Filters[indexFilter].idModulo = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTModuloCS.TTModuloFilters[])filter;
            }

            */
        }
    }
}