using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Usuarios_Registrados_en_ObservatoriosCS
{
    public class Usuarios_Registrados_en_ObservatoriosFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varClave =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Clave{
            get { return varClave; }
            set { varClave = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObservatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ObservatorioCS.ObservatorioFilters[] varObservatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Observatorio{
            get { return varObservatorio; }
            set { varObservatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Registro_de_UsuarioCS.Registro_de_UsuarioFilters[] varUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario{
            get { return varUsuario; }
            set { varUsuario = value; }
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
        private TTClassSpecials.FiltersTypes.String varContrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Ingreso =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Ingreso{
            get { return varFecha_de_Ingreso; }
            set { varFecha_de_Ingreso = value; }
        }
        private TTClassSpecials.FiltersTypes.String varToken = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Token
        {
            get { return varToken; }
            set { varToken = value; }
        }
        private TTClassSpecials.FiltersTypes.String varIdentificador_Dispositivo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Identificador_Dispositivo
        {
            get { return varIdentificador_Dispositivo; }
            set { varIdentificador_Dispositivo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Dispositivo =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Tipo_de_DispositivoCS.Tipo_de_DispositivoFilters[] varTipo_de_Dispositivo;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Dispositivo{
            get { return varTipo_de_Dispositivo; }
            set { varTipo_de_Dispositivo = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varEstado_Token = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Estado_Token
        {
            get { return varEstado_Token; }
            set { varEstado_Token = value; }
        }

    }
public class objectBussinessUsuarios_Registrados_en_Observatorios : IDisposable
{
    public int iProcess = 30330;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Usuarios_Registrados_en_ObservatoriosFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varClave;
	private int? varObservatorio;
	private int? varUsuario;
	private String varNombre;
	private String varCorreo;
	private String varContrasena;
	private DateTime? varFecha_de_Ingreso;
	private String varToken;
	private String varIdentificador_Dispositivo;
	private int? varTipo_de_Dispositivo;
	private Boolean varEstado_Token;


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

    public Usuarios_Registrados_en_ObservatoriosFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Usuarios_Registrados_en_ObservatoriosFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Usuarios_Registrados_en_ObservatoriosFilters[1];
            filters[0] = value;
        }
    }

    public int? Clave{
        get { return varClave;}
        set { varClave = value;}
    }
    public int? Observatorio{
        get { return varObservatorio;}
        set { varObservatorio = value;}
    }
    public int? Usuario{
        get { return varUsuario;}
        set { varUsuario = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Correo{
        get { return varCorreo;}
        set { varCorreo = value;}
    }
    public String Contrasena{
        get { return varContrasena;}
        set { varContrasena = value;}
    }
    public DateTime? Fecha_de_Ingreso{
        get { return varFecha_de_Ingreso;}
        set { varFecha_de_Ingreso = value;}
    }
    public String Token{
        get { return varToken;}
        set { varToken = value;}
    }
    public String Identificador_Dispositivo{
        get { return varIdentificador_Dispositivo;}
        set { varIdentificador_Dispositivo = value;}
    }
    public int? Tipo_de_Dispositivo{
        get { return varTipo_de_Dispositivo;}
        set { varTipo_de_Dispositivo = value;}
    }
    public Boolean Estado_Token{
        get { return varEstado_Token;}
        set { varEstado_Token = value;}
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
            com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Usuarios_Registrados_en_ObservatoriosCS.Usuarios_Registrados_en_ObservatoriosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Usuarios_Registrados_en_Observatorios", fil);
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
                com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios";
        else
            com.CommandText="sp_SelAllUsuarios_Registrados_en_Observatorios";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Usuarios_Registrados_en_ObservatoriosCS.Usuarios_Registrados_en_ObservatoriosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Usuarios_Registrados_en_Observatorios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Usuarios_Registrados_en_Observatorios", fil);
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
                  string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Usuarios_Registrados_en_Observatorios_Clave": sortExpression = "Usuarios_Registrados_en_Observatorios.Clave"; break;  case "Usuarios_Registrados_en_Observatorios_Observatorio": sortExpression = "Usuarios_Registrados_en_Observatorios.Observatorio"; break;  case "Observatorio_Nombre": sortExpression = "Observatorio.Nombre"; break;  case "Usuarios_Registrados_en_Observatorios_Usuario": sortExpression = "Usuarios_Registrados_en_Observatorios.Usuario"; break;  case "Usuario_Nombre": sortExpression = "Usuario.Nombre"; break;  case "Usuarios_Registrados_en_Observatorios_Nombre": sortExpression = "Usuarios_Registrados_en_Observatorios.Nombre"; break;  case "Usuarios_Registrados_en_Observatorios_Correo": sortExpression = "Usuarios_Registrados_en_Observatorios.Correo"; break;  case "Usuarios_Registrados_en_Observatorios_Contrasena": sortExpression = "Usuarios_Registrados_en_Observatorios.Contrasena"; break;  case "Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso": sortExpression = "Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso"; break;  case "Usuarios_Registrados_en_Observatorios_Token": sortExpression = "Usuarios_Registrados_en_Observatorios.Token"; break;  case "Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo": sortExpression = "Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo"; break;  case "Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo": sortExpression = "Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo"; break;  case "Tipo_de_Dispositivo_Tipo": sortExpression = "Tipo_de_Dispositivo.Tipo"; break;  case "Usuarios_Registrados_en_Observatorios_Estado_Token": sortExpression = "Usuarios_Registrados_en_Observatorios.Estado_Token"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Usuarios_Registrados_en_Observatorios.Clave, Usuarios_Registrados_en_Observatorios.Observatorio, Observatorio.Nombre, Usuarios_Registrados_en_Observatorios.Usuario, Usuario.Nombre, Usuarios_Registrados_en_Observatorios.Nombre, Usuarios_Registrados_en_Observatorios.Correo, Usuarios_Registrados_en_Observatorios.Contrasena, Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso, Usuarios_Registrados_en_Observatorios.Token, Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo, Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo, Tipo_de_Dispositivo.Tipo, Usuarios_Registrados_en_Observatorios.Estado_Token" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Usuario.Nombre AS Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token ";             string fieldsForExport = " Usuarios_Registrados_en_Observatorios.Clave As [Clave],        Usuarios_Registrados_en_Observatorios.Observatorio AS [Observatorio],        Observatorio.Nombre AS [Observatorio Nombre],        Usuarios_Registrados_en_Observatorios.Usuario AS [Usuario],        Usuario.Nombre AS [Usuario Nombre],        Usuarios_Registrados_en_Observatorios.Nombre As [Nombre],        Usuarios_Registrados_en_Observatorios.Correo As [Correo],        Usuarios_Registrados_en_Observatorios.Contrasena As [Contrasena],        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As [Fecha de Ingreso],        Usuarios_Registrados_en_Observatorios.Token As [Token],        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As [Identificador Dispositivo],        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS [Tipo de Dispositivo],        Tipo_de_Dispositivo.Tipo AS [Tipo de Dispositivo Tipo],        Usuarios_Registrados_en_Observatorios.Estado_Token As [Estado Token] ";             string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Usuario.Nombre AS Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token ";         Order = (Order == string.Empty || Order == null ? "Usuarios_Registrados_en_Observatorios.Clave, Usuarios_Registrados_en_Observatorios.Observatorio, Observatorio.Nombre, Usuarios_Registrados_en_Observatorios.Usuario, Usuario.Nombre, Usuarios_Registrados_en_Observatorios.Nombre, Usuarios_Registrados_en_Observatorios.Correo, Usuarios_Registrados_en_Observatorios.Contrasena, Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso, Usuarios_Registrados_en_Observatorios.Token, Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo, Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo, Tipo_de_Dispositivo.Tipo, Usuarios_Registrados_en_Observatorios.Estado_Token" : Order);         string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Usuario.Nombre AS Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token ";         Order = (Order == string.Empty || Order == null ? "Usuarios_Registrados_en_Observatorios.Clave, Usuarios_Registrados_en_Observatorios.Observatorio, Observatorio.Nombre, Usuarios_Registrados_en_Observatorios.Usuario, Usuario.Nombre, Usuarios_Registrados_en_Observatorios.Nombre, Usuarios_Registrados_en_Observatorios.Correo, Usuarios_Registrados_en_Observatorios.Contrasena, Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso, Usuarios_Registrados_en_Observatorios.Token, Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo, Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo, Tipo_de_Dispositivo.Tipo, Usuarios_Registrados_en_Observatorios.Estado_Token" : Order);         string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Usuario.Nombre AS Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token ";         Order = (Order == string.Empty || Order == null ? "Usuarios_Registrados_en_Observatorios.Clave, Usuarios_Registrados_en_Observatorios.Observatorio, Observatorio.Nombre, Usuarios_Registrados_en_Observatorios.Usuario, Usuario.Nombre, Usuarios_Registrados_en_Observatorios.Nombre, Usuarios_Registrados_en_Observatorios.Correo, Usuarios_Registrados_en_Observatorios.Contrasena, Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso, Usuarios_Registrados_en_Observatorios.Token, Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo, Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo, Tipo_de_Dispositivo.Tipo, Usuarios_Registrados_en_Observatorios.Estado_Token" : Order);         string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Usuario.Nombre AS Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token ";         Order = (Order == string.Empty || Order == null ? "Usuarios_Registrados_en_Observatorios.Clave, Usuarios_Registrados_en_Observatorios.Observatorio, Observatorio.Nombre, Usuarios_Registrados_en_Observatorios.Usuario, Usuario.Nombre, Usuarios_Registrados_en_Observatorios.Nombre, Usuarios_Registrados_en_Observatorios.Correo, Usuarios_Registrados_en_Observatorios.Contrasena, Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso, Usuarios_Registrados_en_Observatorios.Token, Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo, Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo, Tipo_de_Dispositivo.Tipo, Usuarios_Registrados_en_Observatorios.Estado_Token" : Order);         string from = " from ((( Usuarios_Registrados_en_Observatorios WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario as Usuario WITH(NoLock) ON Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo as Tipo_de_Dispositivo WITH(NoLock) ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios";
        else
            com.CommandText="sp_SelAllUsuarios_Registrados_en_Observatorios";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Usuarios_Registrados_en_ObservatoriosCS.Usuarios_Registrados_en_ObservatoriosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Usuarios_Registrados_en_Observatorios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Usuarios_Registrados_en_Observatorios", fil);
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

        db.BeginTransaction("Usuarios_Registrados_en_Observatorios");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsUsuarios_Registrados_en_Observatorios";
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Usuario",Conversion.FormatNull(varUsuario));
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
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Ingreso",Conversion.FormatNull(varFecha_de_Ingreso));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador_Dispositivo!=null)
            {
                if (varIdentificador_Dispositivo != "")
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", Convierte(varIdentificador_Dispositivo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Tipo_de_Dispositivo",Conversion.FormatNull(varTipo_de_Dispositivo));
            com.Parameters.AddWithValue("@Estado_Token", varEstado_Token);

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Usuarios_Registrados_en_Observatorios");
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

        db.BeginTransaction("Usuarios_Registrados_en_Observatorios");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsUsuarios_Registrados_en_Observatorios";
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Usuario",Conversion.FormatNull(varUsuario));
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
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Ingreso",Conversion.FormatNull(varFecha_de_Ingreso));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador_Dispositivo!=null)
            {
                if (varIdentificador_Dispositivo != "")
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", Convierte(varIdentificador_Dispositivo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Tipo_de_Dispositivo",Conversion.FormatNull(varTipo_de_Dispositivo));
            com.Parameters.AddWithValue("@Estado_Token", varEstado_Token);

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Usuarios_Registrados_en_Observatorios");
            }
            catch{}
            throw ex; 
        }
        return sKeyClave;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Usuarios_Registrados_en_Observatorios");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdUsuarios_Registrados_en_Observatorios";
            com.Parameters.AddWithValue("@Clave",Conversion.FormatNull(varClave));
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Usuario",Conversion.FormatNull(varUsuario));
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
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Fecha_de_Ingreso",Conversion.FormatNull(varFecha_de_Ingreso));
            if (varToken!=null)
            {
                if (varToken != "")
                    com.Parameters.AddWithValue("@Token", Convierte(varToken, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Token", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Token", DBNull.Value);
            }            if (varIdentificador_Dispositivo!=null)
            {
                if (varIdentificador_Dispositivo != "")
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", Convierte(varIdentificador_Dispositivo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Identificador_Dispositivo", DBNull.Value);
            }            com.Parameters.AddWithValue("@Tipo_de_Dispositivo",Conversion.FormatNull(varTipo_de_Dispositivo));
            com.Parameters.AddWithValue("@Estado_Token", varEstado_Token);

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varClave = sKeyClave;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Usuarios_Registrados_en_Observatorios");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyClave, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyClave.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Usuarios_Registrados_en_Observatorios");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelUsuarios_Registrados_en_Observatorios";
com.Parameters.AddWithValue("@Clave",KeyClave);
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
                    db.RollBackTransaction("Usuarios_Registrados_en_Observatorios");
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
            Clave = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Clave"]);
            Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Observatorio"]);
            Usuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Usuario"]);
            Nombre = ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Nombre"].ToString();
            Correo = ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Correo"].ToString();
            Contrasena = ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Contrasena"].ToString();
            Fecha_de_Ingreso = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso"]);
            Token = ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Token"].ToString();
            Identificador_Dispositivo = ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo"].ToString();
            Tipo_de_Dispositivo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo"]);
            if (ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Estado_Token"] != DBNull.Value)
                Estado_Token = Convert.ToBoolean(ds.Tables[0].Rows[0]["Usuarios_Registrados_en_Observatorios_Estado_Token"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyClave, Boolean ConRelaciones){
        DataSet ds;
        if (KeyClave == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_Usuarios_Registrados_en_Observatorios";
            else
                com.CommandText="sp_GetUsuarios_Registrados_en_Observatorios";
com.Parameters.AddWithValue("@Clave",KeyClave);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyClave(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Clave = '" + Key + "'";
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
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Usuario = '" + Key + "'";
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
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Nombre = '" + Key + "'";
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
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Correo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyContrasena(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Contrasena = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Ingreso(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyToken(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Token = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdentificador_Dispositivo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Dispositivo(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyEstado_Token(Boolean Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Usuarios_Registrados_en_Observatorios.Clave As Usuarios_Registrados_en_Observatorios_Clave,        Usuarios_Registrados_en_Observatorios.Observatorio AS Usuarios_Registrados_en_Observatorios_Observatorio,        Observatorio.Nombre AS Observatorio_Nombre,        Usuarios_Registrados_en_Observatorios.Usuario AS Usuarios_Registrados_en_Observatorios_Usuario,        Registro_de_Usuario.Nombre AS Registro_de_Usuario_Nombre,        Usuarios_Registrados_en_Observatorios.Nombre As Usuarios_Registrados_en_Observatorios_Nombre,        Usuarios_Registrados_en_Observatorios.Correo As Usuarios_Registrados_en_Observatorios_Correo,        Usuarios_Registrados_en_Observatorios.Contrasena As Usuarios_Registrados_en_Observatorios_Contrasena,        Usuarios_Registrados_en_Observatorios.Fecha_de_Ingreso As Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso,        Usuarios_Registrados_en_Observatorios.Token As Usuarios_Registrados_en_Observatorios_Token,        Usuarios_Registrados_en_Observatorios.Identificador_Dispositivo As Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo,        Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo AS Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo,        Tipo_de_Dispositivo.Tipo AS Tipo_de_Dispositivo_Tipo,        Usuarios_Registrados_en_Observatorios.Estado_Token As Usuarios_Registrados_en_Observatorios_Estado_Token   from ((( Usuarios_Registrados_en_Observatorios       LEFT JOIN Observatorio ON Observatorio.Clave=Usuarios_Registrados_en_Observatorios.Observatorio)       LEFT JOIN Registro_de_Usuario ON Registro_de_Usuario.Folio=Usuarios_Registrados_en_Observatorios.Usuario)       LEFT JOIN Tipo_de_Dispositivo ON Tipo_de_Dispositivo.Clave=Usuarios_Registrados_en_Observatorios.Tipo_de_Dispositivo)           Where Usuarios_Registrados_en_Observatorios.Estado_Token = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyClave)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Usuarios_Registrados_en_Observatorios";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Usuarios_Registrados_en_ObservatoriosCS.Usuarios_Registrados_en_ObservatoriosFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Usuarios_Registrados_en_Observatorios", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Usuarios_Registrados_en_Observatorios_Clave"]) == KeyClave)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyClave){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetUsuarios_Registrados_en_Observatorios";
com.Parameters.AddWithValue("@Clave",KeyClave);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
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
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Observatorio";
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
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataObservatorioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataUsuarioControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataUsuario(Object ctr, String Filtro){
            public DataTable FillDataUsuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Registro_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario(Object ctr){
            public DataTable FillDataUsuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Registro_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuarioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTipo_de_DispositivoControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Tipo";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Tipo"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Tipo";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Tipo";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataTipo_de_Dispositivo(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Dispositivo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Tipo_de_Dispositivo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_DispositivoControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Dispositivo(Object ctr){
            public DataTable FillDataTipo_de_Dispositivo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selUsuarios_Registrados_en_Observatorios_Relacion_Tipo_de_Dispositivo";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_DispositivoControl(ctr, dt);
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
