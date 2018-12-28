using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlow_Metas_de_FaseCS
{
    public class TTWorkFlow_Metas_de_FaseFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Meta =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_Tipo_de_MetaCS.TTWorkFlow_Tipo_de_MetaFilters[] varTipo_de_Meta;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Meta{
            get { return varTipo_de_Meta; }
            set { varTipo_de_Meta = value; }
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
        private TTClassSpecials.FiltersTypes.filDecimal varMeta = new TTClassSpecials.FiltersTypes.filDecimal();
        public TTClassSpecials.FiltersTypes.filDecimal Meta
        {
            get { return varMeta; }
            set { varMeta = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varFrecuencia =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_FrecuenciaCS.TTWorkFlow_FrecuenciaFilters[] varFrecuencia;
        public TTClassSpecials.FiltersTypes.Dependientes Frecuencia{
            get { return varFrecuencia; }
            set { varFrecuencia = value; }
        }
        private TTClassSpecials.FiltersTypes.filDecimal varValor_Minimo_para_Alerta = new TTClassSpecials.FiltersTypes.filDecimal();
        public TTClassSpecials.FiltersTypes.filDecimal Valor_Minimo_para_Alerta
        {
            get { return varValor_Minimo_para_Alerta; }
            set { varValor_Minimo_para_Alerta = value; }
        }
        private TTClassSpecials.FiltersTypes.filDecimal varValor_Maximo_para_Alerta = new TTClassSpecials.FiltersTypes.filDecimal();
        public TTClassSpecials.FiltersTypes.filDecimal Valor_Maximo_para_Alerta
        {
            get { return varValor_Maximo_para_Alerta; }
            set { varValor_Maximo_para_Alerta = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varGrupo_Funcional_para_Alerta =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTGrupoFuncionalCS.TTGrupoFuncionalFilters[] varGrupo_Funcional_para_Alerta;
        public TTClassSpecials.FiltersTypes.Dependientes Grupo_Funcional_para_Alerta{
            get { return varGrupo_Funcional_para_Alerta; }
            set { varGrupo_Funcional_para_Alerta = value; }
        }

    }
public class objectBussinessTTWorkFlow_Metas_de_Fase{
    public int iProcess = 15806;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlow_Metas_de_FaseFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varTTWorkFlow;
	private int? varFolio;
	private int? varFase;
	private int? varTipo_de_Meta;
	private int? varProceso;
	private int? varCampo;
	private Decimal? varMeta;
	private int? varFrecuencia;
	private Decimal? varValor_Minimo_para_Alerta;
	private Decimal? varValor_Maximo_para_Alerta;
	private int? varGrupo_Funcional_para_Alerta;
		
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

    public TTWorkFlow_Metas_de_FaseFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlow_Metas_de_FaseFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlow_Metas_de_FaseFilters[1];
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
    public int? Tipo_de_Meta{
        get { return varTipo_de_Meta;}
        set { varTipo_de_Meta = value;}
    }
    public int? Proceso{
        get { return varProceso;}
        set { varProceso = value;}
    }
    public int? Campo{
        get { return varCampo;}
        set { varCampo = value;}
    }
    public Decimal? Meta{
        get { return varMeta;}
        set { varMeta = value;}
    }
    public int? Frecuencia{
        get { return varFrecuencia;}
        set { varFrecuencia = value;}
    }
    public Decimal? Valor_Minimo_para_Alerta{
        get { return varValor_Minimo_para_Alerta;}
        set { varValor_Minimo_para_Alerta = value;}
    }
    public Decimal? Valor_Maximo_para_Alerta{
        get { return varValor_Maximo_para_Alerta;}
        set { varValor_Maximo_para_Alerta = value;}
    }
    public int? Grupo_Funcional_para_Alerta{
        get { return varGrupo_Funcional_para_Alerta;}
        set { varGrupo_Funcional_para_Alerta = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlow_Metas_de_FaseCS.TTWorkFlow_Metas_de_FaseFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Metas_de_Fase", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Metas_de_Fase";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Metas_de_FaseCS.TTWorkFlow_Metas_de_FaseFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Metas_de_Fase", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Metas_de_Fase", fil);
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
                  string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Metas_de_Fase_TTWorkFlow": sortExpression = "TTWorkFlow_Metas_de_Fase.TTWorkFlow"; break;  case "TTWorkFlow_Nombre": sortExpression = "TTWorkFlow.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Folio": sortExpression = "TTWorkFlow_Metas_de_Fase.Folio"; break;  case "TTWorkFlow_Metas_de_Fase_Fase": sortExpression = "TTWorkFlow_Metas_de_Fase.Fase"; break;  case "Fase_Nombre": sortExpression = "Fase.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Tipo_de_Meta": sortExpression = "TTWorkFlow_Metas_de_Fase.Tipo_de_Meta"; break;  case "Tipo_de_Meta_Nombre": sortExpression = "Tipo_de_Meta.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Proceso": sortExpression = "TTWorkFlow_Metas_de_Fase.Proceso"; break;  case "Proceso_Nombre": sortExpression = "Proceso.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Campo": sortExpression = "TTWorkFlow_Metas_de_Fase.Campo"; break;  case "Campo_Nombre": sortExpression = "Campo.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Meta": sortExpression = "TTWorkFlow_Metas_de_Fase.Meta"; break;  case "TTWorkFlow_Metas_de_Fase_Frecuencia": sortExpression = "TTWorkFlow_Metas_de_Fase.Frecuencia"; break;  case "Frecuencia_Nombre": sortExpression = "Frecuencia.Nombre"; break;  case "TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta": sortExpression = "TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta"; break;  case "TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta": sortExpression = "TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta"; break;  case "TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta": sortExpression = "TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta"; break;  case "Grupo_Funcional_para_Alerta_Nombre": sortExpression = "Grupo_Funcional_para_Alerta.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow_Metas_de_Fase.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Metas_de_Fase.Folio, TTWorkFlow_Metas_de_Fase.Fase, Fase.Nombre, TTWorkFlow_Metas_de_Fase.Tipo_de_Meta, Tipo_de_Meta.Nombre, TTWorkFlow_Metas_de_Fase.Proceso, Proceso.Nombre, TTWorkFlow_Metas_de_Fase.Campo, Campo.Nombre, TTWorkFlow_Metas_de_Fase.Meta, TTWorkFlow_Metas_de_Fase.Frecuencia, Frecuencia.Nombre, TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta, TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta, TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta, Grupo_Funcional_para_Alerta.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        Tipo_de_Meta.Nombre AS Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        Frecuencia.Nombre AS Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        Grupo_Funcional_para_Alerta.Nombre AS Grupo_Funcional_para_Alerta_Nombre ";             string fieldsForExport = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS [TTWorkFlow],        TTWorkFlow.Nombre AS [TTWorkFlow Nombre],        TTWorkFlow_Metas_de_Fase.Folio As [Folio],        TTWorkFlow_Metas_de_Fase.Fase AS [Fase],        Fase.Nombre AS [Fase Nombre],        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS [Tipo de Meta],        Tipo_de_Meta.Nombre AS [Tipo de Meta Nombre],        TTWorkFlow_Metas_de_Fase.Proceso AS [Proceso],        Proceso.Nombre AS [Proceso Nombre],        TTWorkFlow_Metas_de_Fase.Campo AS [Campo],        Campo.Nombre AS [Campo Nombre],        TTWorkFlow_Metas_de_Fase.Meta As [Meta],        TTWorkFlow_Metas_de_Fase.Frecuencia AS [Frecuencia],        Frecuencia.Nombre AS [Frecuencia Nombre],        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As [Valor Minimo para Alerta],        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As [Valor Maximo para Alerta],        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS [Grupo Funcional para Alerta],        Grupo_Funcional_para_Alerta.Nombre AS [Grupo Funcional para Alerta Nombre] ";             string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        Tipo_de_Meta.Nombre AS Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        Frecuencia.Nombre AS Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        Grupo_Funcional_para_Alerta.Nombre AS Grupo_Funcional_para_Alerta_Nombre ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Metas_de_Fase.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Metas_de_Fase.Folio, TTWorkFlow_Metas_de_Fase.Fase, Fase.Nombre, TTWorkFlow_Metas_de_Fase.Tipo_de_Meta, Tipo_de_Meta.Nombre, TTWorkFlow_Metas_de_Fase.Proceso, Proceso.Nombre, TTWorkFlow_Metas_de_Fase.Campo, Campo.Nombre, TTWorkFlow_Metas_de_Fase.Meta, TTWorkFlow_Metas_de_Fase.Frecuencia, Frecuencia.Nombre, TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta, TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta, TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta, Grupo_Funcional_para_Alerta.Nombre" : Order);         string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        Tipo_de_Meta.Nombre AS Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        Frecuencia.Nombre AS Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        Grupo_Funcional_para_Alerta.Nombre AS Grupo_Funcional_para_Alerta_Nombre ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Metas_de_Fase.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Metas_de_Fase.Folio, TTWorkFlow_Metas_de_Fase.Fase, Fase.Nombre, TTWorkFlow_Metas_de_Fase.Tipo_de_Meta, Tipo_de_Meta.Nombre, TTWorkFlow_Metas_de_Fase.Proceso, Proceso.Nombre, TTWorkFlow_Metas_de_Fase.Campo, Campo.Nombre, TTWorkFlow_Metas_de_Fase.Meta, TTWorkFlow_Metas_de_Fase.Frecuencia, Frecuencia.Nombre, TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta, TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta, TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta, Grupo_Funcional_para_Alerta.Nombre" : Order);         string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        Tipo_de_Meta.Nombre AS Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        Frecuencia.Nombre AS Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        Grupo_Funcional_para_Alerta.Nombre AS Grupo_Funcional_para_Alerta_Nombre ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Metas_de_Fase.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Metas_de_Fase.Folio, TTWorkFlow_Metas_de_Fase.Fase, Fase.Nombre, TTWorkFlow_Metas_de_Fase.Tipo_de_Meta, Tipo_de_Meta.Nombre, TTWorkFlow_Metas_de_Fase.Proceso, Proceso.Nombre, TTWorkFlow_Metas_de_Fase.Campo, Campo.Nombre, TTWorkFlow_Metas_de_Fase.Meta, TTWorkFlow_Metas_de_Fase.Frecuencia, Frecuencia.Nombre, TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta, TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta, TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta, Grupo_Funcional_para_Alerta.Nombre" : Order);         string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        Tipo_de_Meta.Nombre AS Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        Campo.Nombre AS Campo_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        Frecuencia.Nombre AS Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        Grupo_Funcional_para_Alerta.Nombre AS Grupo_Funcional_para_Alerta_Nombre ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Metas_de_Fase.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Metas_de_Fase.Folio, TTWorkFlow_Metas_de_Fase.Fase, Fase.Nombre, TTWorkFlow_Metas_de_Fase.Tipo_de_Meta, Tipo_de_Meta.Nombre, TTWorkFlow_Metas_de_Fase.Proceso, Proceso.Nombre, TTWorkFlow_Metas_de_Fase.Campo, Campo.Nombre, TTWorkFlow_Metas_de_Fase.Meta, TTWorkFlow_Metas_de_Fase.Frecuencia, Frecuencia.Nombre, TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta, TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta, TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta, Grupo_Funcional_para_Alerta.Nombre" : Order);         string from = " from ((((((( TTWorkFlow_Metas_de_Fase WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta as Tipo_de_Meta WITH(NoLock) ON Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata as Campo WITH(NoLock) ON Campo.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia as Frecuencia WITH(NoLock) ON Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional as Grupo_Funcional_para_Alerta WITH(NoLock) ON Grupo_Funcional_para_Alerta.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Metas_de_Fase";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlow_Metas_de_FaseCS.TTWorkFlow_Metas_de_FaseFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Metas_de_Fase", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Metas_de_Fase", fil);
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

        db.BeginTransaction("TTWorkFlow_Metas_de_Fase");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Metas_de_Fase";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Tipo_de_Meta",Conversion.FormatNull(varTipo_de_Meta));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Meta",Conversion.FormatNull(varMeta));
            com.Parameters.AddWithValue("@Frecuencia",Conversion.FormatNull(varFrecuencia));
            com.Parameters.AddWithValue("@Valor_Minimo_para_Alerta",Conversion.FormatNull(varValor_Minimo_para_Alerta));
            com.Parameters.AddWithValue("@Valor_Maximo_para_Alerta",Conversion.FormatNull(varValor_Maximo_para_Alerta));
            com.Parameters.AddWithValue("@Grupo_Funcional_para_Alerta",Conversion.FormatNull(varGrupo_Funcional_para_Alerta));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Metas_de_Fase");
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

        db.BeginTransaction("TTWorkFlow_Metas_de_Fase");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Metas_de_Fase";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Tipo_de_Meta",Conversion.FormatNull(varTipo_de_Meta));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Meta",Conversion.FormatNull(varMeta));
            com.Parameters.AddWithValue("@Frecuencia",Conversion.FormatNull(varFrecuencia));
            com.Parameters.AddWithValue("@Valor_Minimo_para_Alerta",Conversion.FormatNull(varValor_Minimo_para_Alerta));
            com.Parameters.AddWithValue("@Valor_Maximo_para_Alerta",Conversion.FormatNull(varValor_Maximo_para_Alerta));
            com.Parameters.AddWithValue("@Grupo_Funcional_para_Alerta",Conversion.FormatNull(varGrupo_Funcional_para_Alerta));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Metas_de_Fase");
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

        db.BeginTransaction("TTWorkFlow_Metas_de_Fase");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow_Metas_de_Fase";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Tipo_de_Meta",Conversion.FormatNull(varTipo_de_Meta));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Campo",Conversion.FormatNull(varCampo));
            com.Parameters.AddWithValue("@Meta",Conversion.FormatNull(varMeta));
            com.Parameters.AddWithValue("@Frecuencia",Conversion.FormatNull(varFrecuencia));
            com.Parameters.AddWithValue("@Valor_Minimo_para_Alerta",Conversion.FormatNull(varValor_Minimo_para_Alerta));
            com.Parameters.AddWithValue("@Valor_Maximo_para_Alerta",Conversion.FormatNull(varValor_Maximo_para_Alerta));
            com.Parameters.AddWithValue("@Grupo_Funcional_para_Alerta",Conversion.FormatNull(varGrupo_Funcional_para_Alerta));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Metas_de_Fase");
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
            db.BeginTransaction("TTWorkFlow_Metas_de_Fase");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow_Metas_de_Fase";
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
                    db.RollBackTransaction("TTWorkFlow_Metas_de_Fase");
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
            TTWorkFlow = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_TTWorkFlow"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Folio"]);
            Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Fase"]);
            Tipo_de_Meta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Tipo_de_Meta"]);
            Proceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Proceso"]);
            Campo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Campo"]);
            Meta = Conversion.CambiaToDecimal(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Meta"]);
            Frecuencia = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Frecuencia"]);
            Valor_Minimo_para_Alerta = Conversion.CambiaToDecimal(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta"]);
            Valor_Maximo_para_Alerta = Conversion.CambiaToDecimal(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta"]);
            Grupo_Funcional_para_Alerta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta"]);



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
                com.CommandText="sp_GetComplete_TTWorkFlow_Metas_de_Fase";
            else
                com.CommandText="sp_GetTTWorkFlow_Metas_de_Fase";
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
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.TTWorkFlow = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Folio = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Fase = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Meta(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Tipo_de_Meta = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Proceso = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Campo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyMeta(Decimal Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Meta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFrecuencia(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Frecuencia = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyValor_Minimo_para_Alerta(Decimal Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyValor_Maximo_para_Alerta(Decimal Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyGrupo_Funcional_para_Alerta(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Metas_de_Fase.TTWorkFlow AS TTWorkFlow_Metas_de_Fase_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Metas_de_Fase.Folio As TTWorkFlow_Metas_de_Fase_Folio,        TTWorkFlow_Metas_de_Fase.Fase AS TTWorkFlow_Metas_de_Fase_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Metas_de_Fase.Tipo_de_Meta AS TTWorkFlow_Metas_de_Fase_Tipo_de_Meta,        TTWorkFlow_Tipo_de_Meta.Nombre AS TTWorkFlow_Tipo_de_Meta_Nombre,        TTWorkFlow_Metas_de_Fase.Proceso AS TTWorkFlow_Metas_de_Fase_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Metas_de_Fase.Campo AS TTWorkFlow_Metas_de_Fase_Campo,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTWorkFlow_Metas_de_Fase.Meta As TTWorkFlow_Metas_de_Fase_Meta,        TTWorkFlow_Metas_de_Fase.Frecuencia AS TTWorkFlow_Metas_de_Fase_Frecuencia,        TTWorkFlow_Frecuencia.Nombre AS TTWorkFlow_Frecuencia_Nombre,        TTWorkFlow_Metas_de_Fase.Valor_Minimo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Minimo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Valor_Maximo_para_Alerta As TTWorkFlow_Metas_de_Fase_Valor_Maximo_para_Alerta,        TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta AS TTWorkFlow_Metas_de_Fase_Grupo_Funcional_para_Alerta,        TTGrupoFuncional.Nombre AS TTGrupoFuncional_Nombre   from ((((((( TTWorkFlow_Metas_de_Fase       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Metas_de_Fase.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Metas_de_Fase.Fase)       LEFT JOIN TTWorkFlow_Tipo_de_Meta ON TTWorkFlow_Tipo_de_Meta.Clave=TTWorkFlow_Metas_de_Fase.Tipo_de_Meta)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Metas_de_Fase.Proceso)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTWorkFlow_Metas_de_Fase.Campo)       LEFT JOIN TTWorkFlow_Frecuencia ON TTWorkFlow_Frecuencia.Clave=TTWorkFlow_Metas_de_Fase.Frecuencia)       LEFT JOIN TTGrupoFuncional ON TTGrupoFuncional.idGrupo=TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta)           Where TTWorkFlow_Metas_de_Fase.Grupo_Funcional_para_Alerta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow_Metas_de_Fase";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Metas_de_FaseCS.TTWorkFlow_Metas_de_FaseFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Metas_de_Fase", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Metas_de_Fase_TTWorkFlow"]) == KeyTTWorkFlow&& Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Metas_de_Fase_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTWorkFlow_Metas_de_Fase";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Fases";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Fases";
            com.Parameters.AddWithValue("@WorkFlow",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataFaseControl(ctr, dt);
            return dt;
        }
/*            private void FillDataTipo_de_MetaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataTipo_de_Meta(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Meta(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Tipo_de_Meta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_MetaControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Meta(Object ctr){
            public DataTable FillDataTipo_de_Meta(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Tipo_de_Meta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_MetaControl(ctr, dt);
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
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTProceso";
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
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTProceso";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTMetadata";
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
            com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@ProcesoId",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataCampoControl(ctr, dt);
            return dt;
        }
/*            private void FillDataFrecuenciaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataFrecuencia(Object ctr, String Filtro){
            public DataTable FillDataFrecuencia(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Frecuencia";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataFrecuenciaControl(ctr, dt);
                return dt;
            }
//            public void FillDataFrecuencia(Object ctr){
            public DataTable FillDataFrecuencia(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTWorkFlow_Frecuencia";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataFrecuenciaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataGrupo_Funcional_para_AlertaControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "idGrupo";
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
                        ((ListBox)ctr).ValueMember = "idGrupo";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idGrupo";
                }
            }
*///            public DataTable FillDataGrupo_Funcional_para_Alerta(Object ctr, String Filtro){
            public DataTable FillDataGrupo_Funcional_para_Alerta(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTGrupoFuncional";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataGrupo_Funcional_para_AlertaControl(ctr, dt);
                return dt;
            }
//            public void FillDataGrupo_Funcional_para_Alerta(Object ctr){
            public DataTable FillDataGrupo_Funcional_para_Alerta(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Metas_de_Fase_Relacion_TTGrupoFuncional";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataGrupo_Funcional_para_AlertaControl(ctr, dt);
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