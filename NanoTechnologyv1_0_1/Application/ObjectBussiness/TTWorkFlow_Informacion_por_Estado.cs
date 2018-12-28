using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTWorkFlow_Informacion_por_EstadoCS
{
    public class TTWorkFlow_Informacion_por_EstadoFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varProceso =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varProceso;
        public TTClassSpecials.FiltersTypes.Dependientes Proceso{
            get { return varProceso; }
            set { varProceso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCarpeta =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDominioCS.TTDominioFilters[] varCarpeta;
        public TTClassSpecials.FiltersTypes.Dependientes Carpeta{
            get { return varCarpeta; }
            set { varCarpeta = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varVisible =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varVisible;
        public TTClassSpecials.FiltersTypes.Dependientes Visible{
            get { return varVisible; }
            set { varVisible = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varSolo_Lectura =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varSolo_Lectura;
        public TTClassSpecials.FiltersTypes.Dependientes Solo_Lectura{
            get { return varSolo_Lectura; }
            set { varSolo_Lectura = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObligatorios =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTWorkFlow_RespuestaCS.TTWorkFlow_RespuestaFilters[] varObligatorios;
        public TTClassSpecials.FiltersTypes.Dependientes Obligatorios{
            get { return varObligatorios; }
            set { varObligatorios = value; }
        }
        private TTClassSpecials.FiltersTypes.String varEtiqueta = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Etiqueta
        {
            get { return varEtiqueta; }
            set { varEtiqueta = value; }
        }

    }
public class objectBussinessTTWorkFlow_Informacion_por_Estado{
    public int iProcess = 15814;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTWorkFlow_Informacion_por_EstadoFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varTTWorkFlow;
	private int? varFolio;
	private int? varFase;
	private int? varEstado;
	private int? varProceso;
	private int? varCarpeta;
	private int? varVisible;
	private int? varSolo_Lectura;
	private int? varObligatorios;
	private String varEtiqueta;
		
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

    public TTWorkFlow_Informacion_por_EstadoFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTWorkFlow_Informacion_por_EstadoFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTWorkFlow_Informacion_por_EstadoFilters[1];
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
    public int? Proceso{
        get { return varProceso;}
        set { varProceso = value;}
    }
    public int? Carpeta{
        get { return varCarpeta;}
        set { varCarpeta = value;}
    }
    public int? Visible{
        get { return varVisible;}
        set { varVisible = value;}
    }
    public int? Solo_Lectura{
        get { return varSolo_Lectura;}
        set { varSolo_Lectura = value;}
    }
    public int? Obligatorios{
        get { return varObligatorios;}
        set { varObligatorios = value;}
    }
    public String Etiqueta{
        get { return varEtiqueta;}
        set { varEtiqueta = value;}
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
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Informacion_por_Estado", fil);
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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Informacion_por_Estado";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Informacion_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Informacion_por_Estado", fil);
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
                  string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTWorkFlow_Informacion_por_Estado_TTWorkFlow": sortExpression = "TTWorkFlow_Informacion_por_Estado.TTWorkFlow"; break;  case "TTWorkFlow_Nombre": sortExpression = "TTWorkFlow.Nombre"; break;  case "TTWorkFlow_Informacion_por_Estado_Folio": sortExpression = "TTWorkFlow_Informacion_por_Estado.Folio"; break;  case "TTWorkFlow_Informacion_por_Estado_Fase": sortExpression = "TTWorkFlow_Informacion_por_Estado.Fase"; break;  case "Fase_Nombre": sortExpression = "Fase.Nombre"; break;  case "TTWorkFlow_Informacion_por_Estado_Estado": sortExpression = "TTWorkFlow_Informacion_por_Estado.Estado"; break;  case "Estado_Nombre": sortExpression = "Estado.Nombre"; break;  case "TTWorkFlow_Informacion_por_Estado_Proceso": sortExpression = "TTWorkFlow_Informacion_por_Estado.Proceso"; break;  case "Proceso_Nombre": sortExpression = "Proceso.Nombre"; break;  case "TTWorkFlow_Informacion_por_Estado_Carpeta": sortExpression = "TTWorkFlow_Informacion_por_Estado.Carpeta"; break;  case "Carpeta_Descripcion": sortExpression = "Carpeta.Descripcion"; break;  case "TTWorkFlow_Informacion_por_Estado_Visible": sortExpression = "TTWorkFlow_Informacion_por_Estado.Visible"; break;  case "Visible_Descripcion": sortExpression = "Visible.Descripcion"; break;  case "TTWorkFlow_Informacion_por_Estado_Solo_Lectura": sortExpression = "TTWorkFlow_Informacion_por_Estado.Solo_Lectura"; break;  case "Solo_Lectura_Descripcion": sortExpression = "Solo_Lectura.Descripcion"; break;  case "TTWorkFlow_Informacion_por_Estado_Obligatorios": sortExpression = "TTWorkFlow_Informacion_por_Estado.Obligatorios"; break;  case "Obligatorios_Descripcion": sortExpression = "Obligatorios.Descripcion"; break;  case "TTWorkFlow_Informacion_por_Estado_Etiqueta": sortExpression = "TTWorkFlow_Informacion_por_Estado.Etiqueta"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTWorkFlow_Informacion_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Informacion_por_Estado.Folio, TTWorkFlow_Informacion_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Informacion_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Informacion_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Informacion_por_Estado.Carpeta, Carpeta.Descripcion, TTWorkFlow_Informacion_por_Estado.Visible, Visible.Descripcion, TTWorkFlow_Informacion_por_Estado.Solo_Lectura, Solo_Lectura.Descripcion, TTWorkFlow_Informacion_por_Estado.Obligatorios, Obligatorios.Descripcion, TTWorkFlow_Informacion_por_Estado.Etiqueta" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        Carpeta.Descripcion AS Carpeta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        Visible.Descripcion AS Visible_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        Solo_Lectura.Descripcion AS Solo_Lectura_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        Obligatorios.Descripcion AS Obligatorios_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta ";             string fieldsForExport = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS [TTWorkFlow],        TTWorkFlow.Nombre AS [TTWorkFlow Nombre],        TTWorkFlow_Informacion_por_Estado.Folio As [Folio],        TTWorkFlow_Informacion_por_Estado.Fase AS [Fase],        Fase.Nombre AS [Fase Nombre],        TTWorkFlow_Informacion_por_Estado.Estado AS [Estado],        Estado.Nombre AS [Estado Nombre],        TTWorkFlow_Informacion_por_Estado.Proceso AS [Proceso],        Proceso.Nombre AS [Proceso Nombre],        TTWorkFlow_Informacion_por_Estado.Carpeta AS [Carpeta],        Carpeta.Descripcion AS [Carpeta Descripcion],        TTWorkFlow_Informacion_por_Estado.Visible AS [Visible],        Visible.Descripcion AS [Visible Descripcion],        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS [Solo Lectura],        Solo_Lectura.Descripcion AS [Solo Lectura Descripcion],        TTWorkFlow_Informacion_por_Estado.Obligatorios AS [Obligatorios],        Obligatorios.Descripcion AS [Obligatorios Descripcion],        TTWorkFlow_Informacion_por_Estado.Etiqueta As [Etiqueta] ";             string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere; 

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
    

    //-----------------------------------------------------------M�todos para rad Grid----------------------------------------------------------------
    public string GetFullQuery(string where, string Order)
    {
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        Carpeta.Descripcion AS Carpeta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        Visible.Descripcion AS Visible_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        Solo_Lectura.Descripcion AS Solo_Lectura_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        Obligatorios.Descripcion AS Obligatorios_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Informacion_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Informacion_por_Estado.Folio, TTWorkFlow_Informacion_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Informacion_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Informacion_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Informacion_por_Estado.Carpeta, Carpeta.Descripcion, TTWorkFlow_Informacion_por_Estado.Visible, Visible.Descripcion, TTWorkFlow_Informacion_por_Estado.Solo_Lectura, Solo_Lectura.Descripcion, TTWorkFlow_Informacion_por_Estado.Obligatorios, Obligatorios.Descripcion, TTWorkFlow_Informacion_por_Estado.Etiqueta" : Order);         string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere;

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

       	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        Carpeta.Descripcion AS Carpeta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        Visible.Descripcion AS Visible_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        Solo_Lectura.Descripcion AS Solo_Lectura_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        Obligatorios.Descripcion AS Obligatorios_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Informacion_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Informacion_por_Estado.Folio, TTWorkFlow_Informacion_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Informacion_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Informacion_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Informacion_por_Estado.Carpeta, Carpeta.Descripcion, TTWorkFlow_Informacion_por_Estado.Visible, Visible.Descripcion, TTWorkFlow_Informacion_por_Estado.Solo_Lectura, Solo_Lectura.Descripcion, TTWorkFlow_Informacion_por_Estado.Obligatorios, Obligatorios.Descripcion, TTWorkFlow_Informacion_por_Estado.Etiqueta" : Order);         string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        Carpeta.Descripcion AS Carpeta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        Visible.Descripcion AS Visible_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        Solo_Lectura.Descripcion AS Solo_Lectura_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        Obligatorios.Descripcion AS Obligatorios_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Informacion_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Informacion_por_Estado.Folio, TTWorkFlow_Informacion_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Informacion_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Informacion_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Informacion_por_Estado.Carpeta, Carpeta.Descripcion, TTWorkFlow_Informacion_por_Estado.Visible, Visible.Descripcion, TTWorkFlow_Informacion_por_Estado.Solo_Lectura, Solo_Lectura.Descripcion, TTWorkFlow_Informacion_por_Estado.Obligatorios, Obligatorios.Descripcion, TTWorkFlow_Informacion_por_Estado.Etiqueta" : Order);         string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        Fase.Nombre AS Fase_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        Estado.Nombre AS Estado_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        Proceso.Nombre AS Proceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        Carpeta.Descripcion AS Carpeta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        Visible.Descripcion AS Visible_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        Solo_Lectura.Descripcion AS Solo_Lectura_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        Obligatorios.Descripcion AS Obligatorios_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta ";         Order = (Order == string.Empty || Order == null ? "TTWorkFlow_Informacion_por_Estado.TTWorkFlow, TTWorkFlow.Nombre, TTWorkFlow_Informacion_por_Estado.Folio, TTWorkFlow_Informacion_por_Estado.Fase, Fase.Nombre, TTWorkFlow_Informacion_por_Estado.Estado, Estado.Nombre, TTWorkFlow_Informacion_por_Estado.Proceso, Proceso.Nombre, TTWorkFlow_Informacion_por_Estado.Carpeta, Carpeta.Descripcion, TTWorkFlow_Informacion_por_Estado.Visible, Visible.Descripcion, TTWorkFlow_Informacion_por_Estado.Solo_Lectura, Solo_Lectura.Descripcion, TTWorkFlow_Informacion_por_Estado.Obligatorios, Obligatorios.Descripcion, TTWorkFlow_Informacion_por_Estado.Etiqueta" : Order);         string from = " from (((((((( TTWorkFlow_Informacion_por_Estado WITH(NoLock) LEFT JOIN TTWorkFlow as TTWorkFlow WITH(NoLock) ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases as Fase WITH(NoLock) ON Fase.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados as Estado WITH(NoLock) ON Estado.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso as Proceso WITH(NoLock) ON Proceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio as Carpeta WITH(NoLock) ON Carpeta.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta as Visible WITH(NoLock) ON Visible.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as Solo_Lectura WITH(NoLock) ON Solo_Lectura.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as Obligatorios WITH(NoLock) ON Obligatorios.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado";
        else
            com.CommandText="sp_SelAllTTWorkFlow_Informacion_por_Estado";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Informacion_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTWorkFlow_Informacion_por_Estado", fil);
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

        db.BeginTransaction("TTWorkFlow_Informacion_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Informacion_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Carpeta",Conversion.FormatNull(varCarpeta));
            com.Parameters.AddWithValue("@Visible",Conversion.FormatNull(varVisible));
            com.Parameters.AddWithValue("@Solo_Lectura",Conversion.FormatNull(varSolo_Lectura));
            com.Parameters.AddWithValue("@Obligatorios",Conversion.FormatNull(varObligatorios));
            if (varEtiqueta!=null)
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varEtiqueta,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Etiqueta", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Informacion_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Informacion_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTWorkFlow_Informacion_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Carpeta",Conversion.FormatNull(varCarpeta));
            com.Parameters.AddWithValue("@Visible",Conversion.FormatNull(varVisible));
            com.Parameters.AddWithValue("@Solo_Lectura",Conversion.FormatNull(varSolo_Lectura));
            com.Parameters.AddWithValue("@Obligatorios",Conversion.FormatNull(varObligatorios));
            if (varEtiqueta!=null)
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varEtiqueta,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Etiqueta", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Informacion_por_Estado");
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

        db.BeginTransaction("TTWorkFlow_Informacion_por_Estado");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTWorkFlow_Informacion_por_Estado";
            com.Parameters.AddWithValue("@TTWorkFlow",Conversion.FormatNull(varTTWorkFlow));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Fase",Conversion.FormatNull(varFase));
            com.Parameters.AddWithValue("@Estado",Conversion.FormatNull(varEstado));
            com.Parameters.AddWithValue("@Proceso",Conversion.FormatNull(varProceso));
            com.Parameters.AddWithValue("@Carpeta",Conversion.FormatNull(varCarpeta));
            com.Parameters.AddWithValue("@Visible",Conversion.FormatNull(varVisible));
            com.Parameters.AddWithValue("@Solo_Lectura",Conversion.FormatNull(varSolo_Lectura));
            com.Parameters.AddWithValue("@Obligatorios",Conversion.FormatNull(varObligatorios));
            if (varEtiqueta!=null)
                com.Parameters.AddWithValue("@Etiqueta", Convierte(varEtiqueta,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Etiqueta", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTWorkFlow_Informacion_por_Estado");
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
            db.BeginTransaction("TTWorkFlow_Informacion_por_Estado");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTWorkFlow_Informacion_por_Estado";
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
                    db.RollBackTransaction("TTWorkFlow_Informacion_por_Estado");
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
            TTWorkFlow = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_TTWorkFlow"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Folio"]);
            Fase = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Fase"]);
            Estado = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Estado"]);
            Proceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Proceso"]);
            Carpeta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Carpeta"]);
            Visible = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Visible"]);
            Solo_Lectura = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Solo_Lectura"]);
            Obligatorios = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Obligatorios"]);
            Etiqueta = ds.Tables[0].Rows[0]["TTWorkFlow_Informacion_por_Estado_Etiqueta"].ToString();



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
                com.CommandText="sp_GetComplete_TTWorkFlow_Informacion_por_Estado";
            else
                com.CommandText="sp_GetTTWorkFlow_Informacion_por_Estado";
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
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.TTWorkFlow = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Folio = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Fase = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Estado = '" + Key + "'";
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
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Proceso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCarpeta(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Carpeta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyVisible(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Visible = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeySolo_Lectura(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Solo_Lectura = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObligatorios(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Obligatorios = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEtiqueta(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTWorkFlow_Informacion_por_Estado.TTWorkFlow AS TTWorkFlow_Informacion_por_Estado_TTWorkFlow,        TTWorkFlow.Nombre AS TTWorkFlow_Nombre,        TTWorkFlow_Informacion_por_Estado.Folio As TTWorkFlow_Informacion_por_Estado_Folio,        TTWorkFlow_Informacion_por_Estado.Fase AS TTWorkFlow_Informacion_por_Estado_Fase,        TTWorkFlow_Fases.Nombre AS TTWorkFlow_Fases_Nombre,        TTWorkFlow_Informacion_por_Estado.Estado AS TTWorkFlow_Informacion_por_Estado_Estado,        TTWorkFlow_Estados.Nombre AS TTWorkFlow_Estados_Nombre,        TTWorkFlow_Informacion_por_Estado.Proceso AS TTWorkFlow_Informacion_por_Estado_Proceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTWorkFlow_Informacion_por_Estado.Carpeta AS TTWorkFlow_Informacion_por_Estado_Carpeta,        TTDominio.Descripcion AS TTDominio_Descripcion,        TTWorkFlow_Informacion_por_Estado.Visible AS TTWorkFlow_Informacion_por_Estado_Visible,        TTWorkFlow_Respuesta.Descripcion AS TTWorkFlow_Respuesta_Descripcion,        TTWorkFlow_Informacion_por_Estado.Solo_Lectura AS TTWorkFlow_Informacion_por_Estado_Solo_Lectura,        TTWorkFlow_Respuesta1.Descripcion AS TTWorkFlow_Respuesta1_Descripcion,        TTWorkFlow_Informacion_por_Estado.Obligatorios AS TTWorkFlow_Informacion_por_Estado_Obligatorios,        TTWorkFlow_Respuesta2.Descripcion AS TTWorkFlow_Respuesta2_Descripcion,        TTWorkFlow_Informacion_por_Estado.Etiqueta As TTWorkFlow_Informacion_por_Estado_Etiqueta   from (((((((( TTWorkFlow_Informacion_por_Estado       LEFT JOIN TTWorkFlow ON TTWorkFlow.Folio=TTWorkFlow_Informacion_por_Estado.TTWorkFlow)       LEFT JOIN TTWorkFlow_Fases ON TTWorkFlow_Fases.Numero_de_Fase=TTWorkFlow_Informacion_por_Estado.Fase)       LEFT JOIN TTWorkFlow_Estados ON TTWorkFlow_Estados.Codigo_Estado=TTWorkFlow_Informacion_por_Estado.Estado)       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTWorkFlow_Informacion_por_Estado.Proceso)       LEFT JOIN TTDominio ON TTDominio.Folio=TTWorkFlow_Informacion_por_Estado.Carpeta)       LEFT JOIN TTWorkFlow_Respuesta ON TTWorkFlow_Respuesta.Clave=TTWorkFlow_Informacion_por_Estado.Visible)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta1 ON TTWorkFlow_Respuesta1.Clave=TTWorkFlow_Informacion_por_Estado.Solo_Lectura)       LEFT JOIN TTWorkFlow_Respuesta as TTWorkFlow_Respuesta2 ON TTWorkFlow_Respuesta2.Clave=TTWorkFlow_Informacion_por_Estado.Obligatorios)           Where TTWorkFlow_Informacion_por_Estado.Etiqueta = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyTTWorkFlow, int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTWorkFlow_Informacion_por_Estado";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTWorkFlow_Informacion_por_EstadoCS.TTWorkFlow_Informacion_por_EstadoFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTWorkFlow_Informacion_por_Estado", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Informacion_por_Estado_TTWorkFlow"]) == KeyTTWorkFlow&& Function.FormatNumberNull(dt.Rows[i]["TTWorkFlow_Informacion_por_Estado_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetTTWorkFlow_Informacion_por_Estado";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Fases";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Fases";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Estados";
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
            com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Estados";
            com.Parameters.AddWithValue("@Fase",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataEstadoControl(ctr, dt);
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
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTProceso";
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
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataProcesoControl(ctr, dt);
                return dt;
            }
/*            private void FillDataCarpetaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataCarpeta(Object ctr, String Filtro){
            public DataTable FillDataCarpeta(int ProcesoId){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTDominio";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("procesoID", ProcesoId);
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                //dt= d.ToTable();
                //FillDataCarpetaControl(ctr, dt);
                return dt;
            }
//            public void FillDataCarpeta(Object ctr){
            public DataTable FillDataCarpeta(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTDominio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataCarpetaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataVisibleControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataVisible(Object ctr, String Filtro){
            public DataTable FillDataVisible(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataVisibleControl(ctr, dt);
                return dt;
            }
//            public void FillDataVisible(Object ctr){
            public DataTable FillDataVisible(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataVisibleControl(ctr, dt);
                return dt;
            }
/*            private void FillDataSolo_LecturaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataSolo_Lectura(Object ctr, String Filtro){
            public DataTable FillDataSolo_Lectura(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataSolo_LecturaControl(ctr, dt);
                return dt;
            }
//            public void FillDataSolo_Lectura(Object ctr){
            public DataTable FillDataSolo_Lectura(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataSolo_LecturaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataObligatoriosControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataObligatorios(Object ctr, String Filtro){
            public DataTable FillDataObligatorios(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataObligatoriosControl(ctr, dt);
                return dt;
            }
//            public void FillDataObligatorios(Object ctr){
            public DataTable FillDataObligatorios(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTWorkFlow_Informacion_por_Estado_Relacion_TTWorkFlow_Respuesta";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataObligatoriosControl(ctr, dt);
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