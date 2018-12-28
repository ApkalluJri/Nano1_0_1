using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Solicitudes_Via_AppCS
{
    public class Solicitudes_Via_AppFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario_que_Registra =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario_que_Registra;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario_que_Registra{
            get { return varUsuario_que_Registra; }
            set { varUsuario_que_Registra = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Registro =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Registro{
            get { return varFecha_de_Registro; }
            set { varFecha_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varHora_de_Registro = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Hora_de_Registro
        {
            get { return varHora_de_Registro; }
            set { varHora_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCorreo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Correo
        {
            get { return varCorreo; }
            set { varCorreo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varOpcion =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Opciones_de_Solicitud_via_AppCS.Opciones_de_Solicitud_via_AppFilters[] varOpcion;
        public TTClassSpecials.FiltersTypes.Dependientes Opcion{
            get { return varOpcion; }
            set { varOpcion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varLada = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Lada
        {
            get { return varLada; }
            set { varLada = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTelefono = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Telefono
        {
            get { return varTelefono; }
            set { varTelefono = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEstatus =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Estatus_de_Solicitud_Via_AppCS.Estatus_de_Solicitud_Via_AppFilters[] varEstatus;
        public TTClassSpecials.FiltersTypes.Dependientes Estatus{
            get { return varEstatus; }
            set { varEstatus = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObservatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ObservatorioCS.ObservatorioFilters[] varObservatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Observatorio{
            get { return varObservatorio; }
            set { varObservatorio = value; }
        }

    }
public class objectBussinessSolicitudes_Via_App : IDisposable
{
    public int iProcess = 29990;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Solicitudes_Via_AppFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varUsuario_que_Registra;
	private DateTime? varFecha_de_Registro;
	private String varHora_de_Registro;
	private String varNombre;
	private String varCorreo;
	private int? varOpcion;
	private String varDescripcion;
	private String varLada;
	private String varTelefono;
	private int? varEstatus;
	private int? varObservatorio;


    bool disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed ressources
            }
        }
        //dispose unmanaged ressources
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }		
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

    public Solicitudes_Via_AppFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Solicitudes_Via_AppFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Solicitudes_Via_AppFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Usuario_que_Registra{
        get { return varUsuario_que_Registra;}
        set { varUsuario_que_Registra = value;}
    }
    public DateTime? Fecha_de_Registro{
        get { return varFecha_de_Registro;}
        set { varFecha_de_Registro = value;}
    }
    public String Hora_de_Registro{
        get { return varHora_de_Registro;}
        set { varHora_de_Registro = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Correo{
        get { return varCorreo;}
        set { varCorreo = value;}
    }
    public int? Opcion{
        get { return varOpcion;}
        set { varOpcion = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public String Lada{
        get { return varLada;}
        set { varLada = value;}
    }
    public String Telefono{
        get { return varTelefono;}
        set { varTelefono = value;}
    }
    public int? Estatus{
        get { return varEstatus;}
        set { varEstatus = value;}
    }
    public int? Observatorio{
        get { return varObservatorio;}
        set { varObservatorio = value;}
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
            com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Solicitudes_Via_AppCS.Solicitudes_Via_AppFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Solicitudes_Via_App", fil);
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
                com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App";
        else
            com.CommandText="sp_SelAllSolicitudes_Via_App";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Solicitudes_Via_AppCS.Solicitudes_Via_AppFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Solicitudes_Via_App", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Solicitudes_Via_App", fil);
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
                  string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Solicitudes_Via_App_Folio": sortExpression = "Solicitudes_Via_App.Folio"; break;  case "Solicitudes_Via_App_Usuario_que_Registra": sortExpression = "Solicitudes_Via_App.Usuario_que_Registra"; break;  case "Usuario_que_Registra_Nombre": sortExpression = "Usuario_que_Registra.Nombre"; break;  case "Solicitudes_Via_App_Fecha_de_Registro": sortExpression = "Solicitudes_Via_App.Fecha_de_Registro"; break;  case "Solicitudes_Via_App_Hora_de_Registro": sortExpression = "Solicitudes_Via_App.Hora_de_Registro"; break;  case "Solicitudes_Via_App_Nombre": sortExpression = "Solicitudes_Via_App.Nombre"; break;  case "Solicitudes_Via_App_Correo": sortExpression = "Solicitudes_Via_App.Correo"; break;  case "Solicitudes_Via_App_Opcion": sortExpression = "Solicitudes_Via_App.Opcion"; break;  case "Opcion_Descripcion": sortExpression = "Opcion.Descripcion"; break;  case "Solicitudes_Via_App_Descripcion": sortExpression = "Solicitudes_Via_App.Descripcion"; break;  case "Solicitudes_Via_App_Lada": sortExpression = "Solicitudes_Via_App.Lada"; break;  case "Solicitudes_Via_App_Telefono": sortExpression = "Solicitudes_Via_App.Telefono"; break;  case "Solicitudes_Via_App_Estatus": sortExpression = "Solicitudes_Via_App.Estatus"; break;  case "Estatus_Descripcion": sortExpression = "Estatus.Descripcion"; break;  case "Solicitudes_Via_App_Observatorio": sortExpression = "Solicitudes_Via_App.Observatorio"; break;  case "Observatorio_Nombre": sortExpression = "Observatorio.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Solicitudes_Via_App.Folio, Solicitudes_Via_App.Usuario_que_Registra, Usuario_que_Registra.Nombre, Solicitudes_Via_App.Fecha_de_Registro, Solicitudes_Via_App.Hora_de_Registro, Solicitudes_Via_App.Nombre, Solicitudes_Via_App.Correo, Solicitudes_Via_App.Opcion, Opcion.Descripcion, Solicitudes_Via_App.Descripcion, Solicitudes_Via_App.Lada, Solicitudes_Via_App.Telefono, Solicitudes_Via_App.Estatus, Estatus.Descripcion, Solicitudes_Via_App.Observatorio, Observatorio.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opcion.Descripcion AS Opcion_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre ";             string fieldsForExport = " Solicitudes_Via_App.Folio As [Folio],        Solicitudes_Via_App.Usuario_que_Registra AS [Usuario que Registra],        Usuario_que_Registra.Nombre AS [Usuario que Registra Nombre],        Solicitudes_Via_App.Fecha_de_Registro As [Fecha de Registro],        Solicitudes_Via_App.Hora_de_Registro As [Hora de Registro],        Solicitudes_Via_App.Nombre As [Nombre],        Solicitudes_Via_App.Correo As [Correo],        Solicitudes_Via_App.Opcion AS [Opcion],        Opcion.Descripcion AS [Opcion Descripcion],        Solicitudes_Via_App.Descripcion As [Descripcion],        Solicitudes_Via_App.Lada As [Lada],        Solicitudes_Via_App.Telefono As [Telefono],        Solicitudes_Via_App.Estatus AS [Estatus],        Estatus.Descripcion AS [Estatus Descripcion],        Solicitudes_Via_App.Observatorio AS [Observatorio],        Observatorio.Nombre AS [Observatorio Nombre] ";             string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opcion.Descripcion AS Opcion_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Solicitudes_Via_App.Folio, Solicitudes_Via_App.Usuario_que_Registra, Usuario_que_Registra.Nombre, Solicitudes_Via_App.Fecha_de_Registro, Solicitudes_Via_App.Hora_de_Registro, Solicitudes_Via_App.Nombre, Solicitudes_Via_App.Correo, Solicitudes_Via_App.Opcion, Opcion.Descripcion, Solicitudes_Via_App.Descripcion, Solicitudes_Via_App.Lada, Solicitudes_Via_App.Telefono, Solicitudes_Via_App.Estatus, Estatus.Descripcion, Solicitudes_Via_App.Observatorio, Observatorio.Nombre" : Order);         string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opcion.Descripcion AS Opcion_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Solicitudes_Via_App.Folio, Solicitudes_Via_App.Usuario_que_Registra, Usuario_que_Registra.Nombre, Solicitudes_Via_App.Fecha_de_Registro, Solicitudes_Via_App.Hora_de_Registro, Solicitudes_Via_App.Nombre, Solicitudes_Via_App.Correo, Solicitudes_Via_App.Opcion, Opcion.Descripcion, Solicitudes_Via_App.Descripcion, Solicitudes_Via_App.Lada, Solicitudes_Via_App.Telefono, Solicitudes_Via_App.Estatus, Estatus.Descripcion, Solicitudes_Via_App.Observatorio, Observatorio.Nombre" : Order);         string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opcion.Descripcion AS Opcion_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Solicitudes_Via_App.Folio, Solicitudes_Via_App.Usuario_que_Registra, Usuario_que_Registra.Nombre, Solicitudes_Via_App.Fecha_de_Registro, Solicitudes_Via_App.Hora_de_Registro, Solicitudes_Via_App.Nombre, Solicitudes_Via_App.Correo, Solicitudes_Via_App.Opcion, Opcion.Descripcion, Solicitudes_Via_App.Descripcion, Solicitudes_Via_App.Lada, Solicitudes_Via_App.Telefono, Solicitudes_Via_App.Estatus, Estatus.Descripcion, Solicitudes_Via_App.Observatorio, Observatorio.Nombre" : Order);         string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opcion.Descripcion AS Opcion_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus.Descripcion AS Estatus_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre ";         Order = (Order == string.Empty || Order == null ? "Solicitudes_Via_App.Folio, Solicitudes_Via_App.Usuario_que_Registra, Usuario_que_Registra.Nombre, Solicitudes_Via_App.Fecha_de_Registro, Solicitudes_Via_App.Hora_de_Registro, Solicitudes_Via_App.Nombre, Solicitudes_Via_App.Correo, Solicitudes_Via_App.Opcion, Opcion.Descripcion, Solicitudes_Via_App.Descripcion, Solicitudes_Via_App.Lada, Solicitudes_Via_App.Telefono, Solicitudes_Via_App.Estatus, Estatus.Descripcion, Solicitudes_Via_App.Observatorio, Observatorio.Nombre" : Order);         string from = " from (((( Solicitudes_Via_App WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App as Opcion WITH(NoLock) ON Opcion.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App as Estatus WITH(NoLock) ON Estatus.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App";
        else
            com.CommandText="sp_SelAllSolicitudes_Via_App";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Solicitudes_Via_AppCS.Solicitudes_Via_AppFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Solicitudes_Via_App", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Solicitudes_Via_App", fil);
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

        db.BeginTransaction("Solicitudes_Via_App");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsSolicitudes_Via_App";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Opcion",Conversion.FormatNull(varOpcion));
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varLada!=null)
            {
                if (varLada != "")
                    com.Parameters.AddWithValue("@Lada", Convierte(varLada, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }            if (varTelefono!=null)
            {
                if (varTelefono != "")
                    com.Parameters.AddWithValue("@Telefono", Convierte(varTelefono, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Solicitudes_Via_App");
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

        db.BeginTransaction("Solicitudes_Via_App");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsSolicitudes_Via_App";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Opcion",Conversion.FormatNull(varOpcion));
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varLada!=null)
            {
                if (varLada != "")
                    com.Parameters.AddWithValue("@Lada", Convierte(varLada, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }            if (varTelefono!=null)
            {
                if (varTelefono != "")
                    com.Parameters.AddWithValue("@Telefono", Convierte(varTelefono, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Solicitudes_Via_App");
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

        db.BeginTransaction("Solicitudes_Via_App");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdSolicitudes_Via_App";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro", varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Opcion",Conversion.FormatNull(varOpcion));
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            if (varLada!=null)
            {
                if (varLada != "")
                    com.Parameters.AddWithValue("@Lada", Convierte(varLada, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Lada", DBNull.Value);
            }            if (varTelefono!=null)
            {
                if (varTelefono != "")
                    com.Parameters.AddWithValue("@Telefono", Convierte(varTelefono, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Telefono", DBNull.Value);
            }            com.Parameters.AddWithValue("@Estatus",Conversion.FormatNull(varEstatus));
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Solicitudes_Via_App");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Solicitudes_Via_App");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelSolicitudes_Via_App";
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
                    db.RollBackTransaction("Solicitudes_Via_App");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Folio"]);
            Usuario_que_Registra = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Usuario_que_Registra"]);
            Fecha_de_Registro = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Fecha_de_Registro"]);
            Hora_de_Registro = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Hora_de_Registro"].ToString().TrimEnd(' ');
            Nombre = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Nombre"].ToString();
            Correo = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Correo"].ToString();
            Opcion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Opcion"]);
            Descripcion = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Descripcion"].ToString();
            Lada = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Lada"].ToString();
            Telefono = ds.Tables[0].Rows[0]["Solicitudes_Via_App_Telefono"].ToString();
            Estatus = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Estatus"]);
            Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Solicitudes_Via_App_Observatorio"]);



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
                com.CommandText="sp_GetComplete_Solicitudes_Via_App";
            else
                com.CommandText="sp_GetSolicitudes_Via_App";
com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_que_Registra(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Usuario_que_Registra = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Registro(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Fecha_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyHora_de_Registro(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Hora_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCorreo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Correo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyOpcion(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Opcion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDescripcion(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Descripcion = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyLada(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Lada = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTelefono(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Telefono = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstatus(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Estatus = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObservatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Solicitudes_Via_App.Folio As Solicitudes_Via_App_Folio,        Solicitudes_Via_App.Usuario_que_Registra AS Solicitudes_Via_App_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Solicitudes_Via_App.Fecha_de_Registro As Solicitudes_Via_App_Fecha_de_Registro,        Solicitudes_Via_App.Hora_de_Registro As Solicitudes_Via_App_Hora_de_Registro,        Solicitudes_Via_App.Nombre As Solicitudes_Via_App_Nombre,        Solicitudes_Via_App.Correo As Solicitudes_Via_App_Correo,        Solicitudes_Via_App.Opcion AS Solicitudes_Via_App_Opcion,        Opciones_de_Solicitud_via_App.Descripcion AS Opciones_de_Solicitud_via_App_Descripcion,        Solicitudes_Via_App.Descripcion As Solicitudes_Via_App_Descripcion,        Solicitudes_Via_App.Lada As Solicitudes_Via_App_Lada,        Solicitudes_Via_App.Telefono As Solicitudes_Via_App_Telefono,        Solicitudes_Via_App.Estatus AS Solicitudes_Via_App_Estatus,        Estatus_de_Solicitud_Via_App.Descripcion AS Estatus_de_Solicitud_Via_App_Descripcion,        Solicitudes_Via_App.Observatorio AS Solicitudes_Via_App_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre   from (((( Solicitudes_Via_App       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Solicitudes_Via_App.Usuario_que_Registra)       LEFT JOIN Opciones_de_Solicitud_via_App ON Opciones_de_Solicitud_via_App.Clave=Solicitudes_Via_App.Opcion)       LEFT JOIN Estatus_de_Solicitud_Via_App ON Estatus_de_Solicitud_Via_App.Clave=Solicitudes_Via_App.Estatus)       LEFT JOIN Observatorio ON Observatorio.Clave=Solicitudes_Via_App.Observatorio)           Where Solicitudes_Via_App.Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Solicitudes_Via_App";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Solicitudes_Via_AppCS.Solicitudes_Via_AppFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Solicitudes_Via_App", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Solicitudes_Via_App_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetSolicitudes_Via_App";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataUsuario_que_RegistraControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
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
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataUsuario_que_Registra(Object ctr, String Filtro){
            public DataTable FillDataUsuario_que_Registra(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario_que_Registra(Object ctr){
            public DataTable FillDataUsuario_que_Registra(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
/*            private void FillDataOpcionControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataOpcion(Object ctr, String Filtro){
            public DataTable FillDataOpcion(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Opciones_de_Solicitud_via_App";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataOpcionControl(ctr, dt);
                return dt;
            }
//            public void FillDataOpcion(Object ctr){
            public DataTable FillDataOpcion(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Opciones_de_Solicitud_via_App";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataOpcionControl(ctr, dt);
                return dt;
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
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Estatus_de_Solicitud_Via_App";
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
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Estatus_de_Solicitud_Via_App";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEstatusControl(ctr, dt);
                return dt;
            }
/*            private void FillDataObservatorioControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataObservatorio(Object ctr, String Filtro){
            public DataTable FillDataObservatorio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataObservatorioControl(ctr, dt);
                return dt;
            }
//            public void FillDataObservatorio(Object ctr){
            public DataTable FillDataObservatorio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selSolicitudes_Via_App_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataObservatorioControl(ctr, dt);
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
                //Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                //Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                //MyFiltersObligatories[iViews] = MySearch.Filter;
                //MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
    }
}
