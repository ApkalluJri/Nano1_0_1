using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlow_FasesCS
{
    public class TTWorkFlow_FasesFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varWorkFlow =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlowCS.TTWorkFlowFilters[] varWorkFlow;
        public TTClassSpecials.FiltersTypes.Dependientes WorkFlow{
            get { return varWorkFlow; }
            set { varWorkFlow = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varNumero_de_Fase =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Numero_de_Fase{
            get { return varNumero_de_Fase; }
            set { varNumero_de_Fase = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Fase =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Tipo_de_FaseCS.TTWorkFlow_Tipo_de_FaseFilters[] varTipo_de_Fase;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Fase{
            get { return varTipo_de_Fase; }
            set { varTipo_de_Fase = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Distribucion_de_Trabajo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Tipo_Distribucion_TrabajoCS.TTWorkFlow_Tipo_Distribucion_TrabajoFilters[] varTipo_de_Distribucion_de_Trabajo;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Distribucion_de_Trabajo{
            get { return varTipo_de_Distribucion_de_Trabajo; }
            set { varTipo_de_Distribucion_de_Trabajo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Control_de_Flujo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Tipo_Control_FlujoCS.TTWorkFlow_Tipo_Control_FlujoFilters[] varTipo_de_Control_de_Flujo;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Control_de_Flujo{
            get { return varTipo_de_Control_de_Flujo; }
            set { varTipo_de_Control_de_Flujo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstatus_de_Fase =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Estatus_de_FaseCS.TTWorkFlow_Estatus_de_FaseFilters[] varEstatus_de_Fase;
        public TTClassSpecials.FiltersTypes.Dependientes Estatus_de_Fase{
            get { return varEstatus_de_Fase; }
            set { varEstatus_de_Fase = value; }
        }

    }
public class objectBussinessTTWorkFlow_Fases{
    public int iProcess = 15801;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlow_FasesFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varWorkFlow;
	private int? varFolio;
	private int? varNumero_de_Fase;
	private String varNombre;
	private int? varTipo_de_Fase;
	private int? varTipo_de_Distribucion_de_Trabajo;
	private int? varTipo_de_Control_de_Flujo;
	private int? varEstatus_de_Fase;
		
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

    public TTWorkFlow_FasesFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlow_FasesFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlow_FasesFilters[1];
            filters[0] = value;
        }
    }

    public int? WorkFlow{
        get { return varWorkFlow;}
        set { varWorkFlow = value;}
    }
    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Numero_de_Fase{
        get { return varNumero_de_Fase;}
        set { varNumero_de_Fase = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public int? Tipo_de_Fase{
        get { return varTipo_de_Fase;}
        set { varTipo_de_Fase = value;}
    }
    public int? Tipo_de_Distribucion_de_Trabajo{
        get { return varTipo_de_Distribucion_de_Trabajo;}
        set { varTipo_de_Distribucion_de_Trabajo = value;}
    }
    public int? Tipo_de_Control_de_Flujo{
        get { return varTipo_de_Control_de_Flujo;}
        set { varTipo_de_Control_de_Flujo = value;}
    }
    public int? Estatus_de_Fase{
        get { return varEstatus_de_Fase;}
        set { varEstatus_de_Fase = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Fases", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Fases";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Fases", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Fases", fil);
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
                  string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Fases_WorkFlow": sortExpression = "TTWorkFlow_Fases.WorkFlow"; break;  case "WorkFlow_Nombre": sortExpression = "WorkFlow.Nombre"; break;  case "TTWorkFlow_Fases_Folio": sortExpression = "TTWorkFlow_Fases.Folio"; break;  case "TTWorkFlow_Fases_Numero_de_Fase": sortExpression = "TTWorkFlow_Fases.Numero_de_Fase"; break;  case "TTWorkFlow_Fases_Nombre": sortExpression = "TTWorkFlow_Fases.Nombre"; break;  case "TTWorkFlow_Fases_Tipo_de_Fase": sortExpression = "TTWorkFlow_Fases.Tipo_de_Fase"; break;  case "Tipo_de_Fase_Descripcion": sortExpression = "Tipo_de_Fase.Descripcion"; break;  case "TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo": sortExpression = "TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo"; break;  case "Tipo_de_Distribucion_de_Trabajo_Descripcion": sortExpression = "Tipo_de_Distribucion_de_Trabajo.Descripcion"; break;  case "TTWorkFlow_Fases_Tipo_de_Control_de_Flujo": sortExpression = "TTWorkFlow_Fases.Tipo_de_Control_de_Flujo"; break;  case "Tipo_de_Control_de_Flujo_Descripcion": sortExpression = "Tipo_de_Control_de_Flujo.Descripcion"; break;  case "TTWorkFlow_Fases_Estatus_de_Fase": sortExpression = "TTWorkFlow_Fases.Estatus_de_Fase"; break;  case "Estatus_de_Fase_Descripcion": sortExpression = "Estatus_de_Fase.Descripcion"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow_Fases.WorkFlow, WorkFlow.Nombre, TTWorkFlow_Fases.Folio, TTWorkFlow_Fases.Numero_de_Fase, TTWorkFlow_Fases.Nombre, TTWorkFlow_Fases.Tipo_de_Fase, Tipo_de_Fase.Descripcion, TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo, Tipo_de_Distribucion_de_Trabajo.Descripcion, TTWorkFlow_Fases.Tipo_de_Control_de_Flujo, Tipo_de_Control_de_Flujo.Descripcion, TTWorkFlow_Fases.Estatus_de_Fase, Estatus_de_Fase.Descripcion" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        WorkFlow.Nombre AS WorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        Tipo_de_Fase.Descripcion AS Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        Tipo_de_Distribucion_de_Trabajo.Descripcion AS Tipo_de_Distribucion_de_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        Tipo_de_Control_de_Flujo.Descripcion AS Tipo_de_Control_de_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        Estatus_de_Fase.Descripcion AS Estatus_de_Fase_Descripcion ";             string fieldsForExport = " TTWorkFlow_Fases.WorkFlow AS [WorkFlow],        WorkFlow.Nombre AS [WorkFlow Nombre],        TTWorkFlow_Fases.Folio As [Folio],        TTWorkFlow_Fases.Numero_de_Fase As [Numero de Fase],        TTWorkFlow_Fases.Nombre As [Nombre],        TTWorkFlow_Fases.Tipo_de_Fase AS [Tipo de Fase],        Tipo_de_Fase.Descripcion AS [Tipo de Fase Descripcion],        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS [Tipo de Distribucion de Trabajo],        Tipo_de_Distribucion_de_Trabajo.Descripcion AS [Tipo de Distribucion de Trabajo Descripcion],        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS [Tipo de Control de Flujo],        Tipo_de_Control_de_Flujo.Descripcion AS [Tipo de Control de Flujo Descripcion],        TTWorkFlow_Fases.Estatus_de_Fase AS [Estatus de Fase],        Estatus_de_Fase.Descripcion AS [Estatus de Fase Descripcion] ";             string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        WorkFlow.Nombre AS WorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        Tipo_de_Fase.Descripcion AS Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        Tipo_de_Distribucion_de_Trabajo.Descripcion AS Tipo_de_Distribucion_de_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        Tipo_de_Control_de_Flujo.Descripcion AS Tipo_de_Control_de_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        Estatus_de_Fase.Descripcion AS Estatus_de_Fase_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Fases.WorkFlow, WorkFlow.Nombre, TTWorkFlow_Fases.Folio, TTWorkFlow_Fases.Numero_de_Fase, TTWorkFlow_Fases.Nombre, TTWorkFlow_Fases.Tipo_de_Fase, Tipo_de_Fase.Descripcion, TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo, Tipo_de_Distribucion_de_Trabajo.Descripcion, TTWorkFlow_Fases.Tipo_de_Control_de_Flujo, Tipo_de_Control_de_Flujo.Descripcion, TTWorkFlow_Fases.Estatus_de_Fase, Estatus_de_Fase.Descripcion" : Order);         string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        WorkFlow.Nombre AS WorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        Tipo_de_Fase.Descripcion AS Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        Tipo_de_Distribucion_de_Trabajo.Descripcion AS Tipo_de_Distribucion_de_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        Tipo_de_Control_de_Flujo.Descripcion AS Tipo_de_Control_de_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        Estatus_de_Fase.Descripcion AS Estatus_de_Fase_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Fases.WorkFlow, WorkFlow.Nombre, TTWorkFlow_Fases.Folio, TTWorkFlow_Fases.Numero_de_Fase, TTWorkFlow_Fases.Nombre, TTWorkFlow_Fases.Tipo_de_Fase, Tipo_de_Fase.Descripcion, TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo, Tipo_de_Distribucion_de_Trabajo.Descripcion, TTWorkFlow_Fases.Tipo_de_Control_de_Flujo, Tipo_de_Control_de_Flujo.Descripcion, TTWorkFlow_Fases.Estatus_de_Fase, Estatus_de_Fase.Descripcion" : Order);         string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        WorkFlow.Nombre AS WorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        Tipo_de_Fase.Descripcion AS Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        Tipo_de_Distribucion_de_Trabajo.Descripcion AS Tipo_de_Distribucion_de_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        Tipo_de_Control_de_Flujo.Descripcion AS Tipo_de_Control_de_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        Estatus_de_Fase.Descripcion AS Estatus_de_Fase_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Fases.WorkFlow, WorkFlow.Nombre, TTWorkFlow_Fases.Folio, TTWorkFlow_Fases.Numero_de_Fase, TTWorkFlow_Fases.Nombre, TTWorkFlow_Fases.Tipo_de_Fase, Tipo_de_Fase.Descripcion, TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo, Tipo_de_Distribucion_de_Trabajo.Descripcion, TTWorkFlow_Fases.Tipo_de_Control_de_Flujo, Tipo_de_Control_de_Flujo.Descripcion, TTWorkFlow_Fases.Estatus_de_Fase, Estatus_de_Fase.Descripcion" : Order);         string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        WorkFlow.Nombre AS WorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        Tipo_de_Fase.Descripcion AS Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        Tipo_de_Distribucion_de_Trabajo.Descripcion AS Tipo_de_Distribucion_de_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        Tipo_de_Control_de_Flujo.Descripcion AS Tipo_de_Control_de_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        Estatus_de_Fase.Descripcion AS Estatus_de_Fase_Descripcion ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Fases.WorkFlow, WorkFlow.Nombre, TTWorkFlow_Fases.Folio, TTWorkFlow_Fases.Numero_de_Fase, TTWorkFlow_Fases.Nombre, TTWorkFlow_Fases.Tipo_de_Fase, Tipo_de_Fase.Descripcion, TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo, Tipo_de_Distribucion_de_Trabajo.Descripcion, TTWorkFlow_Fases.Tipo_de_Control_de_Flujo, Tipo_de_Control_de_Flujo.Descripcion, TTWorkFlow_Fases.Estatus_de_Fase, Estatus_de_Fase.Descripcion" : Order);         string from = " from ((((( TTWorkFlow_Fases WITH(NoLock) LEFT JOIN TTWorkFlow as WorkFlow WITH(NoLock) ON WorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase as Tipo_de_Fase WITH(NoLock) ON Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo as Tipo_de_Distribucion_de_Trabajo WITH(NoLock) ON Tipo_de_Distribucion_de_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo as Tipo_de_Control_de_Flujo WITH(NoLock) ON Tipo_de_Control_de_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase as Estatus_de_Fase WITH(NoLock) ON Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Fases";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Fases", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Fases", fil);
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

        db.BeginTransaction("TTWorkFlow_Fases");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow",Conversion.FormatNull(varWorkFlow));
            com.Parameters.AddWithValue("@Numero_de_Fase",Conversion.FormatNull(varNumero_de_Fase));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo_de_Fase",Conversion.FormatNull(varTipo_de_Fase));
            com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo",Conversion.FormatNull(varTipo_de_Distribucion_de_Trabajo));
            com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo",Conversion.FormatNull(varTipo_de_Control_de_Flujo));
            com.Parameters.AddWithValue("@Estatus_de_Fase",Conversion.FormatNull(varEstatus_de_Fase));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Fases");
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

        db.BeginTransaction("TTWorkFlow_Fases");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow",Conversion.FormatNull(varWorkFlow));
            com.Parameters.AddWithValue("@Numero_de_Fase",Conversion.FormatNull(varNumero_de_Fase));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo_de_Fase",Conversion.FormatNull(varTipo_de_Fase));
            com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo",Conversion.FormatNull(varTipo_de_Distribucion_de_Trabajo));
            com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo",Conversion.FormatNull(varTipo_de_Control_de_Flujo));
            com.Parameters.AddWithValue("@Estatus_de_Fase",Conversion.FormatNull(varEstatus_de_Fase));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Fases");
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

        db.BeginTransaction("TTWorkFlow_Fases");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow",Conversion.FormatNull(varWorkFlow));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Numero_de_Fase",Conversion.FormatNull(varNumero_de_Fase));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo_de_Fase",Conversion.FormatNull(varTipo_de_Fase));
            com.Parameters.AddWithValue("@Tipo_de_Distribucion_de_Trabajo",Conversion.FormatNull(varTipo_de_Distribucion_de_Trabajo));
            com.Parameters.AddWithValue("@Tipo_de_Control_de_Flujo",Conversion.FormatNull(varTipo_de_Control_de_Flujo));
            com.Parameters.AddWithValue("@Estatus_de_Fase",Conversion.FormatNull(varEstatus_de_Fase));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Fases");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyWorkFlow, int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyWorkFlow.ToString()+ ","+ KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTWorkFlow_Fases");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow_Fases";
com.Parameters.AddWithValue("@WorkFlow",KeyWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);
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
                    db.RollBackTransaction("TTWorkFlow_Fases");
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
            WorkFlow = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_WorkFlow"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Folio"]);
            Numero_de_Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Numero_de_Fase"]);
            Nombre = ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Nombre"].ToString();
            Tipo_de_Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Tipo_de_Fase"]);
            Tipo_de_Distribucion_de_Trabajo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo"]);
            Tipo_de_Control_de_Flujo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Tipo_de_Control_de_Flujo"]);
            Estatus_de_Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Fases_Estatus_de_Fase"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyWorkFlow, int? KeyFolio, Boolean ConRelaciones){
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
                com.CommandText="sp_GetComplete_TTWorkFlow_Fases";
            else
                com.CommandText="sp_GetTTWorkFlow_Fases";
com.Parameters.AddWithValue("@WorkFlow",KeyWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyWorkFlow(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.WorkFlow = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNumero_de_Fase(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Numero_de_Fase = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Fase(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Tipo_de_Fase = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Distribucion_de_Trabajo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Control_de_Flujo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Tipo_de_Control_de_Flujo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstatus_de_Fase(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Fases.WorkFlow AS TTWorkFlow_Fases_WorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Fases.Folio As TTWorkFlow_Fases_Folio,        TTWorkFlow_Fases.Numero_de_Fase As TTWorkFlow_Fases_Numero_de_Fase,        TTWorkFlow_Fases.Nombre As TTWorkFlow_Fases_Nombre,        TTWorkFlow_Fases.Tipo_de_Fase AS TTWorkFlow_Fases_Tipo_de_Fase,        TTWorkFlow_Tipo_de_Fase.Descripcion AS TTWorkFlow_Tipo_de_Fase_Descripcion,        TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo AS TTWorkFlow_Fases_Tipo_de_Distribucion_de_Trabajo,        TTWorkFlow_Tipo_Distribucion_Trabajo.Descripcion AS TTWorkFlow_Tipo_Distribucion_Trabajo_Descripcion,        TTWorkFlow_Fases.Tipo_de_Control_de_Flujo AS TTWorkFlow_Fases_Tipo_de_Control_de_Flujo,        TTWorkFlow_Tipo_Control_Flujo.Descripcion AS TTWorkFlow_Tipo_Control_Flujo_Descripcion,        TTWorkFlow_Fases.Estatus_de_Fase AS TTWorkFlow_Fases_Estatus_de_Fase,        TTWorkFlow_Estatus_de_Fase.Descripcion AS TTWorkFlow_Estatus_de_Fase_Descripcion   from ((((( TTWorkFlow_Fases       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Fases.WorkFlow)       LEFT JOIN TTWorkFlow_Tipo_de_Fase ON TTWorkFlow_Tipo_de_Fase.Clave=TTWorkFlow_Fases.Tipo_de_Fase)       LEFT JOIN TTWorkFlow_Tipo_Distribucion_Trabajo ON TTWorkFlow_Tipo_Distribucion_Trabajo.Clave=TTWorkFlow_Fases.Tipo_de_Distribucion_de_Trabajo)       LEFT JOIN TTWorkFlow_Tipo_Control_Flujo ON TTWorkFlow_Tipo_Control_Flujo.Clave=TTWorkFlow_Fases.Tipo_de_Control_de_Flujo)       LEFT JOIN TTWorkFlow_Estatus_de_Fase ON TTWorkFlow_Estatus_de_Fase.Clave=TTWorkFlow_Fases.Estatus_de_Fase)           Where TTWorkFlow_Fases.Estatus_de_Fase = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow_Fases";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_FasesCS.TTWorkFlow_FasesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Fases", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Fases_WorkFlow"]) == KeyWorkFlow&& Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Fases_Folio"]) == KeyFolio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyWorkFlow, int? KeyFolio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTWorkFlow_Fases";
com.Parameters.AddWithValue("@WorkFlow",KeyWorkFlow);com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataWorkFlowControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataWorkFlow(Object ctr, String Filtro){
            public DataTable FillDataWorkFlow(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataWorkFlowControl(ctr, dt);
                return dt;
            }
//            public void FillDataWorkFlow(Object ctr){
            public DataTable FillDataWorkFlow(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataWorkFlowControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTipo_de_FaseControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataTipo_de_Fase(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Fase(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_FaseControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Fase(Object ctr){
            public DataTable FillDataTipo_de_Fase(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_FaseControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTipo_de_Distribucion_de_TrabajoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataTipo_de_Distribucion_de_Trabajo(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Distribucion_de_Trabajo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_Distribucion_Trabajo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_Distribucion_de_TrabajoControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Distribucion_de_Trabajo(Object ctr){
            public DataTable FillDataTipo_de_Distribucion_de_Trabajo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_Distribucion_Trabajo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_Distribucion_de_TrabajoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTipo_de_Control_de_FlujoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataTipo_de_Control_de_Flujo(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Control_de_Flujo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_Control_Flujo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_Control_de_FlujoControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Control_de_Flujo(Object ctr){
            public DataTable FillDataTipo_de_Control_de_Flujo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Tipo_Control_Flujo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_Control_de_FlujoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEstatus_de_FaseControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataEstatus_de_Fase(Object ctr, String Filtro){
            public DataTable FillDataEstatus_de_Fase(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Estatus_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEstatus_de_FaseControl(ctr, dt);
                return dt;
            }
//            public void FillDataEstatus_de_Fase(Object ctr){
            public DataTable FillDataEstatus_de_Fase(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Fases_Relacion_TTWorkFlow_Estatus_de_Fase";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstatus_de_FaseControl(ctr, dt);
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