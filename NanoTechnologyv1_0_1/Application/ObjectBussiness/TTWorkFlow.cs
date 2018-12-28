using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlowCS
{
    public class TTWorkFlowFilters
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
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varObjetivo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Objetivo
        {
            get { return varObjetivo; }
            set { varObjetivo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstatus =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Estatus_de_WorkFlowCS.TTWorkFlow_Estatus_de_WorkFlowFilters[] varEstatus;
        public TTClassSpecials.FiltersTypes.Dependientes Estatus{
            get { return varEstatus; }
            set { varEstatus = value; }
        }
        private TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters varFases =new TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters();
        public TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters Fases{
            get { return varFases; }
            set { varFases = value; }
        }
        private TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters varEstados =new TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters();
        public TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters Estados{
            get { return varEstados; }
            set { varEstados = value; }
        }
        private TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters varMatriz_de_Estados =new TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters();
        public TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters Matriz_de_Estados{
            get { return varMatriz_de_Estados; }
            set { varMatriz_de_Estados = value; }
        }
        private TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters varRoles_por_Estado =new TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters();
        public TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters Roles_por_Estado{
            get { return varRoles_por_Estado; }
            set { varRoles_por_Estado = value; }
        }
        private TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters varInformacion_por_Estado =new TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters();
        public TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters Informacion_por_Estado{
            get { return varInformacion_por_Estado; }
            set { varInformacion_por_Estado = value; }
        }
        private TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters varCondiciones_por_Estado =new TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters();
        public TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters Condiciones_por_Estado{
            get { return varCondiciones_por_Estado; }
            set { varCondiciones_por_Estado = value; }
        }

    }
public class objectBussinessTTWorkFlow{
    public int iProcess = 15799;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlowFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private String varNombre;
	private String varDescripcion;
	private String varObjetivo;
	private int? varEstatus;
    private TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[] varFases;
    private TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[] varEstados;
    private TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[] varMatriz_de_Estados;
    private TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[] varRoles_por_Estado;
    private TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[] varInformacion_por_Estado;
    private TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[] varCondiciones_por_Estado;
		
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

    public TTWorkFlowFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlowFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlowFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public String Objetivo{
        get { return varObjetivo;}
        set { varObjetivo = value;}
    }
    public int? Estatus{
        get { return varEstatus;}
        set { varEstatus = value;}
    }
    public TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[] Fases{
        get { return varFases;}
        set { varFases = value;}
    }
    public TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[] Estados{
        get { return varEstados;}
        set { varEstados = value;}
    }
    public TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[] Matriz_de_Estados{
        get { return varMatriz_de_Estados;}
        set { varMatriz_de_Estados = value;}
    }
    public TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[] Roles_por_Estado{
        get { return varRoles_por_Estado;}
        set { varRoles_por_Estado = value;}
    }
    public TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[] Informacion_por_Estado{
        get { return varInformacion_por_Estado;}
        set { varInformacion_por_Estado = value;}
    }
    public TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[] Condiciones_por_Estado{
        get { return varCondiciones_por_Estado;}
        set { varCondiciones_por_Estado = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlowCS.TTWorkFlowFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow";
        else
            com.CommandText="sp_SelAllTTWorkFlow";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlowCS.TTWorkFlowFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow", fil);
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
                  string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Folio": sortExpression = "TTWorkFlow.Folio"; break;  case "TTWorkFlow_Nombre": sortExpression = "TTWorkFlow.Nombre"; break;  case "TTWorkFlow_Descripcion": sortExpression = "TTWorkFlow.Descripcion"; break;  case "TTWorkFlow_Objetivo": sortExpression = "TTWorkFlow.Objetivo"; break;  case "TTWorkFlow_Estatus": sortExpression = "TTWorkFlow.Estatus"; break;  case "Estatus_Descripcion": sortExpression = "Estatus.Descripcion"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow.Folio, TTWorkFlow.Nombre, TTWorkFlow.Descripcion, TTWorkFlow.Objetivo, TTWorkFlow.Estatus, Estatus.Descripcion" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        Estatus.Descripcion AS Estatus_Descripcion ";             string fieldsForExport = " TTWorkFlow.Folio As [Folio],        TTWorkFlow.Nombre As [Nombre],        TTWorkFlow.Descripcion As [Descripcion],        TTWorkFlow.Objetivo As [Objetivo],        TTWorkFlow.Estatus AS [Estatus],        Estatus.Descripcion AS [Estatus Descripcion] ";             string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        Estatus.Descripcion AS Estatus_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow.Folio, TTWorkFlow.Nombre, TTWorkFlow.Descripcion, TTWorkFlow.Objetivo, TTWorkFlow.Estatus, Estatus.Descripcion" : Order);         string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        Estatus.Descripcion AS Estatus_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow.Folio, TTWorkFlow.Nombre, TTWorkFlow.Descripcion, TTWorkFlow.Objetivo, TTWorkFlow.Estatus, Estatus.Descripcion" : Order);         string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        Estatus.Descripcion AS Estatus_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow.Folio, TTWorkFlow.Nombre, TTWorkFlow.Descripcion, TTWorkFlow.Objetivo, TTWorkFlow.Estatus, Estatus.Descripcion" : Order);         string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        Estatus.Descripcion AS Estatus_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow.Folio, TTWorkFlow.Nombre, TTWorkFlow.Descripcion, TTWorkFlow.Objetivo, TTWorkFlow.Estatus, Estatus.Descripcion" : Order);         string from = " from ( TTWorkFlow WITH(NoLock) LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow as Estatus WITH(NoLock) ON Estatus.Clave=TTWorkFlow.Estatus)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow";
        else
            com.CommandText="sp_SelAllTTWorkFlow";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlowCS.TTWorkFlowFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow", fil);
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

        db.BeginTransaction("TTWorkFlow");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow";
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            if (varObjetivo!=null)
                com.Parameters.AddWithValue("@Objetivo", Convierte(varObjetivo,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Objetivo", DBNull.Value);
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varFases != null)
            {
                for (int i = 0;i< varFases.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Fases";
                    com.Parameters.AddWithValue("@WorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Numero_de_Fase", Conversion.FormatNull(varFases[i].Numero_de_Fase));
                com.Parameters.AddWithValue("@Nombre", Convierte(varFases[i].Nombre,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Tipo_de_Fase", Conversion.FormatNull(varFases[i].Tipo_de_Fase));
                com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo", Conversion.FormatNull(varFases[i].Tipo_de_Distribucion_de_Trabajo));
                com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo", Conversion.FormatNull(varFases[i].Tipo_de_Control_de_Flujo));
                com.Parameters.AddWithValue("@Estatus_de_Fase", Conversion.FormatNull(varFases[i].Estatus_de_Fase));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varEstados != null)
            {
                for (int i = 0;i< varEstados.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Estados";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varEstados[i].Fase));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varEstados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varEstados[i].Campo));
                com.Parameters.AddWithValue("@Codigo_Estado", Conversion.FormatNull(varEstados[i].Codigo_Estado));
                com.Parameters.AddWithValue("@Nombre", Convierte(varEstados[i].Nombre,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Valor", Conversion.FormatNull(varEstados[i].Valor));
                com.Parameters.AddWithValue("@Texto", Convierte(varEstados[i].Texto,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varMatriz_de_Estados != null)
            {
                for (int i = 0;i< varMatriz_de_Estados.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Matriz_de_Estados";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varMatriz_de_Estados[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varMatriz_de_Estados[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varMatriz_de_Estados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varMatriz_de_Estados[i].Campo));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varMatriz_de_Estados[i].Visible));
                com.Parameters.AddWithValue("@Obligatorio", Conversion.FormatNull(varMatriz_de_Estados[i].Obligatorio));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varMatriz_de_Estados[i].Solo_Lectura));
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varMatriz_de_Estados[i].Etiqueta,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Valor_por_Defecto", Convierte(varMatriz_de_Estados[i].Valor_por_Defecto,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Texto_de_Ayuda", Convierte(varMatriz_de_Estados[i].Texto_de_Ayuda,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varRoles_por_Estado != null)
            {
                for (int i = 0;i< varRoles_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Roles_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varRoles_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varRoles_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Rol_de_Usuario", Conversion.FormatNull(varRoles_por_Estado[i].Rol_de_Usuario));
                com.Parameters.AddWithValue("@Transicion_de_Fase", Conversion.FormatNull(varRoles_por_Estado[i].Transicion_de_Fase));
                com.Parameters.AddWithValue("@Permiso_Consultar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Consultar));
                com.Parameters.AddWithValue("@Permiso_Nuevo", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Nuevo));
                com.Parameters.AddWithValue("@Permiso_Modificar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Modificar));
                com.Parameters.AddWithValue("@Permiso_Eliminar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Eliminar));
                com.Parameters.AddWithValue("@Permiso_Exportar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Exportar));
                com.Parameters.AddWithValue("@Permiso_Imprimir", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Imprimir));
                com.Parameters.AddWithValue("@Permiso_Configuracion", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Configuracion));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varInformacion_por_Estado != null)
            {
                for (int i = 0;i< varInformacion_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Informacion_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varInformacion_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varInformacion_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varInformacion_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Carpeta", Conversion.FormatNull(varInformacion_por_Estado[i].Carpeta));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varInformacion_por_Estado[i].Visible));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varInformacion_por_Estado[i].Solo_Lectura));
                com.Parameters.AddWithValue("@Obligatorios", Conversion.FormatNull(varInformacion_por_Estado[i].Obligatorios));
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varInformacion_por_Estado[i].Etiqueta,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varCondiciones_por_Estado != null)
            {
                for (int i = 0;i< varCondiciones_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Condiciones_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varCondiciones_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varCondiciones_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Operador_de_Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador_de_Condicion));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varCondiciones_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varCondiciones_por_Estado[i].Campo));
                com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Condicion));
                com.Parameters.AddWithValue("@Operador", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador));
                com.Parameters.AddWithValue("@Valor_Operador", Convierte(varCondiciones_por_Estado[i].Valor_Operador,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Prioridad", Conversion.FormatNull(varCondiciones_por_Estado[i].Prioridad));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow");
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

        db.BeginTransaction("TTWorkFlow");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow";
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            if (varObjetivo!=null)
                com.Parameters.AddWithValue("@Objetivo", Convierte(varObjetivo,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Objetivo", DBNull.Value);
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varFases != null)
            {
                for (int i = 0;i< varFases.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Fases";
                    com.Parameters.AddWithValue("@WorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Numero_de_Fase", Conversion.FormatNull(varFases[i].Numero_de_Fase));
                com.Parameters.AddWithValue("@Nombre", Convierte(varFases[i].Nombre,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Tipo_de_Fase", Conversion.FormatNull(varFases[i].Tipo_de_Fase));
                com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo", Conversion.FormatNull(varFases[i].Tipo_de_Distribucion_de_Trabajo));
                com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo", Conversion.FormatNull(varFases[i].Tipo_de_Control_de_Flujo));
                com.Parameters.AddWithValue("@Estatus_de_Fase", Conversion.FormatNull(varFases[i].Estatus_de_Fase));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varEstados != null)
            {
                for (int i = 0;i< varEstados.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Estados";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varEstados[i].Fase));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varEstados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varEstados[i].Campo));
                com.Parameters.AddWithValue("@Codigo_Estado", Conversion.FormatNull(varEstados[i].Codigo_Estado));
                com.Parameters.AddWithValue("@Nombre", Convierte(varEstados[i].Nombre,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Valor", Conversion.FormatNull(varEstados[i].Valor));
                com.Parameters.AddWithValue("@Texto", Convierte(varEstados[i].Texto,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varMatriz_de_Estados != null)
            {
                for (int i = 0;i< varMatriz_de_Estados.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Matriz_de_Estados";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varMatriz_de_Estados[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varMatriz_de_Estados[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varMatriz_de_Estados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varMatriz_de_Estados[i].Campo));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varMatriz_de_Estados[i].Visible));
                com.Parameters.AddWithValue("@Obligatorio", Conversion.FormatNull(varMatriz_de_Estados[i].Obligatorio));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varMatriz_de_Estados[i].Solo_Lectura));
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varMatriz_de_Estados[i].Etiqueta,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Valor_por_Defecto", Convierte(varMatriz_de_Estados[i].Valor_por_Defecto,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Texto_de_Ayuda", Convierte(varMatriz_de_Estados[i].Texto_de_Ayuda,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varRoles_por_Estado != null)
            {
                for (int i = 0;i< varRoles_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Roles_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varRoles_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varRoles_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Rol_de_Usuario", Conversion.FormatNull(varRoles_por_Estado[i].Rol_de_Usuario));
                com.Parameters.AddWithValue("@Transicion_de_Fase", Conversion.FormatNull(varRoles_por_Estado[i].Transicion_de_Fase));
                com.Parameters.AddWithValue("@Permiso_Consultar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Consultar));
                com.Parameters.AddWithValue("@Permiso_Nuevo", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Nuevo));
                com.Parameters.AddWithValue("@Permiso_Modificar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Modificar));
                com.Parameters.AddWithValue("@Permiso_Eliminar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Eliminar));
                com.Parameters.AddWithValue("@Permiso_Exportar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Exportar));
                com.Parameters.AddWithValue("@Permiso_Imprimir", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Imprimir));
                com.Parameters.AddWithValue("@Permiso_Configuracion", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Configuracion));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varInformacion_por_Estado != null)
            {
                for (int i = 0;i< varInformacion_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Informacion_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varInformacion_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varInformacion_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varInformacion_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Carpeta", Conversion.FormatNull(varInformacion_por_Estado[i].Carpeta));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varInformacion_por_Estado[i].Visible));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varInformacion_por_Estado[i].Solo_Lectura));
                com.Parameters.AddWithValue("@Obligatorios", Conversion.FormatNull(varInformacion_por_Estado[i].Obligatorios));
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varInformacion_por_Estado[i].Etiqueta,ConvierteAMayusculas));


                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varCondiciones_por_Estado != null)
            {
                for (int i = 0;i< varCondiciones_por_Estado.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTWorkFlow_Condiciones_por_Estado";
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varCondiciones_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varCondiciones_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Operador_de_Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador_de_Condicion));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varCondiciones_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varCondiciones_por_Estado[i].Campo));
                com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Condicion));
                com.Parameters.AddWithValue("@Operador", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador));
                com.Parameters.AddWithValue("@Valor_Operador", Convierte(varCondiciones_por_Estado[i].Valor_Operador,ConvierteAMayusculas));

                com.Parameters.AddWithValue("@Prioridad", Conversion.FormatNull(varCondiciones_por_Estado[i].Prioridad));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow");
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

        db.BeginTransaction("TTWorkFlow");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            if (varObjetivo!=null)
                com.Parameters.AddWithValue("@Objetivo", Convierte(varObjetivo,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Objetivo", DBNull.Value);
            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Fases Where WorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varFases != null)
            {
                for (int i = 0;i< varFases.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varFases[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@WorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Numero_de_Fase", Conversion.FormatNull(varFases[i].Numero_de_Fase));
                if (varFases[i].Nombre!=null)
                    com.Parameters.AddWithValue("@Nombre", Convierte(varFases[i].Nombre,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@Tipo_de_Fase", Conversion.FormatNull(varFases[i].Tipo_de_Fase));
                com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo", Conversion.FormatNull(varFases[i].Tipo_de_Distribucion_de_Trabajo));
                com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo", Conversion.FormatNull(varFases[i].Tipo_de_Control_de_Flujo));
                com.Parameters.AddWithValue("@Estatus_de_Fase", Conversion.FormatNull(varFases[i].Estatus_de_Fase));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Fases";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Fases";
                        com.Parameters.AddWithValue("@Folio", varFases[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varFases[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Fases " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Estados Where TTWorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varEstados != null)
            {
                for (int i = 0;i< varEstados.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varEstados[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varEstados[i].Fase));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varEstados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varEstados[i].Campo));
                com.Parameters.AddWithValue("@Codigo_Estado", Conversion.FormatNull(varEstados[i].Codigo_Estado));
                if (varEstados[i].Nombre!=null)
                    com.Parameters.AddWithValue("@Nombre", Convierte(varEstados[i].Nombre,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@Valor", Conversion.FormatNull(varEstados[i].Valor));
                if (varEstados[i].Texto!=null)
                    com.Parameters.AddWithValue("@Texto", Convierte(varEstados[i].Texto,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Texto", DBNull.Value);

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Estados";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Estados";
                        com.Parameters.AddWithValue("@Folio", varEstados[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varEstados[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Estados " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Matriz_de_Estados Where TTWorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varMatriz_de_Estados != null)
            {
                for (int i = 0;i< varMatriz_de_Estados.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varMatriz_de_Estados[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varMatriz_de_Estados[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varMatriz_de_Estados[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varMatriz_de_Estados[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varMatriz_de_Estados[i].Campo));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varMatriz_de_Estados[i].Visible));
                com.Parameters.AddWithValue("@Obligatorio", Conversion.FormatNull(varMatriz_de_Estados[i].Obligatorio));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varMatriz_de_Estados[i].Solo_Lectura));
                if (varMatriz_de_Estados[i].Etiqueta!=null)
                    com.Parameters.AddWithValue("@Etiqueta", Convierte(varMatriz_de_Estados[i].Etiqueta,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Etiqueta", DBNull.Value);
                if (varMatriz_de_Estados[i].Valor_por_Defecto!=null)
                    com.Parameters.AddWithValue("@Valor_por_Defecto", Convierte(varMatriz_de_Estados[i].Valor_por_Defecto,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Valor_por_Defecto", DBNull.Value);
                if (varMatriz_de_Estados[i].Texto_de_Ayuda!=null)
                    com.Parameters.AddWithValue("@Texto_de_Ayuda", Convierte(varMatriz_de_Estados[i].Texto_de_Ayuda,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Texto_de_Ayuda", DBNull.Value);

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Matriz_de_Estados";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Matriz_de_Estados";
                        com.Parameters.AddWithValue("@Folio", varMatriz_de_Estados[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varMatriz_de_Estados[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Matriz_de_Estados " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Roles_por_Estado Where TTWorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varRoles_por_Estado != null)
            {
                for (int i = 0;i< varRoles_por_Estado.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varRoles_por_Estado[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varRoles_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varRoles_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Rol_de_Usuario", Conversion.FormatNull(varRoles_por_Estado[i].Rol_de_Usuario));
                com.Parameters.AddWithValue("@Transicion_de_Fase", Conversion.FormatNull(varRoles_por_Estado[i].Transicion_de_Fase));
                com.Parameters.AddWithValue("@Permiso_Consultar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Consultar));
                com.Parameters.AddWithValue("@Permiso_Nuevo", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Nuevo));
                com.Parameters.AddWithValue("@Permiso_Modificar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Modificar));
                com.Parameters.AddWithValue("@Permiso_Eliminar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Eliminar));
                com.Parameters.AddWithValue("@Permiso_Exportar", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Exportar));
                com.Parameters.AddWithValue("@Permiso_Imprimir", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Imprimir));
                com.Parameters.AddWithValue("@Permiso_Configuracion", Conversion.FormatNull(varRoles_por_Estado[i].Permiso_Configuracion));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Roles_por_Estado";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Roles_por_Estado";
                        com.Parameters.AddWithValue("@Folio", varRoles_por_Estado[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varRoles_por_Estado[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Roles_por_Estado " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Informacion_por_Estado Where TTWorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varInformacion_por_Estado != null)
            {
                for (int i = 0;i< varInformacion_por_Estado.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varInformacion_por_Estado[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varInformacion_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varInformacion_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varInformacion_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Carpeta", Conversion.FormatNull(varInformacion_por_Estado[i].Carpeta));
                com.Parameters.AddWithValue("@Visible", Conversion.FormatNull(varInformacion_por_Estado[i].Visible));
                com.Parameters.AddWithValue("@Solo_Lectura", Conversion.FormatNull(varInformacion_por_Estado[i].Solo_Lectura));
                com.Parameters.AddWithValue("@Obligatorios", Conversion.FormatNull(varInformacion_por_Estado[i].Obligatorios));
                if (varInformacion_por_Estado[i].Etiqueta!=null)
                    com.Parameters.AddWithValue("@Etiqueta", Convierte(varInformacion_por_Estado[i].Etiqueta,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Etiqueta", DBNull.Value);

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Informacion_por_Estado";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Informacion_por_Estado";
                        com.Parameters.AddWithValue("@Folio", varInformacion_por_Estado[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varInformacion_por_Estado[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Informacion_por_Estado " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Folio from TTWorkFlow_Condiciones_por_Estado Where TTWorkFlow = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varCondiciones_por_Estado != null)
            {
                for (int i = 0;i< varCondiciones_por_Estado.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varCondiciones_por_Estado[i].Folio.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@TTWorkFlow", sKeyFolio);
                com.Parameters.AddWithValue("@Fase", Conversion.FormatNull(varCondiciones_por_Estado[i].Fase));
                com.Parameters.AddWithValue("@Estado", Conversion.FormatNull(varCondiciones_por_Estado[i].Estado));
                com.Parameters.AddWithValue("@Operador_de_Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador_de_Condicion));
                com.Parameters.AddWithValue("@Proceso", Conversion.FormatNull(varCondiciones_por_Estado[i].Proceso));
                com.Parameters.AddWithValue("@Campo", Conversion.FormatNull(varCondiciones_por_Estado[i].Campo));
                com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondiciones_por_Estado[i].Condicion));
                com.Parameters.AddWithValue("@Operador", Conversion.FormatNull(varCondiciones_por_Estado[i].Operador));
                if (varCondiciones_por_Estado[i].Valor_Operador!=null)
                    com.Parameters.AddWithValue("@Valor_Operador", Convierte(varCondiciones_por_Estado[i].Valor_Operador,ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Valor_Operador", DBNull.Value);
                com.Parameters.AddWithValue("@Prioridad", Conversion.FormatNull(varCondiciones_por_Estado[i].Prioridad));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsTTWorkFlow_Condiciones_por_Estado";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdTTWorkFlow_Condiciones_por_Estado";
                        com.Parameters.AddWithValue("@Folio", varCondiciones_por_Estado[i].Folio);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varCondiciones_por_Estado[i].Folio);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Folio in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from TTWorkFlow_Condiciones_por_Estado " + FiltroDelete), UserInformation, DataReference);
            }
        }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow");
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
            db.BeginTransaction("TTWorkFlow");
            try
            {
                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Fases = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Fases = dbTTWorkFlow_Fases.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Fases Where WorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Fases.Tables.Count > 0)
                    if (recordsTTWorkFlow_Fases.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Fases = int.Parse(recordsTTWorkFlow_Fases.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Fases > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Fases contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Fases.Disconnect();
                                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Estados = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Estados = dbTTWorkFlow_Estados.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Estados Where TTWorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Estados.Tables.Count > 0)
                    if (recordsTTWorkFlow_Estados.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Estados = int.Parse(recordsTTWorkFlow_Estados.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Estados > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Estados contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Estados.Disconnect();
                                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Matriz_de_Estados = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Matriz_de_Estados = dbTTWorkFlow_Matriz_de_Estados.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Matriz_de_Estados Where TTWorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Matriz_de_Estados.Tables.Count > 0)
                    if (recordsTTWorkFlow_Matriz_de_Estados.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Matriz_de_Estados = int.Parse(recordsTTWorkFlow_Matriz_de_Estados.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Matriz_de_Estados > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Matriz_de_Estados contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Matriz_de_Estados.Disconnect();
                                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Roles_por_Estado = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Roles_por_Estado = dbTTWorkFlow_Roles_por_Estado.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Roles_por_Estado Where TTWorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Roles_por_Estado.Tables.Count > 0)
                    if (recordsTTWorkFlow_Roles_por_Estado.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Roles_por_Estado = int.Parse(recordsTTWorkFlow_Roles_por_Estado.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Roles_por_Estado > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Roles_por_Estado contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Roles_por_Estado.Disconnect();
                                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Informacion_por_Estado = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Informacion_por_Estado = dbTTWorkFlow_Informacion_por_Estado.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Informacion_por_Estado Where TTWorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Informacion_por_Estado.Tables.Count > 0)
                    if (recordsTTWorkFlow_Informacion_por_Estado.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Informacion_por_Estado = int.Parse(recordsTTWorkFlow_Informacion_por_Estado.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Informacion_por_Estado > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Informacion_por_Estado contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Informacion_por_Estado.Disconnect();
                                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbTTWorkFlow_Condiciones_por_Estado = new TTDataLayerCS.BD();
                DataSet recordsTTWorkFlow_Condiciones_por_Estado = dbTTWorkFlow_Condiciones_por_Estado.Consulta(new SqlCommand("Select Count(*) From TTWorkFlow_Condiciones_por_Estado Where TTWorkFlow = '" + KeyFolio.ToString() + "'"));
                if (recordsTTWorkFlow_Condiciones_por_Estado.Tables.Count > 0)
                    if (recordsTTWorkFlow_Condiciones_por_Estado.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsTTWorkFlow_Condiciones_por_Estado = int.Parse(recordsTTWorkFlow_Condiciones_por_Estado.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsTTWorkFlow_Condiciones_por_Estado > 0)
                            throw new Exception("No es posible borrar el registro, el proceso TTWorkFlow_Condiciones_por_Estado contiene registros relacionados. \nElimine los registros relacionados para poder borrar el registro actual.");
                    }
                dbTTWorkFlow_Condiciones_por_Estado.Disconnect();
                

                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow";
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
                    db.RollBackTransaction("TTWorkFlow");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Folio"]);
            Nombre = ds.Tables[0].Rows[0]["TTWorkFlow_Nombre"].ToString();
            Descripcion = ds.Tables[0].Rows[0]["TTWorkFlow_Descripcion"].ToString();
            Objetivo = ds.Tables[0].Rows[0]["TTWorkFlow_Objetivo"].ToString();
            Estatus = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Estatus"]);

                {
                    TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases MyDataFases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
                    TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters MyDataFilterFases = new TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters();
                    MyDataFilterFases.WorkFlow.List = new String[1];
                    MyDataFilterFases.WorkFlow.List[0] = Folio.Value.ToString();
                    MyDataFases.Filters = new TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters[1];
                    MyDataFases.Filters[0] = MyDataFilterFases;
                    DataSet dsMulti = MyDataFases.SelAll(true);
                    Fases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Fases[i] = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
                    Fases[i].WorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_WorkFlow"]);
                    Fases[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Folio"]);
                    Fases[i].Numero_de_Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Numero_de_Fase"]);
                    Fases[i].Nombre = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Nombre"].ToString().TrimEnd(' ');
                    Fases[i].Tipo_de_Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Tipo_de_Fase"]);
                    Fases[i].Tipo_de_Distribucion_de_Trabajo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo"]);
                    Fases[i].Tipo_de_Control_de_Flujo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Tipo_de_Control_de_Flujo"]);
                    Fases[i].Estatus_de_Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Fases_Estatus_de_Fase"]);

                    }
               }    
                {
                    TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados MyDataEstados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
                    TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters MyDataFilterEstados = new TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters();
                    MyDataFilterEstados.TTWorkFlow.List = new String[1];
                    MyDataFilterEstados.TTWorkFlow.List[0] = Folio.Value.ToString();
                    MyDataEstados.Filters = new TTWorkFlow_EstadosCS.TTWorkFlow_EstadosFilters[1];
                    MyDataEstados.Filters[0] = MyDataFilterEstados;
                    DataSet dsMulti = MyDataEstados.SelAll(true);
                    Estados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Estados[i] = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
                    Estados[i].TTWorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_TTWorkFlow"]);
                    Estados[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Folio"]);
                    Estados[i].Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Fase"]);
                    Estados[i].Proceso = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Proceso"]);
                    Estados[i].Campo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Campo"]);
                    Estados[i].Codigo_Estado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Codigo_Estado"]);
                    Estados[i].Nombre = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Nombre"].ToString().TrimEnd(' ');
                    Estados[i].Valor = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Valor"]);
                    Estados[i].Texto = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Estados_Texto"].ToString().TrimEnd(' ');

                    }
               }    
                {
                    TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados MyDataMatriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
                    TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters MyDataFilterMatriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters();
                    MyDataFilterMatriz_de_Estados.TTWorkFlow.List = new String[1];
                    MyDataFilterMatriz_de_Estados.TTWorkFlow.List[0] = Folio.Value.ToString();
                    MyDataMatriz_de_Estados.Filters = new TTWorkFlow_Matriz_de_EstadosCS.TTWorkFlow_Matriz_de_EstadosFilters[1];
                    MyDataMatriz_de_Estados.Filters[0] = MyDataFilterMatriz_de_Estados;
                    DataSet dsMulti = MyDataMatriz_de_Estados.SelAll(true);
                    Matriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Matriz_de_Estados[i] = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
                    Matriz_de_Estados[i].TTWorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_TTWorkFlow"]);
                    Matriz_de_Estados[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Folio"]);
                    Matriz_de_Estados[i].Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Fase"]);
                    Matriz_de_Estados[i].Estado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Estado"]);
                    Matriz_de_Estados[i].Proceso = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Proceso"]);
                    Matriz_de_Estados[i].Campo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Campo"]);
                    Matriz_de_Estados[i].Visible = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Visible"]);
                    Matriz_de_Estados[i].Obligatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Obligatorio"]);
                    Matriz_de_Estados[i].Solo_Lectura = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Solo_Lectura"]);
                    Matriz_de_Estados[i].Etiqueta = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Etiqueta"].ToString().TrimEnd(' ');
                    Matriz_de_Estados[i].Valor_por_Defecto = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Valor_por_Defecto"].ToString().TrimEnd(' ');
                    Matriz_de_Estados[i].Texto_de_Ayuda = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Matriz_de_Estados_Texto_de_Ayuda"].ToString().TrimEnd(' ');

                    }
               }    
                {
                    TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado MyDataRoles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
                    TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters MyDataFilterRoles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters();
                    MyDataFilterRoles_por_Estado.TTWorkFlow.List = new String[1];
                    MyDataFilterRoles_por_Estado.TTWorkFlow.List[0] = Folio.Value.ToString();
                    MyDataRoles_por_Estado.Filters = new TTWorkFlow_Roles_por_EstadoCS.TTWorkFlow_Roles_por_EstadoFilters[1];
                    MyDataRoles_por_Estado.Filters[0] = MyDataFilterRoles_por_Estado;
                    DataSet dsMulti = MyDataRoles_por_Estado.SelAll(true);
                    Roles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Roles_por_Estado[i] = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
                    Roles_por_Estado[i].TTWorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_TTWorkFlow"]);
                    Roles_por_Estado[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Folio"]);
                    Roles_por_Estado[i].Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Fase"]);
                    Roles_por_Estado[i].Estado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Estado"]);
                    Roles_por_Estado[i].Rol_de_Usuario = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Rol_de_Usuario"]);
                    Roles_por_Estado[i].Transicion_de_Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Transicion_de_Fase"]);
                    Roles_por_Estado[i].Permiso_Consultar = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Consultar"]);
                    Roles_por_Estado[i].Permiso_Nuevo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Nuevo"]);
                    Roles_por_Estado[i].Permiso_Modificar = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Modificar"]);
                    Roles_por_Estado[i].Permiso_Eliminar = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Eliminar"]);
                    Roles_por_Estado[i].Permiso_Exportar = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Exportar"]);
                    Roles_por_Estado[i].Permiso_Imprimir = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Imprimir"]);
                    Roles_por_Estado[i].Permiso_Configuracion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Roles_por_Estado_Permiso_Configuracion"]);

                    }
               }    
                {
                    TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado MyDataInformacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
                    TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters MyDataFilterInformacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters();
                    MyDataFilterInformacion_por_Estado.TTWorkFlow.List = new String[1];
                    MyDataFilterInformacion_por_Estado.TTWorkFlow.List[0] = Folio.Value.ToString();
                    MyDataInformacion_por_Estado.Filters = new TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters[1];
                    MyDataInformacion_por_Estado.Filters[0] = MyDataFilterInformacion_por_Estado;
                    DataSet dsMulti = MyDataInformacion_por_Estado.SelAll(true);
                    Informacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Informacion_por_Estado[i] = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
                    Informacion_por_Estado[i].TTWorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_TTWorkFlow"]);
                    Informacion_por_Estado[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Folio"]);
                    Informacion_por_Estado[i].Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Fase"]);
                    Informacion_por_Estado[i].Estado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Estado"]);
                    Informacion_por_Estado[i].Proceso = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Proceso"]);
                    Informacion_por_Estado[i].Carpeta = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Carpeta"]);
                    Informacion_por_Estado[i].Visible = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Visible"]);
                    Informacion_por_Estado[i].Solo_Lectura = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Solo_Lectura"]);
                    Informacion_por_Estado[i].Obligatorios = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Obligatorios"]);
                    Informacion_por_Estado[i].Etiqueta = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Informacion_por_Estado_Etiqueta"].ToString().TrimEnd(' ');

                    }
               }    
                {
                    TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado MyDataCondiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
                    TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters MyDataFilterCondiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters();
                    MyDataFilterCondiciones_por_Estado.TTWorkFlow.List = new String[1];
                    MyDataFilterCondiciones_por_Estado.TTWorkFlow.List[0] = Folio.Value.ToString();
                    MyDataCondiciones_por_Estado.Filters = new TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters[1];
                    MyDataCondiciones_por_Estado.Filters[0] = MyDataFilterCondiciones_por_Estado;
                    DataSet dsMulti = MyDataCondiciones_por_Estado.SelAll(true);
                    Condiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Condiciones_por_Estado[i] = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
                    Condiciones_por_Estado[i].TTWorkFlow = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_TTWorkFlow"]);
                    Condiciones_por_Estado[i].Folio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Folio"]);
                    Condiciones_por_Estado[i].Fase = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Fase"]);
                    Condiciones_por_Estado[i].Estado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Estado"]);
                    Condiciones_por_Estado[i].Operador_de_Condicion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion"]);
                    Condiciones_por_Estado[i].Proceso = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Proceso"]);
                    Condiciones_por_Estado[i].Campo = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Campo"]);
                    Condiciones_por_Estado[i].Condicion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Condicion"]);
                    Condiciones_por_Estado[i].Operador = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Operador"]);
                    Condiciones_por_Estado[i].Valor_Operador = dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Valor_Operador"].ToString().TrimEnd(' ');
                    Condiciones_por_Estado[i].Prioridad = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTWorkFlow_Condiciones_por_Estado_Prioridad"]);

                    }
               }    


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
                com.CommandText="sp_GetComplete_TTWorkFlow";
            else
                com.CommandText="sp_GetTTWorkFlow";
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
            com.CommandText="Select         TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        TTWorkFlow_Estatus_de_WorkFlow.Descripcion AS TTWorkFlow_Estatus_de_WorkFlow_Descripcion   from ( TTWorkFlow       LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow ON TTWorkFlow_Estatus_de_WorkFlow.Clave=TTWorkFlow.Estatus)           Where TTWorkFlow.Folio = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        TTWorkFlow_Estatus_de_WorkFlow.Descripcion AS TTWorkFlow_Estatus_de_WorkFlow_Descripcion   from ( TTWorkFlow       LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow ON TTWorkFlow_Estatus_de_WorkFlow.Clave=TTWorkFlow.Estatus)           Where TTWorkFlow.Nombre = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        TTWorkFlow_Estatus_de_WorkFlow.Descripcion AS TTWorkFlow_Estatus_de_WorkFlow_Descripcion   from ( TTWorkFlow       LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow ON TTWorkFlow_Estatus_de_WorkFlow.Clave=TTWorkFlow.Estatus)           Where TTWorkFlow.Descripcion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObjetivo(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        TTWorkFlow_Estatus_de_WorkFlow.Descripcion AS TTWorkFlow_Estatus_de_WorkFlow_Descripcion   from ( TTWorkFlow       LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow ON TTWorkFlow_Estatus_de_WorkFlow.Clave=TTWorkFlow.Estatus)           Where TTWorkFlow.Objetivo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstatus(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow.Folio As TTWorkFlow_Folio,        TTWorkFlow.Nombre As TTWorkFlow_Nombre,        TTWorkFlow.Descripcion As TTWorkFlow_Descripcion,        TTWorkFlow.Objetivo As TTWorkFlow_Objetivo,        TTWorkFlow.Estatus AS TTWorkFlow_Estatus,        TTWorkFlow_Estatus_de_WorkFlow.Descripcion AS TTWorkFlow_Estatus_de_WorkFlow_Descripcion   from ( TTWorkFlow       LEFT JOIN TTWorkFlow_Estatus_de_WorkFlow ON TTWorkFlow_Estatus_de_WorkFlow.Clave=TTWorkFlow.Estatus)           Where TTWorkFlow.Estatus = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlowCS.TTWorkFlowFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTWorkFlow";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataEstatusControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataEstatus(Object ctr, String Filtro){
            public DataTable FillDataEstatus(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Estatus_de_WorkFlow";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEstatusControl(ctr, dt);
                return dt;
            }
//            public void FillDataEstatus(Object ctr){
            public DataTable FillDataEstatus(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Estatus_de_WorkFlow";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstatusControl(ctr, dt);
                return dt;
            }
/*            private void FillDataFasesControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataFases(Object ctr, String Filtro){
            public DataTable FillDataFases(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Fases";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataFasesControl(ctr, dt);
                return dt;
            }
//            public void FillDataFases(Object ctr){
            public DataTable FillDataFases(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Fases";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataFasesControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEstadosControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataEstados(Object ctr, String Filtro){
            public DataTable FillDataEstados(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Estados";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEstadosControl(ctr, dt);
                return dt;
            }
//            public void FillDataEstados(Object ctr){
            public DataTable FillDataEstados(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Estados";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstadosControl(ctr, dt);
                return dt;
            }
/*            private void FillDataMatriz_de_EstadosControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataMatriz_de_Estados(Object ctr, String Filtro){
            public DataTable FillDataMatriz_de_Estados(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Matriz_de_Estados";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataMatriz_de_EstadosControl(ctr, dt);
                return dt;
            }
//            public void FillDataMatriz_de_Estados(Object ctr){
            public DataTable FillDataMatriz_de_Estados(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Matriz_de_Estados";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataMatriz_de_EstadosControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRoles_por_EstadoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataRoles_por_Estado(Object ctr, String Filtro){
            public DataTable FillDataRoles_por_Estado(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Roles_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRoles_por_EstadoControl(ctr, dt);
                return dt;
            }
//            public void FillDataRoles_por_Estado(Object ctr){
            public DataTable FillDataRoles_por_Estado(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Roles_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRoles_por_EstadoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataInformacion_por_EstadoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataInformacion_por_Estado(Object ctr, String Filtro){
            public DataTable FillDataInformacion_por_Estado(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Informacion_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataInformacion_por_EstadoControl(ctr, dt);
                return dt;
            }
//            public void FillDataInformacion_por_Estado(Object ctr){
            public DataTable FillDataInformacion_por_Estado(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Informacion_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataInformacion_por_EstadoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataCondiciones_por_EstadoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataCondiciones_por_Estado(Object ctr, String Filtro){
            public DataTable FillDataCondiciones_por_Estado(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Condiciones_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataCondiciones_por_EstadoControl(ctr, dt);
                return dt;
            }
//            public void FillDataCondiciones_por_Estado(Object ctr){
            public DataTable FillDataCondiciones_por_Estado(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Relacion_TTWorkFlow_Condiciones_por_Estado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataCondiciones_por_EstadoControl(ctr, dt);
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