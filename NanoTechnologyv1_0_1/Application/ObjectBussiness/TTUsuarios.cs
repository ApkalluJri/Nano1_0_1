using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTUsuariosCS
{
    public class TTUsuariosFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varIdUsuario =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric IdUsuario{
            get { return varIdUsuario; }
            set { varIdUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varClave_de_Acceso = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Clave_de_Acceso
        {
            get { return varClave_de_Acceso; }
            set { varClave_de_Acceso = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varActivo = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Activo
        {
            get { return varActivo; }
            set { varActivo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varidGrupoUsuarios =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuarios_Por_GrupoCS.TTUsuarios_Por_GrupoFilters[] varidGrupoUsuarios;
        public TTClassSpecials.FiltersTypes.Dependientes idGrupoUsuarios{
            get { return varidGrupoUsuarios; }
            set { varidGrupoUsuarios = value; }
        }

    }
public class objectBussinessTTUsuarios{
    public int iProcess = 6395;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTUsuariosFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varIdUsuario;
	private String varNombre;
	private String varClave_de_Acceso;
	private String varContrasena;
	private Boolean varActivo;
	private int? varidGrupoUsuarios;
		
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

    public TTUsuariosFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTUsuariosFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTUsuariosFilters[1];
            filters[0] = value;
        }
    }

    public int? IdUsuario{
        get { return varIdUsuario;}
        set { varIdUsuario = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Clave_de_Acceso{
        get { return varClave_de_Acceso;}
        set { varClave_de_Acceso = value;}
    }
    public String Contrasena{
        get { return varContrasena;}
        set { varContrasena = value;}
    }
    public Boolean Activo{
        get { return varActivo;}
        set { varActivo = value;}
    }
    public int? idGrupoUsuarios{
        get { return varidGrupoUsuarios;}
        set { varidGrupoUsuarios = value;}
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
            com.CommandText = "sp_SelAllComplete_TTUsuarios_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTUsuarios";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTUsuariosCS.TTUsuariosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTUsuarios", fil);
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
                com.CommandText = "sp_SelAllComplete_TTUsuarios_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTUsuarios";
        else
            com.CommandText="sp_SelAllTTUsuarios";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTUsuariosCS.TTUsuariosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTUsuarios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTUsuarios", fil);
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
                  string from = " from ( TTUsuarios WITH(NoLock) LEFT JOIN TTGrupo_de_Usuario WITH(NoLock) ON ttGrupo_de_Usuario.idGrupoUsuario=TTUsuarios.idGrupoUsuarios)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTUsuarios_IdUsuario": sortExpression = "TTUsuarios.IdUsuario"; break;  case "TTUsuarios_Nombre": sortExpression = "TTUsuarios.Nombre"; break;  case "TTUsuarios_Clave_de_Acceso": sortExpression = "TTUsuarios.Clave_de_Acceso"; break;  case "TTUsuarios_Contrasena": sortExpression = "TTUsuarios.Contrasena"; break;  case "TTUsuarios_Activo": sortExpression = "TTUsuarios.Activo"; break;  case "TTUsuarios_idGrupoUsuarios": sortExpression = "TTUsuarios.idGrupoUsuarios"; break;  case "TTUsuarios_Por_Grupo_IdUsuario": sortExpression = "TTUsuarios_Por_Grupo.IdUsuario"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTUsuarios.IdUsuario, TTUsuarios.Nombre, TTUsuarios.Clave_de_Acceso, TTUsuarios.Contrasena, TTUsuarios.Activo, TTUsuarios.idGrupoUsuarios, TTUsuarios_Por_Grupo.IdUsuario" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");
                    string fieldsWithAlias = " TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario,        ttGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion ";
                    string fieldsForExport = " TTUsuarios.IdUsuario As [IdUsuario],        TTUsuarios.Nombre As [Nombre],        TTUsuarios.Clave_de_Acceso As [Clave de Acceso],        TTUsuarios.Contrasena As [Contrasena],        TTUsuarios.Activo As [Activo],        TTUsuarios.idGrupoUsuarios AS [idGrupoUsuarios],        TTUsuarios_Por_Grupo.IdUsuario AS [IdUsuario], ttGrupo_de_Usuario.Descripcion AS [Grupo de Usuario] ";
        string from = " from (( TTUsuarios WITH(NoLock) LEFT JOIN TTUsuarios_Por_Grupo WITH(NoLock) ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.IdUsuario) LEFT JOIN TTGrupo_de_Usuario WITH(NoLock) ON TTUsuarios_Por_Grupo.idGrupoUsuario=TTGrupo_de_Usuario.idGrupoUsuario)       " + swhere; 

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
                com.CommandText = "sp_SelAllComplete_TTUsuarios_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTUsuarios";
        else
            com.CommandText="sp_SelAllTTUsuarios";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTUsuariosCS.TTUsuariosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTUsuarios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTUsuarios", fil);
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

        db.BeginTransaction("TTUsuarios");
        int? sKeyIdUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTUsuarios";
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varClave_de_Acceso!=null)
                com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            if (varContrasena!=null)
                com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            com.Parameters.AddWithValue("@Activo", varActivo);
            com.Parameters.AddWithValue("@idGrupoUsuarios",Conversion.FormatNull(varidGrupoUsuarios));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdUsuario = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varIdUsuario = sKeyIdUsuario;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTUsuarios");
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

        db.BeginTransaction("TTUsuarios");
        int? sKeyIdUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTUsuarios";
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varClave_de_Acceso!=null)
                com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            if (varContrasena!=null)
                com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            com.Parameters.AddWithValue("@Activo", varActivo);
            com.Parameters.AddWithValue("@idGrupoUsuarios",Conversion.FormatNull(varidGrupoUsuarios));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdUsuario = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varIdUsuario = sKeyIdUsuario;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTUsuarios");
            }
            catch{}
            throw ex; 
        }
        return sKeyIdUsuario;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTUsuarios");
        int? sKeyIdUsuario = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTUsuarios";
            com.Parameters.AddWithValue("@IdUsuario",Conversion.FormatNull(varIdUsuario));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varClave_de_Acceso!=null)
                com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            if (varContrasena!=null)
                com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            com.Parameters.AddWithValue("@Activo", varActivo);
            com.Parameters.AddWithValue("@idGrupoUsuarios",Conversion.FormatNull(varidGrupoUsuarios));

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdUsuario = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varIdUsuario = sKeyIdUsuario;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTUsuarios");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyIdUsuario, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyIdUsuario.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTUsuarios");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTUsuarios";
com.Parameters.AddWithValue("@IdUsuario",KeyIdUsuario);
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
                    db.RollBackTransaction("TTUsuarios");
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
            IdUsuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTUsuarios_IdUsuario"]);
            Nombre = ds.Tables[0].Rows[0]["TTUsuarios_Nombre"].ToString();
            Clave_de_Acceso = ds.Tables[0].Rows[0]["TTUsuarios_Clave_de_Acceso"].ToString();
            Contrasena = ds.Tables[0].Rows[0]["TTUsuarios_Contrasena"].ToString();
            if (ds.Tables[0].Rows[0]["TTUsuarios_Activo"] != DBNull.Value)
                Activo = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTUsuarios_Activo"]);
            idGrupoUsuarios = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTUsuarios_idGrupoUsuarios"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyIdUsuario, Boolean ConRelaciones){
        DataSet ds;
        if (KeyIdUsuario == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTUsuarios";
            else
                com.CommandText="sp_GetTTUsuarios";
com.Parameters.AddWithValue("@IdUsuario",KeyIdUsuario);

            com.CommandType=CommandType.StoredProcedure;
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
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.IdUsuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyClave_de_Acceso(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.Clave_de_Acceso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyContrasena(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.Contrasena = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyActivo(Boolean Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.Activo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyidGrupoUsuarios(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTUsuarios.IdUsuario As TTUsuarios_IdUsuario,        TTUsuarios.Nombre As TTUsuarios_Nombre,        TTUsuarios.Clave_de_Acceso As TTUsuarios_Clave_de_Acceso,        TTUsuarios.Contrasena As TTUsuarios_Contrasena,        TTUsuarios.Activo As TTUsuarios_Activo,        TTUsuarios.idGrupoUsuarios AS TTUsuarios_idGrupoUsuarios,        TTUsuarios_Por_Grupo.IdUsuario AS TTUsuarios_Por_Grupo_IdUsuario   from ( TTUsuarios       LEFT JOIN TTUsuarios_Por_Grupo ON TTUsuarios_Por_Grupo.IdUsuario=TTUsuarios.idGrupoUsuarios)           Where TTUsuarios.idGrupoUsuarios = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyIdUsuario)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTUsuarios";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTUsuariosCS.TTUsuariosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTUsuarios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTUsuarios_IdUsuario"]) == KeyIdUsuario)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyIdUsuario){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTUsuarios";
com.Parameters.AddWithValue("@IdUsuario",KeyIdUsuario);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataidGrupoUsuariosControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "IdUsuario";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["IdUsuario"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "IdUsuario";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "IdUsuario";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataidGrupoUsuarios(Object ctr, String Filtro){
            public DataTable FillDataidGrupoUsuarios(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTUsuarios_Relacion_TTUsuarios_Por_Grupo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataidGrupoUsuariosControl(ctr, dt);
                return dt;
            }
//            public void FillDataidGrupoUsuarios(Object ctr){
            public DataTable FillDataidGrupoUsuarios(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTUsuarios_Relacion_TTUsuarios_Por_Grupo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataidGrupoUsuariosControl(ctr, dt);
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
        ev.Graphics.DrawString("Usuarios", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Clave: " + this.varIdUsuario, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre: " + this.varNombre, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Clave de Acceso: " + this.varClave_de_Acceso, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Contraseña: " + this.varContrasena, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Activo: " + this.varActivo, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varidGrupoUsuarios != null)
        {
            /*TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo myRelationWhitTTUsuarios_Por_Grupo = new TTUsuarios_Por_GrupoCS.objectBussinessTTUsuarios_Por_Grupo();
            myRelationWhitTTUsuarios_Por_Grupo.GetByKeyIdUsuario(this.varidGrupoUsuarios);
            ev.Graphics.DrawString("Grupo de Usuarios: " + myRelationWhitTTUsuarios_Por_Grupo.IdUsuario , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }
        else {
            /*ev.Graphics.DrawString("Grupo de Usuarios: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;*/
        }


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            /*
            if (sDTid == "13087")
            {
                this.Filters[indexFilter].IdUsuario = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13088")
            {
                this.Filters[indexFilter].Nombre = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13089")
            {
                this.Filters[indexFilter].Clave_de_Acceso = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13090")
            {
                this.Filters[indexFilter].Contrasena = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13091")
            {
                this.Filters[indexFilter].Activo = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "37945")
            {
                this.Filters[indexFilter].idGrupoUsuarios = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTUsuarios_Por_GrupoCS.TTUsuarios_Por_GrupoFilters[])filter;
            }

            */
        }
    }
}