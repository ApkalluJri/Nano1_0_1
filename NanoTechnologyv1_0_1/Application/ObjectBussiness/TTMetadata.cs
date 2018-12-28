using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTMetadataCS
{
    public class TTMetadataFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varDTID =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric DTID{
            get { return varDTID; }
            set { varDTID = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varDNTID =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDNTCS.TTDNTFilters[] varDNTID;
        public TTClassSpecials.FiltersTypes.Dependientes DNTID{
            get { return varDNTID; }
            set { varDNTID = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProcesoId =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProcesoCS.TTProcesoFilters[] varProcesoId;
        public TTClassSpecials.FiltersTypes.Dependientes ProcesoId{
            get { return varProcesoId; }
            set { varProcesoId = value; }
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
        private TTClassSpecials.FiltersTypes.Numeric  varTipo_de_Dato =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Tipo_de_Dato{
            get { return varTipo_de_Dato; }
            set { varTipo_de_Dato = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varLongitud =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Longitud{
            get { return varLongitud; }
            set { varLongitud = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varDecimal =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Decimal{
            get { return varDecimal; }
            set { varDecimal = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varRenglones =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Renglones{
            get { return varRenglones; }
            set { varRenglones = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varIdentificador = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Identificador
        {
            get { return varIdentificador; }
            set { varIdentificador = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varSecuencial = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Secuencial
        {
            get { return varSecuencial; }
            set { varSecuencial = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varObligatorio = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Obligatorio
        {
            get { return varObligatorio; }
            set { varObligatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.String varValor_por_defecto = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Valor_por_defecto
        {
            get { return varValor_por_defecto; }
            set { varValor_por_defecto = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varVisible = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Visible
        {
            get { return varVisible; }
            set { varVisible = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTexto_Ayuda = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Texto_Ayuda
        {
            get { return varTexto_Ayuda; }
            set { varTexto_Ayuda = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varDependiente = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Dependiente
        {
            get { return varDependiente; }
            set { varDependiente = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varDependienteTabla =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDNTCS.TTDNTFilters[] varDependienteTabla;
        public TTClassSpecials.FiltersTypes.Dependientes DependienteTabla{
            get { return varDependienteTabla; }
            set { varDependienteTabla = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varDependienteClave =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varDependienteClave;
        public TTClassSpecials.FiltersTypes.Dependientes DependienteClave{
            get { return varDependienteClave; }
            set { varDependienteClave = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varDependienteDescripcion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTMetadataCS.TTMetadataFilters[] varDependienteDescripcion;
        public TTClassSpecials.FiltersTypes.Dependientes DependienteDescripcion{
            get { return varDependienteDescripcion; }
            set { varDependienteDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varSolo_Lectura = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Solo_Lectura
        {
            get { return varSolo_Lectura; }
            set { varSolo_Lectura = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varOrden =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Orden{
            get { return varOrden; }
            set { varOrden = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varCarpeta =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Carpeta{
            get { return varCarpeta; }
            set { varCarpeta = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varColumna =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Columna{
            get { return varColumna; }
            set { varColumna = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varTotal = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Total
        {
            get { return varTotal; }
            set { varTotal = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varFiltro = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Filtro
        {
            get { return varFiltro; }
            set { varFiltro = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Control =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTTipo_de_ControlCS.TTTipo_de_ControlFilters[] varTipo_de_Control;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Control{
            get { return varTipo_de_Control; }
            set { varTipo_de_Control = value; }
        }

    }
public class objectBussinessTTMetadata{
    public int iProcess = 6386;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTMetadataFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varDTID;
	private int? varDNTID;
	private int? varProcesoId;
	private String varNombre;
	private String varDescripcion;
	private int? varTipo_de_Dato;
	private int? varLongitud;
	private int? varDecimal;
	private int? varRenglones;
	private Boolean varIdentificador;
	private Boolean varSecuencial;
	private Boolean varObligatorio;
	private String varValor_por_defecto;
	private Boolean varVisible;
	private String varTexto_Ayuda;
	private Boolean varDependiente;
	private int? varDependienteTabla;
	private int? varDependienteClave;
	private int? varDependienteDescripcion;
	private Boolean varSolo_Lectura;
	private int? varOrden;
	private int? varCarpeta;
	private int? varColumna;
	private Boolean varTotal;
	private Boolean varFiltro;
	private int? varTipo_de_Control;
		
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

    public TTMetadataFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTMetadataFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTMetadataFilters[1];
            filters[0] = value;
        }
    }

    public int? DTID{
        get { return varDTID;}
        set { varDTID = value;}
    }
    public int? DNTID{
        get { return varDNTID;}
        set { varDNTID = value;}
    }
    public int? ProcesoId{
        get { return varProcesoId;}
        set { varProcesoId = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public int? Tipo_de_Dato{
        get { return varTipo_de_Dato;}
        set { varTipo_de_Dato = value;}
    }
    public int? Longitud{
        get { return varLongitud;}
        set { varLongitud = value;}
    }
    public int? Decimal{
        get { return varDecimal;}
        set { varDecimal = value;}
    }
    public int? Renglones{
        get { return varRenglones;}
        set { varRenglones = value;}
    }
    public Boolean Identificador{
        get { return varIdentificador;}
        set { varIdentificador = value;}
    }
    public Boolean Secuencial{
        get { return varSecuencial;}
        set { varSecuencial = value;}
    }
    public Boolean Obligatorio{
        get { return varObligatorio;}
        set { varObligatorio = value;}
    }
    public String Valor_por_defecto{
        get { return varValor_por_defecto;}
        set { varValor_por_defecto = value;}
    }
    public Boolean Visible{
        get { return varVisible;}
        set { varVisible = value;}
    }
    public String Texto_Ayuda{
        get { return varTexto_Ayuda;}
        set { varTexto_Ayuda = value;}
    }
    public Boolean Dependiente{
        get { return varDependiente;}
        set { varDependiente = value;}
    }
    public int? DependienteTabla{
        get { return varDependienteTabla;}
        set { varDependienteTabla = value;}
    }
    public int? DependienteClave{
        get { return varDependienteClave;}
        set { varDependienteClave = value;}
    }
    public int? DependienteDescripcion{
        get { return varDependienteDescripcion;}
        set { varDependienteDescripcion = value;}
    }
    public Boolean Solo_Lectura{
        get { return varSolo_Lectura;}
        set { varSolo_Lectura = value;}
    }
    public int? Orden{
        get { return varOrden;}
        set { varOrden = value;}
    }
    public int? Carpeta{
        get { return varCarpeta;}
        set { varCarpeta = value;}
    }
    public int? Columna{
        get { return varColumna;}
        set { varColumna = value;}
    }
    public Boolean Total{
        get { return varTotal;}
        set { varTotal = value;}
    }
    public Boolean Filtro{
        get { return varFiltro;}
        set { varFiltro = value;}
    }
    public int? Tipo_de_Control{
        get { return varTipo_de_Control;}
        set { varTipo_de_Control = value;}
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
            com.CommandText = "sp_SelAllComplete_TTMetadata_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTMetadata";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTMetadataCS.TTMetadataFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTMetadata", fil);
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
                com.CommandText = "sp_SelAllComplete_TTMetadata_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTMetadata";
        else
            com.CommandText="sp_SelAllTTMetadata";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTMetadataCS.TTMetadataFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTMetadata", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTMetadata", fil);
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
                com.CommandText = "sp_SelAllComplete_TTMetadata_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTMetadata";
        else
            com.CommandText="sp_SelAllTTMetadata";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTMetadataCS.TTMetadataFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTMetadata", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTMetadata", fil);
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
    public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTMetadata");
        int? sKeyDTID = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTMetadata";
            com.Parameters.AddWithValue("@DTID",Conversion.FormatNull(varDTID));
            com.Parameters.AddWithValue("@DNTID",Conversion.FormatNull(varDNTID));
            com.Parameters.AddWithValue("@ProcesoId",Conversion.FormatNull(varProcesoId));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", varNombre);
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", varDescripcion);
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo_de_Dato",Conversion.FormatNull(varTipo_de_Dato));
            com.Parameters.AddWithValue("@Longitud",Conversion.FormatNull(varLongitud));
            com.Parameters.AddWithValue("@Decimal",Conversion.FormatNull(varDecimal));
            com.Parameters.AddWithValue("@Renglones",Conversion.FormatNull(varRenglones));
            com.Parameters.AddWithValue("@Identificador", varIdentificador);
            com.Parameters.AddWithValue("@Secuencial", varSecuencial);
            com.Parameters.AddWithValue("@Obligatorio", varObligatorio);
            if (varValor_por_defecto!=null)
                com.Parameters.AddWithValue("@Valor_por_defecto", varValor_por_defecto);
            else
                com.Parameters.AddWithValue("@Valor_por_defecto", DBNull.Value);
            com.Parameters.AddWithValue("@Visible", varVisible);
            if (varTexto_Ayuda!=null)
                com.Parameters.AddWithValue("@Texto_Ayuda", varTexto_Ayuda);
            else
                com.Parameters.AddWithValue("@Texto_Ayuda", DBNull.Value);
            com.Parameters.AddWithValue("@Dependiente", varDependiente);
            com.Parameters.AddWithValue("@DependienteTabla",Conversion.FormatNull(varDependienteTabla));
            com.Parameters.AddWithValue("@DependienteClave",Conversion.FormatNull(varDependienteClave));
            com.Parameters.AddWithValue("@DependienteDescripcion",Conversion.FormatNull(varDependienteDescripcion));
            com.Parameters.AddWithValue("@Solo_Lectura", varSolo_Lectura);
            com.Parameters.AddWithValue("@Orden",Conversion.FormatNull(varOrden));
            com.Parameters.AddWithValue("@Carpeta",Conversion.FormatNull(varCarpeta));
            com.Parameters.AddWithValue("@Columna",Conversion.FormatNull(varColumna));
            com.Parameters.AddWithValue("@Total", varTotal);
            com.Parameters.AddWithValue("@Filtro", varFiltro);
            com.Parameters.AddWithValue("@Tipo_de_Control",Conversion.FormatNull(varTipo_de_Control));

            com.CommandType =CommandType.StoredProcedure;
            sKeyDTID = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
            
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTMetadata");
            throw ex; 
        }
        //return sKey;
    }
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTMetadata");
        int? sKeyDTID = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTMetadata";
            com.Parameters.AddWithValue("@DTID",Conversion.FormatNull(varDTID));
            com.Parameters.AddWithValue("@DNTID",Conversion.FormatNull(varDNTID));
            com.Parameters.AddWithValue("@ProcesoId",Conversion.FormatNull(varProcesoId));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", varNombre);
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", varDescripcion);
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@Tipo_de_Dato",Conversion.FormatNull(varTipo_de_Dato));
            com.Parameters.AddWithValue("@Longitud",Conversion.FormatNull(varLongitud));
            com.Parameters.AddWithValue("@Decimal",Conversion.FormatNull(varDecimal));
            com.Parameters.AddWithValue("@Renglones",Conversion.FormatNull(varRenglones));
            com.Parameters.AddWithValue("@Identificador", varIdentificador);
            com.Parameters.AddWithValue("@Secuencial", varSecuencial);
            com.Parameters.AddWithValue("@Obligatorio", varObligatorio);
            if (varValor_por_defecto!=null)
                com.Parameters.AddWithValue("@Valor_por_defecto", varValor_por_defecto);
            else
                com.Parameters.AddWithValue("@Valor_por_defecto", DBNull.Value);
            com.Parameters.AddWithValue("@Visible", varVisible);
            if (varTexto_Ayuda!=null)
                com.Parameters.AddWithValue("@Texto_Ayuda", varTexto_Ayuda);
            else
                com.Parameters.AddWithValue("@Texto_Ayuda", DBNull.Value);
            com.Parameters.AddWithValue("@Dependiente", varDependiente);
            com.Parameters.AddWithValue("@DependienteTabla",Conversion.FormatNull(varDependienteTabla));
            com.Parameters.AddWithValue("@DependienteClave",Conversion.FormatNull(varDependienteClave));
            com.Parameters.AddWithValue("@DependienteDescripcion",Conversion.FormatNull(varDependienteDescripcion));
            com.Parameters.AddWithValue("@Solo_Lectura", varSolo_Lectura);
            com.Parameters.AddWithValue("@Orden",Conversion.FormatNull(varOrden));
            com.Parameters.AddWithValue("@Carpeta",Conversion.FormatNull(varCarpeta));
            com.Parameters.AddWithValue("@Columna",Conversion.FormatNull(varColumna));
            com.Parameters.AddWithValue("@Total", varTotal);
            com.Parameters.AddWithValue("@Filtro", varFiltro);
            com.Parameters.AddWithValue("@Tipo_de_Control",Conversion.FormatNull(varTipo_de_Control));

            com.CommandType =CommandType.StoredProcedure;
            sKeyDTID = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varDTID = sKeyDTID;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTMetadata");
            throw ex; 
        }
    }

    public bool Delete(int? KeyDTID, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyDTID.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTMetadata");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTMetadata";
com.Parameters.AddWithValue("@DTID",KeyDTID);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTMetadata");
                throw ex; 
            }
            return result;
        //}
    }
    public DataSet GetByKey(int? KeyDTID, Boolean ConRelaciones){
        DataSet ds;
        if (KeyDTID == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTMetadata";
            else
                com.CommandText="sp_GetTTMetadata";
com.Parameters.AddWithValue("@DTID",KeyDTID);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
            DTID = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_DTID"]);
            DNTID = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_DNTID"]);
            ProcesoId = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_ProcesoId"]);
            Nombre = ds.Tables[0].Rows[0]["TTMetadata_Nombre"].ToString().TrimEnd(' ');
            Descripcion = ds.Tables[0].Rows[0]["TTMetadata_Descripcion"].ToString().TrimEnd(' ');
            Tipo_de_Dato = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Tipo_de_Dato"]);
            Longitud = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Longitud"]);
            Decimal = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Decimal"]);
            Renglones = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Renglones"]);
            Identificador = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Identificador"]);
            Secuencial = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Secuencial"]);
            Obligatorio = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Obligatorio"]);
            Valor_por_defecto = ds.Tables[0].Rows[0]["TTMetadata_Valor_por_defecto"].ToString().TrimEnd(' ');
            Visible = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Visible"]);
            Texto_Ayuda = ds.Tables[0].Rows[0]["TTMetadata_Texto_Ayuda"].ToString().TrimEnd(' ');
            Dependiente = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Dependiente"]);
            DependienteTabla = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_DependienteTabla"]);
            DependienteClave = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_DependienteClave"]);
            DependienteDescripcion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_DependienteDescripcion"]);
            Solo_Lectura = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Solo_Lectura"]);
            Orden = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Orden"]);
            Carpeta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Carpeta"]);
            Columna = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Columna"]);
            Total = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Total"]);
            Filtro = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTMetadata_Filtro"]);
            Tipo_de_Control = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTMetadata_Tipo_de_Control"]);



            }
            return ds;
        //}
    }
    public Int32 CurrentPosicion(int? KeyDTID)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTMetadata";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTMetadataCS.TTMetadataFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTMetadata", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTMetadata_DTID"]) == KeyDTID)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyDTID){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTMetadata";
com.Parameters.AddWithValue("@DTID",KeyDTID);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataDNTIDControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ComboBox)ctr).ValueMember = "DNTID";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre_Tabla"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ListBox)ctr).ValueMember = "DNTID";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre_Tabla";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "DNTID";
                }
            }
*///            public DataTable FillDataDNTID(Object ctr, String Filtro){
            public DataTable FillDataDNTID(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataDNTIDControl(ctr, dt);
                return dt;
            }
//            public void FillDataDNTID(Object ctr){
            public DataTable FillDataDNTID(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataDNTIDControl(ctr, dt);
                return dt;
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
                com.CommandText = "sp_selTTMetadata_Relacion_TTProceso";
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
                com.CommandText = "sp_selTTMetadata_Relacion_TTProceso";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataProcesoIdControl(ctr, dt);
                return dt;
            }
/*            private void FillDataDependienteTablaControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ComboBox)ctr).ValueMember = "DNTID";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre_Tabla"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre_Tabla";
                        ((ListBox)ctr).ValueMember = "DNTID";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre_Tabla";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "DNTID";
                }
            }
*///            public DataTable FillDataDependienteTabla(Object ctr, String Filtro){
            public DataTable FillDataDependienteTabla(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataDependienteTablaControl(ctr, dt);
                return dt;
            }
//            public void FillDataDependienteTabla(Object ctr){
            public DataTable FillDataDependienteTabla(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTDNT";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataDependienteTablaControl(ctr, dt);
                return dt;
            }
/*            private void FillDataDependienteClaveControl(Object ctr, DataTable dt){
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
*///        public void FillDataDependienteClave(Object ctr){
        public DataTable FillDataDependienteClave(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTMetadata_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataDependienteClaveControl(ctr, dt);
            return dt;
        }
        //public void FillDataDependienteClave(Object ctr, int Key){
        public DataTable FillDataDependienteClave(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTMetadata_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DNTID",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataDependienteClaveControl(ctr, dt);
            return dt;
        }
/*            private void FillDataDependienteDescripcionControl(Object ctr, DataTable dt){
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
*///        public void FillDataDependienteDescripcion(Object ctr){
        public DataTable FillDataDependienteDescripcion(){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTMetadata_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DependienteClave", DBNull.Value);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataDependienteDescripcionControl(ctr, dt);
            return dt;
        }
        //public void FillDataDependienteDescripcion(Object ctr, int Key){
        public DataTable FillDataDependienteDescripcion(int Key){
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTMetadata_Relacion_TTMetadata";
            com.Parameters.AddWithValue("@DependienteClave",Key);
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //FillDataDependienteDescripcionControl(ctr, dt);
            return dt;
        }
/*            private void FillDataTipo_de_ControlControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "IdTipoControl";
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
                        ((ListBox)ctr).ValueMember = "IdTipoControl";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdTipoControl";
                }
            }
*///            public DataTable FillDataTipo_de_Control(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Control(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTTipo_de_Control";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_ControlControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Control(Object ctr){
            public DataTable FillDataTipo_de_Control(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTMetadata_Relacion_TTTipo_de_Control";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_ControlControl(ctr, dt);
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
        ev.Graphics.DrawString("TTMetadata", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("DTID: " + this.varDTID, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varDNTID != null)
        {
            TTDNTCS.objectBussinessTTDNT myRelationWhitTTDNT = new TTDNTCS.objectBussinessTTDNT();
            myRelationWhitTTDNT.GetByKey(this.varDNTID, true);
            ev.Graphics.DrawString("DNTID: " + myRelationWhitTTDNT.Nombre_Tabla , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("DNTID: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        if (this.varProcesoId != null)
        {
            TTProcesoCS.objectBussinessTTProceso myRelationWhitTTProceso = new TTProcesoCS.objectBussinessTTProceso();
            myRelationWhitTTProceso.GetByKey(this.varProcesoId, true);
            ev.Graphics.DrawString("ProcesoId: " + myRelationWhitTTProceso.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("ProcesoId: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        ev.Graphics.DrawString("Nombre: " + this.varNombre, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Descripción: " + this.varDescripcion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Tipo_de_Dato: " + this.varTipo_de_Dato, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Longitud: " + this.varLongitud, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Decimal: " + this.varDecimal, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Renglones: " + this.varRenglones, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Identificador: " + this.varIdentificador, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Secuencial: " + this.varSecuencial, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Obligatorio: " + this.varObligatorio, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Valor por defecto: " + this.varValor_por_defecto, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Visible: " + this.varVisible, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Texto Ayuda: " + this.varTexto_Ayuda, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Dependiente: " + this.varDependiente, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varDependienteTabla != null)
        {
            TTDNTCS.objectBussinessTTDNT myRelationWhitTTDNT = new TTDNTCS.objectBussinessTTDNT();
            myRelationWhitTTDNT.GetByKey(this.varDependienteTabla, true);
            ev.Graphics.DrawString("DependienteTabla: " + myRelationWhitTTDNT.Nombre_Tabla , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("DependienteTabla: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        if (this.varDependienteClave != null)
        {
            TTMetadataCS.objectBussinessTTMetadata myRelationWhitTTMetadata = new TTMetadataCS.objectBussinessTTMetadata();
            myRelationWhitTTMetadata.GetByKey(this.varDependienteClave, true);
            ev.Graphics.DrawString("DependienteClave: " + myRelationWhitTTMetadata.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("DependienteClave: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        if (this.varDependienteDescripcion != null)
        {
            TTMetadataCS.objectBussinessTTMetadata myRelationWhitTTMetadata = new TTMetadataCS.objectBussinessTTMetadata();
            myRelationWhitTTMetadata.GetByKey(this.varDependienteDescripcion, true);
            ev.Graphics.DrawString("DependienteDescripcion: " + myRelationWhitTTMetadata.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("DependienteDescripcion: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        ev.Graphics.DrawString("Solo Lectura: " + this.varSolo_Lectura, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Orden: " + this.varOrden, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Carpeta: " + this.varCarpeta, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Columna: " + this.varColumna, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Total: " + this.varTotal, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Filtro: " + this.varFiltro, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varTipo_de_Control != null)
        {
            TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control myRelationWhitTTTipo_de_Control = new TTTipo_de_ControlCS.objectBussinessTTTipo_de_Control();
            myRelationWhitTTTipo_de_Control.GetByKey(this.varTipo_de_Control, true);
            ev.Graphics.DrawString("Tipo de Control: " + myRelationWhitTTTipo_de_Control.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("Tipo de Control: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "13026")
            {
                this.Filters[indexFilter].DTID = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13024")
            {
                this.Filters[indexFilter].DNTID = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDNTCS.TTDNTFilters[])filter;
            }
            if (sDTid == "13025")
            {
                this.Filters[indexFilter].ProcesoId = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProcesoCS.TTProcesoFilters[])filter;
            }
            if (sDTid == "13027")
            {
                this.Filters[indexFilter].Nombre = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13028")
            {
                this.Filters[indexFilter].Descripcion = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13029")
            {
                this.Filters[indexFilter].Tipo_de_Dato = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13030")
            {
                this.Filters[indexFilter].Longitud = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13031")
            {
                this.Filters[indexFilter].Decimal = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13032")
            {
                this.Filters[indexFilter].Renglones = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13033")
            {
                this.Filters[indexFilter].Identificador = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13034")
            {
                this.Filters[indexFilter].Secuencial = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13035")
            {
                this.Filters[indexFilter].Obligatorio = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13036")
            {
                this.Filters[indexFilter].Valor_por_defecto = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13037")
            {
                this.Filters[indexFilter].Visible = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13038")
            {
                this.Filters[indexFilter].Texto_Ayuda = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13039")
            {
                this.Filters[indexFilter].Dependiente = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13040")
            {
                this.Filters[indexFilter].DependienteTabla = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDNTCS.TTDNTFilters[])filter;
            }
            if (sDTid == "13041")
            {
                this.Filters[indexFilter].DependienteClave = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTMetadataCS.TTMetadataFilters[])filter;
            }
            if (sDTid == "13042")
            {
                this.Filters[indexFilter].DependienteDescripcion = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTMetadataCS.TTMetadataFilters[])filter;
            }
            if (sDTid == "13043")
            {
                this.Filters[indexFilter].Solo_Lectura = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13044")
            {
                this.Filters[indexFilter].Orden = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13045")
            {
                this.Filters[indexFilter].Carpeta = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13046")
            {
                this.Filters[indexFilter].Columna = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13047")
            {
                this.Filters[indexFilter].Total = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "13603")
            {
                this.Filters[indexFilter].Filtro = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "15024")
            {
                this.Filters[indexFilter].Tipo_de_Control = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTTipo_de_ControlCS.TTTipo_de_ControlFilters[])filter;
            }

        }
    }
}
