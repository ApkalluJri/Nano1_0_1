using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;

namespace TTFormatosCS
{
    public class TTFormatosFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varidFormato =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idFormato{
            get { return varidFormato; }
            set { varidFormato = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProcesoId =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varProcesoId;
        public TTClassSpecials.FiltersTypes.Dependientes ProcesoId{
            get { return varProcesoId; }
            set { varProcesoId = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varColumna =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varColumna;
        public TTClassSpecials.FiltersTypes.Dependientes Columna{
            get { return varColumna; }
            set { varColumna = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCabecero = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Cabecero
        {
            get { return varCabecero; }
            set { varCabecero = value; }
        }
        private TTClassSpecials.FiltersTypes.String varFormato = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Formato
        {
            get { return varFormato; }
            set { varFormato = value; }
        }
        private TTClassSpecials.FiltersTypes.String varPie = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Pie
        {
            get { return varPie; }
            set { varPie = value; }
        }

    }
    public class objectBussinessTTFormatos{
    public int iProcess = 17499;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTFormatosFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varidFormato;
	private int? varProcesoId;
	private int? varColumna;
	private String varNombre;
	private String varCabecero;
	private String varFormato;
	private String varPie;
    private List<TTFormatsVariables> variablesCabecero;
    private List<TTFormatsVariables> variablesFormato;
    private List<TTFormatsVariables> variablesPie;
	
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

    public TTFormatosFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTFormatosFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTFormatosFilters[1];
            filters[0] = value;
        }
    }

    public int? idFormato{
        get { return varidFormato;}
        set { varidFormato = value;}
    }
    public int? ProcesoId{
        get { return varProcesoId;}
        set { varProcesoId = value;}
    }
    public int? Columna{
        get { return varColumna;}
        set { varColumna = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Cabecero{
        get { return varCabecero;}
        set { varCabecero = value;}
    }
    public String Formato{
        get { return varFormato;}
        set { varFormato = value;}
    }
    public String Pie{
        get { return varPie;}
        set { varPie = value;}
    }

    public List<TTFormatsVariables> VariablesCabecero
    {
        get
        {
            variablesCabecero = new List<TTFormatsVariables>();
            GetVar(this.Cabecero, ref variablesCabecero);
            return variablesCabecero;
        }
    }

    public List<TTFormatsVariables> VariablesFormato
    {
        get
        {
            variablesFormato = new List<TTFormatsVariables>();
            GetVar(this.Formato, ref variablesFormato);
            return variablesFormato;
        }
    }

    public List<TTFormatsVariables> VariablesPie
    {
        get
        {
            variablesPie = new List<TTFormatsVariables>();
            GetVar(this.Pie, ref variablesPie);
            return variablesPie;
        }
    }

    public string CabeceroRepleced
    {
        get
        {
            return ReplaceVar(this.Cabecero);
        }
    }

    public string FormatoRepleced
    {
        get
        {
            return ReplaceVar(this.Formato);
        }
    }

    public string PieRepleced
    {
        get
        {
            return ReplaceVar(this.Pie);
        }
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

    private void GetVar(string Aux, ref List<TTFormatsVariables> listado)
    {
        while (Aux.Contains("<button "))
        {
            int inicio = Aux.IndexOf("<button ");
            string variable = Aux.Substring(inicio, Aux.IndexOf("</button>") - inicio + 9);
            inicio = variable.IndexOf(" v=" + (char)34) + 4;
            TTFormatsVariables Ovariable = new TTFormatsVariables();
            Ovariable.ID = variable.Substring(inicio, variable.IndexOf((char)34, inicio) - inicio);
            //inicio = variable.IndexOf("format=" + (char)34 + "{&quot;type&quot;:&quot;") + 32;
            //string itemtype = variable.Substring(inicio, variable.IndexOf("&quot;", inicio) - inicio);
            //inicio = variable.IndexOf("format=" + (char)34 + "{") + 9;
            //string objetoF = "{" + variable.Substring(inicio, variable.IndexOf("}" + (char)34, inicio) - inicio + 1).Replace("&quot;", ((char)34).ToString());

            inicio = variable.IndexOf("format=" + (char)34 + "{'type':'") + 17;
            string itemtype = variable.Substring(inicio, variable.IndexOf("'", inicio) - inicio);
            inicio = variable.IndexOf("format=" + (char)34 + "{") + 9;
            string objetoF = "{" + variable.Substring(inicio, variable.IndexOf("}" + (char)34, inicio) - inicio + 1).Replace("'", ((char)34).ToString());
            object myFormat = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<object>(objetoF);
            GetItemProperties(itemtype, myFormat, ref Ovariable);
            listado.Add(Ovariable);
            Aux = Aux.Replace(variable, "@@" + Ovariable.ID + "@@");
        }
    }

    public string ReplaceVar(string Aux)
    {
        while (Aux.Contains("<button "))
        {
            int inicio = Aux.IndexOf("<button ");
            string variable = Aux.Substring(inicio, Aux.IndexOf("</button>") - inicio + 9);
            inicio = variable.IndexOf(" v=" + (char)34) + 4;
            Aux = Aux.Replace(variable, "@@" + variable.Substring(inicio, variable.IndexOf((char)34, inicio) - inicio) + "@@");
        }
        return Aux;
    }

    private void GetItemProperties(string ItemType, object myFormat,ref TTFormatsVariables Ovariable)
    {
        switch (ItemType)
        {
            case "TTFormatsConfigurationsDate":
                TTFormatosCS.TTFormatsConfigurationsDate dColFun = new TTFormatosCS.TTFormatsConfigurationsDate();
                Asignar(dColFun,myFormat);
                Ovariable.Fecha = dColFun;
                break;
            case "TTFormatsConfigurationsCurrency":
                TTFormatosCS.TTFormatsConfigurationsCurrency FMoneda = new TTFormatosCS.TTFormatsConfigurationsCurrency();
                Asignar(FMoneda,myFormat);
                Ovariable.Moneda = FMoneda;
                break;
            case "TTFormatsConfigurationsNumbers":
                TTFormatosCS.TTFormatsConfigurationsNumbers FNumero = new TTFormatosCS.TTFormatsConfigurationsNumbers();
                Asignar(FNumero,myFormat);
                Ovariable.Numero = FNumero;
                break;
            case "TTFormatsConfigurationsString":
                TTFormatosCS.TTFormatsConfigurationsString FTexto = new TTFormatosCS.TTFormatsConfigurationsString();
                Asignar(FTexto,myFormat);
                Ovariable.Texto = FTexto;
                break;
            case "TTFormatsConfigurationsTime":
                TTFormatosCS.TTFormatsConfigurationsTime FHora = new TTFormatosCS.TTFormatsConfigurationsTime();
                Asignar(FHora,myFormat);
                Ovariable.Hora = FHora;
                break;
            default:
                break;
        }
    }
    private void Asignar(object objeto,object myFormat)
    {
        foreach (KeyValuePair<string, object> elem in ((Dictionary<String, Object>)myFormat))
        {
            PropertyInfo pi = objeto.GetType().GetProperty(elem.Key);
            if (pi != null)
            {
                pi.SetValue(objeto, elem.Value, null);
            }
        }
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
            com.CommandText = "sp_SelAllComplete_TTFormatos_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTFormatos";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTFormatosCS.TTFormatosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTFormatos", fil);
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
                com.CommandText = "sp_SelAllComplete_TTFormatos_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTFormatos";
        else
            com.CommandText="sp_SelAllTTFormatos";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTFormatosCS.TTFormatosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTFormatos", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTFormatos", fil);
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
                  string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere; 

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

                    switch (sortExpression)             {                 case "TTFormatos_idFormato": sortExpression = "TTFormatos.idFormato"; break;  case "TTFormatos_ProcesoId": sortExpression = "TTFormatos.ProcesoId"; break;  case "ProcesoId_Nombre": sortExpression = "ProcesoId.Nombre"; break;  case "TTFormatos_Columna": sortExpression = "TTFormatos.Columna"; break;  case "Columna_Nombre": sortExpression = "Columna.Nombre"; break;  case "TTFormatos_Nombre": sortExpression = "TTFormatos.Nombre"; break;  case "TTFormatos_Cabecero": sortExpression = "TTFormatos.Cabecero"; break;  case "TTFormatos_Formato": sortExpression = "TTFormatos.Formato"; break;  case "TTFormatos_Pie": sortExpression = "TTFormatos.Pie"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTFormatos.idFormato, TTFormatos.ProcesoId, ProcesoId.Nombre, TTFormatos.Columna, Columna.Nombre, TTFormatos.Nombre, TTFormatos.Cabecero, TTFormatos.Formato, TTFormatos.Pie" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        ProcesoId.Nombre AS ProcesoId_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        Columna.Nombre AS Columna_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre ";             string fieldsForExport = " TTFormatos.idFormato As [idFormato],        TTFormatos.ProcesoId AS [ProcesoId],        ProcesoId.Nombre AS [ProcesoId Nombre],        TTFormatos.Columna AS [Columna],        Columna.Nombre AS [Columna Nombre],        TTFormatos.Nombre As [Nombre],        TTFormatos.Cabecero As [Cabecero],        TTFormatos.Formato As [Formato],        TTFormatos.Pie As [Pie] ";             string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere; 

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
        	swhere = where; 	
        string fieldsWithAlias = " TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        ProcesoId.Nombre AS ProcesoId_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        Columna.Nombre AS Columna_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre ";         
        Order = (Order == string.Empty || Order == null ? "TTFormatos.idFormato" : Order);         
        string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere;

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

       	swhere = where; 	
        string fieldsWithAlias = " TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        ProcesoId.Nombre AS ProcesoId_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        Columna.Nombre AS Columna_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre                 ";         
        Order = (Order == string.Empty || Order == null ? "TTFormatos.idFormato" : Order);         
        string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        ProcesoId.Nombre AS ProcesoId_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        Columna.Nombre AS Columna_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre ";         
        Order = (Order == string.Empty || Order == null ? "TTFormatos.idFormato" : Order);         
        string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        ProcesoId.Nombre AS ProcesoId_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        Columna.Nombre AS Columna_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie ";         Order = (Order == string.Empty || Order == null ? "TTFormatos.idFormato, TTFormatos.ProcesoId, ProcesoId.Nombre, TTFormatos.Columna, Columna.Nombre, TTFormatos.Nombre, TTFormatos.Cabecero, TTFormatos.Formato, TTFormatos.Pie" : Order);         string from = " from (( TTFormatos WITH(NoLock) LEFT JOIN TTProceso as ProcesoId WITH(NoLock) ON ProcesoId.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata as Columna WITH(NoLock) ON Columna.DTID=TTFormatos.Columna)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_TTFormatos_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTFormatos";
        else
            com.CommandText="sp_SelAllTTFormatos";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTFormatosCS.TTFormatosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTFormatos", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTFormatos", fil);
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

        db.BeginTransaction("TTFormatos");
        int? sKeyidFormato = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTFormatos";
            com.Parameters.AddWithValue("@ProcesoId",Conversion.FormatNull(varProcesoId));
            if (varColumna != 0)
                com.Parameters.AddWithValue("@Columna", Conversion.FormatNull(varColumna));
            else
                com.Parameters.AddWithValue("@Columna", DBNull.Value);
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varCabecero!=null)
                com.Parameters.AddWithValue("@Cabecero", Convierte(varCabecero,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Cabecero", DBNull.Value);
            if (varFormato!=null)
                com.Parameters.AddWithValue("@Formato", Convierte(varFormato,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Formato", DBNull.Value);
            if (varPie!=null)
                com.Parameters.AddWithValue("@Pie", Convierte(varPie,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Pie", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyidFormato = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidFormato = sKeyidFormato;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTFormatos");
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

        db.BeginTransaction("TTFormatos");
        int? sKeyidFormato = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTFormatos";
            com.Parameters.AddWithValue("@ProcesoId",Conversion.FormatNull(varProcesoId));
            if (varColumna != 0)
                com.Parameters.AddWithValue("@Columna", Conversion.FormatNull(varColumna));
            else
                com.Parameters.AddWithValue("@Columna", DBNull.Value);
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varCabecero!=null)
                com.Parameters.AddWithValue("@Cabecero", Convierte(varCabecero,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Cabecero", DBNull.Value);
            if (varFormato!=null)
                com.Parameters.AddWithValue("@Formato", Convierte(varFormato,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Formato", DBNull.Value);
            if (varPie!=null)
                com.Parameters.AddWithValue("@Pie", Convierte(varPie,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Pie", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyidFormato = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidFormato = sKeyidFormato;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTFormatos");
            }
            catch{}
            throw ex; 
        }
        return sKeyidFormato;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("TTFormatos");
        int? sKeyidFormato = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTFormatos";
            com.Parameters.AddWithValue("@idFormato",Conversion.FormatNull(varidFormato));
            com.Parameters.AddWithValue("@ProcesoId",Conversion.FormatNull(varProcesoId));
            if (varColumna != 0)
                com.Parameters.AddWithValue("@Columna", Conversion.FormatNull(varColumna));
            else
                com.Parameters.AddWithValue("@Columna", DBNull.Value);
            
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", Convierte(varNombre,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varCabecero!=null)
                com.Parameters.AddWithValue("@Cabecero", Convierte(varCabecero,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Cabecero", DBNull.Value);
            if (varFormato!=null)
                com.Parameters.AddWithValue("@Formato", Convierte(varFormato,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Formato", DBNull.Value);
            if (varPie!=null)
                com.Parameters.AddWithValue("@Pie", Convierte(varPie,ConvierteAMayusculas));
            else
                com.Parameters.AddWithValue("@Pie", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyidFormato = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varidFormato = sKeyidFormato;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("TTFormatos");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyidFormato, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyidFormato.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTFormatos");
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText="DELETE FROM TTFormatos_por_Grupo_de_Usuario where idFormato = " + KeyidFormato.Value.ToString();
                db.Delete(com);
                com.CommandText="sp_DelTTFormatos";
                com.Parameters.AddWithValue("@idFormato",KeyidFormato);
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
                    db.RollBackTransaction("TTFormatos");
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
            idFormato = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTFormatos_idFormato"]);
            ProcesoId = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTFormatos_ProcesoId"]);
            Columna = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTFormatos_Columna"]);
            Nombre = ds.Tables[0].Rows[0]["TTFormatos_Nombre"].ToString();
            Cabecero = ds.Tables[0].Rows[0]["TTFormatos_Cabecero"].ToString();
            Formato = ds.Tables[0].Rows[0]["TTFormatos_Formato"].ToString();
            Pie = ds.Tables[0].Rows[0]["TTFormatos_Pie"].ToString();



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyidFormato, Boolean ConRelaciones){
        DataSet ds;
        if (KeyidFormato == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTFormatos";
            else
                com.CommandText="sp_GetTTFormatos";
com.Parameters.AddWithValue("@idFormato",KeyidFormato);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyidFormato(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.idFormato = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyProcesoId(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.ProcesoId = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyColumna(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.Columna = '" + Key + "'";
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
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCabecero(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.Cabecero = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFormato(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.Formato = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyPie(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTFormatos.idFormato As TTFormatos_idFormato,        TTFormatos.ProcesoId AS TTFormatos_ProcesoId,        TTProceso.Nombre AS TTProceso_Nombre,        TTFormatos.Columna AS TTFormatos_Columna,        TTMetadata.Nombre AS TTMetadata_Nombre,        TTFormatos.Nombre As TTFormatos_Nombre,        TTFormatos.Cabecero As TTFormatos_Cabecero,        TTFormatos.Formato As TTFormatos_Formato,        TTFormatos.Pie As TTFormatos_Pie   from (( TTFormatos       LEFT JOIN TTProceso ON TTProceso.IdProceso=TTFormatos.ProcesoId)       LEFT JOIN TTMetadata ON TTMetadata.DTID=TTFormatos.Columna)           Where TTFormatos.Pie = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyidFormato)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTFormatos";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTFormatosCS.TTFormatosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTFormatos", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTFormatos_idFormato"]) == KeyidFormato)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyidFormato){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTFormatos";
com.Parameters.AddWithValue("@idFormato",KeyidFormato);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataProcesoIdControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataProcesoId(Object ctr, String Filtro){
            public DataTable FillDataProcesoId(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTFormatos_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataProcesoIdControl(ctr, dt);
                return dt;
            }
//            public void FillDataProcesoId(Object ctr){
            public DataTable FillDataProcesoId(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTFormatos_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataProcesoIdControl(ctr, dt);
                return dt;
            }
/*            private void FillDataColumnaControl(Object ctr, DataTable dt){
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
*///        public void FillDataColumna(Object ctr){
        public DataTable FillDataColumna(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTFormatos_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@ProcesoId", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataColumnaControl(ctr, dt);
            return dt;
        }
        //public void FillDataColumna(Object ctr, int Key){
        public DataTable FillDataColumna(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTFormatos_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@ProcesoId",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataColumnaControl(ctr, dt);
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

        public static DataTable getFormatos(int globalTipoUsuario, int idProceso)
        {
            DataTable dt;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTTFormatos_por_Grupo_de_Usuario_Proceso";
            com.Parameters.AddWithValue("@idGrupoUsuario", globalTipoUsuario);
            com.Parameters.AddWithValue("@idProceso", idProceso); 
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com).Tables[0];
        }
    }

    public class TTFormatsConfigurationsDate
    {
        public TTFormatsConfigurationsEnumDatePositions Posicion1 { get; set; }
        public string Separador1 {get;set;}
        public TTFormatsConfigurationsEnumDatePositions Posicion2 { get; set; }
        public string Separador2 { get; set; }
        public TTFormatsConfigurationsEnumDatePositions Posicion3 { get; set; }
    }

    public enum TTFormatsConfigurationsEnumDatePositions
    {
        Vacio = 0,
        DD = 1,
        Dia_Letra = 2,
        MM = 3,
        MMM = 4,
        Mes_Letra = 5,
        AA = 6,
        AAAA = 7,
        Año_Letra = 8,
    }

    public class TTFormatsConfigurationsCurrency
    {
        public string Simbolo { get; set; }
        public int Decimales { get; set; }
        public TTFormatsConfigurationsEnumCurrencyLimit Limitar { get; set; }
    }

    public enum TTFormatsConfigurationsEnumCurrencyLimit
    {
        Redondeo = 0,
        Truncado = 1,
    }

    public class TTFormatsConfigurationsNumbers
    {
        public bool Letra { get; set; }
    }

    public class TTFormatsConfigurationsString
    {
        public int Caracteres { get; set; }
    }

    public class TTFormatsConfigurationsTime
    {
        public TTFormatsConfigurationsEnumTimeFormat Formato { get; set; }
    }

    public enum TTFormatsConfigurationsEnumTimeFormat
    {
        AM_PM = 0,
        HRS24 = 1,
    }

    public class TTFormatsVariables
    {
        public string ID { get; set; }
        public TTFormatsConfigurationsDate Fecha { get; set; }
        public TTFormatsConfigurationsCurrency Moneda { get; set; }
        public TTFormatsConfigurationsNumbers Numero { get; set; }
        public TTFormatsConfigurationsString Texto { get; set; }
        public TTFormatsConfigurationsTime Hora { get; set; }

        public TTFormatsVariables() { }
    }
}

