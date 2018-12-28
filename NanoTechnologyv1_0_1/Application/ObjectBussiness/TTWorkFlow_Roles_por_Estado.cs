using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlow_Roles_por_EstadoCS
{
    public class TTWorkFlow_Roles_por_EstadoFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varTTWorkFlow =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlowCS.TTWorkFlowFilters[] varTTWorkFlow;
        public TTClassSpecials.FiltersTypes.Dependientes TTWorkFlow{
            get { return varTTWorkFlow; }
            set { varTTWorkFlow = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varFase =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters[] varFase;
        public TTClassSpecials.FiltersTypes.Dependientes Fase{
            get { return varFase; }
            set { varFase = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstado =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters[] varEstado;
        public TTClassSpecials.FiltersTypes.Dependientes Estado{
            get { return varEstado; }
            set { varEstado = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRol_de_Usuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTGrupo_de_UsuarioCS.TTGrupo_de_UsuarioFilters[] varRol_de_Usuario;
        public TTClassSpecials.FiltersTypes.Dependientes Rol_de_Usuario{
            get { return varRol_de_Usuario; }
            set { varRol_de_Usuario = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTransicion_de_Fase =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Transicion_de_FaseCS.TTWorkFlow_Transicion_de_FaseFilters[] varTransicion_de_Fase;
        public TTClassSpecials.FiltersTypes.Dependientes Transicion_de_Fase{
            get { return varTransicion_de_Fase; }
            set { varTransicion_de_Fase = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Consultar =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Consultar;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Consultar{
            get { return varPermiso_Consultar; }
            set { varPermiso_Consultar = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Nuevo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Nuevo;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Nuevo{
            get { return varPermiso_Nuevo; }
            set { varPermiso_Nuevo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Modificar =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Modificar;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Modificar{
            get { return varPermiso_Modificar; }
            set { varPermiso_Modificar = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Eliminar =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Eliminar;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Eliminar{
            get { return varPermiso_Eliminar; }
            set { varPermiso_Eliminar = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Exportar =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Exportar;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Exportar{
            get { return varPermiso_Exportar; }
            set { varPermiso_Exportar = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Imprimir =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Imprimir;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Imprimir{
            get { return varPermiso_Imprimir; }
            set { varPermiso_Imprimir = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varPermiso_Configuracion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varPermiso_Configuracion;
        public TTClassSpecials.FiltersTypes.Dependientes Permiso_Configuracion{
            get { return varPermiso_Configuracion; }
            set { varPermiso_Configuracion = value; }
        }

    }
public class objectBussinessTTWorkFlow_Roles_por_Estado{
    public int iProcess = 15812;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlow_Roles_por_EstadoFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varTTWorkFlow;
	private int? varFolio;
	private int? varFase;
	private int? varEstado;
	private int? varRol_de_Usuario;
	private int? varTransicion_de_Fase;
	private int? varPermiso_Consultar;
	private int? varPermiso_Nuevo;
	private int? varPermiso_Modificar;
	private int? varPermiso_Eliminar;
	private int? varPermiso_Exportar;
	private int? varPermiso_Imprimir;
	private int? varPermiso_Configuracion;
		
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

    public TTWorkFlow_Roles_por_EstadoFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlow_Roles_por_EstadoFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlow_Roles_por_EstadoFilters[1];
            filters[0] = value;
        }
    }

    public int? TTWorkFlow{
        get { return varTTWorkFlow;}
        set { varTTWorkFlow = value;}
    }
    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Fase{
        get { return varFase;}
        set { varFase = value;}
    }
    public int? Estado{
        get { return varEstado;}
        set { varEstado = value;}
    }
    public int? Rol_de_Usuario{
        get { return varRol_de_Usuario;}
        set { varRol_de_Usuario = value;}
    }
    public int? Transicion_de_Fase{
        get { return varTransicion_de_Fase;}
        set { varTransicion_de_Fase = value;}
    }
    public int? Permiso_Consultar{
        get { return varPermiso_Consultar;}
        set { varPermiso_Consultar = value;}
    }
    public int? Permiso_Nuevo{
        get { return varPermiso_Nuevo;}
        set { varPermiso_Nuevo = value;}
    }
    public int? Permiso_Modificar{
        get { return varPermiso_Modificar;}
        set { varPermiso_Modificar = value;}
    }
    public int? Permiso_Eliminar{
        get { return varPermiso_Eliminar;}
        set { varPermiso_Eliminar = value;}
    }
    public int? Permiso_Exportar{
        get { return varPermiso_Exportar;}
        set { varPermiso_Exportar = value;}
    }
    public int? Permiso_Imprimir{
        get { return varPermiso_Imprimir;}
        set { varPermiso_Imprimir = value;}
    }
    public int? Permiso_Configuracion{
        get { return varPermiso_Configuracion;}
        set { varPermiso_Configuracion = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Roles_por_Estado", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Roles_por_Estado";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Roles_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Roles_por_Estado", fil);
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
                  string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Roles_por_Estado_TTWorkFlow": sortExpression = "TTWorkFlow_Roles_por_Estado.TTWorkFlow"; break;  case "TTWorkFlow_Nombre": sortExpression = "TTWorkFlow.Nombre"; break;  case "TTWorkFlow_Roles_por_Estado_Folio": sortExpression = "TTWorkFlow_Roles_por_Estado.Folio"; break;  case "TTWorkFlow_Roles_por_Estado_Fase": sortExpression = "TTWorkFlow_Roles_por_Estado.Fase"; break;  case "Fase_Nombre": sortExpression = "Fase.Nombre"; break;  case "TTWorkFlow_Roles_por_Estado_Estado": sortExpression = "TTWorkFlow_Roles_por_Estado.Estado"; break;  case "Estado_Nombre": sortExpression = "Estado.Nombre"; break;  case "TTWorkFlow_Roles_por_Estado_Rol_de_Usuario": sortExpression = "TTWorkFlow_Roles_por_Estado.Rol_de_Usuario"; break;  case "Rol_de_Usuario_Descripcion": sortExpression = "Rol_de_Usuario.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Transicion_de_Fase": sortExpression = "TTWorkFlow_Roles_por_Estado.Transicion_de_Fase"; break;  case "Transicion_de_Fase_Nombre": sortExpression = "Transicion_de_Fase.Nombre"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Consultar": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Consultar"; break;  case "Permiso_Consultar_Descripcion": sortExpression = "Permiso_Consultar.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Nuevo": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Nuevo"; break;  case "Permiso_Nuevo_Descripcion": sortExpression = "Permiso_Nuevo.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Modificar": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Modificar"; break;  case "Permiso_Modificar_Descripcion": sortExpression = "Permiso_Modificar.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Eliminar": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Eliminar"; break;  case "Permiso_Eliminar_Descripcion": sortExpression = "Permiso_Eliminar.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Exportar": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Exportar"; break;  case "Permiso_Exportar_Descripcion": sortExpression = "Permiso_Exportar.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Imprimir": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Imprimir"; break;  case "Permiso_Imprimir_Descripcion": sortExpression = "Permiso_Imprimir.Descripcion"; break;  case "TTWorkFlow_Roles_por_Estado_Permiso_Configuracion": sortExpression = "TTWorkFlow_Roles_por_Estado.Permiso_Configuracion"; break;  case "Permiso_Configuracion_Descripcion": sortExpression = "Permiso_Configuracion.Descripcion"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow_Roles_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Roles_por_Estado.Folio, TTWorkFlow_Roles_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Roles_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Roles_por_Estado.Rol_de_Usuario, Rol_de_Usuario.Descripcion, TTWorkFlow_Roles_por_Estado.Transicion_de_Fase, Transicion_de_Fase.Nombre, TTWorkFlow_Roles_por_Estado.Permiso_Consultar, Permiso_Consultar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Nuevo, Permiso_Nuevo.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Modificar, Permiso_Modificar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Eliminar, Permiso_Eliminar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Exportar, Permiso_Exportar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Imprimir, Permiso_Imprimir.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Configuracion, Permiso_Configuracion.Descripcion" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        Transicion_de_Fase.Nombre AS Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        Permiso_Consultar.Descripcion AS Permiso_Consultar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        Permiso_Nuevo.Descripcion AS Permiso_Nuevo_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        Permiso_Modificar.Descripcion AS Permiso_Modificar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        Permiso_Eliminar.Descripcion AS Permiso_Eliminar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        Permiso_Exportar.Descripcion AS Permiso_Exportar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        Permiso_Imprimir.Descripcion AS Permiso_Imprimir_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        Permiso_Configuracion.Descripcion AS Permiso_Configuracion_Descripcion ";             string fieldsForExport = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS [TTWorkFlow],        TTWorkFlow.Nombre AS [TTWorkFlow Nombre],        TTWorkFlow_Roles_por_Estado.Folio As [Folio],        TTWorkFlow_Roles_por_Estado.Fase AS [Fase],        Fase.Nombre AS [Fase Nombre],        TTWorkFlow_Roles_por_Estado.Estado AS [Estado],        Estado.Nombre AS [Estado Nombre],        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS [Rol de Usuario],        Rol_de_Usuario.Descripcion AS [Rol de Usuario Descripcion],        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS [Transicion de Fase],        Transicion_de_Fase.Nombre AS [Transicion de Fase Nombre],        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS [Permiso Consultar],        Permiso_Consultar.Descripcion AS [Permiso Consultar Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS [Permiso Nuevo],        Permiso_Nuevo.Descripcion AS [Permiso Nuevo Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS [Permiso Modificar],        Permiso_Modificar.Descripcion AS [Permiso Modificar Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS [Permiso Eliminar],        Permiso_Eliminar.Descripcion AS [Permiso Eliminar Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS [Permiso Exportar],        Permiso_Exportar.Descripcion AS [Permiso Exportar Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS [Permiso Imprimir],        Permiso_Imprimir.Descripcion AS [Permiso Imprimir Descripcion],        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS [Permiso Configuracion],        Permiso_Configuracion.Descripcion AS [Permiso Configuracion Descripcion] ";             string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        Transicion_de_Fase.Nombre AS Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        Permiso_Consultar.Descripcion AS Permiso_Consultar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        Permiso_Nuevo.Descripcion AS Permiso_Nuevo_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        Permiso_Modificar.Descripcion AS Permiso_Modificar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        Permiso_Eliminar.Descripcion AS Permiso_Eliminar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        Permiso_Exportar.Descripcion AS Permiso_Exportar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        Permiso_Imprimir.Descripcion AS Permiso_Imprimir_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        Permiso_Configuracion.Descripcion AS Permiso_Configuracion_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Roles_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Roles_por_Estado.Folio, TTWorkFlow_Roles_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Roles_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Roles_por_Estado.Rol_de_Usuario, Rol_de_Usuario.Descripcion, TTWorkFlow_Roles_por_Estado.Transicion_de_Fase, Transicion_de_Fase.Nombre, TTWorkFlow_Roles_por_Estado.Permiso_Consultar, Permiso_Consultar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Nuevo, Permiso_Nuevo.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Modificar, Permiso_Modificar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Eliminar, Permiso_Eliminar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Exportar, Permiso_Exportar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Imprimir, Permiso_Imprimir.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Configuracion, Permiso_Configuracion.Descripcion" : Order);         string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        Transicion_de_Fase.Nombre AS Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        Permiso_Consultar.Descripcion AS Permiso_Consultar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        Permiso_Nuevo.Descripcion AS Permiso_Nuevo_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        Permiso_Modificar.Descripcion AS Permiso_Modificar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        Permiso_Eliminar.Descripcion AS Permiso_Eliminar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        Permiso_Exportar.Descripcion AS Permiso_Exportar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        Permiso_Imprimir.Descripcion AS Permiso_Imprimir_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        Permiso_Configuracion.Descripcion AS Permiso_Configuracion_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Roles_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Roles_por_Estado.Folio, TTWorkFlow_Roles_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Roles_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Roles_por_Estado.Rol_de_Usuario, Rol_de_Usuario.Descripcion, TTWorkFlow_Roles_por_Estado.Transicion_de_Fase, Transicion_de_Fase.Nombre, TTWorkFlow_Roles_por_Estado.Permiso_Consultar, Permiso_Consultar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Nuevo, Permiso_Nuevo.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Modificar, Permiso_Modificar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Eliminar, Permiso_Eliminar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Exportar, Permiso_Exportar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Imprimir, Permiso_Imprimir.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Configuracion, Permiso_Configuracion.Descripcion" : Order);         string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        Transicion_de_Fase.Nombre AS Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        Permiso_Consultar.Descripcion AS Permiso_Consultar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        Permiso_Nuevo.Descripcion AS Permiso_Nuevo_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        Permiso_Modificar.Descripcion AS Permiso_Modificar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        Permiso_Eliminar.Descripcion AS Permiso_Eliminar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        Permiso_Exportar.Descripcion AS Permiso_Exportar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        Permiso_Imprimir.Descripcion AS Permiso_Imprimir_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        Permiso_Configuracion.Descripcion AS Permiso_Configuracion_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Roles_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Roles_por_Estado.Folio, TTWorkFlow_Roles_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Roles_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Roles_por_Estado.Rol_de_Usuario, Rol_de_Usuario.Descripcion, TTWorkFlow_Roles_por_Estado.Transicion_de_Fase, Transicion_de_Fase.Nombre, TTWorkFlow_Roles_por_Estado.Permiso_Consultar, Permiso_Consultar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Nuevo, Permiso_Nuevo.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Modificar, Permiso_Modificar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Eliminar, Permiso_Eliminar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Exportar, Permiso_Exportar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Imprimir, Permiso_Imprimir.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Configuracion, Permiso_Configuracion.Descripcion" : Order);         string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        Transicion_de_Fase.Nombre AS Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        Permiso_Consultar.Descripcion AS Permiso_Consultar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        Permiso_Nuevo.Descripcion AS Permiso_Nuevo_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        Permiso_Modificar.Descripcion AS Permiso_Modificar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        Permiso_Eliminar.Descripcion AS Permiso_Eliminar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        Permiso_Exportar.Descripcion AS Permiso_Exportar_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        Permiso_Imprimir.Descripcion AS Permiso_Imprimir_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        Permiso_Configuracion.Descripcion AS Permiso_Configuracion_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Roles_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Roles_por_Estado.Folio, TTWorkFlow_Roles_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Roles_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Roles_por_Estado.Rol_de_Usuario, Rol_de_Usuario.Descripcion, TTWorkFlow_Roles_por_Estado.Transicion_de_Fase, Transicion_de_Fase.Nombre, TTWorkFlow_Roles_por_Estado.Permiso_Consultar, Permiso_Consultar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Nuevo, Permiso_Nuevo.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Modificar, Permiso_Modificar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Eliminar, Permiso_Eliminar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Exportar, Permiso_Exportar.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Imprimir, Permiso_Imprimir.Descripcion, TTWorkFlow_Roles_por_Estado.Permiso_Configuracion, Permiso_Configuracion.Descripcion" : Order);         string from = " from (((((((((((( TTWorkFlow_Roles_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario as Rol_de_Usuario WITH(NoLock) ON Rol_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase as Transicion_de_Fase WITH(NoLock) ON Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Consultar WITH(NoLock) ON Permiso_Consultar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Nuevo WITH(NoLock) ON Permiso_Nuevo.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Modificar WITH(NoLock) ON Permiso_Modificar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Eliminar WITH(NoLock) ON Permiso_Eliminar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Exportar WITH(NoLock) ON Permiso_Exportar.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Imprimir WITH(NoLock) ON Permiso_Imprimir.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as Permiso_Configuracion WITH(NoLock) ON Permiso_Configuracion.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Roles_por_Estado";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Roles_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Roles_por_Estado", fil);
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

        db.BeginTransaction("TTWorkFlow_Roles_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Roles_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Rol_de_Usuario",Conversion.FormatNull(varRol_de_Usuario));
            com.Parameters.AddWithValue("@Transicion_de_Fase",Conversion.FormatNull(varTransicion_de_Fase));
            com.Parameters.AddWithValue("@Permiso_Consultar",Conversion.FormatNull(varPermiso_Consultar));
            com.Parameters.AddWithValue("@Permiso_Nuevo",Conversion.FormatNull(varPermiso_Nuevo));
            com.Parameters.AddWithValue("@Permiso_Modificar",Conversion.FormatNull(varPermiso_Modificar));
            com.Parameters.AddWithValue("@Permiso_Eliminar",Conversion.FormatNull(varPermiso_Eliminar));
            com.Parameters.AddWithValue("@Permiso_Exportar",Conversion.FormatNull(varPermiso_Exportar));
            com.Parameters.AddWithValue("@Permiso_Imprimir",Conversion.FormatNull(varPermiso_Imprimir));
            com.Parameters.AddWithValue("@Permiso_Configuracion",Conversion.FormatNull(varPermiso_Configuracion));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Roles_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Roles_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Roles_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Rol_de_Usuario",Conversion.FormatNull(varRol_de_Usuario));
            com.Parameters.AddWithValue("@Transicion_de_Fase",Conversion.FormatNull(varTransicion_de_Fase));
            com.Parameters.AddWithValue("@Permiso_Consultar",Conversion.FormatNull(varPermiso_Consultar));
            com.Parameters.AddWithValue("@Permiso_Nuevo",Conversion.FormatNull(varPermiso_Nuevo));
            com.Parameters.AddWithValue("@Permiso_Modificar",Conversion.FormatNull(varPermiso_Modificar));
            com.Parameters.AddWithValue("@Permiso_Eliminar",Conversion.FormatNull(varPermiso_Eliminar));
            com.Parameters.AddWithValue("@Permiso_Exportar",Conversion.FormatNull(varPermiso_Exportar));
            com.Parameters.AddWithValue("@Permiso_Imprimir",Conversion.FormatNull(varPermiso_Imprimir));
            com.Parameters.AddWithValue("@Permiso_Configuracion",Conversion.FormatNull(varPermiso_Configuracion));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Roles_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Roles_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow_Roles_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Rol_de_Usuario",Conversion.FormatNull(varRol_de_Usuario));
            com.Parameters.AddWithValue("@Transicion_de_Fase",Conversion.FormatNull(varTransicion_de_Fase));
            com.Parameters.AddWithValue("@Permiso_Consultar",Conversion.FormatNull(varPermiso_Consultar));
            com.Parameters.AddWithValue("@Permiso_Nuevo",Conversion.FormatNull(varPermiso_Nuevo));
            com.Parameters.AddWithValue("@Permiso_Modificar",Conversion.FormatNull(varPermiso_Modificar));
            com.Parameters.AddWithValue("@Permiso_Eliminar",Conversion.FormatNull(varPermiso_Eliminar));
            com.Parameters.AddWithValue("@Permiso_Exportar",Conversion.FormatNull(varPermiso_Exportar));
            com.Parameters.AddWithValue("@Permiso_Imprimir",Conversion.FormatNull(varPermiso_Imprimir));
            com.Parameters.AddWithValue("@Permiso_Configuracion",Conversion.FormatNull(varPermiso_Configuracion));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Roles_por_Estado");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyTTWorkFlow, int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyTTWorkFlow.ToString()+ ","+ KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTWorkFlow_Roles_por_Estado");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow_Roles_por_Estado";
com.Parameters.AddWithValue("@TTWorkFlow",KeyTTWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);
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
                    db.RollBackTransaction("TTWorkFlow_Roles_por_Estado");
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
            TTWorkFlow = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_TTWorkFlow"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Folio"]);
            Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Fase"]);
            Estado = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Estado"]);
            Rol_de_Usuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Rol_de_Usuario"]);
            Transicion_de_Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Transicion_de_Fase"]);
            Permiso_Consultar = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Consultar"]);
            Permiso_Nuevo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Nuevo"]);
            Permiso_Modificar = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Modificar"]);
            Permiso_Eliminar = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Eliminar"]);
            Permiso_Exportar = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Exportar"]);
            Permiso_Imprimir = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Imprimir"]);
            Permiso_Configuracion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Roles_por_Estado_Permiso_Configuracion"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyTTWorkFlow, int? KeyFolio, Boolean ConRelaciones){
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
                com.CommandText="sp_GetComplete_TTWorkFlow_Roles_por_Estado";
            else
                com.CommandText="sp_GetTTWorkFlow_Roles_por_Estado";
com.Parameters.AddWithValue("@TTWorkFlow",KeyTTWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTTWorkFlow(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.TTWorkFlow = '" + Key + "'";
            com.CommandType=CommandType.Text;
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
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFase(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Fase = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstado(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Estado = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRol_de_Usuario(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Rol_de_Usuario = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTransicion_de_Fase(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Transicion_de_Fase = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Consultar(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Consultar = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Nuevo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Nuevo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Modificar(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Modificar = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Eliminar(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Eliminar = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Exportar(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Exportar = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Imprimir(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Imprimir = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPermiso_Configuracion(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Roles_por_Estado.TTWorkFlow AS TTWorkFlow_Roles_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Roles_por_Estado.Folio As TTWorkFlow_Roles_por_Estado_Folio,        TTWorkFlow_Roles_por_Estado.Fase AS TTWorkFlow_Roles_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Roles_por_Estado.Estado AS TTWorkFlow_Roles_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Roles_por_Estado.Rol_de_Usuario AS TTWorkFlow_Roles_por_Estado_Rol_de_Usuario,        TTGrupo_de_Usuario.Descripcion AS TTGrupo_de_Usuario_Descripcion,        TTWorkFlow_Roles_por_Estado.Transicion_de_Fase AS TTWorkFlow_Roles_por_Estado_Transicion_de_Fase,        TTWorkFlow_Transicion_de_Fase.Nombre AS TTWorkFlow_Transicion_de_Fase_Nombre,        TTWorkFlow_Roles_por_Estado.Permiso_Consultar AS TTWorkFlow_Roles_por_Estado_Permiso_Consultar,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Nuevo AS TTWorkFlow_Roles_por_Estado_Permiso_Nuevo,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Modificar AS TTWorkFlow_Roles_por_Estado_Permiso_Modificar,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Eliminar AS TTWorkFlow_Roles_por_Estado_Permiso_Eliminar,        TTWorkFlow_Respuesta3.Descripcion AS TTWorkFlow_Respuesta3_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Exportar AS TTWorkFlow_Roles_por_Estado_Permiso_Exportar,        TTWorkFlow_Respuesta4.Descripcion AS TTWorkFlow_Respuesta4_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Imprimir AS TTWorkFlow_Roles_por_Estado_Permiso_Imprimir,        TTWorkFlow_Respuesta5.Descripcion AS TTWorkFlow_Respuesta5_Descripcion,        TTWorkFlow_Roles_por_Estado.Permiso_Configuracion AS TTWorkFlow_Roles_por_Estado_Permiso_Configuracion,        TTWorkFlow_Respuesta6.Descripcion AS TTWorkFlow_Respuesta6_Descripcion   from (((((((((((( TTWorkFlow_Roles_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Roles_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Roles_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Roles_por_Estado.Estado)       LEFT JOIN TTGrupo_de_Usuario ON TTGrupo_de_Usuario.IdGrupoUsuario=TTWorkFlow_Roles_por_Estado.Rol_de_Usuario)       LEFT JOIN TTWorkFlow_Transicion_de_Fase ON TTWorkFlow_Transicion_de_Fase.Clave=TTWorkFlow_Roles_por_Estado.Transicion_de_Fase)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Consultar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Nuevo)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Modificar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta3 ON TTWorkFlow_Respuesta3.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Eliminar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta4 ON TTWorkFlow_Respuesta4.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Exportar)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta5 ON TTWorkFlow_Respuesta5.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Imprimir)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta6 ON TTWorkFlow_Respuesta6.Clave=TTWorkFlow_Roles_por_Estado.Permiso_Configuracion)           Where TTWorkFlow_Roles_por_Estado.Permiso_Configuracion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow_Roles_por_Estado";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Roles_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Roles_por_Estado_TTWorkFlow"]) == KeyTTWorkFlow&& Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Roles_por_Estado_Folio"]) == KeyFolio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyTTWorkFlow, int? KeyFolio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTWorkFlow_Roles_por_Estado";
com.Parameters.AddWithValue("@TTWorkFlow",KeyTTWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataTTWorkFlowControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Folio";
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
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///        public void FillDataTTWorkFlow(Object ctr){
        public DataTable FillDataTTWorkFlow(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow";
            com.Parameters.AddWithValue("@@@DatosDTRelacionPadre.Nombre@@", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataTTWorkFlowControl(ctr, dt);
            return dt;
        }
        //public void FillDataTTWorkFlow(Object ctr, int Key){
        public DataTable FillDataTTWorkFlow(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow";
            com.Parameters.AddWithValue("@@@DatosDTRelacionPadre.Nombre@@",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataTTWorkFlowControl(ctr, dt);
            return dt;
        }
/*            private void FillDataFaseControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Numero_de_Fase";
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
                        ((ListBox)ctr).ValueMember = "Numero_de_Fase";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Numero_de_Fase";
                }
            }
*///        public void FillDataFase(Object ctr){
        public DataTable FillDataFase(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataFaseControl(ctr, dt);
            return dt;
        }
        //public void FillDataFase(Object ctr, int Key){
        public DataTable FillDataFase(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataFaseControl(ctr, dt);
            return dt;
        }
/*            private void FillDataEstadoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Codigo_Estado";
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
                        ((ListBox)ctr).ValueMember = "Codigo_Estado";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Codigo_Estado";
                }
            }
*///        public void FillDataEstado(Object ctr){
        public DataTable FillDataEstado(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Estados";
            com.Parameters.AddWithValue("@Fase", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataEstadoControl(ctr, dt);
            return dt;
        }
        //public void FillDataEstado(Object ctr, int Key){
        public DataTable FillDataEstado(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Estados";
            com.Parameters.AddWithValue("@Fase",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataEstadoControl(ctr, dt);
            return dt;
        }
/*            private void FillDataRol_de_UsuarioControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataRol_de_Usuario(Object ctr, String Filtro){
            public DataTable FillDataRol_de_Usuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTGrupo_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRol_de_UsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataRol_de_Usuario(Object ctr){
            public DataTable FillDataRol_de_Usuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTGrupo_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRol_de_UsuarioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTransicion_de_FaseControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataTransicion_de_Fase(Object ctr, String Filtro){
            public DataTable FillDataTransicion_de_Fase(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Transicion_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTransicion_de_FaseControl(ctr, dt);
                return dt;
            }
//            public void FillDataTransicion_de_Fase(Object ctr){
            public DataTable FillDataTransicion_de_Fase(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Transicion_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTransicion_de_FaseControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_ConsultarControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Consultar(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Consultar(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_ConsultarControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Consultar(Object ctr){
            public DataTable FillDataPermiso_Consultar(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_ConsultarControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_NuevoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Nuevo(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Nuevo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_NuevoControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Nuevo(Object ctr){
            public DataTable FillDataPermiso_Nuevo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_NuevoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_ModificarControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Modificar(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Modificar(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_ModificarControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Modificar(Object ctr){
            public DataTable FillDataPermiso_Modificar(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_ModificarControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_EliminarControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Eliminar(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Eliminar(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_EliminarControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Eliminar(Object ctr){
            public DataTable FillDataPermiso_Eliminar(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_EliminarControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_ExportarControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Exportar(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Exportar(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_ExportarControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Exportar(Object ctr){
            public DataTable FillDataPermiso_Exportar(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_ExportarControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_ImprimirControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Imprimir(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Imprimir(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_ImprimirControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Imprimir(Object ctr){
            public DataTable FillDataPermiso_Imprimir(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_ImprimirControl(ctr, dt);
                return dt;
            }
/*            private void FillDataPermiso_ConfiguracionControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataPermiso_Configuracion(Object ctr, String Filtro){
            public DataTable FillDataPermiso_Configuracion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataPermiso_ConfiguracionControl(ctr, dt);
                return dt;
            }
//            public void FillDataPermiso_Configuracion(Object ctr){
            public DataTable FillDataPermiso_Configuracion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Roles_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataPermiso_ConfiguracionControl(ctr, dt);
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
                Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                MyFiltersObligatories[iViews] = MySearch.Filter;
                MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
    }
}