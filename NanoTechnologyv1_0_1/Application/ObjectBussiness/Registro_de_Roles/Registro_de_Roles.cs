using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Registro_de_RolesCS
{
    public class Registro_de_RolesFilters
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
        private TTClassSpecials.FiltersTypes.String varClave_de_Acceso = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Clave_de_Acceso
        {
            get { return varClave_de_Acceso; }
            set { varClave_de_Acceso = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCorreo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Correo
        {
            get { return varCorreo; }
            set { varCorreo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRol =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Rol_de_UsuarioCS.Rol_de_UsuarioFilters[] varRol;
        public TTClassSpecials.FiltersTypes.Dependientes Rol{
            get { return varRol; }
            set { varRol = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario_de_Sistema =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario_de_Sistema;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario_de_Sistema{
            get { return varUsuario_de_Sistema; }
            set { varUsuario_de_Sistema = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObservatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters[] varObservatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Observatorio{
            get { return varObservatorio; }
            set { varObservatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.String varObservatorios = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Observatorios
        {
            get { return varObservatorios; }
            set { varObservatorios = value; }
        }

    }
public class objectBussinessRegistro_de_Roles : IDisposable
{
    public int iProcess = 30351;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Registro_de_RolesFilters[] filters; 
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
	private String varClave_de_Acceso;
	private String varContrasena;
	private String varCorreo;
	private int? varRol;
	private int? varUsuario_de_Sistema;
	private MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[] varObservatorio;
	private String varObservatorios;


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

    public Registro_de_RolesFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Registro_de_RolesFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Registro_de_RolesFilters[1];
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
    public String Clave_de_Acceso{
        get { return varClave_de_Acceso;}
        set { varClave_de_Acceso = value;}
    }
    public String Contrasena{
        get { return varContrasena;}
        set { varContrasena = value;}
    }
    public String Correo{
        get { return varCorreo;}
        set { varCorreo = value;}
    }
    public int? Rol{
        get { return varRol;}
        set { varRol = value;}
    }
    public int? Usuario_de_Sistema{
        get { return varUsuario_de_Sistema;}
        set { varUsuario_de_Sistema = value;}
    }
    public MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[] Observatorio{
        get { return varObservatorio;}
        set { varObservatorio = value;}
    }
    public String Observatorios{
        get { return varObservatorios;}
        set { varObservatorios = value;}
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
            com.CommandText = "sp_SelAllComplete_Registro_de_Roles_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Registro_de_Roles";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Registro_de_RolesCS.Registro_de_RolesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Roles", fil);
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
                com.CommandText = "sp_SelAllComplete_Registro_de_Roles_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Roles";
        else
            com.CommandText="sp_SelAllRegistro_de_Roles";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_RolesCS.Registro_de_RolesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Roles", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Roles", fil);
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

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object keyRegistro_de_Roles = dr["Registro_de_Roles_Folio"];

            MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol MyDataObservatorio = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
            MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters MyDataFilterObservatorio = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters();
            
            MyDataFilterObservatorio.Clave.List = new String[1];
            MyDataFilterObservatorio.Clave.List[0] = keyRegistro_de_Roles.ToString();
            
            MyDataObservatorio.Filters = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters[1];
            MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
            DataSet dsListBox = MyDataObservatorio.SelAll(true);

            int columnIndex = 0;
            if (dsListBox.Tables[0].Columns.Count >= 4)
                columnIndex = 3;
            else if (dsListBox.Tables[0].Columns.Count >= 2)
                columnIndex = 1;

            try
            {
                foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                    dr["Registro_de_Roles_Observatorio"] +=  (dr["Registro_de_Roles_Observatorio"].ToString() == string.Empty ? string.Empty : ", ") +  drlist[columnIndex].ToString();
            }
            catch{}
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
                  string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Registro_de_Roles_Folio": sortExpression = "Registro_de_Roles.Folio"; break;  case "Registro_de_Roles_Usuario_que_Registra": sortExpression = "Registro_de_Roles.Usuario_que_Registra"; break;  case "Usuario_que_Registra_Nombre": sortExpression = "Usuario_que_Registra.Nombre"; break;  case "Registro_de_Roles_Fecha_de_Registro": sortExpression = "Registro_de_Roles.Fecha_de_Registro"; break;  case "Registro_de_Roles_Hora_de_Registro": sortExpression = "Registro_de_Roles.Hora_de_Registro"; break;  case "Registro_de_Roles_Nombre": sortExpression = "Registro_de_Roles.Nombre"; break;  case "Registro_de_Roles_Clave_de_Acceso": sortExpression = "Registro_de_Roles.Clave_de_Acceso"; break;  case "Registro_de_Roles_Contrasena": sortExpression = "Registro_de_Roles.Contrasena"; break;  case "Registro_de_Roles_Correo": sortExpression = "Registro_de_Roles.Correo"; break;  case "Registro_de_Roles_Rol": sortExpression = "Registro_de_Roles.Rol"; break;  case "Rol_Descripcion": sortExpression = "Rol.Descripcion"; break;  case "Registro_de_Roles_Usuario_de_Sistema": sortExpression = "Registro_de_Roles.Usuario_de_Sistema"; break;  case "Usuario_de_Sistema_Nombre": sortExpression = "Usuario_de_Sistema.Nombre"; break;  case "Registro_de_Roles_Observatorios": sortExpression = "Registro_de_Roles.Observatorios"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Registro_de_Roles.Folio, Registro_de_Roles.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Roles.Fecha_de_Registro, Registro_de_Roles.Hora_de_Registro, Registro_de_Roles.Nombre, Registro_de_Roles.Clave_de_Acceso, Registro_de_Roles.Contrasena, Registro_de_Roles.Correo, Registro_de_Roles.Rol, Rol.Descripcion, Registro_de_Roles.Usuario_de_Sistema, Usuario_de_Sistema.Nombre, Registro_de_Roles.Observatorios" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol.Descripcion AS Rol_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        Usuario_de_Sistema.Nombre AS Usuario_de_Sistema_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios ";             string fieldsForExport = " Registro_de_Roles.Folio As [Folio],        Registro_de_Roles.Usuario_que_Registra AS [Usuario que Registra],        Usuario_que_Registra.Nombre AS [Usuario que Registra Nombre],        Registro_de_Roles.Fecha_de_Registro As [Fecha de Registro],        Registro_de_Roles.Hora_de_Registro As [Hora de Registro],        Registro_de_Roles.Nombre As [Nombre],        Registro_de_Roles.Clave_de_Acceso As [Clave de Acceso],        Registro_de_Roles.Contrasena As [Contrasena],        Registro_de_Roles.Correo As [Correo],        Registro_de_Roles.Rol AS [Rol],        Rol.Descripcion AS [Rol Descripcion],        Registro_de_Roles.Usuario_de_Sistema AS [Usuario de Sistema],        Usuario_de_Sistema.Nombre AS [Usuario de Sistema Nombre],        '' AS [Observatorio],        Registro_de_Roles.Observatorios As [Observatorios] ";             string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere; 

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

                foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object keyRegistro_de_Roles = dr["Registro_de_Roles_Folio"];

            MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol MyDataObservatorio = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
            MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters MyDataFilterObservatorio = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters();
            
            MyDataFilterObservatorio.Clave.List = new String[1];
            MyDataFilterObservatorio.Clave.List[0] = keyRegistro_de_Roles.ToString();
            
            MyDataObservatorio.Filters = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters[1];
            MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
            DataSet dsListBox = MyDataObservatorio.SelAll(true);

            int columnIndex = 0;
            if (dsListBox.Tables[0].Columns.Count >= 4)
                columnIndex = 3;
            else if (dsListBox.Tables[0].Columns.Count >= 2)
                columnIndex = 1;

            try
            {
                foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                    dr["Registro_de_Roles_Observatorio"] +=  (dr["Registro_de_Roles_Observatorio"].ToString() == string.Empty ? string.Empty : ", ") +  drlist[columnIndex].ToString();
            }
            catch{}
        }


        return ds;
    }
    

    //-----------------------------------------------------------Métodos para rad Grid----------------------------------------------------------------
    public string GetFullQuery(string where, string Order)
    {
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol.Descripcion AS Rol_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        Usuario_de_Sistema.Nombre AS Usuario_de_Sistema_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Roles.Folio, Registro_de_Roles.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Roles.Fecha_de_Registro, Registro_de_Roles.Hora_de_Registro, Registro_de_Roles.Nombre, Registro_de_Roles.Clave_de_Acceso, Registro_de_Roles.Contrasena, Registro_de_Roles.Correo, Registro_de_Roles.Rol, Rol.Descripcion, Registro_de_Roles.Usuario_de_Sistema, Usuario_de_Sistema.Nombre, Registro_de_Roles.Observatorios" : Order);         string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol.Descripcion AS Rol_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        Usuario_de_Sistema.Nombre AS Usuario_de_Sistema_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Roles.Folio, Registro_de_Roles.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Roles.Fecha_de_Registro, Registro_de_Roles.Hora_de_Registro, Registro_de_Roles.Nombre, Registro_de_Roles.Clave_de_Acceso, Registro_de_Roles.Contrasena, Registro_de_Roles.Correo, Registro_de_Roles.Rol, Rol.Descripcion, Registro_de_Roles.Usuario_de_Sistema, Usuario_de_Sistema.Nombre, Registro_de_Roles.Observatorios" : Order);         string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol.Descripcion AS Rol_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        Usuario_de_Sistema.Nombre AS Usuario_de_Sistema_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Roles.Folio, Registro_de_Roles.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Roles.Fecha_de_Registro, Registro_de_Roles.Hora_de_Registro, Registro_de_Roles.Nombre, Registro_de_Roles.Clave_de_Acceso, Registro_de_Roles.Contrasena, Registro_de_Roles.Correo, Registro_de_Roles.Rol, Rol.Descripcion, Registro_de_Roles.Usuario_de_Sistema, Usuario_de_Sistema.Nombre, Registro_de_Roles.Observatorios" : Order);         string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol.Descripcion AS Rol_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        Usuario_de_Sistema.Nombre AS Usuario_de_Sistema_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Roles.Folio, Registro_de_Roles.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Roles.Fecha_de_Registro, Registro_de_Roles.Hora_de_Registro, Registro_de_Roles.Nombre, Registro_de_Roles.Clave_de_Acceso, Registro_de_Roles.Contrasena, Registro_de_Roles.Correo, Registro_de_Roles.Rol, Rol.Descripcion, Registro_de_Roles.Usuario_de_Sistema, Usuario_de_Sistema.Nombre, Registro_de_Roles.Observatorios" : Order);         string from = " from ((( Registro_de_Roles WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as Usuario_de_Sistema WITH(NoLock) ON Usuario_de_Sistema.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Registro_de_Roles_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Roles";
        else
            com.CommandText="sp_SelAllRegistro_de_Roles";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Registro_de_RolesCS.Registro_de_RolesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Roles", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Roles", fil);
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

        db.BeginTransaction("Registro_de_Roles");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Roles";
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
            }            if (varClave_de_Acceso!=null)
            {
                if (varClave_de_Acceso != "")
                    com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
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
            }            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));
            com.Parameters.AddWithValue("@Usuario_de_Sistema",Conversion.FormatNull(varUsuario_de_Sistema));
            if (varObservatorios!=null)
            {
                if (varObservatorios != "")
                    com.Parameters.AddWithValue("@Observatorios", Convierte(varObservatorios, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            

            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorio_por_rol";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosInsertListBox@@
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
                db.RollBackTransaction("Registro_de_Roles");
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

        db.BeginTransaction("Registro_de_Roles");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Roles";
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
            }            if (varClave_de_Acceso!=null)
            {
                if (varClave_de_Acceso != "")
                    com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
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
            }            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));
            com.Parameters.AddWithValue("@Usuario_de_Sistema",Conversion.FormatNull(varUsuario_de_Sistema));
            if (varObservatorios!=null)
            {
                if (varObservatorios != "")
                    com.Parameters.AddWithValue("@Observatorios", Convierte(varObservatorios, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            

            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorio_por_rol";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosInsertListBox@@
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
                db.RollBackTransaction("Registro_de_Roles");
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

        db.BeginTransaction("Registro_de_Roles");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdRegistro_de_Roles";
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
            }            if (varClave_de_Acceso!=null)
            {
                if (varClave_de_Acceso != "")
                    com.Parameters.AddWithValue("@Clave_de_Acceso", Convierte(varClave_de_Acceso, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Clave_de_Acceso", DBNull.Value);
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
            }            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));
            com.Parameters.AddWithValue("@Usuario_de_Sistema",Conversion.FormatNull(varUsuario_de_Sistema));
            if (varObservatorios!=null)
            {
                if (varObservatorios != "")
                    com.Parameters.AddWithValue("@Observatorios", Convierte(varObservatorios, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Observatorios", DBNull.Value);
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;

        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKeyFolio.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from MS_Observatorio_por_rol Where Clave = '" + sKeyFolio.ToString() + "'"), UserInformation, DataReference);
            if(varObservatorio != null)
            {
                for (int i = 0;i< varObservatorio.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsMS_Observatorio_por_rol";
                    com.Parameters.AddWithValue("@Clave", sKeyFolio);
                    com.Parameters.AddWithValue("@Observatorio", varObservatorio[i].Observatorio );
//@@DatosDT.ParametrosUpdateListBox@@
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
                db.RollBackTransaction("Registro_de_Roles");
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
            db.BeginTransaction("Registro_de_Roles");
            try
            {

                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbMS_Observatorio_por_rol = new TTDataLayerCS.BD();
                DataSet recordsMS_Observatorio_por_rol = dbMS_Observatorio_por_rol.Consulta(new SqlCommand("Select Count(*) From MS_Observatorio_por_rol Where Clave = '" + KeyFolio.ToString() + "'"));
                if (recordsMS_Observatorio_por_rol.Tables.Count > 0)
                    if (recordsMS_Observatorio_por_rol.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsMS_Observatorio_por_rol = int.Parse(recordsMS_Observatorio_por_rol.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsMS_Observatorio_por_rol > 0)
                            Error = Error + "- MS Observatorio por rol \r\n"; 
                    }
                dbMS_Observatorio_por_rol.Disconnect();
                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelRegistro_de_Roles";
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
                    db.RollBackTransaction("Registro_de_Roles");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Roles_Folio"]);
            Usuario_que_Registra = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Roles_Usuario_que_Registra"]);
            Fecha_de_Registro = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Roles_Fecha_de_Registro"]);
            Hora_de_Registro = ds.Tables[0].Rows[0]["Registro_de_Roles_Hora_de_Registro"].ToString().TrimEnd(' ');
            Nombre = ds.Tables[0].Rows[0]["Registro_de_Roles_Nombre"].ToString();
            Clave_de_Acceso = ds.Tables[0].Rows[0]["Registro_de_Roles_Clave_de_Acceso"].ToString();
            Contrasena = ds.Tables[0].Rows[0]["Registro_de_Roles_Contrasena"].ToString();
            Correo = ds.Tables[0].Rows[0]["Registro_de_Roles_Correo"].ToString();
            Rol = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Roles_Rol"]);
            Usuario_de_Sistema = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Roles_Usuario_de_Sistema"]);
                {
                    MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol MyDataObservatorio = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
                    MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters MyDataFilterObservatorio = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters();
                    MyDataFilterObservatorio.Clave.List = new String[1];
                    MyDataFilterObservatorio.Clave.List[0] = Folio.Value.ToString();
                    MyDataObservatorio.Filters = new MS_Observatorio_por_rolCS.MS_Observatorio_por_rolFilters[1];
                    MyDataObservatorio.Filters[0] = MyDataFilterObservatorio;
                    DataSet dsListBox = MyDataObservatorio.SelAll(true);
                    Observatorio = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol[dsListBox.Tables[0].Rows.Count];
                    for (int i =0;i<dsListBox.Tables[0].Rows.Count;i++)
                    {
                        Observatorio[i] = new MS_Observatorio_por_rolCS.objectBussinessMS_Observatorio_por_rol();
                    Observatorio[i].Observatorio = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["MS_Observatorio_por_rol_Observatorio"].ToString());

                    }
                }
            Observatorios = ds.Tables[0].Rows[0]["Registro_de_Roles_Observatorios"].ToString();



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
                com.CommandText="sp_GetComplete_Registro_de_Roles";
            else
                com.CommandText="sp_GetRegistro_de_Roles";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Folio = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Usuario_que_Registra = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Fecha_de_Registro = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Hora_de_Registro = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyClave_de_Acceso(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Clave_de_Acceso = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Contrasena = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Correo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRol(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Rol = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_de_Sistema(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Usuario_de_Sistema = '" + Key + "'";
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
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObservatorios(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Roles.Folio As Registro_de_Roles_Folio,        Registro_de_Roles.Usuario_que_Registra AS Registro_de_Roles_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Roles.Fecha_de_Registro As Registro_de_Roles_Fecha_de_Registro,        Registro_de_Roles.Hora_de_Registro As Registro_de_Roles_Hora_de_Registro,        Registro_de_Roles.Nombre As Registro_de_Roles_Nombre,        Registro_de_Roles.Clave_de_Acceso As Registro_de_Roles_Clave_de_Acceso,        Registro_de_Roles.Contrasena As Registro_de_Roles_Contrasena,        Registro_de_Roles.Correo As Registro_de_Roles_Correo,        Registro_de_Roles.Rol AS Registro_de_Roles_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion,        Registro_de_Roles.Usuario_de_Sistema AS Registro_de_Roles_Usuario_de_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre,        '' AS Registro_de_Roles_Observatorio,        Registro_de_Roles.Observatorios As Registro_de_Roles_Observatorios   from ((( Registro_de_Roles       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Roles.Usuario_que_Registra)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Registro_de_Roles.Rol)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Roles.Usuario_de_Sistema)           Where Registro_de_Roles.Observatorios = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Registro_de_Roles";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_RolesCS.Registro_de_RolesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Roles", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Registro_de_Roles_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetRegistro_de_Roles";
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
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_TTUsuarios";
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
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRolControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataRol(Object ctr, String Filtro){
            public DataTable FillDataRol(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_Rol_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRolControl(ctr, dt);
                return dt;
            }
//            public void FillDataRol(Object ctr){
            public DataTable FillDataRol(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_Rol_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRolControl(ctr, dt);
                return dt;
            }
/*            private void FillDataUsuario_de_SistemaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataUsuario_de_Sistema(Object ctr, String Filtro){
            public DataTable FillDataUsuario_de_Sistema(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuario_de_SistemaControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario_de_Sistema(Object ctr){
            public DataTable FillDataUsuario_de_Sistema(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Roles_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_de_SistemaControl(ctr, dt);
                return dt;
            }
        	public DataTable FillDataObservatorio(){
        		DataSet ds;
        		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        		SqlCommand com = new SqlCommand();
        		com.CommandText = "sp_selMS_Observatorio_por_rol_Relacion_Observatorio";
        		com.CommandType = CommandType.StoredProcedure;
        		//ctr.Items.Clear();
        		ds = db.Consulta(com);
                                return ds.Tables[0];
//                if (ctr.GetType() == typeof(ComboBox))
//                {
//                        ((ComboBox)ctr).DataSource = ds.Tables[0];
//                        ((ComboBox)ctr).DisplayMember = "Nombre";
//                        ((ComboBox)ctr).ValueMember = "Clave";
//                        ((ComboBox)ctr).SelectedItem = null;
//                }
//                else if (ctr.GetType() == typeof(ListBox))
//                {
//                        ((ListBox)ctr).DataSource = ds.Tables[0];
//                        ((ListBox)ctr).DisplayMember = "Nombre";
//                        ((ListBox)ctr).ValueMember = "Clave";
//                        ((ListBox)ctr).ClearSelected();
//                }
//                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
//                {
//                        ((DataGridViewComboBoxColumn)ctr).DataSource = ds.Tables[0];
//                       ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
//                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
//                }
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
