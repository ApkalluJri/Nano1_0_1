using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlow_Condiciones_por_EstadoCS
{
    public class TTWorkFlow_Condiciones_por_EstadoFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varOperador_de_Condicion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTBusinessRules_CondicionOperatorCS.TTBusinessRules_CondicionOperatorFilters[] varOperador_de_Condicion;
        public TTClassSpecials.FiltersTypes.Dependientes Operador_de_Condicion{
            get { return varOperador_de_Condicion; }
            set { varOperador_de_Condicion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProceso =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varProceso;
        public TTClassSpecials.FiltersTypes.Dependientes Proceso{
            get { return varProceso; }
            set { varProceso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCampo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varCampo;
        public TTClassSpecials.FiltersTypes.Dependientes Campo{
            get { return varCampo; }
            set { varCampo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCondicion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTBusinessRules_ConditionCS.TTBusinessRules_ConditionFilters[] varCondicion;
        public TTClassSpecials.FiltersTypes.Dependientes Condicion{
            get { return varCondicion; }
            set { varCondicion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varOperador =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTBusinessRules_TypeOperator2CS.TTBusinessRules_TypeOperator2Filters[] varOperador;
        public TTClassSpecials.FiltersTypes.Dependientes Operador{
            get { return varOperador; }
            set { varOperador = value; }
        }
        private TTClassSpecials.FiltersTypes.String varValor_Operador = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Valor_Operador
        {
            get { return varValor_Operador; }
            set { varValor_Operador = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varPrioridad =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Prioridad{
            get { return varPrioridad; }
            set { varPrioridad = value; }
        }

    }
public class objectBussinessTTWorkFlow_Condiciones_por_Estado{
    public int iProcess = 15815;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlow_Condiciones_por_EstadoFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varTTWorkFlow;
	private int? varFolio;
	private int? varFase;
	private int? varEstado;
	private int? varOperador_de_Condicion;
	private int? varProceso;
	private int? varCampo;
	private int? varCondicion;
	private int? varOperador;
	private String varValor_Operador;
	private int? varPrioridad;
		
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

    public TTWorkFlow_Condiciones_por_EstadoFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlow_Condiciones_por_EstadoFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlow_Condiciones_por_EstadoFilters[1];
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
    public int? Operador_de_Condicion{
        get { return varOperador_de_Condicion;}
        set { varOperador_de_Condicion = value;}
    }
    public int? Proceso{
        get { return varProceso;}
        set { varProceso = value;}
    }
    public int? Campo{
        get { return varCampo;}
        set { varCampo = value;}
    }
    public int? Condicion{
        get { return varCondicion;}
        set { varCondicion = value;}
    }
    public int? Operador{
        get { return varOperador;}
        set { varOperador = value;}
    }
    public String Valor_Operador{
        get { return varValor_Operador;}
        set { varValor_Operador = value;}
    }
    public int? Prioridad{
        get { return varPrioridad;}
        set { varPrioridad = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Condiciones_por_Estado", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Condiciones_por_Estado";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Condiciones_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Condiciones_por_Estado", fil);
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
                  string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Condiciones_por_Estado_TTWorkFlow": sortExpression = "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow"; break;  case "TTWorkFlow_Nombre": sortExpression = "TTWorkFlow.Nombre"; break;  case "TTWorkFlow_Condiciones_por_Estado_Folio": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Folio"; break;  case "TTWorkFlow_Condiciones_por_Estado_Fase": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Fase"; break;  case "Fase_Nombre": sortExpression = "Fase.Nombre"; break;  case "TTWorkFlow_Condiciones_por_Estado_Estado": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Estado"; break;  case "Estado_Nombre": sortExpression = "Estado.Nombre"; break;  case "TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion"; break;  case "Operador_de_Condicion_Descripcion": sortExpression = "Operador_de_Condicion.Descripcion"; break;  case "TTWorkFlow_Condiciones_por_Estado_Proceso": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Proceso"; break;  case "Proceso_Nombre": sortExpression = "Proceso.Nombre"; break;  case "TTWorkFlow_Condiciones_por_Estado_Campo": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Campo"; break;  case "Campo_Nombre": sortExpression = "Campo.Nombre"; break;  case "TTWorkFlow_Condiciones_por_Estado_Condicion": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Condicion"; break;  case "Condicion_Descripcion": sortExpression = "Condicion.Descripcion"; break;  case "TTWorkFlow_Condiciones_por_Estado_Operador": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Operador"; break;  case "Operador_Descripcion": sortExpression = "Operador.Descripcion"; break;  case "TTWorkFlow_Condiciones_por_Estado_Valor_Operador": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Valor_Operador"; break;  case "TTWorkFlow_Condiciones_por_Estado_Prioridad": sortExpression = "TTWorkFlow_Condiciones_por_Estado.Prioridad"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Condiciones_por_Estado.Folio, TTWorkFlow_Condiciones_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Condiciones_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion, Operador_de_Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Condiciones_por_Estado.Campo, Campo.Nombre, TTWorkFlow_Condiciones_por_Estado.Condicion, Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Operador, Operador.Descripcion, TTWorkFlow_Condiciones_por_Estado.Valor_Operador, TTWorkFlow_Condiciones_por_Estado.Prioridad" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        Operador_de_Condicion.Descripcion AS Operador_de_Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        Condicion.Descripcion AS Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        Operador.Descripcion AS Operador_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad ";             string fieldsForExport = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS [TTWorkFlow],        TTWorkFlow.Nombre AS [TTWorkFlow Nombre],        TTWorkFlow_Condiciones_por_Estado.Folio As [Folio],        TTWorkFlow_Condiciones_por_Estado.Fase AS [Fase],        Fase.Nombre AS [Fase Nombre],        TTWorkFlow_Condiciones_por_Estado.Estado AS [Estado],        Estado.Nombre AS [Estado Nombre],        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS [Operador de Condicion],        Operador_de_Condicion.Descripcion AS [Operador de Condicion Descripcion],        TTWorkFlow_Condiciones_por_Estado.Proceso AS [Proceso],        Proceso.Nombre AS [Proceso Nombre],        TTWorkFlow_Condiciones_por_Estado.Campo AS [Campo],        Campo.Nombre AS [Campo Nombre],        TTWorkFlow_Condiciones_por_Estado.Condicion AS [Condicion],        Condicion.Descripcion AS [Condicion Descripcion],        TTWorkFlow_Condiciones_por_Estado.Operador AS [Operador],        Operador.Descripcion AS [Operador Descripcion],        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As [Valor Operador],        TTWorkFlow_Condiciones_por_Estado.Prioridad As [Prioridad] ";             string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        Operador_de_Condicion.Descripcion AS Operador_de_Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        Condicion.Descripcion AS Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        Operador.Descripcion AS Operador_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Condiciones_por_Estado.Folio, TTWorkFlow_Condiciones_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Condiciones_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion, Operador_de_Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Condiciones_por_Estado.Campo, Campo.Nombre, TTWorkFlow_Condiciones_por_Estado.Condicion, Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Operador, Operador.Descripcion, TTWorkFlow_Condiciones_por_Estado.Valor_Operador, TTWorkFlow_Condiciones_por_Estado.Prioridad" : Order);         string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        Operador_de_Condicion.Descripcion AS Operador_de_Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        Condicion.Descripcion AS Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        Operador.Descripcion AS Operador_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Condiciones_por_Estado.Folio, TTWorkFlow_Condiciones_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Condiciones_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion, Operador_de_Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Condiciones_por_Estado.Campo, Campo.Nombre, TTWorkFlow_Condiciones_por_Estado.Condicion, Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Operador, Operador.Descripcion, TTWorkFlow_Condiciones_por_Estado.Valor_Operador, TTWorkFlow_Condiciones_por_Estado.Prioridad" : Order);         string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        Operador_de_Condicion.Descripcion AS Operador_de_Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        Condicion.Descripcion AS Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        Operador.Descripcion AS Operador_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Condiciones_por_Estado.Folio, TTWorkFlow_Condiciones_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Condiciones_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion, Operador_de_Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Condiciones_por_Estado.Campo, Campo.Nombre, TTWorkFlow_Condiciones_por_Estado.Condicion, Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Operador, Operador.Descripcion, TTWorkFlow_Condiciones_por_Estado.Valor_Operador, TTWorkFlow_Condiciones_por_Estado.Prioridad" : Order);         string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        Operador_de_Condicion.Descripcion AS Operador_de_Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        Condicion.Descripcion AS Condicion_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        Operador.Descripcion AS Operador_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Condiciones_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Condiciones_por_Estado.Folio, TTWorkFlow_Condiciones_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Condiciones_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion, Operador_de_Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Condiciones_por_Estado.Campo, Campo.Nombre, TTWorkFlow_Condiciones_por_Estado.Condicion, Condicion.Descripcion, TTWorkFlow_Condiciones_por_Estado.Operador, Operador.Descripcion, TTWorkFlow_Condiciones_por_Estado.Valor_Operador, TTWorkFlow_Condiciones_por_Estado.Prioridad" : Order);         string from = " from (((((((( TTWorkFlow_Condiciones_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator as Operador_de_Condicion WITH(NoLock) ON Operador_de_Condicion.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition as Condicion WITH(NoLock) ON Condicion.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 as Operador WITH(NoLock) ON Operador.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Condiciones_por_Estado";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Condiciones_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Condiciones_por_Estado", fil);
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

        db.BeginTransaction("TTWorkFlow_Condiciones_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Condiciones_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Operador_de_Condicion",Conversion.FormatNull(varOperador_de_Condicion));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Condicion",Conversion.FormatNull(varCondicion));
            com.Parameters.AddWithValue("@Operador",Conversion.FormatNull(varOperador));
            if (varValor_Operador!=null)
                com.Parameters.AddWithValue("@Valor_Operador", Convierte(varValor_Operador,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Valor_Operador", DBNull.Value);
            com.Parameters.AddWithValue("@Prioridad",Conversion.FormatNull(varPrioridad));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Condiciones_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Condiciones_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Condiciones_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Operador_de_Condicion",Conversion.FormatNull(varOperador_de_Condicion));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Condicion",Conversion.FormatNull(varCondicion));
            com.Parameters.AddWithValue("@Operador",Conversion.FormatNull(varOperador));
            if (varValor_Operador!=null)
                com.Parameters.AddWithValue("@Valor_Operador", Convierte(varValor_Operador,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Valor_Operador", DBNull.Value);
            com.Parameters.AddWithValue("@Prioridad",Conversion.FormatNull(varPrioridad));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Condiciones_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Condiciones_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow_Condiciones_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Operador_de_Condicion",Conversion.FormatNull(varOperador_de_Condicion));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Condicion",Conversion.FormatNull(varCondicion));
            com.Parameters.AddWithValue("@Operador",Conversion.FormatNull(varOperador));
            if (varValor_Operador!=null)
                com.Parameters.AddWithValue("@Valor_Operador", Convierte(varValor_Operador,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Valor_Operador", DBNull.Value);
            com.Parameters.AddWithValue("@Prioridad",Conversion.FormatNull(varPrioridad));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Condiciones_por_Estado");
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
            db.BeginTransaction("TTWorkFlow_Condiciones_por_Estado");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow_Condiciones_por_Estado";
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
                    db.RollBackTransaction("TTWorkFlow_Condiciones_por_Estado");
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
            TTWorkFlow = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_TTWorkFlow"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Folio"]);
            Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Fase"]);
            Estado = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Estado"]);
            Operador_de_Condicion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion"]);
            Proceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Proceso"]);
            Campo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Campo"]);
            Condicion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Condicion"]);
            Operador = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Operador"]);
            Valor_Operador = ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Valor_Operador"].ToString();
            Prioridad = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Condiciones_por_Estado_Prioridad"]);



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
                com.CommandText="sp_GetComplete_TTWorkFlow_Condiciones_por_Estado";
            else
                com.CommandText="sp_GetTTWorkFlow_Condiciones_por_Estado";
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
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.TTWorkFlow = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Folio = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Fase = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Estado = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyOperador_de_Condicion(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyProceso(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Proceso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCampo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Campo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCondicion(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Condicion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyOperador(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Operador = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyValor_Operador(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Valor_Operador = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPrioridad(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Condiciones_por_Estado.TTWorkFlow AS TTWorkFlow_Condiciones_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Condiciones_por_Estado.Folio As TTWorkFlow_Condiciones_por_Estado_Folio,        TTWorkFlow_Condiciones_por_Estado.Fase AS TTWorkFlow_Condiciones_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Condiciones_por_Estado.Estado AS TTWorkFlow_Condiciones_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion AS TTWorkFlow_Condiciones_por_Estado_Operador_de_Condicion,        TTBusinessRules_CondicionOperator.Descripcion AS TTBusinessRules_CondicionOperator_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Proceso AS TTWorkFlow_Condiciones_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Condiciones_por_Estado.Campo AS TTWorkFlow_Condiciones_por_Estado_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Condiciones_por_Estado.Condicion AS TTWorkFlow_Condiciones_por_Estado_Condicion,        TTBusinessRules_Condition.Descripcion AS TTBusinessRules_Condition_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Operador AS TTWorkFlow_Condiciones_por_Estado_Operador,        TTBusinessRules_TypeOperator2.Descripcion AS TTBusinessRules_TypeOperator2_Descripcion,        TTWorkFlow_Condiciones_por_Estado.Valor_Operador As TTWorkFlow_Condiciones_por_Estado_Valor_Operador,        TTWorkFlow_Condiciones_por_Estado.Prioridad As TTWorkFlow_Condiciones_por_Estado_Prioridad   from (((((((( TTWorkFlow_Condiciones_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Condiciones_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Condiciones_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Condiciones_por_Estado.Estado)       LEFT JOIN TTBusinessRules_CondicionOperator ON TTBusinessRules_CondicionOperator.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador_de_Condicion)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Condiciones_por_Estado.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Condiciones_por_Estado.Campo)       LEFT JOIN TTBusinessRules_Condition ON TTBusinessRules_Condition.idCondicion=TTWorkFlow_Condiciones_por_Estado.Condicion)       LEFT JOIN TTBusinessRules_TypeOperator2 ON TTBusinessRules_TypeOperator2.idOperator=TTWorkFlow_Condiciones_por_Estado.Operador)           Where TTWorkFlow_Condiciones_por_Estado.Prioridad = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow_Condiciones_por_Estado";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Condiciones_por_EstadoCS.TTWorkFlow_Condiciones_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Condiciones_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Condiciones_por_Estado_TTWorkFlow"]) == KeyTTWorkFlow&& Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Condiciones_por_Estado_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTWorkFlow_Condiciones_por_Estado";
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
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow_Fases";
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
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow_Fases";
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
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow_Estados";
            com.Parameters.AddWithValue("@Fase", DBNull.Value);
            com.Parameters.AddWithValue("@WorkFlow", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataEstadoControl(ctr, dt);
            return dt;
        }
        //public void FillDataEstado(Object ctr, int Key){
        public DataTable FillDataEstado(int Key, int WorkFlow)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTWorkFlow_Estados";
            com.Parameters.AddWithValue("@Fase",Key);
            if( WorkFlow == 0)
                com.Parameters.AddWithValue("@WorkFlow", DBNull.Value);
            else
                com.Parameters.AddWithValue("@WorkFlow", WorkFlow);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataEstadoControl(ctr, dt);
            return dt;
        }
/*            private void FillDataOperador_de_CondicionControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "idOperator";
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
                        ((ListBox)ctr).ValueMember = "idOperator";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idOperator";
                }
            }
*///            public DataTable FillDataOperador_de_Condicion(Object ctr, String Filtro){
            public DataTable FillDataOperador_de_Condicion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_CondicionOperator";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataOperador_de_CondicionControl(ctr, dt);
                return dt;
            }
//            public void FillDataOperador_de_Condicion(Object ctr){
            public DataTable FillDataOperador_de_Condicion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_CondicionOperator";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataOperador_de_CondicionControl(ctr, dt);
                return dt;
            }
/*            private void FillDataProcesoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataProceso(Object ctr, String Filtro){
            public DataTable FillDataProceso(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataProcesoControl(ctr, dt);
                return dt;
            }
//            public void FillDataProceso(Object ctr){
            public DataTable FillDataProceso(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataProcesoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataCampoControl(Object ctr, DataTable dt){
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
*///        public void FillDataCampo(Object ctr){
        public DataTable FillDataCampo(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@ProcesoId", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataCampoControl(ctr, dt);
            return dt;
        }
        //public void FillDataCampo(Object ctr, int Key){
        public DataTable FillDataCampo(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@ProcesoId",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataCampoControl(ctr, dt);
            return dt;
        }
/*            private void FillDataCondicionControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "idCondicion";
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
                        ((ListBox)ctr).ValueMember = "idCondicion";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idCondicion";
                }
            }
*///            public DataTable FillDataCondicion(Object ctr, String Filtro){
            public DataTable FillDataCondicion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_Condition";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataCondicionControl(ctr, dt);
                return dt;
            }
//            public void FillDataCondicion(Object ctr){
            public DataTable FillDataCondicion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_Condition";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataCondicionControl(ctr, dt);
                return dt;
            }
/*            private void FillDataOperadorControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "idOperator";
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
                        ((ListBox)ctr).ValueMember = "idOperator";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idOperator";
                }
            }
*///            public DataTable FillDataOperador(Object ctr, String Filtro){
            public DataTable FillDataOperador(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_TypeOperator2";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataOperadorControl(ctr, dt);
                return dt;
            }
//            public void FillDataOperador(Object ctr){
            public DataTable FillDataOperador(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Condiciones_por_Estado_Relacion_TTBusinessRules_TypeOperator2";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataOperadorControl(ctr, dt);
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